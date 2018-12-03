using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Baby_Project.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Usuario obligatorio.")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password obligatorio.")]
        public string password { get; set; }

        public string ReturnURL { get; set; }

        public bool isRemember { get; set; }
    }
}