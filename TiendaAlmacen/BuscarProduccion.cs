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
    public partial class BuscarProduccion : UserControl
    {
        public BuscarProduccion()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvPlatos.DataSource = null;
            dgvIngrediente.DataSource = null;

            DateTime fechaHoy = DateTime.Now;
            if (dtpFecha.Value.CompareTo(fechaHoy) <= 0)
            {
                buscarProducion(dtpFecha.Value.Date);
            }
            else
                MessageBox.Show("Fecha fuera de rango", "Error de fecha", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buscarProducion(DateTime dateTime)
        {
            dgvProduccion.DataSource = BRL.ProduccionBRL.DetalleProduccion(dateTime);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvProduccion.CurrentRow.Cells[0].Value);

            DialogResult resultado = MessageBox.Show("Desea elminar", "si", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                BRL.ProduccionBRL.BorraProduccion(id);
                buscarProducion(dtpFecha.Value.Date);
                dgvPlatos.DataSource = null;
                dgvIngrediente.DataSource = null;
            }
        }

        private void dgvProduccion_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvPlatos.DataSource = null;
            dgvIngrediente.DataSource = null;
            if (dgvProduccion.SelectedRows.Count == 1)
            {
                platosRecuperados(Convert.ToInt32(dgvProduccion.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }

        private void dgvPlatos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPlatos.SelectedRows.Count == 1)
            {
                int idPlato = Convert.ToInt32(dgvPlatos.SelectedRows[0].Cells[0].Value);
                float cantidad = (float)Convert.ToDouble(dgvPlatos.SelectedRows[0].Cells[2].Value);

                ingredienteUsados(idPlato, cantidad);
            }
        }

        private void ingredienteUsados(int idPlato, float cantidad)
        {
            dgvIngrediente.DataSource = BRL.ProductoBRL.TablaDetalleProduccion(idPlato, cantidad);
        }

        private void platosRecuperados(int idPro)
        {
            dgvPlatos.DataSource = BRL.ProduccionBRL.DetallePlatos(idPro);
        }

    }
}
