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
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
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
    }
}
