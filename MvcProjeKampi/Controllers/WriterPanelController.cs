﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        // GET: WriterLayout
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading()
        {
            var values = hm.GetListByWriter();
            return View();
        }
    }
}