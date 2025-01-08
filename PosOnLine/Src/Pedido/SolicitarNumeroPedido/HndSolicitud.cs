using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pedido.SolicitarNumeroPedido
{
    public class HndSolicitud: ISolicitud
    {
        private bool _abandonarIsOk;
        private bool _procesarIsOk;
        private int _numeroPedido;
        private ModoSolicitud _modoSolicitud;
        //
        public HndSolicitud() 
        {
            _numeroPedido = 0;
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _modoSolicitud = ModoSolicitud.SinDefinir;
        }
        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _numeroPedido = 0;
            _modoSolicitud = ModoSolicitud.SinDefinir;
        }
        private Frm frm;
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
            return true;
        }

        public bool AbandonarIsOK { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk= Helpers.Msg.Abandonar();
        }

        public bool ProcesarIsOK { get { return _procesarIsOk; } }
        public void Procesar()
        {
            _procesarIsOk = false;
            if (_numeroPedido>0)
            {
                _procesarIsOk = true;
            }
        }

        public int GetNumeroPedidoTarjeta { get { return _numeroPedido; } }
        public void setNumeroPedidoTarjeta(int numPedTarj)
        {
            _numeroPedido = numPedTarj;
        }
        public ModoSolicitud GetModoSolicitud { get { return _modoSolicitud; } }
        public void setModoSolicitud(ModoSolicitud modo)
        {
            _modoSolicitud = modo;
        }
        public bool VerificarMaximoNumeroPermitidoIsOk(int num)
        {
            return !(num > Sistema.MaximoNumeroPedidoPermitido);
        }
    }
}