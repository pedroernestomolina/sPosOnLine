using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreRepo.vm
{
    public interface IRepoPagoDetalle : _Domain.IRepo
    {
        void setMonedaLocal(_Domain.Models.Moneda moneda);
    }
}