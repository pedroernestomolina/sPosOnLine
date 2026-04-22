using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PedidoWeb.TrasladarPisoVta.Vm
{
    public class TrasladarPisoVtaImpl: ITrasladarPisoVta
    {
        private int _idPedidoTrasladar;
        private Domain.UseCase.IUseCase _uc;
        //
        public Models.Modelo MiModelo { get; set; }
        //
        public TrasladarPisoVtaImpl()
        {
            _idPedidoTrasladar = -1;
            _uc = new Domain.UseCase.UseCaseImpl();
            MiModelo = new Models.Modelo();
        }
        public void setIdPedidoTrasaldar(int idPedido)
        {
            _idPedidoTrasladar = idPedido;
        }
        //
        public void Invoke()
        {
            Inicializa();
            Inicia();
            LimpiarSalida();
        }
        //
        private void Inicializa()
        {
        }
        private void Inicia()
        {
            if (CargarData()) 
            {
                if (MiModelo.PedidoTrasladar != null) 
                {
                    var _trasladar = true;
                    if (MiModelo.PedidoTrasladar.Items.Where(w => w.HayDisponibilidad == false).Count() > 0)
                    {
                        //_trasladar = false;
                    }

                    if (_trasladar) 
                    {
                        try
                        {
                            var aplicarTraslado = new Domain.Models.AplicarTraslado()
                            {
                                IdDeposito = Sistema.Deposito.id,
                                IdOperador = Sistema.PosEnUso.id,
                                Items = MiModelo.PedidoTrasladar.Items,
                            };
                            var rt = _uc.AplicarTrasladoPisoVenta(aplicarTraslado);
                        }
                        catch (Exception e)
                        {
                            Helpers.Msg.Error(e.Message);
                        }
                    }
                }
            }
        }
        private void LimpiarSalida()
        {
            _idPedidoTrasladar = -1;
            MiModelo.Limpiar();
        }
        //
        private bool CargarData()
        {
            try 
	        {
                if (_idPedidoTrasladar == -1) { throw new Exception("PEDIDO NO SELECCIONADO"); }

                MiModelo.PedidoTrasladar = _uc.CapturarTrasladoPisoVenta(_idPedidoTrasladar);

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