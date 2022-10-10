using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DAO;
namespace LN
{
   public class StockLN
    {
        StockDAL stockDAL = new StockDAL();

        public Stock ObtenerStock(string articulo,string almacen)
        {

            return stockDAL.ObtenerStock(articulo, almacen);

        }
    }
}
