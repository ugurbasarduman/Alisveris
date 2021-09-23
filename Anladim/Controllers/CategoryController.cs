﻿using Anladim.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.Web.Mvc;
using Anladim.Models.EntityFramework;

namespace Anladim.Controllers
{
    public class CategoryController : Controller
    {
        Context db = new Context();

        //[Route("Kategori/{isim}/{id}")]
        //public ActionResult Index(int id, string searching, int? sayfano)
        //{
        //    var model = db.Products.Where(x => x.CategoryId == id).ToList();
        //    int _sayfano = sayfano ?? 1;
        //    var arama = from x in model select x;
        //    if (!string.IsNullOrEmpty(searching))
        //    {
        //        arama = arama.Where(x => x.Name.Contains(searching));
        //    }
        //    var al = arama.OrderByDescending(x => x.ProductId).ToPagedList(_sayfano, 12); ;
        //    ViewBag.Cat = db.Categories.FirstOrDefault(x => x.CategoryId == id);
        //    return View(al);
        //}
        [Route("Kategori/{isim}/{id}")]
        public ActionResult Index(string sortOrder, string currentFilter, string searching, int? page, int id)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DescSortParm = String.IsNullOrEmpty(sortOrder) ? "desc" : "";
            ViewBag.AscSortParm = String.IsNullOrEmpty(sortOrder) ? "asc" : "";
            var model = db.Products.Where(x => x.CategoryId==id).ToList();
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
                al = al.Where(x => x.Name.Contains(searching) || x.Model.Contains(searching) || x.Brand.Contains(searching));
            }
            ViewBag.Cat = db.Categories.FirstOrDefault(x => x.CategoryId == id);
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
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(al.ToPagedList(pageNumber, pageSize));
            //return View(al.ToPagedList<Product>(_sayfano, 12));
        }
    }
}