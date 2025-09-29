using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdmAnularDoc.vm
{
    public class AnularDocImpl: IAnularDoc
    {
        private Domain.ReglaNegocio.IRule _rule;
        private Domain.UseCase.IUseCase _uc;
        private Anular.IAnular _vmAnular;
        //
        public AnularDocImpl()
        {
            _rule = new Domain.ReglaNegocio.RuleImpl();
            _uc = new Domain.UseCase.UseCaseImpl();
            _vmAnular = new Anular.ImpAnular();
        }
        public void AnularDoc(string idDoc)
        {
            try
            {
                if (_rule.Permiso()) 
                {
                    var _dataAnular= _uc.RecopilarDataDocumentoAnular(idDoc);
                    _rule.ParaAnularDoc(_dataAnular);
                    _vmAnular.Inicializa();
                    _vmAnular.Inicia();
                    if (_vmAnular.ProcesarIsOK) 
                    {
                        if (Helpers.Msg.Procesar("Estas Seguro De Anular Este Documento ?"))
                        {
                            var rt = false;
                            var motivo = _vmAnular.GetMotivo;
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
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        //
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
            switch (r01.Entidad.cuerpo.Tipo)
            {
                case "01":
                    _cntFac_anu = 1;
                    _montoFac_anu = r01.Entidad.cuerpo.Total;
                    break;
                case "04":
                    _cntNte_anu = 1;
                    _montoNte_anu = r01.Entidad.cuerpo.Total;
                    break;
            }
            var metPago = new List<OOB.Documento.Entidad.FichaMetodoPago>();
            OOB.Documento.Anular.Factura.FichaClienteSaldo _clienteSaldo = null;
            if (!r01.Entidad.cuerpo.IsDocumentoCredito)
            {
                _mCambio = r01.Entidad.cuerpo.Cambio;
                _cntCambio = _mCambio > 0 ? 1 : 0;
                _condPagoIsContado = true;
                //
                _montoVueltoPorEfectivo = r01.Entidad.cuerpo.MontoPorVueltoEnEfectivo;
                _montoVueltoPorDivisa = r01.Entidad.cuerpo.MontoPorVueltoEnDivisa;
                _montoVueltoPorPagoMovil = r01.Entidad.cuerpo.MontoPorVueltoEnPagoMovil;
                _cntDivisaPorVueltoDivisa = r01.Entidad.cuerpo.CantDivisaPorVueltoEnDivisa;
                //
                if (r01.Entidad.cuerpo.AutoReciboCxC != "")
                {
                    /*
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
                     */
                }
            }
            else
            {
                _clienteSaldo = new OOB.Documento.Anular.Factura.FichaClienteSaldo()
                {
                    autoCliente = r01.Entidad.cuerpo.AutoCliente,
                    monto = r01.Entidad.cuerpo.MontoDivisa,
                };
            }
            //
            var ficha = new OOB.Documento.Anular.Factura.Ficha()
            {
                idOperador = Sistema.PosEnUso.id,
                autoDocumento = idDoc,
                autoDocCxC = r01.Entidad.cuerpo.AutoDocCxC,
                autoReciboCxC = r01.Entidad.cuerpo.AutoReciboCxC,
                CodigoDocumento = r01.Entidad.cuerpo.Tipo,
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
                    monto = r01.Entidad.cuerpo.Total,
                    mContado = _condPagoIsContado ? r01.Entidad.cuerpo.Total : 0,
                    mCredito = _condPagoIsContado ? 0 : r01.Entidad.cuerpo.Total,
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

    }
}
