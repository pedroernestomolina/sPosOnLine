using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.Cliente.Handler
{
    public class data: LibUtilitis.Opcion.IData 
    {
        public string codigo { get; set; }
        public string desc { get; set; }
        public string id { get; set; }


        public data()
        {
        }
    }
}
