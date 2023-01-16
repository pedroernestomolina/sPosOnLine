using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.MovCaja.Agregar
{
    public class dataMedios
    {
        private decimal _factor;
        private List<medio> _medios;
        private BindingList<medio> _bl;
        private BindingSource _bs;

        public BindingSource Source { get { return _bs; } }
        public decimal Monto { get { return _bl.Sum(s => s.Importe); } }
        public List<medio> Medios { get { return _bl.ToList(); } }

        public dataMedios()
        {
            _factor = 0m;
            _medios = new List<medio>();
            _bl = new BindingList<medio>(_medios);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }

        public void Inicializa()
        {
            _bl.Clear();
        }
        public void Agregar(medio ficha)
        {
            ficha.setFactorCambio(_factor);
            _bl.Add(ficha);
        }
        public void setFactorCambio(decimal p)
        {
            _factor = p;
            foreach (var rg in _bl)
            {
                rg.setFactorCambio(p);
            }
            _bs.CurrencyManager.Refresh();
        }
        public void EliminarMedio()
        {
            if (_bs.Current != null) 
            {
                var it = (medio)_bs.Current;
                _bl.Remove(it);
            }
            _bs.CurrencyManager.Refresh();
        }
        public void IsOk()
        {
            if (Monto<=0m)
                throw new Exception("INDIQUE LOS MEDIOS");
            if (_bl.Count <= 0)
                throw new Exception("INDIQUE LOS MEDIOS");
        }
    }
}