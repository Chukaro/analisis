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
    public class Unidad
    {
        private int id;
        private string nombre;

        public Unidad()
        { 
        }

        public Unidad(int id, string nom)
        {
            this.id = id;
            this.nombre = nom;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public static List<Unidad> llenarCmBoxUnidad()
        {
            List<Unidad> dev = new List<Unidad>();
            dev.Add(new Unidad(0,"Elija unidad"));

            // Proporciona la cadena de conexion a base de datos desde el archivo de configuracion
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados 
            // y dispuestos cuando el código sale 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlDataReader reader;

                // Crear el objeto Command.
                SqlCommand command = new SqlCommand("cmBoxUnidad", connection);
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
                            Unidad u = new Unidad();
                            u.Id = reader.GetInt32(0);
                            u.Nombre = reader[1].ToString();
                            dev.Add(u);
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
