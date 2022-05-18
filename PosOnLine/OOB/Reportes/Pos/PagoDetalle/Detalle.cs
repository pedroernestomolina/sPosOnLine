using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Reportes.Pos.PagoDetalle
{
    
    public class Detalle
    {

        public decimal importe { get; set; }
        public decimal montoRecibido { get; set; }
        public string medioPagCodigo { get; set; }
        public string medioPagDesc { get; set; }
        public string loteCntDivisa { get; set; }
        public string refTasaDivisa { get; set; }
        public bool medioPagIsDivisa { get { return medioPagCodigo.Trim().ToUpper() == "02"; } }
        public decimal cntDivisa 
        {
            get 
            { 
                var rt=0.0m;
                if (medioPagIsDivisa)
                {
                    rt = Decimal.Parse(loteCntDivisa);
                }
                return rt;
            }
        }
        public decimal tasaDivisa
        {
            get
            {
                var rt = 0.0m;
                if (medioPagIsDivisa)
                {
                    rt = Decimal.Parse(refTasaDivisa);
                }
                return rt;
            }
        }
        public string lote
        {
            get
            {
                var rt = "";
                if (!medioPagIsDivisa)
                    rt = loteCntDivisa;
                return rt;
            }
        }
        public string referencia 
        {
            get
            {
                var rt = "";
                if (!medioPagIsDivisa)
                    rt = refTasaDivisa;
                return rt;
            }
        }


        public Detalle() 
        {
            importe = 0.0m;
            montoRecibido = 0.0m;
            medioPagCodigo = "";
            medioPagDesc = "";
            loteCntDivisa = "";
            refTasaDivisa = "";
        }

    }

}