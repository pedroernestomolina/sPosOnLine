using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Documento.Agregar
{
    public class BaseResumenGeneral
    {
        public int idResumen { get; set; }
        public string codigoDocumento { get; set; }
        public string nombreDocumento { get; set; }
        public string varianteDocumento { get; set; }
        public int signoDocumento { get; set; }
        public string estatusCredito { get; set; }
        public decimal montoMonLocal { get; set; }
        public decimal montoMonReferencia { get; set; }
        public decimal montoPendMonLocal { get; set; }
        public decimal montoPendMonReferencia { get; set; }
        public decimal montoRecibidoMonLocal { get; set; }
        public decimal montoRecibidoMonReferencia { get; set; }
        public decimal cambioVuelto { get; set; }
        public decimal cambioVueltoMonReferencia { get; set; }
        public decimal vueltoDadoPagoEfectivo { get; set; }
        public decimal vueltoDadoPagoDivisa { get; set; }
        public decimal vueltoDadoPagoMovil { get; set; }
        public decimal cntDivisaEntregada { get; set; }
        public string estatusAnulado { get; set; }
        public decimal factorCambio { get; set; }
        public decimal bonoPagoDivisaMonLocal { get; set; }
        public decimal bonoPagoDivisaMonReferencia{ get; set; }
        public decimal igtfMonLocal  { get; set; }
        public BaseResumenGeneral()
        {
            idResumen = -1;
            codigoDocumento = "";
            nombreDocumento = "";
            varianteDocumento = "";
            signoDocumento = 1;
            estatusCredito = "";
            montoMonLocal = 0m;
            montoMonReferencia = 0m;
            montoPendMonLocal = 0m;
            montoPendMonReferencia = 0m;
            montoRecibidoMonLocal = 0m;
            montoRecibidoMonReferencia = 0m;
            cambioVuelto= 0m;
            vueltoDadoPagoDivisa = 0m;
            vueltoDadoPagoEfectivo = 0m;
            vueltoDadoPagoMovil = 0m;
            cntDivisaEntregada = 0m;
            estatusAnulado = "";
            factorCambio = 0m;
            bonoPagoDivisaMonLocal = 0m;
            bonoPagoDivisaMonReferencia = 0m;
            igtfMonLocal = 0m;
        }
    }
}