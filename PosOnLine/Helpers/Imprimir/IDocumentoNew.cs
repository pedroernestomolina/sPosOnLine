using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{
    public interface IDocumentoNew
    {
        void setData(data ds);
        void ImprimirDoc();
        void ImprimirCopiaDoc();
        void setImprimirQR(dataQR dat);
        void setEmpresa(OOB.Sistema.Empresa.Ficha ficha);
    }
}