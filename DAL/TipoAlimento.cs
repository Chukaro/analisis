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
    public class TipoAlimento
    {
        private int id;
        private string tipo;

        public TipoAlimento(string nom, int id)
        {
            this.tipo = nom;
            this.id = id;
        }

        public TipoAlimento()
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

        public static List<TipoAlimento> llenarCmBoxTipoAlimento()
        {
            List<TipoAlimento> dev = new List<TipoAlimento>();
            dev.Add(new TipoAlimento("Seleccione un Tipo", 0));
            // Proporciona la cadena de conexion a base de datos desde el archivo de configuracion
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados 
            // y dispuestos cuando el código sale 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlDataReader reader;

                // Crear el objeto Command.
                ///CAMBIAR Y ENVIAR LISTAS
                SqlCommand command = new SqlCommand("cmBoxTipoAlimento", connection);
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
                            TipoAlimento ta = new TipoAlimento();
                           
                            ta.Codigo = reader.GetInt32(0);
                            ta.Tipo = reader[1].ToString();
                            
                            dev.Add(ta);
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
