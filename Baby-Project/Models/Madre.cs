using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Baby_Project.Models
{
    public class Madre
    {
        [Display(Name = "ID")]
        public int Madre_Id { get; set; } 

        [Required(ErrorMessage = "Nombre obligatorio.")] //Muestra alerta si este esta vacio.
        public string Madre_Nombre { get; set; } 

        [Required(ErrorMessage = "Apellidos obligatorio.")]
        public string Madre_Apellido { get; set; } 

        [Required(ErrorMessage = "Fecha de Nacimiento obligatorio.")]
        public DateTime Madre_FecNac { get; set; }

        [Required(ErrorMessage = "Tipo de Sangre obligatorio.")]
        public string Madre_Sangre { get; set; }

        [Required(ErrorMessage = "Factor obligatorio")]
        public string Madre_Factor { get; set; }

        [Required(ErrorMessage = "Enfermedad obligatorio")]
        public string Madre_Enfermedad { get; set; }

        public int Madre_Tipo_ID { get; set; }
    }
}
