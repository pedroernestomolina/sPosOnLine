using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{
    
    public class dataQR
    {

        public int idVerificador { get; set; }
        public string autoDoc { get; set; }
        public string autoCierre { get; set; }
        public string numDoc { get; set; }
        public string codDoc { get; set; }
        public decimal montoDoc { get; set; }


        public dataQR()
        {
            idVerificador = -1;
            autoDoc = "";
            autoCierre = "";
            numDoc = "";
            codDoc = "";
            montoDoc = 0m;
        }

    }

}