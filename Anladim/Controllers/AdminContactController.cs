using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Anladim.Data;
using Anladim.Models.EntityFramework;
using Anladim.ViewModels;

namespace Anladim.Controllers
{
    [Authorize(Roles = "A")]
    public class AdminContactController : Controller
    {
        private Context db = new Context();

        // GET: AdminContact
        public ActionResult Index(string mail, string searching)
        {
            mail = (string)Session["LoginUserMail"];
            if (mail == null)
            {
                return RedirectToAction("Logout", "Security");
            }
            var model = db.Contacts.OrderByDescending(x => x.ContactId).ToList();
            var arama = from x in model select x;
            if (!string.IsNullOrEmpty(searching))
            {
                arama = arama.Where(x => x.Mail.Contains(searching));
            }
            var al = arama.ToList();
            return View(al);
        }

        // GET: AdminContact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
        // GET: AdminContact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: AdminContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("AdminContact/Answer/{id}")]
        public ActionResult Answer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
        [HttpPost]
        public ActionResult Send(Contact contact, FormCollection form)
        {
            string body = form["icerik"];
            WebMail.Send(contact.Mail, contact.Subject, body, null, null, null, true, null, null, null, null, null, null);
            ViewBag.msg = "E-mail başarı ile gönderildi.";
            db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return View("Answer");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
