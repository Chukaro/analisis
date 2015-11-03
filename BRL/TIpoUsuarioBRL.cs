using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    public class TIpoUsuarioBRL
    {
        public static List<TipoUsuario> LLenarcomboTipoUsuario()
        {
            return DAL.TipoUsuario.llenarCmBoxTipoUsuario();
        }
    }
}
