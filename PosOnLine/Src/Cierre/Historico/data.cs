using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Cierre.Historico
{
    
    public class data
    {

        public int id { get; set; }
        public string idEquipo { get; set; }
        public string fechaHora { get; set; }
        public string cierreNro { get; set; }


        public data ()
        {
            id = -1;
            idEquipo = "";
            fechaHora = "";
            cierreNro = "";
        }

    }

}