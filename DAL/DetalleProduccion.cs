using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DetalleProduccion
    {
        private float cantidad;
        private int idProduccion;

        private Plato plato;
       
        public DetalleProduccion() 
        {
            plato = new Plato();
        }

        public float Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public int IdProduccion
        {
            get { return idProduccion; }
            set { idProduccion = value; }
        }
     
        public Plato Plato
        {
            get { return plato; }
            set { plato = value; }
        }

    }
}
