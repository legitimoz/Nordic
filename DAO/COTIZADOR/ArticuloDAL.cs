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
   public  class ArticuloDAL
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        SqlCommand cmd = new SqlCommand();

        //lista de clientes 
        public List<Articulo> ListadoArticulos(string stock)
        {
            String sql;
            List<Articulo> listado = new List<Articulo>();
            try
            {
                cn.Open();
                // orginal sql = "select CL_CCODCLI,CL_CNOMCLI from FT0020CLIE where CL_CESTADO ='V' ";
                //sql = "SELECT TOP 600 AR_CFSTOCK,AR_CCODIGO,AR_CDESCRI, AR_CUNIDAD,AR_NPRECI2,AR_NPRECI1 ,AR_NPRECI3,AR_NPRECI4 FROM AL0020ARTI ";
                sql = "SELECT stock.SK_CALMA,stock.SK_NSKDIS ,art.AR_CCODIGO,art.AR_CDESCRI, art.AR_CUNIDAD,art.AR_NPRECI2,art.AR_NPRECI1 ,art.AR_NPRECI3, art.AR_NPRECI4,art.AR_CFSTOCK FROM AL0020ARTI art " +
                    "inner join  AL0020STOC stock on stock.SK_CCODIGO = art.AR_CCODIGO  " +
                    "where stock.SK_NSKDIS >= 0 AND stock.SK_CALMA ='" + stock.ToString() + "'"+
                    "ORDER BY stock.SK_NSKDIS DESC"; ;



                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Articulo articulo = new Articulo();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());

                    articulo.codigo = dr["AR_CCODIGO"].ToString();
                    articulo.nombre = dr["AR_CDESCRI"].ToString();
                    articulo.stock = dr["SK_NSKDIS"].ToString();
                    articulo.unidad = dr["AR_CUNIDAD"].ToString();
                    articulo.preciouno = dr["AR_NPRECI1"].ToString();
                    articulo.preciodos = dr["AR_NPRECI1"].ToString();
                    articulo.preciotres = dr["AR_NPRECI1"].ToString();
                    articulo.preciocuatro = dr["AR_NPRECI1"].ToString();


                    listado.Add(articulo);
                }
            }
            catch (Exception E)
            {
                throw E;
            }
            return listado;

        }

        public List<Articulo> ListademodelosArticulo()
        {
            String sql,sql3;
            List<Articulo> listado = new List<Articulo>();
            try
            {
                cn.Open();
                // orginal sql = "select CL_CCODCLI,CL_CNOMCLI from FT0020CLIE where CL_CESTADO ='V' ";
                //sql = "SELECT TOP 600 AR_CFSTOCK,AR_CCODIGO,AR_CDESCRI, AR_CUNIDAD,AR_NPRECI2,AR_NPRECI1 ,AR_NPRECI3,AR_NPRECI4 FROM AL0020ARTI ";
               sql3 = "SELECT * FROM RSFACCAR_SS..AL0020TABL WHERE TG_CCOD  = '39'";

              //  sql = "SELECT stock.SK_CALMA,stock.SK_NSKDIS ,art.AR_CCODIGO,art.AR_CDESCRI, art.AR_CUNIDAD,art.AR_NPRECI2,art.AR_NPRECI1 ,art.AR_NPRECI3, art.AR_NPRECI4,art.AR_CFSTOCK FROM AL0020ARTI art " +
                //    "inner join  AL0020STOC stock on stock.SK_CCODIGO = art.AR_CCODIGO  ";
                    



                cmd = new SqlCommand(sql3, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Articulo articulo = new Articulo();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());

                    articulo.cod_modelos = dr["TG_CCLAVE"].ToString();
                    articulo.modelos = dr["TG_CDESCRI"].ToString();
                    //articulo.stock = dr["AR_CFSTOCK"].ToString();
                    //articulo.unidad = dr["AR_CUNIDAD"].ToString();
                    //articulo.preciouno = dr["AR_NPRECI1"].ToString();
                    //articulo.preciodos = dr["AR_NPRECI1"].ToString();
                    //articulo.preciotres = dr["AR_NPRECI1"].ToString();
                    //articulo.preciocuatro = dr["AR_NPRECI1"].ToString();


                    listado.Add(articulo);
                }
                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return listado;

        }

        //buscar Cliente x Ruc
        public Articulo ObtenerArticulo(string codigo)
        {
            String sql;
            Articulo articulo = new Articulo();
            try
            {
                //like a nombre 
                cn.Open();
                sql = "SELECT art.AR_CCODIGO,art.AR_CDESCRI,art.AR_CUNIDAD,art.AR_NPRECI2,art.AR_NPRECI1 ,art.AR_NPRECI3," +
                    "art.AR_NPRECI4,stock.SK_NSKDIS FROM AL0020ARTI art " +
                    "inner join  AL0020STOC stock on stock.SK_CCODIGO = art.AR_CCODIGO  " +
                    "WHERE art.AR_CCODIGO='" + codigo.ToString() + "' "+
                    "AND stock.SK_CALMA ='CA01'";
               



                cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    articulo.codigo = dr["AR_CCODIGO"].ToString().Trim();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    articulo.nombre = dr["AR_CDESCRI"].ToString().Trim();
                    articulo.unidad = dr["AR_CUNIDAD"].ToString().Trim();
                    articulo.stock = dr["SK_NSKDIS"].ToString().Trim();
                    articulo.preciouno = dr["AR_NPRECI1"].ToString();
                    articulo.preciodos = dr["AR_NPRECI1"].ToString();
                    articulo.preciotres = dr["AR_NPRECI1"].ToString();
                    articulo.preciocuatro = dr["AR_NPRECI1"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return articulo;
         }

        public Articulo ObtenerStockArticulo(string codigo)
        {
            String sql;
            Articulo articulo = new Articulo();
            try
            {
                //like a nombre 
                cn.Open();
                sql = "SELECT AR_CCODIGO,AR_CDESCRI, AR_CUNIDAD,AR_NPRECI2,AR_NPRECI1 ,AR_NPRECI3," +
                    "AR_NPRECI4,AR_CFSTOCK FROM AL0020ARTI WHERE AR_CCODIGO='" + codigo.ToString() + "'";




                cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    articulo.codigo = dr["AR_CCODIGO"].ToString().Trim();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    articulo.nombre = dr["AR_CDESCRI"].ToString().Trim();
                    articulo.unidad = dr["AR_CUNIDAD"].ToString().Trim();
                    articulo.stock = dr["AR_CFSTOCK"].ToString().Trim();
                    articulo.preciouno = dr["AR_NPRECI1"].ToString();
                    articulo.preciodos = dr["AR_NPRECI1"].ToString();
                    articulo.preciotres = dr["AR_NPRECI1"].ToString();
                    articulo.preciocuatro = dr["AR_NPRECI1"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return articulo;
        }

        public List<Articulo> ObtenerArticuloParaSelect(string codigo)
        {
            String sql;
            List<Articulo> listado = new List<Articulo>();
            try
            {
                //like a nombre 
                cn.Open();
                sql = "SELECT AR_CCODIGO,AR_CDESCRI, AR_CUNIDAD,AR_NPRECI2,AR_NPRECI1 ,AR_NPRECI3," +
                    "AR_NPRECI4,AR_CFSTOCK FROM AL0020ARTI WHERE AR_CDESCRI LIKE'" + codigo.ToString() + "%'";

                cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.codigo = dr["AR_CCODIGO"].ToString().Trim();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    articulo.nombre = dr["AR_CDESCRI"].ToString().Trim();
                    articulo.unidad = dr["AR_CUNIDAD"].ToString().Trim();
                    articulo.stock = dr["AR_CFSTOCK"].ToString().Trim();
                    articulo.preciouno = dr["AR_NPRECI1"].ToString();
                    articulo.preciodos = dr["AR_NPRECI1"].ToString();
                    articulo.preciotres = dr["AR_NPRECI1"].ToString();
                    articulo.preciocuatro = dr["AR_NPRECI1"].ToString();
                    listado.Add(articulo);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listado;
        }

        public List<Articulo> ListadoArticulosFiltrados(string cod,string descrip , string almacen,string modelo)
        {
            String sql;
            List<Articulo> listado = new List<Articulo>();
            try
            {
                cn.Open();
                sql = "select TOP 15 AR.AR_CUNIDAD,AR.AR_CCODIGO,AR.AR_CDESCRI,stock.SK_NSKDIS,AR.AR_NPRECI1 from AL0020ARTI AR " +
                    "LEFT JOIN  AL0020STOC stock on stock.SK_CCODIGO = AR.AR_CCODIGO " +
                    "LEFT JOIN AL0020TABL TB ON TB.TG_CCLAVE = AR.AR_CMODELO " +
                    "WHERE AR.AR_CDESCRI LIKE '%"+descrip.ToString()+"%' " +
                    "AND AR.AR_CCODIGO LIKE '"+cod.ToString()+"%' " +
                    "AND stock.SK_CALMA = '"+almacen.ToString()+"' " +
                    "OR TB.TG_CCLAVE='"+modelo.ToString()+"'" +
                    "ORDER  BY stock.SK_NSKDIS DESC";


                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Articulo articulo = new Articulo();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());

                    articulo.codigo = dr["AR_CCODIGO"].ToString().Trim();
                    articulo.nombre = dr["AR_CDESCRI"].ToString();
                    articulo.stock = dr["SK_NSKDIS"].ToString();
                    articulo.unidad = dr["AR_CUNIDAD"].ToString();
                    articulo.preciouno = dr["AR_NPRECI1"].ToString();
             


                    listado.Add(articulo);
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
