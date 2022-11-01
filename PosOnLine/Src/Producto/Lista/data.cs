using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Lista
{

    public class data
    {

        private OOB.Producto.Lista.Ficha _item;
        private decimal tasaCambio;
        private decimal _p1;
        private decimal _p2;
        private decimal _p3;
        private decimal _p1Divisa;
        private decimal _p2Divisa;
        private decimal _p3Divisa; 


        public OOB.Producto.Lista.Ficha Item { get { return _item; } }
        public string Id { get { return _item.Auto; } }
        public string codigo { get { return _item.Codigo; } }
        public string nombre { get { return _item.Nombre; } }
        public decimal precio { get { return _item.PrecioFullDivisa; } }
        public string plu { get { return _item.PLU; } }
        public decimal precioMay { get { return _item.PrecioFullDivisaMay; } }
        public string empaqueMay 
        { 
            get 
            {
                var rt = "";
                if (_item.PrecioFullDivisaMay > 0) 
                {
                    rt="MAY/" + _item.ContenidoMay.ToString(); 
                }
                return rt;
            } 
        }
        public decimal cantidadEx 
        { 
            get 
            { 
                var x= 0.0m;
                if (_item.Contenido > 0) 
                {
                    x = _item.ExDisponible;
                }
                return x;
            } 
        }

        public string Empaque_1 { get { return _item.descEmp_1 + "/ (" + _item.contEmp_1.ToString("n0") + ")"; } }
        public string Empaque_2 { get { return _item.descEmp_2 + "/ (" + _item.contEmp_2.ToString("n0") + ")"; } }
        public string Empaque_3 { get { return _item.descEmp_3 + "/ (" + _item.contEmp_3.ToString("n0") + ")"; } }
        public string Precio_1 { get { return _p1.ToString("n2") + "/ ( $ " + _p1Divisa.ToString("n2") + ")"; } }
        public string Precio_2 { get { return _p2.ToString("n2") + "/ ( $ " + _p2Divisa.ToString("n2") + ")"; } }
        public string Precio_3 { get { return _p3.ToString("n2") + "/ ( $ " + _p3Divisa.ToString("n2") + ")"; } }
        //



        private int _exEmpCompra;
        private int _exEmpInv;
        private int _exEmpUnd;
        private decimal _totEx;
        private string _dscEmpCompra;
        private string _dscEmpInv;
        private string _dscEmpUnd;
        public data()
        {
        }
        public data(OOB.Producto.Lista.Ficha it, decimal tasaCambio)
        {
            _item = it;
            _p1 = full(it.pnetoEmp_1);
            _p2 = full(it.pnetoEmp_2);
            _p3 = full(it.pnetoEmp_3);
            _p1Divisa = _p1 / tasaCambio;
            _p2Divisa = _p2 / tasaCambio;
            _p3Divisa = _p3 / tasaCambio;
            this.tasaCambio = tasaCambio;

            _exEmpCompra = 0;
            _exEmpInv = 0;
            _exEmpUnd = 0;
            _totEx = it.ExDisponible;
            if (it.contEmpCompra > 0)
            {
                _exEmpCompra = (int) (_totEx / it.contEmpCompra);
                _totEx -= (_exEmpCompra * it.contEmpCompra);
                _dscEmpCompra += _item.descEmpCompra.Trim() + "/(" + _item.contEmpCompra.ToString().Trim() + ")";
            }
            if (it.contEmpInv > 0)
            {
                _exEmpInv = (int)(_totEx / it.contEmpInv);
                _totEx -= (_exEmpInv * it.contEmpInv);
                _dscEmpInv += _item.descEmpInv.Trim() + "/(" + _item.contEmpInv.ToString().Trim() + ")";
            }
            _exEmpUnd = (int)(_totEx);
            _dscEmpUnd += "Unidad/(1)";
        }


        private decimal full(decimal p)
        {
            var rt = p;
            if (_item.TasaIva > 0) 
            {
                rt = rt + (p * _item.TasaIva / 100);
            }
            return rt;
        }


        public decimal P1 { get { return _p1; } }
        public decimal P1Divisa { get { return _p1Divisa; } }
        public decimal P2 { get { return _p2; } }
        public decimal P2Divisa { get { return _p2Divisa; } }
        public decimal P3 { get { return _p3; } }
        public decimal P3Divisa { get { return _p3Divisa; } }

        public bool Emp1_IsOK 
        {
            get
            {
                var rt = false;
                if (_item != null)
                {
                    if (_item.EsAdmDivisa)
                        return P1Divisa > 0;
                    else
                        return P1 > 0;
                }
                return rt;
            }
        }
        public bool Emp2_IsOK
        {
            get
            {
                var rt = false;
                if (_item != null)
                {
                    if (_item.EsAdmDivisa)
                        return P2Divisa > 0;
                    else
                        return P2 > 0;
                }
                return rt;
            }
        }
        public bool Emp3_IsOK
        {
            get
            {
                var rt = false;
                if (_item != null)
                {
                    if (_item.EsAdmDivisa)
                        return P3Divisa > 0;
                    else
                        return P3 > 0;
                }
                return rt;
            }
        }
        //
        public int GetInvEmpCompra { get { return _exEmpCompra; } }
        public string GetDescEmpCompra { get { return _dscEmpCompra; } }
        public int GetInvEmpInv { get { return _exEmpInv; } }
        public string GetDescEmpInv { get { return _dscEmpInv; } }
        public int GetInvEmpUnd { get { return _exEmpUnd; } }
        public string GetDescEmpUnd { get { return _dscEmpUnd; } }

    }

}