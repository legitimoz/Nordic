using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD.SOP
{
    public class SOP_Registro_Proy_Institucional
    {
        public int     id_pro_institucional         { get; set; }
        public string  proceso                      { get; set; }
        public string  entidad                      { get; set; }
        public string  codigo_articulo              { get; set; }
        public decimal cantidad_total               { get; set; }
        public decimal precio                       { get; set; }
        public decimal importe                      { get; set; }
        public decimal plazo_entrega                { get; set; }
        public decimal num_total_entregas           { get; set; }
        public decimal num_controles                { get; set; }
        public string estatus_buena_pro            { get; set; }
        public decimal importe_pendiente_facturar   { get; set; }
        public decimal pendiente_entregar_unidad    { get; set; }
        public decimal pendiente_entregar_cajas     { get; set; }
        public decimal pendiente_atencion_porcentaje { get; set; }
        public decimal mes_1                        { get; set; }
        public decimal mes_2                        { get; set; }
        public decimal mes_3                        { get; set; }
        public decimal mes_4                        { get; set; }
        public decimal mes_5                        { get; set; }
        public decimal mes_6                        { get; set; }
        public decimal mes_7                        { get; set; }
        public decimal mes_8                        { get; set; }
        public decimal mes_9                        { get; set; }
        public decimal mes_10                       { get; set; }
        public decimal mes_11                       { get; set; }
        public decimal mes_12                       { get; set; }

    }
}
