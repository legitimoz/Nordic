using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using ENTIDAD.VIATICOS;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DAO.VIATICOS
{
   public class VIA_CAB_SOL_DAO
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_BDLABFAR"].ToString());
        SqlCommand cmd = new SqlCommand();


        public bool AgregarCabSolViatico(Via_Cab_Solicitud via_cab_sol)
        {
            bool respuesta = false;
            int rp = 0;
            SqlDataReader RpStore = null;
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_REGISTRAR_CAB_VIA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro idusuario_logeado
                SqlParameter p_id_logeado = new SqlParameter();
                p_id_logeado.ParameterName = "@vcs_usr_id_logeado";
                p_id_logeado.SqlDbType = SqlDbType.Int;
                // pcliente.Size = 50;
                p_id_logeado.Value = via_cab_sol.usr_id_logeado;

             

                //parametro cod_linea
                SqlParameter pcod_linea = new SqlParameter();
                pcod_linea.ParameterName = "@vcs_linea";
                pcod_linea.SqlDbType = SqlDbType.VarChar;
                pcod_linea.Size = 12;
                pcod_linea.Value = via_cab_sol.cod_linea;

                //parametro formapago
                SqlParameter pfechasolicitud = new SqlParameter();
                pfechasolicitud.ParameterName = "@vcs_fecha_solicitud";
                pfechasolicitud.SqlDbType = SqlDbType.Date;
                pfechasolicitud.Size = 50;
                pfechasolicitud.Value = via_cab_sol.fecha_solicitud;

                //parametro Nombre
                SqlParameter pmotivoviaje = new SqlParameter();
                pmotivoviaje.ParameterName = "@vcs_mot_viaje";
                pmotivoviaje.SqlDbType = SqlDbType.Int;
                //pvendedor.Size = 50;
                pmotivoviaje.Value = via_cab_sol.cod_mot_viaje;

                //parametro pmoneda
                SqlParameter pmontosolicitado = new SqlParameter();
                pmontosolicitado.ParameterName = "@vcs_monto_solicitado";
                pmontosolicitado.SqlDbType = SqlDbType.Float;
                //pmontosolicitado.Size = 50;
                pmontosolicitado.Value = via_cab_sol.monto_solicitado;

                //parametro palmacen
                SqlParameter pmedioviaje = new SqlParameter();
                pmedioviaje.ParameterName = "@vcs_medio_viaje";
                pmedioviaje.SqlDbType = SqlDbType.Int;
                //pmedioviaje.Size = 50;
                pmedioviaje.Value = via_cab_sol.cod_med_viaje;

                //parametro padjunto
                SqlParameter piddepartamento_ori = new SqlParameter();
                piddepartamento_ori.ParameterName = "@vcs_idDepartamento_ori";
                piddepartamento_ori.SqlDbType = SqlDbType.Char;
                piddepartamento_ori.Size = 2;
                piddepartamento_ori.Value = via_cab_sol.id_depart_ori;

                //parametro pfechaemision
                SqlParameter pidprovinciaori = new SqlParameter();
                pidprovinciaori.ParameterName = "@vcs_idProvincia_ori";
                pidprovinciaori.SqlDbType = SqlDbType.Char;
                pidprovinciaori.Size = 4;
                pidprovinciaori.Value = via_cab_sol.id_prov_ori;

                //parametro pglosa
                SqlParameter piddistrito_ori = new SqlParameter();
                piddistrito_ori.ParameterName = "@vcs_idDistrito_ori";
                piddistrito_ori.SqlDbType = SqlDbType.Char;
                piddistrito_ori.Size = 6;
                piddistrito_ori.Value = via_cab_sol.id_distri_ori;

                //parametro pfecharegistro
                SqlParameter pfecha_ori = new SqlParameter();
                pfecha_ori.ParameterName = "@vcs_fec_ori";
                pfecha_ori.SqlDbType = SqlDbType.DateTime;
                pfecha_ori.Size = 50;
                pfecha_ori.Value = via_cab_sol.fecha_origi;

                //parametro padjunto
                SqlParameter piddepartamento_des = new SqlParameter();
                piddepartamento_des.ParameterName = "@vcs_idDepartamento_des";
                piddepartamento_des.SqlDbType = SqlDbType.Char;
                piddepartamento_des.Size = 2;
                piddepartamento_des.Value = via_cab_sol.id_depart_dest;

                //parametro pfechaemision
                SqlParameter pidprovincia_des = new SqlParameter();
                pidprovincia_des.ParameterName = "@vcs_idProvincia_des";
                pidprovincia_des.SqlDbType = SqlDbType.Char;
                pidprovincia_des.Size = 4;
                pidprovincia_des.Value = via_cab_sol.id_prov_ori;

                //parametro pglosa
                SqlParameter piddistrito_des = new SqlParameter();
                piddistrito_des.ParameterName = "@vcs_idDistrito_des";
                piddistrito_des.SqlDbType = SqlDbType.Char;
                piddistrito_des.Size = 6;
                piddistrito_des.Value = via_cab_sol.id_distri_dest;

                //parametro pfecharegistro
                SqlParameter pfecha_des = new SqlParameter();
                pfecha_des.ParameterName = "@vcs_fec_des";
                pfecha_des.SqlDbType = SqlDbType.DateTime;
                pfecha_des.Size = 50;
                pfecha_des.Value = via_cab_sol.fecha_dest;

                //parametro pfecharegistro
                SqlParameter pfecha_termino = new SqlParameter();
                pfecha_termino.ParameterName = "@vcs_fec_term_viaje";
                pfecha_termino.SqlDbType = SqlDbType.Date;
                pfecha_termino.Size = 50;
                pfecha_termino.Value = via_cab_sol.fecha_term_viaje;

                //parametro padjunto
                SqlParameter pmonto_esperado = new SqlParameter();
                pmonto_esperado.ParameterName = "@vcs_monto_esperado";
                pmonto_esperado.SqlDbType = SqlDbType.Float;
               // pmonto_esperado.Size = 2;
                pmonto_esperado.Value = via_cab_sol.monto_esperado;

                //parametro pfechaemision
                SqlParameter pcant_dias = new SqlParameter();
                pcant_dias.ParameterName = "@vcs_cant_dias";
                pcant_dias.SqlDbType = SqlDbType.Int;
                //pidprovincia_des.Size = 4;
                pcant_dias.Value = via_cab_sol.cant_dias;

                //parametro pglosa
                SqlParameter pest_codigo = new SqlParameter();
                pest_codigo.ParameterName = "@est_codigo";
                pest_codigo.SqlDbType = SqlDbType.Char;
                pest_codigo.Size = 2;
                pest_codigo.Value = via_cab_sol.est_codigo;

                //parametro pfecharegistro
                SqlParameter pusr_id_cre = new SqlParameter();
                pusr_id_cre.ParameterName = "@vcs_usr_id_cre";
                pusr_id_cre.SqlDbType = SqlDbType.Int;
                //pusr_id_cre.Size = 50;
                pusr_id_cre.Value = via_cab_sol.usr_id_cre;

                //parametro pfecharegistro
                SqlParameter pfec_cre = new SqlParameter();
                pfec_cre.ParameterName = "@vcs_fec_cre";
                pfec_cre.SqlDbType = SqlDbType.DateTime;
                pfec_cre.Size = 50;
                pfec_cre.Value = via_cab_sol.fec_cre;

                cmd.Parameters.Add(p_id_logeado);
                cmd.Parameters.Add(pcod_linea);

                cmd.Parameters.Add(pfechasolicitud);
                cmd.Parameters.Add(pmotivoviaje);
                cmd.Parameters.Add(pmontosolicitado);
                cmd.Parameters.Add(pmedioviaje);
                cmd.Parameters.Add(piddepartamento_ori);
                
                cmd.Parameters.Add(pidprovinciaori);
                cmd.Parameters.Add(piddistrito_ori);
                cmd.Parameters.Add(pfecha_ori);
                cmd.Parameters.Add(piddepartamento_des);
                cmd.Parameters.Add(pidprovincia_des);
                cmd.Parameters.Add(piddistrito_des);
                cmd.Parameters.Add(pfecha_des);
                cmd.Parameters.Add(pfecha_termino);
                cmd.Parameters.Add(pmonto_esperado);
                cmd.Parameters.Add(pcant_dias);
                cmd.Parameters.Add(pest_codigo);
                cmd.Parameters.Add(pusr_id_cre);
                cmd.Parameters.Add(pfec_cre);

                // cmd.ExecuteNonQuery();

                //RpStore = cmd.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery()>0)
                {
               // rp = Convert.ToInt32(RpStore.GetValue(0).ToString());
                  respuesta = true;
                }
                else
                {
                 respuesta = false;
                }
                ////return rp;

                //respuesta = true;
                //MATA CONEXION
                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }

        public bool RegistroDetallePresupuesto(Via_Det_Presupuesto vdp)
        {
            bool respuesta = false;
            int rp = 0;
            SqlDataReader RpStore = null;
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_REGISTRAR_DET_PRESU_VIA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro idusuario_logeado
                SqlParameter p_id_sol= new SqlParameter();
                p_id_sol.ParameterName = "@id_num_sol";
                p_id_sol.SqlDbType = SqlDbType.Int;
                // pcliente.Size = 50;
                p_id_sol.Value = vdp.id_v_num_sol;

                //parametro cod_linea
                SqlParameter pidgasto = new SqlParameter();
                pidgasto.ParameterName = "@id_gasto";
                pidgasto.SqlDbType = SqlDbType.Int;
                //pidgasto.Size = 12;
                pidgasto.Value = vdp.id_gasto;

                //parametro formapago
                SqlParameter pdias = new SqlParameter();
                pdias.ParameterName = "@dias";
                pdias.SqlDbType = SqlDbType.Int;
                //pfechasolicitud.Size = 50;
                pdias.Value = vdp.dias;

                //parametro Nombre
                SqlParameter pprecio = new SqlParameter();
                pprecio.ParameterName = "@precio";
                pprecio.SqlDbType = SqlDbType.Float;
                //pvendedor.Size = 50;
                pprecio.Value = vdp.precio;

                //parametro pmoneda
                SqlParameter pusrid_cre = new SqlParameter();
                pusrid_cre.ParameterName = "@usr_id";
                pusrid_cre.SqlDbType = SqlDbType.Float;
                //pmontosolicitado.Size = 50;
                pusrid_cre.Value = vdp.usr_id_logeado;

              
                             

                cmd.Parameters.Add(p_id_sol);
                cmd.Parameters.Add(pidgasto);

                cmd.Parameters.Add(pdias);
                cmd.Parameters.Add(pprecio);
                cmd.Parameters.Add(pusrid_cre);
         
                // cmd.ExecuteNonQuery();

                //RpStore = cmd.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    // rp = Convert.ToInt32(RpStore.GetValue(0).ToString());
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
                ////return rp;

                //respuesta = true;
                //MATA CONEXION
                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }
        public bool Registrar_Mot_Viaje(Via_Mot_Viaje vdp)
        {
            bool respuesta = false;
            int rp = 0;
            SqlDataReader RpStore = null;
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_REGISTRAR_MOTIVO_VIAJE", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro idusuario_logeado
                SqlParameter p_mot_viaje = new SqlParameter();
                p_mot_viaje.ParameterName = "@mot";
                p_mot_viaje.SqlDbType = SqlDbType.VarChar;
                p_mot_viaje.Size = 50;
                p_mot_viaje.Value = vdp.v_mot_v_nombre;

                               
                cmd.Parameters.Add(p_mot_viaje);

                // cmd.ExecuteNonQuery();

                //RpStore = cmd.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    // rp = Convert.ToInt32(RpStore.GetValue(0).ToString());
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
                ////return rp;

                //respuesta = true;
                //MATA CONEXION
                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }
        
        public bool Registrar_Med_Viaje(Via_Med_Viaje vdp)
        {
            bool respuesta = false;
            int rp = 0;
            SqlDataReader RpStore = null;
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_REGISTRAR_MEDIO_VIAJE", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro idusuario_logeado
                SqlParameter p_mot_viaje = new SqlParameter();
                p_mot_viaje.ParameterName = "@med";
                p_mot_viaje.SqlDbType = SqlDbType.VarChar;
                p_mot_viaje.Size = 50;
                p_mot_viaje.Value = vdp.v_med_v_nombre;


                cmd.Parameters.Add(p_mot_viaje);

                // cmd.ExecuteNonQuery();

                //RpStore = cmd.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    // rp = Convert.ToInt32(RpStore.GetValue(0).ToString());
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
                ////return rp;

                //respuesta = true;
                //MATA CONEXION
                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }
        



        public bool EditarDetallePresupuesto(Via_Det_Presupuesto vdp)
        {
            bool respuesta = false;
            int rp = 0;
            SqlDataReader RpStore = null;
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_EDITAR_DET_PRESU_VIA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro idusuario_logeado
                SqlParameter p_id_sol = new SqlParameter();
                p_id_sol.ParameterName = "@id_num_sol";
                p_id_sol.SqlDbType = SqlDbType.Int;
                // pcliente.Size = 50;
                p_id_sol.Value = vdp.id_v_num_sol;

                //parametro cod_linea
                SqlParameter pidgasto = new SqlParameter();
                pidgasto.ParameterName = "@id_gasto";
                pidgasto.SqlDbType = SqlDbType.Int;
                //pidgasto.Size = 12;
                pidgasto.Value = vdp.id_gasto;

                //parametro formapago
                SqlParameter pdias = new SqlParameter();
                pdias.ParameterName = "@dias";
                pdias.SqlDbType = SqlDbType.Int;
                //pfechasolicitud.Size = 50;
                pdias.Value = vdp.dias;

                //parametro Nombre
                SqlParameter pprecio = new SqlParameter();
                pprecio.ParameterName = "@precio";
                pprecio.SqlDbType = SqlDbType.Float;
                //pvendedor.Size = 50;
                pprecio.Value = vdp.precio;

                //parametro pmoneda
                SqlParameter pusrid_cre = new SqlParameter();
                pusrid_cre.ParameterName = "@usr_id";
                pusrid_cre.SqlDbType = SqlDbType.Float;
                //pmontosolicitado.Size = 50;
                pusrid_cre.Value = vdp.usr_id_logeado;




                cmd.Parameters.Add(p_id_sol);
                cmd.Parameters.Add(pidgasto);

                cmd.Parameters.Add(pdias);
                cmd.Parameters.Add(pprecio);
                cmd.Parameters.Add(pusrid_cre);

                // cmd.ExecuteNonQuery();

                //RpStore = cmd.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    // rp = Convert.ToInt32(RpStore.GetValue(0).ToString());
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
                ////return rp;

                //respuesta = true;
                //MATA CONEXION
                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }
        public bool AnularDetallePresupuesto(Via_Det_Presupuesto vdp)
        {
            bool respuesta = false;
            int rp = 0;
            SqlDataReader RpStore = null;
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_ANULAR_DET_PRESU_VIA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro idusuario_logeado
                SqlParameter p_id_sol = new SqlParameter();
                p_id_sol.ParameterName = "@id_num_sol";
                p_id_sol.SqlDbType = SqlDbType.Int;
                // pcliente.Size = 50;
                p_id_sol.Value = vdp.id_v_num_sol;

                //parametro cod_linea
                SqlParameter pidgasto = new SqlParameter();
                pidgasto.ParameterName = "@id_gasto";
                pidgasto.SqlDbType = SqlDbType.Int;
                //pidgasto.Size = 12;
                pidgasto.Value = vdp.id_gasto;

                //parametro pmoneda
                SqlParameter pusrid_cre = new SqlParameter();
                pusrid_cre.ParameterName = "@usr_id";
                pusrid_cre.SqlDbType = SqlDbType.Float;
                //pmontosolicitado.Size = 50;
                pusrid_cre.Value = vdp.usr_id_logeado;



                cmd.Parameters.Add(p_id_sol);
                cmd.Parameters.Add(pidgasto);
                cmd.Parameters.Add(pusrid_cre);


                // cmd.ExecuteNonQuery();

                //RpStore = cmd.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    // rp = Convert.ToInt32(RpStore.GetValue(0).ToString());
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
                ////return rp;

                //respuesta = true;
                //MATA CONEXION
                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }

        public List<Via_Med_Viaje> ListadoMediosViaje()
        {
            String sql;
            List<Via_Med_Viaje> list_med_viaje = new List<Via_Med_Viaje>();
            try
            {
                cn.Open();

                sql = "SELECT v_med_v_id,v_med_v_nombre,est_codigo FROM VIA_MED_VIAJE WHERE est_codigo='AC'";

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Via_Med_Viaje via_med_viaje = new Via_Med_Viaje();
                    via_med_viaje.v_med_v_id = Convert.ToInt32(dr["v_med_v_id"].ToString());
                    via_med_viaje.v_med_v_nombre = dr["v_med_v_nombre"].ToString();
                    via_med_viaje.est_codigo = dr["est_codigo"].ToString();
                 

                    list_med_viaje.Add(via_med_viaje);
                }
                cn.Close();
            }
            
            catch (Exception E)
            {
                throw E;
            }
            return list_med_viaje;

        }
        
         public List<Via_Mot_Viaje> ListadoMotivosViaje()
        {
            String sql;
            List<Via_Mot_Viaje> list_mot_viaje = new List<Via_Mot_Viaje>();
            try
            {
                cn.Open();

                sql = "SELECT v_mot_v_id,v_mot_v_nombre,est_codigo FROM VIA_MOT_VIAJE WHERE est_codigo='AC'";

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Via_Mot_Viaje via_mot_viaje = new Via_Mot_Viaje();
                    via_mot_viaje.v_mot_v_id = Convert.ToInt32(dr["v_mot_v_id"].ToString());
                    via_mot_viaje.v_mot_v_nombre = dr["v_mot_v_nombre"].ToString();
                    via_mot_viaje.est_codigo = dr["est_codigo"].ToString();


                    list_mot_viaje.Add(via_mot_viaje);
                }
                cn.Close();
            }

            catch (Exception E)
            {
                throw E;
            }
            return list_mot_viaje;

        }

        public List<Via_Lineas> ListadoLineasUsuario()
        {
            String sql;
            List<Via_Lineas> list_lin_usr = new List<Via_Lineas>();
            try
            {
                cn.Open();

                sql = "SELECT TG_CCLAVE,TG_CDESCRI,est_codigo FROM VIA_LN_USUARIOS WHERE est_codigo='AC'";

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Via_Lineas via_lin_usur = new Via_Lineas();
                    via_lin_usur.tg_cclave = dr["TG_CCLAVE"].ToString();
                    via_lin_usur.tg_cdescri = dr["TG_CDESCRI"].ToString();
                    via_lin_usur.est_codigo = dr["est_codigo"].ToString();


                    list_lin_usr.Add(via_lin_usur);
                }
                cn.Close();
            }

            catch (Exception E)
            {
                throw E;
            }
            return list_lin_usr;

        }

        public List<VIA_Gerente_Linea> ListadoGerenteLineas()
        {
            String sql;
            List<VIA_Gerente_Linea> list_lin_usr = new List<VIA_Gerente_Linea>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_VIA_LISTAR_GERENTES_LINEA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro pfecharegistro
                //SqlParameter p_app_function = new SqlParameter();
                //p_app_function.ParameterName = "@app_function";
                //p_app_function.SqlDbType = SqlDbType.Int;
                //p_app_function.Value = app_function;

                //cmd.Parameters.Add(p_app_function);


                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    VIA_Gerente_Linea via_lin_usur = new VIA_Gerente_Linea();
                    via_lin_usur.usr_id = Convert.ToInt32(dr["usr_id"].ToString());
                    via_lin_usur.usr_nombre = dr["usr_nombre"].ToString();
                    via_lin_usur.est_codigo = dr["usr_estado"].ToString();


                    list_lin_usr.Add(via_lin_usur);
                }
                cn.Close();
            }

            catch (Exception E)
            {
                throw E;
            }
            return list_lin_usr;

        }

        public List<Via_Departamento> ListadoDepartamentos()
        {
            String sql;
            List<Via_Departamento> list_departamento = new List<Via_Departamento>();
            try
            {
                cn.Open();

                sql = "SELECT idDepartamento,descripcion FROM tbDepartamentos";

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                Via_Departamento via_departamento = new Via_Departamento();
                  via_departamento.idDepartamento = dr["idDepartamento"].ToString();
                  via_departamento.descripcion = dr["descripcion"].ToString();

                    list_departamento.Add(via_departamento);
                }
                cn.Close();
            }

            catch (Exception E)
            {
                throw E;
            }
            return list_departamento;

        }

        public List<Via_Estados> ListadoEstados(int app_function)
        {
            String sql;
            List<Via_Estados> lista_estados = new List<Via_Estados>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_VIA_LISTAR_ESTADOS", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro pfecharegistro
                SqlParameter p_app_function = new SqlParameter();
                p_app_function.ParameterName = "@app_function";
                p_app_function.SqlDbType = SqlDbType.Int;
                p_app_function.Value = app_function;

                cmd.Parameters.Add(p_app_function);

                

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Via_Estados via_estados = new Via_Estados();
                    via_estados.est_codigo = dr["est_codigo"].ToString();
                    via_estados.est_descri = dr["est_descripcion"].ToString();

                    lista_estados.Add(via_estados);
                }
                cn.Close();
            }

            catch (Exception E)
            {
                throw E;
            }
            return lista_estados;

        }
        
        public List<Via_Det_Con_Gastos> ListadoLiquidaciones(int repre,string f_fin,string f_ini)
        {
            String sql;
            List<Via_Det_Con_Gastos> lista_estados = new List<Via_Det_Con_Gastos>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_VIA_LISTAR_LIQUIDACIONES", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro pfecharegistro
                SqlParameter p_app_function = new SqlParameter();
                p_app_function.ParameterName = "@representante";
                p_app_function.SqlDbType = SqlDbType.Int;
                p_app_function.Value = repre;

                cmd.Parameters.Add(p_app_function);



                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Via_Det_Con_Gastos via_liquidaciones = new Via_Det_Con_Gastos();
                    via_liquidaciones.nombreconceptopgasto = dr["vcg_nombre"].ToString();

                    via_liquidaciones.vdcg_tipo_comprobante  = dr["vdcg_doc_tipo"].ToString(); 
                    via_liquidaciones.vdcg_numcomprobante    = dr["vdcg_num_compro"].ToString(); 
                    via_liquidaciones.vdcg_serie             = dr["vdcg_serie"].ToString(); 
                    via_liquidaciones.vdcg_razonsocial       = dr["vdcg_rz_social"].ToString();

                    via_liquidaciones.vdcg_fechacomprobante = dr["fechacomprobante"].ToString().Substring(0,10);


                    via_liquidaciones.vcg_cnt_conta         = dr["vcg_cnt_conta"].ToString(); 
                    via_liquidaciones.vcs_id                =Convert.ToInt32(dr["vcs_id"].ToString()); 

                    via_liquidaciones.vdcg_precio_propuesto = Convert.ToDouble(dr["vcg_precio"].ToString());

                    lista_estados.Add(via_liquidaciones);
                }
                cn.Close();
            }

            catch (Exception E)
            {
                throw E;
            }
            return lista_estados;

        }
        public List<Via_Provincias> ListadoProvincias(string idDepartamento)
        {
            String sql;
            List<Via_Provincias> list_provincias = new List<Via_Provincias>();
            try
            {
                cn.Open();

                sql = "SELECT idProvincia,descripcion FROM tbProvincias where idDepartamento='"+idDepartamento.ToString().Trim()+"'";

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Via_Provincias via_provincia = new Via_Provincias();
                    via_provincia.idProvincia = dr["idProvincia"].ToString();
                    via_provincia.descripcion = dr["descripcion"].ToString();

                    list_provincias.Add(via_provincia);
                }
                cn.Close();
            }

            catch (Exception E)
            {
                throw E;
            }
            return list_provincias;

        }
        public List<Via_Distrito> ListadoDistritos(string idProvincia)
        {
            String sql;
            List<Via_Distrito> list_distritos = new List<Via_Distrito>();
            try
            {
                cn.Open();

                sql = "SELECT idDistrito,descripcion FROM tbDistritos where idProvincia='" + idProvincia.ToString().Trim() + "'";

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Via_Distrito via_distrito = new Via_Distrito();
                    via_distrito.idDistrito = dr["idDistrito"].ToString();
                    via_distrito.descripcion = dr["descripcion"].ToString();

                    list_distritos.Add(via_distrito);
                }
                cn.Close();
            }

            catch (Exception E)
            {
                throw E;
            }
            return list_distritos;

        }

        public Via_Usuario ObtenerUsuario(int id_usr)
        {
            String sql;
            Via_Usuario via_usuario = new Via_Usuario();
            try
            {
                ////like a nombre 
                //cn.Open();
                //sql = "SELECT usr_id,usr_nombre,per_id FROM USUARIOS WHERE usr_id="+id_usr;
                //cmd = new SqlCommand(sql, cn);

                cn.Open();
                cmd = new SqlCommand("SP_FGB_VIA_OBTENER_USUARIO_LOGEADO", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro cod_cliente
                SqlParameter p_usr_id = new SqlParameter();
                p_usr_id.ParameterName = "@usr_id";
                p_usr_id.SqlDbType = SqlDbType.Int;
                // p_codcliente.Size = 18;
                p_usr_id.Value = id_usr;

              

                cmd.Parameters.Add(p_usr_id);
           

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    via_usuario.usr_id = Convert.ToInt32(dr["usr_id"].ToString().Trim());
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    via_usuario.usr_per_id = Convert.ToInt32(dr["per_id"].ToString().Trim());
                    via_usuario.usr_nombre = dr["usr_nombre"].ToString().Trim();
                
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return via_usuario;
        }

        public List<Via_ClienteSofcom> ListadoClientesSoftcom()
        {
            String sql;
            List<Via_ClienteSofcom> list_client_softcom = new List<Via_ClienteSofcom>();
            try
            {
                cn.Open();

                sql = "SELECT CL_CCODCLI,CL_CNOMCLI FROM RSFACCAR..FT0018CLIE";

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Via_ClienteSofcom via_clientesofcom = new Via_ClienteSofcom();
                    via_clientesofcom.ruc = dr["CL_CCODCLI"].ToString();
                    via_clientesofcom.nombre = dr["CL_CNOMCLI"].ToString();

                    list_client_softcom.Add(via_clientesofcom);
                }
                cn.Close();
            }

            catch (Exception E)
            {
                throw E;
            }
            return list_client_softcom;

        }

        public List<Via_Medicos> ListadoMedicosSoftcom()
        {
            String sql;
            List<Via_Medicos> list_medicos_softcom = new List<Via_Medicos>();
            try
            {
                cn.Open();

               

                cmd = new SqlCommand("SP_FGB_LISTADO_MEDICOS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Via_Medicos via_med = new Via_Medicos();
                    via_med.idMedico = Convert.ToInt32(dr["idMedico"].ToString());
                    via_med.idEstado = Convert.ToInt32(dr["idEstado"].ToString());
                    via_med.idEspecialidad = Convert.ToInt32(dr["idEspecialidad1"].ToString());
                    via_med.idEstado = Convert.ToInt32(dr["idEstado"].ToString());

                    via_med.nombrecompleto = dr["apellidos"].ToString();
                    via_med.cmp = dr["cmp"].ToString();

                    list_medicos_softcom.Add(via_med);
                }
                cn.Close();
            }

            catch (Exception E)
            {
                throw E;
            }
            return list_medicos_softcom;

        }
        
        public List<Via_Representanre> ListadoRepresentantes(int usr_id)
        {
            String sql;
            List<Via_Representanre> listado_representantes = new List<Via_Representanre>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_VIA_LISTAR_REPRESENTANTES", cn);


                cmd.CommandType = CommandType.StoredProcedure;
               
                //parametro usr_id
                SqlParameter p_usr_id = new SqlParameter();
                p_usr_id.ParameterName = "@usr_id";
                p_usr_id.SqlDbType = SqlDbType.Int;
                // p_codcliente.Size = 18;
                p_usr_id.Value = usr_id;



                cmd.Parameters.Add(p_usr_id);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Via_Representanre via_repre = new Via_Representanre();
                    via_repre.codigo = Convert.ToInt32(dr["usr_id"].ToString());
                    via_repre.nombre = dr["usr_nombre"].ToString();
                    via_repre.flag = dr["flag"].ToString();

                    listado_representantes.Add(via_repre);
                }
                cn.Close();
            }

            catch (Exception E)
            {
                throw E;
            }
            return listado_representantes;

        }
        
        public Via_Cab_Solicitud ObtenerUltimoViaticoCreadoporUsu(int usr_id)
        {
            String sql;
            Via_Cab_Solicitud via_cab_sol = new Via_Cab_Solicitud();
            try
            {

                cn.Open();


                cmd = new SqlCommand("SP_FGB_LISTAR_CAB_VIA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro cod_cliente
                SqlParameter p_usr_id = new SqlParameter();
                p_usr_id.ParameterName = "@usr_id";
                p_usr_id.SqlDbType = SqlDbType.Int;
                // p_codcliente.Size = 18;
                p_usr_id.Value = usr_id;

                cmd.Parameters.Add(p_usr_id);



                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    //forma con inner join 
                   
                    via_cab_sol.id_v_num_sol = Convert.ToInt32(dr["vcs_id"].ToString().Trim());
                    via_cab_sol.Nombrelinea = dr["TG_CDESCRI"].ToString().Trim();
                    via_cab_sol.NombreMedioViaje = dr["v_med_v_nombre"].ToString().Trim();
                    via_cab_sol.NombreMotivoViaje = dr["v_mot_v_nombre"].ToString().Trim();
                    
                    
                    string fecha = dr["vcs_fecha_solicitud"].ToString().Trim();
                    string f_forma= convertfecha(fecha);
                  
                    via_cab_sol.fecha_solicitud = f_forma;

                    via_cab_sol.fecha_origi = dr["vcs_fec_ori"].ToString().Trim();
                    via_cab_sol.id_depart_ori = dr["depart_ori"].ToString();
                    via_cab_sol.id_prov_ori = dr["prov_ori"].ToString();
                    via_cab_sol.id_distri_ori = dr["distri_ori"].ToString();
                    via_cab_sol.fecha_dest = dr["vcs_fec_des"].ToString();


                    string fecha_termino = dr["vcs_fec_term_viaje"].ToString().Trim();
                    string f_forma_termino = convertfecha(fecha_termino);
                    via_cab_sol.fecha_term_viaje = f_forma_termino;
                    via_cab_sol.id_depart_dest = dr["depart_des"].ToString();
                    via_cab_sol.id_prov_dest = dr["prov_des"].ToString();
                    via_cab_sol.id_distri_dest = dr["distri_des"].ToString();
                    via_cab_sol.cant_dias = Convert.ToInt32(dr["vcs_cant_dias"].ToString());



                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return via_cab_sol;
        }


        private string convertfecha(string fecha)
        {
            string fecha_formateada="";

            string phrase = fecha;
            string[] words = phrase.Split(' ');

            //"yyyy-MM-dd".


            string phrase_2 = words[0];
            string[] words_2 = phrase_2.Split('/');

            fecha_formateada= words_2[2] + "-" + words_2[1] + "-" + words_2[0];

            return fecha_formateada;
        }
        public bool AgregarDetalleCliente(string cod_cliente,string nom_cliente,int vcs_id,int vcs_usr_creacion , double precio)
        {
            bool respuesta = false;
            int rp = 0;
            SqlDataReader RpStore = null;
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_REGISTRAR_DET_CLIE_CAB_VIA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro cod_cliente
                SqlParameter p_codcliente = new SqlParameter();
                p_codcliente.ParameterName = "@CL_CCODCLI";
                p_codcliente.SqlDbType = SqlDbType.VarChar;
                p_codcliente.Size = 18;
                p_codcliente.Value = cod_cliente.Trim();

                //parametro nom_cliente
                SqlParameter p_nomcliente = new SqlParameter();
                p_nomcliente.ParameterName = "@CL_CNOMCLI";
                p_nomcliente.SqlDbType = SqlDbType.VarChar;
                p_nomcliente.Size = 80;
                p_nomcliente.Value = nom_cliente.Trim();

                //parametro cod_linea
                SqlParameter p_vcs_id= new SqlParameter();
                p_vcs_id.ParameterName = "@vcs_id";
                p_vcs_id.SqlDbType = SqlDbType.Int;
                //pcod_linea.Size = 12;
                p_vcs_id.Value = vcs_id;

                //parametro cod_linea
                SqlParameter p_usr_creacion = new SqlParameter();
                p_usr_creacion.ParameterName = "@vcs_usr_id_cre";
                p_usr_creacion.SqlDbType = SqlDbType.Int;
                //pcod_linea.Size = 12;
                p_usr_creacion.Value = vcs_usr_creacion;

                //parametro cod_linea
                SqlParameter p_precio = new SqlParameter();
                p_precio.ParameterName = "@vcs_precio";
                p_precio.SqlDbType = SqlDbType.Int;
                //pcod_linea.Size = 12;
                p_precio.Value = precio;

                //parametro dec_creacion
                //SqlParameter p_fec_creacion = new SqlParameter();
                //p_fec_creacion.ParameterName = "@vcs_fec_cre";
                //p_fec_creacion.SqlDbType = SqlDbType.VarChar;
                //p_fec_creacion.Size = 50;
                //p_fec_creacion.Value = fec_creacion;

                cmd.Parameters.Add(p_codcliente);
                cmd.Parameters.Add(p_nomcliente);
                cmd.Parameters.Add(p_vcs_id);
                cmd.Parameters.Add(p_usr_creacion);
                cmd.Parameters.Add(p_precio);


                // cmd.ExecuteNonQuery();

                //RpStore = cmd.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery()> 0)
                {
                    // rp = Convert.ToInt32(RpStore.GetValue(0).ToString());
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
                ////return rp;

                //respuesta = true;
                //MATA CONEXION
                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }
        
        public bool UpdateFlagUser(int id)
            {
            bool respuesta = false;
            int rp = 0;
            SqlDataReader RpStore = null;
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_UpdateUser_VIA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro cod_cliente
                SqlParameter p_id = new SqlParameter();
                p_id.ParameterName = "@p_id";
                p_id.SqlDbType = SqlDbType.Int;
                p_id.Value = id;

               
                cmd.Parameters.Add(p_id);


                // cmd.ExecuteNonQuery();

                //RpStore = cmd.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    // rp = Convert.ToInt32(RpStore.GetValue(0).ToString());
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
                ////return rp;

                //respuesta = true;
                //MATA CONEXION
                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }
        public List<Via_Det_Clie> ListadoDetClie(int vcs_id )
        {
            String sql;
            List<Via_Det_Clie> lista_via_det_clie = new List<Via_Det_Clie>();
            try
            {

                cn.Open();


                cmd = new SqlCommand("SP_FGB_LISTAR_DET_CLIE_VIA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro cod_cliente
                SqlParameter P_vcs_id = new SqlParameter();
                P_vcs_id.ParameterName = "@vcs_id";
                P_vcs_id.SqlDbType = SqlDbType.Int;
                // p_codcliente.Size = 18;
                P_vcs_id.Value = vcs_id;

                cmd.Parameters.Add(P_vcs_id);



                SqlDataReader dr = cmd.ExecuteReader();
               // dr.Read();
                while (dr.Read())
                {
                    //forma con inner join 
                    Via_Det_Clie via_det_clie = new Via_Det_Clie();
                    via_det_clie.vdc_id = Convert.ToInt32(dr["vcs_id"].ToString().Trim());
                    via_det_clie.vcs_id = Convert.ToInt32(dr["vcs_id"].ToString().Trim());
                    via_det_clie.cod_clie = dr["CL_CCODCLI"].ToString().Trim();
                    via_det_clie.nom_clie = dr["CL_CNOMCLI"].ToString().Trim();
                    via_det_clie.precio_proyectado = Convert.ToDouble(dr["vcs_pre_proyec"].ToString().Trim());

                    lista_via_det_clie.Add(via_det_clie);

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista_via_det_clie;
        }

        public bool AnularDetCliente(string codigocliente , int codigosoliciud , int usr_id)
        { //se copia del agregar
            bool respuesta = false;
            Detalle_CotizacionE cabecera = new Detalle_CotizacionE();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_ANULAR_DET_CLIE_SOL", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //la unica diferencia es Parametro id  lo copias de buscar 

                SqlParameter pCodigocli = new SqlParameter();
                pCodigocli.ParameterName = "@codigocliente";
                pCodigocli.SqlDbType = SqlDbType.VarChar;
                pCodigocli.Size = 50;
                pCodigocli.Value = codigocliente;

                SqlParameter pSolicitud = new SqlParameter();
                pSolicitud.ParameterName = "@codigosolicitud";
                pSolicitud.SqlDbType = SqlDbType.Int;
                //pCodigoarticulo.Size = 50;
                //llamas al objeto 
                pSolicitud.Value = codigosoliciud;

                SqlParameter pusurId = new SqlParameter();
                pusurId.ParameterName = "@usu_id_anul";
                pusurId.SqlDbType = SqlDbType.Int;
                //pCodigoarticulo.Size = 50;
                //llamas al objeto 
                pusurId.Value = usr_id;



                cmd.Parameters.Add(pCodigocli);
                cmd.Parameters.Add(pSolicitud);
                cmd.Parameters.Add(pusurId);


                cmd.ExecuteNonQuery();
                respuesta = true;

            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }
        public List<Via_Cab_Solicitud> ListadoViaticosCreados(int usr_id,string estado)
        {
            String sql;
            List<Via_Cab_Solicitud> lista_cab_sol = new List<Via_Cab_Solicitud>();

            try
            {

                cn.Open();
                cmd = new SqlCommand("SP_FGB_LISTAR_VIA_CAB_SOL_VEND", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro cod_cliente
                SqlParameter p_usr_id = new SqlParameter();
                p_usr_id.ParameterName = "@usr_id";
                p_usr_id.SqlDbType = SqlDbType.Int;
                // p_codcliente.Size = 18;
                p_usr_id.Value = usr_id;

                //parametro cod_cliente
                SqlParameter p_estado = new SqlParameter();
                p_estado.ParameterName = "@est";
                p_estado.SqlDbType = SqlDbType.VarChar;
                p_estado.Size = 2;
                p_estado.Value = estado;

                cmd.Parameters.Add(p_usr_id);
                cmd.Parameters.Add(p_estado);




                SqlDataReader dr = cmd.ExecuteReader();
                // dr.Read();
                while (dr.Read())
                {
                    //forma con inner join 
                    Via_Cab_Solicitud via_cab_sol = new Via_Cab_Solicitud();
                    via_cab_sol.id_v_num_sol = Convert.ToInt32(dr["vcs_id"].ToString().Trim());
                    via_cab_sol.est_codigo = dr["est_codigo"].ToString().Trim();
                    via_cab_sol.Nombrelinea = dr["TG_CDESCRI"].ToString().Trim();
                    via_cab_sol.fecha_solicitud = dr["vcs_fecha_solicitud"].ToString().Trim();
                  //  via_cab_sol.monto_solicitado = Convert.ToDouble(dr["vcs_monto_solicitado"].ToString().Trim());
                    via_cab_sol.NombreMedioViaje = dr["v_med_v_nombre"].ToString().Trim();
                    via_cab_sol.NombreMotivoViaje = dr["v_mot_v_nombre"].ToString().Trim();

                    via_cab_sol.fecha_origi = dr["vcs_fec_ori"].ToString().Trim();
                    via_cab_sol.id_depart_ori = dr["depart_ori"].ToString();
                    via_cab_sol.id_prov_ori = dr["prov_ori"].ToString();
                    via_cab_sol.id_distri_ori = dr["distri_ori"].ToString();

                    via_cab_sol.fecha_dest = dr["vcs_fec_des"].ToString();
                    via_cab_sol.id_depart_dest = dr["depart_des"].ToString();
                    via_cab_sol.id_prov_dest = dr["prov_des"].ToString();
                    via_cab_sol.id_distri_dest = dr["distri_des"].ToString();
                    //monto toatal
                    String valor = dr["MontoTotal"].ToString();
                    via_cab_sol.monto_solicitado = Convert.ToDouble(valor);

                    via_cab_sol.motivoanulacion = dr["mot_des"].ToString();



                    lista_cab_sol.Add(via_cab_sol);

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista_cab_sol;
        }

        //REGISTRO DE LIQUIDACIONES
        public bool AgregarDet_Con_Gastos(Via_Det_Con_Gastos via_det_con_gas)
        {
            bool respuesta = false;
            int rp = 0;
            SqlDataReader RpStore = null;
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_REGISTRAR_DET_CON__GASTOS_CAMBIO", cn);
                cmd.CommandType = CommandType.StoredProcedure;

               

                //parametro idusuario_logeado
  
                SqlParameter p_vcs_id = new SqlParameter();
                p_vcs_id.ParameterName = "@vcs_id";
                p_vcs_id.SqlDbType = SqlDbType.Int;
                // pcliente.Size = 50;
                p_vcs_id.Value = via_det_con_gas.vcs_id;

                //parametro cod_linea
                SqlParameter p_vcg_id = new SqlParameter();
                p_vcg_id.ParameterName = "@vcg_id";
                p_vcg_id.SqlDbType = SqlDbType.Int;
                //p_vcg_id.Size = 12;
                p_vcg_id.Value = via_det_con_gas.vcg_id;

                //parametro formapago
                SqlParameter ppreciolista= new SqlParameter();
                ppreciolista.ParameterName = "@vcdg_precio_lista";
                ppreciolista.SqlDbType = SqlDbType.Float;
               // ppreciolista.Size = 50;
                ppreciolista.Value = via_det_con_gas.vdcg_precio_lista;

                //parametro Nombre
                SqlParameter ppreciopropuesto = new SqlParameter();
                ppreciopropuesto.ParameterName = "@vcdg_precio_propuesto";
                ppreciopropuesto.SqlDbType = SqlDbType.Float;
                //pvendedor.Size = 50;
                ppreciopropuesto.Value = via_det_con_gas.vdcg_precio_propuesto;

                //parametro pmoneda
                SqlParameter p_fechacomprobante = new SqlParameter();
                p_fechacomprobante.ParameterName = "@vdcg_fechacomprobante";
                p_fechacomprobante.SqlDbType = SqlDbType.VarChar;
                p_fechacomprobante.Size = 50;
                p_fechacomprobante.Value = via_det_con_gas.vdcg_fechacomprobante;

                //parametro palmacen
                SqlParameter pnumcomprobante = new SqlParameter();
                pnumcomprobante.ParameterName = "@vdcg_num_comprobante";
                pnumcomprobante.SqlDbType = SqlDbType.VarChar;
                pnumcomprobante.Size = 30;
                pnumcomprobante.Value = via_det_con_gas.vdcg_numcomprobante;

                //   ,@vdcg_razon_social ,
                //parametro padjunto
                SqlParameter pruc = new SqlParameter();
                pruc.ParameterName = "@vdcg_ruc";
                pruc.SqlDbType = SqlDbType.Char;
                pruc.Size = 18;
                pruc.Value = via_det_con_gas.vdcg_rucproveedor;

                //parametro pfechaemision
                SqlParameter prazonsocial = new SqlParameter();
                prazonsocial.ParameterName = "@vdcg_razon_social";
                prazonsocial.SqlDbType = SqlDbType.Char;
                prazonsocial.Size = 100;
                prazonsocial.Value = via_det_con_gas.vdcg_razonsocial;


                //  ,@vdcg_fec_cre ,@vdcg_usrid_cre
                //parametro pglosa
                SqlParameter ppuntopartida = new SqlParameter();
                ppuntopartida.ParameterName = "@vdcg_pnt_partida";
                ppuntopartida.SqlDbType = SqlDbType.VarChar;
                ppuntopartida.Size = 50;
                ppuntopartida.Value = via_det_con_gas.vdcg_punto_partida;

                //parametro pfecharegistro
                SqlParameter ppuntollegada = new SqlParameter();
                ppuntollegada.ParameterName = "@vdcg_pnt_llegada";
                ppuntollegada.SqlDbType = SqlDbType.VarChar;
                ppuntollegada.Size = 50;
                ppuntollegada.Value = via_det_con_gas.vdcg_punto_llegada;

                //parametro padjunto
                SqlParameter pmedioviaje = new SqlParameter();
                pmedioviaje.ParameterName = "@vdcg_med_viaje";
                pmedioviaje.SqlDbType = SqlDbType.Int;
              //  pmedioviaje.Size = 2;
                pmedioviaje.Value = via_det_con_gas.cod_med_viaje;

                //parametro pfechaemision
                SqlParameter p_foto = new SqlParameter();
                p_foto.ParameterName = "@vdcg_foto";
                p_foto.SqlDbType = SqlDbType.VarChar;
                p_foto.Size = int.MaxValue;
                p_foto.Value = via_det_con_gas.foto;

                //parametro pglosa
                SqlParameter p_fec_cre = new SqlParameter();
                p_fec_cre.ParameterName = "@vdcg_fec_cre";
                p_fec_cre.SqlDbType = SqlDbType.VarChar;
                p_fec_cre.Size = 50;
                p_fec_cre.Value = via_det_con_gas.vdcg_fec_crea;

                //parametro pfecharegistro
                SqlParameter P_usrid_cre = new SqlParameter();
                P_usrid_cre.ParameterName = "@vdcg_usrid_cre";
                P_usrid_cre.SqlDbType = SqlDbType.Int;
                //P_usrid_cre.Size = 50;
                P_usrid_cre.Value = via_det_con_gas.vdcg_usrid_crea;


                //parametro pcomprobantetipo
                SqlParameter p_tipo_comprobante = new SqlParameter();
                p_tipo_comprobante.ParameterName = "@vdcg_doc_tipo";
                p_tipo_comprobante.SqlDbType = SqlDbType.VarChar;
                p_tipo_comprobante.Size = 2;
                p_tipo_comprobante.Value = via_det_con_gas.vdcg_tipo_comprobante;

                //parametro pseriecomprobante
                SqlParameter p_serie = new SqlParameter();
                p_serie.ParameterName = "@serie";
                p_serie.SqlDbType = SqlDbType.VarChar;
                p_serie.Size = 6;
                p_serie.Value = via_det_con_gas.vdcg_serie;



                cmd.Parameters.Add(p_vcs_id);
                cmd.Parameters.Add(p_vcg_id);

                cmd.Parameters.Add(ppreciolista);
                cmd.Parameters.Add(ppreciopropuesto);
                cmd.Parameters.Add(p_fechacomprobante);
                cmd.Parameters.Add(pnumcomprobante);
                cmd.Parameters.Add(pruc);
                cmd.Parameters.Add(prazonsocial);

                cmd.Parameters.Add(ppuntollegada);
                cmd.Parameters.Add(ppuntopartida);
                cmd.Parameters.Add(pmedioviaje);
                cmd.Parameters.Add(p_foto);
                cmd.Parameters.Add(p_fec_cre);
                cmd.Parameters.Add(P_usrid_cre);
                cmd.Parameters.Add(p_tipo_comprobante);
                cmd.Parameters.Add(p_serie);

                // cmd.ExecuteNonQuery();

                //RpStore = cmd.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    // rp = Convert.ToInt32(RpStore.GetValue(0).ToString());
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
                ////return rp;

                //respuesta = true;
                //MATA CONEXION
                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }

        //REGISTRO DE LIQUIDACIONES XML PRUEBA FOTO
        public string AgregarDet_Con_Gastos_XML(string Xml)
        {
            bool respuesta = false;
            string resp = "", resp_2 = "", resp_3 = "", resp_4 = "", resp_5 = "";
            SqlDataReader RpStore = null;
            int rp = 0;
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_REGISTRAR_DET_CON__GASTOS_XML", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pcliente = new SqlParameter();
                pcliente.ParameterName = "@XML";
                pcliente.SqlDbType = SqlDbType.Xml;
                pcliente.Value = Xml;
                cmd.Parameters.Add(pcliente);

                RpStore = cmd.ExecuteReader();
                if (RpStore.Read())
                {
                    resp = RpStore.GetValue(0).ToString();
                   // resp_2 = RpStore.GetValue(1).ToString();
                   // resp_3 = RpStore.GetValue(2).ToString();
                   // resp_4 = RpStore.GetValue(3).ToString();
                    // resp_5 = RpStore.GetValue(4).ToString();
                }
                else
                {

                }

                //rp = cmd.ExecuteNonQuery();
                //if (rp > 0)
                //{
                //    respuesta = true;
                //    resp = RpStore.GetValue(0).ToString();
                //    resp_2 = RpStore.GetValue(1).ToString();
                //    resp_3 = RpStore.GetValue(2).ToString();
                //    resp_4 = RpStore.GetValue(3).ToString();
                //}
                //else
                //{
                //    respuesta = false;
                //}

                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            //return respuesta;
            return resp + "-" + resp_2 + "-" + resp_3 + "-" + resp_4 + "-" + resp_5;

        }
        public List<ConceptopGasto> ListadoConceptoGasto()
        {
            String sql;
            List<ConceptopGasto> Lista_concepto_gasto = new List<ConceptopGasto>();

            try
            {

                cn.Open();


                cmd = new SqlCommand("SP_FGB_LISTAR_CON_GASTOS_REPRESENTANTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                ////parametro cod_cliente
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
                    ConceptopGasto concep_gasto = new ConceptopGasto();

                    concep_gasto.vcg_id = Convert.ToInt32(dr["vcg_id"].ToString().Trim());
                    concep_gasto.vcg_nombre = dr["vcg_nombre"].ToString().Trim();
                    concep_gasto.vcg_descripcion = dr["vcg_descripcion"].ToString().Trim();
                    
                    concep_gasto.vcg_preciolista = Convert.ToDouble(dr["vcg_precio"].ToString().Trim());
                    concep_gasto.vcg_preciomaximo = Convert.ToDouble(dr["vcg_precio_max"].ToString().Trim());
                    concep_gasto.vcg_tipo = Convert.ToInt32(dr["vcg_tipo"].ToString().Trim());
                    concep_gasto.est_codigo = dr["est_codigo"].ToString().Trim();

                    concep_gasto.vcg_cnt_conta = dr["vcg_cnt_conta"].ToString().Trim();
                    Lista_concepto_gasto.Add(concep_gasto);

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Lista_concepto_gasto;
        }

        public List<ConceptopGasto> ListadoConceptoGasto_master()
        {
            String sql;
            List<ConceptopGasto> Lista_concepto_gasto = new List<ConceptopGasto>();

            try
            {

                cn.Open();


                cmd = new SqlCommand("SP_FGB_LISTAR_CON_GASTOS_REPRESENTANTE_MASTER", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                ////parametro cod_cliente
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
                    ConceptopGasto concep_gasto = new ConceptopGasto();

                    concep_gasto.vcg_id = Convert.ToInt32(dr["vcg_id"].ToString().Trim());
                    concep_gasto.vcg_nombre = dr["vcg_nombre"].ToString().Trim();
                    concep_gasto.vcg_descripcion = dr["vcg_descripcion"].ToString().Trim();

                    concep_gasto.vcg_preciolista = Convert.ToDouble(dr["vcg_precio"].ToString().Trim());
                    concep_gasto.vcg_preciomaximo = Convert.ToDouble(dr["vcg_precio_max"].ToString().Trim());
                    concep_gasto.vcg_tipo = Convert.ToInt32(dr["vcg_tipo"].ToString().Trim());
                    concep_gasto.est_codigo = dr["est_codigo"].ToString().Trim();
                    concep_gasto.vcg_idperfil = Convert.ToInt32(dr["vcg_idperfil"].ToString().Trim());

                    concep_gasto.vcg_cnt_conta = dr["vcg_cnt_conta"].ToString().Trim();
                    Lista_concepto_gasto.Add(concep_gasto);

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Lista_concepto_gasto;
        }



        public List<Via_Det_Con_Gastos> ListadoDetGastos(int vcs_id)
        {
            String sql;
            List<Via_Det_Con_Gastos> ListaDet_Con_Gasto = new List<Via_Det_Con_Gastos>();

            try
            {

                cn.Open();

                cmd = new SqlCommand("SP_FGB_LISTAR_DET_GASTOS_REPRESENTANTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro cod_cliente
                SqlParameter p_usr_id = new SqlParameter();
                p_usr_id.ParameterName = "@vcs_id";
                p_usr_id.SqlDbType = SqlDbType.Int;
                // p_codcliente.Size = 18;
                p_usr_id.Value = vcs_id;

                cmd.Parameters.Add(p_usr_id);



                SqlDataReader dr = cmd.ExecuteReader();
                // dr.Read();
                while (dr.Read())
                {
                    //forma con inner join 
                    Via_Det_Con_Gastos vdet_con_gas = new Via_Det_Con_Gastos();


                    vdet_con_gas.vdcg_numcomprobante = dr["vdcg_num_compro"].ToString().Trim();
                    vdet_con_gas.vdcg_rucproveedor = dr["vdcg_ruc"].ToString().Trim();
                    vdet_con_gas.vdcg_razonsocial = dr["vdcg_rz_social"].ToString().Trim();
                    vdet_con_gas.vdcg_precio_propuesto = Convert.ToDouble(dr["vdcg_precio_propuesto"].ToString().Trim());
                    vdet_con_gas.nombremedioviaje = dr["v_med_v_nombre"].ToString().Trim();
                   vdet_con_gas.vdcg_fechacomprobante = dr["vcg_fechacomprobante"].ToString().Trim();
                    vdet_con_gas.nombreconceptopgasto = dr["vcg_nombre"].ToString().Trim();

                    vdet_con_gas.vdcg_tipo_comprobante = dr["vdcg_doc_tipo"].ToString().Trim();
                    vdet_con_gas.vdcg_serie = dr["vdcg_serie"].ToString().Trim();
                    ListaDet_Con_Gasto.Add(vdet_con_gas);

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ListaDet_Con_Gasto;
        }

        public List<Via_Det_Presupuesto> ListadoDet_Presupuesto(int id_solicitud)
        {
            String sql;
            List<Via_Det_Presupuesto> ListaDet_Presupuesto = new List<Via_Det_Presupuesto>();

            try
            {

                cn.Open();

                cmd = new SqlCommand("SP_FGB_LISTAR_DET_PRESUPUESTO", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro cod_cliente
                SqlParameter p_id_solicitud = new SqlParameter();
                p_id_solicitud.ParameterName = "@id_solicitud";
                p_id_solicitud.SqlDbType = SqlDbType.Int;
                // p_codcliente.Size = 18;
                p_id_solicitud.Value = id_solicitud;

                cmd.Parameters.Add(p_id_solicitud);



                SqlDataReader dr = cmd.ExecuteReader();
                // dr.Read();
                while (dr.Read())
                {
                    //forma con inner join 
                    Via_Det_Presupuesto vdet_pres = new Via_Det_Presupuesto();


                    vdet_pres.id_gasto = Convert.ToInt32(dr["id_gasto"].ToString().Trim());
                    vdet_pres.id_v_num_sol = Convert.ToInt32(dr["id_num_sol"].ToString().Trim());
                    
                    vdet_pres.nombregasto = dr["vcg_nombre"].ToString();
                    vdet_pres.dias = Convert.ToInt32(dr["dias"].ToString().Trim());
                    vdet_pres.precio = Convert.ToDouble(dr["precio"].ToString().Trim());
                    vdet_pres.precio_maximo = Convert.ToDouble(dr["vcg_precio_max"].ToString().Trim());
                    vdet_pres.descripcion_gasto = dr["vcg_descripcion"].ToString().Trim();
                    vdet_pres.icon = dr["vcg_icon"].ToString().Trim();



                    ListaDet_Presupuesto.Add(vdet_pres);

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ListaDet_Presupuesto;
        }

        public Via_Cab_Solicitud MontoPresupuestadoporSolicitud(int id_solicitud)
        {
            String sql;
            Via_Cab_Solicitud via_cab_sol = new Via_Cab_Solicitud();
            try
            {

                cn.Open();


                cmd = new SqlCommand("SP_FGB_OBTENERPRESUPUESTO", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro cod_cliente
                SqlParameter p_id_num_sol = new SqlParameter();
                p_id_num_sol.ParameterName = "@id_num_sol";
                p_id_num_sol.SqlDbType = SqlDbType.Int;
                // p_codcliente.Size = 18;
                p_id_num_sol.Value = id_solicitud;

                cmd.Parameters.Add(p_id_num_sol);



                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    //forma con inner join 

                    via_cab_sol.Nombrelinea = dr["suma"].ToString().Trim();
                   
           



                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return via_cab_sol;
        }
        
        public string Enviar__aproba_glinea(int cabeceraCotizacion, string estado, int usrid)
        { //se copia del agregar
            string resp = "", resp_2 = "", resp_3 = "", resp_4 = "", resp_5 = "";
            SqlDataReader RpStore = null;
            bool respuesta = false;
            int rp = 0;
            CabeceraCotizacion cabecera = new CabeceraCotizacion();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_ENVIAR_APROBAR_SOL_VIA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //la unica diferencia es Parametro id  lo copias de buscar 

                SqlParameter pCodigo = new SqlParameter();
                pCodigo.ParameterName = "@codigo";
                pCodigo.SqlDbType = SqlDbType.Int;
                //llamas al objeto 
                pCodigo.Value = cabeceraCotizacion;


                //parametro estado
                SqlParameter pEstado = new SqlParameter();
                pEstado.ParameterName = "@estado";
                pEstado.SqlDbType = SqlDbType.Char;
                pEstado.Size = 2;
                pEstado.Value = estado;


                SqlParameter pusrid = new SqlParameter();
                pusrid.ParameterName = "@usr_id";
                pusrid.SqlDbType = SqlDbType.Int;
                //llamas al objeto 
                pusrid.Value = usrid;

                cmd.Parameters.Add(pCodigo);
                cmd.Parameters.Add(pEstado);
                cmd.Parameters.Add(pusrid);



                RpStore = cmd.ExecuteReader();
                if (RpStore.Read())
                {
                    resp = RpStore.GetValue(0).ToString();
                    resp_2 = RpStore.GetValue(1).ToString();
                    resp_3 = RpStore.GetValue(2).ToString();
                    resp_4 = RpStore.GetValue(3).ToString();
                    // resp_5 = RpStore.GetValue(4).ToString();
                }
                else
                {

                }

                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return resp + "-" + resp_2 + "-" + resp_3 + "-" + resp_4 + "-" + resp_5;

        }

        public string AprobarViaitico(int cabeceraCotizacion, string estado, int usrid)
        { //se copia del agregar
            string resp = "", resp_2 = "", resp_3 = "", resp_4 = "", resp_5 = "";
            SqlDataReader RpStore = null;
            bool respuesta = false;
            int rp = 0;
            CabeceraCotizacion cabecera = new CabeceraCotizacion();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_APROBANDO_SOL_VIA_GERENTE_LINEA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //la unica diferencia es Parametro id  lo copias de buscar 

                SqlParameter pCodigo = new SqlParameter();
                pCodigo.ParameterName = "@codigo";
                pCodigo.SqlDbType = SqlDbType.Int;
                //llamas al objeto 
                pCodigo.Value = cabeceraCotizacion;


                //parametro estado
                SqlParameter pEstado = new SqlParameter();
                pEstado.ParameterName = "@estado";
                pEstado.SqlDbType = SqlDbType.Char;
                pEstado.Size = 2;
                pEstado.Value = estado;


                SqlParameter pusrid = new SqlParameter();
                pusrid.ParameterName = "@usr_id";
                pusrid.SqlDbType = SqlDbType.Int;
                //llamas al objeto 
                pusrid.Value = usrid;

                cmd.Parameters.Add(pCodigo);
                cmd.Parameters.Add(pEstado);
                cmd.Parameters.Add(pusrid);



                RpStore = cmd.ExecuteReader();
                if (RpStore.Read())
                {
                    resp = RpStore.GetValue(0).ToString();
                    resp_2 = RpStore.GetValue(1).ToString();
                    resp_3 = RpStore.GetValue(2).ToString();
                    resp_4 = RpStore.GetValue(3).ToString();
                    // resp_5 = RpStore.GetValue(4).ToString();
                }
                else
                {

                }

                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return resp + "-" + resp_2 + "-" + resp_3 + "-" + resp_4 + "-" + resp_5;

        }

        public Via_Cab_Solicitud ObtenerSolicitudViatico(int id_solicitud)
        {
            String sql;
            Via_Cab_Solicitud via_cab_sol = new Via_Cab_Solicitud();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_LISTAR_CAB_VIA_X_ID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro cod_cliente
                SqlParameter p_usr_id = new SqlParameter();
                p_usr_id.ParameterName = "@vcs_id";
                p_usr_id.SqlDbType = SqlDbType.Int;
                // p_codcliente.Size = 18;
                p_usr_id.Value = id_solicitud;

                cmd.Parameters.Add(p_usr_id);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    //forma con inner join 

                    via_cab_sol.id_v_num_sol = Convert.ToInt32(dr["vcs_id"].ToString().Trim());
                    via_cab_sol.Nombrelinea = dr["TG_CDESCRI"].ToString().Trim();
                    via_cab_sol.NombreMedioViaje = dr["v_med_v_nombre"].ToString().Trim();
                    via_cab_sol.NombreMotivoViaje = dr["v_mot_v_nombre"].ToString().Trim();

                    via_cab_sol.fecha_origi = dr["vcs_fec_ori"].ToString().Trim();
                    via_cab_sol.id_depart_ori = dr["depart_ori"].ToString();
                    via_cab_sol.id_prov_ori = dr["prov_ori"].ToString();
                    via_cab_sol.id_distri_ori = dr["distri_ori"].ToString();

                    via_cab_sol.fecha_dest = dr["vcs_fec_des"].ToString();
                    via_cab_sol.id_depart_dest = dr["depart_des"].ToString();
                    via_cab_sol.id_prov_dest = dr["prov_des"].ToString();
                    via_cab_sol.id_distri_dest = dr["distri_des"].ToString();
                    via_cab_sol.NombreUsuario = dr["usr_nombre"].ToString(); 

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return via_cab_sol;
        }

        public List<Via_Cab_Solicitud> ListadoViaticosCreados_apro(string estado , int id_repre)
        {
            String sql;
            List<Via_Cab_Solicitud> lista_cab_sol = new List<Via_Cab_Solicitud>();

            try
            {
                cn.Open();

                cmd = new SqlCommand("SP_FGB_LISTAR_VIA_CAB_SOL_VEND_APRO", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro cod_cliente

                SqlParameter p_estado = new SqlParameter();
                p_estado.ParameterName = "@estado";
                p_estado.SqlDbType = SqlDbType.VarChar;
                p_estado.Size = 2;
                p_estado.Value = estado;

                SqlParameter p_idrepre = new SqlParameter();
                p_idrepre.ParameterName = "@id_repre";
                p_idrepre.SqlDbType = SqlDbType.Int;
               
                p_idrepre.Value = id_repre;

                cmd.Parameters.Add(p_estado);
                cmd.Parameters.Add(p_idrepre);



                SqlDataReader dr = cmd.ExecuteReader();
                // dr.Read();
                while (dr.Read())
                {
                    //forma con inner join 
                    Via_Cab_Solicitud via_cab_sol = new Via_Cab_Solicitud();
                    via_cab_sol.id_v_num_sol = Convert.ToInt32(dr["vcs_id"].ToString().Trim());
                    via_cab_sol.NombreUsuario = dr["usr_nombre"].ToString().Trim();
                    via_cab_sol.est_codigo = dr["est_codigo"].ToString().Trim();
                    via_cab_sol.Nombrelinea = dr["TG_CDESCRI"].ToString().Trim();
                    via_cab_sol.fecha_solicitud = dr["vcs_fecha_solicitud"].ToString().Trim();
                    //  via_cab_sol.monto_solicitado = Convert.ToDouble(dr["vcs_monto_solicitado"].ToString().Trim());
                    via_cab_sol.NombreMedioViaje = dr["v_med_v_nombre"].ToString().Trim();
                    via_cab_sol.NombreMotivoViaje = dr["v_mot_v_nombre"].ToString().Trim();

                    via_cab_sol.fecha_origi = dr["vcs_fec_ori"].ToString().Trim();
                    via_cab_sol.id_depart_ori = dr["depart_ori"].ToString();
                    via_cab_sol.id_prov_ori = dr["prov_ori"].ToString();
                    via_cab_sol.id_distri_ori = dr["distri_ori"].ToString();

                    via_cab_sol.fecha_dest = dr["vcs_fec_des"].ToString();
                    via_cab_sol.id_depart_dest = dr["depart_des"].ToString();
                    via_cab_sol.id_prov_dest = dr["prov_des"].ToString();
                    via_cab_sol.id_distri_dest = dr["distri_des"].ToString();
                    //monto toatal
                    String valor = dr["MontoTotal"].ToString();
                    via_cab_sol.monto_solicitado = Convert.ToDouble(valor);



                    lista_cab_sol.Add(via_cab_sol);

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista_cab_sol;
        }

        public List<Via_Motivo> ListadoMotivos()
        {
            String sql, Salida = "";
            int id_app = 1;
            List<Via_Motivo> listado = new List<Via_Motivo>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_LISTAR_MOTIVOS", cn);
                cmd.CommandType = CommandType.StoredProcedure;

               // parametro id applicacion

                SqlParameter p_idd_app = new SqlParameter();
                p_idd_app.ParameterName = "@id_app";
                p_idd_app.SqlDbType = SqlDbType.Int;
               // p_idd_appcliente.Size = 18;
                p_idd_app.Value = id_app;

                cmd.Parameters.Add(p_idd_app);



                SqlDataReader dr = cmd.ExecuteReader();
                // dr.Read();
                while (dr.Read())
                {
                    Via_Motivo motivo = new Via_Motivo();
                    motivo.id = Convert.ToInt32(dr["mot_id"].ToString());
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    motivo.descripcion = dr["mot_des"].ToString();

                    listado.Add(motivo);
                }
                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return listado;

        }

        //public bool desaprobar_viatico(int cabeceraCotizacion, int usr_id, int id_motanul)
        //{ //se copia del agregar
        //    bool respuesta = false;
        //    int rp;
            
        //    try
        //    {
        //        cn.Open();
        //        cmd = new SqlCommand("SP_FGB_ANULAR_VIATICO", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        //la unica diferencia es Parametro id  lo copias de buscar 

        //        SqlParameter pCodigo = new SqlParameter();
        //        pCodigo.ParameterName = "@codigo";
        //        pCodigo.SqlDbType = SqlDbType.Int;
        //        //llamas al objeto 
        //        pCodigo.Value = cabeceraCotizacion;

        //        SqlParameter pusrid = new SqlParameter();
        //        pusrid.ParameterName = "@usr_id_anul";
        //        pusrid.SqlDbType = SqlDbType.Int;
        //        //llamas al objeto
        //        pusrid.Value = usr_id;

        //        SqlParameter pidmot_anul = new SqlParameter();
        //        pidmot_anul.ParameterName = "@id_mot_anul";
        //        pidmot_anul.SqlDbType = SqlDbType.Int;
        //        //llamas al objeto 
        //        // pidmot_anul.Size = 2;
        //        pidmot_anul.Value = id_motanul;


        //        cmd.Parameters.Add(pCodigo);
        //        cmd.Parameters.Add(pusrid);
        //        cmd.Parameters.Add(pidmot_anul);

        //        rp = cmd.ExecuteNonQuery();


        //        if (rp > 0)
        //        {
        //            respuesta = true;
        //        }
        //        else
        //        {
        //            respuesta = false;
        //        }

        //        cn.Close();
        //    }
        //    catch (Exception E)
        //    {
        //        throw E;
        //    }
        //    return respuesta;

        //}

        public string desaprobar_viatico(int cabeceraCotizacion, string estado,int usr_id, int id_motanul)
        { //se copia del agregar
            string resp = "", resp_2 = "", resp_3 = "", resp_4 = "", resp_5 = "";
            SqlDataReader RpStore = null;
            bool respuesta = false;
            int rp = 0;
            CabeceraCotizacion cabecera = new CabeceraCotizacion();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_ANULAR_VIATICO", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //la unica diferencia es Parametro id  lo copias de buscar 

                SqlParameter pCodigo = new SqlParameter();
                pCodigo.ParameterName = "@codigo";
                pCodigo.SqlDbType = SqlDbType.Int;
                //llamas al objeto 
                pCodigo.Value = cabeceraCotizacion;

                SqlParameter pusrid = new SqlParameter();
                pusrid.ParameterName = "@usr_id_anul";
                pusrid.SqlDbType = SqlDbType.Int;
                //llamas al objeto
                pusrid.Value = usr_id;

                SqlParameter pidmot_anul = new SqlParameter();
                pidmot_anul.ParameterName = "@id_mot_anul";
                pidmot_anul.SqlDbType = SqlDbType.Int;
                //llamas al objeto 
                // pidmot_anul.Size = 2;
                pidmot_anul.Value = id_motanul;

                SqlParameter p_estado = new SqlParameter();
                p_estado.ParameterName = "@estado";
                p_estado.SqlDbType = SqlDbType.VarChar;  
                p_estado.Size = 2;
                p_estado.Value = estado;


                cmd.Parameters.Add(pCodigo);
                cmd.Parameters.Add(pusrid);
                cmd.Parameters.Add(pidmot_anul);
                cmd.Parameters.Add(p_estado);



                RpStore = cmd.ExecuteReader();
                if (RpStore.Read())
                {
                    resp = RpStore.GetValue(0).ToString();
                    resp_2 = RpStore.GetValue(1).ToString();
                    //resp_3 = RpStore.GetValue(2).ToString();
                    //resp_4 = RpStore.GetValue(3).ToString();
                    // resp_5 = RpStore.GetValue(4).ToString();
                }
                else
                {

                }

                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return resp + "-" + resp_2 + "-" + resp_3 + "-" + resp_4 + "-" + resp_5;

        }


        public string Asignar_Linea(int id_linea, int id_gerente)
        { //se copia del agregar
            string resp = "", resp_2 = "", resp_3 = "", resp_4 = "", resp_5 = "";
            SqlDataReader RpStore = null;
            bool respuesta = false;
            int rp = 0;
            
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_ASIGNAR_GERENTE_LINEA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //la unica diferencia es Parametro id  lo copias de buscar 

                SqlParameter p_idlinea = new SqlParameter();
                p_idlinea.ParameterName = "@id_linea";
                p_idlinea.SqlDbType = SqlDbType.Int;
                p_idlinea.Value = id_linea;

                SqlParameter p_id_gerente = new SqlParameter();
                p_id_gerente.ParameterName = "@id_gerente";
                p_id_gerente.SqlDbType = SqlDbType.Int;
                p_id_gerente.Value = id_gerente;

               
                cmd.Parameters.Add(p_idlinea);
                cmd.Parameters.Add(p_id_gerente);
         



                RpStore = cmd.ExecuteReader();
                if (RpStore.Read())
                {
                    resp = RpStore.GetValue(0).ToString();
                    resp_2 = RpStore.GetValue(1).ToString();
                    //resp_3 = RpStore.GetValue(2).ToString();
                    //resp_4 = RpStore.GetValue(3).ToString();
                    // resp_5 = RpStore.GetValue(4).ToString();
                }
                else
                {

                }

                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return resp + "-" + resp_2 + "-" + resp_3 + "-" + resp_4 + "-" + resp_5;

        }


        public string Saldo_liquidacion(int id_solicitud)
        { //se copia del agregar
            string resp_0 = "", resp_1 = "", resp_2 = "", resp_4 = "", resp_5 = "";
            SqlDataReader RpStore = null;
            bool respuesta = false;
            int rp = 0;
            double valor = 0;
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_VIA_SALDO_LIQUIDACION", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //la unica diferencia es Parametro id  lo copias de buscar 

                SqlParameter p_id_solicitud = new SqlParameter();
                p_id_solicitud.ParameterName = "@id_solicitud";
                p_id_solicitud.SqlDbType = SqlDbType.Int;
                p_id_solicitud.Value = id_solicitud;

                
                cmd.Parameters.Add(p_id_solicitud);




                RpStore = cmd.ExecuteReader();
                if (RpStore.Read())
                {
                    resp_0 = RpStore.GetValue(0).ToString();
                   //valor = Convert.ToDouble(RpStore.GetValue(2).ToString());
                   
                    resp_1 = RpStore.GetValue(2).ToString();
                    resp_2 = RpStore.GetValue(3).ToString();
                    
                }
                else
                {

                }

                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return resp_0 +  "-" + resp_1 + "-" + resp_2  ;

        }



        public DataTable ListarCLientesconDatatable(int repre)
        {
                       
            DataTable DtRetorno = new DataTable();
           
            SqlDataReader Resu=null;

            try
            {
                cn.Open();

                
                cmd = new SqlCommand("SP_FGB_LISTAR_PRUEBA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //parametro pfecharegistro
                SqlParameter p_app_function = new SqlParameter();
                p_app_function.ParameterName = "@representante";
                p_app_function.SqlDbType = SqlDbType.Int;
                p_app_function.Value = repre;

                cmd.Parameters.Add(p_app_function);


                Resu = cmd.ExecuteReader();


                
             
                DtRetorno.Load(Resu);
                cn.Close();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DtRetorno;

        }
    }
}
