using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DAO
{
   public class DetalleFinancieraClienteDAO
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        SqlCommand cmd = new SqlCommand();


        public DetalleFinancieroCliente ObtenerDetalleFinanciero(string ruccliente)
        {
            String sql;
            DetalleFinancieroCliente det_fnz_cli = new DetalleFinancieroCliente();
            try
            {
                //like a nombre 
                cn.Open();
     sql = "SELECT B.CL_NLMCRMN ,MAX( DATEDIFF(DD, A.CD_DFECVEN, GETDATE()))AS DIASVENCIDOS " +
        ",SUM( A.CD_NSALDMN) AS SALDO_DISPONIBLE FROM CC0020CART A "+
        "INNER JOIN FT0020CLIE B ON A.CD_CCODCLI = B.CL_CCODCLI "+
        "LEFT JOIN  CC0020LETR C On A.CD_CTIPDOC = 'LT' AND A.CD_CNRODOC = C.LT_CNROLET AND A.CD_CCODCLI = C.LT_CCODCLI AND C.LT_CSITUAC = 'COPR' "+
        "LEFT JOIN  CC0020BANC D On C.LT_CCODBAN = D.BC_CCODBAN "+
        "WHERE NOT(A.CD_CESTADO = 'S' OR A.CD_CESTADO = 'A') "+
        "AND A.CD_CLOCEMI IN('0001') "+
        "AND convert(datetime, A.CD_DFECVEN,103) between Convert(datetime, DATEADD(YEAR, -4, GETDATE()),103) AND Convert(datetime, DATEADD(YEAR, 2, GETDATE()),103) " +  
        "AND A.CD_CCODCLI = '"+ruccliente.ToString()+"' "+
        "AND A.CD_CTIPDOC IN('FT','BV','LT') GROUP BY B.CL_NLMCRMN ";
 
                cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    det_fnz_cli.limite_credito = dr["CL_NLMCRMN"].ToString().Trim();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    det_fnz_cli.dias_vencidos = dr["DIASVENCIDOS"].ToString().Trim();
                    det_fnz_cli.saldo_disponible = dr["SALDO_DISPONIBLE"].ToString().Trim();
 
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return det_fnz_cli;
        }

        public List<DocumentosVencidosCliente> Lista_documentos_vencidos(string ruccliente)
        {
            String sql,sql_2;
            List<DocumentosVencidosCliente> listado = new List<DocumentosVencidosCliente>();

            try
            {
cn.Open();

                sql_2 = "SELECT CD_CTIPDOC AS TD," +
"CD_CNRODOC AS[NUM DOC]," +
"VEND = Case When VE_CTIPVEN = 'F' Then CD_CCODVEN+'/' + VE_CCODLIN Else CD_CCODVEN End," +
"CD_DFECDOC As[FECHA EMI.]" +
",CD_DFECVEN As[FECHA VEN.]," +
"CD_DFECCAN As[FECHA CANC]," +
"CD_CTIPMON As[MO]," +
"CD_NIMPTMN As[IMPORTE]," +
"SALDO = CASE CD_CTIPMON When 'MN' Then CD_NSALDMN Else CD_NSALDUS End," +
"VENC = Case When Datediff(day, CD_DFECVEN, Getdate()) is null Then 0When Datediff(day, CD_DFECVEN, Getdate())< 0 then 0 " +
"When Datediff(day, CD_DFECVEN, Getdate())> 999 then 999 " +
"Else Datediff(day, CD_DFECVEN, Getdate()) End, CD_CTDOREF AS TDR,CD_CNROREF AS[NUM.DOC.REF.] " +
"FROM RSFACCAR_SS..CC0020CART LEFT JOIN RSFACCAR_SS..CC0020LETR On CD_CTIPDOC = 'LT' AND CD_CNRODOC = LT_CNROLET " +
"LEFT JOIN RSFACCAR_SS..CC0020BANC On LT_CCODBAN = BC_CCODBAN " +
"LEFT JOIN RSFACCAR_SS..FT0020VEND On CD_CCODVEN = VE_CCODIGO WHERE CD_CCODCLI = '" + ruccliente.ToString() + "' AND NOT(CD_CESTADO= 'S' or CD_CESTADO = 'A') ";
                
sql = "SELECT CD_CTIPDOC," +
"CD_CNRODOC," +
"VEND = Case When VE_CTIPVEN = 'F' Then CD_CCODVEN+'/' + VE_CCODLIN Else CD_CCODVEN End," +
"CD_DFECDOC " +
",CD_DFECVEN ," +
"CD_DFECCAN ," +
"CD_CTIPMON ," +
"CD_NIMPTMN ," +
"SALDO = CASE CD_CTIPMON When 'MN' Then CD_NSALDMN Else CD_NSALDUS End," +
"VENC = Case When Datediff(day, CD_DFECVEN, Getdate()) is null Then 0When Datediff(day, CD_DFECVEN, Getdate())< 0 then 0 " +
"When Datediff(day, CD_DFECVEN, Getdate())> 999 then 999 " +
"Else Datediff(day, CD_DFECVEN, Getdate()) End, CD_CTDOREF ,CD_CNROREF " +
"FROM RSFACCAR_SS..CC0020CART LEFT JOIN RSFACCAR_SS..CC0020LETR On CD_CTIPDOC = 'LT' AND CD_CNRODOC = LT_CNROLET " +
"LEFT JOIN RSFACCAR_SS..CC0020BANC On LT_CCODBAN = BC_CCODBAN " +
"LEFT JOIN RSFACCAR_SS..FT0020VEND On CD_CCODVEN = VE_CCODIGO WHERE CD_CCODCLI = '"+ ruccliente.ToString()+"' AND NOT(CD_CESTADO= 'S' or CD_CESTADO = 'A') ";
      
                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DocumentosVencidosCliente doc_vencidos = new DocumentosVencidosCliente();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    doc_vencidos.tipo_documento = dr["CD_CTIPDOC"].ToString();
                    doc_vencidos.numero_documento = dr["CD_CNRODOC"].ToString();
                    doc_vencidos.vendedor = dr["VEND"].ToString();
                    doc_vencidos.fecha_emision = dr["CD_DFECDOC"].ToString();
                    doc_vencidos.fecha_vencimiento = dr["CD_DFECVEN"].ToString();
                    doc_vencidos.fecha_cancelacion = dr["CD_DFECCAN"].ToString();
                    doc_vencidos.motivo = dr["CD_CTIPMON"].ToString();
                    doc_vencidos.importe = dr["CD_NIMPTMN"].ToString();
                    doc_vencidos.saldo = dr["SALDO"].ToString();
                    doc_vencidos.vencimiento = dr["VENC"].ToString();
                    doc_vencidos.tdr = dr["CD_CTDOREF"].ToString();
                    doc_vencidos.numero_doc_referencia = dr["CD_CNROREF"].ToString();


                    listado.Add(doc_vencidos);
                }
            }
            catch (Exception E)
            {
                throw E;
            }



            return listado;
        }
    }
}
