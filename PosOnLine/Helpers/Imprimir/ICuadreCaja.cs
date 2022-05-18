using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{
    
    public interface ICuadreCaja
    {

        void setData(dataCuadre ds);
        void ImprimirDoc();

    }

}