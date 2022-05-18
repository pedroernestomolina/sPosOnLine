using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Resultado
{

    public class FichaEntidad<T> : Ficha
    {

        public T Entidad { get; set; }


        public FichaEntidad()
            : base()
        {
        }

    }

}