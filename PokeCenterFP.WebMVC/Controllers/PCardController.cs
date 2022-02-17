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
        // GET: PGame
        public ActionResult CardIndex()
        {
            var model = new PCardListItem[0];
            return View(model);
        }
        public ActionResult CreatePC()
        {
            PCardCreate model = new PCardCreate();
            return View(model);
        }
        [Route("CreatePC")]
        [HttpPost]
        public ActionResult CreatePC(PCardCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            HttpPostedFileBase file = Request.Files["ImageData"];


            PCardService service = CreatePCardService();
            service.UploadImageInDataBase(file, model);
            if (service.UploadImageInDataBase(file, model))
            {
                TempData["SaveResult"] = "Your card was listed!";

                return RedirectToAction("CardIndex");
            }

            ModelState.AddModelError("", "Card could not be created.");
            return View(model);

        }

        public ActionResult EditPC(int id)
        {
            var service = CreatePCardService();
            var detail = service.GetPCardById(id);
            var model =
                new PCardEdit
                {
                    PCardId = detail.PCardId,
                    CardName = detail.CardName,
                    CardPrice = detail.CardPrice,
                    CardGrade = detail.CardGrade,
                    CardImage = detail.CardImage,
                    IsHolo = detail.IsHolo
                };

            return View(model);
        }

        // POST: Note/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPC(int id, PCardEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PCardId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreatePCardService();

            if (service.UpdatePCard(model))
            {
                TempData["SaveResult"] = "Your game was updated successfully!";
                return RedirectToAction("CardIndex");
            }

            ModelState.AddModelError("", "Your game could not be updated.");
            return View(model);
        }
        private PCardService CreatePCardService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new PCardService(userID);
            return service;
        }
        public ActionResult DeletePC(int id)
        {
            var svc = CreatePCardService();
            var model = svc.GetPCardById(id);

            return View(model);
        }

        // POST: Note/Delete/{id}
        [HttpPost]
        [ActionName("DeletePC")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePostPC(int id)
        {
            var service = CreatePCardService();

            service.DeletePC(id);

            TempData["SaveResult"] = "Your Pokemon card listing was successfully deleted!";

            return RedirectToAction("CardIndex");
        }
    }
}