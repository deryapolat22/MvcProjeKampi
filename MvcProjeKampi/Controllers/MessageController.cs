using BusinessLayer.Concrete;
using BusinessLayer.ValidationFolder;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator mv= new MessageValidator();
        // GET: Message
        public ActionResult Inbox()

        {
            var messageList = mm.GetListInBox();
            return View(messageList);
        }
        public ActionResult Sendbox()

        {
            var messageList = mm.GetListSendBox();
            return View(messageList);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var messageValues = mm.GetByID(id);
            return View(messageValues);
        }
        public ActionResult GetsendboxMessageDetails(int id)
        {
            var messageValues = mm.GetByID(id);
            return View(messageValues);
        }
        public ActionResult NewMessage()
        {
            return View();        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult result = mv.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }


            return View(message);
        }
    }
}