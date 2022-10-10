using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
  public class CabeceraCotizacion
    {
        public string codigo { get; set; }
        public string cliente { get; set; }
        public string direccion { get; set; }
        public string formapago { get; set; }
        public string vendedor { get; set; }
        public string moneda { get; set; }
        public string almacen { get; set; }
        public string adjunto { get; set; }
        public string fechaemision { get; set; }
        public string glosa { get; set; }
        public string fecharegistro { get; set; }
        public string usuario { get; set; }
        public string id_estado { get; set; }


        //DATOS PARA VISTAS 
        public string dato_extra { get; set; }
        public string cod_ven { get; set; }
        public string cod_for_pag { get; set; }
        public string cod_dir_ubi { get; set; }
        public int validador_stock { get; set; }
        public string total_cotizacion { get; set; }
    }
}
