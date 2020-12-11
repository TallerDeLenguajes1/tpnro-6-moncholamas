using Cadeteria.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models
{
    public class RepositorioClientes
    {
        public List<Cliente> getAll()
        {
            //metodos para comunicarme con la BD 
            //devuelve DTO
            //sql conection
            var listaClientes = new List<Cliente>();

            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            conecSQL.Open();

            //comando sql
            var command = conecSQL.CreateCommand();
            command.CommandText = "Select * from Clientes LIMIT 5";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var cliente = new Cliente();
                cliente.Id = Convert.ToInt32(reader["Id"]);
                cliente.Nombre = (reader["nombre"]).ToString();
                cliente.Telefono = reader["telefono"].ToString();
                cliente.Direccion = reader["Direccion"].ToString();
                listaClientes.Add(cliente);
            }
            conecSQL.Close();
            return listaClientes;
        }

        public void altaCliente(Cliente clienteN)
        {
            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            conecSQL.Open();

            var command = conecSQL.CreateCommand();
            command.CommandText = "INSERT INTO Cliente(Nombre,Telefono,Direccion) " +
                                  " VALUES(@Nombre,@Telefono,@Direccion) ";

            command.Parameters.AddWithValue("@Nombre", clienteN.Nombre);
            command.Parameters.AddWithValue("@Telefono", clienteN.Telefono);
            command.Parameters.AddWithValue("@Direccion", clienteN.Direccion);

            command.ExecuteNonQuery();
            conecSQL.Close();
        }

        public void borrarCliente(int id)
        {
            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            conecSQL.Open();
            var command = conecSQL.CreateCommand();
            command.CommandText = "DELETE FROM Clientes WHERE @ID = Id";
            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();
            conecSQL.Close();
        }

    }
}
