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
    public partial class RegistroPlato : UserControl
    {
        public RegistroPlato()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            ClasificacionCmBox();
            this.dataGridViewRegistroPlato.Columns[1].Visible = false;


            cmBoxClasificacion.DropDownStyle = ComboBoxStyle.DropDownList;



            DataGridViewComboBoxColumn comboboxColumn = dataGridViewRegistroPlato.Columns["Producto"] as DataGridViewComboBoxColumn;
            comboboxColumn.DataSource = BRL.ProductoBRL.llenaCbxProducto();
            comboboxColumn.DisplayMember = "Nombre";
            comboboxColumn.ValueMember = "Codigo";

            DataGridViewComboBoxColumn comboboxColumn2 = dataGridViewRegistroPlato.Columns["unidad"] as DataGridViewComboBoxColumn;
            comboboxColumn2.DataSource = BRL.UnidadBRL.LLenarCmBoxUnidad();
            comboboxColumn2.DisplayMember = "Nombre";
            comboboxColumn2.ValueMember = "Id";
        }

        private void ClasificacionCmBox()
        {
            cmBoxClasificacion.DataSource = BRL.ClasificacionBRL.LLenarCmBoxClasificacion();
            cmBoxClasificacion.DisplayMember = "Tipo";
            cmBoxClasificacion.ValueMember = "Codigo";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.Plato plato = new DAL.Plato();

                plato.Nombre = txtNonmrePlato.Text;
                plato.Costo = Convert.ToDecimal(txtCostoPlato.Text);


                plato.Clasificacion.Codigo = Convert.ToInt32(cmBoxClasificacion.SelectedValue);

                foreach (DataGridViewRow row in dataGridViewRegistroPlato.Rows)
                {

                    if (row.Cells[0].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                    {
                        DAL.Ingrediente ing = new DAL.Ingrediente();

                        ing.IdProducto = Convert.ToInt32(row.Cells["Codigo"].Value);
                        ing.Cantidad = (float)Convert.ToDouble(row.Cells["Cantidad"].Value);
                        ing.Unidad.Id = Convert.ToInt32(row.Cells["Unidad"].Value);

                        plato.setIngredientes(ing);
                    }


                }
                BRL.PlatoBRL.RegistraPlato(plato);
                MessageBox.Show("Datos Agregados");
                dataGridViewRegistroPlato.Rows.Clear();
                txtNonmrePlato.Clear();
                txtCostoPlato.Clear();


            }

            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("llene todos los campos", "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int fila = dataGridViewRegistroPlato.CurrentRow.Index;
            dataGridViewRegistroPlato.Rows.RemoveAt(fila);

        }

        private void dataGridViewRegistroPlato_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridViewRegistroPlato.CurrentCell.ColumnIndex == 2)
            {
                DataGridViewTextBoxEditingControl cantidad = (DataGridViewTextBoxEditingControl)e.Control;
                cantidad.KeyPress += new KeyPressEventHandler(txt_Cantidad);

            }
        }

        private void txt_Cantidad(object sender, KeyPressEventArgs e)
        {
            DAL.Validar.NumerosDecimales(e, sender);
        }

        private void dataGridViewRegistroPlato_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewRegistroPlato.Columns[e.ColumnIndex].Name == "Producto")
            {
                //
                // se obtiene el valor seleccionado en el combo
                //
                DataGridViewComboBoxCell combo = dataGridViewRegistroPlato.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;

                int idProducto = (int)combo.Value;

                DataGridViewCell cellCodigo = dataGridViewRegistroPlato.Rows[e.RowIndex].Cells["Codigo"];

                cellCodigo.Value = idProducto;

            }
        }

        private void txtNonmrePlato_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNonmrePlato.Text))
            {
                if (BRL.PlatoBRL.ExistePlato(txtNonmrePlato.Text))
                {
                    errorExistePlato.SetError(txtNonmrePlato, "plato ya existe");
                    MessageBox.Show("Existe Plato");
                    errorExistePlato.Clear();
                    btnGuardar.Enabled = false;
                    txtNonmrePlato.Clear();

                }
                else
                {
                    btnGuardar.Enabled = true;
                }


            }
        }

        private void txtCostoPlato_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.Validar.NumerosDecimales(e, sender);
        }

    }
}
