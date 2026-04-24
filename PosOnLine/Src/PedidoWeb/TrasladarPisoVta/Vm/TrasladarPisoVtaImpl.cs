using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PedidoWeb.TrasladarPisoVta.Vm
{
    public class TrasladarPisoVtaImpl : ITrasladarPisoVta
    {
        private int _idPedidoTrasladar;
        private Domain.UseCase.IUseCase _uc;
        private bool _trasladoPisoVta;
        private Pos.ICliente _gCliente;
        private decimal _tasaSistema;

        //
        public bool TrasladoPisoVtaExitoso { get { return _trasladoPisoVta; } }
        public Models.Modelo MiModelo { get; set; }
        //
        public TrasladarPisoVtaImpl()
        {
            _tasaSistema = 0m;
            _trasladoPisoVta = false;
            _idPedidoTrasladar = -1;
            _uc = new Domain.UseCase.UseCaseImpl();
            _gCliente = Sistema.MiFabrica.CreateInstace_PosCliente();
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
            _tasaSistema = 0m;
            _trasladoPisoVta = false;
        }
        private void Inicia()
        {
            _trasladoPisoVta = false;
            if (CargarData())
            {
                if (MiModelo.PedidoTrasladar != null)
                {
                    try
                    {
                        var _trasladar = true;
                        var _montoNetoMonLocal = MiModelo.PedidoTrasladar.Encabezado.ImporteMonLocal;
                        var _montoFullMonRef = MiModelo.PedidoTrasladar.Encabezado.ImporteMonRef;
                        var _cniRenglones = MiModelo.PedidoTrasladar.Encabezado.CntItems;
                        var _tasaCambioPos = MiModelo.PedidoTrasladar.Encabezado.TasaCambio;
                        var _cirifEntidadWeb = MiModelo.PedidoTrasladar.Encabezado.CiRifEntidad;

                        if (MiModelo.PedidoTrasladar.Encabezado.IdSucursal != Sistema.Sucursal.id) 
                        {
                            throw new Exception("SUCURSAL PEDIDO INCORRECTA");
                        }

                        if (MiModelo.PedidoTrasladar.Encabezado.IdDeposito != Sistema.Deposito.id)
                        {
                            throw new Exception("DEPOSITO PEDIDO INCORRECTA");
                        }

                        if (MiModelo.PedidoTrasladar.Items.Where(w => w.HayDisponibilidad == false).Count() > 0)
                        {
                            var lt = MiModelo.PedidoTrasladar.Items.Where(w => w.HayDisponibilidad == false).ToList();
                            var msg = "Autorizar Solo Despachar Lo Disponible Para " + Environment.NewLine;
                            var xi = 0;
                            foreach (var il in lt) 
                            {
                                if (xi < 3)
                                {
                                    msg += il.nombrePrd + ", Cnt Solicitada: " + il.cntSolicitada.ToString("n0") + ", Cnt Disponible: " + il.CntDisponibleParaTrasladar.ToString("n0") + Environment.NewLine;
                                }
                                xi++;
                            }
                            if (xi > 3)
                            {
                                msg += "Y Otro(s) " + (xi - 3).ToString() + " Productos Mas ?";
                            }
                            else 
                            {
                                msg += " ?";
                            }
                            _trasladar = Helpers.Msg.Autorizar(msg);
                        }

                        var _idCliente = _uc.VerificarExistenciaEntidadWebEnCliente(_cirifEntidadWeb);
                        if (_idCliente == "")
                        {
                            if (Helpers.Msg.Autorizar("Cedula / Rif Del Cliente Web No Encontrado, Deseas Buscar / Crear El Cliente ? "))
                            {
                                BuscarSeleccionarCliente();
                                if (_gCliente.IsClienteOk)
                                {
                                    _idCliente = _gCliente.Cliente.Id;
                                    _trasladar = true;
                                }
                                else
                                {
                                    _trasladar = false;
                                }
                            }
                            else 
                            {
                                _trasladar = false;
                            }
                        }

                        var entidadWeb = _uc.ObtenerEntidadWebSegunIdCliente(_idCliente);

                        if (_trasladar)
                        {
                            var aplicarTraslado = new Domain.Models.AplicarTrasladoModel()
                            {
                                IdPedidoWeb = MiModelo.PedidoTrasladar.Encabezado.Id,
                                NroPedidoWeb = MiModelo.PedidoTrasladar.Encabezado.PedidoNro,
                                IdDeposito = Sistema.Deposito.id,
                                IdOperador = Sistema.PosEnUso.id,
                                IdSucursal = Sistema.Sucursal.id,
                                CiRifEntidad = entidadWeb.CiRifCliente,
                                CntRenglones = _cniRenglones,
                                IdCliente = entidadWeb.IdCliente,
                                IdVendedor = "0000000001",
                                ImporteFullMonRef = _montoFullMonRef,
                                ImporteNetoMonLocal = _montoNetoMonLocal,
                                NombreEntidad = entidadWeb.NombreCliente,
                                TasaCambioPos = _tasaCambioPos,
                                TasaSistema = _tasaSistema,
                                Items = MiModelo.PedidoTrasladar.Items,
                            };
                            var rt = _uc.AplicarTrasladoPisoVenta(aplicarTraslado);
                        }
                        _trasladoPisoVta = true;
                    }
                    catch (Exception e)
                    {
                        Helpers.Msg.Error(e.Message);
                    }
                }
            }
        }

        private void BuscarSeleccionarCliente()
        {
            _gCliente.setHabilitarBusqueda(true);
            _gCliente.Inicializa();
            _gCliente.Inicia();
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

                if (MiModelo.PedidoTrasladar.Encabezado.EstatusProcesado != "0") 
                {
                    throw new Exception("ESTATUS PEDIDO INCORRECTO, VERIFIQUE");
                }

                var rst = Sistema.MyData.Configuracion_TasaCambioSistema();
                if (rst.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst.Mensaje);
                }
                _tasaSistema = rst.Entidad;

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