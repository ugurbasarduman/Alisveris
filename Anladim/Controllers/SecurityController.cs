using Anladim.Data;
using Anladim.Models.EntityFramework;
using Anladim.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Anladim.Controllers
{
    public class SecurityController : Controller
    {
        Context db = new Context();
     
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //[Route("GirisYap")]
        [HttpPost]
        public ActionResult Login(User user)
        {
            var userdb = db.Users.FirstOrDefault(x => x.Mail == user.Mail && x.Password == user.Password);

            if (userdb != null)
            {
                FormsAuthentication.SetAuthCookie(userdb.Mail, false);
                Session["LoginUserMail"] = userdb.Mail;
                return Redirect("/");
            }
            else
            {
                ViewBag.Mesaj = "Gecersiz Kullanici adi ve sifre";
                return View();
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return Redirect("/");
        }
    }
}