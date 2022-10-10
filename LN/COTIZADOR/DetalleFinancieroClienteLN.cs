using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DAO;

namespace LN
{
   public class DetalleFinancieroClienteLN
    {
        DetalleFinancieraClienteDAO dt_fnz_cli_DAO = new DetalleFinancieraClienteDAO();
        
        public DetalleFinancieroCliente ObtenerDetalleFinanciero(string ruccliente)
        {

            return dt_fnz_cli_DAO.ObtenerDetalleFinanciero(ruccliente);

        }

        public List<DocumentosVencidosCliente> ListaDocumentosPendientes(string ruccliente)
        {

            return dt_fnz_cli_DAO.Lista_documentos_vencidos(ruccliente);

        }
    }
}
