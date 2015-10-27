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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            String usuario = txtUSer.Text;
            String password = txtPass.Text;

            DAL.Persona persona = BRL.PersonaBRL.DatosCuenta(usuario, password);


            if (persona.IdPersona > 0 && persona.Nombre.Length > 0)
            {
                //MessageBox.Show("Valor de recuperacion  " + usuario +"   "+password );
                Form1 mostrar = new Form1(persona);
                mostrar.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Usuario no existe", "ERROR DE USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
