using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaAlmacen
{
    public partial class ModificarProducto : Form
    {
        public ModificarProducto()
        {
            InitializeComponent();
            BuscarTipoAlimentoCmBox();
            BuscarClasificacionCmBox();
            UnidadAlimento();
        }



        public void LlenarCampo(string id)
        {
            DAL.Producto prod = BRL.ProductoBRL.DevolverProducto(id);

            txtid.Text = prod.Codigo.ToString();
            txtNombre.Text = prod.Nombre;
            txtPrecio.Text = prod.PrecioVenta.ToString();
            numCantidad.Value = (decimal)prod.Stock;

            //para los combox llenar con el valor de DB
            cmBoxClasificacion.SelectedIndex = prod.Clasificacion.Codigo;
            cmBoxTipo.SelectedIndex = prod.Tipo.Codigo;
            cmBoxUnidad.SelectedIndex = prod.Unidad.Id;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuscarClasificacionCmBox()
        {
            cmBoxClasificacion.DataSource = BRL.ClasificacionBRL.LLenarCmBoxClasificacion();
            cmBoxClasificacion.DisplayMember = "Tipo";
            cmBoxClasificacion.ValueMember = "Codigo";
        }

        private void BuscarTipoAlimentoCmBox()
        {
            cmBoxTipo.Text = "Seleccione tipo de alimento";
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

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.Validar.SoloNumeros(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.Validar.validarSoloLetras(sender, e);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DAL.Producto actualizar = new DAL.Producto();


            actualizar.Codigo = Convert.ToInt32(txtid.Text);
            actualizar.Nombre = txtNombre.Text;
            actualizar.Tipo.Codigo = Convert.ToInt32(cmBoxTipo.SelectedValue);
            actualizar.Clasificacion.Codigo = Convert.ToInt32(cmBoxClasificacion.SelectedValue);
            actualizar.Stock = Convert.ToInt32(numCantidad.Value);
            actualizar.PrecioVenta = Convert.ToDecimal(txtPrecio.Text);
            actualizar.Unidad.Id = Convert.ToInt32(cmBoxUnidad.SelectedValue);

            BRL.ProductoBRL.ActualizarProducto(actualizar);
            Buscar.form.buscar();
            this.Close();
        }
    }
}
