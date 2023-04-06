using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Lista.ModoAdm
{
    public interface IInv
    {
        IEmp EmpCompra { get; }
        IEmp EmpHndInv { get; }
        IEmp EmpUnd { get; }

        void setEmpCompra(IEmp emp);
        void setEmpInv(IEmp emp);
        void setEmpUnd(IEmp emp);
    }
}