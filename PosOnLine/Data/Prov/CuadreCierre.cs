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
                            factor = s.factor.HasValue?s.factor.Value: 0m,
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
                            signoDoc= s.signoDoc,
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
                    bonoPagoDivisaMonLocal = s.bonoPagoDivisaMonLocal.HasValue ? s.bonoPagoDivisaMonLocal.Value: 0m ,
                    bonoPagoDivisaMonReferencia = s.bonoPagoDivisaMonReferencia.HasValue ? s.bonoPagoDivisaMonReferencia.Value: 0m,
                    cambioVueltoMonLocal = s.cambioVueltoMonLocal.HasValue ? s.cambioVueltoMonLocal.Value: 0m,
                    cambioVueltoMonReferencia = s.cambioVueltoMonReferencia.HasValue ? s.cambioVueltoMonReferencia.Value: 0m,
                    cntDivisaEntregada = s.cntDivisaEntregada.HasValue ? s.cntDivisaEntregada.Value: 0,
                    cntDoc = s.cntDoc,
                    igtfMonLocal = s.igtfMonLocal.HasValue? s.igtfMonLocal.Value: 0m,
                    montoMonLocal = s.montoMonLocal.HasValue? s.montoMonLocal.Value:0m ,
                    montoMonReferencia = s.montoMonReferencia.HasValue? s.montoMonReferencia.Value:0m,
                    montoPendMonReferencia = s.montoPendMonReferencia.HasValue? s.montoPendMonReferencia.Value:0m,
                    montoRecibidoMonLocal = s.montoRecibidoMonLocal.HasValue? s.montoRecibidoMonLocal.Value:0m,
                    montoRecibidoMonReferencia = s.montoRecibidoMonReferencia.HasValue? s.montoRecibidoMonReferencia.Value: 0m,
                    vueltoDadoDivisaMonLocal = s.vueltoDadoDivisaMonLocal.HasValue? s.vueltoDadoDivisaMonLocal.Value:0m,
                    vueltoDadoEfectivo = s.vueltoDadoEfectivo.HasValue? s.vueltoDadoEfectivo.Value:0m,
                    vueltoPagoMovil = s.vueltoPagoMovil.HasValue? s.vueltoPagoMovil.Value:0m,
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
                            nroDocAplica= s.nroDocAplica,
                        };
                        return nr;
                    }).ToList();
                }
                rt.ListaD = lst;
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
                }
                rt.Entidad = new OOB.CuadreCierre.Reportes.PagoResumen.Ficha()
                {
                    cntMovCredito = rs.Entidad.credito.cntMovCredito,
                    montoCreditoMonLocal = rs.Entidad.credito.montoCreditoMonLocal.HasValue ? rs.Entidad.credito.montoCreditoMonLocal.Value : 0m,
                    montoCreditoMonReferencia = rs.Entidad.credito.montoCreditoMonReferencia.HasValue ? rs.Entidad.credito.montoCreditoMonReferencia.Value : 0m,
                    montoVueltoMonLocal = rs.Entidad.montoVueltoMonLocal.HasValue ? rs.Entidad.montoVueltoMonLocal.Value : 0m,
                    metodosUsado = lst,
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
                            siglasDoc = s.siglasDoc,
                            signoDoc = s.signoDoc,
                            isAnulado = s.estatusAnulado.Trim().ToUpper()=="1",
                            nroDocAplica= s.nroDocAplica,
                        };
                        return nr;
                    }).ToList();
                }
                rt.ListaD = lst;
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
                }
                rt.ListaD = lst;
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
                }
                rt.ListaD = lst;
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
        public OOB.Resultado.FichaEntidad<int> 
            CuadreCierre_CerrarPos(OOB.CuadreCierre.CierrePos.Ficha ficha)
        {
            var rt = new OOB.Resultado.FichaEntidad<int> ();
            //
            try
            {
                var t = ficha.totales;
                var fichaDTO = new DtoLibPos.CuadreCierre.CerrarPos.Ficha()
                {
                    estatus = ficha.MetodoViejo.estatus,
                    idOperador = ficha.MetodoViejo.idOperador,
                    idResumen = ficha.idResumen,
                    documentos = ficha.documentos.Select(s =>
                    {
                        return new DtoLibPos.CuadreCierre.CerrarPos.Documento()
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
                    metPago = ficha.metPago.Select(s =>
                    {
                        return new DtoLibPos.CuadreCierre.CerrarPos.MetodoPago()
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
                    totales = new DtoLibPos.CuadreCierre.CerrarPos.Total()
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
                    arqueoCerrar = new DtoLibPos.CuadreCierre.CerrarPos.Arqueo()
                    {
                        autoArqueo = ficha.MetodoViejo.arqueo.autoArqueo,
                        cierreFtp = ficha.MetodoViejo.arqueo.cierreFtp,
                    }
                };
                var rst = MyData.CuadreCierre_CerrarPos(fichaDTO);
                if (rst.Result == DtoLib.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(rst.Mensaje);
                }
                rt.Entidad = rst.Entidad;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public OOB.Resultado.FichaEntidad<OOB.CuadreCierre.ObtenerCierre.Ficha> 
            CuadreCierre_Get_ObtenerCierre_byIdOperador(int id)
        {
            var rt = new OOB.Resultado.FichaEntidad<OOB.CuadreCierre.ObtenerCierre.Ficha>();
            //
            try
            {
                var rst = MyData.CuadreCierre_Get_ObtenerCierre_byIdOperador(id);
                if (rst.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst.Mensaje);
                }
                if (rst.Entidad == null)
                {
                    throw new Exception("PROBLEMA AL CARGAR DATA");
                }
                var s = rst.Entidad;
                rt.Entidad = new OOB.CuadreCierre.ObtenerCierre.Ficha()
                {
                    codigoSucursal = s.codigoSucursal,
                    codigoUsuario = s.codigoUsuario,
                    isCerradoOperador = s.estatusOperador.Trim().ToUpper()=="C",
                    fechaApertura = s.fechaApertura,
                    fechaCierre = s.fechaCierre,
                    horaApertura = s.horaApertura,
                    horaCierre = s.horaCierre,
                    idArqueo = s.idArqueo,
                    idResumen = s.idResumen,
                    nombreUsuario = s.nombreUsuario,
                    nroCierre = s.nroCierre.ToString().PadLeft(6,'0'),
                    terminal = s.terminal,
                    idOperador = s.idOperador,
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
        public OOB.Resultado.Lista<OOB.CuadreCierre.ObtenerCierre.Ficha> 
            CuadreCierre_Get_ListaCierre()
        {
            var rt = new OOB.Resultado.Lista<OOB.CuadreCierre.ObtenerCierre.Ficha>();
            //
            try
            {
                var rs = MyData.CuadreCierre_Get_ListaCierre();
                if (rs.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rs.Mensaje);
                }
                if (rs.Lista == null)
                {
                    throw new Exception("DATA NO CARAGADA");
                }
                var lst = new List<OOB.CuadreCierre.ObtenerCierre.Ficha>();
                if (rs.Lista.Count > 0)
                {
                    lst = rs.Lista.Select(s =>
                    {
                        var nr = new OOB.CuadreCierre.ObtenerCierre.Ficha()
                        {
                            codigoSucursal = s.codigoSucursal,
                            codigoUsuario = s.codigoUsuario,
                            isCerradoOperador = s.estatusOperador.Trim().ToUpper()=="C",
                            fechaApertura = s.fechaApertura,
                            fechaCierre = s.fechaCierre,
                            horaApertura = s.horaApertura,
                            horaCierre = s.horaCierre,
                            idArqueo = s.idArqueo,
                            idResumen = s.idResumen,
                            nombreUsuario = s.nombreUsuario,
                            nroCierre = s.nroCierre.ToString().Trim().PadLeft(6,'0'),
                            terminal = s.terminal,
                            idOperador= s.idOperador,
                        };
                        return nr;
                    }).ToList();
                }
                rt.ListaD = lst;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public OOB.Resultado.FichaEntidad<OOB.CuadreCierre.ObtenerCierre.DataResumen.Ficha> 
            CuadreCierre_Get_ObtenerCierreDataResumen_byIdResumen(int idResumen)
        {
            var rt = new OOB.Resultado.FichaEntidad<OOB.CuadreCierre.ObtenerCierre.DataResumen.Ficha>(); 
            //
            try
            {
                var rst = MyData.CuadreCierre_Get_ObtenerCierreDataResumen_byIdResumen(idResumen);
                if (rst.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst.Mensaje);
                }
                if (rst.Entidad == null)
                {
                    throw new Exception("PROBLEMA AL CARGAR DATA");
                }
                if (rst.Entidad.documentos == null)
                {
                    throw new Exception("PROBLEMA AL CARGAR DATA DOCUMENTOS");
                }
                if (rst.Entidad.metPago == null)
                {
                    throw new Exception("PROBLEMA AL CARGAR DATA METODOS DE PAGO");
                }
                if (rst.Entidad.total == null)
                {
                    throw new Exception("PROBLEMA AL CARGAR DATA TOTALES");
                }
                var ss = rst.Entidad;
                rt.Entidad = new OOB.CuadreCierre.ObtenerCierre.DataResumen.Ficha()
                {
                    documentos = ss.documentos.Select(s =>
                    {
                        return new OOB.CuadreCierre.ObtenerCierre.DataResumen.PorDocumento()
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
                            importeMovContadoMonLocal = s.importeMovContadoMonLocal,
                            importeMovContadoMonReferencia = s.importeMovContadoMonReferencia,
                            importeMovCreditoMonLocal = s.importeMovCreditoMonLocal,
                            importeMovCreditoMonReferencia = s.importeMovCreditoMonReferencia,
                            importMovAnuladoMonLocal = s.importMovAnuladoMonLocal,
                            siglasDoc = s.siglasDoc,
                            signoDoc = s.signoDoc,
                            varianteDoc = s.varianteDoc,
                        };
                    }).ToList(),
                    metPago = ss.metPago.Select(s =>
                    {
                        return new OOB.CuadreCierre.ObtenerCierre.DataResumen.PorMetPago()
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
                    total = new OOB.CuadreCierre.ObtenerCierre.DataResumen.Total()
                    {
                        cntDivisaPorVuelto = ss.total.cntDivisaPorVuelto,
                        estatusCuadre = ss.total.estatusCuadre,
                        totalCajaSegunSistemaMonLocal = ss.total.totalCajaSegunSistemaMonLocal,
                        totalCajaSegunUsuarioMonLocal = ss.total.totalCajaSegunUsuarioMonLocal,
                        totalCuadreMonLocal = ss.total.totalCuadreMonLocal,
                        vueltoCambioPorDivisa = ss.total.vueltoCambioPorDivisa,
                        vueltoCambioPorEfectivo = ss.total.vueltoCambioPorEfectivo,
                        vueltoCambioPorPagoMovil = ss.total.vueltoCambioPorPagoMovil,
                    },
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
    }
}