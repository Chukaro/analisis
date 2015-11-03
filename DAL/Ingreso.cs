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
    public class Ingreso
    {
        private int idIngreso;
        private DateTime fechaIngreso;
        List<DetalleIngreso> detalleIngreso = new List<DetalleIngreso>();

        public void setDetalle(DetalleIngreso det)
        {
            detalleIngreso.Add(det);
        }

        public List<DetalleIngreso> getDetalles()
        {
            return detalleIngreso;
        }

        public int IdIngreso
        {
            get { return idIngreso; }
            set { idIngreso = value; }
        }


        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        public static void registraIngreso(Ingreso ingreso)
        {
            // Proporciona la cadena de conexion a base de datos desde el archivo de configuracion
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados y dispuestos cuando el código sale 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el objeto Command.
                SqlCommand command = new SqlCommand("RegistroIngreso", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("fechaIngreso", ingreso.fechaIngreso);
                command.Parameters.AddWithValue("idIngreso", 0);

                command.Parameters["idIngreso"].Direction = ParameterDirection.Output;

                try
                {
                    connection.Open();
                    //transacciones
                    SqlTransaction trato = connection.BeginTransaction();
                    command.Transaction = trato;

                    int fila = command.ExecuteNonQuery();


                    if (fila != 0)
                    {

                        int idIngreso = Convert.ToInt32(command.Parameters["idIngreso"].Value);

                        foreach (DetalleIngreso det in ingreso.getDetalles())
                        {
                            SqlCommand comanddet = new SqlCommand("Registro_Detalle", connection);

                            comanddet.CommandType = CommandType.StoredProcedure;


                            comanddet.Parameters.AddWithValue("cantidad", det.Cantidad);
                            comanddet.Parameters.AddWithValue("precioCompra", det.PrecioCompra);
                            comanddet.Parameters.AddWithValue("idIngreso", idIngreso);
                            comanddet.Parameters.AddWithValue("idProducto", det.IdProducto);
                            comanddet.Parameters.AddWithValue("idUnidad", det.IdUnidad);

                            comanddet.Transaction = trato;

                            fila = comanddet.ExecuteNonQuery();

                            SqlCommand comandStock = new SqlCommand("ActualizarStock", connection);

                            comandStock.CommandType = CommandType.StoredProcedure;
                            comandStock.Parameters.AddWithValue("idProducto", det.IdProducto);
                            comandStock.Parameters.AddWithValue("stock", det.Cantidad);

                            comandStock.Transaction = trato;
                            fila = comandStock.ExecuteNonQuery();
                        }
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
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static DataTable detIngreso(DateTime fecha)
        {
            String fechaInicio = "00:00:00";
            String horaFin = "23:59:59";

            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("infoIngreso", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("fecha", fecha);
                command.Parameters.AddWithValue("horaInicio", fechaInicio);
                command.Parameters.AddWithValue("horaFin", horaFin);


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



        public static List<DetalleIngreso> BuscarIngreso(int idDetalle)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Proporcionar la cadena de consulta 
            // string queryString = "Select IdPersona, Nombre,  ApPaterno from Persona where Nombre like '%{0}%' or ApPaterno like '%{1}%'";


            //Lista de Clientes recuperados
            List<DetalleIngreso> listaDetalle = new List<DetalleIngreso>();

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados 
            // y dispuestos cuando el código sale 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el objeto Command.
                SqlCommand command = new SqlCommand("infoDetalleIngreso", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("idDetalle", idDetalle);

                // Abre la conexión en un bloque try / catch
                // Crear y ejecutar el DataReader, escribiendo 
                // el conjunto de resultados a la ventana de la consola.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            DetalleIngreso det = new DetalleIngreso();
                            //Ingreso ing = new Ingreso();
                            det.IdDetalle = reader.GetInt32(0);
                            det.IdIngreso = reader.GetInt32(1);
                            det.Cantidad = (float)reader.GetDouble(2);
                            det.PrecioCompra = reader.GetDecimal(3);
                            det.IdProducto = reader.GetInt32(4);
                            det.IdUnidad = reader.GetInt32(5);


                            listaDetalle.Add(det);

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

            return listaDetalle;
        }

        public static void actualizarIngreso(DetalleIngreso detalle, int idIngreso)
        {
            string conn = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand actualizarDetalle = new SqlCommand("ActualizarIngreso", connection);
                actualizarDetalle.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    actualizarDetalle.Parameters.AddWithValue("idDetalle", detalle.IdDetalle);
                    actualizarDetalle.Parameters.AddWithValue("idProducto", detalle.IdProducto);
                    actualizarDetalle.Parameters.AddWithValue("cantidad", detalle.Cantidad);
                    actualizarDetalle.Parameters.AddWithValue("precioCompra", detalle.PrecioCompra);
                    actualizarDetalle.Parameters.AddWithValue("idIngreso", idIngreso);
                    actualizarDetalle.Parameters.AddWithValue("unidad", detalle.IdUnidad);


                    actualizarDetalle.ExecuteNonQuery();




                    SqlCommand comandStock = new SqlCommand("ActualizarStock", connection);

                    comandStock.CommandType = CommandType.StoredProcedure;
                    comandStock.Parameters.AddWithValue("idProducto", detalle.IdProducto);
                    comandStock.Parameters.AddWithValue("stock", detalle.Cantidad);

                    comandStock.ExecuteNonQuery();


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
        }

        public static void eliminarIngreso(int id)
        {
            string con = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            string consulta = "delete DetalleIngreso where Ingreso_IdIngreso = @id";

            using (SqlConnection coneccion = new SqlConnection(con))
            {
                SqlCommand comand = new SqlCommand(consulta, coneccion);
                comand.Parameters.AddWithValue("@id", id);

                try
                {

                    coneccion.Open();
                    comand.ExecuteNonQuery();

                    string consultadet = "delete Ingreso where IdIngreso = @idI ";

                    SqlCommand comand2 = new SqlCommand(consultadet, coneccion);
                    comand2.Parameters.AddWithValue("@idI", id);

                    comand2.ExecuteNonQuery();

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
        }
    }
}
