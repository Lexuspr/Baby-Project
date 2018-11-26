using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Baby_Project.Models
{
    public class Salida
    {
        [Display(Name = "ID")]
        public int Salida_ID { get; set; }

        [Required(ErrorMessage = "Observacion obligatoria.")]
        public string Salida_Obs { get; set; }

        [Required(ErrorMessage = "Destino obligatorio.")]
        public string Salida_Destino { get; set; }

        [Required(ErrorMessage = "Número obligatorio.")]
        public string Salida_NumCnv { get; set; }

        [Required(ErrorMessage = "Fecha de Atención obligatoria.")]
        public DateTime Salida_Fec { get; set; }

        public int Asistente_ID { get; set; }
    }
}