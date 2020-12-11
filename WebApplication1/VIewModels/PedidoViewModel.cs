using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.VIewModels
{
    public class PedidoViewModel
    {
        public int Nro { get; set; }
        public string Observacion { get; set; }
        public int IdCli { get; set; }
        public int IdCadete { get; set; }
        public string Estado { get; set; }
        public string TipoPedido { get; set; }
        public double precio { get; set; }
    }
}
