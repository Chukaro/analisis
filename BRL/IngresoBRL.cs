using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    public class IngresoBRL
    {
        public static void RegistraIngreso(DAL.Ingreso ingreso)
        {
            DAL.Ingreso.registraIngreso(ingreso);
        }
    }
}
