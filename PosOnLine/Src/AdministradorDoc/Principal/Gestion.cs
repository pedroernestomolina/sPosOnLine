using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.AdministradorDoc.Principal
{
    public class Gestion
    {
        private bool _isModoFiscal;
        private bool _anularDocumentoIsOk;
        private bool _notaCreditoIsOk;
        private Lista.data _docAplicarNotaCredito;
        private Anular.IAnular _gestionAnular;
        private Visualizar.Gestion _gestionVisualizar;
        private System.Drawing.Printing.PrintDocument _printDoc;
        Helpers.Imprimir.IDocTicket _imprimirDocTicket;
        //
        public object ItemActual { get { return _gestionLista.ItemActual; } }
        public int CntItems { get { return _gestionLista.CntItems; } }
        private Lista.Gestion _gestionLista;
        public bool NotaCreditoIsOk { get { return _notaCreditoIsOk; } }
        public Lista.data DocAplicaNotaCredito { get { return _docAplicarNotaCredito; } }
        public BindingSource Source { get { return _gestionLista.Source; } }
        public bool AnularDocumentoIsOk { get { return _anularDocumentoIsOk; } }
        //
        public Gestion()
        {
            _anularDocumentoIsOk = false;
            _isModoFiscal = Sistema.ModoFiscalActivo;
            _notaCreditoIsOk = false;
            _docAplicarNotaCredito = null;
            _printDoc = new System.Drawing.Printing.PrintDocument();
            _printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            _gestionVisualizar = new Visualizar.Gestion();
            _gestionLista = new Lista.Gestion();
        }
        public void Inicializa()
        {
            _docAplicarNotaCredito = null;
            _anularDocumentoIsOk = false;
            _isModoFiscal = Sistema.ModoFiscalActivo;
            _anularDocumentoIsOk = false;
            _gestionLista.Inicializa();
            _notaCreditoIsOk = false;
        }
        AdmDocFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AdmDocFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void setGestionAnular(Anular.IAnular ctr)
        {
            _gestionAnular = ctr;
        }
        public void SubirItem()
        {
            _gestionLista.SubirItem();
        }
        public void BajarItem()
        {
            _gestionLista.BajarItem();
        }
        public void NotaCredito()
        {
            _notaCreditoIsOk = false;
            _docAplicarNotaCredito = null;
            if (AplicaParaNotaCredito())
            {
                if (Helpers.PassWord.PassWIsOk(Sistema.FuncionAdmNotaCredito))
                {
                    _notaCreditoIsOk = true;
                }
            }
        }
        public void AnularDocumento()
        {
            _anularDocumentoIsOk = false;
            if (AplicaParaAnular())
            {
                if (Helpers.PassWord.PassWIsOk(Sistema.FuncionAdmAnularDocumento))
                {
                    var itemAnular = (Lista.data)ItemActual;
                    _gestionAnular.Inicializa();
                    _gestionAnular.Inicia();
                    if (_gestionAnular.ProcesarIsOK)
                    {
                        if (Helpers.Msg.Procesar("Estas Seguro De Anular Este Documento ?"))
                        {
                            var motivo = _gestionAnular.GetMotivo;
                            var rt = false;
                            switch (itemAnular.DocTipo)
                            {
                                case Lista.Enumerados.enumTipoDoc.NotaEntrega:
                                    //rt = AnularNotaEntrega(_gestionLista.DocAplicaParaAulacion.idDocumento,motivo);
                                    rt = AnularFactura(itemAnular.idDocumento, motivo);
                                    break;
                                case Lista.Enumerados.enumTipoDoc.NotaCredito:
                                    rt = AnularNotaCredito(itemAnular.idDocumento, motivo);
                                    break;
                                case Lista.Enumerados.enumTipoDoc.Factura:
                                    rt = AnularFactura(itemAnular.idDocumento, motivo);
                                    break;
                            }
                            if (rt)
                            {
                                _anularDocumentoIsOk = true;
                                _gestionLista.setAnularDoc();
                            }
                        }
                    }
                }
            }
        }
        public void ImprimirDocumento()
        {
            if (_gestionLista.ItemActual == null) return;
            if (Helpers.PassWord.PassWIsOk(Sistema.FuncionAdmReimprimirDocumento))
            {
                var item = (Lista.data)_gestionLista.ItemActual;
                imprimirDoc(item);
            }
        }
        public void ImprimirDocumentoAnulado()
        {
            if (_gestionLista.ItemActual == null) return;
            var item = (Lista.data)_gestionLista.ItemActual;
            imprimirDoc(item);
        }
        public void VisualizarDocumento()
        {
            visualizarDoc();
        }
        public void ActualizarModoDoc()
        {
            if (Sistema.ModoFiscalActivo)
            {
                _isModoFiscal = !_isModoFiscal;
                CargarDocumentos();
            }
        }
        //
        private bool CargarData()
        {
            try
            {
                var filtro = new OOB.Documento.Lista.Filtro() { idArqueo = Sistema.PosEnUso.idAutoArqueoCierre };
                var r01 = Sistema.MyData.Documento_Get_Lista(filtro);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                var _lst = r01.ListaD;
                if (Sistema.ModoFiscalActivo)
                {
                    _lst = r01.ListaD.Where(d => d.IsFiscal).ToList();
                }
                _gestionLista.setData(_lst);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void imprimirDoc(Lista.data item)
        {
            try
            {
                var xr1 = Sistema.MyData.Documento_GetById(item.idDocumento);
                if (xr1.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(xr1.Mensaje);
                }
                var xr2 = Sistema.MyData.Documento_Get_MetodosPago_ByIdRecibo(xr1.Entidad.AutoReciboCxC);
                if (xr2.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(xr2.Mensaje);
                }
                //
                var dat = new Helpers.Imprimir.dataQR()
                {
                    autoCierre = xr1.Entidad.Cierre,
                    autoDoc = xr1.Entidad.Auto,
                    codDoc = xr1.Entidad.Tipo,
                    idVerificador = 0,
                    montoDoc = xr1.Entidad.Total,
                    numDoc = xr1.Entidad.DocumentoNro,
                };
                Sistema.ImprimirFactura.setImprimirQR(dat);
                Sistema.ImprimirFactura.setEmpresa(Sistema.DatosEmpresa);
                var xdata = new Helpers.Imprimir.data();
                xdata.isAnulado = xr1.Entidad.EstatusAnulado == "1";
                var docNombre = "";
                switch (xr1.Entidad.Tipo.Trim().ToUpper())
                {
                    case "01":
                        docNombre = "COPIA FACTURA";
                        break;
                    case "02":
                        docNombre = "COPIA NOTA DE DEBITO";
                        break;
                    case "03":
                        docNombre = "COPIA NOTA DE CREDITO";
                        break;
                    case "04":
                        docNombre = "COPIA NOTA DE ENTREGA";
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
                    //
                    VueltoEfectivo = xr1.Entidad.MontoPorVueltoEnEfectivo,
                    VueltoDivisa = xr1.Entidad.MontoPorVueltoEnDivisa,
                    VueltoPagoMovil = xr1.Entidad.MontoPorVueltoEnPagoMovil,
                    CntDivisaVueltoDivisa = xr1.Entidad.CantDivisaPorVueltoEnDivisa,
                    //
                    BonoPorPagoDivisa = xr1.Entidad.BonoPorPagoDivisa,
                    MontoBonoPorPagoDivisa = xr1.Entidad.MontoBonoPorPagoDivisa,
                    CntDivisaAplicaBonoPorPagoDivisa = xr1.Entidad.CntDivisaAplicaBonoPorPagoDivisa,
                    //
                    SaldoPendientDiv = xr1.Entidad.SaldoPendiente,
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
                        ImporteFull = rg.Total,
                        ImporteDivisa = rg.Total,
                        Precio = rg.PrecioItem,
                        PrecioDivisa = rg.PrecioItem,
                        TotalUnd = rg.CantidadUnd,
                        TasaIva = rg.Tasa,
                    };
                    xdata.item.Add(nr);
                }
                xdata.metodoPago = new List<Helpers.Imprimir.data.MetodoPago>();
                foreach (var mp in xr2.ListaD)
                {
                    if (Math.Abs(mp.cntDivisa) >= 1)
                    {
                        var pag = new Helpers.Imprimir.data.MetodoPago() { descripcion = "Efectivo($" + mp.cntDivisa.ToString() + ")", monto = mp.montoRecibido };
                        xdata.metodoPago.Add(pag);
                    }
                    else
                    {
                        var pag = new Helpers.Imprimir.data.MetodoPago() { descripcion = mp.descMedioPago.Trim() + "(Bs)", monto = mp.montoRecibido };
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
                //
                _imprimirDocTicket = null;
                switch (item.DocTipo)
                {
                    case Lista.Enumerados.enumTipoDoc.Factura:
                        Sistema.ImprimirFactura.setData(xdata);
                        if (Sistema.ImprimirFactura is Helpers.Imprimir.IDocTicket)
                        {
                            _imprimirDocTicket = (Helpers.Imprimir.DocumentoTicket)Sistema.ImprimirFactura;
                            _printDoc.Print();
                        }
                        else 
                            Sistema.ImprimirFactura.ImprimirCopiaDoc();
                        break;
                    case Lista.Enumerados.enumTipoDoc.NotaCredito:
                        Sistema.ImprimirNotaCredito.setData(xdata);
                        if (Sistema.ImprimirNotaCredito is Helpers.Imprimir.IDocTicket)
                        {
                            _imprimirDocTicket = (Helpers.Imprimir.DocumentoTicket)Sistema.ImprimirNotaCredito;
                            _printDoc.Print();
                        }
                        else 
                            Sistema.ImprimirNotaCredito.ImprimirCopiaDoc();
                        break;
                    case Lista.Enumerados.enumTipoDoc.NotaEntrega:
                        Sistema.ImprimirNotaEntrega.setData(xdata);
                        if (Sistema.ImprimirNotaEntrega is Helpers.Imprimir.IDocTicket)
                        {
                            _imprimirDocTicket = (Helpers.Imprimir.DocumentoTicket)Sistema.ImprimirNotaEntrega;
                            _printDoc.Print();
                        }
                        else 
                            Sistema.ImprimirNotaEntrega.ImprimirCopiaDoc();
                        break;
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (_imprimirDocTicket == null) return;
            _imprimirDocTicket.setControladorTickera(e);
            _imprimirDocTicket.ImprimirDoc();
        }
        private bool AnularNotaEntrega(string idDoc, string mtv)
        {
            var r01 = Sistema.MyData.Documento_GetById(idDoc);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var ficha = new OOB.Documento.Anular.NotaEntrega.Ficha()
            {
                idOperador = Sistema.PosEnUso.id,
                autoDocumento = idDoc,
                CodigoDocumento = r01.Entidad.Tipo,
                auditoria = new OOB.Documento.Anular.NotaEntrega.FichaAuditoria
                {
                    autoSistemaDocumento = Sistema.ConfiguracionActual.idTipoDocumentoNotaEntrega,
                    autoUsuario = Sistema.Usuario.id,
                    codigo = Sistema.Usuario.codigo,
                    estacion = Sistema.EquipoEstacion,
                    motivo = mtv,
                    usuario = Sistema.Usuario.nombre,
                },
                deposito = r01.Entidad.items.Select(s =>
                {
                    var nr = new OOB.Documento.Anular.NotaEntrega.FichaDeposito()
                    {
                        AutoDeposito = s.AutoDeposito,
                        AutoProducto = s.AutoProducto,
                        CantUnd = s.CantidadUnd,
                        nombrePrd = s.Nombre,
                    };
                    return nr;
                }).ToList(),
                resumen = new OOB.Documento.Anular.NotaEntrega.FichaResumen()
                {
                    idResumen = Sistema.PosEnUso.idResumen,
                    monto = r01.Entidad.Total,
                },
            };
            var r03 = Sistema.MyData.Documento_Anular_NotaEntrega(ficha);
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            return true;
        }
        private bool AnularNotaCredito(string idDoc, string mtv)
        {
            var _cntEfectivo = 0;
            var _cntDivisa = 0;
            var _cntElectronico = 0;
            var _cntOtros = 0;
            var _mDivisa = 0.0m;
            var _mElectronico = 0.0m;
            var _mEfectivo = 0.0m;
            var _mOtros = 0.0m;
            var _autoReciboCxC = "";

            var r01 = Sistema.MyData.Documento_GetById(idDoc);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _autoReciboCxC = r01.Entidad.AutoReciboCxC;
            var metPago = new List<OOB.Documento.Entidad.FichaMetodoPago>();
            if (r01.Entidad.CondicionPago.Trim().ToUpper() == "CONTADO")
            {
                if (r01.Entidad.AutoReciboCxC != "")
                {
                    var r04 = Sistema.MyData.Documento_Get_MetodosPago_ByIdRecibo(r01.Entidad.AutoReciboCxC);
                    if (r04.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r04.Mensaje);
                        return false;
                    }
                    if (r04.ListaD.Count > 0) //DOCUMENTO TIENE MEDIOS DE PAGO, DOCUMENTO ORIGEN ES DE CONTADO
                    {
                        foreach (var rg in r04.ListaD)
                        {
                            if (rg.descMedioPago.Trim().ToUpper() == "EFECTIVO")
                            {
                                _cntEfectivo += 1;
                                _mEfectivo += Math.Abs(rg.montoRecibido);
                            }
                            else if (rg.descMedioPago.Trim().ToUpper() == "DIVISA")
                            {
                                _cntDivisa += Math.Abs(rg.cntDivisa);
                                _mDivisa += Math.Abs(rg.montoRecibido);
                            }
                            else if (rg.descMedioPago.Trim().ToUpper() == "TARJETA DEBITO")
                            {
                                _cntElectronico += 1;
                                _mElectronico += Math.Abs(rg.montoRecibido);
                            }
                            else
                            {
                                _cntOtros += 1;
                                _mOtros += Math.Abs(rg.montoRecibido);
                            }
                        }
                    }
                    else
                    {
                        _autoReciboCxC = ""; //DOCUMENTO NO TIENE MEDIOS DE PAGO, DOCUMENTO ORIGEN ES CREDITO
                    }
                }
            }
            OOB.Documento.Anular.NotaCredito.FichaClienteSaldo _clienteSaldo = null;
            if (_autoReciboCxC == "")
            {
                _clienteSaldo = new OOB.Documento.Anular.NotaCredito.FichaClienteSaldo()
                {
                    autoCliente = r01.Entidad.AutoCliente,
                    monto = r01.Entidad.MontoDivisa,
                };
            }

            var ficha = new OOB.Documento.Anular.NotaCredito.Ficha()
            {
                idOperador = Sistema.PosEnUso.id,
                autoDocumento = idDoc,
                autoDocCxC = r01.Entidad.AutoDocCxC,
                autoReciboCxC = _autoReciboCxC,
                CodigoDocumento = r01.Entidad.Tipo,
                clienteSaldo = _clienteSaldo,
                auditoria = new OOB.Documento.Anular.NotaCredito.FichaAuditoria
                {
                    autoSistemaDocumento = Sistema.ConfiguracionActual.idTipoDocumentoDevVenta,
                    autoUsuario = Sistema.Usuario.id,
                    codigo = Sistema.Usuario.codigo,
                    estacion = Sistema.EquipoEstacion,
                    motivo = mtv,
                    usuario = Sistema.Usuario.nombre,
                },
                deposito = r01.Entidad.items.Select(s =>
                {
                    var nr = new OOB.Documento.Anular.NotaCredito.FichaDeposito()
                    {
                        AutoDeposito = s.AutoDeposito,
                        AutoProducto = s.AutoProducto,
                        CantUnd = s.CantidadUnd,
                        nombrePrd = s.Nombre,
                    };
                    return nr;
                }).ToList(),
                resumen = new OOB.Documento.Anular.NotaCredito.FichaResumen()
                {
                    idResumen = Sistema.PosEnUso.idResumen,
                    monto = r01.Entidad.Total,
                    cntDivisa = _cntDivisa,
                    cntEfectivo = _cntEfectivo,
                    cntElectronico = _cntElectronico,
                    cntOtros = _cntOtros,
                    mDivisa = _mDivisa,
                    mEfectivo = _mEfectivo,
                    mElectronico = _mElectronico,
                    mOtros = _mOtros,
                },
            };
            var r03 = Sistema.MyData.Documento_Anular_NotaCredito(ficha);
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }

            return true;
        }
        private bool AnularFactura(string idDoc, string mtv)
        {
            var _condPagoIsContado = false;
            var _cntEfectivo = 0;
            var _cntDivisa = 0;
            var _cntElectronico = 0;
            var _cntOtros = 0;
            var _mDivisa = 0.0m;
            var _mElectronico = 0.0m;
            var _mEfectivo = 0.0m;
            var _mOtros = 0.0m;
            var _cntCambio = 0;
            var _mCambio = 0.0m;
            var _montoVueltoPorEfectivo = 0m;
            var _montoVueltoPorDivisa = 0m;
            var _montoVueltoPorPagoMovil = 0m;
            var _cntDivisaPorVueltoDivisa = 0m;

            var r01 = Sistema.MyData.Documento_GetById(idDoc);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var _cntFac_anu = 0;
            var _cntNte_anu = 0;
            var _montoFac_anu = 0m;
            var _montoNte_anu = 0m;
            switch (r01.Entidad.Tipo)
            {
                case "01":
                    _cntFac_anu = 1;
                    _montoFac_anu = r01.Entidad.Total;
                    break;
                case "04":
                    _cntNte_anu = 1;
                    _montoNte_anu = r01.Entidad.Total;
                    break;
            }
            var metPago = new List<OOB.Documento.Entidad.FichaMetodoPago>();
            OOB.Documento.Anular.Factura.FichaClienteSaldo _clienteSaldo = null;
            if (!r01.Entidad.IsDocumentoCredito)
            {
                _mCambio = r01.Entidad.Cambio;
                _cntCambio = _mCambio > 0 ? 1 : 0;
                _condPagoIsContado = true;
                //
                _montoVueltoPorEfectivo = r01.Entidad.MontoPorVueltoEnEfectivo;
                _montoVueltoPorDivisa = r01.Entidad.MontoPorVueltoEnDivisa;
                _montoVueltoPorPagoMovil = r01.Entidad.MontoPorVueltoEnPagoMovil;
                _cntDivisaPorVueltoDivisa = r01.Entidad.CantDivisaPorVueltoEnDivisa;
                //
                if (r01.Entidad.AutoReciboCxC != "")
                {
                    var r04 = Sistema.MyData.Documento_Get_MetodosPago_ByIdRecibo(r01.Entidad.AutoReciboCxC);
                    if (r04.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r04.Mensaje);
                        return false;
                    }
                    foreach (var rg in r04.ListaD)
                    {
                        if (rg.descMedioPago.Trim().ToUpper() == "EFECTIVO")
                        {
                            _cntEfectivo += 1;
                            _mEfectivo += rg.montoRecibido;
                        }
                        else if (rg.descMedioPago.Trim().ToUpper() == "DIVISA")
                        {
                            _cntDivisa += rg.cntDivisa;
                            _mDivisa += rg.montoRecibido;
                        }
                        else if (rg.descMedioPago.Trim().ToUpper() == "TARJETA DEBITO")
                        {
                            _cntElectronico += 1;
                            _mElectronico += rg.montoRecibido;
                        }
                        else
                        {
                            _cntOtros += 1;
                            _mOtros += rg.montoRecibido;
                        }
                    }
                }
            }
            else
            {
                _clienteSaldo = new OOB.Documento.Anular.Factura.FichaClienteSaldo()
                {
                    autoCliente = r01.Entidad.AutoCliente,
                    monto = r01.Entidad.MontoDivisa,
                };
            }

            var ficha = new OOB.Documento.Anular.Factura.Ficha()
            {
                idOperador = Sistema.PosEnUso.id,
                autoDocumento = idDoc,
                autoDocCxC = r01.Entidad.AutoDocCxC,
                autoReciboCxC = r01.Entidad.AutoReciboCxC,
                CodigoDocumento = r01.Entidad.Tipo,
                clienteSaldo = _clienteSaldo,
                auditoria = new OOB.Documento.Anular.Factura.FichaAuditoria
                {
                    autoSistemaDocumento = Sistema.ConfiguracionActual.idTipoDocumentoVenta,
                    autoUsuario = Sistema.Usuario.id,
                    codigo = Sistema.Usuario.codigo,
                    estacion = Sistema.EquipoEstacion,
                    motivo = mtv,
                    usuario = Sistema.Usuario.nombre,
                },
                deposito = r01.Entidad.items.Select(s =>
                {
                    var nr = new OOB.Documento.Anular.Factura.FichaDeposito()
                    {
                        AutoDeposito = s.AutoDeposito,
                        AutoProducto = s.AutoProducto,
                        CantUnd = s.CantidadUnd,
                        nombrePrd = s.Nombre,
                    };
                    return nr;
                }).ToList(),
                resumen = new OOB.Documento.Anular.Factura.FichaResumen()
                {
                    idResumen = Sistema.PosEnUso.idResumen,
                    monto = r01.Entidad.Total,
                    mContado = _condPagoIsContado ? r01.Entidad.Total : 0,
                    mCredito = _condPagoIsContado ? 0 : r01.Entidad.Total,
                    cntContado = _condPagoIsContado ? 1 : 0,
                    cntCredito = _condPagoIsContado ? 0 : 1,
                    cntDivisa = _cntDivisa,
                    cntEfectivo = _cntEfectivo,
                    cntElectronico = _cntElectronico,
                    cntOtros = _cntOtros,
                    cntCambio = _cntCambio,
                    mDivisa = _mDivisa,
                    mEfectivo = _mEfectivo,
                    mElectronico = _mElectronico,
                    mOtros = _mOtros,
                    mCambio = _mCambio,
                    //
                    montoVueltoPorEfectivo = _montoVueltoPorEfectivo,
                    montoVueltoPorDivisa = _montoVueltoPorDivisa,
                    montoVueltoPorPagoMovil = _montoVueltoPorPagoMovil,
                    cntDivisaPorVueltoDivisa = _cntDivisaPorVueltoDivisa,
                    //
                    cntFac_Anu = _cntFac_anu,
                    cntNte_Anu = _cntNte_anu,
                    montoFac_Anu = _montoFac_anu,
                    montoNte_Anu = _montoNte_anu,
                },
            };
            var r03 = Sistema.MyData.Documento_Anular_Factura(ficha);
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            return true;
        }
        private bool AnularNotaEntrega_2(string idDoc, string mtv)
        {
            var _condPagoIsContado = false;
            var _cntEfectivo = 0;
            var _cntDivisa = 0;
            var _cntElectronico = 0;
            var _cntOtros = 0;
            var _mDivisa = 0.0m;
            var _mElectronico = 0.0m;
            var _mEfectivo = 0.0m;
            var _mOtros = 0.0m;
            var _cntCambio = 0;
            var _mCambio = 0.0m;
            var _montoVueltoPorEfectivo = 0m;
            var _montoVueltoPorDivisa = 0m;
            var _montoVueltoPorPagoMovil = 0m;
            var _cntDivisaPorVueltoDivisa = 0m;

            var r01 = Sistema.MyData.Documento_GetById(idDoc);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var metPago = new List<OOB.Documento.Entidad.FichaMetodoPago>();
            OOB.Documento.Anular.Factura.FichaClienteSaldo _clienteSaldo = null;
            if (!r01.Entidad.IsDocumentoCredito)
            {
                _mCambio = r01.Entidad.Cambio;
                _cntCambio = _mCambio > 0 ? 1 : 0;
                _condPagoIsContado = true;
                //
                _montoVueltoPorEfectivo = r01.Entidad.MontoPorVueltoEnEfectivo;
                _montoVueltoPorDivisa = r01.Entidad.MontoPorVueltoEnDivisa;
                _montoVueltoPorPagoMovil = r01.Entidad.MontoPorVueltoEnPagoMovil;
                _cntDivisaPorVueltoDivisa = r01.Entidad.CantDivisaPorVueltoEnDivisa;
                //
                if (r01.Entidad.AutoReciboCxC != "")
                {
                    var r04 = Sistema.MyData.Documento_Get_MetodosPago_ByIdRecibo(r01.Entidad.AutoReciboCxC);
                    if (r04.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r04.Mensaje);
                        return false;
                    }
                    foreach (var rg in r04.ListaD)
                    {
                        if (rg.descMedioPago.Trim().ToUpper() == "EFECTIVO")
                        {
                            _cntEfectivo += 1;
                            _mEfectivo += rg.montoRecibido;
                        }
                        else if (rg.descMedioPago.Trim().ToUpper() == "DIVISA")
                        {
                            _cntDivisa += rg.cntDivisa;
                            _mDivisa += rg.montoRecibido;
                        }
                        else if (rg.descMedioPago.Trim().ToUpper() == "TARJETA DEBITO")
                        {
                            _cntElectronico += 1;
                            _mElectronico += rg.montoRecibido;
                        }
                        else
                        {
                            _cntOtros += 1;
                            _mOtros += rg.montoRecibido;
                        }
                    }
                }
            }
            else
            {
                _clienteSaldo = new OOB.Documento.Anular.Factura.FichaClienteSaldo()
                {
                    autoCliente = r01.Entidad.AutoCliente,
                    monto = r01.Entidad.MontoDivisa,
                };
            }

            var ficha = new OOB.Documento.Anular.Factura.Ficha()
            {
                idOperador = Sistema.PosEnUso.id,
                autoDocumento = idDoc,
                autoDocCxC = r01.Entidad.AutoDocCxC,
                autoReciboCxC = r01.Entidad.AutoReciboCxC,
                CodigoDocumento = r01.Entidad.Tipo,
                clienteSaldo = _clienteSaldo,
                auditoria = new OOB.Documento.Anular.Factura.FichaAuditoria
                {
                    autoSistemaDocumento = Sistema.ConfiguracionActual.idTipoDocumentoNotaEntrega,
                    autoUsuario = Sistema.Usuario.id,
                    codigo = Sistema.Usuario.codigo,
                    estacion = Sistema.EquipoEstacion,
                    motivo = mtv,
                    usuario = Sistema.Usuario.nombre,
                },
                deposito = r01.Entidad.items.Select(s =>
                {
                    var nr = new OOB.Documento.Anular.Factura.FichaDeposito()
                    {
                        AutoDeposito = s.AutoDeposito,
                        AutoProducto = s.AutoProducto,
                        CantUnd = s.CantidadUnd,
                        nombrePrd = s.Nombre,
                    };
                    return nr;
                }).ToList(),
                resumen = new OOB.Documento.Anular.Factura.FichaResumen()
                {
                    idResumen = Sistema.PosEnUso.idResumen,
                    monto = r01.Entidad.Total,
                    mContado = _condPagoIsContado ? r01.Entidad.Total : 0,
                    mCredito = _condPagoIsContado ? 0 : r01.Entidad.Total,
                    cntContado = _condPagoIsContado ? 1 : 0,
                    cntCredito = _condPagoIsContado ? 0 : 1,
                    cntDivisa = _cntDivisa,
                    cntEfectivo = _cntEfectivo,
                    cntElectronico = _cntElectronico,
                    cntOtros = _cntOtros,
                    cntCambio = _cntCambio,
                    mDivisa = _mDivisa,
                    mEfectivo = _mEfectivo,
                    mElectronico = _mElectronico,
                    mOtros = _mOtros,
                    mCambio = _mCambio,
                    //
                    montoVueltoPorEfectivo = _montoVueltoPorEfectivo,
                    montoVueltoPorDivisa = _montoVueltoPorDivisa,
                    montoVueltoPorPagoMovil = _montoVueltoPorPagoMovil,
                    cntDivisaPorVueltoDivisa = _cntDivisaPorVueltoDivisa,
                },
            };
            var r03 = Sistema.MyData.Documento_Anular_Factura(ficha);
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }

            return true;
        }
        private void visualizarDoc()
        {
            if (ItemActual == null) return;
            var item = (Lista.data)ItemActual;
            _gestionVisualizar.Inicializa();
            _gestionVisualizar.setDocumento(item);
            _gestionVisualizar.Inicia();
        }
        private bool AplicaParaAnular()
        {
            if (ItemActual == null) return false;
            var it = (Lista.data)ItemActual;
            if (it.IsFiscal)
            {
                Helpers.Msg.Error("DOCUMENTO FISCAL NO PUEDE SER ANULADO");
                return false;
            }
            if (it.IsAnulado)
            {
                Helpers.Msg.Error("Documento Se Encuentra Ya Anulado");
                return false;
            }
            return true;
        }
        private void CargarDocumentos()
        {
            try
            {
                var filtro = new OOB.Documento.Lista.Filtro() { idArqueo = Sistema.PosEnUso.idAutoArqueoCierre };
                var r01 = Sistema.MyData.Documento_Get_Lista(filtro);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (_isModoFiscal)
                {
                    _gestionLista.setData(r01.ListaD.Where(d => d.IsFiscal).ToList());
                }
                else
                {
                    _gestionLista.setData(r01.ListaD);
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        private bool AplicaParaNotaCredito()
        {
            if (ItemActual == null) return false;
            var it = (Lista.data)ItemActual;
            if (it.DocTipo == Lista.Enumerados.enumTipoDoc.Factura || it.DocTipo == Lista.Enumerados.enumTipoDoc.NotaEntrega)
            {
                if (it.IsAnulado)
                {
                    Helpers.Msg.Error("A DOCUMENTO ANULADO NO SE PUEDE APLICAR NOTA DE CREDITO");
                    return false;
                }
                _docAplicarNotaCredito = it;
                return true;
            }
            else
            {
                Helpers.Msg.Error("NO SE PUEDE APLICAR NOTA DE CREDITO A ESTE TIPO DE DOCUMENTO");
                return false;
            }
        }
    }
}