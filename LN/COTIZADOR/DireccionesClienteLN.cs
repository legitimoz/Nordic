using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DAO;

namespace LN
{
   public class DireccionesClienteLN
    {
        ClienteDireccionDAL direcionesClienteDAL = new ClienteDireccionDAL();

        public List<DireccionesCliente> ListadoClienteDirecciones(string ruccliente)
        {
            return direcionesClienteDAL.ListadoClientesDirecciones(ruccliente);

        }


    }
}
