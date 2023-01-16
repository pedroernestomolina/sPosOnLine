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


        private bool _notaCreditoIsOk;
        private Anular.IAnular _gestionAnular;
        private Visualizar.Gestion _gestionVisualizar;


        public string TotItems { get { return _gestionLista.TotItems; } }
        private Lista.Gestion _gestionLista;
        public bool NotaCreditoIsOk { get { return _notaCreditoIsOk; } }
        public Lista.data DocAplicaNotaCredito { get { return _gestionLista.DocAplicarNotaCredito; } }
        public BindingSource Source { get { return _gestionLista.Source; } }
        public bool IsTickeraOk { get { return _gestionLista.IsTickeraOk; } }
        public Helpers.Imprimir.IDocumento ImprimirDoc { get { return _gestionLista.ImprimirDoc; } }


        public Gestion()
        {
            _notaCreditoIsOk = false;
            _gestionVisualizar = new Visualizar.Gestion();
            _gestionLista = new Lista.Gestion();
            _gestionLista.setVisualizar(_gestionVisualizar);
        }


        public void Inicializa() 
        {
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

        private bool CargarData()
        {
            var rt = true;

            var filtro = new OOB.Documento.Lista.Filtro() { idArqueo = Sistema.PosEnUso.idAutoArqueoCierre };
            var r01 = Sistema.MyData.Documento_Get_Lista(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _gestionLista.setData(r01.ListaD);

            return rt;
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
            if (_gestionLista.AplicaParaNotaCredito()) 
            {
                if (Helpers.PassWord.PassWIsOk(Sistema.FuncionAdmNotaCredito)) 
                {
                    _notaCreditoIsOk = true;
                }
            }
        }

        private bool _anularDocumentoIsOk;
        public void AnularDocumento()
        {
            _anularDocumentoIsOk = false;
            if (_gestionLista.AplicaParaAnular())
            {
                if (Helpers.PassWord.PassWIsOk(Sistema.FuncionAdmAnularDocumento))
                {
                    _gestionAnular.Inicializa();
                    _gestionAnular.Inicia();
                    if (_gestionAnular.ProcesarIsOK)
                    {
                        var msg = MessageBox.Show("Estas Seguro De Anular Este Documento ?", "** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (msg == DialogResult.No)
                        {
                            return;
                        }
                        var motivo = _gestionAnular.GetMotivo;
                        var rt = false;
                        switch (_gestionLista.DocAplicaParaAulacion.DocTipo)
                        {
                            case Lista.data.enumTipoDoc.NotaEntrega:
                                rt = AnularNotaEntrega(_gestionLista.DocAplicaParaAulacion.idDocumento,motivo);
                                break;
                            case Lista.data.enumTipoDoc.NotaCredito:
                                rt = AnularNotaCredito(_gestionLista.DocAplicaParaAulacion.idDocumento,motivo);
                                break;
                            case Lista.data.enumTipoDoc.Factura:
                                rt = AnularFactura(_gestionLista.DocAplicaParaAulacion.idDocumento,motivo);
                                break;
                        }
                        if (rt)
                        {
                            _anularDocumentoIsOk = rt;
                            _gestionLista.setAnularDoc();
                        }
                    }
                }
            }
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
            OOB.Documento.Anular.NotaCredito.FichaClienteSaldo _clienteSaldo=null;
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
            var _condPagoIsContado=false;
            var _cntEfectivo = 0;
            var _cntDivisa = 0;
            var _cntElectronico = 0;
            var _cntOtros = 0;
            var _mDivisa=0.0m;
            var _mElectronico=0.0m;
            var _mEfectivo=0.0m;
            var _mOtros=0.0m;
            var _cntCambio=0;
            var _mCambio=0.0m;
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
            OOB.Documento.Anular.Factura.FichaClienteSaldo _clienteSaldo=null;
            if (!r01.Entidad.IsDocumentoCredito)
            {
                _mCambio = r01.Entidad.Cambio;
                _cntCambio = _mCambio > 0 ? 1 : 0;
                _condPagoIsContado = true;
                //
                _montoVueltoPorEfectivo = r01.Entidad.MontoPorVueltoEnEfectivo;
                _montoVueltoPorDivisa = r01.Entidad.MontoPorVueltoEnDivisa;
                _montoVueltoPorPagoMovil =r01.Entidad.MontoPorVueltoEnPagoMovil;
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
                idOperador=Sistema.PosEnUso.id,
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

        public void setGestionAnular(Anular.IAnular ctr)
        {
            _gestionAnular = ctr;
        }

        public void ImprimirDocumento()
        {
            _gestionLista.ImprimirDocumento();
        }

        public void Imprimir(System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (ImprimirDoc!=null)
            {
                if (ImprimirDoc.IsModoTicket) 
                {
                    ImprimirDoc.setControlador(e);
                    ImprimirDoc.setEmpresa(Sistema.DatosEmpresa);
                    ImprimirDoc.ImprimirDoc();
                }
            }
        }

        public void VisualizarDocumento()
        {
            _gestionLista.VisualizarDocumento();
        }


        //
        public bool AnularDocumentoIsOk { get { return _anularDocumentoIsOk; } }
    }
}