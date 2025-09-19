using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public Domain.Models.DataResumenRecolectada
            CuadreResumen(int id)
        {
            var rt = new Domain.Models.DataResumenRecolectada();
            //
            try
            {
                var rsMetPago = Sistema.MyData.CuadreCierre_Get_CuadreResumenMetodoPago_byId(id);
                if (rsMetPago.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rsMetPago.Mensaje);
                }
                var rsDocumento = Sistema.MyData.CuadreCierre_Get_CuadreResumenDocumento_byId(id);
                if (rsDocumento.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rsDocumento.Mensaje);
                }
                var rsTotales = Sistema.MyData.CuadreCierre_Get_CuadreResumenTotalesd_byId(id);
                if (rsTotales.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rsTotales.Mensaje);
                }

                var _lstMP = rsMetPago.ListaD.Select(s =>
                {
                    var nr = new Domain.Models.MetodoPagoUso()
                    {
                        idMP = s.idMedPago,
                        codigoMon = s.codigoMon,
                        codigoMP = s.codMedPago,
                        descripcionMP = s.descMedPago,
                        simboloMon = s.simboloMon,
                        tasaFactorPonderado = Math.Round(s.factor, 4, MidpointRounding.AwayFromZero),  
                        totalMontoRecibido = s.ingreso,
                        totalMontoRecibidoMonLocal = s.montoMonLocal,
                    };
                    return nr;
                }).ToList();
                rt.setMetodosPagoUsados(_lstMP);

                var _lstDoc = rsDocumento.ListaD.Select(s =>
                {
                    var _nombreDoc = "";
                    var _atributo = "";
                    switch (s.codigoDoc.Trim().ToUpper())
                    {
                        case "01":
                            {
                                _nombreDoc = "FACTURA";
                                break;
                            }
                        case "03":
                            {
                                _nombreDoc = "NOTA/CREDITO";
                                break;
                            }
                        default:
                            {
                                _nombreDoc = "NO DEFINIDO";
                                break;
                            }
                    }
                    switch (s.varianteDoc.Trim().ToUpper())
                    {
                        case "":
                            {
                                _atributo = "";
                                break;
                            }
                        case "F":
                            {
                                _atributo = "FISCAL";
                                break;
                            }
                        case "N":
                            {
                                _atributo = "CHIMBA";
                                break;
                            }
                        default:
                            {
                                _atributo  = "NO DEFINIDO";
                                break;
                            }
                    }
                    var nr = new Domain.Models.TipoDocUso()
                    {
                        atributoDoc= _atributo,
                        cambioVueltoMonLocal = s.cambioVueltoMonLocal,
                        cambioVueltoMonReferencia = s.cambioVueltoMonReferencia,
                        cntDoc = s.cntDoc,
                        codigoDoc = s.codigoDoc,
                        esAnulado = s.esAnulado,
                        esCredito = s.esCredito,
                        montoMonLocal = s.montoMonLocal,
                        montoMonReferencia = s.montoMonReferencia,
                        montoRecibidoMonLocal = s.montoRecibidoMonLocal,
                        montoRecibidoMonReferencia = s.montoRecibidoMonReferencia,
                        nombreDoc = _nombreDoc,
                    };
                    return nr;
                }).ToList();
                rt.setDocumentosEmitidos(_lstDoc);

                var ss = rsTotales.Entidad;
                rt.setTotalRecogido(
                    new Domain.Models.TotalesRecogido()
                {
                    bonoPagoDivisaMonLocal = ss.bonoPagoDivisaMonLocal,
                    bonoPagoDivisaMonReferencia = ss.bonoPagoDivisaMonReferencia,
                    cambioVueltoMonLocal = ss.cambioVueltoMonLocal,
                    cambioVueltoMonReferencia = ss.cambioVueltoMonReferencia,
                    cntDivisaEntregada = ss.cntDivisaEntregada,
                    cntDoc = ss.cntDoc,
                    igtfMonLocal = ss.igtfMonLocal,
                    montoMonLocal = ss.montoMonLocal,
                    montoMonReferencia = ss.montoMonReferencia,
                    montoPendMonReferencia = ss.montoPendMonReferencia,
                    montoRecibidoMonLocal = ss.montoRecibidoMonLocal,
                    montoRecibidoMonReferencia = ss.montoRecibidoMonReferencia,
                    vueltoDadoDivisaMonLocal = ss.vueltoDadoDivisaMonLocal,
                    vueltoDadoEfectivo = ss.vueltoDadoEfectivo,
                    vueltoPagoMovil = ss.vueltoPagoMovil,
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            //
            return rt;
        }
        public List<Domain.Models.RepoPagoDetalleEnc>
            ReportePagoDetalle(int id)
        {
            var rt = new List<Domain.Models.RepoPagoDetalleEnc>();
            //
            try
            {
                var result = Sistema.MyData.CuadreCierre_Reporte_PagoDetalle(id);
                if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(result.Mensaje);
                }
                var lstPlana = result.ListaD.ToList();
                var lstPadre = lstPlana.
                    GroupBy(g =>
                        new
                        {
                            g.nroDoc,
                            g.fechaEmisionDoc,
                            g.hora,
                            g.codigoDoc,
                            g.nombreRazonSocial,
                            g.ciRif,
                            g.dirFiscal,
                            g.telefonos,
                            g.esAnulado,
                            g.esCredito,
                            g.importeMonLocal,
                            g.importeMonReferencia,
                            g.cambioVueltoMonLocal,
                            g.cambioVueltoMonReferencia,
                            g.siglasDoc,
                            g.tasaReferencia
                        }).
                        Select(s =>
                            new Models.RepoPagoDetalleEnc()
                            {
                                cliCiRif = s.Key.ciRif,
                                cliDir = s.Key.dirFiscal,
                                cliNombre = s.Key.nombreRazonSocial,
                                cliTelf = s.Key.telefonos,
                                docCambioDar = s.Key.cambioVueltoMonLocal,
                                docFecha = s.Key.fechaEmisionDoc,
                                docHora = s.Key.hora,
                                docMonto = s.Key.importeMonLocal,
                                docNumero = s.Key.nroDoc,
                                docSiglas = s.Key.siglasDoc,
                                isAnulado = s.Key.esAnulado,
                                isCredito = s.Key.esCredito,
                                tasaReferencia = s.Key.tasaReferencia,
                                pagos = s.Select(det =>
                                    new Models.RepoPagoDetalleDet()
                                    {
                                        codigoMoneda = det.codigoMoneda,
                                        codigoMP = det.codigoMP,
                                        descMP = det.descMP,
                                        loteNro = det.loteNro,
                                        montoRecibidoMonReferencia = det.montoIngresadoMonReferencia,
                                        montoRecibioMonLocal = det.montoIngresadoMonLocal,
                                        referenciaNro = det.referenciaNro,
                                        simboloMoneda = det.simboloMoneda,
                                        tasaMoneda = det.tasaMoneda,
                                        montoRecibido = det.montoIngresado,
                                    }).ToList()
                            }).ToList();
                rt = lstPadre;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
            //
            return rt;
        }
        public Models.RepoPagoResumen 
            ReportePagoResumen(int id)
        {
            var rt = new Domain.Models.RepoPagoResumen();
            //
            try
            {
                var result = Sistema.MyData.CuadreCierre_Reporte_PagoResumen(id);
                if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(result.Mensaje);
                }
                rt = new Models.RepoPagoResumen()
                {
                    cntMovCredito = result.Entidad.cntMovCredito,
                    montoCreditoMonLocal = result.Entidad.montoCreditoMonLocal,
                    montoCreditoMonReferencia = result.Entidad.montoCreditoMonReferencia,
                    montoVueltoMonLocal = result.Entidad.montoVueltoMonLocal,
                    metodo = result.Entidad.metodosUsado.Select(s =>
                    {
                        return new Models.RepoPagoResumenMetodo()
                        {
                            cntMov = s.cntMov,
                            codigoMoneda = s.codigoMoneda,
                            codigoMP = s.codigoMP,
                            descMP = s.descMP,
                            montoRecibidoMonLocal = s.montoRecibidoMonLocal,
                            recibido = s.recibido,
                            simboloMoneda = s.simboloMoneda,
                            tasaReferencia = s.tasaReferencia,
                            tasaRespectoMonReferencia = s.tasaRespectoMonReferencia,
                        };
                    }).ToList(),
                };
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
            //
            return rt;
        }
        public List<Models.RepoVentaCredito>
            ReporteVentaCredito(int id)
        {
            var rt = new List<Domain.Models.RepoVentaCredito>();
            //
            try
            {
                var result = Sistema.MyData.CuadreCierre_Reporte_VentaCredito(id);
                if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(result.Mensaje);
                }
                rt = result.ListaD.Select(s =>
                {
                    return new Domain.Models.RepoVentaCredito()
                    {
                        bonoPagoDivisaMonReferencia = s.bonoPagoDivisaMonReferencia,
                        ciRifDoc = s.ciRifDoc,
                        entidadDoc = s.entidadDoc,
                        fechaEmisionDoc = s.fechaEmisionDoc,
                        importeMonLocal = s.importeMonLocal,
                        importeMonReferencia = s.importeMonReferencia,
                        montoPendCxcMonReferencia = s.montoPendCxcMonReferencia,
                        nroDoc = s.nroDoc,
                    };
                }).ToList();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
            //
            return rt;
        }
        public List<Models.RepoCambiosVuelto> 
            ReporteCambiosVueltoEntregado(int id)
        {
            var rt = new List<Domain.Models.RepoCambiosVuelto>();
            //
            try
            {
                var result = Sistema.MyData.CuadreCierre_Reporte_CambiosVueltoEntregado(id);
                if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(result.Mensaje);
                }
                rt = result.ListaD.Select(s =>
                {
                    return new Domain.Models.RepoCambiosVuelto()
                    {
                        ciRifDoc = s.ciRifDoc,
                        entidadDoc = s.entidadDoc,
                        fechaEmisionDoc = s.fechaEmisionDoc,
                        importeMonLocal = s.importeMonLocal,
                        importeMonReferencia = s.importeMonReferencia,
                        nroDoc = s.nroDoc,
                        cambioVueltoMonLocal = s.cambioVueltoMonLocal,
                        cntDivisaEntregada = s.cntDivisaEntregada,
                        dirFiscal = s.dirFiscal,
                        telefono = s.telefono,
                        vueltoDivisaMonLocal = s.vueltoDivisaMonLocal,
                        vueltoEfectivoMonLocal = s.vueltoEfectivoMonLocal,
                        vueltoPagoMovilMonLocal = s.vueltoPagoMovilMonLocal,
                        horaDoc= s.horaDoc,
                        siglasDoc= s.siglasDoc
                    };
                }).ToList();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
            //
            return rt;
        }
        public List<Models.RepoPagoMovil> 
            ReportePagoMovilPorRealizar(int id)
        {
            var rt = new List<Domain.Models.RepoPagoMovil>();
            //
            try
            {
                var result = Sistema.MyData.CuadreCierre_Reporte_PagoMovilPorRealizar(id);
                if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(result.Mensaje);
                }
                rt = result.ListaD.Select(s =>
                {
                    return new Domain.Models.RepoPagoMovil()
                    {
                        agenciaDestino = s.agenciaDestino,
                        ciRifDestinoPM = s.ciRifDestinoPM,
                        ciRifEntidad = s.ciRifEntidad,
                        entidad = s.entidad,
                        entidadDestinoPM = s.entidadDestinoPM,
                        fechaEmisionDoc = s.fechaEmisionDoc,
                        montoPM = s.montoPM,
                        nroDoc = s.nroDoc,
                        telefonoDestinoPM = s.telefonoDestinoPM,
                    };
                }).ToList();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
            //
            return rt;
        }
    }
}