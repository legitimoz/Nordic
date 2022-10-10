using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD.VIATICOS
{
    public class ConceptopGasto
    {
        public int vcg_id { get; set; }
        public string vcg_nombre { get; set; }
        public string vcg_descripcion { get; set; }
        public string vcg_icon { get; set; }
        public double vcg_preciolista { get; set; }
        public double vcg_preciomaximo { get; set; }
        public string est_codigo { get; set; }
        public string vcg_cnt_conta {get;set;}
        public int vcg_idperfil { get; set; }
        public int vcg_tipo { get; set; }

    }
}
