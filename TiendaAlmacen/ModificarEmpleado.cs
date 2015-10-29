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
    public partial class ModificarEmpleado : Form
    {
        public ModificarEmpleado()
        {
            InitializeComponent();
        }

        public void LlenarCampo(int id)
        {
            DAL.Usuario user = BRL.UsuarioBRL.DevolverUsuario(id);

            txtid.Text = Convert.ToString(user.Id);
            txtNombre.Text = user.Nombre;
            pwActual.Text = user.Password;

            idPersona.Text = Convert.ToString(user.Idpersona);
            DAL.Usuario persona = BRL.UsuarioBRL.DevolverPersona(Convert.ToInt32(idPersona.Text));
            apPaterno.Text = persona.Appaterno;
            apMaterno.Text = persona.Apmaterno;
            direccion.Text = persona.Direccion;
            telefono.Text = Convert.ToString(persona.Telefono);
            carnet.Text = Convert.ToString(persona.Carnet);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (pwActual.Text == pwActual1.Text)
            {
                DAL.Usuario actualizar = new DAL.Usuario();
                if (pwNueva.Text == "")
                {
                    pwNueva.Text = pwActual.Text;
                }
                actualizar.Id = Convert.ToInt32(txtid.Text);
                actualizar.Nombre = txtNombre.Text;
                actualizar.Password = pwNueva.Text;

                BRL.UsuarioBRL.ActualizarUsuario(actualizar);
                MessageBox.Show("Datos de usuario actualizado.");
                this.Close();
            }
            else
            {
                if (pwActual1.Text == "")
                {
                    MessageBox.Show("Es necesaeio que ingrese su contrasena actual para modificar.");
                }
                else
                {
                    MessageBox.Show("La contrasena que ingresada no coincide.");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (pwActual.Text == pwActual1.Text)
            {
                DAL.Usuario actualizar = new DAL.Usuario();
                if (pwNueva.Text == "")
                {
                    pwNueva.Text = pwActual.Text;
                }
                actualizar.Id = Convert.ToInt32(txtid.Text);
                actualizar.Nombre = txtNombre.Text;
                actualizar.Password = pwNueva.Text;

                BRL.UsuarioBRL.ActualizarUsuario(actualizar);

                DAL.Usuario update = new DAL.Usuario();

                update.Idpersona = Convert.ToInt32(idPersona.Text);
                update.Appaterno = apPaterno.Text;
                update.Apmaterno = apMaterno.Text;
                update.Direccion = direccion.Text;
                update.Telefono = Convert.ToInt32(telefono.Text);
                update.Carnet = Convert.ToInt32(carnet.Text);

                BRL.UsuarioBRL.ActualizarPersona(update);
                MessageBox.Show("Datos de usuario actualizado.");
                this.Close();
            }
            else
            {
                if (pwActual1.Text == "")
                {
                    MessageBox.Show("Es necesaeio que ingrese su contrasena actual para modificar.");
                }
                else
                {
                    MessageBox.Show("La contrasena que ingresada no coincide.");
                }
            }
        }
    }
}
