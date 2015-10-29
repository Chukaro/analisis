using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaAlmacen
{
    public partial class Form1 : Form
    {
        private Buscar buscar;
        private IngresoDetalle ingreso;
        private ControlProduccion produccion;
        private BuscarProduccion buscarProduccion;
        private BuscarPlato busPlato;
        private buscarEmpleado buscaremp;
        //public Form1()
        //{
        //    //InitializeComponent();
        //    buscar = new Buscar();
        //    ingreso = new IngresoDetalle();
        //    produccion = new ControlProduccion();
        //    ////menuStrip1.
        //    //productoToolStripMenuItem.Enabled = false;
        //}

        public Form1(DAL.Persona detalleUsuario)
        {
            InitializeComponent();
            buscar = new Buscar();
            ingreso = new IngresoDetalle();
            produccion = new ControlProduccion();
            buscarProduccion = new BuscarProduccion();

            Program.nombre = detalleUsuario.Nombre;
            Program.cargo = detalleUsuario.Sesion.Tipo.Nombre.ToLower();
            Program.idEmpleado = detalleUsuario.IdPersona;

            mnuUser.Text = Program.nombre;
            mnuUser.Enabled = false;

            switch (Program.cargo)
            {
                case "administrador":
                    menuStrip1.Enabled = true;
                    break;
                case "almacen":
                    salidasToolStripMenuItem.Enabled = false;
                    productoToolStripMenuItem.Enabled = true;
                    ingresoToolStripMenuItem.Enabled = true;
                    break;
                case "cocina":
                    salidasToolStripMenuItem.Enabled = true;
                    productoToolStripMenuItem.Enabled = false;
                    ingresoToolStripMenuItem.Enabled = false;
                    break;

                default:
                    menuStrip1.Enabled = false;
                    break;
            }
                      
        }

        private void ingresarNuevoProductoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NuevoProducto nuevo = new NuevoProducto();
            nuevo.ShowDialog();
        }

        private void buscarProductoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            paneContenedor.Controls.Clear();
            paneContenedor.Controls.Add(buscar);
        }

        private void registroIngresoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            paneContenedor.Controls.Clear();
            paneContenedor.Controls.Add(ingreso);
        }

        private void produccionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            produccion.idEmpleado(Program.idEmpleado);
            paneContenedor.Controls.Clear();
            paneContenedor.Controls.Add(produccion);
        }

        private void buscarEliminarProduccionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            paneContenedor.Controls.Clear();
            paneContenedor.Controls.Add(buscarProduccion);
        }

        private void buscarPlatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paneContenedor.Controls.Clear();
            paneContenedor.Controls.Add(busPlato);
        }

        private void buscarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paneContenedor.Controls.Clear();
            paneContenedor.Controls.Add(buscaremp);
        }
    }
}
