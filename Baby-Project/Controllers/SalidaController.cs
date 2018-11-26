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
    public class SalidaController : Controller
    {
        public ActionResult GetSalidas()
        {
            SalidaRepository SalRepo = new SalidaRepository();

            ModelState.Clear();

            return View(SalRepo.ListarSalidas());
        }

        public ActionResult AddSalida()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSalida(Salida sal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SalidaRepository SalRepo = new SalidaRepository();
                    if (SalRepo.AddSalida(sal))
                        ViewBag.Message = "Salida agregada";
                    else
                        ViewBag.Message = "Ocurrio un error";
                }
                return RedirectToAction("GetSalidas");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditSalida(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            SalidaRepository SalRepo = new SalidaRepository();
            Salida result = SalRepo.ListarSalidas()
                    .Find(Sal => Sal.Salida_ID == id);

            if (result == null)
                return HttpNotFound();

            return View(result);
        }

        [HttpPost]
        public ActionResult EditSalida(Salida obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SalidaRepository SalRepo = new SalidaRepository();
                    if (SalRepo.UpdateSalida(obj))
                        ViewBag.Message = "Salida modificada";
                    else
                        ViewBag.Message = "Ocurrio un error";

                    return RedirectToAction("GetSalidas");
                }
                return View(obj);
            }
            catch
            {
                return RedirectToAction("GetSalidas");
            }
        }

        public ActionResult DeleteSalida(int? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                SalidaRepository SalRepo = new SalidaRepository();
                if (SalRepo.DeleteSalida(id))
                    ViewBag.AlertMsg = "Salida eliminada";
                else
                    ViewBag.AlertMsg = "No se puedo eliminar";

                return RedirectToAction("GetSalidas");
            }
            catch
            {
                return RedirectToAction("GetSalidas");
            }
        }

        //Metodo para el Index general
        public ActionResult Index()
        {
            return View();
        }
    }
}