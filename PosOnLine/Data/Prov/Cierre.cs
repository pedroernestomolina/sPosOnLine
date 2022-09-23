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

        public OOB.Resultado.Lista<OOB.Cierre.Lista.Ficha> 
            Cierre_Lista_GetByFiltro(OOB.Cierre.Lista.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Cierre.Lista.Ficha>();

            var filtroDTO = new DtoLibPos.Pos.Cierre.Lista.Filtro();
            var r01 = MyData.Cierre_Lista_GetByFiltro(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                throw new Exception(r01.Mensaje);

            var _lst = new List<OOB.Cierre.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    _lst = r01.Lista.Select(s =>
                    {
                        return new OOB.Cierre.Lista.Ficha()
                        {
                            cierreNro = s.cierreNro,
                            fecha = s.fecha,
                            hora = s.hora,
                            id = s.id,
                            idEquipo = s.idEquipo,
                        };
                    }).ToList();
                }
            }
            rt.ListaD = _lst;

            return rt;
        }
        public OOB.Resultado.FichaEntidad<OOB.Cierre.Entidad.Ficha> 
            Cierre_GetById(int idCierre)
        {
            var rt = new OOB.Resultado.FichaEntidad<OOB.Cierre.Entidad.Ficha>(); 

            var r01 = MyData.Cierre_GetById(idCierre);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                throw new Exception(r01.Mensaje);

            var s = r01.Entidad;
            rt.Entidad = new OOB.Cierre.Entidad.Ficha()
            {
                fechaCierre = s.fechaCierre,
                horaCierre = s.horaCierre,
                cierreNro = s.cierreNro,
                idEquipo = s.idEquipo,
                codUsuario = s.codUsuario,
                nombreUsuario = s.nombreUsuario,
                diferencia = s.diferencia,
                efectivo = s.efectivo,
                cheque = s.cheque,
                debito = s.debito,
                credito = s.credito,
                ticket = s.ticket,
                firma = s.firma,
                retiro = s.retiro,
                otros = s.otros,
                devolucion = s.devolucion,
                subTotal = s.subTotal,
                cobranza = s.cobranza,
                total = s.total,
                mefectivo = s.mefectivo,
                mcheque = s.mcheque,
                mbanco1 = s.mbanco1,
                mbanco2 = s.mbanco2,
                mbanco3 = s.mbanco3,
                mbanco4 = s.mbanco4,
                mtarjeta = s.mtarjeta,
                mticket = s.mticket,
                mtrans = s.mtrans,
                mfirma = s.firma,
                motros = s.motros,
                mgastos = s.mgastos,
                mretiro = s.mretiro,
                mretenciones = s.mretenciones,
                msubtotal = s.msubtotal,
                mtotal = s.mtotal,
                cntDivisia = s.cntDivisa,
                cntDivisaUsuario = s.cntDivisaUsuario,
                cntDoc = s.cntDoc,
                cntDocFac = s.cntDocFac,
                cntDocNCr = s.cntDocNCr,
                montoFac = s.montoFac,
                montoNCr = s.montoNCr,
                //
                mEfectivo_s = s.mEfectivo_s,
                cntEfectivo_s = s.cntEfectivo_s,
                cntElectronico_s = s.cntElectronico_s,
                cntOtros_s = s.cntOtros_s,
                m_cambio = s.m_cambio,
                cntDocContado = s.cntDocContado,
                cntDocCredito = s.cntDocCredito,
                mContado = s.mContado,
                mCredito = s.mCredito,
                //
                montoVueltoPorEfectivo = s.montoVueltoPorEfectivo,
                montoVueltoPorDivisa = s.montoVueltoPorDivisa,
                montoVueltoPorPagoMovil = s.montoVueltoPorPagoMovil,
                montoContadoAnulado = s.montoContadoAnulado,
                montoCreditoAnulado = s.montoCreditoAnulado
            };

            return rt;
        }

    }

}