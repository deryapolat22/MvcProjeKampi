using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var categoryValues = cm.GetList();
            var writerValues = wm.GetList();
            var headingValues = hm.GetList();
            ViewBag.GorevIlk = categoryValues.Count;
            ViewBag.GorevIkinci = categoryValues.Where(a=>a.CategoryName=="Yazılım").Count();
            ViewBag.GorevUcüncü = writerValues.Count(a => a.WriterName.Contains("a"));
            var enFazlaCategory = headingValues
                .GroupBy(a => a.CategoryID) 
                .OrderByDescending(g => g.Count()) 
                .Select(g => g.Key) 
                .FirstOrDefault();
            ViewBag.GorevDorduncu = categoryValues.FirstOrDefault(c => c.CategoryID == enFazlaCategory)?.CategoryName;

            var trueCategory = categoryValues.Where(a => a.CategoryStatus ==true).Count();
            var falseCategory = categoryValues.Where(a => a.CategoryStatus ==false).Count();
            ViewBag.GorevBesinci = trueCategory - falseCategory;
            return View();
        }
    }
}