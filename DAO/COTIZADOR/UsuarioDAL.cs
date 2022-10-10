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
   public class UsuarioDAL
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_BDLABFAR"].ToString());
        SqlCommand cmd = new SqlCommand();


        //Encontrar Usuario 
        public Usuario ObtenerUsuario(string usuario,string codigo)
        {
            String sql;
            Usuario usuario_buscado= new Usuario();
            try
            {
            //like a nombre 
            cn.Open();
            sql = "SELECT * FROM BDLABFAR..USUARIOS WHERE " +
            "USR_USUARIO='" + usuario.ToString() + "'"+ " AND USR_CLAVE=" + "'" + codigo.ToString() + "'";

                cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    usuario_buscado.idusuario = Convert.ToInt32(dr["usr_id"].ToString().Trim());
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    usuario_buscado.estado = Convert.ToChar(dr["usr_estado"].ToString().Trim());
                    usuario_buscado.alias = dr["usr_usuario"].ToString().Trim();
                    usuario_buscado.clave = dr["usr_clave"].ToString().Trim();
                    usuario_buscado.nombre_usuario = dr["usr_nombre"].ToString().Trim();
                    
                  usuario_buscado.perfil = Convert.ToInt32(dr["per_id"].ToString());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return usuario_buscado;
        }


    }
}
