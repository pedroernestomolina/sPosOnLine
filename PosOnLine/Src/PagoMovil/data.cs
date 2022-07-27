using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PagoMovil
{
    
    public class data
    {

        public string nombre { get; set; }
        public string ciRif { get; set; }
        public string telefono { get; set; }
        public string autoAgencia { get; set; }
        public string nombreAgencia { get; set; }
        public decimal monto { get; set; }


        public data()
        {
            nombre = "";
            ciRif = "";
            telefono = "";
            autoAgencia = "";
            nombreAgencia = "";
            monto = 0m;
        }

    }

}