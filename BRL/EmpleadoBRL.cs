using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    public class EmpleadoBRL
    {
        public static void Insertar(DAL.Empleado pro)
        {
            DAL.Empleado.registraEmpleado(pro);
        }

        public static object Empleado(string nombre, int idClasificacion)
        {
            DataTable dev = new DataTable();

            if (nombre != null && idClasificacion == 0)
            {
                dev = DAL.Empleado.buscarNombre(nombre);
            }

            if (idClasificacion != 0 || nombre == null)
            {
                dev = DAL.Empleado.buscarTipoUsuario(idClasificacion);
            }

            return dev;
        }
    }
}
