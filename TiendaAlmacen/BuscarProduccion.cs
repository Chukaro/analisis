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
             DateTime fechaHoy = DateTime.Now;
             if (dtpFecha.Value.CompareTo(fechaHoy) <= 0)
             {
                 dgvProduccion.DataSource = BRL.ProduccionBRL.DetalleProduccion(dtpFecha.Value.Date);
                 dgvPlatos.Rows.Clear();
                 dgvIngrediente.Rows.Clear();
             }
             else
                 MessageBox.Show("Fecha fuera de rango", "Error de fecha", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvProduccion.CurrentRow.Cells[0].Value);
            DialogResult resultado = MessageBox.Show("Desea elminar", "si", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                BRL.ProduccionBRL.BorraProduccion(id);
                EliminarProducion(id);
            }
        }

        private void dgvProduccion_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
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
                float cantidad = (float)Convert.ToDouble(dgvPlatos.SelectedRows[0].Cells[1].Value);

                ingredienteUsados(idPlato, cantidad);
            }
        }

        private void ingredienteUsados(int idPlato, float cantidad)
        {
            //dgvIngrediente.Rows.Clear();
            List<DAL.Producto> lista = BRL.ProductoBRL.TablaDetalleProduccion(idPlato, cantidad);

            foreach (DAL.Producto item in lista)
            {   //utiliza insert no add
                dgvIngrediente.Rows.Add(item.Codigo, item.Codigo, item.Stock, item.Unidad.Nombre);
            }
        }

        private void platosRecuperados(int idPro)
        {
            dgvPlatos.Rows.Clear();
            List<DAL.DetalleProduccion> lista = BRL.ProduccionBRL.DetallePlatos(idPro);

            foreach (DAL.DetalleProduccion item in lista)
            {   //utiliza insert no add
                dgvPlatos.Rows.Add(item.Plato.Id, item.Cantidad, item.IdProduccion);
                //dgvPlatos.NotifyCurrentCellDirty(true);
            }
        }

        private void EliminarProducion(int idPLato)
        {
            for (int n = dgvProduccion.Rows.Count - 1; n >= 0; n--)
            {
                DataGridViewRow row = dgvProduccion.Rows[n];
                int valor = Convert.ToInt32(dgvProduccion.Rows[n].Cells[0].Value);

                if (valor == idPLato)
                {
                    dgvProduccion.Rows.Remove(row);
                    dgvIngrediente.Rows.Clear();
                    dgvPlatos.Rows.Clear();
                }
            }
        }

    }
}
