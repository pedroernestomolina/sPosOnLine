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
        public OOB.Resultado.Lista<OOB.Reportes.Pos.PagoDetalle.Ficha> 
            ReportePos_PagoDetalle(OOB.Reportes.Pos.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Reportes.Pos.PagoDetalle.Ficha>();

            var filtroDTO = new DtoLibPos.Reportes.POS.Filtro();
            filtroDTO.IdCierre = filtro.idCierre;
            var r01 = MyData.ReportePos_PagoDetalle(filtroDTO);
            if (r01.Result ==  DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.Reportes.Pos.PagoDetalle.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    var gf = r01.Lista.GroupBy(g => 
                        new 
                        {
                            g.autoRecibo, g.documentoNro, g.documentoFecha, g.documentoTipo, g.hora, g.clienteNombre, 
                            g.clienteCiRif, g.clienteDir, g.clienteTelf, g.cambioDar, g.estatus , g.importe , g.estatusCredito
                        }).Select(s => new { key = s.Key, data = s.ToList()}).ToList();

                    foreach (var it in gf)
                    {
                        var nf = new OOB.Reportes.Pos.PagoDetalle.Ficha()
                        {
                            cliCiRif = it.key.clienteCiRif,
                            cliDir = it.key.clienteDir,
                            cliNombre = it.key.clienteNombre,
                            cliTelf = it.key.clienteTelf,
                            docCambioDar = it.key.cambioDar,
                            docEstatus = it.key.estatus,
                            docEstatusCredito = it.key.estatusCredito,
                            docFecha = it.key.documentoFecha,
                            docHora = it.key.hora,
                            docMonto = it.key.importe,
                            docNumero = it.key.documentoNro,
                            docTipo = it.key.documentoTipo,
                            idRecibo = it.key.autoRecibo,
                        };
                        var lp= new List<OOB.Reportes.Pos.PagoDetalle.Detalle>();
                        foreach (var p in it.data) 
                        {
                            var np = new OOB.Reportes.Pos.PagoDetalle.Detalle()
                            {
                                loteCntDivisa = p.loteCntDivisa,
                                medioPagCodigo = p.medioPagoCodigo,
                                medioPagDesc = p.medioPagoDesc,
                                montoRecibido = p.montoRecibido,
                                refTasaDivisa = p.referenciaTasa,
                            };
                            lp.Add(np);
                        }
                        nf.pagos = lp;
                        list.Add(nf);
                    }
                }
            }
            rt.ListaD = list;

            return rt;
        }
        public OOB.Resultado.Lista<OOB.Reportes.Pos.PagoResumen.Ficha> 
            ReportePos_PagoResumen(OOB.Reportes.Pos.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Reportes.Pos.PagoResumen.Ficha>();

            var filtroDTO = new DtoLibPos.Reportes.POS.Filtro();
            filtroDTO.IdCierre = filtro.idCierre;
            var r01 = MyData.ReportePos_PagoDetalle(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.Reportes.Pos.PagoResumen.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Where(w=>w.estatus.Trim().ToUpper()=="0").Select(s =>
                    {
                        var rg = new OOB.Reportes.Pos.PagoResumen.Ficha()
                        {
                            loteCntDivisa = s.loteCntDivisa,
                            montoRecibido = s.montoRecibido,
                            mpCodigo = s.medioPagoCodigo,
                            mpDescripcion = s.medioPagoDesc,
                            refTasaDivisa = s.referenciaTasa,
                            estatusCredito = s.estatusCredito,
                            importeDoc = s.importe,
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.ListaD = list;

            return rt;
        }
        public OOB.Resultado.Lista<OOB.Reportes.Pos.PagoMovil.Ficha> 
            ReportePos_PagoMovil(OOB.Reportes.Pos.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Reportes.Pos.PagoMovil.Ficha>();

            var filtroDTO = new DtoLibPos.Reportes.POS.Filtro();
            filtroDTO.IdCierre = filtro.idCierre;
            var r01 = MyData.ReportePos_PagoMovil(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.Reportes.Pos.PagoMovil.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var rg = new OOB.Reportes.Pos.PagoMovil.Ficha()
                        {
                            agencia = s.agencia,
                            docCiRif = s.docCiRif,
                            docEstatusAnulado = s.docEstatusAnulado,
                            docFecha = s.docFecha,
                            docNro = s.docNro,
                            docRazonSocial = s.docRazonSocial,
                            pmCiRif = s.pmCiRif,
                            pmMonto = s.pmMonto,
                            pmNombre = s.pmNombre,
                            pmTelefono = s.pmTelefono,
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.ListaD = list;

            return rt;
        }
        public OOB.Resultado.Lista<OOB.Reportes.Pos.VueltosEntregados.Ficha> 
            ReportePos_VueltosEntregados(OOB.Reportes.Pos.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Reportes.Pos.VueltosEntregados.Ficha>();

            var filtroDTO = new DtoLibPos.Reportes.POS.Filtro() { IdCierre = filtro.idCierre };
            var r01 = MyData.ReportePos_VueltosEntregados(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                throw new Exception(r01.Mensaje);

            var lst = new List<OOB.Reportes.Pos.VueltosEntregados.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Reportes.Pos.VueltosEntregados.Ficha()
                        {
                            cntVueltoDivisa = s.cntVueltoDivisa,
                            documento = s.documento,
                            entDir = s.entDir,
                            entNombre = s.entNombre,
                            entTelf = s.entTelf,
                            esAnulado = s.esAnulado,
                            fecha = s.fecha,
                            hora = s.hora,
                            montoCambio = s.montoCambio,
                            montoDoc = s.montoDoc,
                            montoVueltoDivisa = s.montoVueltoDivisa,
                            montoVueltoEfectivo = s.montoVueltoEfectivo,
                            montoVueltoPagoMovil = s.montoVueltoPagoMovil,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.ListaD = lst;

            return rt;
        }
        //
        public OOB.Resultado.FichaEntidad<OOB.Reportes.Pos.MovCaja.Ficha> 
            ReportePos_MovCaja(OOB.Reportes.Pos.MovCaja.Filtro filtro)
        {
            var rt = new OOB.Resultado.FichaEntidad<OOB.Reportes.Pos.MovCaja.Ficha>();

            var filtroDTO = new DtoLibPos.Reportes.POS.MovCaja.Filtro() { idOperador = filtro.idOperador };
            var r01 = MyData.ReportePos_MovCaja(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var _mov = new List<OOB.Reportes.Pos.MovCaja.FichaMov>();
            var _det= new List<OOB.Reportes.Pos.MovCaja.FichaDet>();
            if (r01.Entidad.mov != null)
            {
                if (r01.Entidad.mov.Count > 0)
                {
                    _mov= r01.Entidad.mov.Select(s =>
                    {
                        var nr = new OOB.Reportes.Pos.MovCaja.FichaMov()
                        {
                            idMov=s.idMov,
                            numeroMov=s.numeroMov,
                            conceptoMov = s.conceptoMov,
                            estatusAnuladoMov = s.estatusAnuladoMov,
                            factorCambioMov = s.factorCambioMov,
                            fechaMov = s.fechaMov,
                            montoDivisaMov = s.montoDivisaMov,
                            montoMov = s.montoMov,
                            signoMov = s.signoMov,
                            tipoMov = s.tipoMov,
                        };
                        return nr;
                    }).ToList();
                }
            }
            if (r01.Entidad.det != null)
            {
                if (r01.Entidad.det.Count > 0)
                {
                    _det = r01.Entidad.det.Select(s =>
                    {
                        var nr = new OOB.Reportes.Pos.MovCaja.FichaDet()
                        {
                            cntDivisa = s.cntDivisa,
                            codigoMed = s.codigoMed,
                            descMed = s.descMed,
                            esDivisa = s.esDivisa,
                            monto = s.monto,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Entidad = new OOB.Reportes.Pos.MovCaja.Ficha()
            {
                mov = _mov,
                det = _det,
            };
            return rt;
        }
    }
}