using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD.VIATICOS
{
    public class Via_Det_Con_Gastos
    {
        public int vdcg_id { get; set; }
        public int vcs_id { get; set; }
        public int vcg_id { get; set; }
        public double vdcg_precio_lista { get; set; }
        public double vdcg_precio_propuesto { get; set; }
        public string vdcg_fechacomprobante { get; set; }
        public string vdcg_numcomprobante { get; set; }
        public string vdcg_rucproveedor { get; set; }
        public string vdcg_razonsocial { get; set; }
        public string vdcg_punto_partida { get; set; }
        public string vdcg_punto_llegada { get; set; }
        public int cod_med_viaje { get; set; }
        public string foto { get; set; }
        public string vdcg_fec_crea { get; set; }
        public int vdcg_usrid_crea { get; set; }
        public string vdcg_fec_mod { get; set; }
        public int vdcg_usrid_mod { get; set; }
        public string vdcg_tipo_comprobante { get; set; }
        public string vdcg_serie{ get; set; }
        ///datos pra select left join
        public string nombremedioviaje { get; set; }

        public string nombreconceptopgasto { get; set; }
        public string vcg_cnt_conta { get; set; }
        

        public string Serializar(Via_Det_Con_Gastos obj)
        {
            StringWriter _oStringWriter;
            string _listaSerializada = string.Empty;
            System.Xml.Serialization.XmlSerializer _oSerialization;
            try
            {
                _oStringWriter = new StringWriter();
                _oSerialization = new System.Xml.Serialization.XmlSerializer(obj.GetType());
                _oSerialization.Serialize(_oStringWriter, obj);
                _listaSerializada = _oStringWriter.ToString();
                return _listaSerializada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
