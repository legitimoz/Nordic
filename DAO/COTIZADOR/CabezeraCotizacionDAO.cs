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
   public  class CabezeraCotizacionDAO
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_senda"].ToString());
        SqlCommand cmd = new SqlCommand();

        //lista de clientes 
        public List<CabeceraCotizacion> ListadoCotizaciones(string codigo_vendedor, string estado)
        {
            String sql, Salida = "";
            List<CabeceraCotizacion> listado = new List<CabeceraCotizacion>();
            try
            {
          cn.Open();
    
    sql = "SELECT  EST.est_descripcion,CTZ.codigo,CTZ.moneda,CTZ.adjunto,CTZ.fecharegistro,CTZ.usuario, CLI.CL_CNOMCLI,DIR.DE_CDIRECC,FVENT.FV_CDESCRI,VEN.VE_CNOMBRE,ALM.A1_CDESCRI FROM " +
    "Cab_Cotizacion_v1 CTZ " +
    "inner join RSFACCAR_SS..FT0020CLIE CLI on CLI.CL_CCODCLI = CTZ.cliente " +
    
    "LEFT join RSFACCAR_SS..FT0020VEND VEN on VEN.VE_CCODIGO = CTZ.vendedor " +
    "LEFT join RSFACCAR_SS..AL0020ALMA ALM on ALM.A1_CALMA = CTZ.almacen " +
    "LEFT join RSFACCAR_SS..FT0020FORV FVENT on FVENT.FV_CCODIGO = CTZ.formapago " +
    "LEFT join RSFACCAR_SS..FT0020CLID DIR on DIR.DE_CCODUBI = CTZ.direccion  AND DIR.DE_CCODCLI = CTZ.cliente " +
    "LEFT join ESTADOS  EST on EST.est_codigo = CTZ.est_codigo " +
     "WHERE CTZ.usuario='" + codigo_vendedor.ToString() + "'" + " AND CTZ.est_codigo='"+estado.ToString()+"'" +
     
                " UNION " +
    "SELECT EST.est_descripcion,CTZ.codigo,CTZ.moneda,CTZ.adjunto,CTZ.fecharegistro,CTZ.usuario, CLI.CL_CNOMCLI,CLI.CL_CDIRCLI,FVENT.FV_CDESCRI,VEN.VE_CNOMBRE,ALM.A1_CDESCRI FROM " +
    "Cab_Cotizacion_v1 CTZ " +
    "inner join CLienteNuevo_Coti CLI on CLI.CL_CCODCLI = CTZ.cliente " +
   
    "LEFT join RSFACCAR_SS..FT0020VEND VEN on VEN.VE_CCODIGO = CTZ.vendedor " +
    "LEFT join RSFACCAR_SS..AL0020ALMA ALM on ALM.A1_CALMA = CTZ.almacen " +
    "LEFT join RSFACCAR_SS..FT0020FORV FVENT on FVENT.FV_CCODIGO = CTZ.formapago " +
    "LEFT join ESTADOS  EST on EST.est_codigo = CTZ.est_codigo " +
    "WHERE CTZ.usuario='" + codigo_vendedor.ToString() + "'" + " AND CTZ.est_codigo='" + estado.ToString() + "'" +
    "order by CTZ.fecharegistro DESC";

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CabeceraCotizacion cotizacion = new CabeceraCotizacion();
                    cotizacion.codigo = dr["codigo"].ToString();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    cotizacion.cliente = dr["CL_CNOMCLI"].ToString();
                    cotizacion.direccion = dr["DE_CDIRECC"].ToString();
                    cotizacion.formapago = dr["FV_CDESCRI"].ToString();
                    cotizacion.vendedor = dr["VE_CNOMBRE"].ToString();
                    cotizacion.moneda = dr["moneda"].ToString();
                    cotizacion.almacen = dr["A1_CDESCRI"].ToString();
                    cotizacion.adjunto = dr["adjunto"].ToString();
                    cotizacion.fechaemision = dr["DE_CDIRECC"].ToString();
                  //  cotizacion.glosa = dr["cliente"].ToString();
                    cotizacion.fecharegistro = dr["fecharegistro"].ToString();
                    cotizacion.usuario = dr["usuario"].ToString();
                    cotizacion.id_estado= dr["est_descripcion"].ToString();
                  //  cotizacion.validador_stock = Convert.ToInt32(dr["stock"].ToString());

                    listado.Add(cotizacion);
                }
            }
            catch (Exception E)
            {
                throw E;
            }
            return listado;

        }

        public List<CabeceraCotizacion> ListadoCotizaciones_creditos_cobranzas(string codigo_vendedor)
        {
            String sql, Salida = "";
            List<CabeceraCotizacion> listado = new List<CabeceraCotizacion>();
            try
            {
                cn.Open();

                sql = "SELECT  EST.est_descripcion,CTZ.codigo,CTZ.moneda,CTZ.adjunto,CTZ.fecharegistro,CTZ.usuario, CLI.CL_CNOMCLI,DIR.DE_CDIRECC,FVENT.FV_CDESCRI,VEN.VE_CNOMBRE,ALM.A1_CDESCRI FROM " +
                "Cab_Cotizacion_v1 CTZ " +
                "inner join RSFACCAR_SS..FT0020CLIE CLI on CLI.CL_CCODCLI = CTZ.cliente " +

                "LEFT join RSFACCAR_SS..FT0020VEND VEN on VEN.VE_CCODIGO = CTZ.vendedor " +
                "LEFT join RSFACCAR_SS..AL0020ALMA ALM on ALM.A1_CALMA = CTZ.almacen " +
                "LEFT join RSFACCAR_SS..FT0020FORV FVENT on FVENT.FV_CCODIGO = CTZ.formapago " +
                "LEFT join RSFACCAR_SS..FT0020CLID DIR on DIR.DE_CCODUBI = CTZ.direccion  AND DIR.DE_CCODCLI = CTZ.cliente " +
                "LEFT join ESTADOS  EST on EST.est_codigo = CTZ.est_codigo " +
               "WHERE  CTZ.est_codigo='4'" +
                //  "WHERE CTZ.usuario='" + codigo_vendedor.ToString() + "'" + " AND CTZ.est_codigo='4'" +

                            " UNION " +
                "SELECT EST.est_descripcion,CTZ.codigo,CTZ.moneda,CTZ.adjunto,CTZ.fecharegistro,CTZ.usuario, CLI.CL_CNOMCLI,CLI.CL_CDIRCLI,FVENT.FV_CDESCRI,VEN.VE_CNOMBRE,ALM.A1_CDESCRI FROM " +
                "Cab_Cotizacion_v1 CTZ " +
                "inner join CLienteNuevo_Coti CLI on CLI.CL_CCODCLI = CTZ.cliente " +

                "LEFT join RSFACCAR_SS..FT0020VEND VEN on VEN.VE_CCODIGO = CTZ.vendedor " +
                "LEFT join RSFACCAR_SS..AL0020ALMA ALM on ALM.A1_CALMA = CTZ.almacen " +
                "LEFT join RSFACCAR_SS..FT0020FORV FVENT on FVENT.FV_CCODIGO = CTZ.formapago " +
                "LEFT join ESTADOS  EST on EST.est_codigo = CTZ.est_codigo " +
                "WHERE  CTZ.est_codigo='4'" +
                "order by CTZ.fecharegistro ASC";

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CabeceraCotizacion cotizacion = new CabeceraCotizacion();
                    cotizacion.codigo = dr["codigo"].ToString();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    cotizacion.cliente = dr["CL_CNOMCLI"].ToString();
                    cotizacion.direccion = dr["DE_CDIRECC"].ToString();
                    cotizacion.formapago = dr["FV_CDESCRI"].ToString();
                    cotizacion.vendedor = dr["VE_CNOMBRE"].ToString();
                    cotizacion.moneda = dr["moneda"].ToString();
                    cotizacion.almacen = dr["A1_CDESCRI"].ToString();
                    cotizacion.adjunto = dr["adjunto"].ToString();
                    cotizacion.fechaemision = dr["DE_CDIRECC"].ToString();
                    //  cotizacion.glosa = dr["cliente"].ToString();
                    cotizacion.fecharegistro = dr["fecharegistro"].ToString();
                    cotizacion.usuario = dr["usuario"].ToString();
                    cotizacion.id_estado = dr["est_descripcion"].ToString();
                    
                    //  cotizacion.validador_stock = Convert.ToInt32(dr["stock"].ToString());

                    listado.Add(cotizacion);
                }
            }
            catch (Exception E)
            {
                throw E;
            }
            return listado;

        }

        public List<CabeceraCotizacion> ListadoCotizaciones_parametro(string codigo_vendedor,string fechainicio, string fecha_fin)
        {
            String sql, Salida = "";
            List<CabeceraCotizacion> listado = new List<CabeceraCotizacion>();
            try
            {
                cn.Open();
               
                sql = "SELECT  EST.est_descripcion,CTZ.codigo,CTZ.moneda,CTZ.adjunto,CTZ.fecharegistro,CTZ.usuario, CLI.CL_CNOMCLI,DIR.DE_CDIRECC,FVENT.FV_CDESCRI,VEN.VE_CNOMBRE,ALM.A1_CDESCRI FROM " +
                "Cab_Cotizacion_v1 CTZ " +
                "inner join RSFACCAR_SS..FT0020CLIE CLI on CLI.CL_CCODCLI = CTZ.cliente " +

                "LEFT join RSFACCAR_SS..FT0020VEND VEN on VEN.VE_CCODIGO = CTZ.vendedor " +
                "LEFT join RSFACCAR_SS..AL0020ALMA ALM on ALM.A1_CALMA = CTZ.almacen " +
                "LEFT join RSFACCAR_SS..FT0020FORV FVENT on FVENT.FV_CCODIGO = CTZ.formapago " +
                "LEFT join RSFACCAR_SS..FT0020CLID DIR on DIR.DE_CCODUBI = CTZ.direccion  AND DIR.DE_CCODCLI = CTZ.cliente " +
                "LEFT join ESTADOS  EST on EST.est_codigo = CTZ.est_codigo " +
                 "WHERE CTZ.usuario='" + codigo_vendedor.ToString() + "'" + " AND CTZ.est_codigo='3'" +
                 "AND CTZ.fechaemision BETWEEN '"+fechainicio.ToString() +"' AND '" + fecha_fin.ToString()+"' "+
                "UNION " +
                "SELECT EST.est_descripcion,CTZ.codigo,CTZ.moneda,CTZ.adjunto,CTZ.fecharegistro,CTZ.usuario, CLI.CL_CNOMCLI,CLI.CL_CDIRCLI,FVENT.FV_CDESCRI,VEN.VE_CNOMBRE,ALM.A1_CDESCRI FROM " +
                "Cab_Cotizacion_v1 CTZ " +
                "inner join CLienteNuevo_Coti CLI on CLI.CL_CCODCLI = CTZ.cliente " +

                "LEFT join RSFACCAR_SS..FT0020VEND VEN on VEN.VE_CCODIGO = CTZ.vendedor " +
                "LEFT join RSFACCAR_SS..AL0020ALMA ALM on ALM.A1_CALMA = CTZ.almacen " +
                "LEFT join RSFACCAR_SS..FT0020FORV FVENT on FVENT.FV_CCODIGO = CTZ.formapago " +
                "LEFT join ESTADOS  EST on EST.est_codigo = CTZ.est_codigo " +
                "WHERE CTZ.usuario='" + codigo_vendedor.ToString() + "'" + " AND CTZ.est_codigo='3'" +
                "AND CTZ.fechaemision BETWEEN '" + fechainicio.ToString() + "' AND '" + fecha_fin.ToString() + "' " +
                "order by CTZ.fecharegistro DESC";

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CabeceraCotizacion cotizacion = new CabeceraCotizacion();
                    cotizacion.codigo = dr["codigo"].ToString();
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    cotizacion.cliente = dr["CL_CNOMCLI"].ToString();
                    cotizacion.direccion = dr["DE_CDIRECC"].ToString();
                    cotizacion.formapago = dr["FV_CDESCRI"].ToString();
                    cotizacion.vendedor = dr["VE_CNOMBRE"].ToString();
                    cotizacion.moneda = dr["moneda"].ToString();
                    cotizacion.almacen = dr["A1_CDESCRI"].ToString();
                    cotizacion.adjunto = dr["adjunto"].ToString();
                    cotizacion.fechaemision = dr["DE_CDIRECC"].ToString();
                    //  cotizacion.glosa = dr["cliente"].ToString();
                    cotizacion.fecharegistro = dr["fecharegistro"].ToString();
                    cotizacion.usuario = dr["usuario"].ToString();
                    cotizacion.id_estado = dr["est_descripcion"].ToString();
                    //  cotizacion.validador_stock = Convert.ToInt32(dr["stock"].ToString());

                    listado.Add(cotizacion);
                }
            }
            catch (Exception E)
            {
                throw E;
            }
            return listado;

        }

        public bool AgregarCabeceraCot(CabeceraCotizacion cabeceraCot)
        {

            bool respuesta = false;
            int rp = 0;
            SqlDataReader RpStore = null;

            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_CabeceraCoti", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro Cliente
                SqlParameter pcliente = new SqlParameter();
                pcliente.ParameterName = "@cliente";
                pcliente.SqlDbType = SqlDbType.VarChar;
                pcliente.Size = 50;
                pcliente.Value = cabeceraCot.cliente;

                //parametro Apellido
                SqlParameter pdireccion = new SqlParameter();
                pdireccion.ParameterName = "@direccion";
                pdireccion.SqlDbType = SqlDbType.VarChar;
                pdireccion.Size = 50;
                pdireccion.Value = cabeceraCot.direccion;

                //parametro formapago
                SqlParameter pformapago = new SqlParameter();
                pformapago.ParameterName = "@formapago";
                pformapago.SqlDbType = SqlDbType.VarChar;
                pformapago.Size = 50;
                pformapago.Value = cabeceraCot.formapago;

                //parametro Nombre
                SqlParameter pvendedor = new SqlParameter();
                pvendedor.ParameterName = "@vendedor";
                pvendedor.SqlDbType = SqlDbType.VarChar;
                pvendedor.Size = 50;
                pvendedor.Value = cabeceraCot.vendedor;

                //parametro pmoneda
                SqlParameter pmoneda = new SqlParameter();
                pmoneda.ParameterName = "@moneda";
                pmoneda.SqlDbType = SqlDbType.VarChar;
                pmoneda.Size = 50;
                pmoneda.Value = cabeceraCot.moneda;

                //parametro palmacen
                SqlParameter palmacen = new SqlParameter();
                palmacen.ParameterName = "@almacen";
                palmacen.SqlDbType = SqlDbType.VarChar;
                palmacen.Size = 50;
                palmacen.Value = cabeceraCot.almacen;

                //parametro padjunto
                SqlParameter padjunto = new SqlParameter();
                padjunto.ParameterName = "@adjunto";
                padjunto.SqlDbType = SqlDbType.VarChar;
                padjunto.Size = 50;
                padjunto.Value = cabeceraCot.adjunto;

                //parametro pfechaemision
                SqlParameter pfechaemision = new SqlParameter();
                pfechaemision.ParameterName = "@fechaemision";
                pfechaemision.SqlDbType = SqlDbType.VarChar;
                pfechaemision.Size = 50;
                pfechaemision.Value = cabeceraCot.fechaemision;

                //parametro pglosa
                SqlParameter pglosa = new SqlParameter();
                pglosa.ParameterName = "@glosa";
                pglosa.SqlDbType = SqlDbType.VarChar;
                pglosa.Size = 50;
                pglosa.Value = cabeceraCot.glosa;

                //parametro pfecharegistro
                SqlParameter pfecharegistro = new SqlParameter();
                pfecharegistro.ParameterName = "@fecharegistro";
                pfecharegistro.SqlDbType = SqlDbType.VarChar;
                pfecharegistro.Size = 50;
                pfecharegistro.Value = cabeceraCot.fecharegistro;

                //parametro pusuario
                SqlParameter pusuario = new SqlParameter();
                pusuario.ParameterName = "@usuario";
                pusuario.SqlDbType = SqlDbType.VarChar;
                pusuario.Size = 50;
                pusuario.Value = cabeceraCot.usuario;

                //parametro pfecharegistro
                SqlParameter pestado= new SqlParameter();
                pestado.ParameterName = "@estado";
                pestado.SqlDbType = SqlDbType.VarChar;
                pestado.Size = 2;
                pestado.Value = cabeceraCot.id_estado;
               

                cmd.Parameters.Add(pcliente);
                cmd.Parameters.Add(pdireccion);
                cmd.Parameters.Add(pformapago);
                cmd.Parameters.Add(pvendedor);
                cmd.Parameters.Add(pmoneda);
                cmd.Parameters.Add(palmacen);
                cmd.Parameters.Add(padjunto);
                cmd.Parameters.Add(pfechaemision);
                cmd.Parameters.Add(pglosa);
                cmd.Parameters.Add(pfecharegistro);
                cmd.Parameters.Add(pusuario);
                cmd.Parameters.Add(pestado);

               cmd.ExecuteNonQuery();

                //RpStore = cmd.ExecuteReader();
                //if (RpStore.Read())
                //{
                //    rp = Convert.ToInt32(RpStore.GetValue(0).ToString());
                //}
                ////return rp;
              respuesta = true;

            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }

        //BUSCAR Y DEVUELVE 1 CABECERA COTIZACION (ruc)
        public CabeceraCotizacion CotizacionCreada(string usuario)
        {
            String sql,sql3, sql_prueba;
            CabeceraCotizacion cabezera_cotizacion = new CabeceraCotizacion();
            try
            {
            
                cn.Open();

                //FORMA SIN INNER JOIN 
                //sql = "SELECT * FROM Cab_Cotizacion_v1  WHERE codigo= " +
                //"(SELECT codigo FROM Cab_Cotizacion_v1 WHERE codigo = (SELECT MAX(codigo) codigo  FROM Cab_Cotizacion_v1));";   

                //forma con inner join 

                //QUERY ORIGINAL
sql_prueba = "SELECT TOP 1 CTZ.fechaemision,CTZ.almacen,CTZ.codigo,CTZ.moneda,CLI.CL_CNOMCLI,DIR.DE_CDIRECC,FVENT.FV_CDESCRI,VEN.VE_CNOMBRE,ALM.A1_CDESCRI FROM Cab_Cotizacion_v1  CTZ " +
"inner join RSFACCAR_SS..FT0020CLIE CLI on CLI.CL_CCODCLI = CTZ.cliente " +
"left join RSFACCAR_SS..FT0020VEND VEN on VEN.VE_CCODIGO = CTZ.vendedor " +
"LEFT join RSFACCAR_SS..AL0020ALMA ALM on ALM.A1_CALMA = CTZ.almacen " +
"LEFT join RSFACCAR_SS..FT0020FORV FVENT on FVENT.FV_CCODIGO = CTZ.formapago " +
"left join RSFACCAR_SS..FT0020CLID DIR on DIR.DE_CCODUBI = CTZ.direccion AND DIR.DE_CCODCLI = CTZ.cliente " +
"WHERE CTZ.usuario='"+usuario.ToString()+"' "+
"UNION "+
"SELECT TOP 1 CTZ.fechaemision,CTZ.almacen,CTZ.codigo,CTZ.moneda,CLI.CL_CNOMCLI,DIR.DE_CDIRECC,FVENT.FV_CDESCRI,VEN.VE_CNOMBRE,ALM.A1_CDESCRI FROM Cab_Cotizacion_v1  CTZ " +
"inner join ClienteNuevo_Coti CLI on CLI.CL_CCODCLI = CTZ.cliente " +
"LEFT join RSFACCAR_SS..FT0020VEND VEN on VEN.VE_CCODIGO = CTZ.vendedor " +
"LEFT join RSFACCAR_SS..AL0020ALMA ALM on ALM.A1_CALMA = CTZ.almacen " +
"LEFT join RSFACCAR_SS..FT0020FORV FVENT on FVENT.FV_CCODIGO = CTZ.formapago " +
"LEFT join CTZ_DIRCLI DIR on DIR.DE_CCODUBI = CTZ.direccion  AND DIR.DE_CCODCLI = CTZ.cliente " +
"WHERE CTZ.usuario='" + usuario.ToString() + "' ";


                sql = "SELECT CTZ.fechaemision,CTZ.almacen,CTZ.codigo,CTZ.moneda,CLI.CL_CNOMCLI,DIR.DE_CDIRECC,FVENT.FV_CDESCRI,VEN.VE_CNOMBRE,ALM.A1_CDESCRI FROM Cab_Cotizacion_v1  CTZ " +
                "inner join RSFACCAR_SS..FT0020CLIE CLI on CLI.CL_CCODCLI = CTZ.cliente " +
                "left join RSFACCAR_SS..FT0020VEND VEN on VEN.VE_CCODIGO = CTZ.vendedor " +
                "LEFT join RSFACCAR_SS..AL0020ALMA ALM on ALM.A1_CALMA = CTZ.almacen " +
                "LEFT join RSFACCAR_SS..FT0020FORV FVENT on FVENT.FV_CCODIGO = CTZ.formapago " +
                "left join RSFACCAR_SS..FT0020CLID DIR on DIR.DE_CCODUBI = CTZ.direccion AND DIR.DE_CCODCLI = CTZ.cliente " +
                "WHERE codigo = (SELECT codigo FROM Cab_Cotizacion_v1 WHERE codigo = (SELECT MAX(codigo) codigo FROM Cab_Cotizacion_v1)) AND CTZ.usuario='" + usuario.ToString() + "' " +
                "UNION " +
                "SELECT CTZ.fechaemision,CTZ.almacen,CTZ.codigo,CTZ.moneda,CLI.CL_CNOMCLI,DIR.DE_CDIRECC,FVENT.FV_CDESCRI,VEN.VE_CNOMBRE,ALM.A1_CDESCRI FROM Cab_Cotizacion_v1  CTZ " +
                "inner join ClienteNuevo_Coti CLI on CLI.CL_CCODCLI = CTZ.cliente " +
                "LEFT join RSFACCAR_SS..FT0020VEND VEN on VEN.VE_CCODIGO = CTZ.vendedor " +
                "LEFT join RSFACCAR_SS..AL0020ALMA ALM on ALM.A1_CALMA = CTZ.almacen " +
                "LEFT join RSFACCAR_SS..FT0020FORV FVENT on FVENT.FV_CCODIGO = CTZ.formapago " +
                "LEFT join CTZ_DIRCLI DIR on DIR.DE_CCODUBI = CTZ.direccion  AND DIR.DE_CCODCLI = CTZ.cliente " +
                "WHERE codigo = (SELECT codigo FROM Cab_Cotizacion_v1 WHERE codigo = (SELECT MAX(codigo) codigo FROM Cab_Cotizacion_v1)) AND CTZ.usuario='" + usuario.ToString() + "' ";

                cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    //forma con inner join 
                    cabezera_cotizacion.codigo = dr["codigo"].ToString().Trim();
                    cabezera_cotizacion.cliente = dr["CL_CNOMCLI"].ToString().Trim();
                    cabezera_cotizacion.direccion = dr["DE_CDIRECC"].ToString().Trim();
                    cabezera_cotizacion.formapago = dr["FV_CDESCRI"].ToString().Trim();
                    cabezera_cotizacion.vendedor = dr["VE_CNOMBRE"].ToString();
                    cabezera_cotizacion.moneda = dr["moneda"].ToString();
                    cabezera_cotizacion.almacen = dr["A1_CDESCRI"].ToString();
                    cabezera_cotizacion.glosa = dr["almacen"].ToString();
                    cabezera_cotizacion.fechaemision = dr["fechaemision"].ToString();
                    /// forma por codigo 
                    //cabezera_cotizacion.codigo = dr["codigo"].ToString().Trim();
                    //cabezera_cotizacion.cliente = dr["cliente"].ToString().Trim();
                    //cabezera_cotizacion.direccion = dr["direccion"].ToString().Trim();
                    //cabezera_cotizacion.formapago = dr["formapago"].ToString().Trim();
                    //cabezera_cotizacion.vendedor = dr["vendedor"].ToString();
                    //cabezera_cotizacion.moneda = dr["moneda"].ToString();
                    //cabezera_cotizacion.almacen = dr["almacen"].ToString();
                    //  cabezera_cotizacion.glosa = dr["glo"].ToString();


                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cabezera_cotizacion;
        }

        public CabeceraCotizacion CotizacionEditarCabecera(int codigo)
        {
            String sql, sql3;
            CabeceraCotizacion cabezera_cotizacion = new CabeceraCotizacion();
            try
            {

                cn.Open();

                //FORMA SIN INNER JOIN 
                //sql = "SELECT * FROM Cab_Cotizacion_v1  WHERE codigo= " +
                //"(SELECT codigo FROM Cab_Cotizacion_v1 WHERE codigo = (SELECT MAX(codigo) codigo  FROM Cab_Cotizacion_v1));";   
                //forma con inner join 

                //QUERY ORIGINAL
                sql = "SELECT CTZ.direccion,CTZ.formapago,CTZ.vendedor, CLI.CL_CCODCLI ,CTZ.fechaemision,CTZ.almacen,CTZ.codigo,CTZ.moneda,CLI.CL_CNOMCLI,DIR.DE_CDIRECC,FVENT.FV_CDESCRI,VEN.VE_CNOMBRE,ALM.A1_CDESCRI FROM Cab_Cotizacion_v1  CTZ" +
               " left join RSFACCAR_SS..FT0020CLIE CLI on CLI.CL_CCODCLI = CTZ.cliente " +
                "inner join RSFACCAR_SS..FT0020VEND VEN on VEN.VE_CCODIGO = CTZ.vendedor" +
               " inner join RSFACCAR_SS..AL0020ALMA ALM on ALM.A1_CALMA = CTZ.almacen" +
               " inner join RSFACCAR_SS..FT0020FORV FVENT on FVENT.FV_CCODIGO = CTZ.formapago " +
               "left join RSFACCAR_SS..FT0020CLID DIR on DIR.DE_CCODUBI = CTZ.direccion AND DIR.DE_CCODCLI = CTZ.cliente" +
               " WHERE codigo = "+ codigo;

                cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    //forma con inner join 
                    cabezera_cotizacion.codigo = dr["codigo"].ToString().Trim();
                    cabezera_cotizacion.cliente = dr["CL_CNOMCLI"].ToString().Trim();
                    cabezera_cotizacion.direccion = dr["DE_CDIRECC"].ToString().Trim();
                    cabezera_cotizacion.formapago = dr["FV_CDESCRI"].ToString().Trim();
                    cabezera_cotizacion.vendedor = dr["VE_CNOMBRE"].ToString();
                    cabezera_cotizacion.moneda = dr["moneda"].ToString();
                    cabezera_cotizacion.almacen = dr["A1_CDESCRI"].ToString();
                    cabezera_cotizacion.glosa = dr["almacen"].ToString();
                    cabezera_cotizacion.fechaemision = dr["fechaemision"].ToString();
                    cabezera_cotizacion.dato_extra= dr["CL_CCODCLI"].ToString();
                    cabezera_cotizacion.cod_ven = dr["vendedor"].ToString();
                    cabezera_cotizacion.cod_for_pag = dr["formapago"].ToString();
                    cabezera_cotizacion.cod_dir_ubi = dr["direccion"].ToString();
                    /// forma por codigo 
                    //cabezera_cotizacion.codigo = dr["codigo"].ToString().Trim();
                    //cabezera_cotizacion.cliente = dr["cliente"].ToString().Trim();
                    //cabezera_cotizacion.direccion = dr["direccion"].ToString().Trim();
                    //cabezera_cotizacion.formapago = dr["formapago"].ToString().Trim();
                    //cabezera_cotizacion.vendedor = dr["vendedor"].ToString();
                    //cabezera_cotizacion.moneda = dr["moneda"].ToString();
                    //cabezera_cotizacion.almacen = dr["almacen"].ToString();
                    //  cabezera_cotizacion.glosa = dr["glo"].ToString();


                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cabezera_cotizacion;
        }

        public bool AnularCotizacionVendedor(int cabeceraCotizacion, char estado)
        { //se copia del agregar
            bool respuesta = false;
            CabeceraCotizacion cabecera = new CabeceraCotizacion();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_ANULAR_CAB_CTZ", cn);
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

                
                cmd.Parameters.Add(pCodigo);
                cmd.Parameters.Add(pEstado);
               

                cmd.ExecuteNonQuery();
                respuesta = true;

            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }

        public bool anular_detalle_articulo(int cabeceraCotizacion, string codigoarticulo)
        { //se copia del agregar
            bool respuesta = false;
            Detalle_CotizacionE cabecera = new Detalle_CotizacionE();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_ANULAR_DETA_CTZ", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //la unica diferencia es Parametro id  lo copias de buscar 

                SqlParameter pCodigo = new SqlParameter();
                pCodigo.ParameterName = "@codigo";
                pCodigo.SqlDbType = SqlDbType.Int;
                //llamas al objeto 
                pCodigo.Value = cabeceraCotizacion;

                SqlParameter pCodigoarticulo = new SqlParameter();
                pCodigoarticulo.ParameterName = "@codigoarticulo";
                pCodigoarticulo.SqlDbType = SqlDbType.VarChar;
                pCodigoarticulo.Size = 50;
                //llamas al objeto 
                pCodigoarticulo.Value = codigoarticulo;




                cmd.Parameters.Add(pCodigo);
                cmd.Parameters.Add(pCodigoarticulo);



                cmd.ExecuteNonQuery();
                respuesta = true;

            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }

        

        public bool AprobarCotizacionVendedor(int cabeceraCotizacion, char estado,string fechaaprobacion,int id_usuario)
        { //se copia del agregar
            bool respuesta = false;
            CabeceraCotizacion cabecera = new CabeceraCotizacion();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_APROBAR_CAB_CTZ", cn);
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

                //FECHA APROB Y COD USUARIO 
                SqlParameter pfechaAprobacion = new SqlParameter();
                pfechaAprobacion.ParameterName = "@fechaaprobacion";
                pfechaAprobacion.SqlDbType = SqlDbType.VarChar;
                pfechaAprobacion.Size = 50;
                pfechaAprobacion.Value = fechaaprobacion;
                
                //parametro usuarioaprobado
                SqlParameter pusuarioAprobo = new SqlParameter();
                pusuarioAprobo.ParameterName = "@usr_id";
                pusuarioAprobo.SqlDbType = SqlDbType.Int;
                // pEstado.Size = 2;
                pusuarioAprobo.Value = id_usuario;


                cmd.Parameters.Add(pCodigo);
                cmd.Parameters.Add(pEstado);
                cmd.Parameters.Add(pfechaAprobacion);
                cmd.Parameters.Add(pusuarioAprobo);


                cmd.ExecuteNonQuery();
                respuesta = true;

            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }
        public bool RechazarCotizacionVendedor(int cabeceraCotizacion, char estado)
        { //se copia del agregar
            bool respuesta = false;
            CabeceraCotizacion cabecera = new CabeceraCotizacion();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_RECHAZAR_CAB_CTZ", cn);
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


                cmd.Parameters.Add(pCodigo);
                cmd.Parameters.Add(pEstado);


                cmd.ExecuteNonQuery();
                respuesta = true;

            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }

        public bool TotalizarCotizacionVendedor(int cabeceraCotizacion, char estado)
        { //se copia del agregar
            bool respuesta = false;
            CabeceraCotizacion cabecera = new CabeceraCotizacion();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_TOTALIZAR_CAB_CTZ", cn);
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


                cmd.Parameters.Add(pCodigo);
                cmd.Parameters.Add(pEstado);


                cmd.ExecuteNonQuery();
                respuesta = true;

            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }

        public bool EditarCabCtz_Vendedor(int cabeceraCotizacion, string direccion, string formapago, string vendedor,string glosa)
        { //se copia del agregar
            bool respuesta = false;
            CabeceraCotizacion cabecera = new CabeceraCotizacion();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_EDITAR_CAB_CTZ", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //la unica diferencia es Parametro id  lo copias de buscar 

                SqlParameter pCodigo = new SqlParameter();
                pCodigo.ParameterName = "@codigo";
                pCodigo.SqlDbType = SqlDbType.Int;
                //llamas al objeto 
                pCodigo.Value = cabeceraCotizacion;

                //parametro direccion
                SqlParameter pDireccion = new SqlParameter();
                pDireccion.ParameterName = "@direccion";
                pDireccion.SqlDbType = SqlDbType.VarChar;
                pDireccion.Size = 5;
                pDireccion.Value = direccion;

                //parametro formapago
                SqlParameter pFormapago = new SqlParameter();
                pFormapago.ParameterName = "@formapago";
                pFormapago.SqlDbType = SqlDbType.Char;
                pFormapago.Size = 5;
                pFormapago.Value = formapago;

                //parametro vendedor
                SqlParameter pVendedor = new SqlParameter();
                pVendedor.ParameterName = "@vendedor";
                pVendedor.SqlDbType = SqlDbType.Char;
                pVendedor.Size = 5;
                pVendedor.Value = vendedor;

                //parametro glosa
                SqlParameter pGlosa = new SqlParameter();
                pGlosa.ParameterName = "@glosa";
                pGlosa.SqlDbType = SqlDbType.Char;
                pGlosa.Size = 50;
                pGlosa.Value = glosa;


                cmd.Parameters.Add(pCodigo);
                cmd.Parameters.Add(pDireccion);
                cmd.Parameters.Add(pFormapago);
                cmd.Parameters.Add(pVendedor);
                cmd.Parameters.Add(pGlosa);


                cmd.ExecuteNonQuery();
                respuesta = true;

            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }


        public bool CargarImagen_Cotizacion(String Xml)
        {
            bool respuesta = false;
            int rp = 0;
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_FGB_REGISTRAR_FOTO_COTIZACION", cn);
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
               
            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }

        public List<Foto_coti> ListadoFotos(int codigo)
        {
            String sql, Salida = "";
            List<Foto_coti> listado = new List<Foto_coti>();
            try
            {
                cn.Open();

                sql = "SELECT nombre FROM FOTO_COTIZACION where codigocabecera ="+codigo;

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Foto_coti cotizacion = new Foto_coti();
                   
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    cotizacion.imgagenBs = dr["nombre"].ToString();
                 
             

                    listado.Add(cotizacion);
                }
            }
            catch (Exception E)
            {
                throw E;
            }
            return listado;

        }

        public bool GenerarPedido(Generar_pedido generarpedido)
        {

            bool respuesta = false;
         //   int rp = 0;
          //  SqlDataReader RpStore = null;

            try
            {
                cn.Open();
                cmd = new SqlCommand("SPDSN_Pedido_Manage_Saving", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro Cod Cotizacion
                SqlParameter pcod_cotizacion = new SqlParameter();
                pcod_cotizacion.ParameterName = "@codigo";
                pcod_cotizacion.SqlDbType = SqlDbType.Int;
                pcod_cotizacion.Value = generarpedido.codigo_cotizacion;

                //parametro Cod Id Usuario
                SqlParameter pid_usuario = new SqlParameter();
                pid_usuario.ParameterName = "@appUser";
                pid_usuario.SqlDbType = SqlDbType.Int;
                pid_usuario.Value = generarpedido.id_usuario;


                cmd.Parameters.Add(pcod_cotizacion);
                cmd.Parameters.Add(pid_usuario);
          
            

                cmd.ExecuteNonQuery();

                //RpStore = cmd.ExecuteReader();
                //if (RpStore.Read())
                //{
                //    rp = Convert.ToInt32(RpStore.GetValue(0).ToString());
                //}
                ////return rp;
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
