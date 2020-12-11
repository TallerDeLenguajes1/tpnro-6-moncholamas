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
        public bool Verificar(Usuario u)
        {
            
            var cadena = "Data Source= " + Path.Combine(Directory.GetCurrentDirectory(), "DB\\Cadeteria.db");
            var conecSQL = new SQLiteConnection(cadena);
            conecSQL.Open();


            var command = conecSQL.CreateCommand();
            command.CommandText = "SELECT * FROM Administradores Where nombre LIKE @N  AND Password LIKE @C ";
            command.Parameters.AddWithValue("@N", u.Nombre);
            command.Parameters.AddWithValue("@C", u.Clave);

            var reader = command.ExecuteReader();

          
            if (reader.HasRows )
            {

                conecSQL.Close();
                return true; 
                
            }
            else
            {

                conecSQL.Close();
                return false;

            }

                       
        }

    }
}
