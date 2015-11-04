using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    public class ProductoBRL
    {
        public static void RegistraProducto(DAL.Producto ingreso)
        {
            DAL.Producto.registraProducto(ingreso);
        }

        public static bool ExisteProducto(string buscado)
        {
            return DAL.Producto.existeProducto(buscado);
        }

        public static bool ExisteCodigo(string buscado)
        {
            return DAL.Producto.existeCodigo(buscado);
        }

        public static List<DAL.Producto> llenaCbxProducto()
        {
            return DAL.Producto.llenaCombox();
        }
        
        public static DataTable Buscar(string nombre, int idTipo, int idClasificacion)
        {
            DataTable dev = new DataTable();

            if (nombre != null && idTipo == 0 && idClasificacion == 0)
            {
                dev = DAL.Producto.buscarNombre(nombre);
            }

            if (idTipo != 0 && nombre == null && idClasificacion == 0)
            {
                dev = DAL.Producto.buscarTipo(idTipo);
            }

            if (idClasificacion != 0 && nombre == null && idTipo == 0)
            {
                dev = DAL.Producto.buscarClasificacion(idClasificacion);
            }

            if (nombre != null & idTipo != 0 && idClasificacion == 0)
            {
                dev = DAL.Producto.buscarNombreTipo(nombre, idTipo);
            }

            if (nombre != null & idTipo != 0 & idClasificacion != 0)
            {
                dev = DAL.Producto.buscarTipoNombreClasificacion(nombre, idTipo, idClasificacion);
            }
            if (nombre != null & idTipo == 0 & idClasificacion != 0)
            {
                dev = DAL.Producto.buscarNombreClasificacion(nombre, idClasificacion);
            }

            return dev;
        }

        public static void ActualizarProducto(DAL.Producto ingreso)
        {
            DAL.Producto.actualizarProducto(ingreso);
        }

        public static DAL.Producto DevolverProducto(string id)
        {
            return DAL.Producto.DevolverProducto(id);
        }

        public static DataTable TablaDetalleProduccion(int idPlato, float cantidad)
        {
            return DAL.Producto.tablaDetalleProduccion(idPlato, cantidad);
        }
       
    }
}
