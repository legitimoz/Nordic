using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DAO;
namespace LN
{
   public  class MonitoreoLN
    {
        MonitoreoDAO monitoreoDAO = new MonitoreoDAO();

        public List<Monitoreo> LIstadoMonitoreo()
        {
            return monitoreoDAO.lista_monitoreo();

        }

    }
}
