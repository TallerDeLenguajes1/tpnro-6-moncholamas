using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entidades
{
    public class Vehiculo
    {
        protected string Tipo { get; set; }
        public long Matricula { get; set; }
        public Vehiculo(long matr) {
            Matricula = matr;
        }
        public virtual  double plus() {
            return 1;
        }
    }
    class Moto : Vehiculo
    {
        public Moto(long mat) : base(mat) {
            Tipo = "Moto";
        }
        public override double plus()
        {
            return 1.20;
        }

    }
    class Auto : Vehiculo
    {
        public Auto(long mat) : base(mat) {
            Tipo = "Auto";
        }
        public override double plus()
        {
            return 1.25;
        }
    }
    class Bicicleta : Vehiculo
    {
        public Bicicleta(long mat) : base(mat) {
            Tipo = "Bicicleta";
        }
        public override double plus()
        {
            return 1.05;
        }
    }
}
