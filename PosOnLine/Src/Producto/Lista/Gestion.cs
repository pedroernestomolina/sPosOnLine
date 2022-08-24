﻿using System;
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

    }

}