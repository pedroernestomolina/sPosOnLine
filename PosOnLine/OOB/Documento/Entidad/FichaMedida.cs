using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Documento.Entidad
{
    
    public class FichaMedida
    {

        public string desc { get; set; }
        public decimal cant { get; set; }
        public decimal peso { get; set; }
        public decimal volumen { get; set; }


        public FichaMedida()
        {
            desc = "";
            cant = 0m;
            peso = 0m;
            volumen = 0m;
        }

    }

}