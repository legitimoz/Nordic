using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DAO;
namespace LN
{
    public class ClienteNuevoCotizacionLN
    {
        ClienteNuevoCotiDAL clientenuevoDAL = new ClienteNuevoCotiDAL();

        public bool AgregarClienteNuevo(ClienteNuevoCotizacion clienteNuevo)
        {
            return clientenuevoDAL.AgregarClienteNuevo(clienteNuevo);
        }
    }
}
