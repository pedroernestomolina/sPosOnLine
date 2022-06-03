using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Helpers.Opcion
{

    public class Gestion: IOpcion
    {

        private List<ficha> _lst;
        private BindingSource _bs;
        private ficha _item;


        public string GetId
        {
            get 
            {
                var rt = "";
                if (_item != null) { rt = _item.id; }
                return rt;
            }
        }
        public BindingSource Source { get { return _bs; } }
        public ficha Item { get { return _item; } }
        public bool ItemsCargadosIsOk { get { return _lst.Count > 0; } }


        public Gestion()
        {
            _lst = new List<ficha>();
            _bs = new BindingSource();
            _item = null;
        }


        public void Inicializa()
        {
            limpiar();
        }


        public void setData(List<ficha> dat)
        {
            _lst.Clear();
            if (dat != null) 
            {
                foreach (var rg in dat)
                {
                    _lst.Add(rg);
                }
            }
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }

        public void setFicha(string id)
        {
            _item = _lst.FirstOrDefault(f => f.id == id);
        }

        public void Limpiar()
        {
            limpiar();
        }

        private void limpiar() 
        {
            _item = null;
        }

    }

}