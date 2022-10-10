using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;


using System.Web.Script.Serialization;
using ENTIDAD.VIATICOS;
using LN.VIATICOS;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Data;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Web.Security;
using ClosedXML.Excel;
using System.Threading;
using System.Net.Mime;

namespace PRESENTACION.Controllers
{
    public class ViaticosController : Controller
    {
        VIA_CAB_SOL_LN via_cab_sol_ln = new VIA_CAB_SOL_LN();
        // GET: Viaticos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Vendedor()
        {
            try
            {
                //REGISTRAR SOLICITUDES DE VIATICOS 
                int id = Convert.ToInt32(Session["id_usuario_logeado"].ToString());
                ViewBag.Usuario = via_cab_sol_ln.ObtenerUsuario(id);
                return View();

            }
            catch (Exception)
            {

                throw;
            }
           

        }

        public ActionResult Representante()
        {
            try
            {
                int id = Convert.ToInt32(Session["id_usuario_logeado"].ToString());
                ViewBag.Usuario = via_cab_sol_ln.ObtenerUsuario(id);
                return View();
            }
            catch (Exception)
            {

                throw;
            }
            //REGISTRAR SOLICITUDES DE VIATICOS 
            //int id = Convert.ToInt32(Session["id_usuario_logeado"].ToString());
            //ViewBag.Usuario = via_cab_sol_ln.ObtenerUsuario(id);
            //return View();

        }

        public ActionResult RegistroViatico()
        {

            try
            {


            }
            catch (Exception E)
            {

                throw E;
            }

            //via_cab_sol_ln.ObtenerUsuario(id_usr);
            return View();
        }
        public JsonResult RegistroViaticos(int perfil, int id_usr_logeado, string cod_linea)
        {
            //int perfil = 0;
            Via_Cab_Solicitud viaObjet;
            if (perfil == 2)
            {
                viaObjet = new Via_Cab_Solicitud();
                viaObjet.usr_id_logeado = perfil;
                viaObjet.cod_linea = cod_linea;


                return Json(via_cab_sol_ln.AgregarCabSolViatico(viaObjet), JsonRequestBehavior.AllowGet);
            }
            else if (perfil == 6)
            {
                viaObjet = new Via_Cab_Solicitud();
                viaObjet.usr_id_logeado = perfil;
                viaObjet.cod_linea = cod_linea;


                return Json(via_cab_sol_ln.AgregarCabSolViatico(viaObjet), JsonRequestBehavior.AllowGet);
            }

            else if (perfil == 1)
            {
                viaObjet = new Via_Cab_Solicitud();
                viaObjet.usr_id_logeado = perfil;
                viaObjet.cod_linea = cod_linea;


                return Json(via_cab_sol_ln.AgregarCabSolViatico(viaObjet), JsonRequestBehavior.AllowGet);

            }
            else
            {
                viaObjet = new Via_Cab_Solicitud();
                viaObjet.usr_id_logeado = 0;
                viaObjet.cod_linea = "0";
                return Json(via_cab_sol_ln.AgregarCabSolViatico(viaObjet), JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult GerenteLinea()
        {
            try
            {
                int id_d = Convert.ToInt32(Session["id_usuario_logeado"]);
                ViewBag.Usuario = via_cab_sol_ln.ObtenerUsuario(id_d);
                return View();

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public ActionResult Reporteliquidaciones()
            
        {
            return View();
        }

        public JsonResult ListaUsuarios()
        {
            try
            {
                int id_d = Convert.ToInt32(Session["id_usuario_logeado"]);
                return Json(via_cab_sol_ln.ListadoRepresentantes(id_d));
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public JsonResult UpdateFlagUser(int id)
        {
            try
            {
               return Json(via_cab_sol_ln.UpdateFlagUser(id));
            }
            catch (Exception)
            {

                throw;
            }

        }

        
        public ActionResult ViaticoCreado(int usr_creacion)
        {
            //revisar FGB
            // id_d - id_usuario
            try
            {
                if (usr_creacion==0)
                {
                    int id_d = Convert.ToInt32(Session["id_usuario_logeado"]);
                    ViewBag.Usuario = via_cab_sol_ln.ObtenerUsuario(id_d);

                    ViewBag.ViaCabSol = via_cab_sol_ln.ObtenerUltimoViaticoCreadoporUsu(id_d);
                }

                else
                {
                    ViewBag.Usuario = via_cab_sol_ln.ObtenerUsuario(usr_creacion);

                    ViewBag.ViaCabSol = via_cab_sol_ln.ObtenerUltimoViaticoCreadoporUsu(usr_creacion);
                }
                
               
            }
            catch (Exception)
            {

                throw;
            }
            



            return View();
        }
        public ActionResult Master()
        {
            int id_d = Convert.ToInt32(Session["id_usuario_logeado"]);
            ViewBag.Usuario = via_cab_sol_ln.ObtenerUsuario(id_d);
            return View();
        }

        public ActionResult CerrarSesion()
        {
           // Session.Remove("PERFIL_USUARIO");
          //  Session.Remove("ID_USUARIO");
          //  Session.Remove("nombre_usuario_logeado");
            Session.Remove("id_usuario_logeado");
         //   Session.Remove("nombre_usuario_logeado");
          //  Session.Remove("URL");
            Session.Contents.RemoveAll();
           // FormsAuthentication.SignOut();

            // Session.Contents.RemoveAll();
            // FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Index");
        }
        public JsonResult ListadoMediosViaje() {

            return Json(via_cab_sol_ln.ListadoMediosViaje());
        }
        public JsonResult ListadoMotivosViaje()
        {

            return Json(via_cab_sol_ln.ListadoMotivosVaiaje());
        }
        public JsonResult ListadoLineasUsuario()
        {
            return Json(via_cab_sol_ln.ListadoLineasUsuario());
        }

        public JsonResult ListadoGerenteLineas()
        {
            return Json(via_cab_sol_ln.ListadoGerenteLineas());
        }
        public JsonResult ListadoDepartamentos()
        {
            JsonResult json = Json(via_cab_sol_ln.ListadoDepartamentos());
            //return Json(via_cab_sol_ln.ListadoDepartamentos());
            return json;
        }
        public JsonResult ListadoProvincias(string id_departamento)
        {

            return Json(via_cab_sol_ln.ListadoProvincias(id_departamento));
        }
        public JsonResult ListadoDistritos(string id_provincia)
        {
            return Json(via_cab_sol_ln.ListadoDistritos(id_provincia));
        }
        public JsonResult ListadoClientesSoftcom()
        {
            return Json(via_cab_sol_ln.ListadoClientesSoftcom());
        }
        public JsonResult ListadoMedicosSoftcom()
        {
            return Json(via_cab_sol_ln.ListadoMedicosSoftcom());
        }


        

        public JsonResult Registrar_VIA_CAB_SOL(string idlinea, string fec_solicitud, int cod_mot_viaje, double monto_solicitado, int cod_med_viaje,
            string dep_ori, string pro_ori, string dis_ori, string fec_ori, string dep_des, string pro_des, string dis_des, string fec_des, string fec_ter,
            double monto_esperado, int cant_dias)
        {

            DateTime hoy = DateTime.Now;
            Via_Cab_Solicitud via_cab_sol = new Via_Cab_Solicitud();
            via_cab_sol.usr_id_logeado = Convert.ToInt32(Session["id_usuario_logeado"]);
            via_cab_sol.cod_linea = idlinea;
            via_cab_sol.fecha_solicitud = fec_solicitud;
            via_cab_sol.cod_mot_viaje = cod_mot_viaje;
            via_cab_sol.monto_solicitado = monto_solicitado;
            via_cab_sol.cod_med_viaje = cod_med_viaje;
            via_cab_sol.id_depart_ori = dep_ori;
            via_cab_sol.id_prov_ori = pro_ori;
            via_cab_sol.fecha_origi = fec_ori;
            via_cab_sol.id_depart_dest = dep_des;
            via_cab_sol.id_prov_dest = pro_des;
            via_cab_sol.id_distri_dest = dis_des;
            via_cab_sol.fecha_dest = fec_des;
            via_cab_sol.fecha_term_viaje = fec_ter;
            via_cab_sol.monto_esperado = monto_esperado;
            via_cab_sol.cant_dias = cant_dias;
            via_cab_sol.est_codigo = "PE";
            via_cab_sol.usr_id_cre = Convert.ToInt32(Session["id_usuario_logeado"]);
            via_cab_sol.fec_cre = Convert.ToString(hoy);

            return Json(via_cab_sol_ln.AgregarCabSolViatico(via_cab_sol), JsonRequestBehavior.AllowGet);
        }

        public JsonResult RegistroDetallePresupuesto(int id_solicitud, int id_gasto, int cantidad, double precio)
        {
            Via_Det_Presupuesto vdp = new Via_Det_Presupuesto();
            vdp.id_v_num_sol = id_solicitud;
            vdp.id_gasto = id_gasto;
            vdp.precio = precio;
            vdp.dias= cantidad;
            vdp.usr_id_logeado= Convert.ToInt32(Session["id_usuario_logeado"]);

            return Json(via_cab_sol_ln.RegistroDetallePresupuesto(vdp), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Registrar_Mot_Viaje(string mot)
        {
            Via_Mot_Viaje mot_viaje = new Via_Mot_Viaje();
            mot_viaje.v_mot_v_nombre = mot;
          
           
            return Json(via_cab_sol_ln.Registrar_Mot_Viaje(mot_viaje), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Registrar_Med_Viaje(string med)
        {
            Via_Med_Viaje med_viaje = new Via_Med_Viaje();
            med_viaje.v_med_v_nombre = med;


            return Json(via_cab_sol_ln.Registrar_Med_Viaje(med_viaje), JsonRequestBehavior.AllowGet);
        }
        





        public JsonResult AnularDetallePresupuesto(int id_solicitud, int id_gasto)
        {
            Via_Det_Presupuesto vdp = new Via_Det_Presupuesto();
            vdp.id_v_num_sol = id_solicitud;
            vdp.id_gasto = id_gasto;

            vdp.usr_id_logeado = Convert.ToInt32(Session["id_usuario_logeado"]);

            return Json(via_cab_sol_ln.AnularDetallePresupuesto(vdp), JsonRequestBehavior.AllowGet);
        }





        public JsonResult Registrar_VIA_CAB_SOL_2(int id_usr_creacion, string idlinea, string fechasolicitud, int cod_mot_viaje, float monto_solicitado, int cod_med_viaje, string id_depart_ori, string id_prov_ori,
            string id_distri_ori, string fecha_origi, string id_depart_dest, string id_prov_dest, string id_distri_dest, string fecha_dest, string fecha_term_viaje, float monto_esperado, int cant_dias)
        {

            try
            {
                if (id_usr_creacion==0)
                {
                    //REALIZANDO 
                    //detCoti.AgregarDetalleCotizacion(), JsonRequestBehavior.AllowGet;

                    DateTime fecha_origi_parseda = DateTime.Parse(fecha_origi);
                    DateTime fecha_dest_parseda = DateTime.Parse(fecha_dest);
                    DateTime fecha_term_parseda = DateTime.Parse(fecha_term_viaje);


                    DateTime hoy = DateTime.Now;
                    Via_Cab_Solicitud via_cab_sol = new Via_Cab_Solicitud();
                    via_cab_sol.usr_id_logeado = Convert.ToInt32(Session["id_usuario_logeado"]);
                    via_cab_sol.cod_linea = idlinea;
                    via_cab_sol.fecha_solicitud = fechasolicitud;
                    via_cab_sol.cod_mot_viaje = cod_mot_viaje;
                    via_cab_sol.monto_solicitado = monto_solicitado;
                    via_cab_sol.cod_med_viaje = cod_med_viaje;
                    via_cab_sol.id_depart_ori = id_depart_ori;
                    via_cab_sol.id_prov_ori = id_prov_ori;
                    via_cab_sol.id_distri_ori = id_distri_ori;
                    via_cab_sol.fecha_origi = fecha_origi_parseda.ToString("yyyy-MM-dd hh:mm:ss.000");

                    //via_cab_sol.fecha_origi = Convert.ToString(fecha_origi_parseda);
                    via_cab_sol.id_depart_dest = id_depart_dest;
                    via_cab_sol.id_prov_dest = id_prov_dest;
                    via_cab_sol.id_distri_dest = id_distri_dest;
                    //via_cab_sol.fecha_dest = Convert.ToString(hoy);
                    // via_cab_sol.fecha_term_viaje = Convert.ToString(hoy);

                    //via_cab_sol.fecha_dest = Convert.ToString(fecha_dest_parseda);
                    via_cab_sol.fecha_dest = fecha_dest_parseda.ToString("yyyy-MM-dd hh:mm:ss.000");
                    //via_cab_sol.fecha_term_viaje = Convert.ToString(fecha_term_parseda);
                    via_cab_sol.fecha_term_viaje = fecha_term_parseda.ToString("yyyy-MM-dd");

                    via_cab_sol.monto_esperado = monto_esperado;

                    via_cab_sol.est_codigo = "PE";

                    via_cab_sol.fec_cre = hoy.ToString("yyyy-MM-dd hh:mm:ss.000");

                    //CONTEO DE DIAS 
                    cant_dias = ConvertFecha_en_dia(fecha_term_viaje) - ConvertFechaDateTime_en_dia(fecha_dest);

                    via_cab_sol.cant_dias = cant_dias;

                    via_cab_sol.usr_id_cre = Convert.ToInt32(Session["id_usuario_logeado"]);

                    // CAPTURA DE DIAS MES AÑO DE FECHA DESTINO 
                    //string[] fecha_destino = fecha_dest.Split('-');
                    //string[] dias_destino = fecha_destino[2].Split('T');
                    //int dia_destino = Convert.ToInt32(dias_destino[0]);
                    return Json(via_cab_sol_ln.AgregarCabSolViatico(via_cab_sol), JsonRequestBehavior.AllowGet);

                }
                else
                {
                    //REALIZANDO 
                    //detCoti.AgregarDetalleCotizacion(), JsonRequestBehavior.AllowGet;

                    DateTime fecha_origi_parseda = DateTime.Parse(fecha_origi);
                    DateTime fecha_dest_parseda = DateTime.Parse(fecha_dest);
                    DateTime fecha_term_parseda = DateTime.Parse(fecha_term_viaje);
                    DateTime hoy = DateTime.Now;
                    Via_Cab_Solicitud via_cab_sol = new Via_Cab_Solicitud();
                    via_cab_sol.usr_id_logeado = Convert.ToInt32(Session["id_usuario_logeado"]); 
                    via_cab_sol.cod_linea = idlinea;
                    via_cab_sol.fecha_solicitud = fechasolicitud;
                    via_cab_sol.cod_mot_viaje = cod_mot_viaje;
                    via_cab_sol.monto_solicitado = monto_solicitado;
                    via_cab_sol.cod_med_viaje = cod_med_viaje;
                    via_cab_sol.id_depart_ori = id_depart_ori;
                    via_cab_sol.id_prov_ori = id_prov_ori;
                    via_cab_sol.id_distri_ori = id_distri_ori;
                    via_cab_sol.fecha_origi = fecha_origi_parseda.ToString("yyyy-MM-dd hh:mm:ss.000");
                    //via_cab_sol.fecha_origi = Convert.ToString(fecha_origi_parseda);
                    via_cab_sol.id_depart_dest = id_depart_dest;
                    via_cab_sol.id_prov_dest = id_prov_dest;
                    via_cab_sol.id_distri_dest = id_distri_dest;
                    //via_cab_sol.fecha_dest = Convert.ToString(hoy);
                    // via_cab_sol.fecha_term_viaje = Convert.ToString(hoy);

                    //via_cab_sol.fecha_dest = Convert.ToString(fecha_dest_parseda);
                    via_cab_sol.fecha_dest = fecha_dest_parseda.ToString("yyyy-MM-dd hh:mm:ss.000");
                    //via_cab_sol.fecha_term_viaje = Convert.ToString(fecha_term_parseda);
                    via_cab_sol.fecha_term_viaje = fecha_term_parseda.ToString("yyyy-MM-dd");
                    via_cab_sol.monto_esperado = monto_esperado;
                    via_cab_sol.est_codigo = "PE";
                    via_cab_sol.fec_cre = hoy.ToString("yyyy-MM-dd hh:mm:ss.000");
                    //CONTEO DE DIAS 
                    cant_dias = ConvertFecha_en_dia(fecha_term_viaje) - ConvertFechaDateTime_en_dia(fecha_dest);
                    via_cab_sol.cant_dias = cant_dias;
                    via_cab_sol.usr_id_cre = id_usr_creacion;

                    // CAPTURA DE DIAS MES AÑO DE FECHA DESTINO 
                    //string[] fecha_destino = fecha_dest.Split('-');
                    //string[] dias_destino = fecha_destino[2].Split('T');
                    //int dia_destino = Convert.ToInt32(dias_destino[0]);
                    return Json(via_cab_sol_ln.AgregarCabSolViatico(via_cab_sol), JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception)
            {

                throw;
            }
            
          






           
        }
        public int ConvertFechaDateTime_en_dia(string fecha)
        {
            string[] fecha_ = fecha.Split('-');
            string[] dias_ = fecha_[2].Split('T');
            int dia_ = Convert.ToInt32(dias_[0]);

            return dia_;
        }

        public int ConvertFecha_en_dia(string fecha)
        {
            string[] fecha_ = fecha.Split('-');
           // string[] dias_ = fecha_[2].Split('T');
            int dia_ = Convert.ToInt32(fecha_[2]);

            return dia_;
        }

        public ActionResult ListaViaticos()
        {
            //para abrir el detalle 
            int id_d = Convert.ToInt32(Session["id_usuario_logeado"]);
            ViewBag.Usuario = via_cab_sol_ln.ObtenerUsuario(id_d);
            ViewBag.ViaCabSol = via_cab_sol_ln.ObtenerUltimoViaticoCreadoporUsu(id_d);
            

            return View();
        }

        public ActionResult Liquidacion(string codigo)
        {
            //validar que no ingrese data por url 
            //funcion para validar que la solicitud existe para ese usuario 
            if (codigo==null)
            {
               
                return View("ListaViaticos");
            }
            else{

                ViewBag.Cod = codigo;
                return View();
            }
            
        }

        public JsonResult AgregarDetalleCliente(string cod_cliente, string nom_cliente, int vcs_id,double precio_proyectado)
        {
            try
            {
                int usr_id = Convert.ToInt32(Session["id_usuario_logeado"]);

                if (precio_proyectado>0)
                {
                   

            return Json(via_cab_sol_ln.AgregarDetalleCliente(cod_cliente, nom_cliente, vcs_id, usr_id, precio_proyectado), JsonRequestBehavior.AllowGet);
                }

                else
                {
                   
            return Json(via_cab_sol_ln.AgregarDetalleCliente(cod_cliente, nom_cliente, vcs_id, usr_id, 0), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

                throw;
            }
            

           
        }

        public JsonResult ListadoDetClie(int vcs_id)
        {

            return Json(via_cab_sol_ln.ListadoDetClie(vcs_id));
        }

        public JsonResult AnularDetCliente(string codigocliente, int codigosolicitud)
        {
            int id_d = Convert.ToInt32(Session["id_usuario_logeado"]);
            return Json(via_cab_sol_ln.AnularDetCliente(codigocliente,codigosolicitud, id_d));
        }

        public JsonResult ListadoViaticosCreados(string estado)
        {
            int id_d = Convert.ToInt32(Session["id_usuario_logeado"]);
            return Json(via_cab_sol_ln.ListadoViaticosCreados(id_d, estado));
        }

        public JsonResult AgregarDetConGastos(int vcs_id, int vcg_id, string fechacomprobante, int id_med_viaje, string numComprobante, string rucProveedor, string RazonSocial, double ImporteTotal, string tipo_comprobante, string serie, string foto)
        {
            String xml = String.Empty;
            try
            {

                // string RazonSocial,float preciolista ,string foto
                Via_Det_Con_Gastos via_det_con_gastos = new Via_Det_Con_Gastos();

                DateTime ahora = DateTime.Now;
                via_det_con_gastos.vcs_id = vcs_id;
                via_det_con_gastos.vcg_id = vcg_id;
                via_det_con_gastos.cod_med_viaje = id_med_viaje;
                via_det_con_gastos.vdcg_punto_llegada = "";
                via_det_con_gastos.vdcg_punto_partida = "";
                via_det_con_gastos.vdcg_precio_lista = ImporteTotal;
                via_det_con_gastos.vdcg_precio_propuesto = ImporteTotal;
                via_det_con_gastos.vdcg_usrid_crea = Convert.ToInt32(Session["id_usuario_logeado"]); ;
                via_det_con_gastos.vdcg_fec_crea = Convert.ToString(ahora);
                via_det_con_gastos.vdcg_numcomprobante = numComprobante;
                via_det_con_gastos.vdcg_rucproveedor = rucProveedor;
                via_det_con_gastos.vdcg_razonsocial = RazonSocial;
                via_det_con_gastos.vdcg_fechacomprobante = fechacomprobante;
                via_det_con_gastos.vdcg_tipo_comprobante = tipo_comprobante;
                via_det_con_gastos.vdcg_serie = serie;
                via_det_con_gastos.foto = foto;
              
                xml = via_det_con_gastos.Serializar(via_det_con_gastos);

               // return Json(via_cab_sol_ln.AgregarDetConGastos(via_det_con_gastos), JsonRequestBehavior.AllowGet);

                return Json(via_cab_sol_ln.AgregarDetConGastos_xml(xml), JsonRequestBehavior.AllowGet);
            }
            catch (Exception E)
            {

                throw E;
            }

        }
               
        public JsonResult ListadoConceptoGasto()
        {

            return Json(via_cab_sol_ln.ListadoConceptoGasto());
        }
        public JsonResult ListadoConceptoGasto_master()
        {

            return Json(via_cab_sol_ln.ListadoConceptoGasto_master());
        }
        

        public JsonResult ListadoDetGastos(int vcs_id) {
            return Json(via_cab_sol_ln.ListadoDetGastos(vcs_id));
        }

        public JsonResult ListadoDet_Presupuesto(int id_solicitud)
        {
            return Json(via_cab_sol_ln.ListadoDet_Presupuesto(id_solicitud));
        }
      
        public JsonResult EditarDetallePresupuesto(int id_solicitud, int id_gasto, int cantidad, double precio)
        {
            Via_Det_Presupuesto vdp = new Via_Det_Presupuesto();
            vdp.id_v_num_sol = id_solicitud;
            vdp.id_gasto = id_gasto;
            vdp.precio = precio;
            vdp.dias = cantidad;
            vdp.usr_id_logeado = Convert.ToInt32(Session["id_usuario_logeado"]);

            return Json(via_cab_sol_ln.EditarDetallePresupuesto(vdp), JsonRequestBehavior.AllowGet);
        }



        public JsonResult MontoPresupuestadoporSolicitud(int id_solicitud)
        {
            return Json(via_cab_sol_ln.MontoPresupuestadoporSolicitud(id_solicitud));
        }

        public JsonResult Enviar__aproba_glinea(int codigo, string estado)
        {
            int id_d = Convert.ToInt32(Session["id_usuario_logeado"]);
            return Json(via_cab_sol_ln.Enviar__aproba_glinea(codigo, estado, id_d));
        }

        public JsonResult AprobarViatico(int codigo, string estado)
        {
            int id_d = Convert.ToInt32(Session["id_usuario_logeado"]);
            
            return Json(via_cab_sol_ln.AprobarVaitico(codigo, estado, id_d));
        }

        public JsonResult ObtenerSolictudViatico(int codigo)
        {

            //LISTA DETALLE EN APROBACIONES
            return Json(via_cab_sol_ln.ObtenerSolicitudViatico(codigo));
        }

        public ActionResult AprobacionGerenteLinea()
        {
            return View();
        }

        public JsonResult ListadoViaticosCreados_apro(string estado, int representante)
        {
            try
            {

                if (representante != 0)
                {
                    return Json(via_cab_sol_ln.ListadoViaticosCreados_apro(estado, representante));
                }

                else
                {
                    return Json(via_cab_sol_ln.ListadoViaticosCreados_apro(estado, 0));
                }

            }
            catch (Exception)
            {

                throw;
            }

           
        }

        public JsonResult ListaRuc_API(string ruc)
        {
            // OBTENER PROVEEDOR 
            //SI NO ESTA 
            Proveedor pro = new Proveedor();
            pro =   GetRquestApi(ruc);
            return Json(pro);
        }

        public Proveedor GetRquestApi(string Ruc)
        {
            DataTable table = new DataTable();
            string Url = "";
            string token = "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImouYmFsY2F6YXIuZkBnbWFpbC5jb20ifQ.yNTGnoT01IGfjJ8B4ICWFuw6UVluflxGiKDmG5-PHN0";
            string url_ = "https://dniruc.apisperu.com/api/v1/ruc/";
            string responsText = "";
            Proveedor items;
            try
            {
                 Url = url_ +Ruc.ToString()+token;
                WebRequest request = null;
                request =  WebRequest.Create(Url);
                ServicePointManager.Expect100Continue = true;
                request.Method = HttpMethod.Get.Method;
                request.ContentType = "application/json";
                HttpWebResponse response = null;
                request.Method = WebRequestMethods.Http.Get;
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                response = (HttpWebResponse) request.GetResponse();

                if (response==null)
                {
                    items = new Proveedor();
                    items.razonSocial = "No existe";
                    items.ruc = "No existe";
                    return items;
                }

                else
                {

                    WebHeaderCollection header = response.Headers;

                    var encoding = ASCIIEncoding.ASCII;
                    using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
                    {
                        responsText = reader.ReadToEnd();

                        if (responsText == "")
                        {
                            items = new Proveedor();
                            items.razonSocial = "No existe";
                            items.ruc = "No existe";
                            return items;

                        }
                        else
                        {
                            items = JsonConvert.DeserializeObject<Proveedor>(responsText);

                        }
                    }


                }

                               

               
            }
            catch (Exception EX)
            {

                throw EX;
            }
            return items;
        }


        public JsonResult ListadoMotivos()
        {
            return Json(via_cab_sol_ln.ListadoMotivos());
        }


        

        public JsonResult desaprobar_viatico(int codigocabecera, int id_motanul)
        {
            int id_usr = Convert.ToInt32(Session["id_usuario_logeado"].ToString());

            string estado = "AN";

            return Json(via_cab_sol_ln.desaprobar_viatico(codigocabecera,estado ,id_usr, id_motanul), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListadoEstados(int app_function)
        {
            return Json(via_cab_sol_ln.ListadoEstados(app_function), JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult ListadoLiquidaciones(int repre, string f_ini,string f_fin)
        {
          
            int id_usr = Convert.ToInt32(Session["id_usuario_logeado"].ToString());
            return Json(via_cab_sol_ln.ListadoLiquidaciones(id_usr, f_ini,f_fin), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult AsigancionGL()
        {
            int id_d = Convert.ToInt32(Session["id_usuario_logeado"]);
            ViewBag.Usuario = via_cab_sol_ln.ObtenerUsuario(id_d);

            return View();
        }

        public JsonResult Asignar_Linea(int id_linea, int id_gerente)
        {
            return Json(via_cab_sol_ln.Asignar_Linea(id_linea, id_gerente), JsonRequestBehavior.AllowGet);
        }

        
            public ActionResult RestriccionesSistema()
                {
            int id_d = Convert.ToInt32(Session["id_usuario_logeado"]);
            ViewBag.Usuario = via_cab_sol_ln.ObtenerUsuario(id_d);

            return View();
            }

        public JsonResult Saldo_liquidacion(int id_solicitud)
        {

            return Json(via_cab_sol_ln.Saldo_Liquidacion(id_solicitud));

        }


        public JsonResult GenerarExcel()
        {
            try
            {
                
                return Json(Download(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
             
           
            
        }

        public void DescargarExcel()
        {
            try
            {
                DataTable dataTable = new DataTable();
                int id_d = Convert.ToInt32(Session["id_usuario_logeado"]);
                dataTable = via_cab_sol_ln.ListarCLientesconDatatable(id_d);

                // FileContentResult File= null;
                string finalpath = "D:\\archivo";
                string NombreImagen = "EXCELDESCAR2021";
                //NombreImagen = NombreImagen + Session["TU_ALIAS"].ToString() + ".xlsx";
                NombreImagen= NombreImagen + ".xlsx";
                string filePath = Path.Combine(finalpath, NombreImagen);
               
                if (System.IO.File.Exists(filePath))
                {
                   System.IO.File.Delete(filePath);
                }

                XLWorkbook wb = new XLWorkbook();
                wb.Worksheets.Add(dataTable, "EXCELDESCAR2021.xlsx");
                wb.SaveAs(filePath,true);

               FileInfo _file = new FileInfo (filePath);


               // HttpWebR response = null;

                Response.Clear();
                //   //// string str = new ContentDisposition { FileName = this.FileDownloadName, Inline = Inline }.ToString();
                // Response.AppendHeader("Content-Disposition", "attachment; filename=" + _file.Name);
                Response.Headers.Add("Content-Disposition", "attachment; filename=" + _file.Name);
                Response.AppendHeader("Content-Length", _file.Length.ToString());
                Response.ContentType = "application/octet-stream";

                Response.TransmitFile(_file.FullName);
                
             Response.WriteFile(_file.FullName);
               

                  //descarga("~\\EXCELDESCAR2021.xlsx", "hola");
                Response.End();
               if (System.IO.File.Exists(filePath))
                  {
                    Console.WriteLine("File exists...");
                }



                //else
                //{
                // //  // ClientScript.RegisterStartupScript(Type.GetType("System.String"), "messagebox", "<script type=\"text/javascript\">alert('File not Found');</script>");
                //}
               // return File(_file.FullName, "aplication/xlsx", _file.FullName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public FileResult descarga(string ruta_dir,string nombre)
        {

            var ruta = Server.MapPath(ruta_dir);
            return File(ruta,"aplication/xlsx",nombre);
        }

        public FileResult Download()
        {
            //DescargarExcel();

            DataTable dataTable = new DataTable();
            int id_d = Convert.ToInt32(Session["id_usuario_logeado"]);
            dataTable = via_cab_sol_ln.ListarCLientesconDatatable(id_d);

            // FileContentResult File= null;
            string finalpath = "C:\\archivo";
            string NombreImagen = "EXCELDESCAR2021";
            //NombreImagen = NombreImagen + Session["TU_ALIAS"].ToString() + ".xlsx";
            NombreImagen = NombreImagen + ".xlsx";
            string filePath = Path.Combine(finalpath, NombreImagen);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            XLWorkbook wb = new XLWorkbook();
            wb.Worksheets.Add(dataTable, "EXCELDESCAR2021.xlsx");
            wb.SaveAs(filePath, true);




            byte[] fileBytes = System.IO.File.ReadAllBytes(@"c:\archivo\EXCELDESCAR2021.xlsx");
            string fileName = "EXCELDESCAR2021.xlsx";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}