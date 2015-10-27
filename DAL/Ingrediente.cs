using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Ingrediente
    {
        private int id;
        private int idPlato;
        private int idProducto;
        private string nombre;
        private float cantidad;
        private Unidad unidad = new Unidad();

        public int IdPlato
        {
            get { return idPlato; }
            set { idPlato = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public float Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public Unidad Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }

    }
}
