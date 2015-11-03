using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    public class IngresoBRL
    {
        public static void RegistraIngreso(DAL.Ingreso ingreso)
        {
            DAL.Ingreso.registraIngreso(ingreso);
        }
        //public static Ingreso Obtener(int id)
        //{
        //    return Ingreso.ObtenerIngreso(id);

        //}
        public static void Eliminar(int id)
        {
            DAL.Ingreso.eliminarIngreso(id);
        }
        public static List<DetalleIngreso> listaIngreso(int idDetalle)
        {
            return Ingreso.BuscarIngreso(idDetalle);
        }

        public static DataTable InfIngreso(DateTime fecha)
        {
            return DAL.Ingreso.detIngreso(fecha);
        }
        public static void ActualizarIngreso(DetalleIngreso ing, int idIngreso)
        {
            DAL.Ingreso.actualizarIngreso(ing, idIngreso);
        }
    }
}
