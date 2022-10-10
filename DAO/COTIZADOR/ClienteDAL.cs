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
    public class ClienteDAL
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        SqlCommand cmd = new SqlCommand();

        //lista de clientes 
        public List<ClienteSofCom> ListadoClientes()
        {
            String sql, Salida = "";
            List<ClienteSofCom> listado = new List<ClienteSofCom>();
            try
            {
                cn.Open();
                // orginal sql = "select CL_CCODCLI,CL_CNOMCLI from FT0020CLIE where CL_CESTADO ='V' ";
                sql = "SELECT top 5000 Cli.CL_CCODCLI,Cli.CL_CNOMCLI,Ven.VE_CNOMBRE,Ven.VE_CCODIGO FROM FT0020CLIE Cli FULL JOIN FT0020VEND Ven on Cli.cl_cvende = Ven.VE_CCODIGO";
                
                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ClienteSofCom cliente = new ClienteSofCom();
                    cliente.ruc = dr["CL_CCODCLI"].ToString();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    cliente.razonsocial = dr["CL_CNOMCLI"].ToString();
                    cliente.vendedor = dr["VE_CNOMBRE"].ToString();

                    listado.Add(cliente);
                }
               // cn.Close();
            }

          
            catch (Exception E)
            {
                throw E;
            }
            return listado;

        }

        //buscar Cliente x Ruc
        public ClienteSofCom BuscarClientexRuc(string ruccliente)
        {
            String sql, Salida = "";
            ClienteSofCom clienteSofComE = new ClienteSofCom();
            try
            {
        //like a nombre 
        cn.Open();
         sql = "SELECT Cli.CL_CDIRCLI,Cli.CL_CCODCLI,Cli.CL_CNOMCLI,Ven.VE_CNOMBRE,Ven.VE_CCODIGO,Venta.FV_CCODIGO,Venta.FV_CDESCRI,Venta.FV_NDIASV " +
         "FROM FT0020CLIE Cli INNER JOIN FT0020VEND Ven on Cli.cl_cvende = Ven.VE_CCODIGO " +
        "LEFT JOIN FT0020FORV Venta on Cli.CL_CTIPVTA=Venta.FV_CCODIGO " +
        "WHERE TRIM(Cli.CL_CCODCLI)='" + ruccliente.ToString().Trim() + "'";

                cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                 clienteSofComE.ruc = dr["CL_CCODCLI"].ToString().Trim();
                 //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                 clienteSofComE.razonsocial = dr["CL_CNOMCLI"].ToString().Trim();
                 clienteSofComE.vendedor = dr["VE_CNOMBRE"].ToString().Trim();
                 clienteSofComE.direccion = dr["CL_CDIRCLI"].ToString().Trim();
                 clienteSofComE.tipoventa = dr["FV_CDESCRI"].ToString().Trim();
                 clienteSofComE.value_tipoventa = dr["FV_CCODIGO"].ToString().Trim();
                 clienteSofComE.diasdeventa=Convert.ToInt32(dr["FV_NDIASV"].ToString());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return clienteSofComE;
        }

        //buscar Cliente x Ruc
        public List<ClienteSofCom> ListarCLientesconDatatable()
        {
            List<ClienteSofCom> listado = new List<ClienteSofCom>();
            ClienteSofCom clienteSofComE;
            DataTable DtRetorno = new DataTable();
            String sql = "",sql2="";
            
            try
            {
                cn.Open();
       
        sql2="SELECT CASE WHEN CL_NEW.CL_CCODCLI IS NULL THEN Cli.CL_CCODCLI ELSE CL_NEW.CL_CCODCLI  END CL_CCODCLI, " +
             "CASE WHEN CL_NEW.CL_CCODCLI IS NULL THEN Cli.CL_CNOMCLI ELSE CL_NEW.CL_CNOMCLI END CL_CNOMCLI FROM FT0020CLIE Cli " +
             "FULL JOIN BDSSENDA..ClienteNuevo_Coti CL_NEW on Cli.CL_CCODCLI = CL_NEW.CL_CCODCLI";  
                
                // "WHERE Cli.CL_CCODCLI='" + ruccliente.ToString() + "'";
                cmd = new SqlCommand(sql2, cn);

                SqlDataReader Resu = null;

                Resu = cmd.ExecuteReader();
                DtRetorno.Load(Resu);
                if (DtRetorno.Rows.Count > 0)
                {
                   
               foreach (DataRow row in DtRetorno.Rows)
                {
                  clienteSofComE = new ClienteSofCom();
                  clienteSofComE.razonsocial = row["CL_CNOMCLI"].ToString().Trim();
                  clienteSofComE.ruc = row["CL_CCODCLI"].ToString().Trim();  
                  listado.Add(clienteSofComE);
                    }

                    

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listado;
        }


    }
}
