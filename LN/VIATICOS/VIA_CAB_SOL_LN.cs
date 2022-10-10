using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD.VIATICOS;
using DAO.VIATICOS;
using System.Data;

namespace LN.VIATICOS
{
    public class VIA_CAB_SOL_LN
    {
        VIA_CAB_SOL_DAO ViaCabSol_DAO = new VIA_CAB_SOL_DAO();


     
        public bool AgregarCabSolViatico(Via_Cab_Solicitud viacab)
        {
            return ViaCabSol_DAO.AgregarCabSolViatico(viacab);

        }

        public bool RegistroDetallePresupuesto(Via_Det_Presupuesto vdp)
        {
            return ViaCabSol_DAO.RegistroDetallePresupuesto(vdp);

        }
        public bool Registrar_Mot_Viaje(Via_Mot_Viaje mot)
        {
            return ViaCabSol_DAO.Registrar_Mot_Viaje(mot);

        }
        public bool Registrar_Med_Viaje(Via_Med_Viaje med)
        {
            return ViaCabSol_DAO.Registrar_Med_Viaje(med);

        }
        



        public bool EditarDetallePresupuesto(Via_Det_Presupuesto vdp)
        {
            return ViaCabSol_DAO.EditarDetallePresupuesto(vdp);

        }

        
        public bool AnularDetallePresupuesto(Via_Det_Presupuesto vdp)
        {
            return ViaCabSol_DAO.AnularDetallePresupuesto(vdp);

        }
        

        public List<Via_Med_Viaje> ListadoMediosViaje()
        {
            return ViaCabSol_DAO.ListadoMediosViaje();

        }
        
        public List<Via_Mot_Viaje> ListadoMotivosVaiaje()
        {
            return ViaCabSol_DAO.ListadoMotivosViaje();

        }
        public List<Via_Lineas> ListadoLineasUsuario()
        {
            return ViaCabSol_DAO.ListadoLineasUsuario();

        }
        public List<VIA_Gerente_Linea> ListadoGerenteLineas()
        {
            return ViaCabSol_DAO.ListadoGerenteLineas();

        }
        public List<Via_Estados> ListadoEstados(int app_function)
        {
            return ViaCabSol_DAO.ListadoEstados(app_function);

        }
        public List<Via_Det_Con_Gastos> ListadoLiquidaciones(int repre,string f_ini , string f_fin)
        {
            return ViaCabSol_DAO.ListadoLiquidaciones(repre,f_ini,f_fin);

        }
        

        public List<Via_Departamento> ListadoDepartamentos()
        {
            return ViaCabSol_DAO.ListadoDepartamentos();

        }
        public List<Via_Provincias> ListadoProvincias(string id_departamento)
        {
            return ViaCabSol_DAO.ListadoProvincias(id_departamento);

        }
        public List<Via_Distrito> ListadoDistritos(string id_provincia)
        {
            return ViaCabSol_DAO.ListadoDistritos(id_provincia);

        }
        public Via_Usuario ObtenerUsuario(int id_usr)
        {
            return ViaCabSol_DAO.ObtenerUsuario(id_usr);
        }
        public List<Via_ClienteSofcom> ListadoClientesSoftcom()
        {
            return ViaCabSol_DAO.ListadoClientesSoftcom();
        }
        public List<Via_Medicos> ListadoMedicosSoftcom()
        {
            return ViaCabSol_DAO.ListadoMedicosSoftcom();
        }
        
        public List<Via_Representanre> ListadoRepresentantes(int usr_id)
        {
            return ViaCabSol_DAO.ListadoRepresentantes(usr_id);
        }
        public bool UpdateFlagUser(int usr_id)
        {
            return ViaCabSol_DAO.UpdateFlagUser(usr_id);
        }
        
        public Via_Cab_Solicitud ObtenerUltimoViaticoCreadoporUsu(int usr_id)
        {
            return ViaCabSol_DAO.ObtenerUltimoViaticoCreadoporUsu(usr_id);
        }

        public bool AgregarDetalleCliente(string cod_cliente,string nom_cliente,int vcs_id,int usr_id,double precio)
        {
            return ViaCabSol_DAO.AgregarDetalleCliente(cod_cliente, nom_cliente, vcs_id,usr_id, precio);
        }

        public List<Via_Det_Clie>ListadoDetClie(int vcs_id)
        {
            return ViaCabSol_DAO.ListadoDetClie(vcs_id);
        }

        public bool AnularDetCliente(String codcliente,int codsolicitud, int usrid)
        {
            return ViaCabSol_DAO.AnularDetCliente(codcliente,codsolicitud, usrid);

        }

        public List<Via_Cab_Solicitud> ListadoViaticosCreados(int usr_id,string estado)
        {
            return ViaCabSol_DAO.ListadoViaticosCreados(usr_id, estado);
        }

        public bool AgregarDetConGastos(Via_Det_Con_Gastos via_det_con_gastos)
        {


            return ViaCabSol_DAO.AgregarDet_Con_Gastos(via_det_con_gastos);
        }

        public string AgregarDetConGastos_xml(string xml)
        {
            return ViaCabSol_DAO.AgregarDet_Con_Gastos_XML(xml);
        }


        public List<ConceptopGasto> ListadoConceptoGasto()
        {
            return ViaCabSol_DAO.ListadoConceptoGasto();
        }
        public List<ConceptopGasto> ListadoConceptoGasto_master()
        {
            return ViaCabSol_DAO.ListadoConceptoGasto_master();
        }

        

        public List<Via_Det_Con_Gastos> ListadoDetGastos(int vcs_id)
        {
            return ViaCabSol_DAO.ListadoDetGastos(vcs_id);
        }

        public List<Via_Det_Presupuesto>ListadoDet_Presupuesto(int id_solicitud)
        {
            return ViaCabSol_DAO.ListadoDet_Presupuesto(id_solicitud);
        }

        public Via_Cab_Solicitud MontoPresupuestadoporSolicitud(int id_solicitud)
        {
            return ViaCabSol_DAO.MontoPresupuestadoporSolicitud(id_solicitud);
        }

        public String Enviar__aproba_glinea(int id_sol , string es , int id_usr)
        {
            return ViaCabSol_DAO.Enviar__aproba_glinea(id_sol, es, id_usr);
        }

        public String AprobarVaitico(int id_sol, string es, int id_usr)
        {
            return ViaCabSol_DAO.AprobarViaitico(id_sol, es, id_usr);
        }

        public Via_Cab_Solicitud ObtenerSolicitudViatico(int id_solicitud)
        {
            return ViaCabSol_DAO.ObtenerSolicitudViatico(id_solicitud);
        }

        public List<Via_Cab_Solicitud> ListadoViaticosCreados_apro(string estado,int id_repre)
        {
            return ViaCabSol_DAO.ListadoViaticosCreados_apro(estado,id_repre);
        }

        public List<Via_Motivo> ListadoMotivos()
        {
            return ViaCabSol_DAO.ListadoMotivos();

        }

        public string desaprobar_viatico(int codigo, string estado,int usr_id, int id_motanul)
        {
            return ViaCabSol_DAO.desaprobar_viatico(codigo,estado, usr_id, id_motanul);
        }

        public string Asignar_Linea(int id_linea, int id_genente)
        {
            return ViaCabSol_DAO.Asignar_Linea( id_linea, id_genente);
        }

        public string Saldo_Liquidacion(int id_solicitud)
        {
            return ViaCabSol_DAO.Saldo_liquidacion( id_solicitud);
        }

        public DataTable ListarCLientesconDatatable(int repre)
        {
            return ViaCabSol_DAO.ListarCLientesconDatatable(repre);

        }
        


    }
}
