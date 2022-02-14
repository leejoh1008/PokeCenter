using PokeCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokeCenterFP.WebMVC.Controllers
{
    [Authorize]
    public class PCardController : Controller
    {
        // GET: PCard
        public ActionResult CardIndex()
        {
            var model = new PCardListItem[0];
            return View(model);
        }
        public ActionResult CreatePC()
        {
            return View();
        }
    }
}