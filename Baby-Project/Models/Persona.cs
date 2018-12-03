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

        [Display(Name = "Nombre")]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\-][a-zA-Z])?[a-zA-Z]*)*$", ErrorMessage ="Este campo parece tener mal formato.")]
        [StringLength(128, MinimumLength = 4)]
        [Required(ErrorMessage = "Nombre obligatorio.")] //Esto es para mostrar una alerta cuando falta llenar un atributo del modelo. En este caso el Nombre
        public string Persona_Nombre { get; set; } // Desde aqui atentos al tipo de variable. Tiene que ser la misma que en la base de datos. Varchar = string, int = int, date/datetime = date

        [Display(Name = "Apellido")]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\-][a-zA-Z])?[a-zA-Z]*)*$", ErrorMessage = "Este campo parece tener mal formato.")]
        [StringLength(128, MinimumLength = 4)]
        [Required(ErrorMessage = "Apellidos obligatorio.")]
        public string Persona_Apellido { get; set; } // En caso salga un error relacionado al tipo de variable hay que googlear cual es la equivalencia del tipo variable de la bd en c#.

        [Display(Name = "Email")]
        [StringLength(128, MinimumLength = 4)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email obligatorio.")]
        public string Persona_Email { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Fecha de Nacimiento obligatorio.")]
        public string Persona_FecNac { get; set; }

        [Display(Name = "Sexo")]
        [StringLength(1, MinimumLength = 1)]
        [Required(ErrorMessage = "Sexo obligatorio")]
        public string Persona_Sexo { get; set; }

        [Display(Name = "Celular")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(12, MinimumLength = 9)]
        [Required(ErrorMessage = "Celular obligatorio")]
        public string Persona_Celular { get; set; }

        [Display(Name = "Username")]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\-][a-zA-Z])?[a-zA-Z]*)*$", ErrorMessage = "Este campo parece tener mal formato.")]
        [StringLength(128, MinimumLength = 4)]
        [Required(ErrorMessage = "Username obligatorio.")]
        public string Persona_Username { get; set; }

        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{10,128}$", ErrorMessage = "Este campo parece tener mal formato.")]
        [StringLength(128, MinimumLength = 10)]
        [Required(ErrorMessage = "Password obligatorio.")]
        public string Persona_Password { get; set; }

        [Display(Name = "Tipo de Usuario")]
        [Required(ErrorMessage = "Tipo de usuario obligatorio.")]
        public int Persona_Tipo_ID { get; set; } //En este caso si te diste cuenta no coloque el ErrorMessage. Esto es para los atributos que no son obligatorios llenar.

    }
}