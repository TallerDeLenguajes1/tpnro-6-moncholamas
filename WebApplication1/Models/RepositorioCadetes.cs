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
            command.CommandText = "Select * from Cadetes ORDER BY idCadete DESC LIMIT 3";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var cadete = new Cadete();
                cadete.IdCad = Convert.ToInt32(reader["idCadete"]);
                cadete.Nombre = (reader["nombre"]).ToString();
                cadete.Telefono = reader["telefono"].ToString();
                cadete.Direccion = reader["Direccion"].ToString();
                cadete.IdVehiculo = Convert.ToInt32( reader["IdVehiculo"]);
                listaCadetes.Add(cadete);
            }
            conecSQL.Close();
            return listaCadetes;
        }

        public void altaCadete(Cadete cadeteN, Usuario usuarioN)
        {
            
                var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
                var conecSQL = new SQLiteConnection(cadena);
                conecSQL.Open();

                var command1 = conecSQL.CreateCommand();
                command1.CommandText = "INSERT INTO Usuarios(Nombre,Password,Rol) " +
                                      " VALUES(@N,@P,@R) ";

                command1.Parameters.AddWithValue("@N", usuarioN.Nombre);
                command1.Parameters.AddWithValue("@P", usuarioN.Clave);
                command1.Parameters.AddWithValue("@R", 2);



                command1.ExecuteNonQuery();
                
                var RepoU = new RepositorioUsuarios();
                int idRol = RepoU.UltimoUsuarioCargado();
                var command = conecSQL.CreateCommand();
                command.CommandText = "INSERT INTO Cadetes(nombre,telefono,Direccion,IdRol) " +
                                      " VALUES(@Nombre,@Telefono,@Direccion,@Rol) ";

                command.Parameters.AddWithValue("@Nombre", cadeteN.Nombre);
                command.Parameters.AddWithValue("@Telefono", cadeteN.Telefono);
                command.Parameters.AddWithValue("@Direccion", cadeteN.Direccion);
                command.Parameters.AddWithValue("@Rol", idRol);

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

       

        public Cadete UltimoCadeteCargado()
        {
            
            var cadete = new Cadete();

            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            conecSQL.Open();

            //comando sql
            var command = conecSQL.CreateCommand();
            command.CommandText = "Select * from Cadetes ORDER BY idCadete DESC LIMIT 1";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                cadete.IdCad = Convert.ToInt32(reader["idCadete"]);
                cadete.Nombre = (reader["nombre"]).ToString();
                cadete.Telefono = reader["telefono"].ToString();
                cadete.Direccion = reader["Direccion"].ToString();
                cadete.IdVehiculo = Convert.ToInt32(reader["IdVehiculo"]);
            }
            conecSQL.Close();
            return cadete;
        }
    }
}
