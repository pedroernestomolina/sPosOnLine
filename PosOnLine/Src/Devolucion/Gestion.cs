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


        private BindingList<Item.data> _bl;
        private BindingSource _bs;


        public decimal MontoSubTotal { get { return _bl.Sum(f => f.MontoTotal()); } }
        public BindingSource DataSource { get { return _bs; } }


        public Gestion()
        {
            _bl = new BindingList<Item.data>();
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa()
        {
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

    }

}