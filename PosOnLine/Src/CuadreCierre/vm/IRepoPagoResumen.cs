using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.vm
{
    public interface IRepoPagoResumen: _Domain.IRepo
    {
        void setDataCargar(Domain.Models.RepoPagoResumen repoPagoResumen);
        void setMonedaLocal(_Domain.Models.Moneda moneda);
    }
}
