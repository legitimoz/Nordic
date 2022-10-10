using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ENTIDAD;
using LN;
namespace PRESENTACION.Controllers
{
    public class IndexController : Controller
    {

        UsuarioLN usuarioLN = new UsuarioLN();
        PermisoLN permisosLN = new PermisoLN();
       // Usuario usuariolog;
        // GET: Index
        
        public ActionResult Index()
        {
            Session["URL"]="Viaticos";
            return View();
        }

        //public ActionResult SOP()
        //{
        //    Session["URL"] = "Viaticos";
        //    return View();
        //}


        public ActionResult Programas()
        {
            // Session["URL"] = "Viaticos";
            //string mensaje = "", mene = "";
            //mensaje = "<script lenguaje='javascript' type='text/javascript'> location.href = '";

            //mene = "'</script>";
        

            //return Content(mensaje+Url.Action("CotizacionCreada")+ mene );
            return View();
        }



        public JsonResult ObtenerUsuario(string usr, string cod)
        {

            Usuario usu = usuarioLN.ObtenerUsuario(usr, cod);

            if (usu is null)
            {
                // FormsAuthentication.SetAuthCookie(usr, false);
                Session["PERFIL_USUARIO"] = null;
                Session["ID_USUARIO"] = null;
                Session["ID_USUARIO_INT"] = null;
                return Json(usu);
            }
            else
            {
                DateTime hoy = DateTime.Now;
                string fech=Convert.ToString(hoy);
                string[] hora = fech.Split(' ');
                string fec_formateda_pre = hora[0];
                string[] fec_formateda = fec_formateda_pre.Split('-');

                FormsAuthentication.SetAuthCookie(usr, false);
                Session["PERFIL_USUARIO"] = usu.perfil;
                Session["ID_APLICACION"] = 0;
                Session["ID_USUARIO"] = usr;
                Session["ID_USUARIO_INT"] = usr;
                Session["id_usuario_logeado"] = usu.idusuario;
                Session["nombre_usuario_logeado"] = usu.nombre_usuario;
                Session["nombre_compania"] = "Nordyc";
                Session["hora_sistema"] = HoraMinimaSistema();
                return Json(usu);
            }

        }


        public string HoraMinimaSistema()
        {
            string horaminima = "";

            DateTime hoy = DateTime.Now;
            string fech = Convert.ToString(hoy);
            string[] hora = fech.Split(' ');
            string fec_formateda_pre = hora[0];
            string[] fec_formateda = fec_formateda_pre.Split('/');
            horaminima = fec_formateda[2]+"-"+fec_formateda[1] +"-"+fec_formateda[0] ;
            return horaminima;
        }

        public JsonResult ObtenerPermisos(int id)
        {
            
            Session["ID_USUARIO_INT"] = id;
            return Json(id);
        }

        public JsonResult perfil_sesion(int id_perfil)
        {
            //FormsAuthentication.SetAuthCookie(Convert.ToString(id_perfil), false);
            //FGB: ajax usr id
            Usuario usu = new Usuario();
            usu.perfil = id_perfil;
            Session["PERFIL_USUARIO"] = usu.perfil;
           // Session["ID_USUARIO"] = id_usuario;

            //int ids [id_perfil, id_usuario];
            return Json(id_perfil);
        }

        public int DatosUsuario()
        {
            int id_usuario;
            id_usuario = 9;
         
            return id_usuario;
            
        }

        public ActionResult CerrarSesion()
        {



            Session.Remove("PERFIL_USUARIO");
            Session.Remove("ID_USUARIO");
            Session.Remove("nombre_usuario_logeado");
            Session.Remove("id_usuario_logeado");
            //Session.Remove("nombre_usuario_logeado");
            Session.Remove("URL");
            Session.Contents.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Index");
        }

    }
}