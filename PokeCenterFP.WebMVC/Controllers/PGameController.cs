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
            PGameCreate model = new PGameCreate();
            return View(model);
        }
        [Route("CreatePG")]
        [HttpPost]
        public ActionResult CreatePG(PGameCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            HttpPostedFileBase file = Request.Files["ImageData"];
            
           
            PGameService service = CreatePGameService();
            service.UploadImageInDataBase(file, model);
            if (service.UploadImageInDataBase(file, model) )
            {   
                TempData["SaveResult"] = "Your game was listed!";
               
                return RedirectToAction("GameIndex");
            }

            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
            
        }

        public ActionResult EditPG(int id)
        {
            var service = CreatePGameService();
            var detail = service.GetPGameById(id);
            var model =
                new PGameEdit
                {
                    PGameId = detail.PGameId,
                    GameName = detail.GameName,
                    GamePrice = detail.GamePrice,
                    GameImage = detail.GameImage,
                    HasCase = detail.HasCase,
                    Console = detail.Console
                };

            return View(model);
        }

        // POST: Note/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPG(int id, PGameEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PGameId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreatePGameService();

            if (service.UpdatePGame(model))
            {
                TempData["SaveResult"] = "Your game was updated successfully!";
                return RedirectToAction("GameIndex");
            }

            ModelState.AddModelError("", "Your game could not be updated.");
            return View(model);
        }
        private PGameService CreatePGameService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new PGameService(userID);
            return service;
        }
        public ActionResult DeletePG(int id)
        {
            var svc = CreatePGameService();
            var model = svc.GetPGameById(id);

            return View(model);
        }

        // POST: Note/Delete/{id}
        [HttpPost]
        [ActionName("DeletePG")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePostPG(int id)
        {
            var service = CreatePGameService();

            service.DeletePG(id);

            TempData["SaveResult"] = "Your Pokemon card listing was successfully deleted!";

            return RedirectToAction("CardIndex");
        }
    }
}