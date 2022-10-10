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
  public class PermisoDAL
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_BDLABFAR"].ToString());
        SqlCommand cmd = new SqlCommand();

        //lista de Permisos para el perfil de determinado Usuario 
        public List<Permisos> ListadoPermisos_usuario(int id_perfil, int id_usuario)
        {
            String sql;
            List<Permisos> listado = new List<Permisos>();
            try
            {
                cn.Open();
                // orginal sql = "select CL_CCODCLI,CL_CNOMCLI from FT0020CLIE where CL_CESTADO ='V' ";
                //sql = "SELECT TOP 600 AR_CFSTOCK,AR_CCODIGO,AR_CDESCRI, AR_CUNIDAD,AR_NPRECI2,AR_NPRECI1 ,AR_NPRECI3,AR_NPRECI4 FROM AL0020ARTI ";

                sql= "select DetPer.det_idperfil,Usu.usr_nombre,Per.per_nombreformulario,Per.per_nombrepermiso FROM DetallePermisos DetPer " +
                "LEFT JOIN Permiso Per on DetPer.det_idpermiso = Per.per_idpermiso "+
                "LEFT JOIN Usuarios Usu on Usu.per_id = DetPer.det_idperfil "
                    + "where Usu.usr_id=" + id_usuario + "AND DetPer.det_idperfil="+id_perfil+ " AND Per.id_aplicativo=2";



                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Permisos permisos = new Permisos();
                    permisos.nombreFormulario = dr["per_nombreformulario"].ToString();
                    permisos.nombrePermiso = dr["per_nombrepermiso"].ToString();
                    permisos.idperfil = Convert.ToInt32(dr["det_idperfil"].ToString());

                    //permisos.codigo = dr["AR_CCODIGO"].ToString();
                    //permisos.nombre = dr["AR_CDESCRI"].ToString();
                    //permisos.stock = dr["AR_CFSTOCK"].ToString();
                    //permisos.unidad = dr["AR_CUNIDAD"].ToString();


                    listado.Add(permisos);
                }
            }
            catch (Exception E)
            {
                throw E;
            }
            return listado;

        }

        //buscar Cliente x Ruc
        //public Articulo ObtenerArticulo(string codigo)
        //{
        //    String sql;
        //    Articulo articulo = new Articulo();
        //    try
        //    {
        //        //like a nombre 
        //        cn.Open();
        //        sql = "SELECT AR_CCODIGO,AR_CDESCRI, AR_CUNIDAD,AR_NPRECI2,AR_NPRECI1 ,AR_NPRECI3," +
        //            "AR_NPRECI4,AR_CFSTOCK FROM AL0020ARTI WHERE AR_CCODIGO='" + codigo.ToString() + "'";




        //        cmd = new SqlCommand(sql, cn);

        //        SqlDataReader dr = cmd.ExecuteReader();
        //        dr.Read();
        //        if (dr.HasRows)
        //        {
        //            articulo.codigo = dr["AR_CCODIGO"].ToString().Trim();
        //            //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
        //            articulo.nombre = dr["AR_CDESCRI"].ToString().Trim();
        //            articulo.unidad = dr["AR_CUNIDAD"].ToString().Trim();
        //            articulo.stock = dr["AR_CFSTOCK"].ToString().Trim();
        //            articulo.preciouno = dr["AR_NPRECI1"].ToString();
        //            articulo.preciodos = dr["AR_NPRECI1"].ToString();
        //            articulo.preciotres = dr["AR_NPRECI1"].ToString();
        //            articulo.preciocuatro = dr["AR_NPRECI1"].ToString();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return articulo;
        //}


    }
}
