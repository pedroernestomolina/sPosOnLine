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
                    nr.setCargarMontoSegunSistema(s.ingreso);
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
                        signoDoc= s.signoDoc,
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
    }
}