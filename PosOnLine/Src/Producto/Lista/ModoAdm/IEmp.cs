using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Lista.ModoAdm
{
    public interface IEmp
    {
        decimal GetCont { get; }
        string GetDesc { get; }
        decimal GetCnt { get;  }

        void setContEmp(int cont);
        void setDescEmp(string desc);
        void setExTotal(decimal ex);
    }
}