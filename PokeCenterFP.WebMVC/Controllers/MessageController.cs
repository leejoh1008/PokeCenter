using PokeCenter.Models;
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
            var model = new MessageListItem[0];
            return View(model);
        }
        public ActionResult CreateMessage()
        {
            return View();
        }
    }
}