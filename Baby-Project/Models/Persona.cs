using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Baby_Project.Models
{
    public class Persona // Primer paso es crear el modelo siguiendo el ejemplo de Persona y TipoPersona
    {
        [Display(Name = "ID")] // Esto siempre va en el ID del modelo identico ctrl c ctrl v
        public int Persona_Id { get; set; } // En todos los id el tipo de variable es int asi que solo hay que cambiar el nombre dependiendo del modelo
        
        [Required(ErrorMessage = "Nombre obligatorio.")] //Esto es para mostrar una alerta cuando falta llenar un atributo del modelo. En este caso el Nombre
        public string Persona_Nombre { get; set; } // Desde aqui atentos al tipo de variable. Tiene que ser la misma que en la base de datos. Varchar = string, int = int, date/datetime = date

        [Required(ErrorMessage = "Apellidos obligatorio.")]
        public string Persona_Apellido { get; set; } // En caso salga un error relacionado al tipo de variable hay que googlear cual es la equivalencia del tipo variable de la bd en c#.

        [Required(ErrorMessage = "Email obligatorio.")]
        public string Persona_Email { get; set; } 

        [Required(ErrorMessage = "Fecha de Nacimiento obligatorio.")]
        public string Persona_FecNac { get; set; }

        [Required(ErrorMessage = "Sexo obligatorio")]
        public string Persona_Sexo { get; set; }

        [Required(ErrorMessage = "Celular obligatorio")]
        public string Persona_Celular { get; set; }

        [Required(ErrorMessage = "Username obligatorio.")]
        public string Persona_Username { get; set; }

        [Required(ErrorMessage = "Password obligatorio.")]
        public string Persona_Password { get; set; }

        public int Persona_Tipo_ID { get; set; } //En este caso si te diste cuenta no coloque el ErrorMessage. Esto es para los atributos que no son obligatorios llenar.
    }
}