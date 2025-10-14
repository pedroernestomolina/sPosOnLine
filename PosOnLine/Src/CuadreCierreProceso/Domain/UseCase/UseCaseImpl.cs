using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreProceso.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public void CerrarPos(Models.CierreFicha ficha)
        {
            try
            {
                var t = ficha.cierreTotal;
                var fichaOOB = new OOB.CuadreCierre.CierrePos.Ficha()
                {
                    idResumen = ficha.idResumen,
                    codigoSucursal = Sistema.Sucursal.codigo,
                    totales = new OOB.CuadreCierre.CierrePos.Total()
                    {
                        cntDivisaPorVuelto = t.cntDivisaPorVuelto,
                        estatusCuadre = t.estatusCuadre,
                        totalCuadreMonLocal = t.totalCuadreMonLocal,
                        totalCajaSegunSistemaMonLocal = t.totalCajaSegunSistemaMonLocal,
                        totalCajaSegunUsuarioMonLocal = t.totalCajaSegunUsuarioMonLocal,
                        vueltoCambioPorDivisa = t.vueltoCambioPorDivisa,
                        vueltoCambioPorEfectivo = t.vueltoCambioPorEfectivo,
                        vueltoCambioPorPagoMovil = t.vueltoCambioPorPagoMovil,
                    },
                    documentos = ficha.cierrePorDoc.Select(s =>
                    {
                        return new OOB.CuadreCierre.CierrePos.Documento()
                        {
                            cntMovActivo = s.cntMovActivo,
                            cntMovAnulado = s.cntMovAnulado,
                            cntMovContado = s.cntMovContado,
                            cntMovCredito = s.cntMovCredito,
                            cntTotalmov = s.cntTotalmov,
                            codigoDoc = s.codigoDoc,
                            descDoc = s.descDoc,
                            importeMovActivoMonReferencia = s.importeMovActivoMonReferencia,
                            importeMovActMonLocal = s.importeMovActMonLocal,
                            importeMovAnuladoMonReferencia = s.importeMovAnuladoMonReferencia,
                            importeMovContadoMonReferencia = s.importeMovContadoMonReferencia,
                            importeMovCreditoMonLocal = s.importeMovCreditoMonLocal,
                            importeMovCreditoMonReferencia = s.importeMovCreditoMonReferencia,
                            importMovAnuladoMonLocal = s.importMovAnuladoMonLocal,
                            importteMovContadoMonLocal = s.importteMovContadoMonLocal,
                            siglasDoc = s.siglasDoc,
                            signoDoc = s.signoDoc,
                            varianteDoc = s.varianteDoc,
                        };
                    }).ToList(),
                    metPago = ficha.cierrePorMetPago.Select(s =>
                    {
                        return new OOB.CuadreCierre.CierrePos.MetodoPago()
                        {
                            codigoMon = s.codigoMon,
                            codigoMP = s.codigoMP,
                            descMon = "",
                            descMP = s.descMP,
                            importeMonLocal = s.importeMonLocal,
                            montoSegunSistema = s.montoSegunSistema,
                            montoSegunUsuario = s.montoSegunUsuario,
                            simboloMon = s.simboloMon,
                            tasaFactorPonderadoMon = s.tasaFactorPonderadoMon,
                        };
                    }).ToList(),
                };
                fichaOOB.MetodoViejo = new OOB.Pos.Cerrar.Ficha()
                {
                    idOperador = Sistema.PosEnUso.id,
                    estatus = "C",
                    arqueo = new OOB.Pos.Cerrar.FichaArqueo()
                    {
                        autoArqueo = Sistema.PosEnUso.idAutoArqueoCierre,
                    },
                };
                var result = Sistema.MyData.CuadreCierre_CerrarPos(fichaOOB);
                if (result.Result== OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(result.Mensaje);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}