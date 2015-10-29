using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    public class PlatoBRL
    {
        public static DAL.Plato InfPalto(int idPlato, float cantPlatos)
        {
            return DAL.Plato.infPalto(idPlato, cantPlatos);
        }

        public static List<DAL.Plato> Platos()
        {
            return DAL.Plato.platos();
        }


        public static object NombrePlato(string nombre, int idClasificacion)
        {
            DataTable dev = new DataTable();

            if (nombre != null && idClasificacion == 0)
            {
                dev = DAL.Plato.buscarNombre(nombre);
            }

            if (idClasificacion != 0 || nombre == null)
            {
                dev = DAL.Plato.buscarClasificacion(idClasificacion);
            }
            if (idClasificacion != 0 && nombre != null)
            {
                dev = DAL.Plato.buscarPlatoClasificacion(nombre, idClasificacion);
            }
            return dev;
        }


        public static object BuscarIngredientes(string idPlato)
        {
            DataTable dev = new DataTable();

            if (idPlato != null)
            {
                dev = DAL.Plato.buscarIngrediente(idPlato);
            }

            return dev;
        }
    }
}
