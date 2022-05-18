using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Lib.Controles.BalanzaSoloPeso
{
    
    public class Resultado
    {

        public bool IsOk { get; set; }
        public string Mensaje { get; set; }
        public decimal Peso { get; set; }


        public Resultado() 
        {
            IsOk = true;
            Mensaje = "";
            Peso = 0.0m;
        }

    }

}