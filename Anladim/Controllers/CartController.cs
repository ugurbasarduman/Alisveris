using Anladim.Data;
using Anladim.Models.EntityFramework;
using Anladim.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anladim.Controllers
{
    [Authorize(Roles = "U,A")]
    public class CartController : Controller
    {
        Context db = new Context();
        private string strCart = "Cart";

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
        [NonAction]
        private int IsExist(int? id)
        {
            List<Cart> cart = (List<Cart>)Session[strCart];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId == id)
                    return i;
            }
            return -1;
        }

        public ActionResult AddToCart(int? id, string mail)
        {
            mail = (string)Session["LoginUserMail"];
            if (mail == null)
            {
                return RedirectToAction("Logout", "Security");
            }
            var loginUserId = db.Users.Where(x => x.Mail == mail).Select(x => x.UserId).FirstOrDefault();
            var model = db.Orders.Where(x => x.UserId == loginUserId).OrderByDescending(x => x.OrderDate).ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session[strCart] == null)
            {
                List<Cart> cart = new List<Cart>() {
                    new Cart(db.Products.Find(id),1)
                };
                Session[strCart] = cart;
            }
            else
            {
                List<Cart> cart = (List<Cart>)Session[strCart];
                int check = IsExist(id);
                if (check == -1)
                {
                    cart.Add(new Cart(db.Products.Find(id), 1));
                }
                else
                {
                    cart[check].Quantity++;
                }
                Session[strCart] = cart;
            }
            
            return View("Index",model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            int check = IsExist(id);
            List<Cart> cart = (List<Cart>)Session[strCart];
            if(cart.Count>0)
                cart.RemoveAt(check);
            return View("Index");
        }

        public ActionResult UpdateCart(FormCollection form)
        {
            string[] quantities = form.GetValues("quantity");
            List<Cart> cart = (List<Cart>)Session[strCart];
            for(int i = 0; i<cart.Count; i++)
            {              
                cart[i].Quantity = Convert.ToInt32(quantities[i]);
            }
            
            Session[strCart] = cart;
            return View("Index");
        }
    }
}
