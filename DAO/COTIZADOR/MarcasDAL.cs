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
    public class MarcasDAL
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        SqlCommand cmd = new SqlCommand();


        public List<Marcas> ListadoMarcas()
        {
            String sql, Salida="" ;
            List<Marcas> listado = new List<Marcas>();
            try
            {
                cn.Open();
                sql = "select * from Marcas";
                cmd = new SqlCommand(sql, cn);

                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Marcas persona = new Marcas();
                    //se tiene que convertir a int
                    persona.mar_id = Convert.ToInt32(dr["mar_id"]);
                    persona.mar_descripcion = dr["mar_descripcion"].ToString();
                    persona.mar_std = Convert.ToChar(dr["mar_est"].ToString());
                    
                    listado.Add(persona);
                }
            }
            catch (Exception E)
            {
                throw;
            }
            return listado;

        }

    }
}
