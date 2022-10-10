using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
        public class Articulo
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string unidad  { get; set; }
        public string preciouno { get; set; }
        public string preciodos { get; set; }
        public string preciotres { get; set; }
        public string preciocuatro { get; set; }
        public string stock { get; set; }
        public string cantidad_solicitada{ get; set; }
        public string cantidad_disponible { get; set; }

        public string modelos { get; set; }
        public string cod_modelos { get; set; }


    }
}
