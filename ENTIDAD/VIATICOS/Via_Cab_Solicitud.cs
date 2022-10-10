using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD.VIATICOS
{
    public class Via_Cab_Solicitud
    {
        public int id_v_num_sol { get; set; }
        public int usr_id_logeado{ get; set; }
        public int usr_id_creacion { get; set; }
        public string cod_cliente { get; set; }
        public string cod_linea { get; set; }
        public string fecha_solicitud { get; set; }
        public int cod_mot_viaje { get; set; }
        public double monto_solicitado { get; set; }
        public int cod_med_viaje { get; set; }
        public string id_depart_ori { get; set; }
        public string id_prov_ori { get; set; }
        public string id_distri_ori { get; set; }
        public string fecha_origi { get; set; }
        public string id_depart_dest { get; set; }
        public string id_prov_dest { get; set; }
        public string id_distri_dest { get; set; }
        public string fecha_dest { get; set; }
        public string fecha_term_viaje { get; set; }
        public double monto_esperado { get; set; }
        public int cant_dias { get; set; }
        public string est_codigo { get; set; }

        //campos de auditoria
        public int usr_id_cre { get; set; }
        public string fec_cre { get; set; }
        public int usr_id_apro { get; set; }
        public string fec_apro { get; set; }
        public int usr_id_anul{ get; set; }
        public string fec_anul { get; set; }
        public int usr_id_mod{ get; set; }
        public string fec_mod { get; set; }



        //campos extra para Mostrar Left Join

        public string Nombrelinea { get; set; } 
        public string NombreMotivoViaje { get; set; }
        public string NombreMedioViaje { get; set; }

        public string NombreUsuario { get; set; }
        public string motivoanulacion { get; set; }

    }
}
