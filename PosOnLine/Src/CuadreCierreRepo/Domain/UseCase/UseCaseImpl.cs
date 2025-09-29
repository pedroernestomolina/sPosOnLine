using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreRepo.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
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
                            g.tasaReferencia,
                            g.signoDoc,
                            g.nroDocAplica
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
                                docSigno = s.Key.signoDoc,
                                nroDocAplica= s.Key.nroDocAplica,
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
                        siglasDoc=s.siglasDoc,
                        signoDoc=s.signoDoc,
                        isAnulado= s.isAnulado,
                        nroDocAplica= s.nroDocAplica,
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