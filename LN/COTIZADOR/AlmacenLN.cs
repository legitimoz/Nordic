using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DAO;

namespace LN
{
   public class AlmacenLN
    {
        AlmacenDAL almacenDAL = new AlmacenDAL();

        public List<Almacen> ListadoAlmacenes()
        {
            return almacenDAL.ListadoAlmacenes();

        }
        // cambios de muestra

    }
}
