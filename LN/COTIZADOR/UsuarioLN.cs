using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DAO;

namespace LN
{
    public class UsuarioLN
    {
        UsuarioDAL usuarioDAL = new UsuarioDAL();
        public Usuario ObtenerUsuario(string alias, string codigo)
        {
            return usuarioDAL.ObtenerUsuario(alias,codigo);
        }
    }
}
