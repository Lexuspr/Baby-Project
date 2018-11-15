using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Baby_Project.Models
{
    public class Persona
    {
        [Display(Name = "Id")]
        public int Persona_Id { get; set; }
        
        [Required(ErrorMessage = "Nombre obligatorio.")]
        public string Persona_Nombre { get; set; }

        [Required(ErrorMessage = "Apellidos obligatorio.")]
        public string Persona_Apellido { get; set; }

        [Required(ErrorMessage = "Email obligatorio.")]
        public string Persona_Email { get; set; }

        [Required(ErrorMessage = "Fecha de Nacimiento obligatorio.")]
        public string Persona_FecNac { get; set; }

        [Required(ErrorMessage = "Sexo obligatorio")]
        public char Persona_Sexo { get; set; }

        public string Persona_Celular { get; set; }

        [Required(ErrorMessage = "Username obligatorio.")]
        public string Persona_Username { get; set; }

        [Required(ErrorMessage = "Password obligatorio.")]
        public string Persona_Password { get; set; }

        public int Persona_Tipo_ID { get; set; }
    }
}