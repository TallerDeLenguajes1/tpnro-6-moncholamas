using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.VIewModels
{
    public class LoginViewModel
    {
        
        [MinLength(2)]
        [Required (ErrorMessage = "Campo Obligatorio")]
        public string Nombre { get; set; }
        [Required]
        [MinLength(2)]
        public string Clave { get; set; }
        public int Rol { get; set; }
    }
}
