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
    public class ProductController : Controller
    {
        Context db = new Context();
        public ActionResult Details(int id)
        {
            var model = db.Products.Find(id);
            return View("Details",model);
        }
    }
}