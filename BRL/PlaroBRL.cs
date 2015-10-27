using System;
using System.Collections.Generic;
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
    }
}
