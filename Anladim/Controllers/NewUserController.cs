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

namespace Anladim.Controllers
{
    public class NewUserController : Controller
    {
        Context db = new Context();

        [HttpGet]
        [Route("KayitOl")]
        public ActionResult AddUser()
        {
            return View();
        }
        [Route("KayitOl")]
        public ActionResult AddUser(User user)
        {
            
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "Security");
            }
            else {
                return View();
            }
        }
    }
}