using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPagoDscto.vm
{
    public interface IDscto: IGestion
    {
        decimal Get_DsctoDado { get; }
        bool procesarFichaIsOK { get; }
        bool abandonarFichaIsOk { get; }
        //
        void setDsctoDar(decimal porct);
        //
        void abandonarFicha();
        void procesarFicha();
    }
}
