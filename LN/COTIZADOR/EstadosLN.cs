using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using ENTIDAD;
namespace LN
{
   public class EstadosLN
    {
        EstadosDAL estadosDAL = new EstadosDAL();

        public List<EstadoE> ListadoEstados()
        {
            return estadosDAL.ListadoEstados();

        }
    }
}
