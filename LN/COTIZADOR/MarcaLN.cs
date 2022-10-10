using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DAO;

namespace LN
{
    public class MarcaLN
    {
        MarcasDAL marcasDAL = new MarcasDAL();

        public List<Marcas> ListadoMarcas()
        {
            return marcasDAL.ListadoMarcas();

        }

    }
}
