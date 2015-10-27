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
    }
}
