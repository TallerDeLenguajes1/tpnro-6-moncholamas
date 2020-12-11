using Cadeteria.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models
{
    public class RepositorioPedidos
    {
        public List<Pedido> getAll()
        {
            //metodos para comunicarme con la BD 
            //devuelve DTO
            //sql conection
            var listaPedidos = new List<Pedido>();

            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            conecSQL.Open();

            //comando sql
            var command = conecSQL.CreateCommand();
            command.CommandText = "Select * from Pedidos LIMIT 5";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var pedido = new Pedido();
                pedido.Nro = Convert.ToInt32(reader["Nro"]);
                pedido.Observacion = (reader["Observacion"]).ToString();
                pedido.Estado = reader["Estado"].ToString();
                pedido.TipoPedido = reader["TipoPedido"].ToString();
                pedido.Costo = Convert.ToDouble(reader["Costo"]);
                pedido.IdCli = Convert.ToInt32(reader["idCli"]);
                if (reader["IdCadete"].Equals(null))
                {
                    pedido.IdCadete = Convert.ToInt32(reader["IdCadete"]);
                }
                              
            listaPedidos.Add(pedido);
            }
            conecSQL.Close();
            return listaPedidos;
        }

        public void altaPedido(Pedido pedidoN)
        {
            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            conecSQL.Open();

            var command = conecSQL.CreateCommand();
            command.CommandText = "INSERT INTO Pedidos(Observacion,Estado,TipoPedido,Costo,idCli,IdCadete) " +
                                  " VALUES(@Obs,@Est,@TPed,@Costo,@idCli,@idCad) ";

            command.Parameters.AddWithValue("@Obs", pedidoN.Observacion);
            command.Parameters.AddWithValue("@Est", pedidoN.Estado);
            command.Parameters.AddWithValue("@Tped", pedidoN.TipoPedido);
            command.Parameters.AddWithValue("@Costo", pedidoN.Costo);
            command.Parameters.AddWithValue("@idCli", pedidoN.IdCli);
            command.Parameters.AddWithValue("@idCad", pedidoN.IdCadete);

            command.ExecuteNonQuery();
            conecSQL.Close();
        }

        public void borrarCliente(int id)
        {
            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            conecSQL.Open();
            var command = conecSQL.CreateCommand();
            command.CommandText = "DELETE FROM Pedidos WHERE @ID = Id";
            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();
            conecSQL.Close();
        }

    }

}
