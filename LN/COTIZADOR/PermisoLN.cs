using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using ENTIDAD;
namespace LN
{
    public class PermisoLN
    {
        PermisoDAL permisosDAL = new PermisoDAL();

        public List<Permisos> ListadoPermisos(int idperfil, int idusuario)
        {
            return permisosDAL.ListadoPermisos_usuario(idperfil,idusuario);

        }
    }
}
