using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.Domain.Models
{
    public class DataRetornar
    {
        public decimal MontoCambioDarMonLocal {get;set;}
        public decimal MontoCambioDarMonReferencia { get; set; }
        public decimal FactorCambio {get;set;}
        public bool EstatusCuentaIsCredito { get; set; }
        //
        public decimal DescuentoPorct { get; set; }
        public decimal MontoRecibidoMonLocal { get; set; }
        public decimal MontoRecibidoMonReferencia { get; set; }
        public decimal ImporteDocMonLocal { get; set; }
        public decimal ImporteDocMonReferencia { get; set; }
        public bool IGTF_IsActivo { get; set; }
        public decimal IGTF_Tasa { get; set; }
        public decimal IGTF_MontoBaseAplicaMonLocal { get; set; }
        public decimal IGTF_MontoBaseAplicaMonReferencia { get; set; }
        public decimal IGTF_ImporteMonLocal { get; set; }
        public List<FormaPago> FormasPago { get; set; }
        public Models.Moneda MonedaLocal { get; set; }
        public Models.Moneda MonedaReferencia { get; set; }
        public decimal PorctBonoPorPagoDivisa { get; set; }
        public decimal MontoBonoMonLocalPorPagoDivisa { get; set; }
        public decimal MontoBonoMonReferenciaPorPagoDivisa { get; set; }
        public string EstatusBonoPorPagoDivisa { get; set; }
        public FormaPagoBono FPBonoPorDivisa { get; set; }
        public decimal MaximoBonoDadoPorPagoDivisa { get; set; }
        public decimal MaximoBonoDadoMonLocal_PorPagoDivisa { get; set; }

        
        //
        public bool IsCreditoOk { get {return EstatusCuentaIsCredito;} }
        public decimal MontoRecibido { get { return MontoRecibidoMonLocal; } }
        public decimal MontoCambioDar { get { return MontoCambioDarMonLocal; } }
        public decimal MontoPagar { get { return ImporteDocMonLocal; } }
        public decimal MontoPagarDivisa { get { return ImporteDocMonReferencia; } }
        public bool AplicarIGTF { get { return IGTF_IsActivo; } }
        public decimal TasaIGTF { get { return IGTF_Tasa; } }
        public decimal BaseAplicaIGTFMonAct { get { return IGTF_MontoBaseAplicaMonLocal; } }
        public decimal BaseAplicaIGTFMonDiv { get { return IGTF_MontoBaseAplicaMonReferencia; } }
        public decimal MontoPorIGTF { get { return IGTF_ImporteMonLocal; } }
        public bool EstatusBonoPorPagoDivisaIsActivo { get { return EstatusBonoPorPagoDivisa.Trim().ToUpper() == "1"; } }
        public List<FormaPago> PagoDetalles { get { return FormasPago; } }
        public void Limpiar()
        {
        }
    }
}