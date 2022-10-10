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
    public class MotivoDAL
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_senda"].ToString());
        SqlCommand cmd = new SqlCommand();

        //lista de Motivos 
        public List<Motivo> ListadoMotivos()
        {
            String sql, Salida = "";
            List<Motivo> listado = new List<Motivo>();
            try
            {
                cn.Open();
                // orginal sql = "select CL_CCODCLI,CL_CNOMCLI from FT0020CLIE where CL_CESTADO ='V' ";
                sql = "SELECT mot_id , mot_des FROM Motivo";
                
                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Motivo motivo = new Motivo();
                    motivo.id = Convert.ToInt32(dr["mot_id"].ToString());
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    motivo.descripcion = dr["mot_des"].ToString();

                    listado.Add(motivo);
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
