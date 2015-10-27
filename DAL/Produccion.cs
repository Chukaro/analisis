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
    public class Produccion
    {
        private int idProduccion;
        private int idEmpleado;
        private DateTime fechaProd;

        private List<DetalleProduccion> detalle;

        public Produccion()
        {
            detalle = new List<DetalleProduccion>();
        }

        public int IdProduccion
        {
            get { return idProduccion; }
            set { idProduccion = value; }
        }

        public DateTime FechaProd
        {
            get { return fechaProd; }
            set { fechaProd = value; }
        }

        public int IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }

        public void setListaDetalle(DetalleProduccion d)
        {
            detalle.Add(d);
        }

        public List<DetalleProduccion> getListaDetalle()
        {
            return detalle;
        }
               

        public void eliminarElementoLista(int id)
        {
            //var itemToRemove = detalle.Single(r => r.IdPlato == id);
            //detalle.Remove(itemToRemove);

            var eliminaplato = detalle.Single(p => p.Plato.Id == id);
            detalle.Remove(eliminaplato);
            detalle.Remove(eliminaplato);
        }

        public static void llenarDatosProduccion(Produccion produccion, List<Producto> actualizaStock)
        {
            bool correcto = false;
            
            //Primero los item de produccion
            // Proporciona la cadena de conexion a base de datos desde el archivo de configuracion
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados y dispuestos cuando el código sale 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el objeto Command.
                SqlCommand command = new SqlCommand("InsertarProducion", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("fecha", produccion.FechaProd);
                command.Parameters.AddWithValue("idEmpleado", produccion.IdEmpleado);
                
                //rejistrar el  parametro para salida
                command.Parameters.AddWithValue("idProduccion", 0);

                command.Parameters["idProduccion"].Direction = ParameterDirection.Output;

                try
                {
                    connection.Open();
                    //transacciones
                    SqlTransaction trato = connection.BeginTransaction();
                    command.Transaction = trato;

                    int fila = command.ExecuteNonQuery();

                    //verifica si se ingreso correctamente al cliente y luego ingresar los telefonos
                    if (fila != 0)
                    {
                        int idProduccion = Convert.ToInt32(command.Parameters["idProduccion"].Value);

                        foreach (DetalleProduccion item in produccion.getListaDetalle())
                        {
                            SqlCommand commandDetalle = new SqlCommand("InsertarDetalleProduccion", connection);
                            commandDetalle.CommandType = CommandType.StoredProcedure;

                            commandDetalle.Parameters.AddWithValue("cantidad", item.Cantidad);
                            commandDetalle.Parameters.AddWithValue("idPlato", item.Plato.Id);
                            commandDetalle.Parameters.AddWithValue("idProduccion", idProduccion);

                            commandDetalle.Transaction = trato;
                            fila = commandDetalle.ExecuteNonQuery();

                            if (fila != 0)
                            {
                                foreach (Ingrediente usado in item.Plato.getIngredientes())
                                {
                                    SqlCommand commandUsado = new SqlCommand("ActualizarCantidadProducto", connection);
                                    commandUsado.CommandType = CommandType.StoredProcedure;

                                    commandUsado.Parameters.AddWithValue("cantidad", usado.Cantidad);
                                    commandUsado.Parameters.AddWithValue("idProducto", usado.IdProducto);

                                    commandUsado.Transaction = trato;
                                    fila = commandUsado.ExecuteNonQuery();

                                    if (fila != 0)
                                    {
                                        correcto = true;
                                    }
                                    else
                                    {
                                        correcto = false;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                correcto = false;
                                break;
                            }
                        }
                    }

                    if (correcto)
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
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static DataTable detalleProduccion(DateTime fecha)
        {
            String fechaInicio = "00:00:00";
            String horaFin = "23:59:59";

            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ProduccionRealizadas", connection);
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


        public static List<DetalleProduccion> detallePlatos(int idProduccion)
        {
            List<DetalleProduccion> devLisat = new List<DetalleProduccion>();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("platosProduccion", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("idProduccion", idProduccion);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Ingrediente ingrediente = new Ingrediente();

                        DetalleProduccion detalle = new DetalleProduccion();

                        detalle.Cantidad = (float)reader.GetDouble(1);
                        detalle.IdProduccion = reader.GetInt32(2);
                        detalle.Plato.Id = reader.GetInt32(3);

                        devLisat.Add(detalle);
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
            return devLisat;
        }

        public static void borraProduccion(int idProduccion)
        {
            string con = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;


            using (SqlConnection connection = new SqlConnection(con))
            {

                SqlCommand command = new SqlCommand("platosProduccion", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("idProduccion", idProduccion);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
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
