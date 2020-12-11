using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.VIewModels
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(2)]
        public string nombre { get; set; }
        [Required]
        [MinLength(2)]
        public string clave { get; set; }
        public int Rol { get; set; }
    }
}
