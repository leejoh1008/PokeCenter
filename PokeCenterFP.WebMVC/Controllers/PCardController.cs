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
    public class PCardController : Controller
    {
        // GET: PCard
        public ActionResult CardIndex()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PCardService(userId);
            var model = service.GetPCards();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePokemonCard()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePokemonCard(PCardCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreatePCardService();
            if (service.CreatePCard(model))
            {
                TempData["SaveResult"] = " Your Pokemon Card has been listed!";
                return RedirectToAction("CardIndex");
            };
            ModelState.AddModelError("", "There was an error, please fix it!");
            return View(model);
        }
        private PCardService CreatePCardService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PCardService(userId);
            return service;
        }
    }
}