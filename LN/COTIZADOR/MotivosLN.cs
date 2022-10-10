using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using ENTIDAD;

namespace LN
{
   public class MotivosLN
    {
        MotivoDAL motivoDAL = new MotivoDAL();

        public List<Motivo> ListadoMotivos()
        {
            return motivoDAL.ListadoMotivos();

        }
    }
}
