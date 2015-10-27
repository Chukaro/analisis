using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
   public class ProveedorBRL
    {
       public static void Insertar(DAL.Proveedor pro)
       {
           DAL.Proveedor.registraProveedor(pro);
       }
    }
}
