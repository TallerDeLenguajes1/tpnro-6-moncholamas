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
            command.CommandText = "Select * from Cadetes ORDER BY idCadete DESC LIMIT 5";

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

        public void altaCadete(Cadete cadeteN)
        {

                var cadena1 = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
                var conecSQL = new SQLiteConnection(cadena1);
                conecSQL.Open();
                                
                var command = conecSQL.CreateCommand();

                command.Parameters.AddWithValue("@Nombre", cadeteN.Nombre);
                command.Parameters.AddWithValue("@Telefono", cadeteN.Telefono);
                command.Parameters.AddWithValue("@Direccion", cadeteN.Direccion);
                command.Parameters.AddWithValue("@Rol", 2);
                command.CommandText = "INSERT INTO Cadetes(nombre,telefono,Direccion,IdRol) " +
                                      " VALUES(@Nombre,@Telefono,@Direccion,@Rol) ";

                
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

        public Cadete getCadete(int id)
        {
            var cadete = new Cadete();

            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            try
            {
                
                conecSQL.Open();

                var command = conecSQL.CreateCommand();
                command.Parameters.AddWithValue("@ID", id);
                command.CommandText = "Select * from Cadetes WHERE idCadete = @ID";

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cadete.IdCad = Convert.ToInt32(reader["idCadete"]);
                        cadete.Nombre = (reader["nombre"]).ToString();
                        cadete.Telefono = reader["telefono"].ToString();
                        cadete.Direccion = reader["Direccion"].ToString();
                        cadete.IdVehiculo = Convert.ToInt32(reader["IdVehiculo"]);
                    }

                    return cadete;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conecSQL.Close();
            }

            
        }
        public bool ModificarCadete(Cadete c)
        {
            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            try
            {
                conecSQL.Open();
               
                //comando sql
                var command = conecSQL.CreateCommand();

                command.Parameters.AddWithValue("@Nombre", c.Nombre);
                command.Parameters.AddWithValue("@Direccion", c.Direccion);
                command.Parameters.AddWithValue("@Telefono", c.Telefono);
                command.Parameters.AddWithValue("@Vehiculo", c.IdVehiculo);
                command.Parameters.AddWithValue("@id", c.IdCad);

                command.CommandText = "UPDATE Cadetes " +
                                        "SET Nombre = @Nombre," +
                                        "Direccion = @Direccion," +
                                        "Telefono = @Telefono, " +
                                        "IdVehiculo = @Vehiculo" +
                                        " WHERE idCadete = @id;";

                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conecSQL.Close();
            }
        }
        public bool AsignarVehiculo(int IdC, int IdV)
        {
            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            try
            {
                conecSQL.Open();

                //comando sql
                var command = conecSQL.CreateCommand();
                                
                command.Parameters.AddWithValue("@IdV", IdV);
                command.Parameters.AddWithValue("@IdC", IdC);

                command.CommandText = "UPDATE Cadetes " +
                                        "SET IdVehiculo = @IdV" +
                                        " WHERE idCadete = @IdV;";

                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conecSQL.Close();
            }
        }
    }
}
