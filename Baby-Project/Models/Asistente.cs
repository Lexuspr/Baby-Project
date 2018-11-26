using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Baby_Project.Models
{
    public class Asistente
    {
        [Display(Name = "ID")]
        public int Asistente_ID { get; set; }

        [Required(ErrorMessage = "Nombre obligatorio.")]
        public string Asistente_Nombre { get; set; }
    }
}