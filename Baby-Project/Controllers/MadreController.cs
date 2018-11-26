using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Baby_Project.Repository;
using Baby_Project.Models;
using System.Net;

namespace Baby_Project.Controllers
{
    public class MadreController : Controller
    {
        public ActionResult GetMadres()
        {
            MadreRepository MadRepo = new MadreRepository();

            ModelState.Clear();

            return View(MadRepo.ListarMadres());
        }

        public ActionResult AddMadre()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMadre(Madre mad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MadreRepository MadRepo = new MadreRepository();
                    if (MadRepo.AddMadre(mad))
                        ViewBag.Message = "Madre agregado";
                    else
                        ViewBag.Message = "Ocurrio un error";
                }
                return RedirectToAction("GetMadres");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditMadre(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            MadreRepository MadRepo = new MadreRepository();
            Madre result = MadRepo.ListarMadres()
                    .Find(Mad => Mad.Madre_ID == id);

            if (result == null)
                return HttpNotFound();

            return View(result);
        }

        [HttpPost]
        public ActionResult EditMadre(Madre obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MadreRepository MadRepo = new MadreRepository();
                    if (MadRepo.UpdateMadre(obj))
                        ViewBag.Message = "Madre modificado";
                    else
                        ViewBag.Message = "Ocurrio un error";

                    return RedirectToAction("GetMadres");
                }
                return View(obj);
            }
            catch
            {
                return RedirectToAction("GetMadres");
            }
        }

        public ActionResult DeleteMadre(int? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                MadreRepository MadRepo = new MadreRepository();
                if (MadRepo.DeleteMadre(id))
                    ViewBag.AlertMsg = "Madre eliminado";
                else
                    ViewBag.AlertMsg = "No se puedo eliminar";

                return RedirectToAction("GetMadres");
            }
            catch
            {
                return RedirectToAction("GetMadres");
            }
        }

        //Metodo para el Index general
        public ActionResult Index()
        {
            return View();
        }
    }
}