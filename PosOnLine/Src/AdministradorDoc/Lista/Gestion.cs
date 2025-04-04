using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.AdministradorDoc.Lista
{
    public class Gestion
    {
        private List<data> _l;
        private BindingList<data> _bl;
        private BindingSource _bs;
        private data _docAplicarNotaCredito;
        //
        public int CntItems { get { return _bs.Count; } }
        public BindingSource Source { get { return _bs; } }
        public object ItemActual { get { return _bs.Current; } }
        //
        public Gestion()
        {
            _l= new List<data>();
            _bl = new BindingList<data>(_l);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }
        public void Inicializa() 
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }
        public void setData(List<OOB.Documento.Lista.Ficha> list)
        {
            _bl.Clear();
            foreach (var it in list.OrderBy(o => o.Serie).ThenByDescending(o => o.FechaEmision.Date).ThenByDescending(o => o.DocNumero).ToList())
            {
                _bl.Add(new data(it));
            }
            _bs.CurrencyManager.Refresh();
        }
        public void BajarItem()
        {
            _bs.Position += 1;
            _bs.CurrencyManager.Refresh();
        }
        public void SubirItem()
        {
            _bs.Position -= 1;
            _bs.CurrencyManager.Refresh();
        }
        public void setAnularDoc()
        {
            if (_bs.Current != null)
            {
                var it = (data)_bs.Current;
                it.setAnularDoc();
            }
            _bs.CurrencyManager.Refresh();
        }
    }
}