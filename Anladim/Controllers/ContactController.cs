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

//try
 //{
 //    if (ModelState.IsValid)
 //    {
 //        var senderEmail = new MailAddress(user.Mail);
 //        var receiverEmail = new MailAddress("ugurbasarduman@gmail.com", "Receiver");
 //        var password = "Your Email Password here";
 //        var sub = subject;
 //        var body = message;
 //        var smtp = new SmtpClient
 //        {
 //            Host = "smtp.gmail.com",
 //            Port = 587,
 //            EnableSsl = true,
 //            DeliveryMethod = SmtpDeliveryMethod.Network,
 //            UseDefaultCredentials = false,
 //            Credentials = new NetworkCredential(senderEmail.Address, password)
 //        };
 //        using (var mess = new MailMessage(senderEmail, receiverEmail)
 //        {
 //            Subject = subject,
 //            Body = body
 //        })
 //        {
 //            smtp.Send(mess);
 //        }
 //        return View();
 //    }
 //}
 //catch (Exception)
 //{
 //    ViewBag.Error = "Some Error";
 //}