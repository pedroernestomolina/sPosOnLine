using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Lista.ModoAdm
{
    public class imp_dataPrd: IDataPrd
    {
        private IEmpVta _vta1;
        private IEmpVta _vta2;
        private IEmpVta _vta3;
        private IInv _inv;
        private string _autoPrd;
        private string _codigoPrd;
        private string _nombrePrd;
        private string _plu;
        private decimal _exTotal;
        private decimal _tasaIva;
        private bool _admDivisa;
        private decimal _tasaCambio;


        public IEmpVta EmpVta1 { get { return _vta1; } }
        public IEmpVta EmpVta2 { get { return _vta2; } }
        public IEmpVta EmpVta3 { get { return _vta3; } }
        public IInv Inv { get { return _inv; } }
        public string Codigo { get { return _codigoPrd; } }
        public string Nombre { get{return _nombrePrd;} }
        public decimal CantidadEx { get { return _exTotal; } }
        public string PLU { get { return _plu; } }
        public string GetAutoPrd { get { return _autoPrd; } }
        public string GetDesc { get { return _codigoPrd.Trim() + Environment.NewLine + _nombrePrd.Trim(); } }


        public imp_dataPrd()
        {
            _autoPrd = "";
            _codigoPrd = "";
            _nombrePrd = "";
            _plu="";
            _exTotal = 0m;
            _tasaIva = 0m;
            _tasaCambio = 0m;
            _admDivisa = false;
            _vta1 = new imp_empVta();
            _vta2 = new imp_empVta();
            _vta3 = new imp_empVta();
            _inv = new imp_inv();
        }

        public void setPrd(string auto,string codigo, string nombre, decimal exTotal, string plu)
        {
            _autoPrd = auto;
            _codigoPrd = codigo;
            _nombrePrd=nombre;
            _plu = plu;
            _exTotal = exTotal;
        }

        private decimal _exEmpCompra;
        private decimal _exEmpInv;
        private decimal _exEmpUnd;
        private decimal _totEx;
        public void setInv(IEmp hnd_Compra, IEmp hnd_Inv, IEmp hnd_Und, decimal exTotal)
        {
            _exEmpCompra = 0m;
            _exEmpInv = 0m;
            _exEmpUnd = 0m;
            _totEx = exTotal;
            if (hnd_Compra.GetCont> 0m)
            {
                _exEmpCompra = (int)(_totEx / hnd_Compra.GetCont);
                _totEx -= (_exEmpCompra * hnd_Compra.GetCont);
            }
            if (hnd_Inv.GetCont> 0m)
            {
                _exEmpInv = (int)(_totEx / hnd_Inv.GetCont);
                _totEx -= (_exEmpInv * hnd_Inv.GetCont);
            }
            _exEmpUnd = (int)(_totEx);
            //
            hnd_Compra.setExTotal(_exEmpCompra);
            hnd_Inv.setExTotal(_exEmpInv);
            hnd_Und .setExTotal(_exEmpUnd);
            //
            _inv.setEmpCompra(hnd_Compra);
            _inv.setEmpInv(hnd_Inv);
            _inv.setEmpUnd(hnd_Und);
        }
        public void setPVta(IEmpVta vt1, IEmpVta vt2, IEmpVta vt3, decimal tasaIva, bool admDivisa,decimal tasaCambio)
        {
            _tasaIva = tasaIva;
            _admDivisa = admDivisa;
            _tasaCambio = tasaCambio;
            _vta1 = vt1;
            _vta1.setTasaIva(_tasaIva);
            _vta1.setAdmDivisa(_admDivisa);
            _vta1.setTasaCambio(_tasaCambio);
            _vta2 = vt2;
            _vta2.setTasaIva(_tasaIva);
            _vta2.setAdmDivisa(_admDivisa);
            _vta2.setTasaCambio(_tasaCambio);
            _vta3 = vt3;
            _vta3.setTasaIva(_tasaIva);
            _vta3.setAdmDivisa(_admDivisa);
            _vta3.setTasaCambio(_tasaCambio);
        }
    }
}