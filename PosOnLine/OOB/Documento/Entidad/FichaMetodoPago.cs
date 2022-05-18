using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Documento.Entidad
{
    
    public class FichaMetodoPago
    {

        public string autoMedioPago { get; set; }
        public string codigoMedioPago { get; set; }
        public string descMedioPago { get; set; }
        public decimal montoRecibido { get; set; }
        public string lote { get; set; }
        public string referencia { get; set; }
        public int cntDivisa 
        { 
            get 
            {  
                var rt=0;
                if (codigoMedioPago.Trim().ToUpper() == "02")
                {
                    var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                    var culture = CultureInfo.CreateSpecificCulture("es-ES");
                    //var culture = CultureInfo.CreateSpecificCulture("en-EN");
                    int.TryParse(lote, style, culture, out rt);
                }
                return rt;
            } 
        }


        public FichaMetodoPago()
        {
            autoMedioPago = "";
            codigoMedioPago = "";
            descMedioPago = "";
            montoRecibido = 0.0m;
            lote = "";
            referencia = "";
        }

    }

}