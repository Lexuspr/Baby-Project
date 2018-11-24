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
    public class TipoPersonaController : Controller // 3°    Ahora si. El tercer y penultimo paso. Crear el controlador respectivo.
    {
        //Te recomiendo que crees el controlador vacio y le des ctrl c y ctrl v a esto. Porque si usas una de las plantillas que te dan
        // demora más cambiar esos nombres predeterminados de los metodos que los ya tienes acá.
        // Listar: TipoPersona
        public ActionResult GetTipoPersonas() // Esto es la pagina de inicio del modelo respectivo. Este metodo va listar los elementos de la tabla.
        {
            TipoPersonaRepository TipoPerRepo = new TipoPersonaRepository();

            ModelState.Clear();

            return View(TipoPerRepo.ListarTipoPersonas());
        }

        //GET: TipoPersona/AddTipoPersona
        public ActionResult AddTipoPersona()
        {
            return View();
        }

        //POST: Persona/AddTipoPersona
        [HttpPost]
        public ActionResult AddTipoPersona(TipoPersona tper)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TipoPersonaRepository TipoPerRepo = new TipoPersonaRepository();
                    if (TipoPerRepo.AddTipoPersona(tper))
                        ViewBag.Message = "TipoPersona agregada";
                    else
                        ViewBag.Message = "Ocurrio un error";
                }
                return RedirectToAction("GetTipoPersonas");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/EditTipoPersona/5
        public ActionResult EditTipoPersona(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            TipoPersonaRepository TipoPerRepo = new TipoPersonaRepository();
            TipoPersona result = TipoPerRepo.ListarTipoPersonas()
                    .Find(TPer => TPer.TipoPersona_Id == id);

            if (result == null)
                return HttpNotFound();
      
            return View(result);
        }

        // POST: TipoPersona/EditTipoPersona/5
        [HttpPost]
        public ActionResult EditTipoPersona(TipoPersona obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TipoPersonaRepository TipoPerRepo = new TipoPersonaRepository();
                    if (TipoPerRepo.UpdateTipoPersona(obj))
                        ViewBag.Message = "TipoPersona modificada";
                    else
                        ViewBag.Message = "Ocurrio un error";

                    return RedirectToAction("GetTipoPersonas");
                }
                return View(obj);
            }
            catch
            {
                return RedirectToAction("GetTipoPersonas");
            }
        }

        // GET: TipoPersona/DeleteTipoPersona/5
        public ActionResult DeleteTipoPersona(int? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                TipoPersonaRepository TipoPerRepo = new TipoPersonaRepository();
                if (TipoPerRepo.DeleteTipoPersona(id))
                    ViewBag.AlertMsg = "Empleado eliminado";
                else
                    ViewBag.AlertMsg = "No se pudo eliminar";
                return RedirectToAction("GetTipoPersonas");
            }
            catch
            {
                return RedirectToAction("GetTipoPersonas");
            }
        }
    }
}
