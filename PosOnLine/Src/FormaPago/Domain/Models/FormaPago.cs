using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.Domain.Models
{
    public class FormaPago
    {
        public Guid id { get; set; }
        public MedioPago medioPago { get; set; }
        public decimal factorCambioMedioPago { get; set; }
        public decimal montoIngresado { get; set; }
        public string lote { get; set; }
        public string referencia { get; set; }
        public decimal montoMonedaRefenencia { get; set; }
        public decimal montoMonedaLocal { get; set; }
        public string simboloMonedaLocal { get; set; }
        public string simboloMonedaReferencia { get; set; }
        public decimal Monto { get { return montoIngresado; } }
        public FormaPago()
        {
            id = new Guid();
        }
        //
        public string CabDescripcion { get { return medioPago.nombreMp; } }
        public string CabMonto { get { return montoIngresado.ToString("n2")+medioPago.simboloCurrencies; } }
        public string CabMontoCambio 
        {
            get 
            {
                var rt = "";
                rt = montoMonedaLocal.ToString("n2") + simboloMonedaLocal.Trim() + " / " + montoMonedaRefenencia.ToString("n2") + simboloMonedaReferencia.Trim();
                return rt;
            } 
        }
        public string CabLoteRef 
        { 
            get 
            {
                var rt = "";
                if (medioPago.aplicaLoteRef)
                {
                    rt = "Lote:" + lote.Trim() + ", Ref:" + referencia.Trim();
                }
                return rt;
            } 
        }
    }
}