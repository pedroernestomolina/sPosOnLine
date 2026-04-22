using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosOnLine.Src.PedidoWeb.ListaDo.Vm
{
    public class ListaDoImpl: IListaDo
    {
        private BindingList<Domain.Models.PedidoWeb> _bl;
        private BindingSource _bs;
        private Domain.UseCase.IUseCase _uc;
        //
        public Domain.Models.Modelo MiModelo { get; set; }
        public object Get_SourceData { get { return _bs; } }
        public int Get_ItemsEncontrados { get { return _bs.Count; } }
        public Domain.Models.PedidoWeb ItemActual { get { return (Domain.Models.PedidoWeb)_bs.Current; } }
        //
        public ListaDoImpl()
        {
            MiModelo = new Domain.Models.Modelo();
            _bl = new BindingList<Domain.Models.PedidoWeb>();
            _bs = new BindingSource();
            _bs.DataSource = _bl;
            _uc = new Domain.UseCase.UseCaseImpl();
        }
        public void Invoke()
        {
            Inicializa();
            Inicia();
        }
        //
        private void Inicializa() 
        {
        }
        Vista.Frm frm;
        private void Inicia()
        {
            if (CargarData()) 
            {
                
                if (frm == null)
                {
                    frm = new Vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        private MostarPedido.Vm.IMostarPedido _mostrarPedido;
        public void VisualizarItem()
        {
            if (ItemActual != null)
            {
                if (_mostrarPedido == null)
                {
                    _mostrarPedido = new MostarPedido.Vm.MostrarPedidoImpl();
                }
                _mostrarPedido.setIdPedidoMostrar(ItemActual.Id);
                _mostrarPedido.Invoke();
            }
        }
        public void EnviarAlCarritoVenta()
        {
            if (ItemActual != null)
            {
            }
        }
        //
        private bool CargarData()
        {
            try
            {
                var rt = _uc.ObtenerListaDePedidosWebActivosSinProcesar();
                MiModelo.ListaPedidos.Clear();
                MiModelo.ListaPedidos = rt.OrderBy(o => o.PedidoNro).ToList();
                CargarListaItemBinding();
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void CargarListaItemBinding()
        {
            _bl.Clear();
            foreach (var it in MiModelo.ListaPedidos)
            {
                _bl.Add(it);
            }
        }
    }
}
