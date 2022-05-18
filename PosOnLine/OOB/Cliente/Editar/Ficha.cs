using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Cliente.Editar
{
    
    public class Ficha
    {

        public string auto { get; set; }
        public string ciRif { get; set; }
        public string razonSocial { get; set; }
        public string dirFiscal { get; set; }
        public string telefono { get; set; }


        public Ficha()
        {
            auto = "";
            ciRif = "";
            razonSocial = "";
            dirFiscal = "";
            telefono = "";
        }

    }

}