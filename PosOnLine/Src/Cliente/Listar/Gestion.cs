using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Cliente.Listar
{
    
    public class Gestion
    {


        private List<data> _lista;
        private List<OOB.Cliente.Lista.Ficha> _clientes;
        private BindingSource _bs;
        private OOB.Cliente.Lista.Ficha _itemSeleccionado;


        public OOB.Cliente.Lista.Ficha ItemSeleccionado { get { return _itemSeleccionado; } }
        public BindingSource SourceCliente { get { return _bs; } }
        public bool ItemSeleccionadoIsOk { get { return _itemSeleccionado != null; } }


        public Gestion()
        {
            _lista = new List<data>();
            _clientes = new List<OOB.Cliente.Lista.Ficha>();
            _bs = new BindingSource();
            _bs.DataSource = _lista;
        }


        ListaFrm frm;
        public void Inicia()
        {
            if (!ItemSeleccionadoIsOk)
            {
                if (CargarData())
                {
                    if (frm == null)
                    {
                        frm = new ListaFrm();
                        frm.setControlador(this);
                    }
                    frm.ShowDialog();
                }
            }
        }

        private bool CargarData()
        {
            var rt = true;

            _lista.Clear();
            foreach (var it in _clientes.OrderBy(o => o.nombre).ToList())
            {
                _lista.Add(new data(it));
            }
            _bs.Position = 0;
            _bs.CurrencyManager.Refresh();

            return rt;
        }

        public void setLista(List<OOB.Cliente.Lista.Ficha> list)
        {
            _clientes = list;
        }

        public void Inicializar()
        {
            _itemSeleccionado = null;
        }

        public void SubirItem()
        {
            _bs.Position -= 1;
        }

        public void BajarItem()
        {
            _bs.Position += 1;
        }

        public void SeleccionarItem()
        {
            if (_bs.Current != null) 
            {
                _itemSeleccionado = ((data)_bs.Current).Ficha;
            }
        }

    }

}