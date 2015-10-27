using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaAlmacen
{
    public partial class Buscar : UserControl
    {
        public Buscar()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            BuscarClasificacionCmBox();
            BuscarTipoAlimentoCmBox();
        }

        private void BuscarClasificacionCmBox()
        {
            cmBoxBuscarClasificacion.DataSource = BRL.ClasificacionBRL.LLenarCmBoxClasificacion();
            cmBoxBuscarClasificacion.DisplayMember = "Tipo";
            cmBoxBuscarClasificacion.ValueMember = "Codigo";
        }

        private void BuscarTipoAlimentoCmBox()
        {
            cmBoxBuscarTipo.Text = "Seleccione tipo de alimento";
            cmBoxBuscarTipo.DataSource = BRL.TipoAlimentoBRL.LLenarCmBoxTipoAlimento();
            cmBoxBuscarTipo.DisplayMember = "Tipo";
            cmBoxBuscarTipo.ValueMember = "Codigo";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscar.Text;
            int idTipo = Convert.ToInt32(cmBoxBuscarTipo.SelectedValue);
            int idClasificacion = Convert.ToInt32(cmBoxBuscarClasificacion.SelectedValue);

           //MessageBox.Show(nombre +"  "+ idTipo +"  "+ idClasificacion,"Prueba");

            dataGridViewBuscar.DataSource = BRL.ProductoBRL.Buscar(nombre, idTipo, idClasificacion); 
            //dataGridViewBuscar.Columns[0].Visible = false;
            dataGridViewBuscar.Columns[1].HeaderText = "Nombre del producto";
            dataGridViewBuscar.Columns[2].HeaderText = "Cantidad";
            dataGridViewBuscar.Columns[3].HeaderText = "Precio de venta";

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ModificarProducto frmModificar = new ModificarProducto();
                frmModificar.LlenarCampo(dataGridViewBuscar.SelectedRows[0].Cells[0].Value.ToString());
                frmModificar.ShowDialog();
                //searchCliente();
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione un Prodcuto ", "Error al selecionar deproducto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoProducto nuevo = new NuevoProducto();
            nuevo.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

    }
}
