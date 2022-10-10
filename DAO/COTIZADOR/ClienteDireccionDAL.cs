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
   public class ClienteDireccionDAL
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        SqlCommand cmd = new SqlCommand();

        //lista de clientes 
        public List<DireccionesCliente> ListadoClientesDirecciones(string ruccliente)
        {
            String sql,sql2;
            List<DireccionesCliente> listado = new List<DireccionesCliente>();
            try
            {
                cn.Open();
               
 sql = "SELECT DE_CCODCLI , DE_CCODUBI,DE_CDIRECC FROM FT0020CLID WHERE TRIM(DE_CCODCLI)='" + ruccliente.ToString().Trim() + "'";
                sql2 = "SELECT CASE WHEN CL_NEW.DE_CCODCLI IS NULL THEN Cli.DE_CCODCLI ELSE CL_NEW.DE_CCODCLI END DE_CCODCLI, "+
"CASE WHEN CL_NEW.DE_CCODCLI IS NULL THEN Cli.DE_CCODUBI ELSE CL_NEW.DE_CCODUBI END DE_CCODUBI, "+
"CASE WHEN CL_NEW.DE_CCODCLI IS NULL THEN Cli.DE_CDIRECC ELSE CL_NEW.DE_CDIRECC END DE_CDIRECC "+
"FROM FT0020CLID Cli "+
 " FULL JOIN BDSSENDA..CTZ_DIRCLI CL_NEW on Cli.DE_CCODCLI = CL_NEW.DE_CCODCLI WHERE CL_NEW.DE_CCODCLI="+
"'" + ruccliente.ToString().Trim() + "'" + "OR Cli.DE_CCODCLI = '" + ruccliente.ToString().Trim() + "'";             
                
                cmd = new SqlCommand(sql2, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DireccionesCliente direcciones = new DireccionesCliente();
                    direcciones.codigo = dr["DE_CCODCLI"].ToString();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    direcciones.codigoUbicacion = dr["DE_CCODUBI"].ToString();
                    direcciones.nombre = dr["DE_CDIRECC"].ToString();

                    listado.Add(direcciones);
                }
            }
            catch (Exception E)
            {
                throw E;
            }
            return listado;

        }

        public List<DireccionesCliente> ListadoClientesDirecciones_rz(string rs)
        {
            String sql, sql2;
            List<DireccionesCliente> listado = new List<DireccionesCliente>();
            try
            {
                cn.Open();

                sql = "SELECT DE_CCODCLI , DE_CCODUBI,DE_CDIRECC FROM FT0020CLID WHERE TRIM(DE_CCODCLI)='" + rs.ToString().Trim() + "'";
                sql2 = "SELECT CASE WHEN CL_NEW.DE_CCODCLI IS NULL THEN Cli.DE_CCODCLI ELSE CL_NEW.DE_CCODCLI END DE_CCODCLI, " +
"CASE WHEN CL_NEW.DE_CCODCLI IS NULL THEN Cli.DE_CCODUBI ELSE CL_NEW.DE_CCODUBI END DE_CCODUBI, " +
"CASE WHEN CL_NEW.DE_CCODCLI IS NULL THEN Cli.DE_CDIRECC ELSE CL_NEW.DE_CDIRECC END DE_CDIRECC " +
"FROM FT0020CLID Cli " +
 " FULL JOIN BDSSENDA..CTZ_DIRCLI CL_NEW on Cli.DE_CCODCLI = CL_NEW.DE_CCODCLI WHERE CL_NEW.DE_CCODCLI=" +
"'" + rs.ToString().Trim() + "'" + "OR Cli.DE_CCODCLI = '" + rs.ToString().Trim() + "'";

                cmd = new SqlCommand(sql2, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DireccionesCliente direcciones = new DireccionesCliente();
                    direcciones.codigo = dr["DE_CCODCLI"].ToString();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    direcciones.codigoUbicacion = dr["DE_CCODUBI"].ToString();
                    direcciones.nombre = dr["DE_CDIRECC"].ToString();

                    listado.Add(direcciones);
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
