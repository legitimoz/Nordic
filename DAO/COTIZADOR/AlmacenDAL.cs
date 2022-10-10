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
   public class AlmacenDAL
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        SqlCommand cmd = new SqlCommand();


        //lista de Almacenes 
        public List<Almacen> ListadoAlmacenes()
        {
            String sql, Salida = "";
            List<Almacen> listado = new List<Almacen>();
            try
            {
                cn.Open();
                // orginal sql = "select CL_CCODCLI,CL_CNOMCLI from FT0020CLIE where CL_CESTADO ='V' ";
                sql = "SELECT * FROM AL0020ALMA";

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Almacen almacen = new Almacen();
                    almacen.codigo = dr["A1_CALMA"].ToString();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    almacen.nombre = dr["A1_CDESCRI"].ToString();
                    

                    listado.Add(almacen);
                }
            }
            catch (Exception E)
            {
                throw;
            }
            return listado;

            //PROBANDO panchis

        }



    }
}
