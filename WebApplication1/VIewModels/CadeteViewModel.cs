using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.VIewModels
{
    public class CadeteViewModel
    {
        public int IdCad { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Direccion { get; set; }
        public int IdVehiculo { get; set; }

        public List<PedidoViewModel> PedidosTransportados { get; set; }
    }
    public class AdminCadeteViewModel 
    {
        public string NombreUsuario { get; set; }
        
        public List<CadeteViewModel> ListaCadetes { get; set; }
    }
    public class AltaCadeteViewModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Clave { get; set; }

    }
}
