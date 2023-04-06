using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Producto.Lista.ModoAdm
{
    public class ImpListar: IListar
    {
        private BindingSource _bs;
        private List<IDataPrd> _lst;


        public BindingSource GetSource { get { return _bs; } }
        public object ItemActual { get { return _bs.Current; } }
        public IDataPrd Prd { get { return _bs.Current == null ? new imp_dataPrd() : (IDataPrd)_bs.Current; } }


        public ImpListar()
        {
            _lst = new List<IDataPrd>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }


        public void setDataListar(List<IDataPrd> lst)
        {
            _lst.Clear();
            _lst = lst;
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }


        public void Inicializa()
        {
            _lst.Clear();
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }
        public void SubirItem()
        {
            _bs.Position -= 1;
        }
        public void BajarItem()
        {
            _bs.Position += 1;
        }
    }
}