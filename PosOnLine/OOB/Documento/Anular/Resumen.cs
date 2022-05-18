using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Documento.Anular
{
    
    public class Resumen
    {

        public int idResumen { get; set; }
        public decimal monto { get; set; }


        public Resumen()
        {
            idResumen = -1;
            monto= 0.0m;
        }

    }

}