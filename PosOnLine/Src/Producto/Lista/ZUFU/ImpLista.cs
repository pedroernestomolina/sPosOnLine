using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Producto.Lista.ZUFU
{
    public class ImpLista : ILista
    {
        private List<Idata> _list;
        private BindingSource _bs;
        private object _itemSeleccionado;
        //
        public object ItemSeleccionado { get { return _itemSeleccionado; } }
        public bool ItemSeleccionadoIsOk { get { return _itemSeleccionado != null; } }
        public object GetSource { get { return _bs; } }
        public object ItemActual { get { return _bs.Current; } }
        public string GetDetalleProducto { get { return getDetalleProducto(); } }
        //PRECIOS
        public string GetEmp1 { get { return getEmp1(); } }
        public string GetEmp2 { get { return getEmp2(); } }
        public string GetEmp3 { get { return getEmp3(); } }
        public string GetPrecio1 { get { return getPrecio1(); } }
        public string GetPrecio2 { get { return getPrecio2(); } }
        public string GetPrecio3 { get { return getPrecio3(); } }
        public string GetPrecio1ConBono { get { return getPrecio1ConBono(); } }
        public string GetPrecio2ConBono { get { return getPrecio2ConBono(); } }
        public string GetPrecio3ConBono { get { return getPrecio3ConBono(); } }
        public string GetTituloPrecioBono { get { return getTituloPrecioBono(); } }
        //INVENTARIO
        public decimal GetInvEmpCompra { get { return getInvEmpCompra(); } }
        public decimal GetInvEmpInv { get { return getInvEmpInv(); } }
        public decimal GetInvEmpUnd { get { return getInvEmpUnd(); } }
        public string GetDescEmpCompra { get { return getDescEmpCompra(); } }
        public string GetDescEmpInv { get { return getDescEmpInv(); } }
        public string GetDescEmpUnd { get { return getDescEmpUnd(); } }
        //
        public bool GetIsOkEmp1 { get { return getIsOkEmp1(); } }
        public bool GetIsOkEmp2 { get { return getIsOkEmp2(); } }
        public bool GetIsOkEmp3 { get { return getIsOkEmp3(); } }
        public object GetPrdImagen { get { return getPrdImagen(); } }
        //
        public ImpLista()
        {
            _itemSeleccionado = null;
            _list = new List<Idata>();
            _bs = new BindingSource();
            _bs.DataSource = _list;
            _bs.Position = 0;
            _bs.CurrencyManager.Refresh();
        }
        public void Inicializa()
        {
            _itemSeleccionado = null;
            _list.Clear();
            _bs.Position = 0;
            _bs.CurrencyManager.Refresh();
        }
        public void FlechaArriba()
        {
            if (ItemActual != null)
            {
                _bs.Position -= 1;
            }
            _bs.CurrencyManager.Refresh();
        }
        public void FlechaAbajo()
        {
            if (ItemActual != null)
            {
                _bs.Position += 1;
            }
            _bs.CurrencyManager.Refresh();
        }
        public void SeleccionarItem()
        {
            _itemSeleccionado = null;
            if (ItemActual != null)
            {
                _itemSeleccionado = ((data)ItemActual).Ficha;
            }
        }
        public void setData(IEnumerable<object> lst, decimal factorCambio, decimal porctBonoDivisa, bool habilitarBonoDivisa)
        {
            _list.Clear();
            foreach (var it in ((List<OOB.Producto.Lista.Ficha>)lst).OrderBy(o => o.Nombre).ToList())
            {
                _list.Add(new data(it, factorCambio, porctBonoDivisa, habilitarBonoDivisa));
            }
            _bs.Position = 0;
            _bs.CurrencyManager.Refresh();
        }
        //
        private string getDetalleProducto()
        {
            var rt = "";
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).NombrePrd;
            }
            return rt;
        }
        private string getEmp1()
        {
            var rt = "";
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).Empaque1;
            }
            return rt;
        }
        public string getEmp2()
        {
            var rt = "";
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).Empaque2;
            }
            return rt;
        }
        public string getEmp3()
        {
            var rt = "";
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).Empaque3;
            }
            return rt;
        }
        private string getPrecio1()
        {
            var rt = "";
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).Precio1;
            }
            return rt;
        }
        private string getPrecio2()
        {
            var rt = "";
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).Precio2;
            }
            return rt;
        }
        private string getPrecio3()
        {
            var rt = "";
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).Precio3;
            }
            return rt;
        }
        private string getPrecio1ConBono()
        {
            var rt = "";
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).Precio1ConBono;
            }
            return rt;
        }
        private string getPrecio2ConBono()
        {
            var rt = "";
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).Precio2ConBono;
            }
            return rt;
        }
        private string getPrecio3ConBono()
        {
            var rt = "";
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).Precio3ConBono;
            }
            return rt;
        }
        private string getTituloPrecioBono()
        {
            var rt = "";
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).TituloPrecioBono;
            }
            return rt;
        }
        private decimal getInvEmpCompra()
        {
            var rt = 0m;
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).ExInvEmpCompra;
            }
            return rt;
        }
        private decimal getInvEmpInv()
        {
            var rt = 0m;
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).ExInvEmpInv;
            }
            return rt;
        }
        private decimal getInvEmpUnd()
        {
            var rt = 0m;
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).ExInvEmpUnd;
            }
            return rt;
        }
        private string getDescEmpCompra()
        {
            var rt = "";
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).DescEmpCompra;
            }
            return rt;
        }
        private string getDescEmpInv()
        {
            var rt = "";
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).DescEmpInv;
            }
            return rt;
        }
        private string getDescEmpUnd()
        {
            var rt = "";
            if (ItemActual != null)
            {
                rt = ((data)ItemActual).DescEmpUnd;
            }
            return rt;
        }
        private bool getIsOkEmp1()
        {
            var rt = false;
            if (ItemActual != null)
            {
                return ((data)ItemActual).IsOkEmp1;
            }
            return rt;
        }
        private bool getIsOkEmp2()
        {
            var rt = false;
            if (ItemActual != null)
            {
                return ((data)ItemActual).IsOkEmp2;
            }
            return rt;
        }
        private bool getIsOkEmp3()
        {
            var rt = false;
            if (ItemActual != null)
            {
                return ((data)ItemActual).IsOkEmp3;
            }
            return rt;
        }
        private object getPrdImagen()
        {
            if (ItemActual != null)
            {
                return ((data)ItemActual).PrdImagen;
            }
            return null;
        }
    }
}