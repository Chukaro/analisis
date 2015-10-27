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
    public partial class ControlProduccion : UserControl
    {
        private List<DAL.Producto> listaProducto;
        private DAL.Produccion produccion;

        public ControlProduccion()
        {
            listaProducto = new List<DAL.Producto>();
            produccion = new DAL.Produccion();

            
            this.Dock = DockStyle.Fill;

            InitializeComponent();
            
            this.dgvPlatos.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
            this.dgvPlatos.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            
            PlatosCmBox();
            llenadoComboBoxDataGridView();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idPlato = (int)cmBoxPlato.SelectedValue;
            int cantidad = Convert.ToInt32(numCantidad.Value);

            if (idPlato > 0 && cantidad > 0)
            {
                DateTime fechaHoy = DateTime.Now;

                this.lblFecha.Text = fechaHoy.ToString();

                tablaPlatos(idPlato, cantidad);
            }
            else
                MessageBox.Show("Tiene que elegir plato y cantidad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tablaPlatos(int idPlato, float cantidad)
        {
            DAL.DetalleProduccion detalle = new DAL.DetalleProduccion();

            //DAL.Plato infPlato = BRL.PlatoBRL.InfPalto(idPlato, cantidad);

            detalle.Cantidad = cantidad;
            detalle.Plato = BRL.PlatoBRL.InfPalto(idPlato, cantidad); ;
            
            produccion.setListaDetalle(detalle);
            
            celdasPlato();

            //produccion.setListaDetalle(new DAL.DetalleProduccion(idPlato, cantidad));

            this.dgvPlatos.Rows.Add(detalle.Plato.Id, detalle.Plato.Nombre, null, null, cantidad, null, String.Format("{0:0.00}", detalle.Plato.Costo));

            lblTotal.Text = String.Format("{0:0.00}", detalle.Plato.Costo + Convert.ToDecimal(lblTotal.Text));

            foreach (DAL.Ingrediente ing in detalle.Plato.getIngredientes())
            {
                celdasIngredientes();

                this.dgvPlatos.Rows.Add(idPlato, null, ing.IdProducto, ing.IdProducto, String.Format("{0:0.00}", ing.Cantidad), ing.Unidad.Nombre, null);

                ing.Cantidad = DAL.Validar.ConvertirAKilo(ing.Unidad.Nombre.ToLower(), ing.Cantidad);
                
                //listaProducto.Add(new DAL.Producto(ing.IdProducto, DAL.Validar.ConvertirAKilo(ing.Unidad.Nombre.ToLower(), ing.Cantidad), idPlato));
            }

        }

        private void btnRegistrarProdcuccion_Click(object sender, EventArgs e)
        {
            try
            {
                produccion.FechaProd = Convert.ToDateTime(lblFecha.Text);
                produccion.IdEmpleado = Convert.ToInt32(txtIdempleado.Text);

                if (produccion.getListaDetalle().Count > 0)
                {
                    BRL.ProduccionBRL.LLenarDatosProduccion(produccion, listaProducto);
                    limpiarCamposForm();
                }
                else 
                    limpiarCamposForm();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error Sql Excepción: " + ex.Message, "Registrar Produccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Registrar Produccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiarCamposForm()
        {
            dgvPlatos.Rows.Clear();
            lblTotal.Text = "0";
            numCantidad.Value = 0;
            cmBoxPlato.SelectedIndex = 0;
            lblFecha.Text = "Fecha pedido";

            listaProducto.Clear();
            produccion.getListaDetalle().Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCamposForm();
        }

        private void PlatosCmBox()
        {
            cmBoxPlato.DataSource = BRL.PlatoBRL.Platos();
            cmBoxPlato.DisplayMember = "Nombre";
            cmBoxPlato.ValueMember = "Id";
        }

        private void llenadoComboBoxDataGridView()
        {
            DataGridViewComboBoxColumn comboboxColumn = dgvPlatos.Columns["Producto"] as DataGridViewComboBoxColumn;
            comboboxColumn.DataSource = BRL.ProductoBRL.llenaCbxProducto();
            comboboxColumn.DisplayMember = "Nombre";
            comboboxColumn.ValueMember = "Codigo";
        }

        private void celdasIngredientes()
        {
            dgvPlatos.Columns[2].CellTemplate.Style.BackColor = Color.PowderBlue;
            dgvPlatos.Columns[3].CellTemplate.Style.BackColor = Color.PowderBlue;
            dgvPlatos.Columns[4].CellTemplate.Style.BackColor = Color.PowderBlue;
            dgvPlatos.Columns[5].CellTemplate.Style.BackColor = Color.PowderBlue;

            dgvPlatos.Columns[0].CellTemplate.Style.BackColor = Color.White;
            dgvPlatos.Columns[1].CellTemplate.Style.BackColor = Color.White;
            dgvPlatos.Columns[6].CellTemplate.Style.BackColor = Color.White;
        }

        private void celdasPlato()
        {
            dgvPlatos.Columns[0].CellTemplate.Style.BackColor = Color.PaleTurquoise;
            dgvPlatos.Columns[1].CellTemplate.Style.BackColor = Color.PaleTurquoise;
            dgvPlatos.Columns[6].CellTemplate.Style.BackColor = Color.PaleTurquoise;

            dgvPlatos.Columns[2].CellTemplate.Style.BackColor = Color.White;
            dgvPlatos.Columns[3].CellTemplate.Style.BackColor = Color.White;
            dgvPlatos.Columns[4].CellTemplate.Style.BackColor = Color.PaleTurquoise;
            dgvPlatos.Columns[5].CellTemplate.Style.BackColor = Color.White;
        }

        private void numCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.Validar.NumerosDecimales(e, sender);
        }

        //eliminar plato del DataGridview
        private void EliminarPlato(int idPLato)
        { 
            for (int n = dgvPlatos.Rows.Count - 1; n >= 0; n--)
            {
                DataGridViewRow row = dgvPlatos.Rows[n];
                int valor = Convert.ToInt32(dgvPlatos.Rows[n].Cells[0].Value);

                if (valor == idPLato)
                    dgvPlatos.Rows.Remove(row); 
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvPlatos.SelectedRows[0].Cells[0].Value);
            EliminarPlato(id);

            produccion.eliminarElementoLista(id);

            //BRL.ProduccionBRL.BorrarElementosListaProducto(listaProducto, id);

            //lblTotal -= 
        }

        public void idEmpleado(int id)
        {
            txtIdempleado.Text = id.ToString();
        }
    }
}
