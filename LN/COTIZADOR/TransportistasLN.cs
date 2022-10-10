using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using ENTIDAD;
namespace LN
{
    public class TransportistasLN
    {

        TransportistasDAL transportistasDAL = new TransportistasDAL();

        public List<Transportista> ListadoTransportistas()
        {
            return transportistasDAL.ListadoTransportistas();

        }
        public Transportista ObtenerTransportistaUltimaGuia(string ruccliente)
        {
            return transportistasDAL.ObtenerTransportistadeUltimaGuia(ruccliente);
        }

    }
}
