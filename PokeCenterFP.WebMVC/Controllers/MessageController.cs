using Microsoft.AspNet.Identity;
using PokeCenter.Models;
using PokeCenter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokeCenterFP.WebMVC.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult MessageIndex()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MessageService(userID);
            var model = service.GetMessages();

            return View(model);
        }
        public ActionResult Notifications()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MessageService(userID);
            var model = service.ReceiveMessages();

            return View(model);
        }

        public ActionResult CreateMessage()
        {
            MessageCreate model = new MessageCreate();
            return View(model);
        }
        [HttpPost]
        [ActionName("CreateMessage")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMessage(MessageCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateMessageService();

            if (service.CreateMessage(model))
            {
                TempData["SaveResult"] = "Your message was sent!";
                return RedirectToAction("Notifications");
            }

            ModelState.AddModelError("", "Your message couldn't be sent.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMessageService();
            var model = svc.GetMessageById(id);

            return View(model);
        }

        public ActionResult DeleteMessage(int id)
        {
            var svc = CreateMessageService();
            var model = svc.GetMessageById(id);

            return View(model);
        }

        // POST: Note/Delete/{id}
        [HttpPost]
        [ActionName("DeleteMessage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMessageService();

            service.DeleteMessage(id);

            TempData["SaveResult"] = "Your listing was successfully deleted!";

            return RedirectToAction("Notifications");
        }

        private MessageService CreateMessageService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MessageService(userID);
            return service;
        }
    }
}