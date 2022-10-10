using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRESENTACION.Controllers
{
    public class CanjesController : Controller
    {

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

        // GET: Canjes
        public ActionResult ListarCanjes()
        {
            return View();
        }

        public JsonResult Listar_Canjes()
        {
            String rp = "";
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return Json(rp) ;
        }

        // GET: Canjes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Canjes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Canjes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Canjes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Canjes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Canjes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Canjes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
