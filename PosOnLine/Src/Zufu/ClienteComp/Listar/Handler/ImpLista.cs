using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Zufu.ClienteComp.Listar.Handler
{
    public class ImpLista: Vista.IListaCliente
    {
        private List<Vista.IdataList> _lst;
        private BindingSource _bs;
        private object _itemSeleccionado;

        public BindingSource GetSource { get { return _bs; } }
        public object GetItemActual { get { return _bs.Current; } }
        public int GetCantItem { get { return _bs.Count; } }
        public object ItemSeleccionado { get { return _itemSeleccionado; } }
        public bool ItemSeleccionadoIsOk { get { return _itemSeleccionado != null; } }

        public ImpLista()
        {
            _itemSeleccionado = null;
            _lst = new List<Vista.IdataList>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }
        public void Inicializa()
        {
            _itemSeleccionado = null;
            _lst.Clear();
            _bs.CurrencyManager.Refresh();
        }
        public void setLista(List<object> lst)
        {
            _lst.Clear();
            foreach (OOB.Cliente.Lista.Ficha it in lst) 
            {
                _lst.Add(new dataList(it));
            }
            _bs.CurrencyManager.Refresh();
        }
        public void Met_SubirItem()
        {
            _bs.Position -= 1;
        }
        public void Met_BajarItem()
        {
            _bs.Position += 1;
        }
        public void Met_SeleccionarItem()
        {
            if (GetItemActual != null) 
            {
                _itemSeleccionado = _bs.Current;
            }
        }
    }
}