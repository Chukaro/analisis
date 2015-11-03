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
    public partial class buscarEmpleado : UserControl
    {
        public static buscarEmpleado form;
        public buscarEmpleado()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            TipoUsuarioCmBox();
            cmBoxBuscarTipoEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ModificarEmpleado fr1 = new ModificarEmpleado();
            fr1.LlenarCampo(3);
            fr1.ShowDialog();
        }

        private void TipoUsuarioCmBox()
        {
            cmBoxBuscarTipoEmpleado.DataSource = BRL.TIpoUsuarioBRL.LLenarcomboTipoUsuario();
            cmBoxBuscarTipoEmpleado.DisplayMember = "Nombre";
            cmBoxBuscarTipoEmpleado.ValueMember = "Id";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resul = MessageBox.Show("Seguro que quiere eliminar el Registro?", "Eliminar Registro", MessageBoxButtons.YesNo);
            if (resul == DialogResult.Yes)
            {
                DAL.Usuario user = BRL.UsuarioBRL.EliminarUsuario(5);
            }
        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarEmpleado.Text;
            int idClasificacion = Convert.ToInt32(cmBoxBuscarTipoEmpleado.SelectedValue);

            //MessageBox.Show(nombre +"  "+ idTipo +"  "+ idClasificacion,"Prueba");

            dataGridViewBuscarEmpleado.DataSource = BRL.EmpleadoBRL.Empleado(nombre, idClasificacion);
            txtBuscarEmpleado.Clear();

        }

    }
}
