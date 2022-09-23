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
        public Helpers.ficha agencia { get; set; }
        public decimal monto { get; set; }


        public data()
        {
            nombre = "";
            ciRif = "";
            telefono = "";
            agencia = null;
            monto = 0m;
        }

    }

}