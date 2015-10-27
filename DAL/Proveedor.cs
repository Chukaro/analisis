using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Proveedor: Persona
    {
        public static void registraProveedor(Persona ingreso)
        {
            int idProveedor = 0;
            // Proporciona la cadena de conexion a base de datos desde el archivo de configuracion
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados y dispuestos cuando el código sale 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el objeto Command.
                SqlCommand command = new SqlCommand("RegistroPersona", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("nom", ingreso.Nombre);
                command.Parameters.AddWithValue("apPat", ingreso.ApPat);
                command.Parameters.AddWithValue("apMat", ingreso.ApMat);
                command.Parameters.AddWithValue("direccion", ingreso.Direccion);
                command.Parameters.AddWithValue("telefono", ingreso.Telefono);
                command.Parameters.AddWithValue("carnet", ingreso.Carnet);

                command.Parameters.AddWithValue("idPersona", 0);
                command.Parameters["idPersona"].Direction = ParameterDirection.Output;

                try
                {
                    connection.Open();
                    SqlTransaction trato = connection.BeginTransaction();
                    command.Transaction = trato;

                    int fila = command.ExecuteNonQuery();

                    //verifica si se ingreso correctamente al cliente y luego ingresar los telefonos
                    if (fila != 0)
                    {
                        idProveedor = Convert.ToInt32(command.Parameters["idPersona"].Value);

                        SqlCommand commandID = new SqlCommand("RegistroProveedor", connection);
                        commandID.CommandType = CommandType.StoredProcedure;

                        commandID.Parameters.AddWithValue("idProveedor", idProveedor);

                        commandID.Transaction = trato;

                        fila = commandID.ExecuteNonQuery();
                    }

                    if (fila != 0)
                    {
                        trato.Commit();
                    }
                    else
                    {
                        trato.Rollback();
                    }

                   

                }
                catch (Exception)
                {
                    
                    throw;
                }



            }
        }
    }
}
