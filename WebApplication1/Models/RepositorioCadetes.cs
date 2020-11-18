using Cadeteria.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models
{
    public class RepositorioCadetes
    {
        

        public List<Cadete> getAll()
    {
            //metodos para comunicarme con la BD 
            //devuelve DTO
            //sql conection
            var listaCadetes = new List<Cadete>();

            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            conecSQL.Open();

            //comando sql
            var command = conecSQL.CreateCommand();
            command.CommandText = "Select * from Cadetes LIMIT 3";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var cadete = new Cadete();
                cadete.IdCad = Convert.ToInt32(reader["idCadete"]);
                cadete.Nombre = (reader["nombre"]).ToString();
                cadete.Telefono = reader["telefono"].ToString();
                cadete.Direccion = reader["Direccion"].ToString();
                listaCadetes.Add(cadete);
            }
            conecSQL.Close();
            return listaCadetes;
        }

        public void altaCadete(Cadete cadeteN)
        {
            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            conecSQL.Open();

            var command = conecSQL.CreateCommand();
            command.CommandText = "INSERT INTO Cadetes(nombre,telefono,Direccion) " +
                                  " VALUES(@Nombre,@Telefono,@Direccion) ";

            command.Parameters.AddWithValue("@Nombre", cadeteN.Nombre);
            command.Parameters.AddWithValue("@Telefono", cadeteN.Telefono);
            command.Parameters.AddWithValue("@Direccion", cadeteN.Direccion);

            command.ExecuteNonQuery();
            conecSQL.Close();
        }

        public void borrarCadete(int id)
        {
            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            conecSQL.Open();
            var command = conecSQL.CreateCommand();
            command.CommandText = "DELETE FROM Cadetes WHERE @ID = idCadete";
            command.Parameters.AddWithValue("@ID",id);
            command.ExecuteNonQuery();
        }

        public void InfoCadete(int id)
        {
            //muestra la informacion del cadete y los pedidos que hizo
        }

    }
}
