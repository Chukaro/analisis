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
    public class Persona
    {
        private int idPersona;
        private string nombre;
        private string name;
        private string apPat;
        private string apMat;
        private string direccion;
        private int telefono;
        private int carnet;

        //aumente esto computDOR BETO 
        private Usuario sesion;

        public Persona() 
        {
            sesion = new Usuario();
        }


        public Usuario Sesion
        {
            get { return sesion; }
            set { sesion = value; }
        }

        public int Carnet
        {
            get { return carnet; }
            set { carnet = value; }
        }

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string NombrePersona
        {
            get { return name; }
            set { name = value; }
        }

        public string ApPat
        {
            get { return apPat; }
            set { apPat = value; }
        }
        
        public string ApMat
        {
            get { return apMat; }
            set { apMat = value; }
        }
        
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
       
        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public static Persona datosCuenta(string user, string pass)
        {
            Persona datosUsuario = new Persona();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("verificaCuenta", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("user", user);
                command.Parameters.AddWithValue("pass", pass);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        datosUsuario.IdPersona = reader.GetInt32(0);
                        datosUsuario.Nombre = reader[1].ToString();
                        datosUsuario.Sesion.Tipo.Nombre = reader[2].ToString();
                    }
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

            return datosUsuario;
        }

    }
}
