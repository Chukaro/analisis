using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaAlmacen
{
    public partial class NuevoProducto : Form
    {
        public NuevoProducto()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            ClasificacionCmBox();
            TipoAlimentoCmBox();
            UnidadAlimento(); 
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                int c = (int)cmBoxClasificacion.SelectedValue;
                int t = (int)cmBoxTipo.SelectedValue;
                int u = (int)cmBoxUnidad.SelectedValue;

                if (!DAL.Validar.validarTxtBox(panel1) && c != 0 && t !=0 && u != 0)
                {
                    btnIngreso.Enabled = true;
                    DAL.Producto ingreso = new DAL.Producto();

                    //ingreso.Codigo = txtCodigo.Text;
                    ingreso.Nombre = txtNombre.Text.ToUpper();
                    ingreso.Stock = Convert.ToInt32(numCantidad.Value);
                    ingreso.PrecioVenta = Convert.ToDecimal(txtPrecio.Text);
                    ingreso.Clasificacion.Codigo = Convert.ToInt32(cmBoxClasificacion.SelectedValue);
                    ingreso.Tipo.Codigo = Convert.ToInt32(cmBoxTipo.SelectedValue);
                    ingreso.Unidad.Id = Convert.ToInt32(cmBoxUnidad.SelectedValue);

                    BRL.ProductoBRL.RegistraProducto(ingreso);
                    this.Close();
                    //MessageBox.Show(cmBoxClasificacion.SelectedValue + "   " + cmBoxTipo.SelectedValue, "Error");
                }
                else
                {
                    MessageBox.Show("Campos requeridos vacios", "ERROR");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Errror", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClasificacionCmBox()
        {
            cmBoxClasificacion.DataSource = BRL.ClasificacionBRL.LLenarCmBoxClasificacion();
            cmBoxClasificacion.DisplayMember = "Tipo";
            cmBoxClasificacion.ValueMember = "Codigo";
        }

        private void TipoAlimentoCmBox()
        {
            cmBoxTipo.DataSource = BRL.TipoAlimentoBRL.LLenarCmBoxTipoAlimento();
            cmBoxTipo.DisplayMember = "Tipo";
            cmBoxTipo.ValueMember = "Codigo";
        }

        private void UnidadAlimento()
        {
            cmBoxUnidad.DataSource = BRL.UnidadBRL.LLenarCmBoxUnidad();
            cmBoxUnidad.DisplayMember = "Nombre";
            cmBoxUnidad.ValueMember = "Id";
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.Validar.NumerosDecimales(e, sender);
        }

        private void numCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.Validar.NumerosDecimales(e, sender);
        }
    }
}
