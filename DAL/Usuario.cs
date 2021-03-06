﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string usuario;
        private TipoUsuario tipo;
        private string password;
        private int idTipoUsuario;

        public int IdTipoUsuario
        {
            get { return idTipoUsuario; }
            set { idTipoUsuario = value; }
        }

        private int idpersona;
        private string nombrepersona;
        private string appaterno;
        private string apmaterno;
        private string direccion;
        private int telefono;
        private int carnet;

        public Usuario()
        {
            //modificado otra computadora
            tipo = new TipoUsuario();
        }

        public String Usuario1
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public TipoUsuario Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

/// ////////////////////////////
        public Usuario(int id, string nom)
        {
            this.id = id;
            this.nombre = nom;
        }

        public string NombrePersona
        {
            get { return nombrepersona; }
            set { nombrepersona = value; }
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

        public int Idpersona
        {
            get { return idpersona; }
            set { idpersona = value; }
        }

        public string Appaterno
        {
            get { return appaterno; }
            set { appaterno = value; }
        }
        public string Apmaterno
        {
            get { return apmaterno; }
            set { apmaterno = value; }
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
        public int Carnet
        {
            get { return carnet; }
            set { carnet = value; }
        }
        public static DataTable buscarUsuarios()
        {
            DataTable devolverDataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("buscarUsuarios", connection);
                command.CommandType = CommandType.StoredProcedure;

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



        public static void actualizaUsuario(Usuario user)
        {
            // Proporciona la cadena de conexion a base de datos desde el archivo de configuracion
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados y dispuestos cuando el código sale 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el objeto Command.
                SqlCommand command = new SqlCommand("ActualizarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("id", user.Id);
                command.Parameters.AddWithValue("nombre", user.Nombre);
                command.Parameters.AddWithValue("password", user.Password);


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
                catch (Exception)
                {

                    throw;
                }
            }
        }


        public static Usuario DevolverUsuario(int id)
        {
            Usuario user = new Usuario();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("RecuperarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("id", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        user.Id = Convert.ToInt32(reader[0].ToString());
                        user.Nombre = reader[1].ToString();

                        user.Password = reader[2].ToString();

                        user.Idpersona = Convert.ToInt32(reader[3].ToString());
                        user.NombrePersona = reader[4].ToString();
                        user.Appaterno = reader[5].ToString();
                        user.Apmaterno = reader[6].ToString();
                        user.Direccion = reader[7].ToString();
                        user.Telefono = Convert.ToInt32(reader[8].ToString());
                        user.Carnet = Convert.ToInt32(reader[9].ToString());

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

                return user;
            }
        }

        public static Usuario EliminarUsuario(int p)
        {
            Usuario user = new Usuario();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("EliminarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("id", p);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

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

                return user;
            }
        }

        public static Usuario devolverPersona(int p)
        {
            Usuario user = new Usuario();

            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("RecuperarPersona", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("id", p);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        user.Appaterno = reader[0].ToString();
                        user.Apmaterno = reader[1].ToString();
                        user.Direccion = reader[2].ToString();
                        user.Telefono = Convert.ToInt32(reader[3].ToString());
                        user.Carnet = Convert.ToInt32(reader[4].ToString());

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

                return user;
            }
        }

        public static void actualizarPersona(Usuario update)
        {
            // Proporciona la cadena de conexion a base de datos desde el archivo de configuracion
            string connectionString = ConfigurationManager.ConnectionStrings["TiendaConString"].ConnectionString;

            // Crear y abrir la conexión en un bloque using. 
            // Esto asegura que todos los recursos serán cerrados y dispuestos cuando el código sale 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el objeto Command.
                SqlCommand command = new SqlCommand("ActualizarPersona", connection);
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.AddWithValue("idpersona", update.Idpersona);
                command.Parameters.AddWithValue("nombre", update.NombrePersona);
                command.Parameters.AddWithValue("appaterno", update.Appaterno);
                command.Parameters.AddWithValue("apmaterno", update.Apmaterno);
                command.Parameters.AddWithValue("direccion", update.Direccion);
                command.Parameters.AddWithValue("telefono", update.Telefono);
                command.Parameters.AddWithValue("carnet", update.Carnet);


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
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
