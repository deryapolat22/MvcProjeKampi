using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        //TODO: controller seviyesinde yaptığın bu işlemi mimari seviyesine taşı!
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Context c=new Context();
            var adminUserInfo = c.Admins.FirstOrDefault(
                x => x.AdminUserName == admin.AdminUserName &&
                x.AdminPassword == admin.AdminPassword);
            if(adminUserInfo != null)
            {
                //TODO: Giriş Yapan Kullanıcın Verisini Tutma
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"]=adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index");

            }
                
            return View();
        }
        public ActionResult LogOut()
        {
            return View();
        }
    }
}