using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DetalleIngreso
    {
        private int idDetalle;
        private float cantidad;
        private decimal precioCompra;
        private int idIngreso;
        private int idProducto;
        private int idUnidad;

        public int IdUnidad
        {
            get { return idUnidad; }
            set { idUnidad = value; }
        }

        public decimal PrecioCompra
        {
            get { return precioCompra; }
            set { precioCompra = value; }
        }
        public int IdDetalle
        {
            get { return idDetalle; }
            set { idDetalle = value; }
        }


        public float Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        public int IdIngreso
        {
            get { return idIngreso; }
            set { idIngreso = value; }
        }


        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }
    }
}
