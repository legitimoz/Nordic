using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DAO;

namespace LN
{
 public class CabezeraCotizacionLN
    {
        CabezeraCotizacionDAO cotizacionCab = new CabezeraCotizacionDAO();

        public List<CabeceraCotizacion> ListadoCotizaciones(string codigovendedor, string estado)
        {
            return cotizacionCab.ListadoCotizaciones(codigovendedor,estado);

        }
        public List<CabeceraCotizacion> ListadoCotizaciones_creditos_cobranzas(string codigovendedor)
        {
            return cotizacionCab.ListadoCotizaciones_creditos_cobranzas(codigovendedor);

        }
        public List<CabeceraCotizacion> ListadoCotizaciones_parametro(string codigovendedor,string fecha_inicio,string fecha_fin)
        {
            return cotizacionCab.ListadoCotizaciones_parametro(codigovendedor, fecha_inicio, fecha_fin);

        }
        public bool AgregarCabeceraCotizacion(CabeceraCotizacion cabeceraCoti)
        {
            return cotizacionCab.AgregarCabeceraCot(cabeceraCoti);
        }
        public CabeceraCotizacion CotizacionCreada(string usuario)
        {
            return cotizacionCab.CotizacionCreada(usuario);
        }
        public CabeceraCotizacion CotizacionEditarCabecera(int codigo)
        {
            return cotizacionCab.CotizacionEditarCabecera(codigo);
        }
        public bool AnularCotizacionVendedor(int codigo,char estado)
        {
            return cotizacionCab.AnularCotizacionVendedor(codigo,estado);
        }
        public bool anular_detalle_articulo(int codigo,string codarticulo)
        {
            return cotizacionCab.anular_detalle_articulo(codigo, codarticulo);
        }

        
        public bool AprobarCotizacionVendedor(int codigo, char estado,string fechaaprobacion,int idusuario)
        {
            return cotizacionCab.AprobarCotizacionVendedor(codigo, estado, fechaaprobacion,idusuario);
        }
        public bool RechazarCotizacionVendedor(int codigo, char estado)
        {
            return cotizacionCab.RechazarCotizacionVendedor(codigo, estado);
        }
        
        public bool TotalizarCotizacionVendedor(int codigo, char estado)
        {
            return cotizacionCab.TotalizarCotizacionVendedor(codigo, estado);
        }
        public bool EditarCabCtz_Vendedor(int codigo, string direccion,string formapago,string vendedor,string glosa)
        {
            return cotizacionCab.EditarCabCtz_Vendedor(codigo, direccion,formapago,vendedor,glosa);
        }

        public bool CargarImagen_Cotizacion(int codigo,string foto, string extension)
        {
            Foto_coti obj = new Foto_coti();
            String xml = String.Empty;
            try
            {
               
                obj.codcabecera = codigo;
                obj.imgagenBs = foto;
                obj.extension = extension;
                xml = obj.Serializar(obj);

                return cotizacionCab.CargarImagen_Cotizacion(xml);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Foto_coti> ListadoFotos(int codigo)
        {
            return cotizacionCab.ListadoFotos(codigo);

        }

        public bool GenerarPedido (Generar_pedido generar_pedido)
        {
            return cotizacionCab.GenerarPedido(generar_pedido);

        }

        //public ClienteSofCom BuscarClientexRuc(string ruccliente)
        //{

        //    return clienteDAL.BuscarClientexRuc(ruccliente);

        //}

    }
}
