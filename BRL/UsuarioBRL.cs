using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BRL
{
    public class UsuarioBRL
    {
        public static DataTable Nombre()
        {
            DataTable dev = new DataTable();

            dev = DAL.Usuario.buscarUsuarios();

            return dev;
        }

        public static void ActualizarUsuario(DAL.Usuario user)
        {
            DAL.Usuario.actualizaUsuario(user);
        }

        public static DAL.Usuario DevolverUsuario(int id)
        {
            return DAL.Usuario.DevolverUsuario(id);
        }

        public static DAL.Usuario EliminarUsuario(int p)
        {
            return DAL.Usuario.EliminarUsuario(p);
        }
    }
}
