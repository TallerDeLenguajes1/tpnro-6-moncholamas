using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entidades
{
    public class Pedido
    {
        protected Cliente clienteActual;
        protected Cadete cadeteActual;
        public int Nro { get; set; }
        public int IdCli { get; set; }

        public int IdCadete { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
        public string TipoPedido { get; set; }
        public double Costo { get; set; }
        
    }
    public class Express: Pedido
    {
        
        public bool agregarCadete(Cadete c)
        {
            cadeteActual = c;
            return true;
        }
    }
}
