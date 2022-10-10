using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LN.SOP;
using ENTIDAD.SOP;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Web.Security;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PRESENTACION.Controllers
{
    public class SOPController : Controller
    {

        SOP_RegistroSanitarioLN SOP_rrgg = new SOP_RegistroSanitarioLN();
       
        // GET: SOP
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Proyeccion()
        {
            return View();
        }
        public ActionResult Institucional()
        {
            return View();
        }

        public JsonResult ListaRegistrosSanitarios()
        {

            return Json(SOP_rrgg.ListadoRegistrosSanitarios());
        }
    
        public static DataTable ConvertExcelToDataTable(string FileName)
        {
            DataTable dtResult = null;
            int totalSheet = 0;
            using (OleDbConnection objConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=2;';"))
            {
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                DataTable dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = string.Empty;
                if (dt != null)
                {
                    var tempDataTable = (from dataRow in dt.AsEnumerable()
                                         where !dataRow["TABLE_NAME"].ToString().Contains("FilterDatabase")
                                         select dataRow).CopyToDataTable();
                    dt = tempDataTable;
                    totalSheet = dt.Rows.Count;
                    sheetName = dt.Rows[0]["TABLE_NAME"].ToString();
                }
                cmd.Connection = objConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                oleda = new OleDbDataAdapter(cmd);
                oleda.Fill(ds, "excelData");
                dtResult = ds.Tables["excelData"];
                objConn.Close();
                return dtResult;
            }
        }

        public JsonResult CargarArchivo_Cotizacion(int codigocotizacion, string dataimage)
        {
            try
            {
                int id = 0;
                if (dataimage!="" && id==0)
                {
                    id= Convert.ToInt32(Session["id_usuario_logeado"].ToString());
                    return Json(SOP_rrgg.CargarArchivo_excel(codigocotizacion, dataimage, id), JsonRequestBehavior.AllowGet);
                }

                else
                {
                    CerrarSesion();
                    return Json(false, JsonRequestBehavior.AllowGet);

                }


               
            }
            catch (Exception e)
            {

                throw e;
            }
            

        }
        public JsonResult CargarArchivo_Institucional(int codigocotizacion, string dataimage)
        {
            try
            {
                if (dataimage!="")
                {
                    return Json(SOP_rrgg.CargarArchivo_excel_Institucional(codigocotizacion, dataimage), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

                throw;
            }

            

        }

        public JsonResult Lista_proy_privada()
        {
           int id = Convert.ToInt32(Session["id_usuario_logeado"].ToString());
            return Json(SOP_rrgg.Lista_proy_privada(id));
        }
        public JsonResult Lista_proy_institucional()
        {

            return Json(SOP_rrgg.Lista_proy_institucional());
        }

        public ActionResult Embarque()
        {
            return View();
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

         

        public async Task<JsonResult>ListaEmbarque_API(string codEmbarque)
           
        {
            // OBTENER PROVEEDOR 
            //SI NO ESTA 
            Task <SOP_Embarquev2> sop_embar;
            //sop_embar = new SOP_Embarque();
            //Lista_API(codEmbarque);
            sop_embar  =  ListaEmbarque_API_get(codEmbarque);


            try
            {
                if (sop_embar==null)
                {
                    return Json(sop_embar);

                }
                else
                {
                    sop_embar =  ListaEmbarque_API_get(codEmbarque);

                    return Json(await sop_embar);
                }


            }
            catch (Exception)
            {

                throw;
            }

          // return Json(sop_embar);
        }
     
        public async Task <SOP_Embarquev2> ListaEmbarque_API_get(string codEmbarque)
        {
            var client = new HttpClient();
            // ShipmentTracking emb;
            SOP_Embarquev2 obj = new SOP_Embarquev2(); 
            //ShipmentTracking emb = new ShipmentTracking();
            string body="";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.dhl.com/dgff/transportation/shipment-tracking?housebill="+ codEmbarque.ToString()),
                Headers =
    {
        { "DHL-API-Key", "2OAmzW3WOlCed7jZbqJxqx1qY8euyUXU" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                //var body = await response.Content.ReadAsStringAsync();
                body = await response.Content.ReadAsStringAsync();

                // emb = JsonConvert.DeserializeObject<ShipmentTracking>(body);
                obj = JsonConvert.DeserializeObject<SOP_Embarquev2>(body);
                //emb = JsonSerializer.Deserialize<ShipmentTracking>(body);
                Console.WriteLine(body);
                return (obj);
            }

            //return (emb);
        }

        public JsonResult RegistroCodigoEmbarque(string codEmbarque)
        {

          int usr_id = Convert.ToInt32(Session["id_usuario_logeado"].ToString());

          return Json(SOP_rrgg.RegistroCodigoEmbarque(usr_id,codEmbarque), JsonRequestBehavior.AllowGet);

        }

        public JsonResult ObtenerRegistroSanitario(int cod_solicitud)
        {
            return Json(SOP_rrgg.ObtenerRegistroSanitario(cod_solicitud));
        }


        public JsonResult RS_Listado_Fabricante()
        {

            return Json(SOP_rrgg.RS_Listado_Fabricante());
        }

        public JsonResult RS_Listado_Paises()
        {

            return Json(SOP_rrgg.RS_Listado_Paises());
        }
        public JsonResult RS_Listado_Estado()
        {

            return Json(SOP_rrgg.RS_Listado_Estado());
        }

        public JsonResult RS_Listado_Envases()
        {

            return Json(SOP_rrgg.RS_Listado_Envases());
        }

        



    }
}