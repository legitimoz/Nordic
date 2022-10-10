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
   public class StockDAL
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        SqlCommand cmd = new SqlCommand();

        //buscar Cliente x Ruc
        public Stock ObtenerStock(string articulo,string almacen)
        {
            String sql;
            Stock stock = new Stock();
            try
            {
                //like a nombre 
                cn.Open();
             sql= "SELECT SK_CALMA, SK_CCODIGO, SK_NSKDIS FROM AL0020STOC WHERE SK_CCODIGO " +
                    "='"+ articulo.ToString()+"'"+" AND SK_CALMA='"+ almacen.ToString() + "'";
                
                cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    stock.codigo_almacen = dr["SK_CALMA"].ToString().Trim();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    stock.codigo_articulo = dr["SK_CCODIGO"].ToString().Trim();
                    
                    stock.stock = dr["SK_NSKDIS"].ToString().Trim();
                   
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return stock;
        }


    }
}
