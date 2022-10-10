using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Usuario
    {
       public int idempresa  {get;set;}
       public int idusuario { get; set; }
       public char estado { get; set; }
       public string alias { get; set; }
        public string nombre_usuario { get; set; }
        public string clave { get; set; }
        public int perfil { get; set; }
    }
}
