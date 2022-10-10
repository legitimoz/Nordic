using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using ENTIDAD.SOP;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DAO.SOP
{
    public class SOP_CAB_DAO
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_BDLABFAR_OK"].ToString());
        SqlCommand cmd = new SqlCommand();


        public List<SOP_Registro_Sanitario> Listado_RegistrosSanitarios()
        {
            
            List<SOP_Registro_Sanitario> listarrss = new List<SOP_Registro_Sanitario>();

            try
            {
                cn.Open();

                cmd = new SqlCommand("SP_FGB_LISTAR_RRS", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro cod_cliente

                //SqlParameter p_usr_id = new SqlParameter();
                //p_usr_id.ParameterName = "@usr_id";
                //p_usr_id.SqlDbType = SqlDbType.Int;
                //// p_codcliente.Size = 18;
                //p_usr_id.Value = usr_id;
                //cmd.Parameters.Add(p_usr_id);

                SqlDataReader dr = cmd.ExecuteReader();
                // dr.Read();
                while (dr.Read())
                {
                    //forma con inner join 
                    SOP_Registro_Sanitario ObjRegSanitario = new SOP_Registro_Sanitario();
                    ObjRegSanitario.id_rrgg = Convert.ToInt32(dr["id_reg_san"].ToString().Trim());
                    ObjRegSanitario.codigo = dr["RRSS"].ToString().Trim();
                    ObjRegSanitario.nombre = dr["nombre"].ToString().Trim();
                    ObjRegSanitario.nombre_fabricante = dr["fab_des"].ToString().Trim();
                    ObjRegSanitario.nombre_pais = dr["pa_des"].ToString().Trim();          
                    ObjRegSanitario.comercializacion = dr["comercializacion"].ToString().Trim();
                    ObjRegSanitario.est_codigo = dr["est_descripcion"].ToString().Trim();
                    ObjRegSanitario.fecha_inicio = dr["fec_inicio_rrss"].ToString().Trim();
                    ObjRegSanitario.fec_vigencia = dr["fec_vigen_rrss"].ToString();
                    ObjRegSanitario.vida_util = Convert.ToInt32(dr["vu"].ToString());
                    
                    ObjRegSanitario.des_temperatura = dr["descri_temp"].ToString();
                    ObjRegSanitario.des_envase= dr["descri_envase"].ToString();

                    listarrss.Add(ObjRegSanitario);

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listarrss;
        }
        public List<SOP_Registro_Detalle> Lista_proy_privada(int usr_id)
        {

            List<SOP_Registro_Detalle> lista_pro_privada = new List<SOP_Registro_Detalle>();

            try
            {
                cn.Open();

                cmd = new SqlCommand("SP_FGB_LISTAR_SOP_PROY_PRIVADA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro cod_cliente

                SqlParameter p_usr_id = new SqlParameter();
                p_usr_id.ParameterName = "@usr_id";
                p_usr_id.SqlDbType = SqlDbType.Int;
               
                p_usr_id.Value = usr_id;
                cmd.Parameters.Add(p_usr_id);

                SqlDataReader dr = cmd.ExecuteReader();
                // dr.Read();
                while (dr.Read())
                {
                    //forma con inner join 
                    SOP_Registro_Detalle obj_pro_pri = new SOP_Registro_Detalle();
                    obj_pro_pri.id_pro_pri =        Convert.ToInt32(dr["id_pro_pri"].ToString().Trim());
                    obj_pro_pri.codigo_articulo =   dr["codigo_articulo"].ToString().Trim();
                    obj_pro_pri.valor_enero =       Convert.ToDecimal(dr["valor_enero"].ToString().Trim());
                    obj_pro_pri.valor_febrero =     Convert.ToDecimal(dr["valor_febrero"].ToString().Trim());
                    obj_pro_pri.valor_marzo =       Convert.ToDecimal(dr["valor_marzo"].ToString().Trim());
                    obj_pro_pri.valor_abril =       Convert.ToDecimal(dr["valor_abril"].ToString().Trim());
                    obj_pro_pri.valor_mayo =        Convert.ToDecimal(dr["valor_mayo"].ToString().Trim());
                    obj_pro_pri.valor_junio =       Convert.ToDecimal(dr["valor_junio"].ToString().Trim());
                    obj_pro_pri.valor_julio =       Convert.ToDecimal(dr["valor_julio"].ToString().Trim());
                    obj_pro_pri.valor_agosto =      Convert.ToDecimal(dr["valor_agosto"].ToString().Trim());
                    obj_pro_pri.valor_setiembre=    Convert.ToDecimal(dr["valor_setiembre"].ToString().Trim());
                    obj_pro_pri.valor_octubre=      Convert.ToDecimal(dr["valor_octubre"].ToString().Trim());
                    obj_pro_pri.valor_noviembre =   Convert.ToDecimal(dr["valor_noviembre"].ToString().Trim());
                    obj_pro_pri.valor_diciembre =   Convert.ToDecimal(dr["valor_diciembre"].ToString().Trim());

                    lista_pro_privada.Add(obj_pro_pri);

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista_pro_privada;
        }
        public List<SOP_Registro_Proy_Institucional> Lista_proy_institucional()
        {

            List<SOP_Registro_Proy_Institucional> lista_pro_institucional = new List<SOP_Registro_Proy_Institucional>();

            try
            {
                cn.Open();

                cmd = new SqlCommand("SP_FGB_LISTAR_SOP_PROY_INSTITUCIONAL", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro cod_cliente

                //SqlParameter p_usr_id = new SqlParameter();
                //p_usr_id.ParameterName = "@usr_id";
                //p_usr_id.SqlDbType = SqlDbType.Int;
                //// p_codcliente.Size = 18;
                //p_usr_id.Value = usr_id;
                //cmd.Parameters.Add(p_usr_id);

                SqlDataReader dr = cmd.ExecuteReader();
                // dr.Read();
                while (dr.Read())
                {
                    //forma con inner join 
                    SOP_Registro_Proy_Institucional obj_pro_insti = new SOP_Registro_Proy_Institucional();
                    
                    obj_pro_insti.id_pro_institucional = Convert.ToInt32(dr["id_pro_institucional"].ToString().Trim());
                    obj_pro_insti.proceso = dr["proceso"].ToString().Trim();
                    obj_pro_insti.entidad = dr["entidad"].ToString().Trim();
                    obj_pro_insti.codigo_articulo = dr["codigo_articulo"].ToString().Trim();
                    obj_pro_insti.cantidad_total = Convert.ToDecimal(dr["cantidad_total"].ToString().Trim());
                    obj_pro_insti.precio = Convert.ToDecimal(dr["precio"].ToString().Trim());
                    obj_pro_insti.importe = Convert.ToDecimal(dr["importe"].ToString().Trim());
                    obj_pro_insti.plazo_entrega = Convert.ToDecimal(dr["plazo_entrega"].ToString().Trim());
                    obj_pro_insti.num_total_entregas = Convert.ToDecimal(dr["num_total_entregas"].ToString().Trim());
                    obj_pro_insti.num_controles = Convert.ToDecimal(dr["num_controles"].ToString().Trim());
                    obj_pro_insti.estatus_buena_pro = dr["estatus_buena_pro"].ToString().Trim();
                    obj_pro_insti.importe_pendiente_facturar = Convert.ToDecimal(dr["importe_pendiente_facturar"].ToString().Trim());
                    obj_pro_insti.pendiente_entregar_unidad = Convert.ToDecimal(dr["pendiente_entregar_unidad"].ToString().Trim());
                    obj_pro_insti.pendiente_entregar_cajas = Convert.ToDecimal(dr["pendiente_entregar_cajas"].ToString().Trim());
                    obj_pro_insti.pendiente_atencion_porcentaje = Convert.ToDecimal(dr["pendiente_atencion_porcentaje"].ToString().Trim());
                    obj_pro_insti.mes_1 =  Convert.ToDecimal(dr["mes_1"].ToString().Trim());
                    obj_pro_insti.mes_2 =  Convert.ToDecimal(dr["mes_2"].ToString().Trim());
                    obj_pro_insti.mes_3 =  Convert.ToDecimal(dr["mes_3"].ToString().Trim());
                    obj_pro_insti.mes_4 =  Convert.ToDecimal(dr["mes_4"].ToString().Trim());
                    obj_pro_insti.mes_5 =  Convert.ToDecimal(dr["mes_5"].ToString().Trim());
                    obj_pro_insti.mes_6 =  Convert.ToDecimal(dr["mes_6"].ToString().Trim());
                    obj_pro_insti.mes_7 =  Convert.ToDecimal(dr["mes_7"].ToString().Trim());
                    obj_pro_insti.mes_8 =  Convert.ToDecimal(dr["mes_8"].ToString().Trim());
                    obj_pro_insti.mes_9 =  Convert.ToDecimal(dr["mes_9"].ToString().Trim());
                    obj_pro_insti.mes_10 = Convert.ToDecimal(dr["mes_10"].ToString().Trim());
                    obj_pro_insti.mes_11 = Convert.ToDecimal(dr["mes_11"].ToString().Trim());
                    obj_pro_insti.mes_12 = Convert.ToDecimal(dr["mes_12"].ToString().Trim());

                    lista_pro_institucional.Add(obj_pro_insti);

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista_pro_institucional;
        }
        public List<SOP_Fabricantes> RS_Listado_Fabricante()
        {

            List<SOP_Fabricantes> listado_fabricantes = new List<SOP_Fabricantes>();

            try
            {
                cn.Open();

                cmd = new SqlCommand("SP_FGB_LISTAR_SOP_RRSS_FABRICANTES", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                 SqlDataReader dr = cmd.ExecuteReader();
                // dr.Read();
                while (dr.Read())
                {
                    //forma con inner join 
                    SOP_Fabricantes fabrica = new SOP_Fabricantes();

                    fabrica.fab_id = Convert.ToInt32(dr["fab_id"].ToString().Trim());
                    fabrica.fab_des = dr["fab_des"].ToString().Trim();
                    fabrica.fab_est = dr["fab_est"].ToString().Trim();
                    


                    listado_fabricantes.Add(fabrica);

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listado_fabricantes;
        }
        
        public List<SOP_Paises> RS_Listado_Paises()
        {

            List<SOP_Paises> listado_paises = new List<SOP_Paises>();

            try
            {
                cn.Open();

                cmd = new SqlCommand("SP_FGB_LISTAR_SOP_RRSS_PAISES", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                // dr.Read();
                while (dr.Read())
                {
                    //forma con inner join 
                    SOP_Paises pais = new SOP_Paises();

                    pais.pa_id = Convert.ToInt32(dr["pa_id"].ToString().Trim());
                    pais.pa_des = dr["pa_des"].ToString().Trim();
                    pais.pa_est = dr["pa_est"].ToString().Trim();



                    listado_paises.Add(pais);

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listado_paises;
        }
        
        public List<SOP_Estados> RS_Listado_Estado()
        {

            List<SOP_Estados> listado_estados  = new List<SOP_Estados>();

            try
            {
                cn.Open();

                cmd = new SqlCommand("SP_FGB_LISTAR_SOP_RRSS_ESTADOS", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                // dr.Read();
                while (dr.Read())
                {
                    //forma con inner join 
                    SOP_Estados estados = new SOP_Estados();

                   
                    estados.est_codigo = dr["est_codigo"].ToString().Trim();
                    estados.est_descripcion = dr["est_descripcion"].ToString().Trim();



                    listado_estados.Add(estados);

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listado_estados;
        }


        public List<SOP_Envases> RS_Listado_Envases()
        {

            List<SOP_Envases> listado_envases = new List<SOP_Envases>();

            try
            {
                cn.Open();

                cmd = new SqlCommand("SP_FGB_LISTAR_SOP_RRSS_ENVASES", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                // dr.Read();
                while (dr.Read())
                {
                    //forma con inner join 
                    SOP_Envases envases = new SOP_Envases();

                    envases.id_envase = Convert.ToInt32(dr["id_envase"].ToString().Trim());
                    envases.descri_envase = dr["descri_envase"].ToString().Trim();
                    envases.est_cod = dr["est_cod"].ToString().Trim();



                    listado_envases.Add(envases);

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listado_envases;
        }








        public bool CargargarExcel(String Xml,int id)
        {
            bool respuesta = false;
            int rp = 0;
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_REGISTRAR_PROYECCION_PRIV_PRUEBA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pcliente = new SqlParameter();
                pcliente.ParameterName = "@XML";
                pcliente.SqlDbType = SqlDbType.Xml;
                pcliente.Value = Xml;

                SqlParameter p_id = new SqlParameter();
                p_id.ParameterName = "@id_usuario";
                p_id.SqlDbType = SqlDbType.Int;
                p_id.Value = id;


                cmd.Parameters.Add(pcliente);
                cmd.Parameters.Add(p_id);
                rp = cmd.ExecuteNonQuery();
                if (rp > 0)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }

                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }
        public bool CargargarExcel_Institucional(String Xml)
        {
            bool respuesta = false;
            int rp = 0;
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_REGISTRAR_PROYECCION_INSTITUCIONAL", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pcliente = new SqlParameter();
                pcliente.ParameterName = "@XML";
                pcliente.SqlDbType = SqlDbType.Xml;
                pcliente.Value = Xml;
                cmd.Parameters.Add(pcliente);
                rp = cmd.ExecuteNonQuery();
                if (rp > 0)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }

                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }
        public bool RegistroCodigoEmbarque(int usr_id , string codEmbarque)
        {
            bool respuesta = false;
            int rp = 0;

            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_SOP_REGISTRAR_EMBARQUE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                SqlParameter p_usr_id = new SqlParameter();
                p_usr_id.ParameterName = "@usr_id";
                p_usr_id.SqlDbType = SqlDbType.Int;
                p_usr_id.Value = usr_id;
               

                SqlParameter p_cod_embarque = new SqlParameter();
                p_cod_embarque.ParameterName = "@cod_embarque";
                p_cod_embarque.SqlDbType = SqlDbType.VarChar;
                p_cod_embarque.Size = 20;
                p_cod_embarque.Value = codEmbarque;
               
                cmd.Parameters.Add(p_usr_id);
                cmd.Parameters.Add(p_cod_embarque);

                rp = cmd.ExecuteNonQuery();
               
                if (rp > 0)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }

                cn.Close();


                return respuesta;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public SOP_Registro_Sanitario ObtenerRegistroSanitario(int cod_registro_sanitario)
        {
            SOP_Registro_Sanitario regSa = new SOP_Registro_Sanitario();

            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_SOP_OBTENER_REG_SAN", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro cod_cliente
                SqlParameter p_usr_id = new SqlParameter();
                p_usr_id.ParameterName = "@cod_reg_san";
                p_usr_id.SqlDbType = SqlDbType.Int;
                // p_codcliente.Size = 18;
                p_usr_id.Value = cod_registro_sanitario;

                cmd.Parameters.Add(p_usr_id);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    //forma con inner join 

                    regSa.id_rrgg = Convert.ToInt32(dr["id_reg_san"].ToString().Trim());
                    regSa.codigo = dr["RRSS"].ToString().Trim();
                    regSa.nombre = dr["nombre"].ToString().Trim();
                    regSa.id_fabricante = Convert.ToInt32(dr["fabricante"].ToString().Trim());
                    regSa.nombre_fabricante = dr["fab_des"].ToString().Trim();
                    regSa.id_pais = Convert.ToInt32(dr["id_pais"].ToString().Trim());
                    regSa.nombre_pais = dr["pa_des"].ToString().Trim();
                    regSa.comercializacion = dr["comercializacion"].ToString();
                    regSa.est_codigo = dr["est_descripcion"].ToString();
                    regSa.fecha_inicio = dr["fec_inicio_rrss"].ToString();
                  
                    regSa.fec_vigencia = dr["fec_vigen_rrss"].ToString();
                    regSa.vida_util = Convert.ToInt32(dr["vu"].ToString());
                    regSa.id_tipo_envase = Convert.ToInt32(dr["tipo"].ToString());
                    regSa.des_envase = dr["descri_envase"].ToString();

                    regSa.rrgg_competencia = dr["rs_competencia"].ToString();

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
            return regSa;

        }

    }
}
