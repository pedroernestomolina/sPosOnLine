using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pos
{

    public class Gestion
    {

        public enum EnumModoFuncion { Facturacion = 1, NotaCredito, NotaEntrega };


        private string _claveAcceso;
        private decimal _tasaCambioActual;
        private string _precioManejar;
        private OOB.Deposito.Entidad.Ficha _depositoAsignado;
        private OOB.Sucursal.Entidad.Ficha _sucursalAsignada;
        private OOB.Concepto.Entidad.Ficha _conceptoVenta;
        private OOB.Concepto.Entidad.Ficha _conceptoDevVenta;
        private OOB.Concepto.Entidad.Ficha _conceptoSalida;
        private OOB.Sistema.TipoDocumento.Entidad.Ficha _tipoDocumentoVenta;
        private OOB.Sistema.TipoDocumento.Entidad.Ficha _tipoDocumentoDevVenta;
        private OOB.Sistema.TipoDocumento.Entidad.Ficha _tipoDocumentoNotaEntrega;
        private OOB.Vendedor.Entidad.Ficha _vendedorAsignado;
        private OOB.Sistema.SerieFiscal.Entidad.Ficha _serieFactura;
        private OOB.Sistema.SerieFiscal.Entidad.Ficha _serieNotaCredito;
        private OOB.Sistema.SerieFiscal.Entidad.Ficha _serieNotaEntrega;
        private OOB.Sistema.Transporte.Entidad.Ficha _transporteAsignado;
        private OOB.Sistema.TasaFiscal.Entidad.Ficha _tasaFiscal_1;
        private OOB.Sistema.TasaFiscal.Entidad.Ficha _tasaFiscal_2;
        private OOB.Sistema.TasaFiscal.Entidad.Ficha _tasaFiscal_3;
        private OOB.Sistema.Cobrador.Entidad.Ficha _cobradorAsignado;
        private OOB.Sistema.MedioPago.Entidad.Ficha _medioPagoEfectivo;
        private OOB.Sistema.MedioPago.Entidad.Ficha _medioPagoDivisa;
        private OOB.Sistema.MedioPago.Entidad.Ficha _medioPagoElectronico;
        private OOB.Sistema.MedioPago.Entidad.Ficha _medioPagoOtro;

        private OOB.Documento.Entidad.Ficha _docAplicarNotaCredito;
        private EnumModoFuncion _modoFuncion;
        private bool _permitirBusquedaPorDescripcion;
        //private Producto.Lista.Gestion _gestionListar;
        private Producto.Lista.IListaModo _gestionListar;
        private Producto.Buscar.Gestion _gestionBuscar;
        private ICliente _gestionCliente;
        //private Consultor.Gestion _gestionConsultor;
        private Consultor.IModo _gestionConsultor;
        //private Item.Gestion _gestionItem;
        private Item.IModo _gestionItem;
        private Multiplicar.Gestion _gestionMultiplicar;
        private Pago.Procesar.Gestion _gestionProcesarPago;
        private Pendiente.Gestion _gestionPendiente;
        private PassWord.Gestion _gestionPassW;
        private bool _isTickeraOk;
        private Helpers.Imprimir.IDocumento _ImprimirDoc;
        //private PrecioMayor.Gestion _gestionMayor;
        private PrecioMayor.IModo _gestionMayor;
        private CambioPrecio.ICambioPrecio _gCambioPrecio;
        private SolicitarPermiso.ISolicitarPermiso _gSolicitarPermiso;
        private IMultiplicar _gMultiplicar;
        //
        private System.Windows.Forms.PrintDialog printDialog2;
        private System.Drawing.Printing.PrintDocument printDocument2;
        //
        private OOB.Vendedor.Entidad.Ficha _vendedorPorDefecto; 


        public Decimal TasaCambioActual { get { return _tasaCambioActual; } }
        public string UsuarioActual { get { return Sistema.Usuario.codigo + Environment.NewLine + Sistema.Usuario.nombre; } }
        public string EquipoEstacion { get { return Sistema.EquipoEstacion; } }
        public string ClienteData { get { return _gestionCliente.ClienteData; } }
        public int CantItem { get { return _gestionItem.CantItem; } }
        public decimal TotalPeso { get { return _gestionItem.TotalPeso; } }
        public int CantRenglones { get { return _gestionItem.CantRenglones; } }
        public decimal Importe { get { return _gestionItem.Importe; } }
        public decimal ImporteDivisa { get { return _gestionItem.ImporteDivisa; } }
        public string ProductoNombre { get { return _gestionItem.Producto; } }
        public string ProductoTasaIva { get { return _gestionItem.PrdTasaIva; } }
        public decimal ProductoPrecioNeto { get { return _gestionItem.PrdPrecioNeto; } }
        public decimal ProductoIva { get { return _gestionItem.PrdIva; } }
        public decimal ProductoContenido { get { return _gestionItem.PrdContenido; } }
        public int CntCtasPendientes { get { return _gestionPendiente.CntCtasPendientes; } }
        public BindingSource ItemSource { get { return _gestionItem.ItemSource; } }
        public bool IsNotaCredito { get { return _modoFuncion == EnumModoFuncion.NotaCredito; } }
        public bool IsNotaEntrega { get { return _modoFuncion == EnumModoFuncion.NotaEntrega; } }
        public bool IsTickeraOk { get { return _isTickeraOk; } }

        public bool SalirIsOk
        {
            get
            {
                var rt = true;
                if (Importe > 0) { return false; }
                if (CantItem > 0) { return false; }
                return rt;
            }
        }

        private Anular.IAnular _gAnular;
        public Gestion(Anular.IAnular ctrAnular)
        {
            _gAnular = ctrAnular;

            printDialog2 = new PrintDialog();
            printDocument2 = new System.Drawing.Printing.PrintDocument();
            printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            printDialog2.Document = printDocument2;


            _precioManejar = "";
            _docAplicarNotaCredito = null;
            _modoFuncion = EnumModoFuncion.Facturacion;
            _permitirBusquedaPorDescripcion = false;

            //03/04
            //_gestionMayor = new PrecioMayor.Gestion();
            //_gestionListar = new Producto.Lista.Gestion();
            //_gestionConsultor = new Consultor.Gestion();
            //_gestionItem = new Item.Gestion();
            //_gestionListar = new Producto.Lista.ModoAdm.ImpModoAdm();
            //_gestionMayor = new PrecioMayor.ModoAdm.ImpModoAdm();
            //_gestionConsultor = new Consultor.ModoAdm.ImpModoAdm();
            //_gestionItem = new Item.ModoAdm.ImpModoAdm();
            _gestionListar = Sistema.MiFabrica.CreateInstace_PosGestionListar();
            _gestionMayor = Sistema.MiFabrica.CreateInstace_PosGestionMayor();
            _gestionConsultor = Sistema.MiFabrica.CreateInstace_PosGestionConsultor();
            _gestionItem = Sistema.MiFabrica.CreateInstace_PosGestionItem(); 

            _gestionBuscar = new Producto.Buscar.Gestion();
            _gestionBuscar.setGestionLista(_gestionListar);
            _gestionBuscar.setGestionPrecioMayor(_gestionMayor);
            _gestionConsultor.setGestionBuscar(_gestionBuscar);
            _gestionMultiplicar = new Multiplicar.Gestion();
            _gestionPendiente = new Pendiente.Gestion();
            _gestionItem.Hnd_Item_Cambio += _gestionItem_Hnd_Item_Cambio;
            _gestionItem.setGestionMultiplicar(_gestionMultiplicar);
            _gestionItem.setGestionPendiente(_gestionPendiente);
            _gestionProcesarPago = new Pago.Procesar.Gestion();
            _gCambioPrecio = new CambioPrecio.CambioPrecio();
            _gSolicitarPermiso = new SolicitarPermiso.SolicitarPerm();
            //
            _gMultiplicar = _gestionMultiplicar;
        }
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            _isTickeraOk = false;
            if (_ImprimirDoc != null)
            {
                _ImprimirDoc.setControlador(e);
                _ImprimirDoc.setEmpresa(Sistema.DatosEmpresa);
                _ImprimirDoc.ImprimirDoc();
            }
            _ImprimirDoc = null;
        }


        private void _gestionItem_Hnd_Item_Cambio(object sender, EventArgs e)
        {
            if (frm != null)
            {
                frm.ActualizarItem();
            }
        }

        public void Inicializa()
        {
            _docAplicarNotaCredito = null;
            _modoFuncion = EnumModoFuncion.Facturacion;
            _gestionCliente.Inicializa();
        }

        PosFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new PosFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_FactorDivisa();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var r02 = Sistema.MyData.Deposito_GetFichaById(Sistema.ConfiguracionActual.idDeposito);
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            var r02_1 = Sistema.MyData.Concepto_GetFichaById(Sistema.ConfiguracionActual.idConceptoVenta);
            if (r02_1.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_1.Mensaje);
                return false;
            }
            var r02_2 = Sistema.MyData.Concepto_GetFichaById(Sistema.ConfiguracionActual.idConceptoDevVenta);
            if (r02_2.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_2.Mensaje);
                return false;
            }
            var r02_3 = Sistema.MyData.Sistema_TipoDocumento_GetFichaById(Sistema.ConfiguracionActual.idTipoDocumentoVenta);
            if (r02_3.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_3.Mensaje);
                return false;
            }
            var r02_4 = Sistema.MyData.Sistema_TipoDocumento_GetFichaById(Sistema.ConfiguracionActual.idTipoDocumentoDevVenta);
            if (r02_4.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_4.Mensaje);
                return false;
            }
            var r02_5 = Sistema.MyData.Sistema_TipoDocumento_GetFichaById(Sistema.ConfiguracionActual.idTipoDocumentoNotaEntrega);
            if (r02_5.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_5.Mensaje);
                return false;
            }
            var r02_6 = Sistema.MyData.Sucursal_GetFichaById(Sistema.ConfiguracionActual.idSucursal);
            if (r02_6.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_6.Mensaje);
                return false;
            }
            var r02_7 = Sistema.MyData.Vendedor_GetFichaById(Sistema.ConfiguracionActual.idVendedor);
            if (r02_7.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_7.Mensaje);
                return false;
            }
            _vendedorPorDefecto = r02_7.Entidad;
            var r02_8 = Sistema.MyData.Sistema_Serie_GetFichaBySerie(Sistema.SerieFactura);
            if (r02_8.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_8.Mensaje);
                return false;
            }
            var r02_9 = Sistema.MyData.Sistema_Serie_GetFichaBySerie(Sistema.SerieNCredito);
            if (r02_9.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_9.Mensaje);
                return false;
            }
            var r02_A = Sistema.MyData.Sistema_Serie_GetFichaBySerie(Sistema.SerieNEntrega);
            if (r02_A.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_A.Mensaje);
                return false;
            }
            var r02_B = Sistema.MyData.Sistema_Transporte_GetFichaById(Sistema.ConfiguracionActual.idTransporte);
            if (r02_B.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_B.Mensaje);
                return false;
            }
            var r02_C = Sistema.MyData.Sistema_Fiscal_GetTasas(new OOB.Sistema.TasaFiscal.Listar.Filtro());
            if (r02_C.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_C.Mensaje);
                return false;
            }
            var r02_D = Sistema.MyData.Sistema_Cobrador_GetFichaById(Sistema.ConfiguracionActual.idCobrador);
            if (r02_D.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_D.Mensaje);
                return false;
            }
            var r02_E = Sistema.MyData.Sistema_MedioPago_GetFichaById(Sistema.ConfiguracionActual.idMedioPagoEfectivo);
            if (r02_E.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_E.Mensaje);
                return false;
            }
            var r02_F = Sistema.MyData.Sistema_MedioPago_GetFichaById(Sistema.ConfiguracionActual.idMedioPagoDivisa);
            if (r02_F.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_F.Mensaje);
                return false;
            }
            var r02_G = Sistema.MyData.Sistema_MedioPago_GetFichaById(Sistema.ConfiguracionActual.idMedioPagoElectronico);
            if (r02_G.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_G.Mensaje);
                return false;
            }
            var r02_H = Sistema.MyData.Sistema_MedioPago_GetFichaById(Sistema.ConfiguracionActual.idMedioPagoOtros);
            if (r02_H.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_H.Mensaje);
                return false;
            }
            var r02_I = Sistema.MyData.Sistema_ClaveAcceso_GetByIdNivel(int.Parse(Sistema.ConfiguracionActual.idClaveUsar));
            if (r02_I.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_I.Mensaje);
                return false;
            }
            var r02_J = Sistema.MyData.Concepto_GetFichaById(Sistema.ConfiguracionActual.idConceptoSalida);
            if (r02_J.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_J.Mensaje);
                return false;
            }

            var filtro = new OOB.Venta.Item.Lista.Filtro()
            {
                idOperador = Sistema.PosEnUso.id,
            };
            var r03 = Sistema.MyData.Venta_Item_GetLista(filtro);
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }

            var r04 = Sistema.MyData.Configuracion_Habilitar_Precio5_VentaMayor();
            if (r04.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }

            var r05 = Sistema.MyData.Configuracion_HabilitarDescuentoUnicamenteConPagoEnDivsa();
            if (r05.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            var r06 = Sistema.MyData.Configuracion_ValorMaximoPorcentajeDescuento();
            if (r06.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }
            _habilitarBonoPagoDivisa = r05.Entidad;
            _dsctoBonoPagoDivisa = r06.Entidad;


            _permitirBusquedaPorDescripcion = Sistema.ConfiguracionActual.BusquedaPorDescripcion_Activa;
            _tasaCambioActual = r01.Entidad;
            _depositoAsignado = r02.Entidad;
            _conceptoVenta = r02_1.Entidad;
            _conceptoDevVenta = r02_2.Entidad;
            _tipoDocumentoVenta = r02_3.Entidad;
            _tipoDocumentoDevVenta = r02_4.Entidad;
            _tipoDocumentoNotaEntrega = r02_5.Entidad;
            _sucursalAsignada = r02_6.Entidad;
            _vendedorAsignado = r02_7.Entidad;
            _serieFactura = r02_8.Entidad;
            _serieNotaCredito = r02_9.Entidad;
            _serieNotaEntrega = r02_A.Entidad;
            _transporteAsignado = r02_B.Entidad;
            _tasaFiscal_1 = r02_C.ListaD.FirstOrDefault(f => f.codTasa == 1);
            _tasaFiscal_2 = r02_C.ListaD.FirstOrDefault(f => f.codTasa == 2);
            _tasaFiscal_3 = r02_C.ListaD.FirstOrDefault(f => f.codTasa == 3);
            _cobradorAsignado = r02_D.Entidad;
            _medioPagoEfectivo = r02_E.Entidad;
            _medioPagoDivisa = r02_F.Entidad;
            _medioPagoElectronico = r02_G.Entidad;
            _medioPagoOtro = r02_H.Entidad;
            _claveAcceso = r02_I.Entidad;
            _conceptoSalida = r02_J.Entidad;

            switch (Sistema.ConfiguracionActual.EnumModoPrecio)
            {
                case OOB.Configuracion.Entidad.Enumerados.enumModoPrecio.PorTipoNegocio:
                    _precioManejar = _sucursalAsignada.idPrecioManejar.ToString();
                    break;
                case OOB.Configuracion.Entidad.Enumerados.enumModoPrecio.PorPrecioFijo:
                    _precioManejar = Sistema.ConfiguracionActual.idPrecioManejar;
                    break;
                case OOB.Configuracion.Entidad.Enumerados.enumModoPrecio.Libre:
                    _precioManejar = "";
                    break;
            }


            Helpers.PassWord.setClave(_claveAcceso);
            _gestionBuscar.setDepositoAsignado(_depositoAsignado);
            _gestionBuscar.setTarifaPrecio(_precioManejar);
            _gestionBuscar.setHabilitarVentaMayor(Sistema.Sucursal.HabilitarVentaMayor);
            _gestionConsultor.setTarifaPrecio(_precioManejar);
            _gestionItem.Inicializar();
            _gestionItem.setDepositoAsignado(_depositoAsignado);
            _gestionItem.setTarifaPrecio(_precioManejar);
            _gestionItem.setValidarExistencia(Sistema.ConfiguracionActual.ValidarExistencia_Activa);
            _gestionItem.setHabilitarPrecio5VentaMayor(r04.Entidad);
            if (!IsNotaCredito)
            {
                _gestionItem.setData(r03.ListaD, _tasaCambioActual);
            }
            else
            {
                _gestionItem.setData(_docAplicarNotaCredito.items, _tasaCambioActual);
                _gestionCliente.CargarCliente(_docAplicarNotaCredito.AutoCliente);
            }

            return rt;
        }

        public void ClienteBuscar()
        {
            if (!IsNotaCredito)
            {
                //_gestionCliente.Inicializa();

                if (Sistema.Activar_VentasAdm)
                {
                    var _habilitar = !(_gestionItem.Items.Count() > 0);
                    if (_gestionCliente.Cliente == null)
                    {
                        _habilitar = true;
                    }
                    _gestionCliente.setHabilitarBusqueda(_habilitar);
                }
                _gestionCliente.Inicia();
                _gestionItem.setItemActualInicializar();
            }
        }

        public void Consultor()
        {
            var r01 = Sistema.MyData.Configuracion_Habilitar_Precio5_VentaMayor();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            _gestionConsultor.Inicializa();
            _gestionConsultor.setFactorCambio(_tasaCambioActual);
            _gestionConsultor.Inicia();
            _gestionItem.setItemActualInicializar();
        }

        public void BuscarProducto(string cadena)
        {
            if (cadena == "") { return; }

            if (Sistema.Activar_VentasAdm)
                if (!_gestionCliente.IsClienteOk) 
                {
                    Helpers.Msg.Alerta("POR FAVOR, DEBES PRIMERO SELECCIONAR UN CLIENTE PRIMERO");
                    return;
                }

            if (_precioManejar == "") //MODO LIBRE, debe indicar un cliente, para mostrar precio
            {
                if (!_gestionCliente.IsClienteOk)
                {
                    Helpers.Msg.Alerta("DEBES INDICAR/SELECCIONAR UN CLIENTE POR FAVOR");
                    return;
                }
            }

            if (_modoFuncion != EnumModoFuncion.NotaCredito)
            {
                var _tarifaPrecioManejar = _precioManejar;
                if (_precioManejar == "")
                {
                    if (_gestionCliente.IsClienteOk)
                    {
                        _tarifaPrecioManejar = _gestionCliente.Cliente.TarifaPrecio;
                    }
                    else
                    {
                        _tarifaPrecioManejar = "1";
                    }
                }

                _gestionBuscar.setHabilitarVentaMayor(Sistema.Sucursal.HabilitarVentaMayor);
                _gestionBuscar.GestionListar.setCantidadVisible(true);
                _gestionBuscar.GestionListar.setPrecioVisible(false);
                _gestionBuscar.setTarifaPrecio(_tarifaPrecioManejar);
                _gestionBuscar.ActivarBusqueda(cadena, _permitirBusquedaPorDescripcion);
                if (_gestionBuscar.BusquedaIsOk)
                {
                    _gestionItem.Inicializar();
                    _gestionItem.RegistraItem(_gestionBuscar.AutoProducto, _gestionBuscar.TarifaPrecioSeleccionada);
                }
                else
                    _gestionItem.setItemActualInicializar();
            }

        }

        public void AnularVenta()
        {
            if (CantRenglones == 0)
                return;

            var msg = MessageBox.Show("Anular Venta ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.No)
                return;

            if (PassWIsOk(Sistema.FuncionPosAnularVenta))
            {
                _gestionItem.Inicializar();
                _gestionItem.AnularVenta(!IsNotaCredito);
                if (_gestionItem.AnularVentaIsOk)
                {
                    _gestionCliente.Limpiar();
                    Inicializa();
                    Reiniciar();
                }
                _gestionItem.setItemActualInicializar();
            }
        }

        private void Reiniciar()
        {
            _gestionCliente.Limpiar();
            _vendedorAsignado = _vendedorPorDefecto;
        }

        public void DevolucionItem()
        {
            if (PassWIsOk(Sistema.FuncionPosDevolucion))
            {
                _gestionItem.DevolucionItem(!IsNotaCredito);
            }
        }

        public void DecrementarItem()
        {
            if (!IsNotaCredito)
            {
                if (PassWIsOk(Sistema.FuncionPosTeclaRestar))
                {
                    _gestionItem.Decrementar();
                }
            }
        }

        public void DejarCtaPendiente()
        {
            if (!IsNotaCredito)
            {
                if (CantRenglones == 0)
                    return;

                if (_gestionCliente.Cliente == null)
                {
                    Helpers.Msg.Error("DEBE SELECCIONAR UN CLIENTE ANTES DE DEJAR LA CUENTA PENDIENTE");
                }
                else
                {
                    if (PassWIsOk(Sistema.FuncionPosTeclaPendiente))
                    {
                        var _idSucursal = Sistema.ConfiguracionActual.idSucursal;
                        var _idDeposito = Sistema.ConfiguracionActual.idDeposito;
                        var _idVendedor= Sistema.ConfiguracionActual.idVendedor;
                        if (Sistema.Activar_VentasAdm) 
                        {
                            _idSucursal = _gestionCliente.GetSucursalId;
                            _idDeposito= _gestionCliente.GetDepositoId;
                            _idVendedor = _gestionCliente.GetVendedorId;
                        }
                        _gestionItem.DejarCtaPendiente(_gestionCliente.Cliente, _idSucursal, _idDeposito, _idVendedor);
                        if (_gestionItem.DejarCtaPendienteIsOk)
                        {
                            _gestionCliente.Limpiar();
                            Inicializa();
                            Reiniciar();
                            _gestionItem.setItemActualInicializar();
                        }
                    }
                }
                //Inicializa();
                //_gestionItem.setItemActualInicializar();
            }
        }

        public void AbriCtaPendiente()
        {
            if (!IsNotaCredito)
            {
                if (CntCtasPendientes > 0)
                {
                    if (Importe == 0.0m && CantRenglones == 0)
                    {
                        _gestionPendiente.Inicializar();
                        _gestionPendiente.Inicia();
                        if (_gestionPendiente.AbrirCtaPendienteIsOk)
                        {
                            ActualizarData();
                            if (_gestionPendiente.CtaPediente.Ficha != null)
                            {
                                _gestionCliente.CargarCliente(_gestionPendiente.CtaPediente.Ficha.idCliente);
                                _gestionCliente.setSucursal(_gestionPendiente.CtaPediente.Ficha.idSucursal);
                                _gestionCliente.setDeposito(_gestionPendiente.CtaPediente.Ficha.idDeposito);
                                _gestionCliente.setVendedor(_gestionPendiente.CtaPediente.Ficha.idVendedor);

                                _vendedorAsignado = _vendedorPorDefecto;
                                var v01 = Sistema.MyData.Vendedor_GetFichaById(_gestionPendiente.CtaPediente.Ficha.idVendedor);
                                if (v01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                                {
                                    Helpers.Msg.Error(v01.Mensaje);
                                    return;
                                }
                                _vendedorAsignado = v01.Entidad;
                            }
                        }
                    }
                    else
                    {
                        Helpers.Msg.Error("HAY UNA CUENTA EN PROCESO");
                    }
                }
                _gestionItem.setItemActualInicializar();
            }
        }

        private void ActualizarData()
        {
            var filtro = new OOB.Venta.Item.Lista.Filtro()
            {
                idOperador = Sistema.PosEnUso.id,
            };
            var r01 = Sistema.MyData.Venta_Item_GetLista(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _gestionItem.setData(r01.ListaD, _tasaCambioActual);
        }

        public void Totalizar()
        {
            if (Importe > 0)
            {
                if (CantRenglones > 0)
                {
                    if (_gestionCliente.Cliente == null)
                    {
                        Helpers.Msg.Error("DEBE SELECCIONAR UN CLIENTE PARA PROCESAR DOCUMENTO");
                        return;
                    }

                    if (Sistema.ModoSoloDocPendiente)
                    {
                        Helpers.Msg.Error("OPCION NO PERMITIDA," + Environment.NewLine + "SOLO PODRAS DEJAR EL DOCUMENTO EN PENDIENTE" + Environment.NewLine + "VERIFICA POR FAVOR...");
                        return;
                    }

                    if (_modoFuncion == EnumModoFuncion.Facturacion)
                    {
                        if (!PassWIsOk(Sistema.FuncionPosElaborarFacturaVenta))
                        {
                            return;
                        }
                        _gestionProcesarPago.Inicializar();
                        _gestionProcesarPago.setCliente(_gestionCliente.ClienteData);
                        _gestionProcesarPago.setDataCliente(_gestionCliente.Cliente);
                        _gestionProcesarPago.setImporte(_gestionItem.Importe);
                        _gestionProcesarPago.setTasaCambio(_tasaCambioActual);
                        _gestionProcesarPago.Inicia();
                        if (_gestionProcesarPago.PagoIsOk)
                        {
                            ProcesarFactura();
                        }
                    }
                    else if (_modoFuncion == EnumModoFuncion.NotaCredito)
                    {
                        var msg = MessageBox.Show("Procesar Nota De Crédito ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (msg == DialogResult.Yes)
                        {
                            _gestionProcesarPago.Inicializar();
                            _gestionProcesarPago.setCliente(_gestionCliente.ClienteData);
                            _gestionProcesarPago.setImporte(_gestionItem.Importe);
                            _gestionProcesarPago.setTasaCambio(_tasaCambioActual);
                            _gestionProcesarPago.setNotaCredito(true);
                            if (_docAplicarNotaCredito.isContado)
                            {
                                _gestionProcesarPago.Inicia();
                                if (_gestionProcesarPago.PagoIsOk)
                                {
                                    ProcesarNotaCredito();
                                }
                            }
                            else
                            {
                                ProcesarNotaCredito();
                            }
                        }
                    }
                    else
                    {
                        var msg = MessageBox.Show("Procesar Nota De Entrega ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (msg == DialogResult.Yes)
                        {
                            _gestionProcesarPago.Inicializar();
                            _gestionProcesarPago.setCliente(_gestionCliente.ClienteData);
                            _gestionProcesarPago.setDataCliente(_gestionCliente.Cliente);
                            _gestionProcesarPago.setImporte(_gestionItem.Importe);
                            _gestionProcesarPago.setTasaCambio(_tasaCambioActual);
                            _gestionProcesarPago.Inicia();
                            if (_gestionProcesarPago.PagoIsOk)
                            {
                                ProcesarNotaEntreag_2();
                            }
                        }
                    }
                }
            }
            _gestionItem.setItemActualInicializar();
        }

        private void ProcesarFactura()
        {
            if (Sistema.Activar_VentasAdm)
            {
                var t01 = Sistema.MyData.Vendedor_GetFichaById(_gestionCliente.GetVendedorId);
                if (t01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(t01.Mensaje);
                    return;
                }
                _vendedorAsignado = t01.Entidad;
            }
            if (_vendedorAsignado == null)
            {
                _vendedorAsignado = _vendedorPorDefecto;
            }

            _isTickeraOk = false;
            _ImprimirDoc = null;
            var dsctoFinal = _gestionProcesarPago.DescuentoPorct;
            _gestionItem.setDescuentoFinal(dsctoFinal);

            var isCredito = _gestionProcesarPago.IsCreditoOk;
            var montoRecibido = _gestionProcesarPago.MontoRecibido;
            //var montoCambio = _gestionProcesarPago.MontoCambioDar_MonedaNacional;
            var montoCambio = _gestionProcesarPago.MontoCambioDar;
            var BaseExenta = _gestionItem.Items.Sum(s => s.BaseExenta);
            var MontoBase = _gestionItem.Items.Sum(s => s.MontoBase);
            var MontoImpuesto = _gestionItem.Items.Sum(s => s.MontoImpuesto);
            var MontoBase1 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_1.id).Sum(s => s.MontoBase);
            var MontoBase2 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_2.id).Sum(s => s.MontoBase);
            var MontoBase3 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_3.id).Sum(s => s.MontoBase);
            var MontoImpuesto1 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_1.id).Sum(s => s.MontoImpuesto);
            var MontoImpuesto2 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_2.id).Sum(s => s.MontoImpuesto);
            var MontoImpuesto3 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_3.id).Sum(s => s.MontoImpuesto);
            var dsctoMonto = _gestionItem.Importe * dsctoFinal / 100;
            var utilidadMonto = _gestionItem.Items.Sum(s => s.Utilidad);
            var costoMonto = _gestionItem.Items.Sum(s => s.CostoVenta);
            var subTotalNeto = _gestionItem.Items.Sum(s => s.TotalNeto);
            var subTotal = _gestionItem.Importe - dsctoMonto;
            var netoMonto = _gestionItem.Items.Sum(s => s.VentaNeta);
            var netoMontoDivisa = 0m;
            if (_tasaCambioActual > 0) 
            {
                netoMontoDivisa = netoMonto / _tasaCambioActual;
            }

            var importeDocumento = _gestionProcesarPago.MontoPagar;
            var importeDocumentoDivisa = _gestionProcesarPago.MontoPagarDivisa;
            var documento = "";
            var factorCambio = _tasaCambioActual;
            var saldoPendiente = isCredito ? importeDocumento : 0.0m;
            var dataPagoRecolectada = _gestionProcesarPago.DataPagoRecolectar;

            var fichaOOB = new OOB.Documento.Agregar.Factura.Ficha()
            {
                idOperador = Sistema.PosEnUso.id,
                DocumentoNro = documento,
                RazonSocial = _gestionCliente.Cliente.Nombre,
                DirFiscal = _gestionCliente.Cliente.DireccionFiscal,
                CiRif = _gestionCliente.Cliente.CiRif,
                Tipo = _tipoDocumentoVenta.codigo,
                Exento = BaseExenta,
                Base1 = MontoBase1,
                Base2 = MontoBase2,
                Base3 = MontoBase3,
                Impuesto1 = MontoImpuesto1,
                Impuesto2 = MontoImpuesto2,
                Impuesto3 = MontoImpuesto3,
                MBase = MontoBase,
                Impuesto = MontoImpuesto,
                Total = importeDocumento,
                Tasa1 = _tasaFiscal_1.tasa,
                Tasa2 = _tasaFiscal_2.tasa,
                Tasa3 = _tasaFiscal_3.tasa,
                Nota = "",
                TasaRetencionIva = 0.0m,
                TasaRetencionIslr = 0.0m,
                RetencionIva = 0.0m,
                RetencionIslr = 0.0m,
                AutoCliente = _gestionCliente.Cliente.Id,
                CodigoCliente = _gestionCliente.Cliente.Codigo,
                Control = _serieFactura.Control,
                OrdenCompra = "",
                Dias = 0,
                Descuento1 = dsctoMonto,
                Descuento2 = 0.0m,
                Cargos = 0.0m,
                Descuento1p = dsctoFinal,
                Descuento2p = 0.0m,
                Cargosp = 0.0m,
                Columna = "1",
                EstatusAnulado = "0",
                Aplica = "",
                ComprobanteRetencion = "",
                SubTotalNeto = subTotalNeto,
                Telefono = _gestionCliente.Cliente.Telefono,
                FactorCambio = factorCambio,
                CodigoVendedor = _vendedorAsignado.codigo,
                Vendedor = _vendedorAsignado.nombre,
                AutoVendedor = _vendedorAsignado.id,
                FechaPedido = DateTime.Now.Date,
                Pedido = "",
                CondicionPago = isCredito ? "CREDITO" : "CONTADO",
                Usuario = Sistema.Usuario.nombre,
                CodigoUsuario = Sistema.Usuario.codigo,
                CodigoSucursal = _sucursalAsignada.codigo,
                Transporte = _transporteAsignado.nombre,
                CodigoTransporte = _transporteAsignado.codigo,
                MontoDivisa = importeDocumentoDivisa,
                Despachado = "",
                DirDespacho = "",
                Estacion = Sistema.EquipoEstacion,
                Renglones = _gestionItem.CantRenglones,
                SaldoPendiente = saldoPendiente,
                ComprobanteRetencionIslr = "",
                DiasValidez = 0,
                AutoUsuario = Sistema.Usuario.id,
                AutoTransporte = _transporteAsignado.id,
                Situacion = "Procesado",
                Signo = _tipoDocumentoVenta.signo,
                Serie = _serieFactura.Serie,
                Tarifa = _precioManejar,
                TipoRemision = "",
                DocumentoRemision = "",
                AutoRemision = "",
                DocumentoNombre = "VENTA",
                SubTotalImpuesto = MontoImpuesto,
                SubTotal = subTotal,
                TipoCliente = "",
                Planilla = "",
                Expendiente = "",
                AnticipoIva = 0.0m,
                TercerosIva = 0.0m,
                Neto = netoMonto,
                Costo = costoMonto,
                Utilidad = utilidadMonto,
                Utilidadp = 100 - (costoMonto / netoMonto * 100),
                DocumentoTipo = _tipoDocumentoVenta.tipo,
                CiTitular = "",
                NombreTitular = "",
                CiBeneficiario = "",
                NombreBeneficiario = "",
                Clave = "",
                DenominacionFiscal = "No Contribuyente",
                Cambio = montoCambio,
                EstatusValidado = "0",
                Cierre = Sistema.PosEnUso.idAutoArqueoCierre,
                EstatusCierreContable = "0",
                CierreFtp = "",
                Prefijo = _sucursalAsignada.codigo + Sistema.IdEquipo,
                //
                PorctBonoPorPagoDivisa = dataPagoRecolectada.PorctBonoPorPagoDivisa,
                MontoBonoPorPagoDivisa = Math.Round(dataPagoRecolectada.MontoBonoPorPagoDivisa, 2, MidpointRounding.AwayFromZero),
                MontoBonoEnDivisaPorPagoDivisa = Math.Round(dataPagoRecolectada.MontoBonoEnDivisaPorPagoDivisa, 2, MidpointRounding.AwayFromZero),
                CantDivisaAplicaBonoPorPagoDivisa = dataPagoRecolectada.CantDivisaAplicaBonoPorPagoDivisa,
                MontoPorVueltoEnEfectivo = Math.Round(dataPagoRecolectada.MontoPorVueltoEnEfectivo, 2, MidpointRounding.AwayFromZero),
                MontoPorVueltoEnDivisa = Math.Round(dataPagoRecolectada.MontoPorVueltoEnDivisa, 2, MidpointRounding.AwayFromZero),
                MontoPorVueltoEnPagoMovil = Math.Round(dataPagoRecolectada.MontoPorVueltoEnPagoMovil, 2, MidpointRounding.AwayFromZero),
                CantDivisaPorVueltoEnDivisa = dataPagoRecolectada.CantDivisaPorVueltoEnDivisa,
                estatusPorBonoPorPagoDivisa = dataPagoRecolectada.estatusPorBonoPorPagoDivisa,
                estatusPorVueltoEnPagoMovil = dataPagoRecolectada.AplicaPagoMovil ? "1" : "0",
            };

            var medidas = _gestionItem.Items.
                            GroupBy(g => g.Ficha.empaqueDescripcion).
                            Select(s => new OOB.Documento.Agregar.Factura.FichaMedida()
                            {
                                descMedida = s.Key,
                                cnt = s.ToList().Sum(ss => ss.Cantidad),
                                peso = s.ToList().Sum(ss => ss.Cantidad * ss.Ficha.peso),
                                volumen = s.ToList().Sum(ss => ss.Cantidad * ss.Ficha.volumen),
                            }).
                            ToList();
            fichaOOB.Medidas = medidas;
            
            var detalles = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.Factura.FichaDetalle()
                {
                    AutoProducto = s.Ficha.autoProducto,
                    Codigo = s.Ficha.codigo,
                    Nombre = s.Ficha.nombre,
                    AutoDepartamento = s.Ficha.autoDepartamento,
                    AutoGrupo = s.Ficha.autoGrupo,
                    AutoSubGrupo = s.Ficha.autoSubGrupo,
                    AutoDeposito = s.Ficha.autoDeposito,
                    Cantidad = s.Ficha.cantidad,
                    Empaque = s.Ficha.empaqueDescripcion,
                    PrecioNeto = s.Ficha.pneto,
                    Descuento1p = 0.0m,
                    Descuento2p = 0.0m,
                    Descuento3p = 0.0m,
                    Descuento1 = 0.0m,
                    Descuento2 = 0.0m,
                    Descuento3 = 0.0m,
                    CostoVenta = s.CostoVenta,
                    TotalNeto = s.TotalNeto,
                    Tasa = s.Ficha.tasaIva,
                    Impuesto = s.Impuesto,
                    Total = s.Total,
                    EstatusAnulado = "0",
                    Tipo = _tipoDocumentoVenta.codigo,
                    Deposito = _depositoAsignado.nombre,
                    Signo = _tipoDocumentoVenta.signo,
                    PrecioFinal = s.PrecioFinal,
                    AutoCliente = _gestionCliente.Cliente.Id,
                    Decimales = s.Ficha.decimales,
                    ContenidoEmpaque = s.Ficha.empaqueContenido,
                    CantidadUnd = s.TotalUnd,
                    PrecioUnd = s.PrecioUnd,
                    CostoUnd = s.Ficha.costoUnd,
                    Utilidad = s.Utilidad,
                    Utilidadp = s.UtilidadP,
                    PrecioItem = s.PrecioItem,
                    EstatusGarantia = "0",
                    EstatusSerial = "0",
                    CodigoDeposito = _depositoAsignado.codigo,
                    DiasGarantia = 0,
                    Detalle = "",
                    PrecioSugerido = 0.0m,
                    AutoTasa = s.Ficha.autoTasa,
                    EstatusCorte = "0",
                    X = 1,
                    Y = 1,
                    Z = 1,
                    Corte = "",
                    Categoria = s.Ficha.categoria,
                    Cobranzap = 0.0m,
                    Ventasp = 0.0m,
                    CobranzapVendedor = 0.0m,
                    VentaspVendedor = 0.0m,
                    Cobranza = 0.0m,
                    Ventas = 0.0m,
                    CobranzaVendedor = 0.0m,
                    VentasVendedor = 0.0m,
                    CostoPromedioUnd = s.Ficha.costoPromedioUnd,
                    CostoCompra = s.Ficha.costoCompra,
                    EstatusChecked = "1",
                    Tarifa = s.Ficha.tarifaPrecio,
                    TotalDescuento = 0.0m,
                    CodigoVendedor = _vendedorAsignado.codigo,
                    AutoVendedor = _vendedorAsignado.id,
                    CierreFtp = "",
                };
                return nr;
            }).ToList();
            fichaOOB.Detalles = detalles;

            var actDeposito = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.Factura.FichaDeposito()
                {
                    AutoDeposito = s.Ficha.autoDeposito,
                    AutoProducto = s.Ficha.autoProducto,
                    CantUnd = s.TotalUnd,
                };
                return nr;
            }).ToList();
            fichaOOB.ActDeposito = actDeposito;

            var kardex = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.Factura.FichaKardex()
                {
                    AutoProducto = s.Ficha.autoProducto,
                    Total = s.TotalUnd * s.Ficha.costoUnd,
                    AutoDeposito = s.Ficha.autoDeposito,
                    AutoConcepto = _conceptoVenta.id,
                    Modulo = "Ventas",
                    Entidad = _gestionCliente.Cliente.Nombre,
                    Signo = -1,
                    Cantidad = s.Cantidad,
                    CantidadBono = 0.0m,
                    CantidadUnd = s.TotalUnd,
                    CostoUnd = s.Ficha.costoUnd,
                    EstatusAnulado = "0",
                    Nota = "",
                    PrecioUnd = s.PrecioFinalUnd,
                    Codigo = _tipoDocumentoVenta.codigo,
                    Siglas = _tipoDocumentoVenta.siglas,
                    CierreFtp = "",
                    CodigoSucursal = _sucursalAsignada.codigo,
                    CodigoDeposito = _depositoAsignado.codigo,
                    NombreDeposito = _depositoAsignado.nombre,
                    CodigoConcepto = _conceptoVenta.codigo,
                    NombreConcepto = _conceptoVenta.nombre,
                    FactorCambio = factorCambio,
                };
                return nr;
            }).ToList();
            fichaOOB.MovKardex = kardex;

            fichaOOB.DocCxC = new OOB.Documento.Agregar.Factura.FichaCxC()
            {
                CCobranza = 0.0m,
                CCobranzap = 0.0m,
                TipoDocumento = _tipoDocumentoVenta.siglas,
                Nota = "",
                Importe = importeDocumento,
                Acumulado = isCredito ? 0.0m : importeDocumento,
                AutoCliente = _gestionCliente.Cliente.Id,
                Cliente = _gestionCliente.Cliente.Nombre,
                CiRif = _gestionCliente.Cliente.CiRif,
                CodigoCliente = _gestionCliente.Cliente.Codigo,
                EstatusCancelado = isCredito ? "0" : "1",
                Resta = isCredito ? importeDocumento : 0.0m,
                EstatusAnulado = "0",
                Numero = "",
                AutoAgencia = "0000000001",
                Agencia = "",
                Signo = _tipoDocumentoVenta.signo,
                AutoVendedor = _vendedorAsignado.id,
                CDepartamento = 0.0m,
                CVentas = 0.0m,
                CVentasp = 0.0m,
                Serie = _serieFactura.Serie,
                ImporteNeto = netoMonto,
                Dias = 0,
                CastigoP = 0.0m,
                CierreFtp = "",
                MontoDivisa = importeDocumentoDivisa,
                TasaDivisa = factorCambio,
                //
                AcumuladoDivisa = isCredito ? 0.0m : importeDocumentoDivisa,
                CodigoSucursal = _sucursalAsignada.codigo,
                RestaDivisa = isCredito ? importeDocumentoDivisa : 0.0m,
                ImporteNetoDivisa = Math.Round(netoMontoDivisa, 2, MidpointRounding.AwayFromZero),
            };

            var PMontoEfectivo = 0.0m;
            var PMontoDivisa = 0.0m;
            var PMontoElectronico = 0.0m;
            var PMontoOtro = 0.0m;
            var CntEfectivo = 0;
            var CntDivisa = 0;
            var CntElectronico = 0;
            var CntOtro = 0;

            if (isCredito)
            {
                fichaOOB.DocCxCPago = null;
                fichaOOB.ClienteSaldo = new OOB.Documento.Agregar.Factura.FichaClienteSaldo()
                {
                    AutoCliente = _gestionCliente.Cliente.Id,
                    MontoActualizar = importeDocumentoDivisa,
                };
            }
            else
            {
                fichaOOB.DocCxCPago = new OOB.Documento.Agregar.Factura.FichaCxCPago();
                var p = new OOB.Documento.Agregar.Factura.FichaCxC()
                {
                    CCobranza = 0.0m,
                    CCobranzap = 0.0m,
                    TipoDocumento = "PAG",
                    Nota = "",
                    Importe = importeDocumento,
                    Acumulado = 0.0m,
                    AutoCliente = _gestionCliente.Cliente.Id,
                    Cliente = _gestionCliente.Cliente.Nombre,
                    CiRif = _gestionCliente.Cliente.CiRif,
                    CodigoCliente = _gestionCliente.Cliente.Codigo,
                    EstatusCancelado = "0",
                    Resta = 0.0m,
                    EstatusAnulado = "0",
                    Numero = "",
                    AutoAgencia = "0000000001",
                    Agencia = "",
                    Signo = -1,
                    AutoVendedor = _vendedorAsignado.id,
                    CDepartamento = 0.0m,
                    CVentas = 0.0m,
                    CVentasp = 0.0m,
                    Serie = "",
                    ImporteNeto = 0.0m,
                    Dias = 0,
                    CastigoP = 0.0m,
                    CierreFtp = "",
                    MontoDivisa = importeDocumentoDivisa,
                    TasaDivisa = factorCambio,
                    //
                    AcumuladoDivisa = 0m,
                    CodigoSucursal = _sucursalAsignada.codigo,
                    RestaDivisa = 0m,
                    ImporteNetoDivisa = 0m,
                };
                var _montoRecibidoDivisa=0m;
                var _cambioDivisa=0m;
                if (factorCambio >0)
                {
                    _montoRecibidoDivisa= Math.Round(montoRecibido / factorCambio, 2, MidpointRounding.AwayFromZero);
                    _cambioDivisa=Math.Round(montoCambio/ factorCambio, 2, MidpointRounding.AwayFromZero);
                }
                var pR = new OOB.Documento.Agregar.Factura.FichaCxCRecibo()
                {
                    AutoUsuario = Sistema.Usuario.id,
                    Importe = importeDocumento,
                    Usuario = Sistema.Usuario.nombre,
                    MontoRecibido = montoRecibido,
                    Cobrador = _cobradorAsignado.nombre,
                    AutoCliente = _gestionCliente.Cliente.Id,
                    Cliente = _gestionCliente.Cliente.Nombre,
                    CiRif = _gestionCliente.Cliente.CiRif,
                    Codigo = _gestionCliente.Cliente.Codigo,
                    EstatusAnulado = "0",
                    Direccion = _gestionCliente.Cliente.DireccionFiscal,
                    Telefono = _gestionCliente.Cliente.Telefono,
                    AutoCobrador = _cobradorAsignado.id,
                    Anticipos = 0.0m,
                    Cambio = montoCambio,
                    Nota = "",
                    CodigoCobrador = _cobradorAsignado.codigo,
                    Retenciones = 0.0m,
                    Descuentos = 0.0m,
                    Cierre = Sistema.PosEnUso.idAutoArqueoCierre,
                    CierreFtp = "",
                    //
                    ImporteDivisa = importeDocumentoDivisa,
                    MontoRecibidoDivisa = _montoRecibidoDivisa,
                    CambioDivisa = _cambioDivisa,
                    CodigoSucursal = _sucursalAsignada.codigo,
                };
                var pD = new OOB.Documento.Agregar.Factura.FichaCxCDocumento()
                {
                    Id = 1,
                    TipoDocumento = "FAC",
                    Operacion = "Pago",
                    Importe = importeDocumento,
                    Dias = 0,
                    CastigoP = 0.0m,
                    ComisionP = 0.0m,
                    CierreFtp = "",
                    //
                    ImporteDivisa = importeDocumentoDivisa,
                    CodigoSucursal = _sucursalAsignada.codigo,
                    Notas = "",
                };

                var pM = new List<OOB.Documento.Agregar.Factura.FichaCxCMetodoPago>();
                foreach (var it in _gestionProcesarPago.PagoDetalles.Where(w => w.Monto > 0m).ToList())
                {
                    var autoMedioPago = "";
                    var codigoMedioPago = "";
                    var descMedioPago = "";
                    var lote = "";
                    var referencia = "";
                    var montoRecibe = it.MontoRecibido;
                    var _montoRecibeDivisa = 0m;
                    var _aplicaFactorConversion="";

                    switch (it.Modo)
                    {
                        case Pago.Procesar.Enumerados.ModoPago.Efectivo:
                            autoMedioPago = _medioPagoEfectivo.id;
                            codigoMedioPago = _medioPagoEfectivo.codigo;
                            descMedioPago = _medioPagoEfectivo.nombre;
                            PMontoEfectivo += montoRecibe;
                            CntEfectivo += 1;
                            //
                            if (factorCambio>0)
                            {
                                _montoRecibeDivisa = Math.Round(montoRecibe / factorCambio, 4, MidpointRounding.AwayFromZero);
                            }
                            _aplicaFactorConversion="1";
                            break;

                        case Pago.Procesar.Enumerados.ModoPago.Divisa:
                            //montoRecibe = it.Monto;
                            montoRecibe = it.MontoPagoDivisaSinBono;
                            autoMedioPago = _medioPagoDivisa.id;
                            codigoMedioPago = _medioPagoDivisa.codigo;
                            descMedioPago = _medioPagoDivisa.nombre;
                            lote = it.Cantidad.ToString();
                            referencia = TasaCambioActual.ToString("n2").Replace(".", "");
                            PMontoDivisa += montoRecibe;
                            CntDivisa = (int)it.Cantidad;
                            //
                            _montoRecibeDivisa = it.Cantidad;
                            _aplicaFactorConversion="0";
                            break;

                        case Pago.Procesar.Enumerados.ModoPago.Electronico:
                            if (it.Id != 4) //DEBITO
                            {
                                autoMedioPago = _medioPagoElectronico.id;
                                codigoMedioPago = _medioPagoElectronico.codigo;
                                descMedioPago = _medioPagoElectronico.nombre;
                                lote = it.Lote;
                                referencia = it.Referencia;
                                PMontoElectronico += montoRecibe;
                                CntElectronico += 1;
                                //
                                if (factorCambio>0)
                                {
                                    _montoRecibeDivisa = Math.Round(montoRecibe / factorCambio, 4, MidpointRounding.AwayFromZero);
                                }
                                _aplicaFactorConversion="1";
                            }
                            else //OTROS
                            {
                                autoMedioPago = _medioPagoOtro.id;
                                codigoMedioPago = _medioPagoOtro.codigo;
                                descMedioPago = _medioPagoOtro.nombre;
                                lote = it.Lote;
                                referencia = it.Referencia;
                                PMontoOtro += montoRecibe;
                                CntOtro += 1;
                                //
                                if (factorCambio>0)
                                {
                                    _montoRecibeDivisa = Math.Round(montoRecibe / factorCambio, 4, MidpointRounding.AwayFromZero);
                                }
                                _aplicaFactorConversion="1";
                            }
                            break;
                    }

                    pM.Add(new OOB.Documento.Agregar.Factura.FichaCxCMetodoPago()
                    {
                        AutoMedioPago = autoMedioPago,
                        AutoAgencia = "",
                        Medio = descMedioPago,
                        Codigo = codigoMedioPago,
                        MontoRecibido = montoRecibe,
                        EstatusAnulado = "0",
                        Numero = "",
                        Agencia = "",
                        AutoUsuario = Sistema.Usuario.id,
                        Lote = lote,
                        Referencia = referencia,
                        AutoCobrador = _cobradorAsignado.id,
                        Cierre = Sistema.PosEnUso.idAutoArqueoCierre,
                        CierreFtp = "",
                        //
                        OpBanco = "",
                        OpNroCta = "",
                        OpNroRef = "",
                        OpFecha = DateTime.Now.Date,
                        OpDetalle = "",
                        OpMonto = _montoRecibeDivisa,
                        OpTasa = factorCambio,
                        OpAplicaConversion = _aplicaFactorConversion,
                        CodigoSucursal = _sucursalAsignada.codigo,
                    });
                }
                fichaOOB.DocCxCPago.Pago = p;
                fichaOOB.DocCxCPago.Recibo = pR;
                fichaOOB.DocCxCPago.Documento = pD;
                fichaOOB.DocCxCPago.MetodoPago = pM;
                fichaOOB.ClienteSaldo = null;
            }
            fichaOOB.PosVenta = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.Factura.FichaPosVenta()
                {
                    id = s.Ficha.id,
                    idOperador = s.Ficha.idOperador,
                };
                return nr;
            }).ToList();
            fichaOOB.Resumen = new OOB.Documento.Agregar.Factura.FichaPosResumen()
            {
                cntDoc = 1,
                cntDevolucion = 0,
                cntFac = 1,
                cntNCr = 0,
                idResumen = Sistema.PosEnUso.idResumen,
                mDevolucion = 0.0m,
                mFac = importeDocumento,
                mNCr = 0.0m,
                cntEfectivo = CntEfectivo,
                cntDivisa = CntDivisa,
                cntElectronico = CntElectronico,
                cntotros = CntOtro,
                mEfectivo = PMontoEfectivo,
                mDivisa = PMontoDivisa,
                mElectronico = PMontoElectronico,
                mOtros = PMontoOtro,
                cntDocContado = isCredito ? 0 : 1,
                cntDocCredito = isCredito ? 1 : 0,
                mContado = isCredito ? 0 : importeDocumento,
                mCredito = isCredito ? importeDocumento : 0,
                //
                cntAnu = 0,
                cntNte = 0,
                mAnu = 0.0m,
                mNte = 0.0m,
                //
                mCambio = montoCambio,
                cntCambio = montoCambio > 0 ? 1 : 0,
                //
                montoVueltoPorEfectivo=dataPagoRecolectada.MontoPorVueltoEnEfectivo,
                montoVueltoPorDivisa=dataPagoRecolectada.MontoPorVueltoEnDivisa,
                montoVueltoPorPagoMovil=dataPagoRecolectada.MontoPorVueltoEnPagoMovil,
                cntDivisaPorVueltoDivisa = dataPagoRecolectada.CantDivisaPorVueltoEnDivisa,
            };
            fichaOOB.SerieFiscal = new OOB.Documento.Agregar.Factura.FichaSerie() { auto = _serieFactura.Auto };
            if (dataPagoRecolectada.AplicaPagoMovil) 
            {
                var pm = dataPagoRecolectada.DataPagoMovil;
                fichaOOB.PagoMovil = new OOB.Documento.Agregar.Factura.FichaPagoMovil()
                {
                    autoAgencia = pm.agencia.id,
                    ciRif = pm.ciRif,
                    monto = pm.monto,
                    nombre = pm.nombre,
                    telefono = pm.telefono,
                    //
                    clienteDirFiscal = _gestionCliente.Cliente.DireccionFiscal,
                    clienteNombre = _gestionCliente.Cliente.Nombre,
                    clienteRif = _gestionCliente.Cliente.CiRif,
                    codigoDocumento = _tipoDocumentoDevVenta.codigo,
                    tipoDocumento = _tipoDocumentoDevVenta.tipo,
                    montoDocumento = importeDocumento,
                    codigoSucursal = _sucursalAsignada.codigo,
                    nombreAgencia = pm.agencia.desc,
                    cierre = Sistema.PosEnUso.idAutoArqueoCierre,
                    cierreFtp = "",
                };
            }
            fichaOOB.estatusFiscal = Sistema.ImprimirFactura.IsModoFiscal;
            if (Sistema.ImprimirFactura.IsModoFiscal) 
            {
                var f01 = Sistema.FiscalTfhka.Informacion();
                if (f01.Resultado == LibFoxFiscal.Resultado.EnumResultado.ERROR)
                {
                    Helpers.Msg.Error(f01.MensajeError);
                    return;
                }
                fichaOOB.SerieFiscal = null;
                fichaOOB.DocumentoNro = (f01.Entidad.UltimaFacturaGenerada + 1).ToString().Trim().PadLeft(10, '0');
                fichaOOB.Control = f01.Entidad.Serial;
                fichaOOB.zFiscal = f01.Entidad.UltimoZGenerado + 1;
            }
            var r01 = Sistema.MyData.Documento_Agregar_Factura(fichaOOB);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var xdata = CargarDataDocumento(r01.Entidad.autoDoc);
            if (xdata != null)
            {
                var dat = new Helpers.Imprimir.dataQR()
                {
                    autoCierre = r01.Entidad.autoCierre,
                    autoDoc = r01.Entidad.autoDoc,
                    codDoc = r01.Entidad.codDoc,
                    idVerificador = r01.Entidad.idVerificador,
                    montoDoc = r01.Entidad.montoDoc,
                    numDoc = r01.Entidad.numDoc,
                };
                Sistema.ImprimirFactura.setData(xdata);
                Sistema.ImprimirFactura.setImprimirQR(dat);
                if (Sistema.ImprimirFactura.IsModoTicket)
                {
                    _isTickeraOk = true;
                    _ImprimirDoc = Sistema.ImprimirFactura;
                    printDocument2.Print();
                }
                else 
                {
                    Sistema.ImprimirFactura.ImprimirDoc();
                }
            }

            _gestionItem.Limpiar();
            _gestionCliente.Limpiar();
            Inicializa();
            Reiniciar();
        }

        public void ActivarCalculadora()
        {
            Helpers.Utilitis.Calculadora();
            _gestionItem.setItemActualInicializar();
        }

        public void ListaPlu()
        {
            if (!IsNotaCredito)
            {
                var filtro = new OOB.Producto.Lista.Filtro()
                {
                    autoDeposito = _depositoAsignado.id,
                    cadena = "",
                    idPrecioManejar = _precioManejar,
                    isPorPlu = true,
                };
                var r04 = Sistema.MyData.Producto_GetLista(filtro);
                if (r04.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r04.Mensaje);
                    return;
                }
                _gestionListar.Inicializa();
                _gestionListar.setData(r04.ListaD, _tasaCambioActual);
                _gestionListar.setFiltroPrdListar(filtro);
                _gestionListar.Inicia();
                if (_gestionListar.ItemSeleccionIsOk)
                {
                    _gestionItem.Inicializar();
                    var _autoPrd = _gestionListar.IdItemSeleccionado;
                    _gestionItem.RegistraItem(_autoPrd, _precioManejar);
                }
            }
        }

        public void setGestionPassW(PassWord.Gestion gestion)
        {
            _gestionPassW = gestion;
        }

        private bool PassWIsOk(string funcion)
        {
            return Helpers.PassWord.PassWIsOk(funcion);
        }

        public void setNotaCredito(AdministradorDoc.Lista.data data)
        {
            var r01 = Sistema.MyData.Documento_GetById(data.idDocumento);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _docAplicarNotaCredito = r01.Entidad;
            _modoFuncion = EnumModoFuncion.NotaCredito;
        }


        /// <summary>
        /// NOTA DE CREDITO
        /// </summary>
        private void ProcesarNotaCredito()
        {
            var t01 = Sistema.MyData.Vendedor_GetFichaById(_docAplicarNotaCredito.AutoVendedor);
            if (t01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(t01.Mensaje);
                return;
            }
            _vendedorAsignado = t01.Entidad;


            _ImprimirDoc = null;
            _isTickeraOk = false;

            var dsctoFinal = 0.0m;
            dsctoFinal = _docAplicarNotaCredito.Descuento1p;
            _gestionItem.setDescuentoFinal(dsctoFinal);
            _gestionProcesarPago.setDescuento(dsctoFinal);


            var isCredito = _docAplicarNotaCredito.IsDocumentoCredito;
            var montoRecibido = _gestionProcesarPago.MontoRecibido;
            var montoCambio = 0.0m;
            var BaseExenta = _gestionItem.Items.Sum(s => s.BaseExenta);
            var MontoBase = _gestionItem.Items.Sum(s => s.MontoBase);
            var MontoImpuesto = _gestionItem.Items.Sum(s => s.MontoImpuesto);
            var MontoBase1 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_1.id).Sum(s => s.MontoBase);
            var MontoBase2 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_2.id).Sum(s => s.MontoBase);
            var MontoBase3 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_3.id).Sum(s => s.MontoBase);
            var MontoImpuesto1 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_1.id).Sum(s => s.MontoImpuesto);
            var MontoImpuesto2 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_2.id).Sum(s => s.MontoImpuesto);
            var MontoImpuesto3 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_3.id).Sum(s => s.MontoImpuesto);
            var dsctoMonto = _gestionItem.Importe * dsctoFinal / 100;
            var utilidadMonto = _gestionItem.Items.Sum(s => s.Utilidad);
            var costoMonto = _gestionItem.Items.Sum(s => s.CostoVenta);
            var subTotalNeto = _gestionItem.Items.Sum(s => s.TotalNeto);
            var subTotal = _gestionItem.Importe - dsctoMonto;
            var netoMonto = _gestionItem.Items.Sum(s => s.VentaNeta);
            var netoMontoDivisa = 0m;
            if (_tasaCambioActual > 0) 
            {
                netoMontoDivisa = Math.Round(netoMonto / _tasaCambioActual, 2, MidpointRounding.AwayFromZero);
            }
            var importeDocumento = _gestionProcesarPago.MontoPagar;
            var importeDocumentoDivisa = _gestionProcesarPago.MontoPagarDivisa;
            var documento = "";
            var factorCambio = _tasaCambioActual;
            var saldoPendiente = isCredito ? importeDocumento : 0.0m;


            OOB.Documento.Agregar.NotaCredito.FichaClienteSaldo _clienteSaldo = null;
            if (_docAplicarNotaCredito.IsDocumentoCredito)
            {
                _clienteSaldo = new OOB.Documento.Agregar.NotaCredito.FichaClienteSaldo()
                {
                    AutoCliente = _docAplicarNotaCredito.AutoCliente,
                    MontoActualizar = importeDocumentoDivisa,
                };
            }
            var _serie = _serieNotaCredito;
            if (!_docAplicarNotaCredito.IsFiscal) 
            {
                _serie = _serieNotaEntrega;
            }


            var dataPagoRecolectada = _gestionProcesarPago.DataPagoRecolectar;
            var fichaOOB = new OOB.Documento.Agregar.NotaCredito.Ficha()
            {
                idOperador=Sistema.PosEnUso.id,
                DocumentoNro = documento,
                RazonSocial = _gestionCliente.Cliente.Nombre,
                DirFiscal = _gestionCliente.Cliente.DireccionFiscal,
                CiRif = _gestionCliente.Cliente.CiRif,
                Tipo = _tipoDocumentoDevVenta.codigo,
                Exento = BaseExenta,
                Base1 = MontoBase1,
                Base2 = MontoBase2,
                Base3 = MontoBase3,
                Impuesto1 = MontoImpuesto1,
                Impuesto2 = MontoImpuesto2,
                Impuesto3 = MontoImpuesto3,
                MBase = MontoBase,
                Impuesto = MontoImpuesto,
                Total = importeDocumento,
                Tasa1 = _tasaFiscal_1.tasa,
                Tasa2 = _tasaFiscal_2.tasa,
                Tasa3 = _tasaFiscal_3.tasa,
                Nota = "",
                TasaRetencionIva = 0.0m,
                TasaRetencionIslr = 0.0m,
                RetencionIva = 0.0m,
                RetencionIslr = 0.0m,
                AutoCliente = _gestionCliente.Cliente.Id,
                CodigoCliente = _gestionCliente.Cliente.Codigo,
                Control = _serie.Control,
                OrdenCompra = "",
                Dias = 0,
                Descuento1 = dsctoMonto,
                Descuento2 = 0.0m,
                Cargos = 0.0m,
                Descuento1p = dsctoFinal,
                Descuento2p = 0.0m,
                Cargosp = 0.0m,
                Columna = "1",
                EstatusAnulado = "0",
                Aplica = _docAplicarNotaCredito.DocumentoNro,
                ComprobanteRetencion = "",
                SubTotalNeto = subTotalNeto,
                Telefono = _gestionCliente.Cliente.Telefono,
                FactorCambio = factorCambio,
                CodigoVendedor =  _vendedorAsignado.codigo,
                Vendedor = _vendedorAsignado.nombre,
                AutoVendedor = _vendedorAsignado.id,
                FechaPedido = DateTime.Now.Date,
                Pedido = "",
                CondicionPago = isCredito ? "CREDITO" : "CONTADO",
                Usuario = Sistema.Usuario.nombre,
                CodigoUsuario = Sistema.Usuario.codigo,
                CodigoSucursal = _sucursalAsignada.codigo,
                Transporte = _transporteAsignado.nombre,
                CodigoTransporte = _transporteAsignado.codigo,
                MontoDivisa = importeDocumentoDivisa,
                Despachado = "",
                DirDespacho = "",
                Estacion = Sistema.EquipoEstacion,
                Renglones = _gestionItem.CantRenglones,
                SaldoPendiente = saldoPendiente,
                ComprobanteRetencionIslr = "",
                DiasValidez = 0,
                AutoUsuario = Sistema.Usuario.id,
                AutoTransporte = _transporteAsignado.id,
                Situacion = "Procesado",
                Signo = _tipoDocumentoDevVenta.signo,
                Serie = _serie.Serie,
                Tarifa = _precioManejar,
                TipoRemision = "01",
                DocumentoRemision = _docAplicarNotaCredito.DocumentoNro,
                AutoRemision = _docAplicarNotaCredito.Auto,
                DocumentoNombre = "NOTA CREDITO",
                SubTotalImpuesto = MontoImpuesto,
                SubTotal = subTotal,
                TipoCliente = "",
                Planilla = "",
                Expendiente = "",
                AnticipoIva = 0.0m,
                TercerosIva = 0.0m,
                Neto = netoMonto,
                Costo = costoMonto,
                Utilidad = utilidadMonto,
                Utilidadp = 100 - (costoMonto / netoMonto * 100),
                DocumentoTipo = _tipoDocumentoDevVenta.tipo,
                CiTitular = "",
                NombreTitular = "",
                CiBeneficiario = "",
                NombreBeneficiario = "",
                Clave = "",
                DenominacionFiscal = "No Contribuyente",
                Cambio = montoCambio,
                EstatusValidado = "0",
                Cierre = Sistema.PosEnUso.idAutoArqueoCierre,
                EstatusCierreContable = "0",
                CierreFtp = "",
                Prefijo = _sucursalAsignada.codigo + Sistema.IdEquipo,
                //
                PorctBonoPorPagoDivisa = dataPagoRecolectada.PorctBonoPorPagoDivisa,
                MontoBonoPorPagoDivisa = Math.Round(dataPagoRecolectada.MontoBonoPorPagoDivisa, 2, MidpointRounding.AwayFromZero),
                MontoBonoEnDivisaPorPagoDivisa = Math.Round(dataPagoRecolectada.MontoBonoEnDivisaPorPagoDivisa, 2, MidpointRounding.AwayFromZero),
                CantDivisaAplicaBonoPorPagoDivisa = dataPagoRecolectada.CantDivisaAplicaBonoPorPagoDivisa,
                MontoPorVueltoEnEfectivo = 0m,
                MontoPorVueltoEnDivisa = 0m,
                MontoPorVueltoEnPagoMovil = 0m,
                CantDivisaPorVueltoEnDivisa = 0,
                estatusPorBonoPorPagoDivisa = dataPagoRecolectada.estatusPorBonoPorPagoDivisa,
                estatusPorVueltoEnPagoMovil = "0",
                //
                estatusFiscal = _docAplicarNotaCredito.estatusFiscal,
            };
            fichaOOB.ClienteSaldo = _clienteSaldo;

            var detalles = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.NotaCredito.FichaDetalle()
                {
                    AutoProducto = s.Ficha.autoProducto,
                    Codigo = s.Ficha.codigo,
                    Nombre = s.Ficha.nombre,
                    AutoDepartamento = s.Ficha.autoDepartamento,
                    AutoGrupo = s.Ficha.autoGrupo,
                    AutoSubGrupo = s.Ficha.autoSubGrupo,
                    AutoDeposito = s.Ficha.autoDeposito,
                    Cantidad = s.Ficha.cantidad,
                    Empaque = s.Ficha.empaqueDescripcion,
                    PrecioNeto = s.Ficha.pneto,
                    Descuento1p = 0.0m,
                    Descuento2p = 0.0m,
                    Descuento3p = 0.0m,
                    Descuento1 = 0.0m,
                    Descuento2 = 0.0m,
                    Descuento3 = 0.0m,
                    CostoVenta = s.CostoVenta,
                    TotalNeto = s.TotalNeto,
                    Tasa = s.Ficha.tasaIva,
                    Impuesto = s.Impuesto,
                    Total = s.Total,
                    EstatusAnulado = "0",
                    Tipo = _tipoDocumentoDevVenta.codigo,
                    Deposito = _depositoAsignado.nombre,
                    Signo = _tipoDocumentoDevVenta.signo,
                    PrecioFinal = s.PrecioFinal,
                    AutoCliente = _gestionCliente.Cliente.Id,
                    Decimales = s.Ficha.decimales,
                    ContenidoEmpaque = s.Ficha.empaqueContenido,
                    CantidadUnd = s.TotalUnd,
                    PrecioUnd = s.PrecioUnd,
                    CostoUnd = s.Ficha.costoUnd,
                    Utilidad = s.Utilidad,
                    Utilidadp = s.UtilidadP,
                    PrecioItem = s.PrecioItem,
                    EstatusGarantia = "0",
                    EstatusSerial = "0",
                    CodigoDeposito = _depositoAsignado.codigo,
                    DiasGarantia = 0,
                    Detalle = "",
                    PrecioSugerido = 0.0m,
                    AutoTasa = s.Ficha.autoTasa,
                    EstatusCorte = "0",
                    X = 1,
                    Y = 1,
                    Z = 1,
                    Corte = "",
                    Categoria = s.Ficha.categoria,
                    Cobranzap = 0.0m,
                    Ventasp = 0.0m,
                    CobranzapVendedor = 0.0m,
                    VentaspVendedor = 0.0m,
                    Cobranza = 0.0m,
                    Ventas = 0.0m,
                    CobranzaVendedor = 0.0m,
                    VentasVendedor = 0.0m,
                    CostoPromedioUnd = s.Ficha.costoPromedioUnd,
                    CostoCompra = s.Ficha.costoCompra,
                    EstatusChecked = "1",
                    Tarifa = _precioManejar,
                    TotalDescuento = 0.0m,
                    CodigoVendedor = _vendedorAsignado.codigo,
                    AutoVendedor = _vendedorAsignado.id,
                    CierreFtp = "",
                };
                return nr;
            }).ToList();
            fichaOOB.Detalles = detalles;

            var actDeposito = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.NotaCredito.FichaDeposito()
                {
                    AutoDeposito = s.Ficha.autoDeposito,
                    AutoProducto = s.Ficha.autoProducto,
                    CantUnd = s.TotalUnd,
                };
                return nr;
            }).ToList();
            fichaOOB.ActDeposito = actDeposito;

            var kardex = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.NotaCredito.FichaKardex()
                {
                    AutoProducto = s.Ficha.autoProducto,
                    Total = s.TotalUnd * s.Ficha.costoUnd,
                    AutoDeposito = s.Ficha.autoDeposito,
                    AutoConcepto = _conceptoDevVenta.id,
                    Modulo = "Ventas",
                    Entidad = _gestionCliente.Cliente.Nombre,
                    Signo = 1,
                    Cantidad = s.Cantidad,
                    CantidadBono = 0.0m,
                    CantidadUnd = s.TotalUnd,
                    CostoUnd = s.Ficha.costoUnd,
                    EstatusAnulado = "0",
                    Nota = "",
                    PrecioUnd = s.PrecioFinalUnd,
                    Codigo = _tipoDocumentoDevVenta.codigo,
                    Siglas = _tipoDocumentoDevVenta.siglas,
                    CierreFtp = "",
                    CodigoSucursal = _sucursalAsignada.codigo,
                    CodigoDeposito = _depositoAsignado.codigo,
                    NombreDeposito = _depositoAsignado.nombre,
                    CodigoConcepto = _conceptoDevVenta.codigo,
                    NombreConcepto = _conceptoDevVenta.nombre,
                    FactorCambio = factorCambio,
                };
                return nr;
            }).ToList();
            fichaOOB.MovKardex = kardex;

            fichaOOB.DocCxC = new OOB.Documento.Agregar.NotaCredito.FichaCxC()
            {
                CCobranza = 0.0m,
                CCobranzap = 0.0m,
                TipoDocumento = _tipoDocumentoDevVenta.siglas,
                Nota = "",
                Importe = importeDocumento,
                Acumulado = isCredito ? 0.0m : importeDocumento,
                AutoCliente = _gestionCliente.Cliente.Id,
                Cliente = _gestionCliente.Cliente.Nombre,
                CiRif = _gestionCliente.Cliente.CiRif,
                CodigoCliente = _gestionCliente.Cliente.Codigo,
                EstatusCancelado = isCredito ? "0" : "1",
                Resta = isCredito ? importeDocumento : 0.0m,
                EstatusAnulado = "0",
                Numero = "",
                AutoAgencia = "0000000001",
                Agencia = "",
                Signo = _tipoDocumentoDevVenta.signo,
                AutoVendedor = _vendedorAsignado.id,
                CDepartamento = 0.0m,
                CVentas = 0.0m,
                CVentasp = 0.0m,
                Serie = _serie.Serie,
                ImporteNeto = netoMonto,
                Dias = 0,
                CastigoP = 0.0m,
                CierreFtp = "",
                MontoDivisa = importeDocumentoDivisa,
                TasaDivisa = factorCambio,
                //
                AcumuladoDivisa = isCredito ? 0.0m : importeDocumentoDivisa,
                CodigoSucursal = _sucursalAsignada.codigo,
                RestaDivisa = isCredito ? importeDocumentoDivisa : 0.0m,
                ImporteNetoDivisa = Math.Round(netoMontoDivisa, 2, MidpointRounding.AwayFromZero),
            };


            var PMontoEfectivo = 0.0m;
            var PMontoDivisa = 0.0m;
            var PMontoElectronico = 0.0m;
            var PMontoOtro = 0.0m;
            var CntEfectivo = 0;
            var CntDivisa = 0;
            var CntElectronico = 0;
            var CntOtro = 0;


            if (!isCredito)
            {
                fichaOOB.DocCxCPago = new OOB.Documento.Agregar.NotaCredito.FichaCxCPago();
                var p = new OOB.Documento.Agregar.NotaCredito.FichaCxC()
                {
                    CCobranza = 0.0m,
                    CCobranzap = 0.0m,
                    TipoDocumento = "PAG",
                    Nota = "",
                    Importe = importeDocumento,
                    Acumulado = 0.0m,
                    AutoCliente = _gestionCliente.Cliente.Id,
                    Cliente = _gestionCliente.Cliente.Nombre,
                    CiRif = _gestionCliente.Cliente.CiRif,
                    CodigoCliente = _gestionCliente.Cliente.Codigo,
                    EstatusCancelado = "0",
                    Resta = 0.0m,
                    EstatusAnulado = "0",
                    Numero = "",
                    AutoAgencia = "0000000001",
                    Agencia = "",
                    Signo = (_tipoDocumentoDevVenta.signo) * -1,
                    AutoVendedor = _vendedorAsignado.id,
                    CDepartamento = 0.0m,
                    CVentas = 0.0m,
                    CVentasp = 0.0m,
                    Serie = "",
                    ImporteNeto = 0.0m,
                    Dias = 0,
                    CastigoP = 0.0m,
                    CierreFtp = "",
                    MontoDivisa = importeDocumentoDivisa,
                    TasaDivisa = factorCambio,
                    //
                    AcumuladoDivisa = 0m,
                    CodigoSucursal = _sucursalAsignada.codigo,
                    RestaDivisa = 0m,
                    ImporteNetoDivisa = 0m,
                };
                var _montoRecibidoDivisa = 0m;
                var _cambioDivisa = 0m;
                if (factorCambio > 0)
                {
                    _montoRecibidoDivisa = Math.Round(montoRecibido / factorCambio, 2, MidpointRounding.AwayFromZero);
                    _cambioDivisa = Math.Round(montoCambio / factorCambio, 2, MidpointRounding.AwayFromZero);
                }
                var pR = new OOB.Documento.Agregar.NotaCredito.FichaCxCRecibo()
                {
                    AutoUsuario = Sistema.Usuario.id,
                    Importe = (-1) * importeDocumento,
                    Usuario = Sistema.Usuario.nombre,
                    MontoRecibido = (-1) * montoRecibido,
                    Cobrador = _cobradorAsignado.nombre,
                    AutoCliente = _gestionCliente.Cliente.Id,
                    Cliente = _gestionCliente.Cliente.Nombre,
                    CiRif = _gestionCliente.Cliente.CiRif,
                    Codigo = _gestionCliente.Cliente.Codigo,
                    EstatusAnulado = "0",
                    Direccion = _gestionCliente.Cliente.DireccionFiscal,
                    Telefono = _gestionCliente.Cliente.Telefono,
                    AutoCobrador = _cobradorAsignado.id,
                    Anticipos = 0.0m,
                    Cambio = montoCambio,
                    Nota = "",
                    CodigoCobrador = _cobradorAsignado.codigo,
                    Retenciones = 0.0m,
                    Descuentos = 0.0m,
                    Cierre = Sistema.PosEnUso.idAutoArqueoCierre,
                    CierreFtp = "",
                    //
                    ImporteDivisa = (-1) * importeDocumentoDivisa,
                    MontoRecibidoDivisa = (-1) * _montoRecibidoDivisa,
                    CambioDivisa = _cambioDivisa,
                    CodigoSucursal = _sucursalAsignada.codigo,
                };
                var pD = new OOB.Documento.Agregar.NotaCredito.FichaCxCDocumento()
                {
                    Id = 1,
                    TipoDocumento = "NCR",
                    Operacion = "Pago",
                    Importe = importeDocumento,
                    Dias = 0,
                    CastigoP = 0.0m,
                    ComisionP = 0.0m,
                    CierreFtp = "",
                    //
                    ImporteDivisa = importeDocumentoDivisa,
                    CodigoSucursal = _sucursalAsignada.codigo,
                    Notas = "",
                };

                var pM = new List<OOB.Documento.Agregar.NotaCredito.FichaCxCMetodoPago>();
                foreach (var it in _gestionProcesarPago.PagoDetalles.Where(w => w.Monto > 0m).ToList())
                {
                    var autoMedioPago = "";
                    var codigoMedioPago = "";
                    var descMedioPago = "";
                    var lote = "";
                    var referencia = "";
                    var montoRecibe = (-1) * it.MontoRecibido;
                    var _montoRecibeDivisa = 0m;
                    var _aplicaFactorConversion = "";

                    switch (it.Modo)
                    {
                        case Pago.Procesar.Enumerados.ModoPago.Efectivo:
                            autoMedioPago = _medioPagoEfectivo.id;
                            codigoMedioPago = _medioPagoEfectivo.codigo;
                            descMedioPago = _medioPagoEfectivo.nombre;
                            PMontoEfectivo += montoRecibe;
                            CntEfectivo += 1;
                            //
                            if (factorCambio > 0)
                            {
                                _montoRecibeDivisa = Math.Round(montoRecibe / factorCambio, 4, MidpointRounding.AwayFromZero);
                            }
                            _aplicaFactorConversion = "1";
                            break;

                        case Pago.Procesar.Enumerados.ModoPago.Divisa:
                            montoRecibe = (-1) * it.Monto;
                            autoMedioPago = _medioPagoDivisa.id;
                            codigoMedioPago = _medioPagoDivisa.codigo;
                            descMedioPago = _medioPagoDivisa.nombre;
                            lote = ((-1) * it.Cantidad).ToString();
                            referencia = TasaCambioActual.ToString("n2").Replace(".", "");
                            PMontoDivisa += montoRecibe;
                            CntDivisa = (int)it.Cantidad;
                            //
                            if (factorCambio > 0)
                            {
                                _montoRecibeDivisa = (-1) * it.Cantidad;
                            }
                            _aplicaFactorConversion = "1";
                            break;

                        case Pago.Procesar.Enumerados.ModoPago.Electronico:
                            if (it.Id != 4) //DEBITO
                            {
                                autoMedioPago = _medioPagoElectronico.id;
                                codigoMedioPago = _medioPagoElectronico.codigo;
                                descMedioPago = _medioPagoElectronico.nombre;
                                lote = it.Lote;
                                referencia = it.Referencia;
                                PMontoElectronico += montoRecibe;
                                CntElectronico += 1;
                                //
                                if (factorCambio > 0)
                                {
                                    _montoRecibeDivisa = Math.Round(montoRecibe / factorCambio, 4, MidpointRounding.AwayFromZero);
                                }
                                _aplicaFactorConversion = "1";
                            }
                            else //OTROS
                            {
                                autoMedioPago = _medioPagoOtro.id;
                                codigoMedioPago = _medioPagoOtro.codigo;
                                descMedioPago = _medioPagoOtro.nombre;
                                lote = it.Lote;
                                referencia = it.Referencia;
                                PMontoOtro += montoRecibe;
                                CntOtro += 1;
                                //
                                if (factorCambio > 0)
                                {
                                    _montoRecibeDivisa = Math.Round(montoRecibe / factorCambio, 4, MidpointRounding.AwayFromZero);
                                }
                                _aplicaFactorConversion = "1";
                            }
                            break;
                    }

                    pM.Add(new OOB.Documento.Agregar.NotaCredito.FichaCxCMetodoPago()
                    {
                        AutoMedioPago = autoMedioPago,
                        AutoAgencia = "",
                        Medio = descMedioPago,
                        Codigo = codigoMedioPago,
                        MontoRecibido = montoRecibe,
                        EstatusAnulado = "0",
                        Numero = "",
                        Agencia = "",
                        AutoUsuario = Sistema.Usuario.id,
                        Lote = lote,
                        Referencia = referencia,
                        AutoCobrador = _cobradorAsignado.id,
                        Cierre = Sistema.PosEnUso.idAutoArqueoCierre,
                        CierreFtp = "",
                        //
                        OpBanco = "",
                        OpNroCta = "",
                        OpNroRef = "",
                        OpFecha = DateTime.Now.Date,
                        OpDetalle = "",
                        OpMonto = _montoRecibeDivisa,
                        OpTasa = factorCambio,
                        OpAplicaConversion = _aplicaFactorConversion,
                        CodigoSucursal = _sucursalAsignada.codigo,
                    });
                }
                fichaOOB.DocCxCPago.Pago = p;
                fichaOOB.DocCxCPago.Recibo = pR;
                fichaOOB.DocCxCPago.Documento = pD;
                fichaOOB.DocCxCPago.MetodoPago = pM;
            }
            else 
            {
                fichaOOB.DocCxCPago = null;
            }

            fichaOOB.Resumen = new OOB.Documento.Agregar.NotaCredito.FichaPosResumen()
            {
                cntDoc = 1,
                cntDevolucion = 1,
                cntFac = 0,
                cntNCr = 1,
                idResumen = Sistema.PosEnUso.idResumen,
                mDevolucion = importeDocumento,
                mFac = 0.0m,
                mNCr = importeDocumento,
                cntEfectivo = CntEfectivo,
                cntDivisa = CntDivisa,
                cntElectronico = CntElectronico,
                cntotros = CntOtro,
                mEfectivo = Math.Abs(PMontoEfectivo),
                mDivisa = Math.Abs(PMontoDivisa),
                mElectronico = Math.Abs(PMontoElectronico),
                mOtros = Math.Abs(PMontoOtro),
                cntDocContado = 0,
                cntDocCredito = 0,
                mContado = 0,
                mCredito = 0,
                //
                cntAnu = 0,
                cntNte = 0,
                mAnu = 0.0m,
                mNte = 0.0m,
            };
            fichaOOB.SerieFiscal = new OOB.Documento.Agregar.NotaCredito.FichaSerie() { auto = _serie.Auto };

            if (_docAplicarNotaCredito.IsFiscal)
            {
                if (Sistema.ImprimirNotaCredito.IsModoFiscal)
                {
                    var f01 = Sistema.FiscalTfhka.Informacion();
                    if (f01.Resultado == LibFoxFiscal.Resultado.EnumResultado.ERROR)
                    {
                        Helpers.Msg.Error(f01.MensajeError);
                        return;
                    }
                    fichaOOB.SerieFiscal = null;
                    fichaOOB.DocumentoNro = (f01.Entidad.UltimaNCreditoGenerada + 1).ToString().Trim().PadLeft(10, '0');
                    fichaOOB.Control = f01.Entidad.Serial;
                    fichaOOB.zFiscal = f01.Entidad.UltimoZGenerado + 1;
                }
            }

            var r01 = Sistema.MyData.Documento_Agregar_NotaCredito(fichaOOB);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var xdata = CargarDataDocumento(r01.Auto);
            if (xdata != null)
            {
                Sistema.ImprimirNotaCredito.setData(xdata);
                if (_docAplicarNotaCredito.IsFiscal)
                {
                    Sistema.ImprimirNotaCredito.ImprimirDoc();
                }
                else
                {
                    _isTickeraOk = true;
                    _ImprimirDoc = Sistema.ImprimirNotaCreditoNoFiscal;
                    printDocument2.Print();
                }
                //Sistema.ImprimirNotaCredito.setData(xdata);
                //if (Sistema.ImprimirNotaCredito.IsModoTicket)
                //{
                //    _isTickeraOk = true;
                //    _ImprimirDoc = Sistema.ImprimirNotaCredito;
                //    printDocument2.Print();
                //}
                //else
                //{
                //    Sistema.ImprimirNotaCredito.ImprimirDoc();
                //}
            }
            _gestionItem.Limpiar();
            _gestionCliente.Limpiar();
            Inicializa();
            Reiniciar();
        }

        public void NotaEntrega()
        {
            if (!IsNotaCredito)
            {
                if (PassWIsOk(Sistema.FuncionPosElaborarNotaEntrega))
                {
                    if (_modoFuncion == EnumModoFuncion.Facturacion)
                    {
                        _modoFuncion = EnumModoFuncion.NotaEntrega;
                    }
                    else
                    {
                        _modoFuncion = EnumModoFuncion.Facturacion;
                    }
                }
            }
        }


        /// <summary>
        /// NOTA DE NETREGA
        /// </summary>
        private void ProcesarNotaEntrega()
        {
            _ImprimirDoc = null;
            _isTickeraOk = false;

            var dsctoFinal = 0.0m;
            _gestionItem.setDescuentoFinal(dsctoFinal);
            _gestionProcesarPago.setDescuento(dsctoFinal);

            var isCredito = false; ;
            // var montoRecibido = 0.0m;
            var montoCambio = 0.0m; ;
            var BaseExenta = _gestionItem.Items.Sum(s => s.BaseExenta);
            var MontoBase = _gestionItem.Items.Sum(s => s.MontoBase);
            var MontoImpuesto = _gestionItem.Items.Sum(s => s.MontoImpuesto);
            var MontoBase1 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_1.id).Sum(s => s.MontoBase);
            var MontoBase2 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_2.id).Sum(s => s.MontoBase);
            var MontoBase3 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_3.id).Sum(s => s.MontoBase);
            var MontoImpuesto1 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_1.id).Sum(s => s.MontoImpuesto);
            var MontoImpuesto2 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_2.id).Sum(s => s.MontoImpuesto);
            var MontoImpuesto3 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_3.id).Sum(s => s.MontoImpuesto);
            var dsctoMonto = _gestionItem.Importe * dsctoFinal / 100;
            var utilidadMonto = _gestionItem.Items.Sum(s => s.Utilidad);
            var costoMonto = _gestionItem.Items.Sum(s => s.CostoVenta);
            var subTotalNeto = _gestionItem.Items.Sum(s => s.TotalNeto);
            var subTotal = _gestionItem.Importe - dsctoMonto;
            var netoMonto = _gestionItem.Items.Sum(s => s.VentaNeta);

            var importeDocumento = _gestionProcesarPago.MontoPagar;
            var importeDocumentoDivisa = _gestionProcesarPago.MontoPagarDivisa;
            var documento = "";
            var factorCambio = _tasaCambioActual;
            var saldoPendiente = isCredito ? importeDocumento : 0.0m;

            var fichaOOB = new OOB.Documento.Agregar.NotaEntrega.Ficha()
            {
                idOperador = Sistema.PosEnUso.id,
                DocumentoNro = documento,
                RazonSocial = _gestionCliente.Cliente.Nombre,
                DirFiscal = _gestionCliente.Cliente.DireccionFiscal,
                CiRif = _gestionCliente.Cliente.CiRif,
                Tipo = _tipoDocumentoNotaEntrega.codigo,
                Exento = BaseExenta,
                Base1 = MontoBase1,
                Base2 = MontoBase2,
                Base3 = MontoBase3,
                Impuesto1 = MontoImpuesto1,
                Impuesto2 = MontoImpuesto2,
                Impuesto3 = MontoImpuesto3,
                MBase = MontoBase,
                Impuesto = MontoImpuesto,
                Total = importeDocumento,
                Tasa1 = _tasaFiscal_1.tasa,
                Tasa2 = _tasaFiscal_2.tasa,
                Tasa3 = _tasaFiscal_3.tasa,
                Nota = "",
                TasaRetencionIva = 0.0m,
                TasaRetencionIslr = 0.0m,
                RetencionIva = 0.0m,
                RetencionIslr = 0.0m,
                AutoCliente = _gestionCliente.Cliente.Id,
                CodigoCliente = _gestionCliente.Cliente.Codigo,
                Control = _serieNotaEntrega.Control,
                OrdenCompra = "",
                Dias = 0,
                Descuento1 = dsctoMonto,
                Descuento2 = 0.0m,
                Cargos = 0.0m,
                Descuento1p = dsctoFinal,
                Descuento2p = 0.0m,
                Cargosp = 0.0m,
                Columna = "1",
                EstatusAnulado = "0",
                Aplica = "",
                ComprobanteRetencion = "",
                SubTotalNeto = subTotalNeto,
                Telefono = _gestionCliente.Cliente.Telefono,
                FactorCambio = factorCambio,
                CodigoVendedor = _vendedorAsignado.codigo,
                Vendedor = _vendedorAsignado.nombre,
                AutoVendedor = _vendedorAsignado.id,
                FechaPedido = DateTime.Now.Date,
                Pedido = "",
                CondicionPago = isCredito ? "CREDITO" : "CONTADO",
                Usuario = Sistema.Usuario.nombre,
                CodigoUsuario = Sistema.Usuario.codigo,
                CodigoSucursal = _sucursalAsignada.codigo,
                Transporte = _transporteAsignado.nombre,
                CodigoTransporte = _transporteAsignado.codigo,
                MontoDivisa = importeDocumentoDivisa,
                Despachado = "",
                DirDespacho = "",
                Estacion = Sistema.EquipoEstacion,
                Renglones = _gestionItem.CantRenglones,
                SaldoPendiente = saldoPendiente,
                ComprobanteRetencionIslr = "",
                DiasValidez = 0,
                AutoUsuario = Sistema.Usuario.id,
                AutoTransporte = _transporteAsignado.id,
                Situacion = "Procesado",
                Signo = _tipoDocumentoNotaEntrega.signo,
                Serie = _serieNotaEntrega.Serie,
                Tarifa = _precioManejar,
                TipoRemision = "",
                DocumentoRemision = "",
                AutoRemision = "",
                DocumentoNombre = "NOTA ENTREGA",
                SubTotalImpuesto = MontoImpuesto,
                SubTotal = subTotal,
                TipoCliente = "",
                Planilla = "",
                Expendiente = "",
                AnticipoIva = 0.0m,
                TercerosIva = 0.0m,
                Neto = netoMonto,
                Costo = costoMonto,
                Utilidad = utilidadMonto,
                Utilidadp = 100 - (costoMonto / netoMonto * 100),
                DocumentoTipo = _tipoDocumentoNotaEntrega.tipo,
                CiTitular = "",
                NombreTitular = "",
                CiBeneficiario = "",
                NombreBeneficiario = "",
                Clave = "",
                DenominacionFiscal = "No Contribuyente",
                Cambio = montoCambio,
                EstatusValidado = "0",
                Cierre = Sistema.PosEnUso.idAutoArqueoCierre,
                EstatusCierreContable = "0",
                CierreFtp = "",
                Prefijo = _sucursalAsignada.codigo + Sistema.IdEquipo,
            };

            var detalles = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.NotaEntrega.FichaDetalle()
                {
                    AutoProducto = s.Ficha.autoProducto,
                    Codigo = s.Ficha.codigo,
                    Nombre = s.Ficha.nombre,
                    AutoDepartamento = s.Ficha.autoDepartamento,
                    AutoGrupo = s.Ficha.autoGrupo,
                    AutoSubGrupo = s.Ficha.autoSubGrupo,
                    AutoDeposito = s.Ficha.autoDeposito,
                    Cantidad = s.Ficha.cantidad,
                    Empaque = s.Ficha.empaqueDescripcion,
                    PrecioNeto = s.Ficha.pneto,
                    Descuento1p = 0.0m,
                    Descuento2p = 0.0m,
                    Descuento3p = 0.0m,
                    Descuento1 = 0.0m,
                    Descuento2 = 0.0m,
                    Descuento3 = 0.0m,
                    CostoVenta = s.CostoVenta,
                    TotalNeto = s.TotalNeto,
                    Tasa = s.Ficha.tasaIva,
                    Impuesto = s.Impuesto,
                    Total = s.Total,
                    EstatusAnulado = "0",
                    Tipo = _tipoDocumentoNotaEntrega.codigo,
                    Deposito = _depositoAsignado.nombre,
                    Signo = _tipoDocumentoNotaEntrega.signo,
                    PrecioFinal = s.PrecioFinal,
                    AutoCliente = _gestionCliente.Cliente.Id,
                    Decimales = s.Ficha.decimales,
                    ContenidoEmpaque = s.Ficha.empaqueContenido,
                    CantidadUnd = s.TotalUnd,
                    PrecioUnd = s.PrecioUnd,
                    CostoUnd = s.Ficha.costoUnd,
                    Utilidad = s.Utilidad,
                    Utilidadp = s.UtilidadP,
                    PrecioItem = s.PrecioItem,
                    EstatusGarantia = "0",
                    EstatusSerial = "0",
                    CodigoDeposito = _depositoAsignado.codigo,
                    DiasGarantia = 0,
                    Detalle = "",
                    PrecioSugerido = 0.0m,
                    AutoTasa = s.Ficha.autoTasa,
                    EstatusCorte = "0",
                    X = 1,
                    Y = 1,
                    Z = 1,
                    Corte = "",
                    Categoria = s.Ficha.categoria,
                    Cobranzap = 0.0m,
                    Ventasp = 0.0m,
                    CobranzapVendedor = 0.0m,
                    VentaspVendedor = 0.0m,
                    Cobranza = 0.0m,
                    Ventas = 0.0m,
                    CobranzaVendedor = 0.0m,
                    VentasVendedor = 0.0m,
                    CostoPromedioUnd = s.Ficha.costoPromedioUnd,
                    CostoCompra = s.Ficha.costoCompra,
                    EstatusChecked = "1",
                    Tarifa = _precioManejar,
                    TotalDescuento = 0.0m,
                    CodigoVendedor = _vendedorAsignado.codigo,
                    AutoVendedor = _vendedorAsignado.id,
                    CierreFtp = "",
                };
                return nr;
            }).ToList();
            fichaOOB.Detalles = detalles;

            var actDeposito = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.NotaEntrega.FichaDeposito()
                {
                    AutoDeposito = s.Ficha.autoDeposito,
                    AutoProducto = s.Ficha.autoProducto,
                    CantUnd = s.TotalUnd,
                };
                return nr;
            }).ToList();
            fichaOOB.ActDeposito = actDeposito;

            var kardex = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.NotaEntrega.FichaKardex()
                {
                    AutoProducto = s.Ficha.autoProducto,
                    Total = s.TotalUnd * s.Ficha.costoUnd,
                    AutoDeposito = s.Ficha.autoDeposito,
                    AutoConcepto = _conceptoSalida.id,
                    Modulo = "Ventas",
                    Entidad = _gestionCliente.Cliente.Nombre,
                    Signo = -1,
                    Cantidad = s.Cantidad,
                    CantidadBono = 0.0m,
                    CantidadUnd = s.TotalUnd,
                    CostoUnd = s.Ficha.costoPromedioUnd,
                    EstatusAnulado = "0",
                    Nota = "",
                    PrecioUnd = s.PrecioFinal,
                    Codigo = _tipoDocumentoNotaEntrega.codigo,
                    Siglas = _tipoDocumentoNotaEntrega.siglas,
                    CierreFtp = "",
                    CodigoSucursal = _sucursalAsignada.codigo,
                    CodigoDeposito = _depositoAsignado.codigo,
                    NombreDeposito = _depositoAsignado.nombre,
                    CodigoConcepto = _conceptoSalida.codigo,
                    NombreConcepto = _conceptoSalida.nombre,
                };
                return nr;
            }).ToList();
            fichaOOB.MovKardex = kardex;

            fichaOOB.PosVenta = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.NotaEntrega.FichaPosVenta()
                {
                    id = s.Ficha.id,
                    idOperador = s.Ficha.idOperador,
                };
                return nr;
            }).ToList();

            var PMontoEfectivo = 0.0m;
            var PMontoDivisa = 0.0m;
            var PMontoElectronico = 0.0m;
            var PMontoOtro = 0.0m;
            var CntEfectivo = 0;
            var CntDivisa = 0;
            var CntElectronico = 0;
            var CntOtro = 0;

            fichaOOB.Resumen = new OOB.Documento.Agregar.NotaEntrega.FichaPosResumen()
            {
                cntDoc = 1,
                cntDevolucion = 0,
                cntFac = 0,
                cntNCr = 0,
                idResumen = Sistema.PosEnUso.idResumen,
                mDevolucion = 0.0m,
                mFac = 0.0m,
                mNCr = 0.0m,
                cntEfectivo = CntEfectivo,
                cntDivisa = CntDivisa,
                cntElectronico = CntElectronico,
                cntotros = CntOtro,
                mEfectivo = PMontoEfectivo,
                mDivisa = PMontoDivisa,
                mElectronico = PMontoElectronico,
                mOtros = PMontoOtro,
                cntDocContado = 0,
                cntDocCredito = 0,
                mContado = 0,
                mCredito = 0,
                //
                cntAnu = 0,
                cntNte = 1,
                mAnu = 0.0m,
                mNte = importeDocumento,
            };
            fichaOOB.SerieFiscal = new OOB.Documento.Agregar.NotaEntrega.FichaSerie() { auto = _serieNotaEntrega.Auto };

            var r01 = Sistema.MyData.Documento_Agregar_NotaEntrega(fichaOOB);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var xdata = CargarDataDocumento(r01.Auto);
            if (xdata != null)
            {
                Sistema.ImprimirNotaEntrega.setData(xdata);
                if (Sistema.ImprimirNotaEntrega.IsModoTicket)
                {
                    _isTickeraOk = true;
                    _ImprimirDoc = Sistema.ImprimirNotaEntrega;
                    printDocument2.Print();
                }
                else
                {
                    Sistema.ImprimirNotaEntrega.ImprimirDoc();
                }
            }
            _gestionItem.Limpiar();
            _gestionCliente.Limpiar();
            Inicializa();
            Reiniciar();
        }

        private Helpers.Imprimir.data CargarDataDocumento(string idDoc)
        {
            var xr1 = Sistema.MyData.Documento_GetById(idDoc);
            if (xr1.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(xr1.Mensaje);
                return null;
            }

            var xr2 = Sistema.MyData.Documento_Get_MetodosPago_ByIdRecibo(xr1.Entidad.AutoReciboCxC);
            if (xr2.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(xr2.Mensaje);
                return null;
            }

            var xdata = new Helpers.Imprimir.data();
            xdata.isAnulado = xr1.Entidad.EstatusAnulado == "1";
            xdata.negocio = new Helpers.Imprimir.data.Negocio()
            {
                Nombre = Sistema.DatosEmpresa.Nombre,
                CiRif = Sistema.DatosEmpresa.CiRif,
                Direccion = Sistema.DatosEmpresa.Direccion,
                Telefonos = Sistema.DatosEmpresa.Telefono,
            };
            var docNombre = "";
            switch (xr1.Entidad.Tipo.Trim().ToUpper())
            {
                case "01":
                    docNombre = "FACTURA";
                    break;
                case "02":
                    docNombre = "NOTA DE DEBITO";
                    break;
                case "03":
                    docNombre = "NOTA DE CREDITO";
                    break;
                case "04":
                    docNombre = "NOTA DE ENTREGA";
                    break;
            }
            xdata.encabezado = new Helpers.Imprimir.data.Encabezado()
            {
                CiRifCli = xr1.Entidad.CiRif,
                DireccionCli = xr1.Entidad.DirFiscal,
                DocumentoCondicionPago = xr1.Entidad.CondicionPago,
                DocumentoControl = xr1.Entidad.Control,
                DocumentoDiasCredito = xr1.Entidad.Dias,
                DocumentoFecha = xr1.Entidad.Fecha,
                DocumentoFechaVencimiento = xr1.Entidad.FechaVencimiento,
                DocumentoNombre = docNombre,
                DocumentoNro = xr1.Entidad.DocumentoNro,
                DocumentoSerie = xr1.Entidad.Serie,
                DocumentoAplica = xr1.Entidad.Aplica,
                NombreCli = xr1.Entidad.RazonSocial,
                FactorCambio = xr1.Entidad.FactorCambio,
                SubTotal = xr1.Entidad.SubTotal,
                Descuento = xr1.Entidad.Descuento,
                Total = xr1.Entidad.Total,
                TotalDivisa = xr1.Entidad.MontoDivisa,
                EstacionEquipo = xr1.Entidad.Estacion,
                Usuario = xr1.Entidad.Usuario,
                CambioDar = xr1.Entidad.Cambio,
                DocumentoHora = xr1.Entidad.Hora,
                TelefonoCli = xr1.Entidad.Telefono,
                CodigoCli = xr1.Entidad.CodigoCliente,
                DescuentoPorc = xr1.Entidad.Descuento1p,
                Cargo = xr1.Entidad.Cargos,
                CargoPorc = xr1.Entidad.Cargosp,
                VueltoEfectivo = xr1.Entidad.MontoPorVueltoEnEfectivo,
                VueltoDivisa = xr1.Entidad.MontoPorVueltoEnDivisa,
                VueltoPagoMovil = xr1.Entidad.MontoPorVueltoEnPagoMovil,
                CntDivisaVueltoDivisa = xr1.Entidad.CantDivisaPorVueltoEnDivisa,
                //
                BonoPorPagoDivisa = xr1.Entidad.BonoPorPagoDivisa,
                MontoBonoPorPagoDivisa = xr1.Entidad.MontoBonoPorPagoDivisa,
                CntDivisaAplicaBonoPorPagoDivisa = xr1.Entidad.CntDivisaAplicaBonoPorPagoDivisa,
                //
                DocumentoAplica_Fecha = xr1.Entidad.Fecha,
                DocumentoAplica_SerialFiscal = xr1.Entidad.Control,
            };
            xdata.item = new List<Helpers.Imprimir.data.Item>();
            foreach (var rg in xr1.Entidad.items)
            {
                var nr = new Helpers.Imprimir.data.Item()
                {
                    NombrePrd = rg.Nombre,
                    CodigoPrd = rg.Codigo,
                    Cantidad = rg.Cantidad,
                    Contenido = rg.ContenidoEmpaque,
                    DepositoCodigo = rg.CodigoDeposito,
                    DepositoDesc = rg.Deposito,
                    Empaque = rg.Empaque,
                    Importe = rg.TotalNeto,
                    ImporteDivisa = rg.TotalNeto,
                    Precio = rg.PrecioItem,
                    PrecioDivisa = rg.PrecioItem,
                    TotalUnd = rg.CantidadUnd,
                    TasaIva = rg.Tasa,
                    ImporteFull = rg.Total,
                };
                xdata.item.Add(nr);
            }

            xdata.metodoPago = new List<Helpers.Imprimir.data.MetodoPago>();
            foreach (var mp in xr2.ListaD)
            {
                if (Math.Abs(mp.cntDivisa) >= 1)
                {
                    var pag = new Helpers.Imprimir.data.MetodoPago() { descripcion = "Efectivo("+Sistema.SimboloDivisa_AlImprimirTicket + mp.cntDivisa.ToString() + ")", monto = mp.montoRecibido };
                    xdata.metodoPago.Add(pag);
                }
                else
                {
                    var pag = new Helpers.Imprimir.data.MetodoPago() { descripcion = mp.descMedioPago, monto = mp.montoRecibido };
                    xdata.metodoPago.Add(pag);
                }
            }
            xdata.medidaEmp = xr1.Entidad.medidas.Select(s =>
            {
                var med = new Helpers.Imprimir.data.MedidaEmp()
                {
                    cant = s.cant,
                    desc = s.desc,
                    peso = s.peso,
                    volumen = s.volumen,
                };
                return med;
            }).ToList();

            return xdata;
        }

        public void Imprimir(System.Drawing.Printing.PrintPageEventArgs e)
        {
            _isTickeraOk = false;
            if (_ImprimirDoc != null)
            {
                _ImprimirDoc.setControlador(e);
                _ImprimirDoc.setEmpresa(Sistema.DatosEmpresa);
                _ImprimirDoc.ImprimirDoc();
            }
            _ImprimirDoc = null;
        }

        public void CambiarPrecio()
        {
            _gSolicitarPermiso.Inicializa();
            _gSolicitarPermiso.Inicia();
            if (!_gSolicitarPermiso.IsOk)
            {
                return;
            }
            var _usu = _gSolicitarPermiso.GetUsuario;
            var _psw = _gSolicitarPermiso.GetPassword;
            if (Helpers.VerificarPermiso.Verificar(_usu, _psw))
            {
                _gCambioPrecio.Inicializa();
                if (_gestionItem.DataItemActual != null)
                {
                    if (_modoFuncion != EnumModoFuncion.NotaCredito)
                    {
                        _gCambioPrecio.setDataItem(_gestionItem.DataItemActual);
                        _gCambioPrecio.Inicia();
                        if (_gCambioPrecio.CambioPrecioIsOk)
                        {
                            _gestionItem.DataItemActual.setPrecio(_gCambioPrecio.PrecioNuevo);
                        }
                    }
                }
            }
        }


        //
        public object Item { get { return _gestionItem.Item; } }


        public void Multiplicar()
        {
            if (!IsNotaCredito)
            {
                if (PassWIsOk(Sistema.FuncionPosTeclaMultiplicar))
                {
                    //_gestionItem.Multiplicar();
                    if (Item != null)
                    {
                        var it = (Item.data)Item;
                        if (it.EsPesado)
                        {
                            return;
                        }
                        _gMultiplicar.Inicializa();
                        _gMultiplicar.Inicia();
                        if (_gMultiplicar.MultiplicarIsOk)
                        {
                            _gestionItem.SetCantIncrementar(it, _gMultiplicar.CantidadIngresar);
                        }
                    }
                }
            }
        }
        public void IncrementarItem()
        {
            if (!IsNotaCredito)
            {
                if (PassWIsOk(Sistema.FuncionPosTeclaSumar))
                {
                    //_gestionItem.Incrementar();
                    if (Item != null)
                    {
                        var it = (Item.data)Item;
                        if (it.EsPesado)
                        {
                            return;
                        }
                        _gestionItem.SetCantIncrementar(it, 1);
                    }
                }
            }
        }


        public void setCtrlCliente(ICliente ctr)
        {
            _gestionCliente = ctr;
        }


        public string PagoImporteDivisaBono 
        {
            get 
            {
                if (Sistema.Modo_Despliegue_Solo_Divisa)
                    return pagoDivisaConBonoDscto_SoloEnDivisa();
                else
                    return pagoDivisaConBonoDscto_EnDivisaBolivar();
            } 
        }
        private bool _habilitarBonoPagoDivisa;
        private decimal _dsctoBonoPagoDivisa;
        private string pagoDivisaConBonoDscto_SoloEnDivisa()
        {
            var rt = "";
            if (_habilitarBonoPagoDivisa) 
            {
                rt += "Con Bono ("+_dsctoBonoPagoDivisa.ToString("n2")+"%): ";
                var _impDivisa= Math.Round(ImporteDivisa, 2, MidpointRounding.AwayFromZero);
                var _pagoDivisa = (_impDivisa / (1 + (_dsctoBonoPagoDivisa / 100)));
                rt += _pagoDivisa.ToString("n2") + "$";
            }
            return rt.Trim();
        }
        private string pagoDivisaConBonoDscto_EnDivisaBolivar()
        {
            var rt = "";
            if (_habilitarBonoPagoDivisa)
            {
                rt += "Con Bono (" + _dsctoBonoPagoDivisa.ToString("n2") + "%): ";

                var _importDivisa = Math.Round(ImporteDivisa, 2, MidpointRounding.AwayFromZero);
                var _pagoDivisa = Math.Round(_importDivisa / (1 + (_dsctoBonoPagoDivisa / 100)), 2, MidpointRounding.AwayFromZero);
                _pagoDivisa = _pagoDivisa - (_pagoDivisa - (int)_pagoDivisa);

                var _pago = (_pagoDivisa * _tasaCambioActual);
                var _bono = _pago * (_dsctoBonoPagoDivisa / 100);
                var _resta = Importe - (_pago + _bono);
                if (_resta <= 0.001m) { _resta = 0m; }
                rt += _pagoDivisa.ToString("n0") + "$, con " + _resta.ToString("n2") + "Bs";
            }
            return rt.Trim();
        }

        Src.MovCaja.Agregar.IAgregar _gAgregarMovCaja;
        Src.MovCaja.Anular.IAnularMov _gAnularMovCaja;
        Src.MovCaja.View.IViewMov _gViewMovCaja;
        Src.MovCaja.Adm.IAdm _gAdmMovCaja;
        public void MOV_ENTRADA_SALIDA_DINERO_CAJA()
        {
            if (Sistema.Sucursal.isModGastoHabilitado)
            {
                if (_gAgregarMovCaja == null)
                {
                    _gAgregarMovCaja = new Src.MovCaja.Agregar.ImpAgregar();
                }
                if (_gAnularMovCaja == null)
                {
                    _gAnularMovCaja = new Src.MovCaja.Anular.ImpAnularMov(_gAnular);
                }
                if (_gViewMovCaja == null)
                {
                    _gViewMovCaja = new Src.MovCaja.View.ImpViewMov();
                }

                if (_gAdmMovCaja == null)
                {
                    _gAdmMovCaja = new Src.MovCaja.Adm.ImpAdm(_gAnularMovCaja, _gAgregarMovCaja, _gViewMovCaja);
                }
                _gAdmMovCaja.Inicializa();
                _gAdmMovCaja.setIdOperadorActual(Sistema.PosEnUso.id);
                _gAdmMovCaja.Inicia();
            }
        }

        //
        private void ProcesarNotaEntreag_2()
        {
            if (Sistema.Activar_VentasAdm)
            {
                var t01 = Sistema.MyData.Vendedor_GetFichaById(_gestionCliente.GetVendedorId);
                if (t01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(t01.Mensaje);
                    return;
                }
                _vendedorAsignado = t01.Entidad;
            }
            if (_vendedorAsignado == null) 
            {
                _vendedorAsignado = _vendedorPorDefecto;
            }

            _isTickeraOk = false;
            _ImprimirDoc = null;

            var dsctoFinal = _gestionProcesarPago.DescuentoPorct;
            _gestionItem.setDescuentoFinal(dsctoFinal);

            var isCredito = _gestionProcesarPago.IsCreditoOk;
            var montoRecibido = _gestionProcesarPago.MontoRecibido;
            //var montoCambio = _gestionProcesarPago.MontoCambioDar_MonedaNacional;
            var montoCambio = _gestionProcesarPago.MontoCambioDar;
            var BaseExenta = _gestionItem.Items.Sum(s => s.BaseExenta);
            var MontoBase = _gestionItem.Items.Sum(s => s.MontoBase);
            var MontoImpuesto = _gestionItem.Items.Sum(s => s.MontoImpuesto);
            var MontoBase1 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_1.id).Sum(s => s.MontoBase);
            var MontoBase2 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_2.id).Sum(s => s.MontoBase);
            var MontoBase3 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_3.id).Sum(s => s.MontoBase);
            var MontoImpuesto1 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_1.id).Sum(s => s.MontoImpuesto);
            var MontoImpuesto2 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_2.id).Sum(s => s.MontoImpuesto);
            var MontoImpuesto3 = _gestionItem.Items.Where(w => w.IdTasaFiscal == _tasaFiscal_3.id).Sum(s => s.MontoImpuesto);
            var dsctoMonto = _gestionItem.Importe * dsctoFinal / 100;
            var utilidadMonto = _gestionItem.Items.Sum(s => s.Utilidad);
            var costoMonto = _gestionItem.Items.Sum(s => s.CostoVenta);
            var subTotalNeto = _gestionItem.Items.Sum(s => s.TotalNeto);
            var subTotal = _gestionItem.Importe - dsctoMonto;
            var netoMonto = _gestionItem.Items.Sum(s => s.VentaNeta);
            var netoMontoDivisa = 0m;
            if (_tasaCambioActual > 0)
            {
                netoMontoDivisa = netoMonto / _tasaCambioActual;
            }

            var importeDocumento = _gestionProcesarPago.MontoPagar;
            var importeDocumentoDivisa = _gestionProcesarPago.MontoPagarDivisa;
            var documento = "";
            var factorCambio = _tasaCambioActual;
            var saldoPendiente = isCredito ? importeDocumento : 0.0m;
            var dataPagoRecolectada = _gestionProcesarPago.DataPagoRecolectar;

            var fichaOOB = new OOB.Documento.Agregar.Factura.Ficha()
            {
                idOperador = Sistema.PosEnUso.id,
                DocumentoNro = documento,
                RazonSocial = _gestionCliente.Cliente.Nombre,
                DirFiscal = _gestionCliente.Cliente.DireccionFiscal,
                CiRif = _gestionCliente.Cliente.CiRif,
                Tipo = _tipoDocumentoNotaEntrega.codigo,
                Exento = BaseExenta,
                Base1 = MontoBase1,
                Base2 = MontoBase2,
                Base3 = MontoBase3,
                Impuesto1 = MontoImpuesto1,
                Impuesto2 = MontoImpuesto2,
                Impuesto3 = MontoImpuesto3,
                MBase = MontoBase,
                Impuesto = MontoImpuesto,
                Total = importeDocumento,
                Tasa1 = _tasaFiscal_1.tasa,
                Tasa2 = _tasaFiscal_2.tasa,
                Tasa3 = _tasaFiscal_3.tasa,
                Nota = "",
                TasaRetencionIva = 0.0m,
                TasaRetencionIslr = 0.0m,
                RetencionIva = 0.0m,
                RetencionIslr = 0.0m,
                AutoCliente = _gestionCliente.Cliente.Id,
                CodigoCliente = _gestionCliente.Cliente.Codigo,
                Control = _serieNotaEntrega.Control,
                OrdenCompra = "",
                Dias = 0,
                Descuento1 = dsctoMonto,
                Descuento2 = 0.0m,
                Cargos = 0.0m,
                Descuento1p = dsctoFinal,
                Descuento2p = 0.0m,
                Cargosp = 0.0m,
                Columna = "1",
                EstatusAnulado = "0",
                Aplica = "",
                ComprobanteRetencion = "",
                SubTotalNeto = subTotalNeto,
                Telefono = _gestionCliente.Cliente.Telefono,
                FactorCambio = factorCambio,
                CodigoVendedor = _vendedorAsignado.codigo,
                Vendedor = _vendedorAsignado.nombre,
                AutoVendedor = _vendedorAsignado.id,
                FechaPedido = DateTime.Now.Date,
                Pedido = "",
                CondicionPago = isCredito ? "CREDITO" : "CONTADO",
                Usuario = Sistema.Usuario.nombre,
                CodigoUsuario = Sistema.Usuario.codigo,
                CodigoSucursal = _sucursalAsignada.codigo,
                Transporte = _transporteAsignado.nombre,
                CodigoTransporte = _transporteAsignado.codigo,
                MontoDivisa = importeDocumentoDivisa,
                Despachado = "",
                DirDespacho = "",
                Estacion = Sistema.EquipoEstacion,
                Renglones = _gestionItem.CantRenglones,
                SaldoPendiente = saldoPendiente,
                ComprobanteRetencionIslr = "",
                DiasValidez = 0,
                AutoUsuario = Sistema.Usuario.id,
                AutoTransporte = _transporteAsignado.id,
                Situacion = "Procesado",
                Signo = _tipoDocumentoNotaEntrega.signo,
                Serie = _serieNotaEntrega.Serie,
                Tarifa = _precioManejar,
                TipoRemision = "",
                DocumentoRemision = "",
                AutoRemision = "",
                DocumentoNombre = "NOTA ENTREGA",
                SubTotalImpuesto = MontoImpuesto,
                SubTotal = subTotal,
                TipoCliente = "",
                Planilla = "",
                Expendiente = "",
                AnticipoIva = 0.0m,
                TercerosIva = 0.0m,
                Neto = netoMonto,
                Costo = costoMonto,
                Utilidad = utilidadMonto,
                Utilidadp = 100 - (costoMonto / netoMonto * 100),
                DocumentoTipo = _tipoDocumentoNotaEntrega.tipo,
                CiTitular = "",
                NombreTitular = "",
                CiBeneficiario = "",
                NombreBeneficiario = "",
                Clave = "",
                DenominacionFiscal = "No Contribuyente",
                Cambio = montoCambio,
                EstatusValidado = "0",
                Cierre = Sistema.PosEnUso.idAutoArqueoCierre,
                EstatusCierreContable = "0",
                CierreFtp = "",
                Prefijo = _sucursalAsignada.codigo + Sistema.IdEquipo,
                //
                PorctBonoPorPagoDivisa = dataPagoRecolectada.PorctBonoPorPagoDivisa,
                MontoBonoPorPagoDivisa = Math.Round(dataPagoRecolectada.MontoBonoPorPagoDivisa, 2, MidpointRounding.AwayFromZero),
                MontoBonoEnDivisaPorPagoDivisa = Math.Round(dataPagoRecolectada.MontoBonoEnDivisaPorPagoDivisa, 2, MidpointRounding.AwayFromZero),
                CantDivisaAplicaBonoPorPagoDivisa = dataPagoRecolectada.CantDivisaAplicaBonoPorPagoDivisa,
                MontoPorVueltoEnEfectivo = Math.Round(dataPagoRecolectada.MontoPorVueltoEnEfectivo, 2, MidpointRounding.AwayFromZero),
                MontoPorVueltoEnDivisa = Math.Round(dataPagoRecolectada.MontoPorVueltoEnDivisa, 2, MidpointRounding.AwayFromZero),
                MontoPorVueltoEnPagoMovil = Math.Round(dataPagoRecolectada.MontoPorVueltoEnPagoMovil, 2, MidpointRounding.AwayFromZero),
                CantDivisaPorVueltoEnDivisa = dataPagoRecolectada.CantDivisaPorVueltoEnDivisa,
                estatusPorBonoPorPagoDivisa = dataPagoRecolectada.estatusPorBonoPorPagoDivisa,
                estatusPorVueltoEnPagoMovil = dataPagoRecolectada.AplicaPagoMovil ? "1" : "0",
            };

            var medidas = _gestionItem.Items.
                            GroupBy(g => g.Ficha.empaqueDescripcion).
                            Select(s => new OOB.Documento.Agregar.Factura.FichaMedida()
                            {
                                descMedida = s.Key,
                                cnt = s.ToList().Sum(ss => ss.Cantidad),
                                peso = s.ToList().Sum(ss => ss.Cantidad * ss.Ficha.peso),
                                volumen = s.ToList().Sum(ss => ss.Cantidad * ss.Ficha.volumen),
                            }).
                            ToList();
            fichaOOB.Medidas = medidas;

            var detalles = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.Factura.FichaDetalle()
                {
                    AutoProducto = s.Ficha.autoProducto,
                    Codigo = s.Ficha.codigo,
                    Nombre = s.Ficha.nombre,
                    AutoDepartamento = s.Ficha.autoDepartamento,
                    AutoGrupo = s.Ficha.autoGrupo,
                    AutoSubGrupo = s.Ficha.autoSubGrupo,
                    AutoDeposito = s.Ficha.autoDeposito,
                    Cantidad = s.Ficha.cantidad,
                    Empaque = s.Ficha.empaqueDescripcion,
                    PrecioNeto = s.Ficha.pneto,
                    Descuento1p = 0.0m,
                    Descuento2p = 0.0m,
                    Descuento3p = 0.0m,
                    Descuento1 = 0.0m,
                    Descuento2 = 0.0m,
                    Descuento3 = 0.0m,
                    CostoVenta = s.CostoVenta,
                    TotalNeto = s.TotalNeto,
                    Tasa = s.Ficha.tasaIva,
                    Impuesto = s.Impuesto,
                    Total = s.Total,
                    EstatusAnulado = "0",
                    Tipo = _tipoDocumentoVenta.codigo,
                    Deposito = _depositoAsignado.nombre,
                    Signo = _tipoDocumentoVenta.signo,
                    PrecioFinal = s.PrecioFinal,
                    AutoCliente = _gestionCliente.Cliente.Id,
                    Decimales = s.Ficha.decimales,
                    ContenidoEmpaque = s.Ficha.empaqueContenido,
                    CantidadUnd = s.TotalUnd,
                    PrecioUnd = s.PrecioUnd,
                    CostoUnd = s.Ficha.costoUnd,
                    Utilidad = s.Utilidad,
                    Utilidadp = s.UtilidadP,
                    PrecioItem = s.PrecioItem,
                    EstatusGarantia = "0",
                    EstatusSerial = "0",
                    CodigoDeposito = _depositoAsignado.codigo,
                    DiasGarantia = 0,
                    Detalle = "",
                    PrecioSugerido = 0.0m,
                    AutoTasa = s.Ficha.autoTasa,
                    EstatusCorte = "0",
                    X = 1,
                    Y = 1,
                    Z = 1,
                    Corte = "",
                    Categoria = s.Ficha.categoria,
                    Cobranzap = 0.0m,
                    Ventasp = 0.0m,
                    CobranzapVendedor = 0.0m,
                    VentaspVendedor = 0.0m,
                    Cobranza = 0.0m,
                    Ventas = 0.0m,
                    CobranzaVendedor = 0.0m,
                    VentasVendedor = 0.0m,
                    CostoPromedioUnd = s.Ficha.costoPromedioUnd,
                    CostoCompra = s.Ficha.costoCompra,
                    EstatusChecked = "1",
                    Tarifa = s.Ficha.tarifaPrecio,
                    TotalDescuento = 0.0m,
                    CodigoVendedor = _vendedorAsignado.codigo,
                    AutoVendedor = _vendedorAsignado.id,
                    CierreFtp = "",
                };
                return nr;
            }).ToList();
            fichaOOB.Detalles = detalles;

            var actDeposito = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.Factura.FichaDeposito()
                {
                    AutoDeposito = s.Ficha.autoDeposito,
                    AutoProducto = s.Ficha.autoProducto,
                    CantUnd = s.TotalUnd,
                };
                return nr;
            }).ToList();
            fichaOOB.ActDeposito = actDeposito;

            var kardex = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.Factura.FichaKardex()
                {
                    AutoProducto = s.Ficha.autoProducto,
                    Total = s.TotalUnd * s.Ficha.costoUnd,
                    AutoDeposito = s.Ficha.autoDeposito,
                    AutoConcepto = _conceptoVenta.id,
                    Modulo = "Ventas",
                    Entidad = _gestionCliente.Cliente.Nombre,
                    Signo = -1,
                    Cantidad = s.Cantidad,
                    CantidadBono = 0.0m,
                    CantidadUnd = s.TotalUnd,
                    CostoUnd = s.Ficha.costoUnd,
                    EstatusAnulado = "0",
                    Nota = "",
                    PrecioUnd = s.PrecioFinalUnd,
                    Codigo = _tipoDocumentoNotaEntrega.codigo,
                    Siglas = _tipoDocumentoNotaEntrega.siglas,
                    CierreFtp = "",
                    CodigoSucursal = _sucursalAsignada.codigo,
                    CodigoDeposito = _depositoAsignado.codigo,
                    NombreDeposito = _depositoAsignado.nombre,
                    CodigoConcepto = _conceptoSalida.codigo,
                    NombreConcepto = _conceptoSalida.nombre,
                    FactorCambio = factorCambio,
                };
                return nr;
            }).ToList();
            fichaOOB.MovKardex = kardex;

            fichaOOB.DocCxC = new OOB.Documento.Agregar.Factura.FichaCxC()
            {
                CCobranza = 0.0m,
                CCobranzap = 0.0m,
                TipoDocumento = _tipoDocumentoVenta.siglas,
                Nota = "",
                Importe = importeDocumento,
                Acumulado = isCredito ? 0.0m : importeDocumento,
                AutoCliente = _gestionCliente.Cliente.Id,
                Cliente = _gestionCliente.Cliente.Nombre,
                CiRif = _gestionCliente.Cliente.CiRif,
                CodigoCliente = _gestionCliente.Cliente.Codigo,
                EstatusCancelado = isCredito ? "0" : "1",
                Resta = isCredito ? importeDocumento : 0.0m,
                EstatusAnulado = "0",
                Numero = "",
                AutoAgencia = "0000000001",
                Agencia = "",
                Signo = _tipoDocumentoVenta.signo,
                AutoVendedor = _vendedorAsignado.id,
                CDepartamento = 0.0m,
                CVentas = 0.0m,
                CVentasp = 0.0m,
                Serie = _serieFactura.Serie,
                ImporteNeto = netoMonto,
                Dias = 0,
                CastigoP = 0.0m,
                CierreFtp = "",
                MontoDivisa = importeDocumentoDivisa,
                TasaDivisa = factorCambio,
                //
                AcumuladoDivisa = isCredito ? 0.0m : importeDocumentoDivisa,
                CodigoSucursal = _sucursalAsignada.codigo,
                RestaDivisa = isCredito ? importeDocumentoDivisa : 0.0m,
                ImporteNetoDivisa = Math.Round(netoMontoDivisa, 2, MidpointRounding.AwayFromZero),
            };

            var PMontoEfectivo = 0.0m;
            var PMontoDivisa = 0.0m;
            var PMontoElectronico = 0.0m;
            var PMontoOtro = 0.0m;
            var CntEfectivo = 0;
            var CntDivisa = 0;
            var CntElectronico = 0;
            var CntOtro = 0;

            if (isCredito)
            {
                fichaOOB.DocCxCPago = null;
                fichaOOB.ClienteSaldo = new OOB.Documento.Agregar.Factura.FichaClienteSaldo()
                {
                    AutoCliente = _gestionCliente.Cliente.Id,
                    MontoActualizar = importeDocumentoDivisa,
                };
            }
            else
            {
                fichaOOB.DocCxCPago = new OOB.Documento.Agregar.Factura.FichaCxCPago();
                var p = new OOB.Documento.Agregar.Factura.FichaCxC()
                {
                    CCobranza = 0.0m,
                    CCobranzap = 0.0m,
                    TipoDocumento = "PAG",
                    Nota = "",
                    Importe = importeDocumento,
                    Acumulado = 0.0m,
                    AutoCliente = _gestionCliente.Cliente.Id,
                    Cliente = _gestionCliente.Cliente.Nombre,
                    CiRif = _gestionCliente.Cliente.CiRif,
                    CodigoCliente = _gestionCliente.Cliente.Codigo,
                    EstatusCancelado = "0",
                    Resta = 0.0m,
                    EstatusAnulado = "0",
                    Numero = "",
                    AutoAgencia = "0000000001",
                    Agencia = "",
                    Signo = -1,
                    AutoVendedor = _vendedorAsignado.id,
                    CDepartamento = 0.0m,
                    CVentas = 0.0m,
                    CVentasp = 0.0m,
                    Serie = "",
                    ImporteNeto = 0.0m,
                    Dias = 0,
                    CastigoP = 0.0m,
                    CierreFtp = "",
                    MontoDivisa = importeDocumentoDivisa,
                    TasaDivisa = factorCambio,
                    //
                    AcumuladoDivisa = 0m,
                    CodigoSucursal = _sucursalAsignada.codigo,
                    RestaDivisa = 0m,
                    ImporteNetoDivisa = 0m,
                };
                var _montoRecibidoDivisa = 0m;
                var _cambioDivisa = 0m;
                if (factorCambio > 0)
                {
                    _montoRecibidoDivisa = Math.Round(montoRecibido / factorCambio, 2, MidpointRounding.AwayFromZero);
                    _cambioDivisa = Math.Round(montoCambio / factorCambio, 2, MidpointRounding.AwayFromZero);
                }
                var pR = new OOB.Documento.Agregar.Factura.FichaCxCRecibo()
                {
                    AutoUsuario = Sistema.Usuario.id,
                    Importe = importeDocumento,
                    Usuario = Sistema.Usuario.nombre,
                    MontoRecibido = montoRecibido,
                    Cobrador = _cobradorAsignado.nombre,
                    AutoCliente = _gestionCliente.Cliente.Id,
                    Cliente = _gestionCliente.Cliente.Nombre,
                    CiRif = _gestionCliente.Cliente.CiRif,
                    Codigo = _gestionCliente.Cliente.Codigo,
                    EstatusAnulado = "0",
                    Direccion = _gestionCliente.Cliente.DireccionFiscal,
                    Telefono = _gestionCliente.Cliente.Telefono,
                    AutoCobrador = _cobradorAsignado.id,
                    Anticipos = 0.0m,
                    Cambio = montoCambio,
                    Nota = "",
                    CodigoCobrador = _cobradorAsignado.codigo,
                    Retenciones = 0.0m,
                    Descuentos = 0.0m,
                    Cierre = Sistema.PosEnUso.idAutoArqueoCierre,
                    CierreFtp = "",
                    //
                    ImporteDivisa = importeDocumentoDivisa,
                    MontoRecibidoDivisa = _montoRecibidoDivisa,
                    CambioDivisa = _cambioDivisa,
                    CodigoSucursal = _sucursalAsignada.codigo,
                };
                var pD = new OOB.Documento.Agregar.Factura.FichaCxCDocumento()
                {
                    Id = 1,
                    TipoDocumento = _tipoDocumentoNotaEntrega.siglas,
                    Operacion = "Pago",
                    Importe = importeDocumento,
                    Dias = 0,
                    CastigoP = 0.0m,
                    ComisionP = 0.0m,
                    CierreFtp = "",
                    //
                    ImporteDivisa = importeDocumentoDivisa,
                    CodigoSucursal = _sucursalAsignada.codigo,
                    Notas = "",
                };

                var pM = new List<OOB.Documento.Agregar.Factura.FichaCxCMetodoPago>();
                foreach (var it in _gestionProcesarPago.PagoDetalles.Where(w => w.Monto > 0m).ToList())
                {
                    var autoMedioPago = "";
                    var codigoMedioPago = "";
                    var descMedioPago = "";
                    var lote = "";
                    var referencia = "";
                    var montoRecibe = it.MontoRecibido;
                    var _montoRecibeDivisa = 0m;
                    var _aplicaFactorConversion = "";

                    switch (it.Modo)
                    {
                        case Pago.Procesar.Enumerados.ModoPago.Efectivo:
                            autoMedioPago = _medioPagoEfectivo.id;
                            codigoMedioPago = _medioPagoEfectivo.codigo;
                            descMedioPago = _medioPagoEfectivo.nombre;
                            PMontoEfectivo += montoRecibe;
                            CntEfectivo += 1;
                            //
                            if (factorCambio > 0)
                            {
                                _montoRecibeDivisa = Math.Round(montoRecibe / factorCambio, 4, MidpointRounding.AwayFromZero);
                            }
                            _aplicaFactorConversion = "1";
                            break;

                        case Pago.Procesar.Enumerados.ModoPago.Divisa:
                            //montoRecibe = it.Monto;
                            montoRecibe = it.MontoPagoDivisaSinBono;
                            autoMedioPago = _medioPagoDivisa.id;
                            codigoMedioPago = _medioPagoDivisa.codigo;
                            descMedioPago = _medioPagoDivisa.nombre;
                            lote = it.Cantidad.ToString();
                            referencia = TasaCambioActual.ToString("n2").Replace(".", "");
                            PMontoDivisa += montoRecibe;
                            CntDivisa = (int)it.Cantidad;
                            //
                            _montoRecibeDivisa = it.Cantidad;
                            _aplicaFactorConversion = "0";
                            break;

                        case Pago.Procesar.Enumerados.ModoPago.Electronico:
                            if (it.Id != 4) //DEBITO
                            {
                                autoMedioPago = _medioPagoElectronico.id;
                                codigoMedioPago = _medioPagoElectronico.codigo;
                                descMedioPago = _medioPagoElectronico.nombre;
                                lote = it.Lote;
                                referencia = it.Referencia;
                                PMontoElectronico += montoRecibe;
                                CntElectronico += 1;
                                //
                                if (factorCambio > 0)
                                {
                                    _montoRecibeDivisa = Math.Round(montoRecibe / factorCambio, 4, MidpointRounding.AwayFromZero);
                                }
                                _aplicaFactorConversion = "1";
                            }
                            else //OTROS
                            {
                                autoMedioPago = _medioPagoOtro.id;
                                codigoMedioPago = _medioPagoOtro.codigo;
                                descMedioPago = _medioPagoOtro.nombre;
                                lote = it.Lote;
                                referencia = it.Referencia;
                                PMontoOtro += montoRecibe;
                                CntOtro += 1;
                                //
                                if (factorCambio > 0)
                                {
                                    _montoRecibeDivisa = Math.Round(montoRecibe / factorCambio, 4, MidpointRounding.AwayFromZero);
                                }
                                _aplicaFactorConversion = "1";
                            }
                            break;
                    }

                    pM.Add(new OOB.Documento.Agregar.Factura.FichaCxCMetodoPago()
                    {
                        AutoMedioPago = autoMedioPago,
                        AutoAgencia = "",
                        Medio = descMedioPago,
                        Codigo = codigoMedioPago,
                        MontoRecibido = montoRecibe,
                        EstatusAnulado = "0",
                        Numero = "",
                        Agencia = "",
                        AutoUsuario = Sistema.Usuario.id,
                        Lote = lote,
                        Referencia = referencia,
                        AutoCobrador = _cobradorAsignado.id,
                        Cierre = Sistema.PosEnUso.idAutoArqueoCierre,
                        CierreFtp = "",
                        //
                        OpBanco = "",
                        OpNroCta = "",
                        OpNroRef = "",
                        OpFecha = DateTime.Now.Date,
                        OpDetalle = "",
                        OpMonto = _montoRecibeDivisa,
                        OpTasa = factorCambio,
                        OpAplicaConversion = _aplicaFactorConversion,
                        CodigoSucursal = _sucursalAsignada.codigo,
                    });
                }
                fichaOOB.DocCxCPago.Pago = p;
                fichaOOB.DocCxCPago.Recibo = pR;
                fichaOOB.DocCxCPago.Documento = pD;
                fichaOOB.DocCxCPago.MetodoPago = pM;
                fichaOOB.ClienteSaldo = null;
            }
            fichaOOB.PosVenta = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.Factura.FichaPosVenta()
                {
                    id = s.Ficha.id,
                    idOperador = s.Ficha.idOperador,
                };
                return nr;
            }).ToList();
            fichaOOB.Resumen = new OOB.Documento.Agregar.Factura.FichaPosResumen()
            {
                cntDoc = 1,
                cntDevolucion = 0,
                cntFac = 0,
                cntNCr = 0,
                idResumen = Sistema.PosEnUso.idResumen,
                mDevolucion = 0.0m,
                mFac = 0m,
                mNCr = 0.0m,
                cntEfectivo = CntEfectivo,
                cntDivisa = CntDivisa,
                cntElectronico = CntElectronico,
                cntotros = CntOtro,
                mEfectivo = PMontoEfectivo,
                mDivisa = PMontoDivisa,
                mElectronico = PMontoElectronico,
                mOtros = PMontoOtro,
                cntDocContado = isCredito ? 0 : 1,
                cntDocCredito = isCredito ? 1 : 0,
                mContado = isCredito ? 0 : importeDocumento,
                mCredito = isCredito ? importeDocumento : 0,
                //
                cntAnu = 0,
                cntNte = 1,
                mAnu = 0.0m,
                mNte = importeDocumento,
                //
                mCambio = montoCambio,
                cntCambio = montoCambio > 0 ? 1 : 0,
                //
                montoVueltoPorEfectivo = dataPagoRecolectada.MontoPorVueltoEnEfectivo,
                montoVueltoPorDivisa = dataPagoRecolectada.MontoPorVueltoEnDivisa,
                montoVueltoPorPagoMovil = dataPagoRecolectada.MontoPorVueltoEnPagoMovil,
                cntDivisaPorVueltoDivisa = dataPagoRecolectada.CantDivisaPorVueltoEnDivisa,
            };
            fichaOOB.SerieFiscal = new OOB.Documento.Agregar.Factura.FichaSerie() { auto = _serieNotaEntrega.Auto };
            if (dataPagoRecolectada.AplicaPagoMovil)
            {
                var pm = dataPagoRecolectada.DataPagoMovil;
                fichaOOB.PagoMovil = new OOB.Documento.Agregar.Factura.FichaPagoMovil()
                {
                    autoAgencia = pm.agencia.id,
                    ciRif = pm.ciRif,
                    monto = pm.monto,
                    nombre = pm.nombre,
                    telefono = pm.telefono,
                    //
                    clienteDirFiscal = _gestionCliente.Cliente.DireccionFiscal,
                    clienteNombre = _gestionCliente.Cliente.Nombre,
                    clienteRif = _gestionCliente.Cliente.CiRif,
                    codigoDocumento = _tipoDocumentoDevVenta.codigo,
                    tipoDocumento = _tipoDocumentoDevVenta.tipo,
                    montoDocumento = importeDocumento,
                    codigoSucursal = _sucursalAsignada.codigo,
                    nombreAgencia = pm.agencia.desc,
                    cierre = Sistema.PosEnUso.idAutoArqueoCierre,
                    cierreFtp = "",
                };
            }

            var r01 = Sistema.MyData.Documento_Agregar_Factura(fichaOOB);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var xdata = CargarDataDocumento(r01.Entidad.autoDoc);
            if (xdata != null)
            {
                var dat = new Helpers.Imprimir.dataQR()
                {
                    autoCierre = r01.Entidad.autoCierre,
                    autoDoc = r01.Entidad.autoDoc,
                    codDoc = r01.Entidad.codDoc,
                    idVerificador = r01.Entidad.idVerificador,
                    montoDoc = r01.Entidad.montoDoc,
                    numDoc = r01.Entidad.numDoc,
                };
                Sistema.ImprimirNotaEntrega.setData(xdata);
                Sistema.ImprimirNotaEntrega.setImprimirQR(dat);
                if (Sistema.ImprimirNotaEntrega.IsModoTicket)
                {
                    _isTickeraOk = true;
                    _ImprimirDoc = Sistema.ImprimirNotaEntrega;
                    printDocument2.Print();
                }
                else
                {
                    Sistema.ImprimirNotaEntrega.ImprimirDoc();
                }
            }

            _gestionItem.Limpiar();
            _gestionCliente.Limpiar();
            Inicializa();
            Reiniciar();
        }
    }
}