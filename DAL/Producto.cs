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
    public class Producto
    {
        private int id;
        private string nombre;
        private float stock;
        private decimal precioVenta;
        private Clasificacion clasificacion = new Clasificacion();
        private TipoAlimento tipo = new TipoAlimento();
        private Unidad unidad = new Unidad();
        
        public Producto() { }

        public Producto(int id, float stock, int idPlato)
        {
            this.id = id;
            this.stock = stock;
        }

        
        public decimal PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }

        public int Codigo
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public float Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public Clasificacion Clasificacion
        {
            get { return clasificacion; }
            set { clasificacion = value; }
        }


        public TipoAlimento Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public Unidad Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }

        public static void registraProducto(Producto ingreso)
        {
            // Proporciona la cadena de conexion a base de datos desde el archivo de configuracion
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados y dispuestos cuando el código sale 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el objeto Command.
                SqlCommand command = new SqlCommand("TV_RegistraProducto", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("id", ingreso.Codigo);
                command.Parameters.AddWithValue("nom", ingreso.Nombre);
                command.Parameters.AddWithValue("stock", ingreso.Stock);
                command.Parameters.AddWithValue("precio", ingreso.PrecioVenta);
                command.Parameters.AddWithValue("tipo", ingreso.Tipo.Codigo);
                command.Parameters.AddWithValue("clasificacion", ingreso.Clasificacion.Codigo);
                command.Parameters.AddWithValue("unidad", ingreso.Unidad.Id);
               
                try
                {
                    connection.Open();
                    SqlTransaction trato = connection.BeginTransaction();
                    command.Transaction = trato;

                    int fila = command.ExecuteNonQuery();

                    
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
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        
        }

        public static bool existeProducto(string nombre)
        {
            bool existe = false;
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("TV_ExisteProducto", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("bus", nombre);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        existe = true;
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
            return existe;
        }

        public static bool existeCodigo(string id)
        {
            bool existe = false;
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("TV_ExisteID", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("bus", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        existe = true;
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
            return existe;
        }

        public static DataTable buscarNombreTipo(string nombre, int id)
        {
            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("buscarTipoNombre", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("nombre", nombre);
                command.Parameters.AddWithValue("idTipo", id);

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
        public static DataTable buscarNombre(string nombre)
        {
            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("buscarNombre", connection);
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
        public static DataTable buscarTipoNombreClasificacion(string nombre, int id, int ide)
        {
            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("buscarTipoNombreClasificacion", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("nombre", nombre);
                command.Parameters.AddWithValue("idTipo", id);
                command.Parameters.AddWithValue("idClasificacion", ide);
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

        public static DataTable buscarTipo(int id)
        {
            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("buscarTipo", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("idTipo", id);
        
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

        public static DataTable buscarClasificacion(int id)
        {
            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("buscarClasificacion", connection);
                command.CommandType = CommandType.StoredProcedure;

              
                command.Parameters.AddWithValue("idClasificacion", id);
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

        public static DataTable buscarNombreClasificacion(string nombre, int ide)
        {
            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("buscarNombreClasificacion", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("nombre", nombre);
                command.Parameters.AddWithValue("idClasificacion", ide);
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

        public static void actualizarProducto(Producto modificar)
        {
            // Proporciona la cadena de conexion a base de datos desde el archivo de configuracion
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados y dispuestos cuando el código sale 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el objeto Command.
                SqlCommand command = new SqlCommand("ActualizarProducto", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("id", modificar.Codigo);
                command.Parameters.AddWithValue("nom", modificar.Nombre);
                command.Parameters.AddWithValue("stock", modificar.Stock);
                command.Parameters.AddWithValue("precio", modificar.PrecioVenta);
                command.Parameters.AddWithValue("tipo", modificar.Tipo.Codigo);
                command.Parameters.AddWithValue("clasificacion", modificar.Clasificacion.Codigo);
                command.Parameters.AddWithValue("unidad", modificar.Unidad.Id);

                try
                {
                    connection.Open();
                    SqlTransaction trato = connection.BeginTransaction();
                    command.Transaction = trato;

                    int fila = command.ExecuteNonQuery();


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
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public static Producto DevolverProducto(string id)
        {
            Producto prod = new Producto();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("RecuperarProducto", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("id", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        prod.Codigo = reader.GetInt32(0);
                        prod.Nombre = reader[1].ToString();

                        prod.Stock = (float)reader.GetDouble(2);
                        prod.PrecioVenta = reader.GetDecimal(3);

                        prod.Clasificacion.Codigo = reader.GetInt32(4);
                        prod.Unidad.Id = reader.GetInt32(5);
                        prod.Tipo.Codigo = reader.GetInt32(6);

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

                return prod;
            }
        }

        public static List<Producto> llenaCombox()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Proporcionar la cadena de consulta 
            string queryString = "SELECT IdProducto, Nombre FROM Producto";

            //Lista de empleados recuperados
            List<Producto> lista = new List<Producto>();

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados 
            // y dispuestos cuando el código sale 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el objeto Command.
                SqlCommand command = new SqlCommand(queryString, connection);

                // Abre la conexión en un bloque try / catch. 
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
                            Producto idProducto = new Producto();

                            idProducto.Codigo = reader.GetInt32(0);
                            idProducto.Nombre = reader.GetString(1);

                            lista.Add(idProducto);
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
            return lista;
        }

        public static DataTable tablaDetalleProduccion(int idPlato, float cantidad)
        {
            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ingredienteDetalle", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("cantidad", cantidad);
                command.Parameters.AddWithValue("idPlato", idPlato);

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
