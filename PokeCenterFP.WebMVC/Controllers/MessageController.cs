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
        public ActionResult CreateMessage()
        {
            MessageCreate model = new MessageCreate();
            return View(model);
        }
        [HttpPost]
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
                TempData["SaveResult"] = "Your note was created!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMessageService();
            var model = svc.GetMessageById(id);

            return View(model);
        }

        public ActionResult Delete(int id)
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

            TempData["SaveResult"] = "Your note was successfully deleted!";

            return RedirectToAction("MessageIndex");
        }

        private MessageService CreateMessageService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MessageService(userID);
            return service;
        }
    }
}