﻿using Anladim.Data;
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
        // GET: Order
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
            List<Cart> lstCart = (List<Cart>)Session["Cart"];
            mail = (string)Session["LoginUserMail"];
            var loginUserId = db.Users.Where(x => x.Mail == mail).Select(y => y.UserId).FirstOrDefault();
            Order order = new Order();
            order.UserId = loginUserId;
            order.OrderDate = DateTime.Now;
            order.UserAddressId = id;
            order.TotalPrice = lstCart.Sum(x => x.Product.Price * x.Quantity);
            order.OrderProducts = new List<OrderProduct>();
            db.Orders.Add(order);
            db.SaveChanges();

            foreach (Cart cart in lstCart)
            {
                order.OrderProducts.Add(new OrderProduct
                {
                    Quantity = cart.Quantity,
                    ProductId = cart.Product.ProductId,
                    Price = cart.Product.Price
                });

                db.SaveChanges();
            }
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
        //public ActionResult NewOrder(int id, string mail)
        //{
        //    mail = (string)Session["LoginUserMail"];
        //    var loginUserId = db.Users.Where(x => x.Mail == mail).Select(y => y.UserId).FirstOrDefault();
        //    var sepet = db.Cart.Include("Product").Where(x => x.UserId == loginUserId).ToList();

        //    Order order = new Order();
        //    order.UserId = loginUserId;
        //    order.UserAddressId = id;
        //    order.TotalPrice = sepet.Sum(x => x.Product.Price);
        //    order.OrderDate = DateTime.Now;
        //    order.OrderProducts = new List<OrderProduct>();

        //    foreach (var item in sepet)
        //    {
        //        order.OrderProducts.Add(new OrderProduct
        //        {
        //            OrderId = loginUserId,
        //            Quantity = item.Quantity,
        //            ProductId = item.ProductId
        //        });
        //        db.Cart.Remove(item);
        //    }
        //    db.Orders.Add(order);
        //    //var orderid = db.Orders.Where(x => x.UserId == loginUserId).OrderByDescending(q => q.OrderDate).FirstOrDefault().OrderId;
        //    db.SaveChanges();
        //    return Redirect("/");
        //    //return RedirectToAction("Detail",new {id=orderid });
        //}

    }
}