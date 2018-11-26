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
    public class AsistenteController : Controller
    {
        public ActionResult GetAsistentes()
        {
            AsistenteRepository AsisRepo = new AsistenteRepository();

            ModelState.Clear();

            return View(AsisRepo.ListarAsistentes());
        }

        public ActionResult AddAsistente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAsistente(Asistente asis)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AsistenteRepository AsisRepo = new AsistenteRepository();
                    if (AsisRepo.AddAsistente(asis))
                        ViewBag.Message = "Asistente agregado";
                    else
                        ViewBag.Message = "Ocurrio un error";
                }
                return RedirectToAction("GetAsistentes");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditAsistente(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            AsistenteRepository AsisRepo = new AsistenteRepository();
            Asistente result = AsisRepo.ListarAsistentes()
                    .Find(Asis => Asis.Asistente_ID == id);

            if (result == null)
                return HttpNotFound();

            return View(result);
        }

        [HttpPost]
        public ActionResult EditAsistente(Asistente obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AsistenteRepository AsisRepo = new AsistenteRepository();
                    if (AsisRepo.UpdateAsistente(obj))
                        ViewBag.Message = "Asistente modificado";
                    else
                        ViewBag.Message = "Ocurrio un error";

                    return RedirectToAction("GetAsistentes");
                }
                return View(obj);
            }
            catch
            {
                return RedirectToAction("GetAsistentes");
            }
        }

        public ActionResult DeleteAsistente(int? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                AsistenteRepository AsisRepo = new AsistenteRepository();
                if (AsisRepo.DeleteAsistente(id))
                    ViewBag.AlertMsg = "Asistente eliminado";
                else
                    ViewBag.AlertMsg = "No se puedo eliminar";

                return RedirectToAction("GetAsistentes");
            }
            catch
            {
                return RedirectToAction("GetAsistentes");
            }
        }

        //Metodo para el Index general
        public ActionResult Index()
        {
            return View();
        }
    }
}