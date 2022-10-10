using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD.SOP
{
   public class SOP_Embarque

    {
    public int id_emb     { get; set; } 
    public string cod_emb { get; set; }
    public int lugar_emb { get; set; }
    public int agent_carga_naviera { get; set; }
    public string est_emb { get; set; }
    public int tipo_carga { get; set; }
    public string fec_emb_req { get; set; }
    public string fec_lleg_req { get; set; }
    public string fec_emb_real { get; set; }
    public string fec_arribo_real { get; set; }
    public string fec_nordic_real { get; set; }
    public string fec_entrega_ent { get; set; }
    public int id_via_viaje { get; set; }
    public string fecha_vct_flete { get; set; }
    public string est_flete { get; set; }
    public double precio_flete { get; set; }
    public string fecha_vct_seguro { get; set; }
    public string est_seguro { get; set; }
    public double precio_seguro { get; set; }
    public int usr_id_creacion { get; set; }

        //PRUEBA 
   public string HousebillNumber { get; set; }
   public string Shipment       { get; set; }
    }
}
