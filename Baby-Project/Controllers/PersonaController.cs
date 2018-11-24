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
    public class PersonaController : Controller // 3°    Ahora si. El tercer y penultimo paso. Crear el controlador respectivo.
    {
        //Te recomiendo que crees el controlador vacio y le des ctrl c y ctrl v a esto. Porque si usas una de las plantillas que te dan
        // demora más cambiar esos nombres predeterminados de los metodos que los ya tienes acá.
        // Listar: Persona
        public ActionResult GetPersonas() // Esto es la pagina de inicio del modelo respectivo. Este metodo va listar los elementos de la tabla.
        {
            PersonaRepository PerRepo = new PersonaRepository(); //llamamos al repositorio respectivo que creamos

            ModelState.Clear(); // esto le das ctrl c ctrl v

            return View(PerRepo.ListarPersonas()); //Aqui es lo que va devolver esta funcion. Con esto se construye la vista.
            // En este caso le decimos que construya la vista basandose en el resultado del metodo ListarPersonas() en el repositorio respectivo
            // Osea que cuando la vista aparezca la tabla de ahi se va llenar con los registros que existen.
        }

        //GET: Persona/AddPersona ------ Cuando es GET generalmente es para cargar la vista.
        public ActionResult AddPersona() // Esto va cargar la vista de Añadir registro
        {
            return View(); // Dentro del view no va nada porque queremos la vista sin datos. limpia para que el usuario la llene.
        }

        //POST: Persona/AddPersona ---- cuando es POST quiere decir que viene de algun boton de un formulario. En este caso vendrá cuando el boton Añadir se presione.
        [HttpPost]
        public ActionResult AddPersona(Persona per) //Esto se ejecuta cuando se decide grabar el registro
        {
            try
            {
                if (ModelState.IsValid) // esto es una comprobacion de que el modelo se ha cargado correctamente con todos sus campos llenos
                {
                    PersonaRepository PerRepo = new PersonaRepository();
                    if (PerRepo.AddPersona(per))
                        ViewBag.Message = "Persona agregada"; // Si la funcion dentro del if devuelve true quiere decir que si logramos añadir un registro
                    else
                        ViewBag.Message = "Ocurrio un error"; //Si no ps mala suerte
                }
                return RedirectToAction("GetPersonas"); // Haya añadido o no un registro lo que hacemos es que la vista vuelva al listado de Personas. Esto apunta al método de arrribbba
                // si te das cuenta tiene que tener el nombre exacto
            } catch
            {
                return View(); //Esto en caso el modelo sea invalido se recargara la vista para que lo intente otra vez. OJO: No va ir al listado simplemente se esta llamando a su GET
            }
        }

        // GET: Persona/EditPersona/5
        public ActionResult EditPersona(int? id) //Este para editar un regitro. Tenemos que recibir el id del registro que se va a editar.
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // Esto en caso no recibamos un id. Mandará un 500 Bad request

            PersonaRepository PerRepo = new PersonaRepository();
            Persona result = PerRepo.ListarPersonas() // Aqui guardamos el resultado de consultar a la bd usando el id que recibimos. 
                    .Find(Per => Per.Persona_Id == id); // Si todo va bien recibiremos un objeto de tipo del modelo respectivo. Revisa donde cambiar los nombres
            //      .Find(ejemplo => ejemplo.atributo_id == id        Ese "ejemplo" puede ser cualquier palabra pero un nombre que guarde relacion con el modelo actual pls
            if (result == null) //En caso no haya encontrado ningun registro con el id recibo pos se jode y le metemos un 404 Not Found >:v
                return HttpNotFound();

            return View(result); // Aqui es cuando usamos el registro recibido al consultar la bd.
            // para que?. Para llenar los campos del formulario con los datos del registro pss.
        }

        // POST: Persona/EditPersona/5 ----- Repitiendo. Esto se ejecuta generalmente cuando le das al boton Guardar en la vista de editar
        [HttpPost]
        public ActionResult EditPersona(Persona obj) // Guardamos el registro
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PersonaRepository PerRepo = new PersonaRepository();
                    if (PerRepo.UpdatePersona(obj)) // Atento a los nombres plss
                        ViewBag.Message = "Persona modificada";
                    else
                        ViewBag.Message = "Ocurrio un error";

                    return RedirectToAction("GetPersonas"); //Guardado o no el registro regresamos al listado
                }
                return View(obj); //EN caso sea el modelo invalido recargamos
            }
            catch
            {
                return RedirectToAction("GetPersonas"); // Al listadooooo
            }
        }

        // GET: Persona/DeletePersona/5  ----- Este metodo solo tiene un GET ya que usualmente no hay vista cuando se quiere eliminar un registro.
        // Por lo que no habrá un boton Guardar dentro de esa vista nueva al cual llamar para un POSt
        public ActionResult DeletePersona(int? id) // Aqui viene el ban. Esto viene del boton eliminar que supuestamente  deberia estar en la vista del LISTADO
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                PersonaRepository PerRepo = new PersonaRepository();
                if (PerRepo.DeletePersona(id))
                    ViewBag.AlertMsg = "Persona eliminado";
                else
                    ViewBag.AlertMsg = "No se puedo eliminar";

                return RedirectToAction("GetPersonas");
            } catch
            {
                return RedirectToAction("GetPersonas"); //Regresamos al listado. Aunque nunca nos fuimos asi que vendria a ser un refresh ;v
            }
        }

        //Metodo para el Index general
        public ActionResult Index()
        {
            return View();
        }

        //El metodo a continuacion son es para Personas. Es para loguearse XD
        //GET: Login
        public ActionResult Login()
        {
            return View();
        }

        //POST: Login
        [HttpPost]
        public ActionResult Login(Login obj)
        {
            try
            {
                PersonaRepository PerRepo = new PersonaRepository();
                if (PerRepo.Login(obj.username, obj.password))
                {
                    ViewBag.AlertMsg = "Exito";
                    return RedirectToAction("Index");
                }
                ViewBag.AlertMsg = "Usuario o contraseña incorrecto";
                return View();
            }
            catch
            {
                ViewBag.AlertMsg = "Ocurrio un error";
                return View();
            }
        }

        // Bien luego de hacer todos esos metodos viene los ultimos pasos que son crear la vista para cada modelo.
        // Habrá vista para litado de personas. GetPersonas. Vista para el añadir. Vista para el modificar. Pero no habra vista para el eliminar


        // Como se crean la vista o donde se crea?
        // Pos le das clic derecho al nombre de los métodos GET (excepto el de eliminar) 
        // Ahi Agregar vista...
        // Primero te aparece para que pongas el nombre de la vista. Por defecto
        // Luego el template viene a ser la plantilla. Aqui para probar si hiciste bien todo tenemos que construir un formulario básico. Por lo que dependiendo del método escoges.
        // SI es un listado entonces seria List, si es un añadir, el template seria un Create y asi para los demas
        // Luego de elegir el template te va pedir un Model Class. Izi escoges el modelo que estas trabajando. Persona, TipoPersona; etc...
        // Lo demás lo dejas por defecto y listo


        //Para terminar. La base de datos esta hecha de manera que no es necesario escribir el id de un registro cuando se desea ingresar uno nuevo.
        // por lo que en las vistas de añadir o add, buscas todo lo que vendría a ser el id de la tabla. Te vas a dar cuenta que cada atributo se encuentra empaquetado en etiquetas que se repiten para cada uno.
        // Eliminas todo el paquete y dejas los demas atributos.
        // Al final de cada vista  hay un input que te permite regresar al listado. Por defecto esta en index pero tu debes cambiar ese Index por el nombre del método listar respectivo
        // Para personas, en vez de Index seria GetPersonas.

        // Para probar el modelo y controlador y repositorio que hiciste primero selecciona el archivo de la vista principal. En este caso de Personas seria GetPersonas.cshtml y luego RUN.
    }
}
