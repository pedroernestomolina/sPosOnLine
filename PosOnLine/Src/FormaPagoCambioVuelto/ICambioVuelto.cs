using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPagoCambioVuelto
{
    public interface ICambioVuelto: IGestion
    {
        bool abandonarIsOK { get; }
        bool validacionIsOk { get; }
        Domain.Models.DataRetornar Get_DataRetornar { get; }
        //
        void setMontoValidar(decimal monto);
        void setTasaCambio(decimal factor);
        //
        void abandonarFicha();
        void procesarFicha();
   }
}