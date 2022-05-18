using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Pos.Cerrar
{
    
    public class Ficha
    {

        public int idOperador { get; set; }
        public string estatus { get; set; }
        public FichaArqueo arqueo { get; set; }


        public Ficha()
        {
            idOperador = -1;
            estatus = "";
            arqueo = new FichaArqueo();
        }

    }

}