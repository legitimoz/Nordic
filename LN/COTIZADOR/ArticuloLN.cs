using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DAO;
namespace LN
{
   public class ArticuloLN
    {

        ArticuloDAL articuloDAL = new ArticuloDAL();

        public List<Articulo> ListadoArticulo(string stock)
        {
            return articuloDAL.ListadoArticulos(stock);

        }
       
        public List<Articulo> ListademodelosArticulo()
        {
            return articuloDAL.ListademodelosArticulo();

        }
        
        public Articulo ObtenerArticulo(string codigo)
        {
            return articuloDAL.ObtenerArticulo(codigo);

        }
        
        public List<Articulo> ObtenerArticuloparaSelect(string codigo)
        {
            return articuloDAL.ObtenerArticuloParaSelect(codigo);

        }

        public List<Articulo> ListadoArticulosFiltrados(string codigo,string descripcion,string almacen,string modelo)
        {
            return articuloDAL.ListadoArticulosFiltrados(codigo,descripcion,almacen,modelo);
        }



    }
}
