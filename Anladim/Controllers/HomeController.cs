using Anladim.Data;
using Anladim.Models.EntityFramework;
using Anladim.ViewModels;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anladim.Controllers
{
    public class HomeController : Controller
    {
        Context db = new Context();

        //public ActionResult Index(string searching, int? sayfano, string sortOrder)

        public ActionResult Index(string sortOrder, string currentFilter, string searching, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DescSortParm = String.IsNullOrEmpty(sortOrder) ? "desc" : "";
            ViewBag.AscSortParm = String.IsNullOrEmpty(sortOrder) ? "asc" : "";
            var model = db.Products.Include(x => x.Category).ToList();
            //int _sayfano = sayfano ?? 1;
            if (searching != null)
            {
                page = 1;
            }
            else
            {
                searching = currentFilter;
            }
            ViewBag.CurrentFilter = searching;
            var al = from x in model select x;
            if (!String.IsNullOrEmpty(searching))
            {
                al = al.Where(x => x.Name.ToLower().Contains(searching) || x.Name.ToUpper().Contains(searching) || x.Model.ToLower().Contains(searching) || 
                x.Model.ToUpper().Contains(searching) || x.Brand.ToLower().Contains(searching) || x.Brand.ToUpper().Contains(searching)||
                x.Category.CategoryName.ToLower().Contains(searching) || x.Category.CategoryName.ToUpper().Contains(searching) || x.Name.Contains(searching) || 
                x.Model.Contains(searching) || x.Brand.Contains(searching) || x.Category.CategoryName.Contains(searching));
            }           
            switch (sortOrder)
            {
                case "desc":
                   al = al.OrderByDescending(x => x.Price);
                    break;
                case "asc":
                    al = al.OrderBy(x => x.Price);
                    break;
                default:
                    al = al.OrderByDescending(x => x.ProductId);
                    break;
            }
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(al.ToPagedList(pageNumber, pageSize));
        }
        public PartialViewResult Menu()
        {
            var model = db.Categories.ToList();
            return PartialView(model);
        }

        //public ActionResult Index(string searching)
        //{
        //    var arama = from x in db.Products select x;
        //       if(!string.IsNullOrEmpty(searching))
        //        {
        //            arama = arama.Where(x => x.Name.Contains(searching));
        //        }
        //    var al = arama.ToList();
        //    return View(al);
        //}

        //[Route("Index")]
        //public ActionResult GetAll(string searching)
        //{
        //    var arama = from x in db.Products select x;
        //    if(!string.IsNullOrEmpty(searching))
        //    {
        //        arama = arama.Where(x => x.Name.Contains(searching));
        //    }
        //    return View(arama.ToList());
        //}

    }
}