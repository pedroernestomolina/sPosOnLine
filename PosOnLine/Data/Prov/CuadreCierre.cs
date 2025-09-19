using PosOnLine.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Prov
{
    public partial class DataPrv: IData
    {
        public OOB.Resultado.Lista<OOB.CuadreCierre.CuadreResumen.MetodoPago>
            CuadreCierre_Get_CuadreResumenMetodoPago_byId(int idResumen)
        {
            var rt = new OOB.Resultado.Lista<OOB.CuadreCierre.CuadreResumen.MetodoPago>();
            //
            try
            {
                var rs = MyData.CuadreCierre_Get_CuadreResumenMetodoPago_byId(idResumen);
                if (rs.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rs.Mensaje);
                }
                if (rs.Lista == null) 
                {
                    throw new Exception("DATA NO CARAGADA");
                }
                var _lst = new List<OOB.CuadreCierre.CuadreResumen.MetodoPago>();
                if (rs.Lista.Count > 0)
                {
                    _lst = rs.Lista.Select(s =>
                    {
                        return new OOB.CuadreCierre.CuadreResumen.MetodoPago()
                        {
                            idMedPago = s.idMedPago,
                            codigoMon = s.codigoMon,
                            codMedPago = s.codMedPago,
                            descMedPago = s.descMedPago,
                            factor = s.factor,
                            ingreso = s.ingreso,
                            montoMonLocal = s.montoMonLocal,
                            simboloMon = s.simboloMon,
                        };
                    }).ToList();
                }
                rt.ListaD = _lst;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public OOB.Resultado.Lista<OOB.CuadreCierre.CuadreResumen.Documento>
            CuadreCierre_Get_CuadreResumenDocumento_byId(int idResumen)
        {
            var rt = new OOB.Resultado.Lista<OOB.CuadreCierre.CuadreResumen.Documento>();
            //
            try
            {
                var rs = MyData.CuadreCierre_Get_CuadreResumenDocumento_byId(idResumen);
                if (rs.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rs.Mensaje);
                }
                if (rs.Lista == null)
                {
                    throw new Exception("DATA NO CARAGADA");
                }
                var _lst = new List<OOB.CuadreCierre.CuadreResumen.Documento>();
                if (rs.Lista.Count > 0)
                {
                    _lst = rs.Lista.Select(s =>
                    {
                        return new OOB.CuadreCierre.CuadreResumen.Documento()
                        {
                            esAnulado = s.anulado.Trim().ToUpper() == "1",
                            cambioVueltoMonLocal = s.cambioVueltoMonLocal,
                            cambioVueltoMonReferencia = s.cambioVueltoMonReferencia,
                            cntDoc = s.cntDoc,
                            codigoDoc = s.codigoDoc,
                            esCredito = s.esCredito.Trim().ToUpper() == "1",
                            montoMonLocal = s.montoMonLocal,
                            montoMonReferencia = s.montoMonReferencia,
                            montoRecibidoMonLocal = s.montoRecibidoMonLocal,
                            montoRecibidoMonReferencia = s.montoRecibidoMonReferencia,
                            varianteDoc = s.varianteDoc,
                        };
                    }).ToList();
                }
                rt.ListaD = _lst;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public OOB.Resultado.FichaEntidad<OOB.CuadreCierre.CuadreResumen.Totales>
            CuadreCierre_Get_CuadreResumenTotalesd_byId(int idResumen)
        {
            var rt = new OOB.Resultado.FichaEntidad<OOB.CuadreCierre.CuadreResumen.Totales>();
            //
            try
            {
                var rs = MyData.CuadreCierre_Get_CuadreResumenTotalesd_byId(idResumen);
                if (rs.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rs.Mensaje);
                }
                if (rs.Entidad == null)
                {
                    throw new Exception("DATA NO CARAGADA");
                }
                var s = rs.Entidad;
                rt.Entidad = new OOB.CuadreCierre.CuadreResumen.Totales()
                {
                    bonoPagoDivisaMonLocal = s.bonoPagoDivisaMonLocal,
                    bonoPagoDivisaMonReferencia = s.bonoPagoDivisaMonReferencia,
                    cambioVueltoMonLocal = s.cambioVueltoMonLocal,
                    cambioVueltoMonReferencia = s.cambioVueltoMonReferencia,
                    cntDivisaEntregada = s.cntDivisaEntregada,
                    cntDoc = s.cntDoc,
                    igtfMonLocal = s.igtfMonLocal,
                    montoMonLocal = s.montoMonLocal,
                    montoMonReferencia = s.montoMonReferencia,
                    montoPendMonReferencia = s.montoPendMonReferencia,
                    montoRecibidoMonLocal = s.montoRecibidoMonLocal,
                    montoRecibidoMonReferencia = s.montoRecibidoMonReferencia,
                    vueltoDadoDivisaMonLocal = s.vueltoDadoDivisaMonLocal,
                    vueltoDadoEfectivo = s.vueltoDadoEfectivo,
                    vueltoPagoMovil = s.vueltoPagoMovil,
                };
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        //
        public OOB.Resultado.Lista<OOB.CuadreCierre.Reportes.PagoDetalle.Ficha> 
            CuadreCierre_Reporte_PagoDetalle(int idResumen)
        {
            var rt = new OOB.Resultado.Lista<OOB.CuadreCierre.Reportes.PagoDetalle.Ficha>();
            //
            try
            {
                var rs = MyData.CuadreCierre_Reporte_PagoDetalle(idResumen);
                if (rs.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rs.Mensaje);
                }
                if (rs.Lista == null)
                {
                    throw new Exception("DATA NO CARAGADA");
                }
                var lst = new List<OOB.CuadreCierre.Reportes.PagoDetalle.Ficha>();
                if (rs.Lista.Count > 0) 
                {
                    lst = rs.Lista.Select(s =>
                    {
                        var nr = new OOB.CuadreCierre.Reportes.PagoDetalle.Ficha()
                        {
                            cambioVueltoMonLocal = s.cambioVueltoMonLocal,
                            cambioVueltoMonReferencia = s.cambioVueltoMonReferencia,
                            ciRif = s.ciRif,
                            codigoDoc = s.codigoDoc,
                            codigoMoneda = s.codigoMoneda,
                            codigoMP = s.codigoMP,
                            descMP = s.descMP,
                            dirFiscal = s.dirFiscal,
                            esAnulado = s.estatusAnulado.Trim().ToUpper() == "1",
                            esCredito = s.estatusCredito.Trim().ToUpper() == "1",
                            fechaEmisionDoc = s.fechaEmisionDoc,
                            hora = s.hora,
                            importeMonLocal = s.importeMonLocal,
                            importeMonReferencia = s.importeMonReferencia,
                            loteNro = s.loteNro,
                            montoIngresado = s.montoIngresado,
                            montoIngresadoMonLocal = s.montoIngresadoMonLocal,
                            montoIngresadoMonReferencia = s.montoIngresadoMonReferencia,
                            totalMontoRecibidoMonLocal = s.totalMontoRecibidoMonLocal,
                            totalMontoRecibidoMonReferencia = s.totalMontoRecibidoMonReferencia,
                            nombreRazonSocial = s.nombreRazonSocial,
                            nroDoc = s.nroDoc,
                            referenciaNro = s.referenciaNro,
                            signoDoc = s.signoDoc,
                            simboloMoneda = s.simboloMoneda,
                            tasaMoneda = s.tasaMoneda,
                            tasaReferencia = s.tasaReferencia,
                            telefonos = s.telefonos,
                            siglasDoc = s.siglasDoc,
                        };
                        return nr;
                    }).ToList();
                    rt.ListaD = lst;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public OOB.Resultado.FichaEntidad<OOB.CuadreCierre.Reportes.PagoResumen.Ficha> 
            CuadreCierre_Reporte_PagoResumen(int idResumen)
        {
            var rt = new OOB.Resultado.FichaEntidad<OOB.CuadreCierre.Reportes.PagoResumen.Ficha>();
            //
            try
            {
                var rs = MyData.CuadreCierre_Reporte_PagoResumen(idResumen);
                if (rs.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rs.Mensaje);
                }
                if (rs.Entidad == null)
                {
                    throw new Exception("DATA NO CARAGADA");
                }
                if (rs.Entidad.credito == null) 
                {
                    throw new Exception("DATA NO CARAGADA");
                }
                if (rs.Entidad.ListaMetodosPago == null) 
                {
                    throw new Exception("DATA NO CARAGADA");
                }
                var lst = new List<OOB.CuadreCierre.Reportes.PagoResumen.Metodo>();
                if (rs.Entidad.ListaMetodosPago.Count > 0)
                {
                    lst = rs.Entidad.ListaMetodosPago.Select(s =>
                    {
                        var nr = new OOB.CuadreCierre.Reportes.PagoResumen.Metodo()
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
                        return nr;
                    }).ToList();
                    rt.Entidad = new OOB.CuadreCierre.Reportes.PagoResumen.Ficha()
                    {
                        cntMovCredito = rs.Entidad.credito.cntMovCredito,
                        montoCreditoMonLocal = rs.Entidad.credito.montoCreditoMonLocal,
                        montoCreditoMonReferencia = rs.Entidad.credito.montoCreditoMonReferencia,
                        montoVueltoMonLocal = rs.Entidad.montoVueltoMonLocal,
                        metodosUsado = lst,
                    };
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public OOB.Resultado.Lista<OOB.CuadreCierre.Reportes.VentaCredito.Ficha> 
            CuadreCierre_Reporte_VentaCredito(int idResumen)
        {
            var rt = new OOB.Resultado.Lista<OOB.CuadreCierre.Reportes.VentaCredito.Ficha>();
            //
            try
            {
                var rs = MyData.CuadreCierre_Reporte_VentaCredito (idResumen);
                if (rs.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rs.Mensaje);
                }
                if (rs.Lista == null)
                {
                    throw new Exception("DATA NO CARAGADA");
                }
                var lst = new List<OOB.CuadreCierre.Reportes.VentaCredito.Ficha>();
                if (rs.Lista.Count > 0)
                {
                    lst = rs.Lista.Select(s =>
                    {
                        var nr = new OOB.CuadreCierre.Reportes.VentaCredito.Ficha()
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
                        return nr;
                    }).ToList();
                    rt.ListaD = lst;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public OOB.Resultado.Lista<OOB.CuadreCierre.Reportes.CambiosVuelto.Ficha> 
            CuadreCierre_Reporte_CambiosVueltoEntregado(int idResumen)
        {
            var rt = new OOB.Resultado.Lista<OOB.CuadreCierre.Reportes.CambiosVuelto.Ficha>();
            //
            try
            {
                var rs = MyData.CuadreCierre_Reporte_CambiosVueltoEntregado(idResumen);
                if (rs.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rs.Mensaje);
                }
                if (rs.Lista == null)
                {
                    throw new Exception("DATA NO CARAGADA");
                }
                var lst = new List<OOB.CuadreCierre.Reportes.CambiosVuelto.Ficha>();
                if (rs.Lista.Count > 0)
                {
                    lst = rs.Lista.Select(s =>
                    {
                        var nr = new OOB.CuadreCierre.Reportes.CambiosVuelto.Ficha()
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
                        return nr;
                    }).ToList();
                    rt.ListaD = lst;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public OOB.Resultado.Lista<OOB.CuadreCierre.Reportes.PagoMovil.Ficha> 
            CuadreCierre_Reporte_PagoMovilPorRealizar(int idResumen)
        {
            var rt = new OOB.Resultado.Lista<OOB.CuadreCierre.Reportes.PagoMovil.Ficha>();
            //
            try
            {
                var rs = MyData.CuadreCierre_Reporte_PagoMovil(idResumen);
                if (rs.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rs.Mensaje);
                }
                if (rs.Lista == null)
                {
                    throw new Exception("DATA NO CARAGADA");
                }
                var lst = new List<OOB.CuadreCierre.Reportes.PagoMovil.Ficha>();
                if (rs.Lista.Count > 0)
                {
                    lst = rs.Lista.Select(s =>
                    {
                        var nr = new OOB.CuadreCierre.Reportes.PagoMovil.Ficha()
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
                        return nr;
                    }).ToList();
                    rt.ListaD = lst;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
    }
}