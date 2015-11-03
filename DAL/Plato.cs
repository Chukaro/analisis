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
    public class Plato
    {
        private int id;
        private string nombre;
        private decimal costo;
        private Clasificacion clasificacion;
        private List<Ingrediente> ingredientes;
        

        public Plato() 
        {
            ingredientes = new List<Ingrediente>();
            clasificacion = new Clasificacion();
        }

        public Plato(int id, string nombre) 
        {
            this.id = id;
            this.nombre = nombre;
        }


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public decimal Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public Clasificacion Clasificacion
        {
            get { return clasificacion; }
            set { clasificacion = value; }
        }

        public List<Ingrediente> getIngredientes()
        {
            return ingredientes;
        }

        public void setIngredientes(Ingrediente ing)
        {
            ingredientes.Add(ing);
        }

        public List<Ingrediente> getIngredientesUsados()
        {
            return ingredientes;
        }

        public void setIngredientesUsados(Ingrediente ing)
        {
            ingredientes.Add(ing);
        }

        
        public static Plato infPalto(int idPlato, float cantPlatos)
        { 
            Plato plato = new Plato();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INF_PLATO", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("cantPlato", cantPlatos);
                command.Parameters.AddWithValue("idplato", idPlato);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        plato.Id = reader.GetInt32(0);
                        plato.Nombre = reader[1].ToString();
                        plato.Costo = reader.GetDecimal(2);

                        reader.NextResult();

                        while (reader.Read())
                        {
                            Ingrediente ingrediente = new Ingrediente();

                            ingrediente.IdProducto = reader.GetInt32(0);
                            ingrediente.Cantidad = (float)reader.GetDouble(1);
                            ingrediente.Unidad.Nombre = reader[2].ToString();

                            plato.setIngredientes(ingrediente);
                        }

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

            return plato;
        }

        public static List<Plato> platos()
        {
            List<Plato> platos = new List<Plato>();
            platos.Add(new Plato(0, "Seleccione un plato"));

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("Platos", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        Plato plato = new Plato();

                        plato.Id = reader.GetInt32(0);
                        plato.Nombre = reader[1].ToString();

                        platos.Add(plato);
                    }

                }
                catch (SqlException ex)
                {
                    //throw ex;
                }
                catch (Exception ex)
                {
                    //throw ex;
                }
            }

            return platos;
        }

        public static DataTable buscarNombre(string nombre)
        {
            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("buscarPlatos", connection);
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

        public static DataTable buscarClasificacion(int idClasificacion)
        {
            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("buscarPlatoClasificacion", connection);
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.AddWithValue("idClasificacion", idClasificacion);
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

        public static DataTable buscarPlatoClasificacion(string nombre, int idClasificacion)
        {
            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("buscarPlatoClasificacion2", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("nombre", nombre);
                command.Parameters.AddWithValue("idClasificacion", idClasificacion);
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

        public static DataTable buscarIngrediente(string idPlato)
        {
            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("buscarIngredientes", connection);
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.AddWithValue("IdPlato", idPlato);
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

        public static void registraPlato(Plato plato)
        {
            // Proporciona la cadena de conexion a base de datos desde el archivo de configuracion
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados y dispuestos cuando el código sale 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el objeto Command.
                SqlCommand command = new SqlCommand("Registro_Plato", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("nombre", plato.Nombre);
                command.Parameters.AddWithValue("costo", plato.Costo);
                command.Parameters.AddWithValue("idClasificacion", plato.Clasificacion.Codigo);
                command.Parameters.AddWithValue("idPlato", 0);

                command.Parameters["idPlato"].Direction = ParameterDirection.Output;

                try
                {
                    connection.Open();
                    //transacciones
                    SqlTransaction trato = connection.BeginTransaction();
                    command.Transaction = trato;

                    int fila = command.ExecuteNonQuery();


                    if (fila != 0)
                    {

                        int id = Convert.ToInt32(command.Parameters["idPlato"].Value);

                        foreach (Ingrediente ing in plato.getIngredientes())
                        {
                            SqlCommand comanding = new SqlCommand("Registro_Ingredientes", connection);

                            comanding.CommandType = CommandType.StoredProcedure;


                            comanding.Parameters.AddWithValue("cantidad", ing.Cantidad);
                            comanding.Parameters.AddWithValue("idPlato", id);
                            comanding.Parameters.AddWithValue("idProducto", ing.IdProducto);
                            comanding.Parameters.AddWithValue("idUnidad", ing.Unidad.Id);

                            comanding.Transaction = trato;

                            fila = comanding.ExecuteNonQuery();

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

        public static bool existePlato(string nombre)
        {
            bool existe = false;
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ExistePlato", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("plato", nombre);
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


        public static List<Ingrediente> BuscarIngrediente(int idIngrediente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Proporcionar la cadena de consulta 
            // string queryString = "Select IdPersona, Nombre,  ApPaterno from Persona where Nombre like '%{0}%' or ApPaterno like '%{1}%'";


            //Lista de Clientes recuperados
            List<Ingrediente> listaIngrediente = new List<Ingrediente>();

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados 
            // y dispuestos cuando el código sale 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el objeto Command.
                SqlCommand command = new SqlCommand("infoIngrediente", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("idIngrediente", idIngrediente);

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

                            Ingrediente ing = new Ingrediente();

                            ing.Id = reader.GetInt32(0);
                            ing.IdPlato = reader.GetInt32(1);
                            ing.Cantidad = (float)reader.GetDouble(2);
                            ing.IdUnidad = reader.GetInt32(3);
                            ing.IdProducto = reader.GetInt32(4);




                            listaIngrediente.Add(ing);

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

            return listaIngrediente;
        }

        public static void actualizarIngredientes(Plato modificar)
        {
            // Proporciona la cadena de conexion a base de datos desde el archivo de configuracion
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;


            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados y dispuestos cuando el código sale 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand commandI = new SqlCommand("ActualizarPlato", connection);
                commandI.CommandType = CommandType.StoredProcedure;
                commandI.Parameters.AddWithValue("id", modificar.Id);
                commandI.Parameters.AddWithValue("nom", modificar.Nombre);
                commandI.Parameters.AddWithValue("precio", modificar.Costo);
                commandI.Parameters.AddWithValue("clasificacion", modificar.Clasificacion);


                // Crear el objeto Command.


                try
                {
                    connection.Open();
                    SqlTransaction trato = connection.BeginTransaction();
                    commandI.Transaction = trato;

                    int fila = commandI.ExecuteNonQuery();


                    foreach (Ingrediente item in modificar.getIngredientes())
                    {
                        SqlCommand command = new SqlCommand("ActualizarIngrediente", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("idIngrediente", item.Id);
                        command.Parameters.AddWithValue("cantidad", item.Cantidad);
                        command.Parameters.AddWithValue("idPlato", item.IdPlato);
                        command.Parameters.AddWithValue("idProducto", item.IdProducto);
                        command.Parameters.AddWithValue("idUnidad", item.IdUnidad);

                        command.ExecuteNonQuery();

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
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
    }
}
