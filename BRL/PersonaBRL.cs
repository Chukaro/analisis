using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    public class PersonaBRL
    {
        public static DAL.Persona DatosCuenta(string user, string pass)
        {
            return DAL.Persona.datosCuenta(user, pass);
        }

    }
}
