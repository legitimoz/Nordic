using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
   public class ClienteNuevoCotizacion
    {
        public string ruc { get; set; }
        public string razonsocial { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string corrreo { get; set; }
        public string vendedor { get; set; }
        public string tipocliente { get; set; }
        public int cod_usuario { get; set; }
        public string fecha_registro { get; set; }
    }
}
