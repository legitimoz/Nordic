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
    public class TransportistasDAL
    {

        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        SqlCommand cmd = new SqlCommand();


        //lista de Almacenes 
        public List<Transportista> ListadoTransportistas()
        {
            String sql, Salida = "";
            List<Transportista> listado = new List<Transportista>();
            try
            {
                cn.Open();
                // orginal sql = "select CL_CCODCLI,CL_CNOMCLI from FT0020CLIE where CL_CESTADO ='V' ";
                sql = "SELECT  TR_CCODIGO, TR_CNOMBRE FROM AL0020TRAN WHERE TR_CESTADO = 'V'";

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Transportista transportista = new Transportista();
                    transportista.codigo = dr["TR_CCODIGO"].ToString();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    transportista.nombre = dr["TR_CNOMBRE"].ToString();


                    listado.Add(transportista);
                }
            }
            catch (Exception E)
            {
                throw;
            }
            return listado;

        }

        public Transportista ObtenerTransportistadeUltimaGuia(string ruccliente)
        {
            String sql;
            Transportista transportista = new Transportista();
            try
            {
                //like a nombre 
                cn.Open();
            sql = "SELECT TOP 1 C5_CCODTRA FROM RSFACCAR_SS..AL0020MOVC WHERE C5_CTD = 'GS' AND C5_CCODCLI ='" + ruccliente.ToString() + "'" +
                  " ORDER BY C5_DFECDOC DESC";
              

                cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    transportista.codigo = dr["C5_CCODTRA"].ToString().Trim();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                   // transportista.nombre = dr["AR_CDESCRI"].ToString().Trim();
                    
           
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return transportista;

        }





    }
}
