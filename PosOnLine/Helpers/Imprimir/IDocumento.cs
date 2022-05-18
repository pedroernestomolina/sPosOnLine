using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{

    public interface IDocumento
    {

        void setData(data ds);
        void ImprimirDoc();
        void ImprimirCopiaDoc();
        
    }

}