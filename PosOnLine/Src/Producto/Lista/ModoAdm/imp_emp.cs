using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Lista.ModoAdm
{
    public class imp_emp: IEmp
    {
        private int _cont;
        private string _desc;
        private decimal _cnt;


        public decimal GetCont { get { return _cont; } }
        public decimal GetCnt { get { return _cnt; } }
        public string GetDesc
        {
            get
            {
                var _dsc = "";
                return _dsc += _desc.Trim() + "/(" + _cont.ToString().Trim() + ")";
            }
        }


        public imp_emp()
        {
            _cont = 0;
            _desc = "";
            _cnt=0m;
        }


        public void setContEmp(int cont)
        {
            _cont = cont;
        }
        public void setDescEmp(string desc)
        {
            _desc = desc;
        }
        public void setExTotal(decimal ex)
        {
            _cnt = ex;
        }
    }
}