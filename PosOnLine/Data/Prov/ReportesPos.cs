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

        public OOB.Resultado.Lista<OOB.Reportes.Pos.PagoDetalle.Ficha> ReportePos_PagoDetalle(OOB.Reportes.Pos.Filtro filtro)
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
                            g.clienteCiRif, g.clienteDir, g.clienteTelf, g.cambioDar, g.estatus , g.importe 
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

        public OOB.Resultado.Lista<OOB.Reportes.Pos.PagoResumen.Ficha> ReportePos_PagoResumen(OOB.Reportes.Pos.Filtro filtro)
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
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.ListaD = list;

            return rt;
        }

    }

}