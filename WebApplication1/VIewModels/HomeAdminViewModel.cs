using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.VIewModels
{
    public class HomeAdminViewModel
    {
        public string Nombre { get; set; }
        public int Rol { get; set; }
        // public pedidos sin atender
        public List<PedidoViewModel> pedidosPendientes { get; set; }
        // ultimos clientes 
        public List<ClienteViewModel> ultimosClientes { get; set; }

        // cadetes sin asignar
        public List<CadeteViewModel> cadetesSinPedido { get; set; }

    }
}
