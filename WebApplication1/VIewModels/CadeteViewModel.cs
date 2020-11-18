using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.VIewModels
{
    public class CadeteViewModel
    {
        public int IdCad { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public CadeteViewModel(int i,string n,string t,string d)
        {
            IdCad = i;
            Nombre = n;
            Telefono = t;
            Direccion = d;
        }
    }
}
