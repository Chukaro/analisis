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
    public class Empleado : Persona
    {
        private int id;


        public Empleado()
        {
        }

        public int Codigo
        {
            get { return id; }
            set { id = value; }
        }

        public static void registraEmpleado(Persona empleado)
        {
            int idEmpleado = 0;
            // Proporciona la cadena de conexion a base de datos desde el archivo de configuracion
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados y dispuestos cuando el código sale 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el objeto Command.
                SqlCommand command = new SqlCommand("RegistroPersona", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("nombre", empleado.Nombre);
                command.Parameters.AddWithValue("apPaterno", empleado.ApPat);
                command.Parameters.AddWithValue("apMaterno", empleado.ApMat);
                command.Parameters.AddWithValue("direccion", empleado.Direccion);
                command.Parameters.AddWithValue("telefono", empleado.Telefono);
                command.Parameters.AddWithValue("carnet", empleado.Carnet);

                command.Parameters.AddWithValue("idPersona", 0);
                command.Parameters["idPersona"].Direction = ParameterDirection.Output;

                try
                {
                    connection.Open();
                    SqlTransaction trato = connection.BeginTransaction();
                    command.Transaction = trato;

                    int fila = command.ExecuteNonQuery();


                    if (fila != 0)
                    {
                        idEmpleado = Convert.ToInt32(command.Parameters["idPersona"].Value);

                        SqlCommand commandID = new SqlCommand("RegistroEmpleado", connection);
                        commandID.CommandType = CommandType.StoredProcedure;

                        commandID.Parameters.AddWithValue("idEmpleado", idEmpleado);


                        commandID.Transaction = trato;


                        fila = commandID.ExecuteNonQuery();

                        SqlCommand comandUsuario = new SqlCommand("RegistroUsuario", connection);
                        comandUsuario.CommandType = CommandType.StoredProcedure;

                        comandUsuario.Parameters.AddWithValue("nombre", empleado.Sesion.Nombre);
                        comandUsuario.Parameters.AddWithValue("pasword", empleado.Sesion.Password);
                        comandUsuario.Parameters.AddWithValue("idTipoUsuario", empleado.Sesion.IdTipoUsuario);
                        comandUsuario.Parameters.AddWithValue("idEmpleado", idEmpleado);
                        

                        comandUsuario.Transaction = trato;

                        fila = comandUsuario.ExecuteNonQuery();


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


        public static DataTable buscarNombre(string nombre)
        {
            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("buscarNombreEmpleado", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("nombre", nombre);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    SqlDataAdapter tableAdapter = new SqlDataAdapter(command);

                    tableAdapter.Fill(devolverDataTable);

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
            return devolverDataTable;
        }

        public static DataTable buscarTipoUsuario(int id)
        {
            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("buscarCargoEmpleado", connection);
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.AddWithValue("cargo", id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    SqlDataAdapter tableAdapter = new SqlDataAdapter(command);

                    tableAdapter.Fill(devolverDataTable);

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
            return devolverDataTable;
        }

        public static DataTable buscarEmpleadoTipo(string nombre, int ide)
        {
            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("buscarEmpleadoYTipo", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("nombre", nombre);
                command.Parameters.AddWithValue("idTipoUsuario", ide);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    SqlDataAdapter tableAdapter = new SqlDataAdapter(command);

                    tableAdapter.Fill(devolverDataTable);

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
            return devolverDataTable;
        }

    }

}
