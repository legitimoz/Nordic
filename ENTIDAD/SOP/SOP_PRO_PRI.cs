using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD.SOP
{
    public class SOP_PRO_PRI
    {
       public List<SOP_Registro_Detalle>  ListaCarga { get; set; }

        public string Serializar(SOP_PRO_PRI obj)
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
