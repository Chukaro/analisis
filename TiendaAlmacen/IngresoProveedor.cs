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
    public partial class IngresoProveedor : UserControl
    {
        public IngresoProveedor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DAL.Proveedor pro = new DAL.Proveedor();
            pro.Nombre = txtNombre.Text;
            pro.ApPat = txtApellidoPat.Text;
            pro.ApMat = txtApellidoMat.Text;
            pro.Direccion = txtDireccion.Text;
            pro.Telefono = Int32.Parse(txtTelefono.Text);
            pro.Carnet = Int32.Parse(txtCarnet.Text);

            BRL.ProveedorBRL.Insertar(pro);

        }
    }
}
