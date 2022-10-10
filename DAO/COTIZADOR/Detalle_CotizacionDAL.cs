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
   public  class Detalle_CotizacionDAL
    {
        //variables de conexion
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_senda"].ToString());
        SqlCommand cmd = new SqlCommand();


        public bool AgregarDetalleCot(Detalle_CotizacionE DetalleCot)
        {

            bool respuesta = false;

            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_DetalleCoti_v1", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro Codigo Cabecera Cotizacion
                SqlParameter pcodicabecera = new SqlParameter();
                pcodicabecera.ParameterName = "@cab_coti";
                pcodicabecera.SqlDbType = SqlDbType.Int;
                //pcliente.Size = 50;
                pcodicabecera.Value = DetalleCot.codigo_cabecera;

                //parametro Cod Articulo
                SqlParameter pcodArticulo = new SqlParameter();
                pcodArticulo.ParameterName = "@codArticulo";
                pcodArticulo.SqlDbType = SqlDbType.VarChar;
                pcodArticulo.Size = 50;
                pcodArticulo.Value = DetalleCot.codigo_articulo;

                //parametro Nom Articulo
                SqlParameter pNomArticulo = new SqlParameter();
                pNomArticulo.ParameterName = "@nomArticulo";
                pNomArticulo.SqlDbType = SqlDbType.VarChar;
                pNomArticulo.Size = 50;
                pNomArticulo.Value = DetalleCot.nombre_articulo;

                //parametro Precio Cotiz
                SqlParameter pprecio = new SqlParameter();
                pprecio.ParameterName = "@precioCoti";
                pprecio.SqlDbType = SqlDbType.VarChar;
                pprecio.Size = 50;
                pprecio.Value = DetalleCot.preciodecotizacion;

                //parametro Stock
                SqlParameter pstock = new SqlParameter();
                pstock.ParameterName = "@stock";
                pstock.SqlDbType = SqlDbType.VarChar;
                pstock.Size = 50;
                pstock.Value = DetalleCot.stock;

                //parametro Unidad
                SqlParameter punidad = new SqlParameter();
                punidad.ParameterName = "@unidad";
                punidad.SqlDbType = SqlDbType.VarChar;
                punidad.Size = 50;
                punidad.Value = DetalleCot.uni;

                //parametro Cant Solicitada
                SqlParameter pcantSolicitada = new SqlParameter();
                pcantSolicitada.ParameterName = "@cantSolicitada";
                pcantSolicitada.SqlDbType = SqlDbType.Int;
                //pcantSolicitada.Size = 50;
                pcantSolicitada.Value = DetalleCot.cantidad_solicitada;

                //parametro Cant Disponible
                SqlParameter pcantDisponible = new SqlParameter();
                pcantDisponible.ParameterName = "@cantDisponible";
                pcantDisponible.SqlDbType = SqlDbType.Int;
                //pcantDisponible.Size = 50;
                pcantDisponible.Value = DetalleCot.cantidad_disponible;

                //parametro Motivo
                SqlParameter pmotivo = new SqlParameter();
                pmotivo.ParameterName = "@motivo";
                pmotivo.SqlDbType = SqlDbType.VarChar;
                pmotivo.Size = 50;
                pmotivo.Value = DetalleCot.motivo;

                //relase 2 datos de auditoria

                //parametro fecha registro
                SqlParameter pfecharegistro = new SqlParameter();
                pfecharegistro.ParameterName = "@fecharegistro";
                pfecharegistro.SqlDbType = SqlDbType.VarChar;
                pfecharegistro.Size = 50;
                pfecharegistro.Value = DetalleCot.fecha_registro_detalle;
                
                //parametro estado  registro
                SqlParameter pestadoregistro = new SqlParameter();
                pestadoregistro.ParameterName = "@estadoregistro";
                pestadoregistro.SqlDbType = SqlDbType.Char;
                pestadoregistro.Size = 2;
                pestadoregistro.Value = DetalleCot.estado_registro;

                //parametro usuario  registro
                SqlParameter pusuarioregistro = new SqlParameter();
                pusuarioregistro.ParameterName = "@usuregistro";
                pusuarioregistro.SqlDbType = SqlDbType.Int;
                //pestadoregistro.Size = 2;
                pusuarioregistro.Value = DetalleCot.usuario_registro;

                //parametro precio  publico
                SqlParameter ppreciopublico = new SqlParameter();
                ppreciopublico.ParameterName = "@preciopublico";
                ppreciopublico.SqlDbType = SqlDbType.Decimal;
                //pestadoregistro.Size = 2;
                ppreciopublico.Value = DetalleCot.preciopublico;

                //parametro precio  lista
                SqlParameter ppreciolista = new SqlParameter();
                ppreciolista.ParameterName = "@preciolista";
                ppreciolista.SqlDbType = SqlDbType.Decimal;
                //pestadoregistro.Size = 2;
                ppreciolista.Value = DetalleCot.preciolista;


                cmd.Parameters.Add(pcodicabecera);
                cmd.Parameters.Add(pcodArticulo);
                cmd.Parameters.Add(pNomArticulo);
                cmd.Parameters.Add(pprecio);
                cmd.Parameters.Add(pstock);
                cmd.Parameters.Add(punidad);
                cmd.Parameters.Add(pcantSolicitada);
                cmd.Parameters.Add(pcantDisponible);
                cmd.Parameters.Add(pmotivo);
                cmd.Parameters.Add(pusuarioregistro);
                cmd.Parameters.Add(pestadoregistro);
                cmd.Parameters.Add(pfecharegistro);
                cmd.Parameters.Add(ppreciolista);
                cmd.Parameters.Add(ppreciopublico);


                cmd.ExecuteNonQuery();
                respuesta = true;

            }
            catch (Exception E)
            {
                throw E;
            }
            return respuesta;

        }


        public List<Detalle_CotizacionE> AgregarListaDetalleCot ()
        {
            List <Detalle_CotizacionE> lista = new List<Detalle_CotizacionE>();

            bool respuesta = false;


            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_DetalleCoti_v1", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                Detalle_CotizacionE DetalleCot = new Detalle_CotizacionE();

                //parametro Codigo Cabecera Cotizacion
                SqlParameter pcodicabecera = new SqlParameter();
                pcodicabecera.ParameterName = "@cab_coti";
                pcodicabecera.SqlDbType = SqlDbType.Int;
                //pcliente.Size = 50;
                pcodicabecera.Value = DetalleCot.codigo_cabecera;

                //parametro Cod Articulo
                SqlParameter pcodArticulo = new SqlParameter();
                pcodArticulo.ParameterName = "@codArticulo";
                pcodArticulo.SqlDbType = SqlDbType.VarChar;
                pcodArticulo.Size = 50;
                pcodArticulo.Value = DetalleCot.codigo_articulo;

                //parametro Nom Articulo
                SqlParameter pNomArticulo = new SqlParameter();
                pNomArticulo.ParameterName = "@nomArticulo";
                pNomArticulo.SqlDbType = SqlDbType.VarChar;
                pNomArticulo.Size = 50;
                pNomArticulo.Value = DetalleCot.nombre_articulo;

                //parametro Precio Cotiz
                SqlParameter pprecio = new SqlParameter();
                pprecio.ParameterName = "@precioCoti";
                pprecio.SqlDbType = SqlDbType.VarChar;
                pprecio.Size = 50;
                pprecio.Value = DetalleCot.preciodecotizacion;

                //parametro Stock
                SqlParameter pstock = new SqlParameter();
                pstock.ParameterName = "@stock";
                pstock.SqlDbType = SqlDbType.VarChar;
                pstock.Size = 50;
                pstock.Value = DetalleCot.stock;

                //parametro Unidad
                SqlParameter punidad = new SqlParameter();
                punidad.ParameterName = "@unidad";
                punidad.SqlDbType = SqlDbType.VarChar;
                punidad.Size = 50;
                punidad.Value = DetalleCot.uni;

                //parametro Cant Solicitada
                SqlParameter pcantSolicitada = new SqlParameter();
                pcantSolicitada.ParameterName = "@cantSolicitada";
                pcantSolicitada.SqlDbType = SqlDbType.Int;
                //pcantSolicitada.Size = 50;
                pcantSolicitada.Value = DetalleCot.cantidad_solicitada;

                //parametro Cant Disponible
                SqlParameter pcantDisponible = new SqlParameter();
                pcantDisponible.ParameterName = "@cantDisponible";
                pcantDisponible.SqlDbType = SqlDbType.Int;
                //pcantDisponible.Size = 50;
                pcantDisponible.Value = DetalleCot.cantidad_disponible;

                //parametro Motivo
                SqlParameter pmotivo = new SqlParameter();
                pmotivo.ParameterName = "@motivo";
                pmotivo.SqlDbType = SqlDbType.VarChar;
                pmotivo.Size = 50;
                pmotivo.Value = DetalleCot.motivo;

                cmd.Parameters.Add(pcodicabecera);
                cmd.Parameters.Add(pcodArticulo);
                cmd.Parameters.Add(pNomArticulo);
                cmd.Parameters.Add(pprecio);
                cmd.Parameters.Add(pstock);
                cmd.Parameters.Add(punidad);
                cmd.Parameters.Add(pcantSolicitada);
                cmd.Parameters.Add(pcantDisponible);
                cmd.Parameters.Add(pmotivo);


                cmd.ExecuteNonQuery();

                lista.Add(DetalleCot);
                respuesta = true;

            }
            catch (Exception E)
            {
                throw E;
            }
            return lista;

        }


        public List<Detalle_CotizacionE> ListadoDetalleCotizacion_stock_mayor_cero(int codigo_cabecera)
        {
            String sql, Salida = "";
            List<Detalle_CotizacionE> listado = new List<Detalle_CotizacionE>();
            try
            {
                cn.Open();

                sql = "select DIR.DE_CDIRECC, FVENT.FV_CDESCRI, CLI.CL_CNOMCLI ,C_CTZ.cliente,C_CTZ.fecharegistro, FVENT.FV_CDESCRI, VEN.VE_CNOMBRE,VEN.VE_CTELEFO , VEN.VE_CEMAIL, D_CTZ.codigo_cabezera,D_CTZ.nombre_articulo,D_CTZ.codigo_articulo,D_CTZ.preciodecotizacion,D_CTZ.cantidad_solicitada from Cab_Cotizacion_v1 C_CTZ " +
                "left join Deta_Cotizacion_v1 D_CTZ ON C_CTZ.codigo = D_CTZ.codigo_cabezera " +
                "inner join RSFACCAR_SS..FT0020CLIE CLI on CLI.CL_CCODCLI = C_CTZ.cliente " +
   "LEFT join RSFACCAR_SS..FT0020VEND VEN on VEN.VE_CCODIGO = C_CTZ.vendedor " +
   "LEFT join RSFACCAR_SS..FT0020FORV FVENT on FVENT.FV_CCODIGO = C_CTZ.formapago " +
   "LEFT join RSFACCAR_SS..FT0020CLID DIR on DIR.DE_CCODUBI = C_CTZ.direccion  AND DIR.DE_CCODCLI = C_CTZ.cliente " +
   "where C_CTZ.codigo = "+ codigo_cabecera + "  and D_CTZ.stock >= 0 " +
    " UNION " +
    "select DIR.DE_CDIRECC, FVENT.FV_CDESCRI, CLI.CL_CNOMCLI ,C_CTZ.cliente,C_CTZ.fecharegistro, FVENT.FV_CDESCRI, VEN.VE_CNOMBRE,VEN.VE_CTELEFO,VEN.VE_CEMAIL, D_CTZ.codigo_cabezera,D_CTZ.nombre_articulo,D_CTZ.codigo_articulo,D_CTZ.preciodecotizacion,D_CTZ.cantidad_solicitada from Cab_Cotizacion_v1 C_CTZ " +
                "left join Deta_Cotizacion_v1 D_CTZ ON C_CTZ.codigo = D_CTZ.codigo_cabezera " +
                "inner join ClienteNuevo_Coti CLI on CLI.CL_CCODCLI = C_CTZ.cliente " +
   "LEFT join RSFACCAR_SS..FT0020VEND VEN on VEN.VE_CCODIGO = C_CTZ.vendedor " +
   "LEFT join RSFACCAR_SS..FT0020FORV FVENT on FVENT.FV_CCODIGO = C_CTZ.formapago " +
   "LEFT join CTZ_DIRCLI DIR on DIR.DE_CCODUBI = C_CTZ.direccion  AND DIR.DE_CCODCLI = C_CTZ.cliente " +

                "where C_CTZ.codigo =" + codigo_cabecera + " and D_CTZ.stock >=0 ";

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Detalle_CotizacionE Det_cotizacion = new Detalle_CotizacionE();

                    Det_cotizacion.codigo_cabecera = Convert.ToInt32(dr["codigo_cabezera"].ToString());
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    Det_cotizacion.codigo_articulo = dr["codigo_articulo"].ToString();
                    Det_cotizacion.nombre_articulo = dr["nombre_articulo"].ToString();
                    Det_cotizacion.preciodecotizacion = dr["preciodecotizacion"].ToString();
                    Det_cotizacion.cantidad_solicitada = Convert.ToInt32(dr["cantidad_solicitada"].ToString());
                   Det_cotizacion.vendedor = dr["VE_CNOMBRE"].ToString();
                   Det_cotizacion.forma_pago = dr["FV_CDESCRI"].ToString();
                    
                    Det_cotizacion.fecha_registro = dr["fecharegistro"].ToString();
                    Det_cotizacion.nombre_cliente = dr["CL_CNOMCLI"].ToString();
                    Det_cotizacion.ruc_cliente = dr["cliente"].ToString();
                    Det_cotizacion.direccion = dr["DE_CDIRECC"].ToString();
                    Det_cotizacion.telefono_vendedor = dr["VE_CTELEFO"].ToString();
                    Det_cotizacion.correo_vendedor = dr["VE_CEMAIL"].ToString();


                    listado.Add(Det_cotizacion);
                }
                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return listado;

        }

        public List<Detalle_CotizacionE> ListadoDetalleCotizacion_por_cabecera(int codigo_cabecera)
        {
            String sql, Salida = "";
            List<Detalle_CotizacionE> listado = new List<Detalle_CotizacionE>();
            try
            {
                cn.Open();

       sql = "select D_CTZ.uni,D_CTZ.stock, D_CTZ.codigo_cabezera,D_CTZ.nombre_articulo,D_CTZ.codigo_articulo,D_CTZ.preciodecotizacion,D_CTZ.cantidad_solicitada,D_CTZ.cantidad_disponible from Cab_Cotizacion_v1 C_CTZ " +
             "left join Deta_Cotizacion_v1 D_CTZ ON C_CTZ.codigo = D_CTZ.codigo_cabezera " +
             "where C_CTZ.codigo = " + codigo_cabecera + "  and D_CTZ.stock >= 0 and  D_CTZ.motivo='Registro'" +
             " UNION " +
             "select D_CTZ.uni,D_CTZ.stock,D_CTZ.codigo_cabezera,D_CTZ.nombre_articulo,D_CTZ.codigo_articulo,D_CTZ.preciodecotizacion,D_CTZ.cantidad_solicitada,D_CTZ.cantidad_disponible from Cab_Cotizacion_v1 C_CTZ " +
             "left join Deta_Cotizacion_v1 D_CTZ ON C_CTZ.codigo = D_CTZ.codigo_cabezera " +
             "where C_CTZ.codigo =" + codigo_cabecera + " and D_CTZ.stock >=0 and  D_CTZ.motivo='Registro' ";

                cmd = new SqlCommand(sql, cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Detalle_CotizacionE Det_cotizacion = new Detalle_CotizacionE();

                    Det_cotizacion.codigo_cabecera = Convert.ToInt32(dr["codigo_cabezera"].ToString());
                    //cliente.ruc = Convert.ToChar(dr["CL_CCODCLI"].ToString());
                    Det_cotizacion.codigo_articulo = dr["codigo_articulo"].ToString();
                    Det_cotizacion.nombre_articulo = dr["nombre_articulo"].ToString();
                    Det_cotizacion.preciodecotizacion = dr["preciodecotizacion"].ToString();
                    Det_cotizacion.uni = dr["uni"].ToString();
                    Det_cotizacion.cantidad_solicitada = Convert.ToInt32(dr["cantidad_solicitada"].ToString());
                    Det_cotizacion.cantidad_disponible = Convert.ToInt32(dr["cantidad_disponible"].ToString());
                    Det_cotizacion.stock = dr["stock"].ToString();

                    listado.Add(Det_cotizacion);
                }
                cn.Close();
            }
            catch (Exception E)
            {
                throw E;
            }
            return listado;

        }

    }
}
