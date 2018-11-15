using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Baby_Project.Repository;

namespace Baby_Project.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult GetAllPersonaDetails()
        {
            PersonaRepository PerRepo = new PersonaRepository();

            ModelState.Clear();

            return View(PerRepo.GetAllPersonas());
        }

        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        
    }
}
