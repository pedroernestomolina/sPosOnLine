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
            get_CuadreResumenMetodoPago_byId(int idResumen)
        {
            var rt = new OOB.Resultado.Lista<OOB.CuadreCierre.CuadreResumen.MetodoPago>();
            //
            try
            {
                var rs = MyData.get_CuadreResumenMetodoPago_byId(idResumen);
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
            get_CuadreResumenDocumento_byId(int idResumen)
        {
            var rt = new OOB.Resultado.Lista<OOB.CuadreCierre.CuadreResumen.Documento>();
            //
            try
            {
                var rs = MyData.get_CuadreResumenDocumento_byId(idResumen);
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
            get_CuadreResumenTotalesd_byId(int idResumen)
        {
            var rt = new OOB.Resultado.FichaEntidad<OOB.CuadreCierre.CuadreResumen.Totales>();
            //
            try
            {
                var rs = MyData.get_CuadreResumenTotalesd_byId(idResumen);
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
    }
}