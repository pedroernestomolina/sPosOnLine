using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Producto.Lista
{

    public class Gestion
    {

        private OOB.Producto.Lista.Ficha _itemSeleccionado;
        private bool _itemSeleccionadoIsOk; 
        private BindingSource _bs;
        private List<data> _lData;
        private bool _isCantidadVisible;
        private bool _isPrecioVisible;
        private decimal _tasaCambioActual;


        public BindingSource Source { get { return _bs; } }
        public bool ItemSeleccionIsOk { get { return _itemSeleccionadoIsOk; } }
        public OOB.Producto.Lista.Ficha ItemSeleccionado { get { return _itemSeleccionado; } }
        public bool IsCantidadVisible { get { return _isCantidadVisible; } }
        public bool IsPrecioVisible { get { return _isPrecioVisible; } }


        public Gestion()
        {
            _isCantidadVisible = true;
            _isPrecioVisible = true;
            _itemSeleccionado = null;
            _itemSeleccionadoIsOk = false;
            _lData = new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _lData;
            _tasaCambioActual = 0m;
        }


        public void Subir() 
        {
            _bs.Position -= 1;
        }

        public void Bajar()
        {
            _bs.Position += 1;
        }

        public void Seleccionar() 
        {
            if (_bs != null)
            {
                if (_bs.Current != null)
                {
                    _itemSeleccionado = ((data)_bs.Current).Item;
                    _itemSeleccionadoIsOk = true;
                    frm.Cerrar();
                }
            }
        }

        public void Inicializa()
        {
            _itemSeleccionadoIsOk = false;
            _itemSeleccionado = null;
        }

        internal void setData(List<OOB.Producto.Lista.Ficha> lst, decimal tasaCambio)
        {
            _lData.Clear();
            foreach (var it in lst.OrderBy(o=>o.Nombre).ToList())
            {
                _lData.Add(new data(it, tasaCambio));
            }
            _bs.Position = 0;
            _bs.CurrencyManager.Refresh();
        }


        ListaFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new ListaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private decimal _porctBonoDivisa;
        private bool _habilitarBonoDivisa; 
        private bool CargarData()
        {
            var rt = true;

            _porctBonoDivisa = 0m;
            var r01 = Sistema.MyData.Configuracion_HabilitarDescuentoUnicamenteConPagoEnDivsa();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _habilitarBonoDivisa = r01.Entidad;
            var r02 = Sistema.MyData.Configuracion_ValorMaximoPorcentajeDescuento();
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            _porctBonoDivisa = r02.Entidad;

            return rt;
        }

        public void setCantidadVisible(bool valor) 
        {
            _isCantidadVisible = valor;
        }

        public void setPrecioVisible(bool valor)
        {
            _isPrecioVisible = valor;
        }


        public string GetEmp_1 
        {
            get 
            { 
                var rt="";
                if (_bs.Current != null) 
                {
                    rt = ((data)_bs.Current).Empaque_1;
                }
                return rt;
            }
        }
        public string GetPrecio_1
        {
            get
            {
                var rt = "";
                if (_bs.Current != null)
                {
                    rt = ((data)_bs.Current).Precio_1;
                }
                return rt;
            }
        }
        public string GetEmp_2
        {
            get
            {
                var rt = "";
                if (_bs.Current != null)
                {
                    rt = ((data)_bs.Current).Empaque_2;
                }
                return rt;
            }
        }
        public string GetPrecio_2 
        {
            get
            {
                var rt = "";
                if (_bs.Current != null)
                {
                    rt = ((data)_bs.Current).Precio_2;
                }
                return rt;
            }
        }
        public string GetEmp_3         
        {            
            get
            {
                var rt = "";
                if (_bs.Current != null)
                {
                    rt = ((data)_bs.Current).Empaque_3;
                }
                return rt;
            }
        }
        public string GetPrecio_3
        {
            get
            {
                var rt = "";
                if (_bs.Current != null)
                {
                    rt = ((data)_bs.Current).Precio_3;
                }
                return rt;
            }
        }

        public string GetPrecio_1_Bono 
        {
            get 
            {
                var rt = "";
                if ((data)_bs.Current != null)
                {
                    var _p = ((data)_bs.Current).P1;
                    var _pDivisa = Math.Round(((data)_bs.Current).P1Divisa, 2, MidpointRounding.AwayFromZero);
                    rt=PrecioBono(_p, _pDivisa);
                }
                return rt;
            }
        }
        public string GetPrecio_2_Bono 
        { 
            get
            {
                var rt = "";
                if ((data)_bs.Current != null)
                {
                    var _p = ((data)_bs.Current).P2;
                    var _pDivisa = Math.Round(((data)_bs.Current).P2Divisa, 2, MidpointRounding.AwayFromZero);
                    rt=PrecioBono(_p, _pDivisa);
                }
                return rt;
            } 
        }
        public string GetPrecio_3_Bono
        {
            get
            {
                var rt = "";
                if ((data)_bs.Current != null)
                {
                    var _p = ((data)_bs.Current).P3;
                    var _pDivisa = Math.Round(((data)_bs.Current).P3Divisa, 2, MidpointRounding.AwayFromZero);
                    rt = PrecioBono(_p, _pDivisa);
                }
                return rt;
            }
        }
        public string GetTituloPrecioBono 
        {
            get 
            {
                var rt = "";
                if (_habilitarBonoDivisa)
                {
                    rt = "Bono " + _porctBonoDivisa.ToString("n2") + "%";
                }
                return rt; 
            }
        }


        private string PrecioBono(decimal montoLocal, decimal montoDivisa) 
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

        public bool GetEmp_1_IsOk 
        {
            get
            {
                if (_bs.Current != null)
                {
                    var rt= (data)_bs.Current;
                    return rt.Emp1_IsOK;
                }
                return false;
            }
        }
        public bool GetEmp_2_IsOk
        {
            get
            {
                if (_bs.Current != null)
                {
                    var rt = (data)_bs.Current;
                    return rt.Emp2_IsOK;
                }
                return false;
            }
        }
        public bool GetEmp_3_IsOk
        {
            get
            {
                if (_bs.Current != null)
                {
                    var rt = (data)_bs.Current;
                    return rt.Emp3_IsOK;
                }
                return false;
            }
        }

    }

}