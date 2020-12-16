using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Cliente() { }
        public Cliente(string nom, string dir, string tel)
        {
            Nombre = nom;
            Direccion = dir;
            Telefono = tel;
        }
        List<Pedido> pedidosRealizados;
       
    }
 

    public class Cadete
    {
        public int IdCad { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdVehiculo { get; set; }
        public Cadete() { }
        public Cadete(string nom, string dir, string tel)
        {

            Nombre = nom;
            Direccion = dir;
            Telefono = tel;
        }

        List<Pedido> pedidosTransportados;

        Vehiculo vehiculoActual;


        public bool AgregarPedido(Pedido P)
        {
            pedidosTransportados.Add(P);
            return true;
        }
        public List<Pedido> PedidosRealizados()
        {
            return pedidosTransportados;
        }
        public void AsignarVehiculo(Vehiculo v) {
            vehiculoActual = v;
        }

    }

}