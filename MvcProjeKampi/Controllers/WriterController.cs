using BusinessLayer.Concrete;
using BusinessLayer.ValidationFolder;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: WriterDal
        public ActionResult Index()
        {
            var writerValues = wm.GetList();
            return View(writerValues);
        }
        public ActionResult AddWriter() 
        {
            return View();
        
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer) 
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid)
            {
                wm.WriterAdd(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);

                }
            }
            return View();
        
        }
        public ActionResult EditWriter(int id)
        {
            var writerValue=wm.GetByID(id);
            return View(writerValue);
        }
        public ActionResult EditWriter(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();

            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return RedirectToAction("Index");
        }
    }
}