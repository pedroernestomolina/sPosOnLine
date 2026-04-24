using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosOnLine.Src.PedidoWeb.MostarPedido.Vm
{
    public class MostrarPedidoImpl: IMostarPedido
    {
        private int _idPedidoMostrar;
        private int _pedidoNro;
        private string _entidadPed;
        private BindingSource _bsDet;
        private PedidoWeb.Domain.UseCase.IUseCase _uc;
        //
        public Domain.Modelo MiModelo { get; set; }
        public object Get_DetallesSource { get { return _bsDet; } }
        public int Get_PedidoNro { get { return _pedidoNro; } }
        public string Get_EntidadPedido { get { return _entidadPed; } }
        //
        public MostrarPedidoImpl()
        {
            _idPedidoMostrar = -1;
            _bsDet = new BindingSource();
            _uc = new PedidoWeb.Domain.UseCase.UseCaseImpl();
            _pedidoNro = 0;
            _entidadPed = "";
            MiModelo = new Domain.Modelo();
        }
        //
        public void setIdPedidoMostrar(int id)
        {
            _idPedidoMostrar = id;
        }
        //
        public void Invoke()
        {
            Inicializa();
            Inicia();
            Limpiar();
        }
        //
        private void Inicializa()
        {
            _pedidoNro = 0;
            _entidadPed="";
            MiModelo.Pedido = null;
        }
        Vista.Frm frm;
        private void Inicia()
        {
            if (CargarData())
            {
                _bsDet.DataSource = MiModelo.Pedido.Detalles;
                if (frm==null)
                {
                    frm= new Vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        private void Limpiar()
        {
            _idPedidoMostrar = -1;
            MiModelo.Limpiar();
        }
        //
        private bool CargarData()
        {
            try
            {
                if (_idPedidoMostrar == -1)
                {
                    throw new Exception("[ ID ] PEDIDO, NO CARGADO");
                }
                MiModelo.Pedido = _uc.CargarPedidoWebById(_idPedidoMostrar);
                _pedidoNro = MiModelo.Pedido.PedidoNro;
                _entidadPed = MiModelo.Pedido.CiRifEntidad.Trim() + Environment.NewLine +
                    MiModelo.Pedido.NombreEntidad.Trim() + Environment.NewLine +
                    MiModelo.Pedido.DirEntidad.Trim() + Environment.NewLine +
                    MiModelo.Pedido.TelefonoEntidad.Trim() + Environment.NewLine +
                    "Tasa Cambio Web: " + MiModelo.Pedido.TasaCambio.ToString("n4");
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
    }
}