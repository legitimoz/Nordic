using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DAO;
namespace LN
{
    public class FormaVentaLN
    {
        FormaVentaDAL formaventaDAL = new FormaVentaDAL();

        public List<FormaVenta> ListadoFormasVenta(int ruc_cliente)
        {
            return formaventaDAL.ListaFormaVenta(ruc_cliente);

        }
    }
}
