using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Data.SqlClient;

namespace TiendaAlmacen
{
    public partial class IngresoEmpleado : UserControl
    {
        public IngresoEmpleado()
        {
            this.Dock = DockStyle.Fill;

            InitializeComponent();
            TipoUsuarioCmBox();
            comboBoxTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {

                int tipo = (int)comboBoxTipoUsuario.SelectedValue;
                if (!DAL.Validar.validarTxtBox(panel1) && tipo != 0)
                {
                    btnGuardar.Enabled = true;

                    Empleado pro = new Empleado();
                    pro.Nombre = txtNombre.Text;
                    pro.ApPat = txtApellidoPat.Text;
                    pro.ApMat = txtApellidoMat.Text;
                    pro.Direccion = txtDireccion.Text;
                    pro.Telefono = Int32.Parse(txtTelefono.Text);
                    pro.Carnet = Int32.Parse(txtCarnet.Text);

                    pro.Sesion.Nombre = txtUsuario.Text;
                    pro.Sesion.Password = txtContraseña.Text;
                    pro.Sesion.IdTipoUsuario = Convert.ToInt32(comboBoxTipoUsuario.SelectedValue);

                    BRL.EmpleadoBRL.Insertar(pro);
                    MessageBox.Show("Empleado Registrado");
                    limpiar();

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

        private void TipoUsuarioCmBox()
        {
            comboBoxTipoUsuario.DataSource = BRL.TIpoUsuarioBRL.LLenarcomboTipoUsuario();
            comboBoxTipoUsuario.DisplayMember = "Nombre";
            comboBoxTipoUsuario.ValueMember = "Id";
        }
        private void limpiar()
        {
            txtNombre.Clear();
            txtApellidoPat.Clear();
            txtApellidoMat.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCarnet.Clear();
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtConfirmar.Clear();
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            string con1 = txtContraseña.Text;
            string con2 = txtConfirmar.Text;
            if (CompararContraseña(con1, con2))
                btnGuardar.Enabled = true;
            else
                btnGuardar.Enabled = false;
        }

        private void txtConfirmar_Leave(object sender, EventArgs e)
        {
            string con1 = txtContraseña.Text;
            string con2 = txtConfirmar.Text;
            if (CompararContraseña(con1, con2))
                btnGuardar.Enabled = true;
            else
                btnGuardar.Enabled = false;
        }

        private bool CompararContraseña(string con1, string con2)
        {
            return (con1.CompareTo(con2) == 0) ? true : false;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.Validar.SoloNumeros(e);
            
        }

        private void txtCarnet_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.Validar.SoloNumeros(e);

        }
    }
}
