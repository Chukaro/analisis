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


            this.dataGridViewDetalle.Columns[0].Visible = false;
            this.dataGridViewDetalle.Columns[1].Visible = false;
            this.dataGridViewDetalle.Columns[4].Visible = false;

            DataGridViewComboBoxColumn comboboxColumn = dataGridViewDetalle.Columns["Producto"] as DataGridViewComboBoxColumn;
            comboboxColumn.DataSource = BRL.ProductoBRL.llenaCbxProducto();
            comboboxColumn.DisplayMember = "Nombre";
            comboboxColumn.ValueMember = "Codigo";

            DataGridViewComboBoxColumn comboboxColumn2 = dataGridViewDetalle.Columns["Unidad"] as DataGridViewComboBoxColumn;
            comboboxColumn2.DataSource = BRL.UnidadBRL.LLenarCmBoxUnidad();
            comboboxColumn2.DisplayMember = "Nombre";
            comboboxColumn2.ValueMember = "Id";
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

        }

        private void dataGridViewBuscar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int filaseleccionada = dataGridViewBuscar.CurrentRow.Index;
            //string nombre = Convert.ToString(dataGridViewBuscar.Rows[filaseleccionada].Cells[1].Value);
            //int idClasificacion = Convert.ToInt32(cmBoxBuscarClasificacion.SelectedValue);
            //string idPlato = dataGridViewBuscar.Rows[filaseleccionada].Cells[0].Value.ToString();
            //dataGridViewDetalle.DataSource = BRL.PlatoBRL.BuscarIngredientes(idPlato);
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

        private void dataGridViewBuscar_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewDetalle.Rows.Clear();
            
            if (dataGridViewBuscar.SelectedRows.Count == 1)
            {
                datosRecuperados(Convert.ToInt32(dataGridViewBuscar.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }

        private void datosRecuperados(int idIngrediente)
        {
            List<DAL.Ingrediente> listaIngrediente = BRL.PlatoBRL.listaIngrediente(idIngrediente);

            foreach (DAL.Ingrediente item in listaIngrediente)
            {
                dataGridViewDetalle.Rows.Add(item.Id, item.IdPlato, item.Cantidad, item.IdUnidad, item.IdProducto, item.IdProducto);
            }

        }

        private void dataGridViewDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewDetalle.Columns[e.ColumnIndex].Name == "Producto")
            {
                //
                // se obtiene el valor seleccionado en el combo
                //
                DataGridViewComboBoxCell combo = dataGridViewDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;

                int idProducto = (int)combo.Value;

                DataGridViewCell cellCodigo = dataGridViewDetalle.Rows[e.RowIndex].Cells["IdProducto"];

                cellCodigo.Value = idProducto;
            }

        }

      
    }
}
