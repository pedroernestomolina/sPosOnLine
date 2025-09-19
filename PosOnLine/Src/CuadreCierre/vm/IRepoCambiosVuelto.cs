using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.vm
{
    public interface IRepoCambiosVuelto: _Domain.IRepo
    {
        void setDataCargar(List<Domain.Models.RepoCambiosVuelto> list);
    }
}
