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
   public class FormaVentaDAL
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        SqlCommand cmd = new SqlCommand();


        //lista de forma de ventas 
        public List<FormaVenta> ListaFormaVenta(int numero_dias)
        {
            String sql,sql2, Salida = "";
            List<FormaVenta> listado = new List<FormaVenta>();
            try
            {
                cn.Open();
               // sql = "select CL_CCODCLI,CL_CNOMCLI from FT0020CLIE where CL_CESTADO ='V' ";

           sql=   "SELECT top 5  FV.FV_CCODIGO,FV.FV_CDESCRI,FV.FV_NDIASV FROM FT0020FORV FV "+
                "left join FT0020CLIE CLI on FV.FV_CCODIGO = CLI.CL_CTIPVTA ";

                sql2 = "SELECT FV_CCODIGO,FV_CDESCRI,FV_NDIASV FROM "+
"RSFACCAR_SS..FT0020FORV WHERE FV_NDIASV<= "+ numero_dias + "AND FV_NDIASV> 1 AND NOT FV_CDESCRI LIKE'FACTURA%' "+
"AND NOT FV_CDESCRI LIKE'LETRA%' AND NOT FV_CDESCRI LIKE'CHEQUE%' AND NOT FV_CDESCRI LIKE'CONS%' AND NOT FV_CCODIGO LIKE'L%' AND NOT FV_CDESCRI LIKE'%DIRECT%'  " +
"UNION "+
"SELECT FV_CCODIGO,FV_CDESCRI,FV_NDIASV FROM "+
"RSFACCAR_SS..FT0020FORV WHERE FV_CCODIGO = 'C02' "+
"ORDER BY FV_NDIASV DESC";


                
              // orginal  sql = "SELECT FV_CCODIGO,FV_CDESCRI ,FV_NDIASV FROM FT0020FORV FV  " +
               // "left join FT0020CLIE CLI on FV.FV_CCODIGO = CLI.CL_CTIPVTA ";
       // "WHERE CLI.CL_CCODCLI ='"+ruc_cliente.ToString()+"'";

                cmd = new SqlCommand(sql2, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    FormaVenta formaventa = new FormaVenta();
                    formaventa.codigo = dr["FV_CCODIGO"].ToString();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    formaventa.nombre = dr["FV_CDESCRI"].ToString();
                    formaventa.numero_dias =Convert.ToInt32(dr["FV_NDIASV"]);
                    listado.Add(formaventa);
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
