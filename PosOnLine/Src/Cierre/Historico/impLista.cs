using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Cierre.Historico
{
    public class impLista: ILista
    {
        private List<Idata> _lst;
        private BindingSource _bs;
        //
        public object ItemActual { get { return _bs.Current; } }        
        public object GetSource { get { return _bs; } }
        //
        public impLista()
        {
            _lst = new List<Idata>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }
        public void Inicializa()
        {
            _lst.Clear();
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }
        public void setData(IEnumerable<object> list)
        {
            _lst.Clear();
            _lst = list.Select(s =>
            {
                Idata nr = new data(s);
                return nr;
            }).ToList();
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }
    }
}