using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using ENTIDAD;
namespace LN
{
    public class VendedorLN
    {
        VendedorDAL vendedorDAL = new VendedorDAL();

        public List<VendedorE> ListadoVendedores(string cod_usuario)
        {
            return vendedorDAL.ListadoVendedores(cod_usuario);

        }
    }
}
