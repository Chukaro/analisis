using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DAL
{
    public class Validar
    {
        public static void SoloNumeros(KeyPressEventArgs pE)
        {
            if (char.IsDigit(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (char.IsControl(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else
            {
                pE.Handled = true;
            }
        }


        public static void NumerosDecimales(KeyPressEventArgs pE, object sender)
        {
            if (Char.IsDigit(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsControl(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsPunctuation(pE.KeyChar))
            {
                pE.Handled = false;
            }
                       else
            {
                pE.Handled = true;
            }

            if ((pE.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                pE.Handled = true;
            }

            if ((pE.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                pE.Handled = true;
            }

            if (pE.KeyChar == '-')
            {
                pE.Handled = true;
            }
        }

        public void vacioTexBox(TextBox entrada, ErrorProvider error)
        {
            if (string.IsNullOrWhiteSpace(entrada.Text))
            {
                error.SetError(entrada, "CAMPO REQUERIDO");
            }
            else { error.Clear(); }
        }

        public static bool validarTxtBox(Panel panel)
        {
            bool dev = false;
            foreach (Control oControls in panel.Controls)
            {
                if (oControls is TextBox & oControls.Text == String.Empty)
                {
                    dev = true;
                }
            }

            return dev;
        }

        public static float ConvertirAKilo(string opcion, float cantidad) 
        {
            float convertido = 0;

            switch (opcion)
            {
                case "gramo":
                    convertido = cantidad / 1000;
                    break;

                case "libra":
                    convertido = (float) (cantidad / 2.2046);
                    break;

                case "mililitro":
                    convertido = (float)(cantidad / 1000);
                    break;
                
                default:
                    convertido = cantidad;
                    break;
            }
            return convertido;
        }
    }
}
