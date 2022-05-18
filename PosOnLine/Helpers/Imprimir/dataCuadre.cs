using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{
    
    public class dataCuadre
    {

        public string Usuario { get; set; }

        public int cntFAC { get; set; }
        public int cntNCR { get; set; }
        public int cntNEN { get; set; }
        public int cntFACAnu { get; set; }
        public int cntNCRAnu { get; set; }
        public int cntNENAnu { get; set; }
        public decimal montoFAC { get; set; }
        public decimal montoNCR { get; set; }
        public decimal montoNEN { get; set; }
        public decimal montoFACAnu { get; set; }
        public decimal montoNCRAnu { get; set; }
        public decimal montoNENAnu { get; set; }
        public decimal montoVenta { get; set; }
        public decimal montoVentaContado { get; set; }
        public decimal montoVentaCredito { get; set; }
        public decimal efectivo_s { get; set; }
        public decimal divisa_s { get; set; }
        public decimal electronico_s { get; set; }
        public decimal otros_s { get; set; }
        public decimal devoluciones_s { get; set; }
        public decimal credito_s { get; set; }
        public decimal cambio_s { get; set; }
        public decimal efectivo_u { get; set; }
        public decimal divisa_u { get; set; }
        public decimal electronico_u { get; set; }
        public decimal otros_u { get; set; }
        public int cnt_efectivo_s { get; set; }
        public int cnt_divisa_s { get; set; }        
        public int cnt_electronico_s { get; set; }        
        public int cnt_otros_s { get; set; }
        public int cnt_divisa_u { get; set; }
        public decimal cuadre_s { get; set; }
        public decimal cuadre_u { get; set; }
        //
        public int cntDocContado { get; set; }
        public int cntDocCredito { get; set; }


        public dataCuadre()
        {
            Usuario = "";
            cntDocContado = 0;
            cntDocCredito = 0;
            //
            cntFAC = 0;
            cntFACAnu = 0;
            cntNCR=0;
            cntNCRAnu = 0;
            cntNEN = 0;
            cntNENAnu=0;
            montoFAC = 0.0M;
            montoFACAnu = 0.0M;
            montoNCR = 0.0M;
            montoNCRAnu = 0.0M;
            montoNEN = 0.0M;
            montoNENAnu = 0.0M;
            montoVenta = 0.0m;
            montoVentaContado = 0.0m;
            montoVentaCredito = 0.0m;
            //
            efectivo_s = 0.0m;
            divisa_s = 0.0m;
            electronico_s = 0.0m;
            otros_s = 0.0m;
            devoluciones_s = 0.0m;
            credito_s = 0.0m;
            cambio_s = 0.0m;
            //
            efectivo_u = 0.0m;
            divisa_u = 0.0m;
            electronico_u = 0.0m;
            otros_u = 0.0m;
            //
            cnt_efectivo_s = 0;
            cnt_divisa_s=0;
            cnt_electronico_s=0;
            cnt_otros_s=0;
            //
            cnt_divisa_u = 0;
            //
            cuadre_s = 0.0m;
            cuadre_u = 0.0m;
        }

    }

}