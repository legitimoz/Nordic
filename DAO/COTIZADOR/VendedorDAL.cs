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
    public class VendedorDAL
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        SqlCommand cmd = new SqlCommand();

        //lista de Vendedores 
        public List<VendedorE> ListadoVendedores(string cod_vendedor)
        {
            String sql, Salida = "";
            List<VendedorE> listado = new List<VendedorE>();
            try
            {
                cn.Open();
                // orginal sql = "select CL_CCODCLI,CL_CNOMCLI from FT0020CLIE where CL_CESTADO ='V' ";
  sql = "SELECT VE.VE_CCODIGO,VE.VE_CNOMBRE FROM FT0020VEND VE " +
   "inner join BDSSENDA..Usuarios Us on Us.usr_usuario = VE.VE_CCODIGO where Us.usr_usuario = '"+ cod_vendedor.ToString()+"'";

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    VendedorE vendedor = new VendedorE();
                    vendedor.codigo = dr["VE_CCODIGO"].ToString();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    vendedor.nombre = dr["VE_CNOMBRE"].ToString();
                  //  vendedor.telefono= dr["VE_CTELEFO"].ToString();
                  //  vendedor.correo = dr["VE_CEMAIL"].ToString();
  
                    listado.Add(vendedor);
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
