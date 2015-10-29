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
    public class Clasificacion
    {
        private int id;
        private string tipo;

        public Clasificacion(string nom, int id)
        {
            this.tipo = nom;
            this.id = id;
        }

        public Clasificacion()
        {
        }


        public int Codigo
        {
            get { return id; }
            set { id = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public static List<Clasificacion> llenarCmBoxClasificacion()
        {
            List<Clasificacion> dev = new List<Clasificacion>();
            dev.Add(new Clasificacion("Seleccione clasificacion", 0));

            // Proporciona la cadena de conexion a base de datos desde el archivo de configuracion
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados 
            // y dispuestos cuando el código sale 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlDataReader reader;

                // Crear el objeto Command.<z
                ///CAMBIAR Y ENVIAR LISTAS
                SqlCommand command = new SqlCommand("cmBoxClasificacion", connection);
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
                            Clasificacion c = new Clasificacion();
                            c.Codigo = reader.GetInt32(0);
                            c.Tipo = reader[1].ToString();
                            dev.Add(c);
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

            return dev;
        }
        public static List<Clasificacion> llenarCmBoxClasificacion2()
        {
            List<Clasificacion> dev = new List<Clasificacion>();
            dev.Add(new Clasificacion("Seleccione clasificacion", 0));

            // Proporciona la cadena de conexion a base de datos desde el archivo de configuracion
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados 
            // y dispuestos cuando el código sale 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlDataReader reader;

                // Crear el objeto Command.<z
                ///CAMBIAR Y ENVIAR LISTAS
                SqlCommand command = new SqlCommand("cmBoxClasificacion2", connection);
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
                            Clasificacion c = new Clasificacion();
                            c.Codigo = reader.GetInt32(0);
                            c.Tipo = reader[1].ToString();
                            dev.Add(c);
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

            return dev;
        }
    }
}
