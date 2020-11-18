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
        public string Obs { get; set; }
        public string Estado { get; set; }
        public double Costo { get; set; }
        public Pedido(string obs, string est, double cos) {
            Obs = obs;
            Estado = est;
            Costo = cos;
        }
    }
    public class Express: Pedido
    {
        public Express(string o, string e, double c)
        :base(o,e,c)
        { }
        public bool agregarCadete(Cadete c)
        {
            cadeteActual = c;
            return true;
        }
    }
}
