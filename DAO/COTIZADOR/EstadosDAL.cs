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
    public class EstadosDAL
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_senda"].ToString());
        SqlCommand cmd = new SqlCommand();


        //lista de clientes 
        public List<EstadoE> ListadoEstados()
        {
            String sql;
            List<EstadoE> listado = new List<EstadoE>();
            try
            {
                cn.Open();

                sql = "SELECT est_codigo,est_descripcion,id_app FROM ESTADOS where id_app=2";

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EstadoE estados = new EstadoE();
                    estados.cod = dr["est_codigo"].ToString();
                    estados.descripcion = dr["est_descripcion"].ToString();
                    estados.cod_aplicacion = Convert.ToInt32(dr["id_app"].ToString());
                   
                    listado.Add(estados);
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
