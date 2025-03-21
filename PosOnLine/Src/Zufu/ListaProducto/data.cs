using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ListaProducto
{
    public class data : Idata
    {
        private OOB.Producto.Lista.Ficha _ficha;
        private decimal _factorCambio;
        private decimal _porctBonoDivisa;
        private bool _habilitarBonoDivisa;
        //
        private decimal _p1;
        private decimal _p2;
        private decimal _p3;
        private decimal _p1Divisa;
        private decimal _p2Divisa;
        private decimal _p3Divisa;
        //
        private decimal _exEmpCompra;
        private decimal _exEmpInv;
        private decimal _exEmpUnd;
        private decimal _totEx;
        private string _dscEmpCompra;
        private string _dscEmpInv;
        private string _dscEmpUnd;
        //
        public string CodigoPrd { get; set; }
        public string NombrePrd { get; set; }
        public string ExTotalPrd { get; set; }
        //PRECIOS
        public string Empaque1 { get { return _ficha.descEmp_1 + "/ (" + _ficha.contEmp_1.ToString("n0") + ")"; } }
        public string Empaque2 { get { return _ficha.descEmp_2 + "/ (" + _ficha.contEmp_2.ToString("n0") + ")"; } }
        public string Empaque3 { get { return _ficha.descEmp_3 + "/ (" + _ficha.contEmp_3.ToString("n0") + ")"; } }
        public string Precio1 { get { return _p1.ToString("n2") + "/ ( $ " + _p1Divisa.ToString("n2") + ")"; } }
        public string Precio2 { get { return _p2.ToString("n2") + "/ ( $ " + _p2Divisa.ToString("n2") + ")"; } }
        public string Precio3 { get { return _p3.ToString("n2") + "/ ( $ " + _p3Divisa.ToString("n2") + ")"; } }
        public string Precio1ConBono { get { return precioBono(_p1, _p1Divisa); } }
        public string Precio2ConBono { get { return precioBono(_p2, _p2Divisa); } }
        public string Precio3ConBono { get { return precioBono(_p3, _p3Divisa); } }
        public string TituloPrecioBono { get { return tituloPrecioBono(); } }
        //INVENTARIO
        public decimal ExInvEmpCompra { get { return _exEmpCompra; } }
        public decimal ExInvEmpInv { get { return _exEmpInv; } }
        public decimal ExInvEmpUnd { get { return _exEmpUnd; } }
        public string DescEmpCompra { get { return _dscEmpCompra; } }
        public string DescEmpInv { get { return _dscEmpInv; } }
        public string DescEmpUnd { get { return _dscEmpUnd; } }
        //
        public bool IsOkEmp1 { get { return isOkEmp1(); } }
        public bool IsOkEmp2 { get { return isOkEmp2(); } }
        public bool IsOkEmp3 { get { return isOkEmp3(); } }
        public object PrdImagen { get { return getImagen(); } }
        //
        public object Ficha { get { return _ficha; } }
        //
        public data(object it, decimal factorCambio, decimal porctBonoDivisa, bool habilitarBonoDivisa)
        {
            _ficha = (OOB.Producto.Lista.Ficha)it;
            _factorCambio = factorCambio;
            _porctBonoDivisa = porctBonoDivisa;
            _habilitarBonoDivisa = habilitarBonoDivisa;
            //
            CodigoPrd = _ficha.Codigo;
            NombrePrd = _ficha.Nombre;
            ExTotalPrd = _ficha.IsPesado ? _ficha.ExDisponible.ToString("n3") : _ficha.ExDisponible.ToString("n0");
            //
            _p1 = 0m;
            _p2 = 0m;
            _p3 = 0m;
            _p1Divisa=0m;
            _p2Divisa = 0m;
            _p3Divisa = 0m;
            _p1 = full(_ficha.pnetoEmp_1);
            _p2 = full(_ficha.pnetoEmp_2);
            _p3 = full(_ficha.pnetoEmp_3);
            _p1Divisa = _p1 / factorCambio;
            _p2Divisa = _p2 / factorCambio;
            _p3Divisa = _p3 / factorCambio;
            //
            _exEmpCompra = 0m;
            _exEmpInv = 0m;
            _exEmpUnd = 0m;
            _totEx = _ficha.ExDisponible;
            _dscEmpCompra = "";
            _dscEmpInv = "";
            _dscEmpUnd = "";
            if (_ficha.contEmpCompra > 0)
            {
                _exEmpCompra = (int)(_totEx / _ficha.contEmpCompra);
                _totEx -= (_exEmpCompra * _ficha.contEmpCompra);
                _dscEmpCompra += _ficha.descEmpCompra.Trim() + "/(" + _ficha.contEmpCompra.ToString().Trim() + ")";
            }
            if (_ficha.contEmpInv > 0)
            {
                _exEmpInv = (int)(_totEx / _ficha.contEmpInv);
                _totEx -= (_exEmpInv * _ficha.contEmpInv);
                _dscEmpInv += _ficha.descEmpInv.Trim() + "/(" + _ficha.contEmpInv.ToString().Trim() + ")";
            }
            _exEmpUnd = (int)(_totEx);
            _dscEmpUnd += "Unidad/(1)";
        }
        //
        private decimal full(decimal neto)
        {
            var rt = neto;
            if (_ficha.TasaIva > 0)
            {
                rt = rt + (neto * _ficha.TasaIva / 100);
            }
            return rt;
        }
        private string precioBono(decimal montoLocal, decimal montoDivisa)
        {
            var rt = "";
            if (_habilitarBonoDivisa)
            {
                var _factor = ((_porctBonoDivisa / 100) + 1);
                if (_factor > 0m)
                {
                    rt += (montoLocal / _factor).ToString("n2") + "/ ( $ ";
                    rt += (montoDivisa / _factor).ToString("n2") + " )";
                }
            }
            return rt;
        }
        private string tituloPrecioBono()
        {
            var rt = "";
            if (_habilitarBonoDivisa)
            {
                rt = "Bono " + _porctBonoDivisa.ToString("n2") + "%";
            }
            return rt;
        }
        private bool isOkEmp1()
        {
            if (_ficha.EsAdmDivisa)
                return _p1Divisa > 0m;
            else
                return _p1 > 0m;
        }
        private bool isOkEmp2()
        {
            if (_ficha.EsAdmDivisa)
                return _p2Divisa > 0m;
            else
                return _p2 > 0m;
        }
        private bool isOkEmp3()
        {
            if (_ficha.EsAdmDivisa)
                return _p3Divisa > 0m;
            else
                return _p3 > 0m;
        }
        public object getImagen()
        {
            var img = _ficha.imagen;
            if (img.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(img))
                {
                    return Image.FromStream(ms);
                }
            }
            else { return null; }
        }
    }
}