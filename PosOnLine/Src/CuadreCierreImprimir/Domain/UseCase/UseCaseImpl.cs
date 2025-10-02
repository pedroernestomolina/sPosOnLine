using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreImprimir.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public Models.CierreImprimir
            CargarCierreOperador(int idOperador)
        {
            try
            {
                var rstCierre = Sistema.MyData.CuadreCierre_Get_ObtenerCierre_byIdOperador(idOperador);
                if (rstCierre.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(rstCierre.Mensaje);
                }
                var idResumen = rstCierre.Entidad.idResumen;
                var rstCierreResumen = Sistema.MyData.CuadreCierre_Get_ObtenerCierreDataResumen_byIdResumen(idResumen);
                if (rstCierreResumen.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rstCierreResumen.Mensaje);
                }
                var e = rstCierre.Entidad;
                var ss = rstCierreResumen.Entidad.total;
                return new Models.CierreImprimir()
                {
                    dataCierre = new Models.DataCierre()
                   {
                       fechaHoraApertura = e.fechaApertura.ToShortDateString() + ", " + e.horaApertura,
                       fechaHoraCierre = e.fechaCierre.ToShortDateString() + ", " + e.horaCierre,
                       nroCierre = e.nroCierre,
                       terminal = e.terminal,
                       Usuario = e.codigoUsuario + "/" + e.nombreUsuario,
                   },
                    tiposDoc = rstCierreResumen.Entidad.documentos.Select(s => 
                    {
                        return new Models.TipoDocumento()
                        {
                            cntMovActivo = s.cntMovActivo,
                            cntMovAnulado = s.cntMovAnulado,
                            cntMovContado = s.cntMovContado,
                            cntMovCredito = s.cntMovCredito,
                            cntTotalmov = s.cntTotalmov,
                            descDoc = s.descDoc,
                            importeMovActivoMonReferencia = s.importeMovActivoMonReferencia*s.signoDoc,
                            importeMovActMonLocal = s.importeMovActMonLocal * s.signoDoc,
                            importeMovAnuladoMonReferencia = s.importeMovAnuladoMonReferencia ,
                            importeMovContadoMonLocal = s.importeMovContadoMonLocal * s.signoDoc,
                            importeMovContadoMonReferencia = s.importeMovContadoMonReferencia * s.signoDoc,
                            importeMovCreditoMonLocal = s.importeMovCreditoMonLocal * s.signoDoc,
                            importeMovCreditoMonReferencia = s.importeMovCreditoMonReferencia * s.signoDoc,
                            importMovAnuladoMonLocal = s.importMovAnuladoMonLocal ,
                        };
                    }).ToList(),
                    formasPago = rstCierreResumen.Entidad.metPago.Select(s =>
                    {
                        return new Models.FormaPago()
                        {
                            codigoMon = s.codigoMon,
                            codigoMP = s.codigoMP,
                            descMon = s.descMon,
                            descMP = s.descMP,
                            importeMonLocal = s.importeMonLocal,
                            montoSegunSistema = s.montoSegunSistema,
                            montoSegunUsuario = s.montoSegunUsuario,
                            simboloMon = s.simboloMon,
                            tasaFactorPonderadoMon = s.tasaFactorPonderadoMon,
                        };
                    }).ToList(),
                    totales = new Models.Totales()
                    {
                        cntDivisaPorVuelto = ss.cntDivisaPorVuelto,
                        estatusCuadre = ss.estatusCuadre,
                        totalCajaSegunSistemaMonLocal = ss.totalCajaSegunSistemaMonLocal,
                        totalCajaSegunUsuarioMonLocal = ss.totalCajaSegunUsuarioMonLocal,
                        totalCuadreMonLocal = ss.totalCuadreMonLocal,
                        vueltoCambioPorDivisa = ss.vueltoCambioPorDivisa,
                        vueltoCambioPorEfectivo = ss.vueltoCambioPorEfectivo,
                        vueltoCambioPorPagoMovil = ss.vueltoCambioPorPagoMovil,
                    },
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}