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
    [Authorize(Roles = "U,A")] //Duzenlenecek
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

        public ActionResult OrderNow(int? id, string mail)
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

















        //public ActionResult UpdateCart(FormCollection form)
        //{
        //    string[] quantities = form.GetValues("quantity");
        //    List<Cart> lstCart = (List<Cart>)Session[strCart];
        //    for (int i = 0; i < lstCart.Count; i++)
        //    {
        //        lstCart[i].Quantity = Convert.ToInt32(quantities[i]);
        //    }
        //    Session[strCart] = lstCart;
        //    return View("Index");
        //}




        //public ActionResult Index()
        //{
        //    return View("IndexDeneme");
        //}
        //[Route("Cart/Deneme/{id}")]
        //public ActionResult Deneme(int? id, string mail)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        //    }
        //    if (Session[cartses] == null)
        //    {
        //        List<Item> cart = new List<Item>();
        //        cart.Add(new Item()
        //        {
        //            Product = db.Products.Find(id),
        //            Quantity = 1
        //        });
        //        Session[cartses] = cart;
        //    }
        //    else
        //    {
        //        List<Item> cart = (List<Item>)Session[cartses];
        //        int check = IsExistingCheck(id);
        //        if (check == -1)
        //        {
        //            cart.Add(new Item()
        //            {
        //                Product = db.Products.Find(id),
        //                Quantity = 1
        //            });
        //        }
        //        else
        //            cart[check].Quantity++;
        //        Session[cartses] = cart;
        //    }
        //    return View("IndexDeneme");
        //}
        //private int IsExistingCheck(int? id)
        //{
        //    List<Item> cart = (List<Item>)Session[cartses];
        //    for (int i = 0; i < cart.Count; i++)
        //    {
        //        if (cart[i].Product.ProductId == id) return i;
        //    }
        //    return -1;
        //}
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        //    }
        //    int check = IsExistingCheck(id);
        //    List<Item> cart = (List<Item>)Session[cartses];
        //    cart.RemoveAt(check);
        //    return View("IndexDeneme");
        //}
        //public ActionResult UpdateCart(FormCollection frc)
        //{
        //    string[] quantities = frc.GetValues("quantity");
        //    List<Item> cart = (List<Item>)Session[cartses];
        //    for (int i = 0; i < cart.Count; i++)
        //    {
        //        cart[i].Quantity = Convert.ToInt32(quantities[i]);
        //    }
        //    Session[cartses] = cart;
        //    return View("Index");
        //}

        //ET: Cart
        //[HttpPost]
        //[Route("Sepetimm")]
        //public JsonResult AddProduct(int id, string mail, int quantity)
        //{
        //    mail = (string)Session["LoginUserMail"];
        //    var userIdInfo = db.Users.Where(x => x.Mail == mail).Select(y => y.UserId).FirstOrDefault();
        //    db.Cart.Add(new Cart
        //    {
        //        CreateDate = DateTime.Now,
        //        ProductId = id,
        //        UserId = userIdInfo,
        //        Quantity = quantity
        //    });
        //    var model = db.SaveChanges();

        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}

        ////public ActionResult Index(string mail)
        ////{

        ////    mail = (string)Session["LoginUserMail"];
        ////    if (mail == null)
        ////    {
        ////        return RedirectToAction("Logout", "Security");
        ////    }
        ////    var loginuserID = db.Users.Where(x => x.Mail == mail).Select(y => y.UserId).FirstOrDefault();
        ////    var data = db.Cart.Include("Product").Where(x => x.UserId == loginuserID).ToList();

        ////    return View(data);
        ////}

        //public ActionResult Delete(int id)
        //{
        //    var silinecek = db.Cart.Find(id);
        //    db.Entry(silinecek).State = EntityState.Deleted;
        //    db.SaveChanges();
        //    return Redirect("/Sepetim");
        //}
    }
}
