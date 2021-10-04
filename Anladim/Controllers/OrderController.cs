using Anladim.Data;
using Anladim.Models.EntityFramework;
using Anladim.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anladim.Controllers
{
    public class OrderController : Controller
    {

        Context db = new Context();
        [Route("AdresListesi")]
        public ActionResult AddressList(string mail)
        {
            mail = (string)Session["LoginUserMail"];
            var loginUserId = db.Users.Where(x => x.Mail == mail).Select(x => x.UserId).FirstOrDefault();
            var model = db.UserAddresses.Where(x => x.UserId == loginUserId).ToList(); //unutma
            return View(model);
        }
        [HttpGet]
        public ActionResult NewUserAddress()
        {
            return View();
        }

        public ActionResult NewUserAddress(UserAddress userAddress, string mail)
        {
            mail = (string)Session["LoginUserMail"];
            var loginUserId = db.Users.Where(x => x.Mail == mail).Select(y => y.UserId).FirstOrDefault();
            userAddress.UserId = loginUserId;

            db.UserAddresses.Add(userAddress);
            db.SaveChanges();
            return RedirectToAction("AddressList");   
        }


        [Route("NewOrder/{id}")]
        public ActionResult NewOrder(int id, string mail)
        {
            List<Cart> cart = (List<Cart>)Session["Cart"];
            mail = (string)Session["LoginUserMail"];
            var loginUserId = db.Users.Where(x => x.Mail == mail).Select(y => y.UserId).FirstOrDefault();
            Order order = new Order();
            order.UserId = loginUserId;
            order.OrderDate = DateTime.Now;
            order.UserAddressId = id;
            order.TotalPrice = cart.Sum(x => x.Product.Price * x.Quantity);
            order.OrderProducts = new List<OrderProduct>();
            db.Orders.Add(order);
            db.SaveChanges();


            foreach (Cart item in cart)
            {
                order.OrderProducts.Add(new OrderProduct
                {
                    Quantity = item.Quantity,
                    ProductId = item.Product.ProductId,
                    Price = item.Product.Price
                });

                db.SaveChanges();
            }
            cart.Clear();
            return Redirect("/");
        }

        [Route("Order/Detail/{id}")]
        public ActionResult Detail(int id)
        {
            var model = db.Orders.Include("OrderProducts").Include("OrderProducts.Product").Include("UserAddress").Where(x => x.OrderId == id).FirstOrDefault();
            return View(model);
        }
        [Route("Siparislerim")]
        public ActionResult Index(string mail)
        {
            mail = (string)Session["LoginUserMail"];
            if (mail == null)
            {
                return RedirectToAction("Logout", "Security");
            }
            var loginUserId = db.Users.Where(x => x.Mail == mail).Select(x => x.UserId).FirstOrDefault();
            var model = db.Orders.Where(x => x.UserId == loginUserId).OrderByDescending(x => x.OrderDate).ToList();
            return View(model);
        }
        

    }
}