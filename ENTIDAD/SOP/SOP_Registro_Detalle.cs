using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD.SOP
{
    public class SOP_Registro_Detalle
    {

        public int id_pro_pri { get; set; }
        public string codigo_registro { get; set; }
        public string codigo_articulo { get; set; }

       

        public string mes_1 { get; set; }
        public string mes_2 { get; set; }
        public string mes_3 { get; set; }
        public string mes_4 { get; set; }
        public string mes_5 { get; set; }
        public string mes_6 { get; set; }
        public string mes_7 { get; set; }
        public string mes_8 { get; set; }
        public string mes_9 { get; set; }
        public string mes_10 { get; set; }
        public string mes_11 { get; set; }
        public string mes_12 { get; set; }

        public string anio_1 { get; set; }
        public string anio_12 { get; set; }
        public decimal valor_enero { get; set; }
        public string Mes_anio_2 { get; set; }
        public decimal valor_febrero { get; set; }
        public string Mes_anio_3 { get; set; }
        public decimal valor_marzo { get; set; }
        public string Mes_anio_4 { get; set; }
        public decimal valor_abril { get; set; }
        public decimal valor_mayo { get; set; }
        public decimal valor_junio { get; set; }
        public decimal valor_julio { get; set; }
        public decimal valor_agosto { get; set; }
        public decimal valor_setiembre { get; set; }
        public decimal valor_octubre { get; set; }
        public decimal valor_noviembre { get; set; }
        public decimal valor_diciembre { get; set; }
        public decimal valor_total { get; set; }
        public decimal fecha_ano { get; set; }

        public DateTime fecha_registro { get; set; }

        public int usr_id { get; set; }
    }
}
