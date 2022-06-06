using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Src.Principal
{
    
    public class dataItem
    {
        
        public string prdDesc { get; set; }
        public string prdCod { get; set; }
        public decimal cnt { get; set; }
        public string empaqueCont  { get; set; }


        public dataItem() 
        {
            prdDesc = "";
            prdCod = "";
            cnt = 0m;
            empaqueCont = "";
        }

    }

}