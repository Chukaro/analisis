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
    public partial class BuscarIngreso : UserControl
    {
        public BuscarIngreso()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
           


            this.dgvDetalleIngreso.Columns[0].Visible = false;
            this.dgvDetalleIngreso.Columns[1].Visible = false;
            this.dgvDetalleIngreso.Columns[3].Visible = false;

            DataGridViewComboBoxColumn comboboxColumn = dgvDetalleIngreso.Columns["Producto"] as DataGridViewComboBoxColumn;
            comboboxColumn.DataSource = BRL.ProductoBRL.llenaCbxProducto();
            comboboxColumn.DisplayMember = "Nombre";
            comboboxColumn.ValueMember = "Codigo";

            DataGridViewComboBoxColumn comboboxColumn2 = dgvDetalleIngreso.Columns["Unidad"] as DataGridViewComboBoxColumn;
            comboboxColumn2.DataSource = BRL.UnidadBRL.LLenarCmBoxUnidad();
            comboboxColumn2.DisplayMember = "Nombre";
            comboboxColumn2.ValueMember = "Id";
        }

        //metodo para recuperar datos

        private void datosRecuperados(int idDetalle)
        {
            List<DAL.DetalleIngreso> lista = BRL.IngresoBRL.listaIngreso(idDetalle);

            foreach (DAL.DetalleIngreso item in lista)
            {
                dgvDetalleIngreso.Rows.Add(item.IdDetalle, item.IdIngreso, item.IdProducto, item.IdProducto, String.Format("{0:0.00}", item.Cantidad), item.IdUnidad, String.Format("{0:0.00}", item.PrecioCompra));
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fechaHoy = DateTime.Now;
            if (dateTimePickerFecha.Value.CompareTo(fechaHoy) <= 0)
            {
                dgvIngreso.DataSource = BRL.IngresoBRL.InfIngreso(dateTimePickerFecha.Value.Date);
                dgvDetalleIngreso.Rows.Clear();
                this.dgvIngreso.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
                this.dgvIngreso.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

            }
            else
                MessageBox.Show("Fecha fuera de rango", "Error de fecha", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            DAL.Ingreso ingreso = new DAL.Ingreso();

            int idIngreso = Convert.ToInt32(dgvIngreso.CurrentRow.Cells[0].Value);

            foreach (DataGridViewRow item in dgvDetalleIngreso.Rows)
            {
                DAL.DetalleIngreso ing = new DAL.DetalleIngreso();

                ing.IdDetalle = Convert.ToInt32(item.Cells[0].Value);
                ing.IdProducto = Convert.ToInt32(item.Cells[3].Value);
                ing.Cantidad = (float)Convert.ToDouble(item.Cells[4].Value);
                ing.IdUnidad = Convert.ToInt32(item.Cells[5].Value);
                ing.PrecioCompra = Convert.ToDecimal(item.Cells[6].Value);

                BRL.IngresoBRL.ActualizarIngreso(ing, idIngreso);

            }

            //envia todos los datos en una lista no uno por uno
            MessageBox.Show("Datos Modificados");
            dgvDetalleIngreso.Rows.Clear();

        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id;
            DialogResult resultado = MessageBox.Show("Desea elminar", "si", MessageBoxButtons.YesNo);
            id = Convert.ToInt32(dgvIngreso.CurrentRow.Cells[0].Value);
            if (resultado == DialogResult.Yes)
            {

                BRL.IngresoBRL.Eliminar(id);
                dgvDetalleIngreso.Rows.Clear();

            }
        }



        private void dgvIngreso_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetalleIngreso.Rows.Clear();

            if (dgvIngreso.SelectedRows.Count == 1)
            {
                datosRecuperados(Convert.ToInt32(dgvIngreso.SelectedRows[0].Cells[0].Value.ToString()));

                this.dgvDetalleIngreso.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
                this.dgvDetalleIngreso.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);


            }

        }

        private void dgvDetalleIngreso_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleIngreso.Columns[e.ColumnIndex].Name == "Producto")
            {
                //
                // se obtiene el valor seleccionado en el combo
                //
                DataGridViewComboBoxCell combo = dgvDetalleIngreso.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;

                int idProducto = (int)combo.Value;

                DataGridViewCell cellCodigo = dgvDetalleIngreso.Rows[e.RowIndex].Cells["IdProducto"];

                cellCodigo.Value = idProducto;
            }

        }

        private void dgvDetalleIngreso_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvDetalleIngreso.CurrentCell.ColumnIndex == 4)
            {
                DataGridViewTextBoxEditingControl txtCantidad = (DataGridViewTextBoxEditingControl)e.Control;
                txtCantidad.KeyPress += new KeyPressEventHandler(txtCantidad_KeyPress);
            }
            if (dgvDetalleIngreso.CurrentCell.ColumnIndex == 6)
            {
                DataGridViewTextBoxEditingControl txtCosto = (DataGridViewTextBoxEditingControl)e.Control;
                txtCosto.KeyPress += new KeyPressEventHandler(txtCosto_KeyPress);
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.Validar.NumerosDecimales(e, sender);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.Validar.NumerosDecimales(e, sender);
        }
    }
}
