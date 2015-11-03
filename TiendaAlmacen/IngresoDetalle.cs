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
            this.dataGridViewIngreso.Columns[1].Visible = false;

            DataGridViewComboBoxColumn comboboxColumn = dataGridViewIngreso.Columns["Producto"] as DataGridViewComboBoxColumn;
            comboboxColumn.DataSource = BRL.ProductoBRL.llenaCbxProducto();
            comboboxColumn.DisplayMember = "Nombre";
            comboboxColumn.ValueMember = "Codigo";

            DataGridViewComboBoxColumn comboboxColumn2 = dataGridViewIngreso.Columns["Unidad"] as DataGridViewComboBoxColumn;
            comboboxColumn2.DataSource = BRL.UnidadBRL.LLenarCmBoxUnidad();
            comboboxColumn2.DisplayMember = "Nombre";
            comboboxColumn2.ValueMember = "Id";
        }


        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.Ingreso ing = new DAL.Ingreso();
                DateTime fechaHoy = DateTime.Now;
                if (dateTimePicker_FechaIngreso.Value.CompareTo(fechaHoy) <= 0)
                {
                    ing.FechaIngreso = dateTimePicker_FechaIngreso.Value;

                    foreach (DataGridViewRow row in dataGridViewIngreso.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null && row.Cells[4].Value != null)
                        {
                            DAL.DetalleIngreso det = new DAL.DetalleIngreso();

                            det.IdProducto = Convert.ToInt32(row.Cells["Codigo"].Value);
                            det.Cantidad = (float)Convert.ToDouble(row.Cells["Cantidad"].Value);
                            det.PrecioCompra = Convert.ToDecimal(row.Cells["PrecioCompra"].Value);
                            det.IdUnidad = Convert.ToInt32(row.Cells["Unidad"].Value);

                            ing.setDetalle(det);
                        }

                    }
                    BRL.IngresoBRL.RegistraIngreso(ing);
                    MessageBox.Show("Datos Agregados");
                    dataGridViewIngreso.Rows.Clear();
                }
                else
                    MessageBox.Show("Fecha fuera de rango", "Error de fecha", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void dataGridViewIngreso_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewIngreso.Columns[e.ColumnIndex].Name == "Producto")
            {
                //
                // se obtiene el valor seleccionado en el combo
                //
                DataGridViewComboBoxCell combo = dataGridViewIngreso.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;

                int idProducto = (int)combo.Value;

                DataGridViewCell cellCodigo = dataGridViewIngreso.Rows[e.RowIndex].Cells["Codigo"];

                cellCodigo.Value = idProducto;
            }

        }

        private void dataGridViewIngreso_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridViewIngreso.CurrentCell.ColumnIndex == 2)
            {
                DataGridViewTextBoxEditingControl txtCantidad = (DataGridViewTextBoxEditingControl)e.Control;
                txtCantidad.KeyPress += new KeyPressEventHandler(txtCantidad_KeyPress);
            }
            if (dataGridViewIngreso.CurrentCell.ColumnIndex == 4)
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
