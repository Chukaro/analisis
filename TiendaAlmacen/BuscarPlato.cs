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
    public partial class BuscarPlato : UserControl
    {
        public BuscarPlato()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            BuscarClasificacionCmBox();
        }

        private void BuscarClasificacionCmBox()
        {
            cmBoxBuscarClasificacion.DataSource = BRL.ClasificacionBRL.LLenarCmBoxClasificacion2();
            cmBoxBuscarClasificacion.DisplayMember = "Tipo";
            cmBoxBuscarClasificacion.ValueMember = "Codigo";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscar.Text;
            int idClasificacion = Convert.ToInt32(cmBoxBuscarClasificacion.SelectedValue);

            //MessageBox.Show(nombre +"  "+ idTipo +"  "+ idClasificacion,"Prueba");

            dataGridViewBuscar.DataSource = BRL.PlatoBRL.NombrePlato(nombre, idClasificacion);
            //dataGridViewBuscar.Columns[0].Visible = false;
            //dataGridViewBuscar.Columns[0].HeaderText = "ID";
            //dataGridViewBuscar.Columns[1].HeaderText = "Nombre del producto";
            //dataGridViewBuscar.Columns[2].HeaderText = "Cantidad";
            //dataGridViewBuscar.Columns[3].HeaderText = "Precio de venta";
        }

        private void dataGridViewBuscar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaseleccionada = dataGridViewBuscar.CurrentRow.Index;
            string nombre = Convert.ToString(dataGridViewBuscar.Rows[filaseleccionada].Cells[1].Value);
            int idClasificacion = Convert.ToInt32(cmBoxBuscarClasificacion.SelectedValue);
            string idPlato = dataGridViewBuscar.Rows[filaseleccionada].Cells[0].Value.ToString();
            dataGridViewDetalle.DataSource = BRL.PlatoBRL.BuscarIngredientes(idPlato);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.Validar.SoloLetras(e, sender);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarClasificacionCmBox();
            dataGridViewBuscar.DataSource = null;
            dataGridViewBuscar.Refresh();
            dataGridViewDetalle.DataSource = null;
            dataGridViewDetalle.Refresh();
        }


    }
}
