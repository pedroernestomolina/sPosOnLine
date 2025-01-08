using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pedido.Lista
{
    public class HndListaPedidos: IListaPedidos
    {
        private bool _abrirTarjetaIsOk;
        private Idata _abrirTarjeta;
        private List<Idata> _list;
        private BindingList<Idata> _bl;
        private BindingSource _bs;
        //
        public BindingSource DataSource { get { return _bs; } }
        //
        public HndListaPedidos() 
        {
            _list = new List<Idata>();
            _bl = new BindingList<Idata>(_list);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }
        public void Inicializa()
        {
            _abrirTarjetaIsOk = false;
            _abrirTarjeta = null;
            _list.Clear();
        }
        Frm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null) 
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        private bool CargarData()
        {
            try 
            {
                return true;
            }
            catch(Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        public void setData(object data)
        {
            _bl.Clear();
            var _list = (List<OOB.Pedido.ListaResumen.Resumen>)data;
            foreach (var it in _list.OrderBy(o => o.tarjetaNum).ToList())
            {
                _bl.Add(new data(it));
            }
        }
        public bool AbrirTarjetaIsOk { get { return _abrirTarjetaIsOk; } }
        public object TarjetaPedidoAbrir { get { return _abrirTarjeta; } }
        public void AbrirTarjetaPedido()
        {
            _abrirTarjetaIsOk = false;
            _abrirTarjeta = null;
            if (_bs.Current != null)
            {
                var it = (data)_bs.Current;
                var msg = MessageBox.Show("Abrir Tarjeta/Pedido ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == System.Windows.Forms.DialogResult.Yes)
                {
                    _abrirTarjetaIsOk = true;
                    _abrirTarjeta = it;
                }
            }
        }
    }
}