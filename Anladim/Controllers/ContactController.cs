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
    public class ContactController : Controller
    {
        Context db = new Context();
        [HttpGet]
        [Route("Contact")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("Contact")]
        public ActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Mesaj = "Mesajiniz Gonderildi...";
                return View();
            }
            else
            {
                ViewBag.Mesaj = "Gecersiz Deger Girdiniz...";
                return View();
            }            
        }
    }
}
