using PokeCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokeCenterFP.WebMVC.Controllers
{
    [Authorize]
    public class PGameController : Controller
    {
        // GET: PGame
        public ActionResult GameIndex()
        {
            var model = new PGameListItem[0];
            return View(model);
        }
        public ActionResult CreatePG()
        {
            return View();
        }
    }
}