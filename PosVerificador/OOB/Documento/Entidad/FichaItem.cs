using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.OOB.Documento.Entidad
{
    
    public class FichaItem
    {

        public string prdDesc { get; set; }
        public string prdCod { get; set; }
        public decimal cnt { get; set; }
        public string empaque { get; set; }
        public int empCont { get; set; }


        public FichaItem() 
        {
            prdDesc = "";
            prdCod = "";
            cnt = 0m;
            empaque = "";
            empCont = 0;
        }

    }

}