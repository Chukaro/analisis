using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    public class TipoAlimentoBRL
    {
        public static List<DAL.TipoAlimento> LLenarCmBoxTipoAlimento()
        {
            return DAL.TipoAlimento.llenarCmBoxTipoAlimento();
        }
    }
}
