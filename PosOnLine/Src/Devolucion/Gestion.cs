using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Devolucion
{
    
    public class Gestion
    {

        public event EventHandler<int> EliminarItemHnd;
        public event EventHandler<int> DevolverItemHnd;
        public event EventHandler<dataDev> CntDevItemHnd;


        private BindingList<Item.data> _bl;
        private BindingSource _bs;
        private Multiplicar.Gestion _gMult;


        public decimal MontoSubTotal { get { return _bl.Sum(f => f.MontoTotal()); } }
        public BindingSource DataSource { get { return _bs; } }


        public Gestion()
        {
            _bl = new BindingList<Item.data>();
            _bs = new BindingSource();
            _bs.DataSource = _bl;
            _gMult = new Multiplicar.Gestion();
        }


        public void Inicializa()
        {
            _gMult.Inicializa();
        }

        DevolucionFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new DevolucionFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;
            return rt;
        }

        public void SubirItem()
        {
            _bs.Position -= 1;
        }

        public void BajarItem()
        {
            _bs.Position += 1;
        }

        public void setData(System.ComponentModel.BindingList<Item.data> bl)
        {
            _bl.Clear();
            foreach (var it in bl) 
            {
                _bl.Add(it);
            }
            _bs.CurrencyManager.Refresh();
        }

        public void EliminarItem()
        {
            if (_bs.Current != null)
            {
                var it=(Item.data) _bs.Current;
                EventHandler<int> hnd = EliminarItemHnd;
                if (hnd != null) 
                {
                    hnd(this, it.Ficha.id);
                }
            }
        }

        public void DevolerItem()
        {
            if (_bs.Current != null)
            {
                var it = (Item.data)_bs.Current;
                EventHandler<int> hnd = DevolverItemHnd;
                if (hnd != null)
                {
                    hnd(this, it.Ficha.id);
                }
            }
        }

        public void Eliminar(int e)
        {
            var it = _bl.FirstOrDefault(f=>f.Id==e);
            if (it != null)
            {
                _bl.Remove(it);
            }
            _bs.CurrencyManager.Refresh();
        }

        public void DevolverItem(int e)
        {
            var it = _bl.FirstOrDefault(f => f.Id == e);
            if (it != null)
            {
                if (it.Cantidad == 0)
                {
                    _bl.Remove(it);
                }
                _bs.CurrencyManager.Refresh();
            }
        }

        public void CantidadDevolver()
        {
            if (_bs.Current != null)
            {
                var it = (Item.data)_bs.Current;
                _gMult.Inicializa();
                _gMult.Inicia();
                if (_gMult.MultiplicarIsOk)
                {
                    if (_gMult.Cantidad >= it.Cantidad)
                    {
                        Helpers.Msg.Alerta("CANTIDAD A DEVOLVER SOBRE PASA LA CANTIDAD INGRESADA");
                        return;
                    }
                }
                else 
                {
                    return;
                }

                var dtDev = new dataDev()
                {
                    idItem = it.Ficha.id,
                    cnt = _gMult.Cantidad,
                };
                EventHandler<dataDev> hnd = CntDevItemHnd;
                if (hnd != null)
                {
                    hnd(this, dtDev);
                }
            }
        }

    }

}