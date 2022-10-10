using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD.SOP;
using DAO.SOP;
using System.Data;
using System.IO;
using System.Data.OleDb;

namespace LN.SOP
{
  public class SOP_RegistroSanitarioLN
    {
        SOP_CAB_DAO sop_rrgg_Dao = new SOP_CAB_DAO();
        public List<SOP_Registro_Sanitario> ListadoRegistrosSanitarios()
        {
            return sop_rrgg_Dao.Listado_RegistrosSanitarios();

        }
        public List<SOP_Registro_Detalle>Lista_proy_privada(int usr_id)
        {
            return sop_rrgg_Dao.Lista_proy_privada(usr_id);

        }
        public List<SOP_Registro_Proy_Institucional> Lista_proy_institucional()
        {
            return sop_rrgg_Dao.Lista_proy_institucional();

        }
        public List<SOP_Fabricantes> RS_Listado_Fabricante()
        {
            return sop_rrgg_Dao.RS_Listado_Fabricante();

        }
        public List<SOP_Paises> RS_Listado_Paises()
        {
            return sop_rrgg_Dao.RS_Listado_Paises();

        }

        public List<SOP_Estados> RS_Listado_Estado()
        {
            return sop_rrgg_Dao.RS_Listado_Estado();

        }
        public List<SOP_Envases> RS_Listado_Envases()
        {
            return sop_rrgg_Dao.RS_Listado_Envases();

        }

        







        public SOP_Registro_Sanitario ObtenerRegistroSanitario(int cod_registro_sanitario)
        {
            return sop_rrgg_Dao.ObtenerRegistroSanitario(cod_registro_sanitario);
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
        public bool CargarArchivo_excel(int codigocotizacion, string dataimage, int usr_id)
        {
            DataTable tablaretorno = new DataTable();
            SOP_PRO_PRI Obj = new SOP_PRO_PRI();
            string XML = "";
            List<String> Columns = null;
            try
            {
                if (dataimage != "")
                {
                    string filePath = "D:\\archivo";
                    string NombreImagen = "AEXCDEVCSE.xlsx";
                    string finalpath = Path.Combine(filePath, NombreImagen);
                    Console.WriteLine(finalpath);
                    //Guardar archivo para poder recuperar
                    System.IO.File.WriteAllBytes(finalpath, Convert.FromBase64String(dataimage));
                    tablaretorno = ConvertExcelToDataTable(finalpath);
                    if (tablaretorno.Columns.Count >0)
                    {
                        Columns = new List<string>();
                        foreach (DataColumn columnrow in tablaretorno.Columns)
                        {
                            Columns.Add(columnrow.ColumnName);
                        }
                        if (tablaretorno.Rows.Count > 0)
                        {
                            
                            Obj.ListaCarga = new List<SOP_Registro_Detalle>();

                            foreach (DataRow item in tablaretorno.Rows)
                            {
                                String valor = "";
                                //tablaretorno.Columns
                                SOP_Registro_Detalle objDet = new SOP_Registro_Detalle();
                                valor = Columns.ElementAt(1).ToString();
                                objDet.anio_1 = valor.Substring(valor.Length-4, 4);
                                if (valor.Length == 5)
                                {
                                    objDet.mes_1 = valor.Substring(0,1);
                                }
                                else
                                {
                                    if (valor.Length == 6)
                                    {
                                        objDet.mes_1 = valor.Substring(0, 2);
                                    }
                                }
                                objDet.codigo_articulo = item["COD"].ToString().Trim();
                                objDet.usr_id = usr_id;  
                                objDet.mes_1= Columns.ElementAt(1).ToString().ToString().Trim();
                                objDet.mes_2 = Columns.ElementAt(2).ToString().ToString().Trim();
                                objDet.mes_3 = Columns.ElementAt(3).ToString().ToString().Trim();
                                objDet.mes_4 = Columns.ElementAt(4).ToString().ToString().Trim();
                                objDet.mes_5 = Columns.ElementAt(5).ToString().ToString().Trim();
                                objDet.mes_6 = Columns.ElementAt(6).ToString().ToString().Trim();
                                objDet.mes_7 = Columns.ElementAt(7).ToString().ToString().Trim();
                                objDet.mes_8 = Columns.ElementAt(8).ToString().ToString().Trim();
                                objDet.mes_9 = Columns.ElementAt(9).ToString().ToString().Trim();
                                objDet.mes_10 = Columns.ElementAt(10).ToString().ToString().Trim();
                                objDet.mes_11 = Columns.ElementAt(11).ToString().ToString().Trim();
                                objDet.mes_12 = Columns.ElementAt(12).ToString().ToString().Trim();

                                objDet.valor_enero =     Convert.ToDecimal(item[Columns.ElementAt(1).ToString()].ToString().Trim());
                                objDet.valor_febrero =   Convert.ToDecimal(item[Columns.ElementAt(2).ToString()].ToString().Trim());
                                objDet.valor_marzo =     Convert.ToDecimal(item[Columns.ElementAt(3).ToString()].ToString().Trim());
                                objDet.valor_abril =     Convert.ToDecimal(item[Columns.ElementAt(4).ToString()].ToString().Trim());
                                objDet.valor_mayo =      Convert.ToDecimal(item[Columns.ElementAt(5).ToString()].ToString().Trim());
                                objDet.valor_junio =     Convert.ToDecimal(item[Columns.ElementAt(6).ToString()].ToString().Trim());
                                objDet.valor_julio =     Convert.ToDecimal(item[Columns.ElementAt(7).ToString()].ToString().Trim());
                                objDet.valor_agosto =    Convert.ToDecimal(item[Columns.ElementAt(8).ToString()].ToString().Trim());
                                objDet.valor_setiembre = Convert.ToDecimal(item[Columns.ElementAt(9).ToString()].ToString().Trim());
                                objDet.valor_octubre =   Convert.ToDecimal(item[Columns.ElementAt(10).ToString()].ToString().Trim());
                                objDet.valor_noviembre = Convert.ToDecimal(item[Columns.ElementAt(11).ToString()].ToString().Trim());
                                objDet.valor_diciembre = Convert.ToDecimal(item[Columns.ElementAt(12).ToString()].ToString().Trim());
                               
                                objDet.valor_total =     Convert.ToDecimal(item["TOTAL"].ToString().Trim());


                                Obj.ListaCarga.Add(objDet);

                            }
                            if (Obj.ListaCarga.Count != 0)
                            {
                                XML = Obj.Serializar(Obj);
                            }


                        }

                    }



                    //bool result = File.Exists(finalpath);
                    //if (result == true)
                    //{
                    //    File.Delete(finalpath);
                    //}                                             
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return sop_rrgg_Dao.CargargarExcel(XML, usr_id);

        }





        public bool CargarArchivo_excel_FUNCIONA(int codigocotizacion, string dataimage)
        {
            DataTable tablaretorno = new DataTable();
            SOP_PRO_PRI Obj = new SOP_PRO_PRI();
            string XML = "";
            List<String> Columns = null;
            try
            {
                if (dataimage != "")
                {
                    string filePath = "D:\\archivo";
                    string NombreImagen = "AEXCDEVCSE.xlsx";
                    string finalpath = Path.Combine(filePath, NombreImagen);
                    Console.WriteLine(finalpath);
                    //Guardar archivo para poder recuperar
                    System.IO.File.WriteAllBytes(finalpath, Convert.FromBase64String(dataimage));
                    tablaretorno = ConvertExcelToDataTable(finalpath);
                    if (tablaretorno.Columns.Count > 0)
                    {
                        Columns = new List<string>();
                        foreach (DataColumn columnrow in tablaretorno.Columns)
                        {
                            Columns.Add(columnrow.ColumnName);
                        }
                        if (tablaretorno.Rows.Count > 0)
                        {

                            Obj.ListaCarga = new List<SOP_Registro_Detalle>();

                            foreach (DataRow item in tablaretorno.Rows)
                            {
                                String valor = "";
                                //tablaretorno.Columns
                                SOP_Registro_Detalle objDet = new SOP_Registro_Detalle();
                                valor = Columns.ElementAt(1).ToString();
                                objDet.anio_1 = valor.Substring(valor.Length - 4, 4);
                                if (valor.Length == 5)
                                {
                                    objDet.mes_1 = valor.Substring(0, 1);
                                }
                                else
                                {
                                    if (valor.Length == 6)
                                    {
                                        objDet.mes_1 = valor.Substring(0, 2);
                                    }
                                }
                                objDet.codigo_articulo = item["COD"].ToString().Trim();
                                objDet.mes_1 = Columns.ElementAt(1).ToString().ToString().Trim();
                                objDet.mes_12 = Columns.ElementAt(12).ToString().ToString().Trim();

                                objDet.valor_enero = Convert.ToDecimal(item[Columns.ElementAt(1).ToString()].ToString().Trim());
                                objDet.valor_marzo = Convert.ToDecimal(item[Columns.ElementAt(2).ToString()].ToString().Trim());
                                objDet.valor_abril = Convert.ToDecimal(item[Columns.ElementAt(3).ToString()].ToString().Trim());
                                objDet.valor_mayo = Convert.ToDecimal(item[Columns.ElementAt(4).ToString()].ToString().Trim());
                                objDet.valor_junio = Convert.ToDecimal(item[Columns.ElementAt(5).ToString()].ToString().Trim());
                                objDet.valor_julio = Convert.ToDecimal(item[Columns.ElementAt(6).ToString()].ToString().Trim());
                                objDet.valor_agosto = Convert.ToDecimal(item[Columns.ElementAt(7).ToString()].ToString().Trim());
                                objDet.valor_setiembre = Convert.ToDecimal(item[Columns.ElementAt(8).ToString()].ToString().Trim());
                                objDet.valor_octubre = Convert.ToDecimal(item[Columns.ElementAt(9).ToString()].ToString().Trim());
                                objDet.valor_noviembre = Convert.ToDecimal(item[Columns.ElementAt(10).ToString()].ToString().Trim());
                                objDet.valor_diciembre = Convert.ToDecimal(item[Columns.ElementAt(11).ToString()].ToString().Trim());
                                objDet.valor_febrero = Convert.ToDecimal(item[Columns.ElementAt(12).ToString()].ToString().Trim());
                                objDet.valor_total = Convert.ToDecimal(item["TOTAL"].ToString().Trim());


                                Obj.ListaCarga.Add(objDet);

                            }
                            if (Obj.ListaCarga.Count != 0)
                            {
                                XML = Obj.Serializar(Obj);
                            }


                        }

                    }



                    //bool result = File.Exists(finalpath);
                    //if (result == true)
                    //{
                    //    File.Delete(finalpath);
                    //}                                             
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return sop_rrgg_Dao.CargargarExcel(XML,1);

        }

        public bool CargarArchivo_excel_prueba(int codigocotizacion, string dataimage)
        {
            DataTable tablaretorno = new DataTable();
            SOP_PRO_PRI Obj = new SOP_PRO_PRI();
            string XML = "";
            List<String> Columns = null;
            try
            {
                if (dataimage != "")
                {
                    string filePath = "D:\\archivo";
                    string NombreImagen = "AEXCDEVCSE.xlsx";
                    string finalpath = Path.Combine(filePath, NombreImagen);
                    Console.WriteLine(finalpath);
                    //Guardar archivo para poder recuperar
                    System.IO.File.WriteAllBytes(finalpath, Convert.FromBase64String(dataimage));
                    tablaretorno = ConvertExcelToDataTable(finalpath);
                    if (tablaretorno.Columns.Count > 0)
                    {
                        Columns = new List<string>();
                        foreach (DataColumn columnrow in tablaretorno.Columns)
                        {
                            Columns.Add(columnrow.ColumnName);
                        }
                        if (tablaretorno.Rows.Count > 0)
                        {

                            Obj.ListaCarga = new List<SOP_Registro_Detalle>();

                            foreach (DataRow item in tablaretorno.Rows)
                            {
                                String valor = "";
                                //tablaretorno.Columns
                                SOP_Registro_Detalle objDet = new SOP_Registro_Detalle();
                                valor = Columns.ElementAt(1).ToString();
                                objDet.anio_1 = valor.Substring(valor.Length - 4, 4);
                                if (valor.Length == 5)
                                {
                                    objDet.mes_1 = valor.Substring(0, 1);
                                }
                                else
                                {
                                    if (valor.Length == 6)
                                    {
                                        objDet.mes_1 = valor.Substring(0, 2);
                                    }
                                }
                                objDet.codigo_articulo = item["COD"].ToString().Trim();
                                objDet.valor_enero = Convert.ToDecimal(item[Columns.ElementAt(1).ToString()].ToString().Trim());
                                objDet.valor_febrero = Convert.ToDecimal(item["CAJA FEBRERO 2022"].ToString().Trim());
                                objDet.valor_marzo = Convert.ToDecimal(item["CAJA MARZO 2022"].ToString().Trim());
                                objDet.valor_abril = Convert.ToDecimal(item["CAJA ABRIL 2022"].ToString().Trim());
                                objDet.valor_mayo = Convert.ToDecimal(item["CAJA MAYO 2022"].ToString().Trim());
                                objDet.valor_junio = Convert.ToDecimal(item["CAJA JUNIO 2022"].ToString().Trim());
                                objDet.valor_julio = Convert.ToDecimal(item["CAJA JULIO 2022"].ToString().Trim());
                                objDet.valor_agosto = Convert.ToDecimal(item["CAJA AGOSTO 2022"].ToString().Trim());
                                objDet.valor_setiembre = Convert.ToDecimal(item["CAJA SETIEMBRE 2022"].ToString().Trim());
                                objDet.valor_octubre = Convert.ToDecimal(item["CAJA OCTUBRE 2022"].ToString().Trim());
                                objDet.valor_noviembre = Convert.ToDecimal(item["CAJA NOVIEMBRE 2022"].ToString().Trim());
                                objDet.valor_diciembre = Convert.ToDecimal(item["CAJA DICIEMBRE 2022"].ToString().Trim());
                                objDet.valor_total = Convert.ToDecimal(item["TOTAL"].ToString().Trim());

                                Obj.ListaCarga.Add(objDet);

                            }
                            if (Obj.ListaCarga.Count != 0)
                            {
                                XML = Obj.Serializar(Obj);
                            }


                        }

                    }



                    //bool result = File.Exists(finalpath);
                    //if (result == true)
                    //{
                    //    File.Delete(finalpath);
                    //}
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return sop_rrgg_Dao.CargargarExcel(XML,1);

        }




        public bool CargarArchivo_excel_Institucional(int codigocotizacion, string dataimage)
        {
            DataTable tablaretorno = new DataTable();
            SOP_PRO_INST Obj = new SOP_PRO_INST();
            string XML = "";
            try
            {
                if (dataimage != "")
                {
                    string filePath = "D:\\archivo";
                    string NombreImagen = "AEXCDEVCSE_1.xlsx";
                    string finalpath = Path.Combine(filePath, NombreImagen);
                    Console.WriteLine(finalpath);
                    //Guardar archivo para poder recuperar
                    System.IO.File.WriteAllBytes(finalpath, Convert.FromBase64String(dataimage));
                    tablaretorno = ConvertExcelToDataTable(finalpath);
                    if (tablaretorno.Rows.Count > 0)
                    {
                        Obj.ListaCarga_Institucional = new List<SOP_Registro_Proy_Institucional>();
                        foreach (DataRow item in tablaretorno.Rows)
                        {
                            SOP_Registro_Proy_Institucional objDet = new SOP_Registro_Proy_Institucional();
                            objDet.proceso = item["proceso"].ToString().Trim();
                            objDet.entidad = item["entidad"].ToString().Trim();
                            objDet.codigo_articulo = item["codigo"].ToString().Trim();
                            objDet.cantidad_total = Convert.ToDecimal(item["cantidad_total"].ToString().Trim());
                            objDet.precio = Convert.ToDecimal(item["precio"].ToString().Trim());
                            objDet.importe = Convert.ToDecimal(item["inporte"].ToString().Trim());
                            objDet.plazo_entrega = Convert.ToDecimal(item["plazo_entrega"].ToString().Trim());
                            objDet.num_total_entregas = Convert.ToDecimal(item["num_total_entregas"].ToString().Trim());
                            objDet.num_controles = Convert.ToDecimal(item["num_controles"].ToString().Trim());
                            objDet.estatus_buena_pro = item["estatus_buena_pro"].ToString().Trim();
                            objDet.importe_pendiente_facturar = Convert.ToDecimal(item["importe_pendiente_facturar"].ToString().Trim());
                            objDet.pendiente_entregar_unidad = Convert.ToDecimal(item["pendiente_entregar_unidad"].ToString().Trim());
                            objDet.pendiente_entregar_cajas = Convert.ToDecimal(item["pendiente_entregar_cajas"].ToString().Trim());
                            objDet.pendiente_atencion_porcentaje = Convert.ToDecimal(item["pendiente_atencion_porcentaje"].ToString().Trim());
                            objDet.mes_1  = Convert.ToDecimal(item["MES_1"].ToString().Trim());
                            objDet.mes_2  = Convert.ToDecimal(item["MES_2"].ToString().Trim());
                            objDet.mes_3  = Convert.ToDecimal(item["MES_3"].ToString().Trim());
                            objDet.mes_4  = Convert.ToDecimal(item["MES_4"].ToString().Trim());
                            objDet.mes_5  = Convert.ToDecimal(item["MES_5"].ToString().Trim());
                            objDet.mes_6  = Convert.ToDecimal(item["MES_6"].ToString().Trim());
                            objDet.mes_7  = Convert.ToDecimal(item["MES_7"].ToString().Trim());
                            objDet.mes_8  = Convert.ToDecimal(item["MES_8"].ToString().Trim()); 
                            objDet.mes_9  = Convert.ToDecimal(item["MES_9"].ToString().Trim());
                            objDet.mes_10 = Convert.ToDecimal(item["MES_10"].ToString().Trim());
                            objDet.mes_11 = Convert.ToDecimal(item["MES_11"].ToString().Trim()); 
                            objDet.mes_12 = Convert.ToDecimal(item["MES_12"].ToString().Trim());
                           

                            Obj.ListaCarga_Institucional.Add(objDet);

                        }
                        if (Obj.ListaCarga_Institucional.Count != 0)
                        {
                            XML = Obj.Serializar(Obj);
                        }


                    }



                    //bool result = File.Exists(finalpath);
                    //if (result == true)
                    //{
                    //    File.Delete(finalpath);
                    //}
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return sop_rrgg_Dao.CargargarExcel_Institucional(XML);

        }

        public bool RegistroCodigoEmbarque(int usr_id, string codEmbarque)
        {
            return sop_rrgg_Dao.RegistroCodigoEmbarque(usr_id, codEmbarque);
        }


    }
}
