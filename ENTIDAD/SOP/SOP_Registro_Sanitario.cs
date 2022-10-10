using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD.SOP
{
  public class SOP_Registro_Sanitario
    {
        public int id_rrgg { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int id_fabricante { get; set; }
        public int id_pais { get; set; }
        public int d_planta { get; set; }
        public string comercializacion { get; set; }
        public string est_codigo { get; set; }
        public string fecha_inicio { get; set; }
        public string fec_vigencia { get; set; }
        public int vida_util { get; set; }
        public int id_temperatura { get; set; }
        public int id_tipo_envase { get; set; }
        public string rrgg_competencia { get; set; }

        //para select
        public string nombre_fabricante { get; set; }
        public string nombre_pais { get; set; }

        public string des_temperatura { get; set; }
        public string des_envase { get; set; }

        


    }
}
