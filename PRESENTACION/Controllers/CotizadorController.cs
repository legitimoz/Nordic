using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//using System.Web.Services;
using System.Web.Script.Serialization;
using ENTIDAD;
using LN;
using System.IO;
using System.Net;

namespace PRESENTACION.Controllers
{
    public class CotizadorController : Controller
    {
        ClienteSofconLN clienteLN = new ClienteSofconLN();
        AlmacenLN almacenLN = new AlmacenLN();
        VendedorLN vendedoresLN = new VendedorLN();
        FormaVentaLN formaventaLN = new FormaVentaLN();
        ArticuloLN articuloLN = new ArticuloLN();
        TransportistasLN transportistasLN = new TransportistasLN();
        StockLN stockLN = new StockLN();
        CabezeraCotizacionLN cabCoti = new CabezeraCotizacionLN();
        Detalle_CotizacionLN detCotiLN = new Detalle_CotizacionLN();
        DireccionesClienteLN direClientesLN = new DireccionesClienteLN();  
        MotivosLN motivosLN = new MotivosLN();
        ClienteNuevoCotizacionLN clientenuevoLN = new ClienteNuevoCotizacionLN();
        EstadosLN estadosLN= new EstadosLN();
        DetalleFinancieroClienteLN dt_fnz_cli_LN = new DetalleFinancieroClienteLN();
        MonitoreoLN monitoreoLN = new MonitoreoLN();
        CabeceraCotizacion a;
        string parametro23="";

        //prueba de stock para articulo
        //string stock;

        // GET: Cotizador
       //OBJETO PARA AUTORIZAR 
       //[Authorize]
        public ActionResult Index(string parametro)
        {
            if (Session["ID_USUARIO"] != null)
            {
                ViewBag.clienteDataTable = clienteLN.ListadoClientesconDataTable();
                ViewBag.cliente = clienteLN.ListadoClientes();
                ViewBag.Almacen = almacenLN.ListadoAlmacenes();
                //listado de forma de ventas completo
             // ViewBag.formaventa = formaventaLN.ListadoFormasVenta("12345455");
                ViewBag.articulo = articuloLN.ListadoArticulo("");
                ViewBag.vendedor = vendedoresLN.ListadoVendedores(Session["ID_USUARIO"].ToString());
                ViewBag.transportista=transportistasLN.ListadoTransportistas();
            }
            else{
                ViewBag.vendedor = vendedoresLN.ListadoVendedores("");

            }


           
            //ViewBag.direcciones=direClientesLN.ListadoClienteDirecciones("");
            // ViewBag.stock = stockLN.ListadoArticulo();
            return View();
        }

        public JsonResult ListadoFormaVenta(int ruccliente)
        {
            return Json(formaventaLN.ListadoFormasVenta(ruccliente));
        } 

        public JsonResult ObtenerTransportistaUltimaGuia(string ruccliente)
        {
            return Json(transportistasLN.ObtenerTransportistaUltimaGuia(ruccliente));
        }
        public ActionResult Monitoreo()
        {
            //if (Session["ID_USUARIO"] != null)
            //{
               
                
            //}
            //else
            //{
               

            //}

            return View();
        }
        public JsonResult ListarCotizacionesMonitoreo()
        {
            return Json(monitoreoLN.LIstadoMonitoreo());
        }  

        public JsonResult Variable_sesion(int cod, string nombre)
        {
            //FGB: ajax usr id
            Session["id_usuario_logeado"] = cod;
            Session["nombre_usuario_logeado"] = nombre;
            return Json(cod);
        }

        public ActionResult CerrarSesion()
        {
           
            
            Session.Remove("PERFIL_USUARIO");
            Session.Remove("ID_USUARIO");
            Session.Remove("nombre_usuario_logeado");
            Session.Remove("id_usuario_logeado");
            Session.Remove("nombre_usuario_logeado");
            Session.Remove("URL");
            Session.Contents.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Index");
        }
        public ActionResult CrearCotizacion()
        {
           // FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Cotizador");
        }

        [Authorize]
        public ActionResult CotizacionCreada(string usuario)
        {
            // tiene que traer la otizacion y ademas poner los datos deshabilitados
            // ViewBag.cliente = clienteLN.ListadoClientes();
            // ViewBag.Almacen = almacenLN.ListadoAlmacenes();
            ViewBag.modelosarticulo = articuloLN.ListademodelosArticulo();
            ViewBag.Cabecera = cabCoti.CotizacionCreada(Session["id_usuario_logeado"].ToString());
            //ViewBag.Cabecera = cabCoti.CotizacionCreada(usuario);
            //colocar variable extra para tener el codigo almacen  
            //= new CabeceraCotizacion ();
            a = cabCoti.CotizacionCreada(Session["id_usuario_logeado"].ToString());
            if (a.glosa==null)
            {
                ViewBag.articulo = articuloLN.ListadoArticulo("0000");
            }
            else
            {
                Session["ALMACEN_DE_CTZ_CREADA"] = a.glosa;
                ViewBag.articulo = articuloLN.ListadoArticulo(a.glosa);
            }
            //return Json(cabCoti.CotizacionCreada(usuario), JsonRequestBehavior.AllowGet);
            return View();
        }

        [Authorize]
        public ActionResult ListarClientes()
        {
            //prueba 
  //          ViewBag.cliente = clienteLN.ListadoClientesconDataTable();
//            ViewBag.Almacen = almacenLN.ListadoAlmacenes();
            return View(clienteLN.ListadoClientesconDataTable());
        }
        public JsonResult ListarDireccionesCliente(string ruccliente)
        {
            //REALIZANDO 
            //detCoti.AgregarDetalleCotizacion(), JsonRequestBehavior.AllowGet;
            
            return Json(direClientesLN.ListadoClienteDirecciones(ruccliente));
        }
        public JsonResult AgregarClienteNuevo(string ruccliente,string razonsocial,string direccion ,string telefono,string correo, string vendedor)
        {
            //REALIZANDO 
            //detCoti.AgregarDetalleCotizacion(), JsonRequestBehavior.AllowGet;
            ClienteNuevoCotizacion clienteNuevo = new ClienteNuevoCotizacion();
            clienteNuevo.ruc =ruccliente;
            clienteNuevo.razonsocial = razonsocial;
            clienteNuevo.direccion = direccion;
            clienteNuevo.telefono = telefono;
            clienteNuevo.corrreo = correo;
            clienteNuevo.vendedor = "ERR";
            clienteNuevo.tipocliente = "C01";
            clienteNuevo.cod_usuario = Int32.Parse("1");
            clienteNuevo.fecha_registro = "2022-05-25 11:15:53.980";

            return Json(clientenuevoLN.AgregarClienteNuevo(clienteNuevo), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerDetalleFinanciero(string ruccliente)
        {
            return Json(dt_fnz_cli_LN.ObtenerDetalleFinanciero(ruccliente));
        }
        public JsonResult ListaDocumentosPendientes(string ruccliente)
        {
            return Json(dt_fnz_cli_LN.ListaDocumentosPendientes(ruccliente));
        }
        public JsonResult ListadoMotivos()
        {
           return Json(motivosLN.ListadoMotivos());
        }

        public JsonResult ListarEstados()
        {
            return Json(estadosLN.ListadoEstados());
        }

        public JsonResult AnularCotiVendedor(int codigo, char estado)
        {
            return Json(cabCoti.AnularCotizacionVendedor(codigo,estado));
        }

        public JsonResult AprobarCotiVendedor(int codigo, char estado, int idusuario)
        {
            DateTime dt1 = DateTime.Now;
            string fechaaprobacion = Convert.ToString(dt1);
            //int idusuario = Convert.ToInt32(Session["id_usuario_logeado"].ToString());
           //int idusuario = idusuario
            return Json(cabCoti.AprobarCotizacionVendedor(codigo, estado,fechaaprobacion , idusuario));
        }
        public JsonResult TotalizarCotiVendedor(int codigo, char estado)
        {
            return Json(cabCoti.AnularCotizacionVendedor(codigo, estado));
        }

        public JsonResult AgregarDetalleCoti(string codigo_articulo,string nombre_articulo,string uni,string preciocotizacion,string cantidad_solicitada,string cantidad_disponible,string stock,string motivo,string codigo_cabecera)
        {
            DateTime dt1 = DateTime.Now;
            Detalle_CotizacionE detCotE = new Detalle_CotizacionE();
            detCotE.codigo_cabecera = Int32.Parse(codigo_cabecera);
            detCotE.codigo_articulo = codigo_articulo;
            detCotE.nombre_articulo = nombre_articulo;
            detCotE.preciodecotizacion = preciocotizacion;
            detCotE.stock = stock;
            detCotE.uni = uni;
            detCotE.cantidad_solicitada = Int32.Parse(cantidad_solicitada);
            detCotE.cantidad_disponible = Int32.Parse(cantidad_disponible);
            detCotE.motivo = motivo;
            //release 2  datos de auditoria

            detCotE.fecha_registro_detalle= Convert.ToString(dt1);

            detCotE.estado_registro = "6";
            detCotE.usuario_registro = Convert.ToInt32(Session["id_usuario_logeado"].ToString());

            detCotE.preciopublico = Convert.ToDecimal(preciocotizacion);
            detCotE.preciolista = Convert.ToDecimal(preciocotizacion);


            return Json(detCotiLN.AgregarDetalleCoti(detCotE),JsonRequestBehavior.AllowGet);
        }

        public JsonResult Buscar(string ruccliente)
        {

            return Json(clienteLN.BuscarClientexRuc(ruccliente), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerArticulo(string codigo)
        {

            return Json(articuloLN.ObtenerArticulo(codigo), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerArticuloparaSelect(string codigo)
        {

            return Json(articuloLN.ObtenerArticuloparaSelect(codigo), JsonRequestBehavior.AllowGet);
        }
        public JsonResult OnbtenerStockArticulo(string codigoarticulo, string codigoalmacen)
        {

            return Json(stockLN.ObtenerStock(codigoarticulo, codigoalmacen), JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditarDetalleCotizacion(string codigocabecera, string codigoarticulo,string motivo)
        {

            return Json(stockLN.ObtenerStock(codigoarticulo, codigoarticulo), JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditarCabeceraCotizacion(int codigo_cabecera, string direccion, string formapago,string vendedor,string glosa)
        {

            return Json(cabCoti.EditarCabCtz_Vendedor(codigo_cabecera, direccion,formapago,vendedor,glosa), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult Visor()

        {
            string verificarperfil = Session["PERFIL_USUARIO"].ToString();
            IndexController inss = new IndexController();
            try
            {
               
                if (verificarperfil == "6")
                {
                    // NO SE PARA QUE ERA TALVEZ PARA EDITAR 
                    //  ViewBag.Cabecera = cabCoti.CotizacionCreada(Session["id_usuario_logeado"].ToString());

                    //ViewBag.Cabecera = cabCoti.CotizacionCreada(usuario);
                    //colocar variable extra para tener el codigo almacen  
                    //= new CabeceraCotizacion ();



                    //falta ruc 
                    ViewBag.formaventa2 = formaventaLN.ListadoFormasVenta(1);
                    ViewBag.vendedor2 = vendedoresLN.ListadoVendedores(Session["ID_USUARIO"].ToString());
                    //  int qa = Convert.ToInt32(tenerdatoenduro());
                    ViewBag.modelosarticulo = articuloLN.ListademodelosArticulo();

                    a = cabCoti.CotizacionCreada(Session["ID_USUARIO"].ToString());
                    if (a.glosa == null)
                    {
                        ViewBag.articulo = articuloLN.ListadoArticulo("0000");

                    }
                    else
                    {
                        ViewBag.articulo = articuloLN.ListadoArticulo(a.glosa);
                    }

                    return View();

                }
                else if (verificarperfil == null)
                {
                    return RedirectToAction("CerrarSesion", "Cotizador");
                }
                else
                {
                    return RedirectToAction("CerrarSesion", "Cotizador");
                }



            }
            catch (Exception e)
            {

                throw e;
            }
            
            
           
        }
        [Authorize]
        public ActionResult ListarCotizaciones()
        {

            try
            {
                if (Session["id_usuario_logeado"].ToString() == null)
                {
                    RedirectToAction("Index", "Index");
                }
                else
                {


                    ViewBag.clienteDataTable = clienteLN.ListadoClientesconDataTable();
                    //falta ruc 
                    ViewBag.formaventa2 = formaventaLN.ListadoFormasVenta(1);
                    ViewBag.vendedor2 = vendedoresLN.ListadoVendedores(Session["id_usuario_logeado"].ToString());
                    //  int qa = Convert.ToInt32(tenerdatoenduro());
                    ViewBag.modelosarticulo = articuloLN.ListademodelosArticulo();

                    a = cabCoti.CotizacionCreada("qa");
                    if (a.glosa == null)
                    {
                        ViewBag.articulo = articuloLN.ListadoArticulo("0000");

                    }
                    else
                    {
                        ViewBag.articulo = articuloLN.ListadoArticulo(a.glosa);
                    }


                }


            }
            catch (Exception e)
            {

                throw e;
            }

            return View();
        }
        public int tenerdatoenduro()
        {
            int dato = 12 + 12;
            return dato;
        }

        public JsonResult traer_dato_para_codigo(int codigo)
        {
        return Json(cabCoti.CotizacionEditarCabecera(codigo),JsonRequestBehavior.AllowGet); 
        }

        public JsonResult ListarCotizacionesVendedor(string estado)
        {
            try
            {
                //FGB: COONTROLA LA VARIABLE USUARIO ;
                if (Session["id_usuario_logeado"] !=null)
                {
                   
                    return Json(cabCoti.ListadoCotizaciones(Session["id_usuario_logeado"].ToString(), estado));
                }
                else
                {
                    return Json(cabCoti.ListadoCotizaciones("",""));
                }

                
            }
            catch (Exception E)
            {

                throw E;
            }
            
           
        }
        [Authorize]
        public JsonResult ListarCotizacionesVendedor_visor_creditos_cobranzas()
        {
            try
            {
                //FGB: COONTROLA LA VARIABLE USUARIO ;
                if (Session["id_usuario_logeado"] != null)
                {

                    return Json(cabCoti.ListadoCotizaciones_creditos_cobranzas(Session["id_usuario_logeado"].ToString()));
                }
                else
                {
                    return Json(cabCoti.ListadoCotizaciones("",""));
                }


            }
            catch (Exception E)
            {

                throw E;
            }


        }

        public JsonResult ListarCotizacionesVendedor_parametro(string fecha_inicio, string fecha_fin,string parametro)
        {
            try
            {
                //FGB: COONTROLA LA VARIABLE USUARIO ;
                if (Session["id_usuario_logeado"] != null)
                {

                    return Json(cabCoti.ListadoCotizaciones_parametro(Session["id_usuario_logeado"].ToString(),fecha_inicio,fecha_fin));
                }
                else
                {
                    return Json(cabCoti.ListadoCotizaciones_parametro("",fecha_inicio,fecha_fin));
                }


            }
            catch (Exception E)
            {

                throw E;
            }


        }

        [HttpPost]
        public ActionResult CargarArchivo(HttpPostedFileBase cargaArchivo)
        {
            try
            {
                //creamos un path
                string path = Server.MapPath("~/Assets/Imagenes/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);

                }
                cargaArchivo.SaveAs(path + Path.GetFileName(cargaArchivo.FileName));
            }
            catch (Exception e)
            {
                return Json(new { Value = false , Message=e.Message},JsonRequestBehavior.AllowGet);
               
            }

            return Json(new { Value = true, Message = "SUbido con exito" }, JsonRequestBehavior.AllowGet );
        }

        public JsonResult CargarImagen_Cotizacion(int codigocotizacion,string dataimage)
        {
            return Json(cabCoti.CargarImagen_Cotizacion(codigocotizacion, dataimage, ""));
        }

        [Authorize]
        public ActionResult ListarCotizacionesUsuario()
        {
            return View(cabCoti.ListadoCotizaciones(Session["ID_USUARIO"].ToString(),"3"));
        }

        public ActionResult InsertarCabeceraCotizacion(string txtCliente, string txtDireccionse, string txtFormaPago, string txtVendedor,string txtMoneda,
        string txtAlmacen, string txtAdjunto, string txtFechaEmision, string txtGlosa, string txtFechaRegistro,string txtUsuario)
        {
            //txtAdjunto = "";
            CabeceraCotizacion cabCotizacion = new CabeceraCotizacion();
            DateTime dt1 = DateTime.Now;
            if (txtDireccionse==null|| txtAdjunto==null)
            {
                //"0001"
                cabCotizacion.direccion = txtDireccionse;
                cabCotizacion.cliente = txtCliente;
                
                cabCotizacion.formapago = txtFormaPago;
                cabCotizacion.vendedor = txtVendedor;
                cabCotizacion.moneda = txtMoneda;
                cabCotizacion.almacen = txtAlmacen;

                cabCotizacion.adjunto = "";
                cabCotizacion.fechaemision = Convert.ToString(dt1);
                cabCotizacion.glosa = txtGlosa;
                cabCotizacion.fecharegistro = Convert.ToString(dt1);
                //agregar cabecera cotizacion con ID
                cabCotizacion.usuario = Session["id_usuario_logeado"].ToString();
                //
                //cabCotizacion.usuario = Session["ID_USUARIO"].ToString();
                cabCotizacion.id_estado = "3";
            }
            else
            {
                cabCotizacion.cliente = txtCliente;
                cabCotizacion.direccion = txtDireccionse;
                cabCotizacion.formapago = txtFormaPago;
                cabCotizacion.vendedor = txtVendedor;
                cabCotizacion.moneda = txtMoneda;
                cabCotizacion.almacen = txtAlmacen;
                cabCotizacion.adjunto = txtAdjunto;
                cabCotizacion.fechaemision = Convert.ToString(dt1); ;
                cabCotizacion.glosa = txtGlosa;
                cabCotizacion.fecharegistro = Convert.ToString(dt1); ;

                cabCotizacion.usuario = Session["id_usuario_logeado"].ToString();
                //cabCotizacion.usuario = Session["ID_USUARIO"].ToString();
                cabCotizacion.id_estado = "3";
            }
           


            string mensaje = "";

            string baseurl1="",baseurl ="", baseurl2 = "";
            string userIP = Request.UserHostAddress;

            if (cabCoti.AgregarCabeceraCotizacion(cabCotizacion) == true)
            {
                if (userIP == "::1")
                {
                    baseurl = "/Cotizador/CotizacionCreada";
                    mensaje = "<script lenguaje='javascript' type='text/javascript'>" +
                    "window.location.href='" + baseurl + "';</script>";
                }
               //else if (userIP=="10.10.0.14") 
               // {
               //     baseurl1 = "http://10.10.0.14/cotizadorRepuestos/Cotizador/CotizacionCreada";
               //     mensaje = "<script lenguaje='javascript' type='text/javascript'>" +
               //     "window.location.href='" + baseurl1 + "';" +
               //     "console.log('10.....');</script>";
               // }
                else
                {
                    baseurl2 = "http://190.116.2.84/cotizadorRepuestos/Cotizador/CotizacionCreada";
                    mensaje = "<script lenguaje='javascript' type='text/javascript'>" +
                    "window.location.href='" + baseurl2 + "';" +
                    "</script>";
                }

                //servidor internet 
                // baseurl = "http://190.116.2.84/cotizadorRepuestos/Cotizador/CotizacionCreada";
                //mensaje = "<script lenguaje='javascript' type='text/javascript'>" +
                //"window.location.href='"+baseurl+"';</script>";
                // baseurl2 = "http://10.10.0.14/cotizadorRepuestos/Cotizador/CotizacionCreada";
                //mensaje = "<script lenguaje='javascript' type='text/javascript'>" +
                //"window.location.href='" + baseurl2 + "';</script>";



                //local
                //            mensaje = "<script lenguaje='javascript' type='text/javascript'>" +
                //"window.location.href='/Cotizador/CotizacionCreada';</script>";

                //mensaje = "RedirectToAction('Cotizador, 'CotizacionCreada');";
                //"<script lenguaje='javascript' type='text/javascript'> alert('hola'); " +
                //    "window.location.href="+"'@Url.Action('CotizacionCreada','Cotizador')';"+"</script>";

            }
            else
            {
                
                mensaje = "<script lenguaje='javascript' type='text/javascript'>" +
                    "window.location.href=" +
                    "'/Cotizador/Index';</script>";
            }


            return Content(mensaje) ;
        }

        public JsonResult Listado_Detalle_stock_mayor_cero(int codigo)
        {
        return Json(detCotiLN.ListadoDetalleCotizacion_stock_mayor_cero(codigo), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarDetalleCotizacionxCabecera(int codigocabecera)
        {
            return Json(detCotiLN.ListadoDetalleCotizacionPorCabecera(codigocabecera), JsonRequestBehavior.AllowGet);
        }

        public JsonResult anular_detalle_articulo(int codigocabecera,string codarticulo)
        {

            return Json(cabCoti.anular_detalle_articulo(codigocabecera, codarticulo));
        }

        
        public JsonResult ListadoArticulosFiltrado(string codigo , string descripcion,string modelo)
        {
            return Json(articuloLN.ListadoArticulosFiltrados(codigo,descripcion, Session["ALMACEN_DE_CTZ_CREADA"].ToString(),modelo), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListadoArticulosFiltrado_edit(string codigo, string almacen,string descripcion, string modelo)
        {
            return Json(articuloLN.ListadoArticulosFiltrados(codigo, descripcion, almacen, modelo), JsonRequestBehavior.AllowGet);
        }

        public JsonResult lIstadodeimagenesabonos(int codigocotizacion) {
            return Json(cabCoti.ListadoFotos(codigocotizacion), JsonRequestBehavior.AllowGet);
        }



        //GENERAR PEDIDO
        
            public JsonResult GenerarPedido(int codigocotizacion,int idusuario)
        {
           //usuario que aprueba la cotizacion
            int id_usr = Convert.ToInt32(Session["id_usuario_logeado"].ToString());
            Generar_pedido genPed = new Generar_pedido();
            genPed.codigo_cotizacion = codigocotizacion;
            genPed.id_usuario = id_usr;

            return Json(cabCoti.GenerarPedido(genPed),JsonRequestBehavior.AllowGet);
        }
    }       
}