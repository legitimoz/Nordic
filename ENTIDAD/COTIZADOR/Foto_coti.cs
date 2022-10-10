using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    [Serializable]
    public class Foto_coti
    {
        public int codcabecera { get; set; }
        public string imgagenBs { get; set; }
        public string extension { get; set; }

        public string Serializar(Foto_coti obj)
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
