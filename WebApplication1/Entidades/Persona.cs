using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entidades
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Persona() { }
        public Persona(string nom, string dir, string tel)
        {
            Nombre = nom;
            Direccion = dir;
            Telefono = tel;
        }
    }
    public class Cliente
    {
        List<Pedido> pedidosRealizados;
        public Cliente(string nom, string dir, string tel)
        {
        }

        public bool AgregarPedido(Pedido P)
        {
            pedidosRealizados.Add(P);
            return true;
        }
        public List<Pedido> PedidosRealizados()
        {
            return pedidosRealizados;
        }
    }

    public class Cadete
    {
        public int IdCad { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
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