using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Baby_Project.Models
{
    public class TipoPersona
    {
        [Display(Name = "ID")]
        public int TipoPersona_Id { get; set; }

        [Required(ErrorMessage = "Descripcion obligatoria.")]
        public string TipoPersona_Desc { get; set; }
    }
}