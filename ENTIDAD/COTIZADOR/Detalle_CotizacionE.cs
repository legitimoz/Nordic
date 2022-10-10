using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Detalle_CotizacionE
    {
        public int codigo_cabecera { get; set; }
        public string codigo_articulo { get; set; }
        public string nombre_articulo { get; set; }
        public string preciodecotizacion { get; set; }
        public string stock { get; set; }
        public string uni { get; set; }
        public int cantidad_solicitada { get; set; }
        public int cantidad_disponible { get; set; }
        public string motivo { get; set; }

       
        //relase 2 -- datos de auditoria 
        public string fecha_registro_detalle { get; set; }
        public string estado_registro { get; set; }
        public int usuario_registro { get; set; }

        public decimal preciopublico { get; set; }
        public decimal preciolista { get; set; }

        public string fecha_anulacion_detalle { get; set; }
        public string estado_anulacion { get; set; }
        public int usuario_anulacion { get; set; }



        //DATOS EXTRAS para cab

        public string nombre_cliente { get; set; }
        public string ruc_cliente { get; set; }
        public string fecha_registro { get; set; }
        public string vendedor { get; set; }
        public string direccion { get; set; }
        public string forma_pago { get; set; }
        public string telefono_vendedor { get; set; }
        public string correo_vendedor { get; set; }


    }
}
