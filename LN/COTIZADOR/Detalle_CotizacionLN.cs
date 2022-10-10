using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DAO;

namespace LN
{
  public class Detalle_CotizacionLN
    {
        Detalle_CotizacionDAL detCotDAL = new Detalle_CotizacionDAL();

        public bool AgregarDetalleCoti(Detalle_CotizacionE detalleCot)
        {
            return detCotDAL.AgregarDetalleCot(detalleCot);
        }

        public List<Detalle_CotizacionE> ListadoDetalleCotizacion_stock_mayor_cero(int codigo_cabecera)
        {
            return detCotDAL.ListadoDetalleCotizacion_stock_mayor_cero(codigo_cabecera);
        }

        public List<Detalle_CotizacionE> ListadoDetalleCotizacionPorCabecera(int codigo_cabecera)
        {
            return detCotDAL.ListadoDetalleCotizacion_por_cabecera(codigo_cabecera);
        }

    }
}
