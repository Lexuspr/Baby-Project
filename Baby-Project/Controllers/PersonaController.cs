using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Baby_Project.Repository;
using Baby_Project.Models;

namespace Baby_Project.Controllers
{
    public class PersonaController : Controller
    {
        // Listar: Persona
        public ActionResult GetPersonas()
        {
            PersonaRepository PerRepo = new PersonaRepository();

            ModelState.Clear();

            return View(PerRepo.ListarPersonas());
        }

        //GET: Persona/AddPersona
        public ActionResult AddPersona()
        {
            return View();
        }

        //POST: Persona/AddPersona
        [HttpPost]
        public ActionResult AddPersona(Persona per)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PersonaRepository PerRepo = new PersonaRepository();
                    if (PerRepo.AddPersona(per))
                    {
                        ViewBag.Message = "Persona agregada";
                    }
                }
                return View();
            } catch
            {
                return View();
            }
        }

        // GET: Persona/EditPersona/5
        public ActionResult EditPersona(int id)
        {
            PersonaRepository PerRepo = new PersonaRepository();
            return View(PerRepo.ListarPersonas()
                    .Find(Per => Per.Persona_Id == id));
        }

        // POST: Persona/EditPersona/5
        [HttpPost]
        public ActionResult EditPersona(int id, Persona obj)
        {
            try
            {
                PersonaRepository PerRepo = new PersonaRepository();
                PerRepo.UpdatePersona(obj);
                return RedirectToAction("GetPersonas");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/DeletePersona/5
        public ActionResult DeletePersona(int id)
        {
            try
            {
                PersonaRepository PerRepo = new PersonaRepository();
                if (PerRepo.DeletePersona(id))
                {
                    ViewBag.AlertMsg = "Empleado eliminado";
                }
                return RedirectToAction("GetPersonas");
            } catch
            {
                return View();
            }
        }
        
    }
}
