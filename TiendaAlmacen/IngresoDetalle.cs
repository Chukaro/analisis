using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TiendaAlmacen
{
    public partial class IngresoDetalle : UserControl
    {
        public IngresoDetalle()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            DataGridViewComboBoxColumn comboboxColumn = dataGridViewIngreso.Columns["Producto"] as DataGridViewComboBoxColumn;
            comboboxColumn.DataSource = BRL.ProductoBRL.llenaCbxProducto();
            comboboxColumn.DisplayMember = "Nombre";
            comboboxColumn.ValueMember = "Codigo";
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.Ingreso ing = new DAL.Ingreso();

                ing.FechaIngreso = dateTimePicker_FechaIngreso.Value;

                foreach (DataGridViewRow row in dataGridViewIngreso.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                    {
                        DAL.DetalleIngreso det = new DAL.DetalleIngreso();

                        det.IdProducto = Convert.ToString(row.Cells["Codigo"].Value);
                        det.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                        det.PrecioCompra = Convert.ToDecimal(row.Cells["PrecioCompra"].Value);
                        ing.setDetalle(det);
                    }
                    
                }
                BRL.IngresoBRL.RegistraIngreso(ing);
                MessageBox.Show("Datos Agregados");

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione un Prodcuto ", "Error al selecionar de producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            NuevoProducto nuevo = new NuevoProducto();
            nuevo.ShowDialog();
        }

        private void dataGridViewIngreso_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridViewIngreso.CurrentCell.ColumnIndex == 2)
            {
                DataGridViewTextBoxEditingControl txtCantidad = (DataGridViewTextBoxEditingControl)e.Control;
                txtCantidad.KeyPress += new KeyPressEventHandler(txtCantidad_KeyPress);
            }
            if (dataGridViewIngreso.CurrentCell.ColumnIndex == 3)
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

        private void dataGridViewIngreso_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewIngreso.Columns[e.ColumnIndex].Name == "Producto")
            {
                //
                // se obtiene el valor seleccionado en el combo
                //
                DataGridViewComboBoxCell combo = dataGridViewIngreso.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;

                string idProducto = (String)combo.Value;

                DataGridViewCell cellCodigo = dataGridViewIngreso.Rows[e.RowIndex].Cells["Codigo"];

                cellCodigo.Value = idProducto;
            }
        }
    }
}
