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
   public class ClienteNuevoCotiDAL
    {

        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_senda"].ToString());
        SqlCommand cmd = new SqlCommand();

        public bool AgregarClienteNuevo(ClienteNuevoCotizacion clienteNuevoC)
        {

            bool respuesta = false;

            try
            {
                cn.Open();
                // SP_FGB_AgregarClienteNuevoCotizacion
                cmd = new SqlCommand("SP_FGB_AgregarClienteNuevoCotizacion_direciones", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro Cliente
                SqlParameter pcliente = new SqlParameter();
                pcliente.ParameterName = "@CL_CCODCLI";
                pcliente.SqlDbType = SqlDbType.Char;
                pcliente.Size = 18;
                pcliente.Value = clienteNuevoC.ruc;

                //parametro Razon Social
                SqlParameter prsocial = new SqlParameter();
                prsocial.ParameterName = "@CL_CNOMCLI";
                prsocial.SqlDbType = SqlDbType.VarChar;
                prsocial.Size = 80;
                prsocial.Value = clienteNuevoC.razonsocial;

                //parametro direccion
                SqlParameter pdireccion = new SqlParameter();
                pdireccion.ParameterName = "@CL_CDIRCLI";
                pdireccion.SqlDbType = SqlDbType.VarChar;
                pdireccion.Size = 80;
                pdireccion.Value = clienteNuevoC.direccion;

                //parametro telefono
                SqlParameter ptelefono = new SqlParameter();
                ptelefono.ParameterName = "@CL_CTELEFO";
                ptelefono.SqlDbType = SqlDbType.VarChar;
                ptelefono.Size = 25;
                ptelefono.Value = clienteNuevoC.telefono;

                //parametro correo
                SqlParameter pcorreo = new SqlParameter();
                pcorreo.ParameterName = "@CL_CORREO";
                pcorreo.SqlDbType = SqlDbType.VarChar;
                pcorreo.Size = 80;
                pcorreo.Value = clienteNuevoC.corrreo;

                //parametro vendedor
                SqlParameter pvendedor = new SqlParameter();
                pvendedor.ParameterName = "CL_CVENDE";
                pvendedor.SqlDbType = SqlDbType.Char;
                pvendedor.Size = 5;
                pvendedor.Value = clienteNuevoC.vendedor;

                //parametro tipocliente
                SqlParameter ptipocliente = new SqlParameter();
                ptipocliente.ParameterName = "@CL_CTIPVTA";
                ptipocliente.SqlDbType = SqlDbType.Char;
                ptipocliente.Size = 5;
                ptipocliente.Value = clienteNuevoC.tipocliente;

                //parametro usuario
                SqlParameter pusuario = new SqlParameter();
                pusuario.ParameterName = "@usr_id";
                pusuario.SqlDbType = SqlDbType.Int;
                //pfechaemision.Size = 50;
                pusuario.Value = clienteNuevoC.cod_usuario;

                //parametro fecharegistro
                SqlParameter pfecha_registro = new SqlParameter();
                pfecha_registro.ParameterName = "@cln_fecreg";
                pfecha_registro.SqlDbType = SqlDbType.DateTime;
                //pglosa.Size = 50;
                pfecha_registro.Value = clienteNuevoC.fecha_registro;

                
                cmd.Parameters.Add(pcliente);
                cmd.Parameters.Add(prsocial);
                cmd.Parameters.Add(pdireccion);
                cmd.Parameters.Add(ptelefono);
                cmd.Parameters.Add(pcorreo);
                cmd.Parameters.Add(pvendedor);
                cmd.Parameters.Add(ptipocliente);
                cmd.Parameters.Add(pusuario);
                cmd.Parameters.Add(pfecha_registro);
              

                cmd.ExecuteNonQuery();
                respuesta = true;

            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }



    }
}
