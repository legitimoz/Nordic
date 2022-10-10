using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
   public class DocumentosVencidosCliente
    {
        public string tipo_documento { get; set; }
        public string numero_documento { get; set; }
        public string vendedor { get; set; }
        public string fecha_emision { get; set; }
        public string fecha_vencimiento { get; set; }
        public string fecha_cancelacion { get; set; }
        public string motivo { get; set; }
        public string importe { get; set; }
        public string saldo { get; set; }
        public string vencimiento { get; set; }
        public string tdr { get; set; }
        public string numero_doc_referencia { get; set; }
    }
}
