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
    [Authorize(Roles ="U,A")]
    public class ProfilController : Controller
    {
        Context db = new Context();

        [Route("Profil")]
        public ActionResult Index(string mail)
        {
            mail = (string)Session["LoginUserMail"];
            if (mail == null)
            {
                return RedirectToAction("Logout", "Security");
            }
            var loginUserId = db.Users.Where(x => x.Mail == mail).Select(x => x.UserId).FirstOrDefault();
            //ViewBag.adres = db.UserAddresses.Where(x => x.UserId == loginUserId).ToList();
            var model = db.Users.Where(x => x.UserId == loginUserId).FirstOrDefault();
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = db.Users.Find(id);
            return View("ProfilForm", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("ProfilForm");
            }
            else
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Redirect("/Profil");
        }

        public ActionResult AddressList(string mail)
        {
            mail = (string)Session["loginUserMail"];
            var loginUserId = db.Users.Where(x => x.Mail == mail).Select(x => x.UserId).FirstOrDefault();

            var model = db.UserAddresses.Where(x => x.UserId == loginUserId);
            return View(model);
        }


        [HttpGet]
        public ActionResult NewUserAddressProfiles()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewUserAddressProfiles(UserAddress userAddress, string mail)
        {
            mail = (string)Session["LoginUserMail"];
            var loginUserId = db.Users.Where(x => x.Mail == mail).Select(y => y.UserId).FirstOrDefault();
            userAddress.UserId = loginUserId;

            db.UserAddresses.Add(userAddress);
            db.SaveChanges();
            return RedirectToAction("AddressList", "Profil");
        }


        public ActionResult AddressEdit(int id)
        {
            var model = db.UserAddresses.Find(id);
            return View("NewUserAddressProfil",model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveAddress(UserAddress userAddress)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("NewUserAddressProfil");
            }
            else
                db.Entry(userAddress).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddressList","Profil");
        }

        public ActionResult AddressDelete(int id)
        {
            var model = db.UserAddresses.Find(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            db.UserAddresses.Remove(model);
            db.SaveChanges();
            return RedirectToAction("AddressList","Profil");
        }
    }
}