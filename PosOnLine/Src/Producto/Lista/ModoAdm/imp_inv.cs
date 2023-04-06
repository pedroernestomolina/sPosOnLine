using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Lista.ModoAdm
{
    public class imp_inv: IInv
    {
        private IEmp _empCompra;
        private IEmp _empHndInv;
        private IEmp _empUnd;

        public IEmp EmpCompra { get { return _empCompra; } }
        public IEmp EmpHndInv { get { return _empHndInv; } }
        public IEmp EmpUnd { get { return _empUnd; } }


        public imp_inv()
        {
            _empCompra = new imp_emp();
            _empHndInv = new imp_emp();
            _empUnd = new imp_emp();
        }


        public void setEmpCompra(IEmp emp)
        {
            _empCompra = emp;
        }
        public void setEmpInv(IEmp emp)
        {
            _empHndInv = emp;
        }
        public void setEmpUnd(IEmp emp)
        {
            _empUnd = emp;
        }
    }
}