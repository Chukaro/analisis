using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    public class ProduccionBRL
    {

        public static void LLenarDatosProduccion(DAL.Produccion produccion, List<DAL.Producto> actualizaStock)
        {
            DAL.Produccion.llenarDatosProduccion(produccion, actualizaStock);
        }

        public static DataTable DetalleProduccion(DateTime fecha)
        {
            return DAL.Produccion.detalleProduccion(fecha);  
        }

        public static DataTable DetallePlatos(int idProduccion)
        {
            return DAL.Produccion.detallePlatos(idProduccion);
        }

        public static void BorraProduccion(int idProduccion)
        {
            DAL.Produccion.borraProduccion(idProduccion);
        }
    }
}
