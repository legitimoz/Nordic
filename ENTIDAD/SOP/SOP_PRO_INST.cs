using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD.SOP
{
   public class SOP_PRO_INST
    {


        public List<SOP_Registro_Proy_Institucional> ListaCarga_Institucional { get; set; }

        public string Serializar(SOP_PRO_INST obj)
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
