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

        public void setData(List<OOB.Producto.Lista.Ficha> lst)
        {
            _lData.Clear();
            foreach (var it in lst.OrderBy(o=>o.Nombre).ToList())
            {
                _lData.Add(new data(it));
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

        private bool CargarData()
        {
            return true;
        }

        public void setCantidadVisible(bool valor) 
        {
            _isCantidadVisible = valor;
        }

        public void setPrecioVisible(bool valor)
        {
            _isPrecioVisible = valor;
        }

    }

}