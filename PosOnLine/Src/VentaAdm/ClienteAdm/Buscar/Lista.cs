using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.VentaAdm.ClienteAdm.Buscar
{
    
    public class Lista
    {

        private List<data> _lst;
        private BindingList<data> _bl;
        private BindingSource _bs;


        public int GetCntItem { get { return _bs.Count; } }
        public BindingSource GetSource { get { return _bs; } }
        public data ItemActual { get { return (data)_bs.Current; } }


        public Lista()
        {
            _lst = new List<data>();
            _bl = new BindingList<data>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa()
        {
            _lst.Clear();
            _bs.CurrencyManager.Refresh();
        }


        public void setLista(List<data> list)
        {
            _lst.Clear();
            foreach (var it in list.OrderBy(o => o.NombreRazonSocial).ToList())
            {
                _lst.Add(it);
            }
            _bs.CurrencyManager.Refresh();
        }

        //public void AgregarFicha(OOB.Maestro.Cliente.Entidad.Ficha ficha)
        //{
        //    _lst.Add(new data(ficha));
        //    _bs.CurrencyManager.Refresh();
        //}

        //public void ActualizarFicha(OOB.Maestro.Cliente.Entidad.Ficha ficha)
        //{
        //    var it = _bl.FirstOrDefault(f => f.Id == ficha.id);
        //    if (it != null)
        //    {
        //        it.SetActualizarFicha(ficha);
        //        _bs.CurrencyManager.Refresh();
        //    }
        //}

        public bool CargarData()
        {
            return true;
        }

    }

}