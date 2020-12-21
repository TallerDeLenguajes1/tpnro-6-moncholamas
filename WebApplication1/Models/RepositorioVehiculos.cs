using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cadeteria.Entidades;

namespace Cadeteria.Models
{
    public class RepositorioVehiculos
    {
        public List<Vehiculo> getAll()
        {
            //metodos para comunicarme con la BD 
            //devuelve DTO
            //sql conection
            var listaVehiculo = new List<Vehiculo>();

            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            conecSQL.Open();

            //comando sql
            var command = conecSQL.CreateCommand();
            command.CommandText = "Select * from Vehiculos Where IdVehiculo <> 0 ORDER BY IdVehiculo DESC";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                
                var vehiculo = new Vehiculo();
                vehiculo.IdVehiculo = Convert.ToInt32(reader["IdVehiculo"]);
                vehiculo.Matricula = (reader["Matricula"]).ToString();
                vehiculo.Tipo = (reader["Tipo"]).ToString();
                listaVehiculo.Add(vehiculo);
            }
            conecSQL.Close();
            return listaVehiculo;
        }

        
    }

}
