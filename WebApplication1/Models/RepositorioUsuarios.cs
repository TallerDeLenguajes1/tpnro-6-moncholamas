using Cadeteria.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models
{
    public class RepositorioUsuarios
    {
        public Usuario Verificar(Usuario u)
        {
            
            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            var NuevoUsuario = new Usuario();

            conecSQL.Open();


            var command = conecSQL.CreateCommand();
            command.CommandText = "SELECT * FROM Usuarios Where nombre LIKE @N  AND Password LIKE @C ";
            command.Parameters.AddWithValue("@N", u.Nombre);
            command.Parameters.AddWithValue("@C", u.Clave);

            var reader = command.ExecuteReader();

          
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    NuevoUsuario.Id = Convert.ToInt32(reader["Id"]);
                    NuevoUsuario.Nombre = (reader["Nombre"]).ToString();
                    NuevoUsuario.Clave = "";
                    NuevoUsuario.Rol = Convert.ToInt32(reader["Rol"]);
                }
                conecSQL.Close();
                return NuevoUsuario; 
                
            }
            else
            {

                conecSQL.Close();
                return null;

            }

                       
        }
        public Usuario TraerUsuario(string NombreU)
        {
            //devuelvo un usuario con el rol para tener control de las vistas

            

            return null;
        }

        public int UltimoUsuarioCargado()
        {

            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            int id;

            conecSQL.Open();


            var command = conecSQL.CreateCommand();
            command.CommandText = "SELECT * FROM Usuarios ORDER BY Id DESC LIMIT 1";
            
            var reader = command.ExecuteReader();


            if (reader.HasRows)
            {

                reader.Read();                
                id = Convert.ToInt32(reader["Id"]);                             
                conecSQL.Close();
                return id;

            }
            else
            {

                conecSQL.Close();
                return 0;

            }


        }
        public int AltaUsuario(Usuario usuarioN)
        {
            int IdUsuario=0;
            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            conecSQL.Open();

            var command1 = conecSQL.CreateCommand();
            command1.Parameters.AddWithValue("@N", usuarioN.Nombre);
            command1.Parameters.AddWithValue("@P", usuarioN.Clave);
            command1.Parameters.AddWithValue("@R", 2);

            command1.CommandText = "INSERT INTO Usuarios(Nombre,Password,Rol) " +
                                  " VALUES(@N,@P,@R) ";

            var res = command1.ExecuteNonQuery();
            if (res > 0)
            {
                IdUsuario = UltimoUsuarioCargado();
            }
            conecSQL.Close();
            return IdUsuario;
        }

    }
}
