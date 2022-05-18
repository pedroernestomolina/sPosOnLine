using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Resultado
{

    public class Lista<T> : Ficha
    {

        public List<T> ListaD {get; set;}
        public int cntRegistro 
        {
            get 
            {
                var x = 0;
                if (ListaD != null) { x = ListaD.Count(); }
                return x;
            }
        }


        public Lista()
            :base()
        {
            ListaD = null;
        }
    }

}