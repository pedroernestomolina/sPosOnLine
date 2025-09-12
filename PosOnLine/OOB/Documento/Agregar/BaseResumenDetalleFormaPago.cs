using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Documento.Agregar
{
    public class BaseResumenDetalleFormaPago
    {
        public int idResumen { get; set; }
        public string idMedioPago { get; set; }
        public string codigoMedioPago { get; set; }
        public string descripcionMedioPago { get; set; }
        public int idCurrencies { get; set; }
        public string codigoCurrencies { get; set; }
        public string descripcionCurrencies { get; set; }
        public string simboloCurrencies { get; set; }
        public decimal tasaCurrencies { get; set; }
        public decimal montoIngresao { get; set; }
        public string loteNro { get; set; }
        public string referenciaNro { get; set; }
        public int signo { get; set; }
        public string estatusAnulado { get; set; }
        public decimal montoIngresoMonedaLocal { get; set; }
        public decimal montoIngresoMonedaReferencia { get; set; }
        public bool estatusAplicaBonoPorPagoDivisa { get; set; }
        public bool estatusAplicaIGTF { get; set; }
        public decimal factorCambio { get; set; }
        //
        public BaseResumenDetalleFormaPago()
        {
            idResumen = -1;
            idMedioPago = "";
            codigoMedioPago = "";
            descripcionMedioPago = "";
            idCurrencies = -1;
            codigoCurrencies = "";
            descripcionCurrencies = "";
            simboloCurrencies = "";
            tasaCurrencies = 0m;
            montoIngresao=0m;
            loteNro="";
            referenciaNro="";
            signo = 1;
            estatusAnulado = "0";
            montoIngresoMonedaLocal = 0m;
            montoIngresoMonedaReferencia = 0m;
            estatusAplicaBonoPorPagoDivisa = false;
            estatusAplicaIGTF = false;
            factorCambio = 0m;
        }
    }
}