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
    public class MonitoreoDAO
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_senda"].ToString());
        SqlCommand cmd = new SqlCommand();

        //monitor ctz 
        public List<Monitoreo> lista_monitoreo()
        {
            String sql, Salida = "";
            List<Monitoreo> listado = new List<Monitoreo>();
            try
            {
                cn.Open();

                //  sql = "SELECT CO.codigo,"+
                //  "CASE WHEN CLI.CL_CCODCLI IS NULL THEN cl.CL_CNOMCLI "+
                //  "WHEN CLI.CL_CCODCLI IS NOT NULL THEN cli.CL_CNOMCLI end CL_CNOMCLI,"+ 
                //	"V.VE_CNOMBRE ,"+ 
                //  "CO.fecharegistro ,"+
                //  "CO.fechaaprobacion ,"+
                //	"A.F5_DFECCRE ,"+
                //	"A.F5_CNUMPED ,"+
                //	"(A.F5_CNUMSER + F5_CNUMDOC) as guia "+
                //  "FROM[dbo].[Cab_Cotizacion_v1] CO "+
                //  "LEFT JOIN RSFACCAR_SS..PD0020PENC A ON CO.F5_CCODAGE = A.F5_CCODAGE AND CO.F5_CNUMPED = A.F5_CNUMPED "+
                //  "LEFT JOIN ClienteNuevo_Coti Cl ON CO.cliente = Cl.CL_CCODCLI "+
                //  "LEFT JOIN RSFACCAR_SS..FT0020CLIE CLI ON CO.cliente = CLI.CL_CCODCLI "+
                //  "LEFT JOIN RSFACCAR_SS..FT0020VEND V ON   CO.vendedor = V.VE_CCODIGO "+
                //  "LEFT JOIN RSFACCAR_SS..AL0020MOVC C ON A.F5_CTD = C.C5_CTD AND(A.F5_CNUMSER + A.F5_CNUMDOC) = C.C5_CNUMDOC "+
                //  "WHERE CONVERT(DATE, CO.fecharegistro) = CONVERT(DATE, GETDATE() - 4)";


                sql = "SELECT CO.codigo," +
               "CASE WHEN CLI.CL_CCODCLI IS NULL THEN cl.CL_CNOMCLI " +
               "WHEN CLI.CL_CCODCLI IS NOT NULL THEN cli.CL_CNOMCLI end CL_CNOMCLI," +
               "V.VE_CNOMBRE ," +
               "CO.fecharegistro ," +
               "CO.fechaaprobacion ," +
               "A.F5_DFECCRE ," +
              "A.F5_CNUMPED ," +
               "(A.F5_CNUMSER + F5_CNUMDOC) as guia " +
"FROM[dbo].[Cab_Cotizacion_v1] CO " +
     "LEFT JOIN RSFACCAR_SS..PD0020PENC A ON CO.F5_CCODAGE = A.F5_CCODAGE AND CO.F5_CNUMPED = A.F5_CNUMPED " +
      "LEFT JOIN ClienteNuevo_Coti Cl ON CO.cliente = Cl.CL_CCODCLI " +
      "LEFT JOIN RSFACCAR_SS..FT0020CLIE CLI ON CO.cliente = CLI.CL_CCODCLI " +
      "LEFT JOIN RSFACCAR_SS..FT0020VEND V ON   CO.vendedor = V.VE_CCODIGO " +
      "LEFT JOIN RSFACCAR_SS..AL0020MOVC C ON A.F5_CTD = C.C5_CTD AND(A.F5_CNUMSER + A.F5_CNUMDOC) = C.C5_CNUMDOC " +
"WHERE CONVERT(DATE, CO.fecharegistro) = CONVERT(DATE, GETDATE() - 3)";


                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Monitoreo monitoreo = new Monitoreo();
                    monitoreo.cotizacion = dr["codigo"].ToString();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    monitoreo.cliente = dr["CL_CNOMCLI"].ToString();
                    monitoreo.vendedor = dr["VE_CNOMBRE"].ToString();
                    monitoreo.fechaaprobacion = dr["fechaaprobacion"].ToString();
                    monitoreo.fechacreacion = dr["fecharegistro"].ToString();
                    monitoreo.pedido = dr["F5_DFECCRE"].ToString();
                    monitoreo.numeroguia = dr["guia"].ToString();
                    monitoreo.numeropedido = dr["F5_CNUMPED"].ToString();
                   
                    //  cotizacion.validador_stock = Convert.ToInt32(dr["stock"].ToString());

                    listado.Add(monitoreo);
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
