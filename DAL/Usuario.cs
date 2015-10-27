using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Usuario
    {
        private string usuario;
        private TipoUsuario tipo;
        private string password;

        public Usuario()
        {
            tipo = new TipoUsuario();
        }

        public String Usuario1
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public TipoUsuario Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        
    }
}
