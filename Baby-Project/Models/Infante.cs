using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Baby_Project.Models
{
    public class Infante
    {
        [Display(Name = "ID del Infante")]
        public int Infante_ID { get; set; }

        [Required(ErrorMessage = "Número del Historial Clinico del Bebe")]
        public string Infante_Historial { get; set; }

        [Required(ErrorMessage = "Nombre obligatorio.")] //Muestra alerta si este esta vacio.
        public string Infante_Nombre { get; set; }

        [Required(ErrorMessage = "Apellidos obligatorio.")]
        public string Infante_Apellido { get; set; }

        [Required(ErrorMessage = "Fecha de Nacimiento obligatorio.")]
        public DateTime Infante_FecNac { get; set; }

        [Required(ErrorMessage = "Sexo obligatorio")]
        public string Infante_Sexo { get; set; }

        [Required(ErrorMessage = "Lugar de Nacimiento obligatorio")]
        public string Infante_Lugar { get; set; }

        public int Infante_Exa_Gen { get; set; }

        public int Infante_Exa_Fis { get; set; }
    }
}