using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Lista.ZUFU
{
    public class data : Idata
    {
        private string _descBonoDivisa;
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
        private decimal _p1Bono;
        private decimal _p2Bono;
        private decimal _p3Bono;
        private decimal _p1DivisaBono;
        private decimal _p2DivisaBono;
        private decimal _p3DivisaBono;
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
        public string Precio1ConBono { get { return precioBono(_p1Bono, _p1DivisaBono); } }
        public string Precio2ConBono { get { return precioBono(_p2Bono, _p2DivisaBono); } }
        public string Precio3ConBono { get { return precioBono(_p3Bono, _p3DivisaBono); } }
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
        public data(object it, decimal factorCambio, decimal porctBonoDivisa, bool habilitarBonoDivisa, string descBonoDivisa)
        {
            _ficha = (OOB.Producto.Lista.Ficha)it;
            _factorCambio = factorCambio;
            _porctBonoDivisa = porctBonoDivisa;
            _habilitarBonoDivisa = habilitarBonoDivisa;
            _descBonoDivisa = descBonoDivisa;
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
            _p1Bono = 0m;
            _p2Bono = 0m;
            _p3Bono = 0m;
            _p1DivisaBono = 0m;
            _p2DivisaBono = 0m;
            _p3DivisaBono = 0m;
            if (_ficha.EsAdmDivisa)
            {
                _p1 = full(_ficha.pnetoEmp_1);
                _p2 = full(_ficha.pnetoEmp_2);
                _p3 = full(_ficha.pnetoEmp_3);
                _p1Divisa = _p1 / factorCambio;
                _p2Divisa = _p2 / factorCambio;
                _p3Divisa = _p3 / factorCambio;
                //
                _p1Bono = full(_ficha.pnetoEmp_1);
                _p2Bono = full(_ficha.pnetoEmp_2);
                _p3Bono = full(_ficha.pnetoEmp_3);
                _p1DivisaBono = _p1 / factorCambio;
                _p2DivisaBono = _p2 / factorCambio;
                _p3DivisaBono = _p3 / factorCambio;
            }
            else 
            {
                _p1 = _ficha.pfullDivEmp_1 * factorCambio;
                _p2 = _ficha.pfullDivEmp_2 * factorCambio;
                _p3 = _ficha.pfullDivEmp_3 * factorCambio;
                _p1Divisa = _ficha.pfullDivEmp_1;
                _p2Divisa = _ficha.pfullDivEmp_2;
                _p3Divisa = _ficha.pfullDivEmp_3;
                //
                _p1Bono = _ficha.pfullDivEmp_1u * factorCambio;
                _p2Bono = _ficha.pfullDivEmp_2u * factorCambio;
                _p3Bono = _ficha.pfullDivEmp_3u * factorCambio;
                _p1DivisaBono = _ficha.pfullDivEmp_1u;
                _p2DivisaBono = _ficha.pfullDivEmp_2u;
                _p3DivisaBono = _ficha.pfullDivEmp_3u;
            }
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
            if (_habilitarBonoDivisa)// && _ficha.EsAdmDivisa)
            {
                var _factor = ((_porctBonoDivisa / 100) + 1);
                if (_factor > 0m)
                {
                    //rt += (montoLocal / _factor).ToString("n2") + "/ ( $ ";
                    //rt += (montoDivisa / _factor).ToString("n2") + " )";
                    var _montoDivisa = montoDivisa / _factor;
                    _montoDivisa = Math.Round(_montoDivisa, 2, MidpointRounding.AwayFromZero);
                    var _montoLocal = _montoDivisa * _factorCambio;
                    _montoLocal = Math.Round(_montoLocal, 2, MidpointRounding.AwayFromZero);
                    rt += (_montoLocal).ToString("n2") + "/ ( $ ";
                    rt += (_montoDivisa).ToString("n2") + " )";
                }
            }
            //
            return rt;
        }
        private string tituloPrecioBono()
        {
            var rt = "";
            if (_habilitarBonoDivisa)// && _ficha.EsAdmDivisa)
            {
                //rt = "Bono " + _porctBonoDivisa.ToString("n2") + "%";
                rt = "Bono " + _descBonoDivisa;
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