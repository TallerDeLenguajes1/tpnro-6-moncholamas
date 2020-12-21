using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entidades
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string Matricula { get; set; }
        public string Tipo { get; set; }

        public double plus(double precioBase)
        {
            switch (Tipo)
            {
                case "Auto":
                    return precioBase * 1.25;
                case "Moto":
                    return precioBase * 1.20;
                case "Bicicleta":
                    return precioBase * 1.05;
                default:
                    return precioBase;
                    break;
            }
        }

    }
    
}
