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
    public class InfanteController : Controller
    {
        public ActionResult GetInfantes() 
        {
            InfanteRepository InfanRepo = new InfanteRepository(); 

            ModelState.Clear();

            return View(InfanRepo.ListarInfantes());
        }

        public ActionResult AddInfante() 
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult AddInfante(Infante inf)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InfanteRepository InfanRepo = new InfanteRepository();
                    if (InfanRepo.AddInfante(inf))
                        ViewBag.Message = "Infante agregado"; 
                    else
                        ViewBag.Message = "Ocurrio un error"; 
                }
                return RedirectToAction("GetInfantes");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditInfante(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            InfanteRepository InfanRepo = new InfanteRepository();
            Infante result = InfanRepo.ListarInfantes()  
                    .Find(Inf => Inf.Infante_ID == id);
            
            if (result == null) 
                return HttpNotFound();

            return View(result); 
        }
      
        [HttpPost]
        public ActionResult EditInfante(Infante obj) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InfanteRepository InfanRepo = new InfanteRepository();
                    if (InfanRepo.UpdateInfante(obj))
                        ViewBag.Message = "Infante modificado";
                    else
                        ViewBag.Message = "Ocurrio un error";

                    return RedirectToAction("GetInfantes");
                }
                return View(obj);
            }
            catch
            {
                return RedirectToAction("GetInfantes"); 
            }
        }

        public ActionResult DeleteInfante(int? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                InfanteRepository InfanRepo = new InfanteRepository();
                if (InfanRepo.DeleteInfante(id))
                    ViewBag.AlertMsg = "Infante eliminado";
                else
                    ViewBag.AlertMsg = "No se puedo eliminar";

                return RedirectToAction("GetInfantes");
            }
            catch
            {
                return RedirectToAction("GetInfantes");
            }
        }

        //Metodo para el Index general
        public ActionResult Index()
        {
            return View();
        }
    }
}