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
    public class TipoUsuario
    {
        private int id;
        private string nombre;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public TipoUsuario() { }

        public TipoUsuario(string nom, int id)
        {
            this.nombre = nom;
            this.id = id;
        }

        public static List<TipoUsuario> llenarCmBoxTipoUsuario()
        {
            List<TipoUsuario> tipo = new List<TipoUsuario>();

            tipo.Add(new TipoUsuario("Seleccione clasificacion", 0));
            // Proporciona la cadena de conexion a base de datos desde el archivo de configuracion
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados 
            // y dispuestos cuando el código sale 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlDataReader reader;

                // Crear el objeto Command.
                SqlCommand command = new SqlCommand("ListaTipoUsuario", connection);
                command.CommandType = CommandType.StoredProcedure; //especifica de que tipo es la consulta "procedimiento".
                // Abre la conexión en un bloque try / catch. 
                // Crear y ejecutar el DataReader, escribiendo 
                // el conjunto de resultados a la ventana de la consola.
                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();

                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            TipoUsuario tipousuario = new TipoUsuario();
                            tipousuario.Id = reader.GetInt32(0);
                            tipousuario.Nombre = reader[1].ToString();
                            tipo.Add(tipousuario);
                        }
                        reader.NextResult();

                    }
                    reader.Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return tipo;
        }


    }
}
