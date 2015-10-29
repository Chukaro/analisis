using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    public class ClasificacionBRL
    {
        public static List<DAL.Clasificacion> LLenarCmBoxClasificacion()
        {
            return DAL.Clasificacion.llenarCmBoxClasificacion();
        }
        public static object LLenarCmBoxClasificacion2()
        {
            return DAL.Clasificacion.llenarCmBoxClasificacion2();
        }
    }
}
