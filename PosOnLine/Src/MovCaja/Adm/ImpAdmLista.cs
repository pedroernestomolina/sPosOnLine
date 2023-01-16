using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.MovCaja.Adm
{
    public class ImpAdmLista:IAdmLista
    {
        private List<data> _lst;
        private BindingList<data> _bl;
        private BindingSource _bs;

        public BindingSource GetSource { get { return _bs; } }
        public object GetItemActual { get { return _bs.Current; } }
        public int GetCantItem { get { return _bs.Count; } }

        public ImpAdmLista()
        {
            _lst = new List<data>();
            _bl = new BindingList<data>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }

        public void Inicializa()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }
        public void setLista(List<object> lst)
        {
            _bl.Clear();
            foreach (var rg in lst) 
            {
                _bl.Add((data)rg);
            }
            _bs.CurrencyManager.Refresh();
        }
        public void setAnularMov(int id)
        {
            var item = _bl.FirstOrDefault(f => f.IdMov == id);
            if (item != null) 
            {
                item.setEstatusAnulado();
            }
        }
        public void Agregar(data ficha)
        {
            _bl.Insert(0,ficha);
        }

        public void Subir()
        {
            _bs.MovePrevious();
        }
        public void Bajar()
        {
            _bs.MoveNext();
        }


    }
}