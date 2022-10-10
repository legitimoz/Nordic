using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD.VIATICOS
{
    public class Via_Det_Presupuesto { 

    public int id_v_num_sol { get; set; }
    public int usr_id_logeado { get; set; }
    public double precio { get; set; }
    public int dias { get; set; }
    public int id_gasto { get; set; }
    public string icon { get; set; }

        // LEFT 
        public string nombregasto { get; set; }
public double precio_maximo { get; set; }
public string descripcion_gasto { get; set; }
    }
}
