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

        public OOB.Resultado.FichaEntidad<OOB.Pos.EnUso.Ficha> Jornada_EnUso_GetByIdEquipo(string idEquipo)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Pos.EnUso.Ficha>();

            var r01 = MyData.Jornada_EnUso_GetByIdEquipo(idEquipo);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent=r01.Entidad;
            var nr = new OOB.Pos.EnUso.Ficha()
            {
                codUsuario = ent.codUsuario,
                fechaApertura = ent.fechaApertura,
                horaApertura = ent.horaApertura,
                id = ent.id,
                idUsuario = ent.idUsuario,
                nomUsuario = ent.nomUsuario,
                idAutoArqueoCierre=ent.idArqueoCierre,
                idResumen=ent.idResumen,
            };
            result.Entidad=nr;

            return result;
        }

        public OOB.Resultado.FichaId Jornada_Abrir(OOB.Pos.Abrir.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaId();

            var fichaDTO = new DtoLibPos.Pos.Abrir.Ficha()
            {
                idEquipo = ficha.idEquipo,
                codSucursal=ficha.codSucursal,
                operadorAbrir = new DtoLibPos.Pos.Abrir.Operador()
                {
                    estatus = ficha.operadorAbrir.estatus,
                    idEquipo = ficha.operadorAbrir.idEquipo,
                    idUsuario = ficha.operadorAbrir.idUsuario,
                    codSucursal = ficha.codSucursal,
                },
                arqueoAbrir = new DtoLibPos.Pos.Abrir.Arqueo()
                {
                    cheque = ficha.arqueoAbrir.cheque,
                    cierreFtp = ficha.arqueoAbrir.cierreFtp,
                    cntDivisaUsuario = ficha.arqueoAbrir.cntDivisaUsuario,
                    cntDivisia = ficha.arqueoAbrir.cntDivisia,
                    cntDoc = ficha.arqueoAbrir.cntDoc,
                    cntDocFac = ficha.arqueoAbrir.cntDocFac,
                    cntDocNCr = ficha.arqueoAbrir.cntDocNCr,
                    cobranza = ficha.arqueoAbrir.cobranza,
                    codUsuario = ficha.arqueoAbrir.codUsuario,
                    credito = ficha.arqueoAbrir.credito,
                    debito = ficha.arqueoAbrir.debito,
                    devolucion = ficha.arqueoAbrir.devolucion,
                    diferencia = ficha.arqueoAbrir.diferencia,
                    efectivo = ficha.arqueoAbrir.efectivo,
                    firma = ficha.arqueoAbrir.firma,
                    idUsuario = ficha.arqueoAbrir.idUsuario,
                    mbanco1 = ficha.arqueoAbrir.mbanco1,
                    mbanco2 = ficha.arqueoAbrir.mbanco2,
                    mbanco3 = ficha.arqueoAbrir.mbanco3,
                    mbanco4 = ficha.arqueoAbrir.mbanco4,
                    mcheque = ficha.arqueoAbrir.mcheque,
                    mefectivo = ficha.arqueoAbrir.mefectivo,
                    mfirma = ficha.arqueoAbrir.mfirma,
                    mgastos = ficha.arqueoAbrir.mgastos,
                    montoFac = ficha.arqueoAbrir.montoFac,
                    montoNCr = ficha.arqueoAbrir.montoNCr,
                    motros = ficha.arqueoAbrir.motros,
                    mretenciones = ficha.arqueoAbrir.mretenciones,
                    mretiro = ficha.arqueoAbrir.mretiro,
                    msubtotal = ficha.arqueoAbrir.msubtotal,
                    mtarjeta = ficha.arqueoAbrir.mtarjeta,
                    mticket = ficha.arqueoAbrir.mticket,
                    mtotal = ficha.arqueoAbrir.mtotal,
                    mtrans = ficha.arqueoAbrir.mtrans,
                    nombreUsuario = ficha.arqueoAbrir.nombreUsuario,
                    otros = ficha.arqueoAbrir.otros,
                    retiro = ficha.arqueoAbrir.retiro,
                    subTotal = ficha.arqueoAbrir.subTotal,
                    ticket = ficha.arqueoAbrir.ticket,
                    total = ficha.arqueoAbrir.total,
                },
                resumenAbrir = new DtoLibPos.Pos.Abrir.Resumen()
                {
                    cntDevolucion = ficha.resumenAbrir.cntDevolucion,
                    cntDivisa = ficha.resumenAbrir.cntDivisa,
                    cntDoc = ficha.resumenAbrir.cntDoc,
                    cntDocContado = ficha.resumenAbrir.cntDocContado,
                    cntDocCredito = ficha.resumenAbrir.cntDocCredito,
                    cntEfectivo = ficha.resumenAbrir.cntEfectivo,
                    cntElectronico = ficha.resumenAbrir.cntElectronico,
                    cntFac = ficha.resumenAbrir.cntFac,
                    cntNCr = ficha.resumenAbrir.cntNCr,
                    cntotros = ficha.resumenAbrir.cntotros,
                    mContado = ficha.resumenAbrir.mContado,
                    mCredito = ficha.resumenAbrir.mCredito,
                    mDevolucion = ficha.resumenAbrir.mDevolucion,
                    mDivisa = ficha.resumenAbrir.mDivisa,
                    mEfectivo = ficha.resumenAbrir.mEfectivo,
                    mElectronico = ficha.resumenAbrir.mElectronico,
                    mFac = ficha.resumenAbrir.mFac,
                    mNCr = ficha.resumenAbrir.mNCr,
                    mOtros = ficha.resumenAbrir.mOtros,
                }
            };
            var r01 = MyData.Jornada_Abrir(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Id = r01.Id;

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Pos.EnUso.Ficha> Jornada_EnUso_GetById(int id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Pos.EnUso.Ficha>();

            var r01 = MyData.Jornada_EnUso_GetById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            var nr = new OOB.Pos.EnUso.Ficha()
            {
                codUsuario = ent.codUsuario,
                fechaApertura = ent.fechaApertura,
                horaApertura = ent.horaApertura,
                id = ent.id,
                idUsuario = ent.idUsuario,
                nomUsuario = ent.nomUsuario,
                idAutoArqueoCierre = ent.idArqueoCierre,
                idResumen = ent.idResumen,
            };
            result.Entidad = nr;

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Pos.Resumen.Ficha> Jornada_Resumen_GetByIdResumen(int id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Pos.Resumen.Ficha>();

            var r01 = MyData.Jornada_Resumen_GetByIdResumen(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            var nr = new OOB.Pos.Resumen.Ficha()
            {
                cnt_anu = ent.cnt_anu,
                cnt_anu_fac = ent.cnt_anu_fac,
                cnt_anu_ncr = ent.cnt_anu_ncr,
                cnt_anu_nte = ent.cnt_anu_nte,
                cntDevolucion = ent.cntDevolucion,
                cntDivisa = ent.cntDivisa,
                cntDoc = ent.cntDoc,
                cntDocContado = ent.cntDocContado,
                cntDocCredito = ent.cntDocCredito,
                cntEfectivo = ent.cntEfectivo,
                cntElectronico = ent.cntElectronico,
                cntFac = ent.cntFac,
                cntNCr = ent.cntNCr,
                cntNtE = ent.cntNtE,
                cntotros = ent.cntotros,
                m_anu = ent.m_anu,
                m_anu_fac = ent.m_anu_fac,
                m_anu_ncr = ent.m_anu_ncr,
                m_anu_nte = ent.m_anu_nte,
                mContado = ent.mContado,
                mCredito = ent.mCredito,
                mDevolucion = ent.mDevolucion,
                mDivisa = ent.mDivisa,
                mEfectivo = ent.mEfectivo,
                mElectronico = ent.mElectronico,
                mFac = ent.mFac,
                mNCr = ent.mNCr,
                mNtE = ent.mNtE,
                mOtros = ent.mOtros,
                m_cambio = ent.m_cambio,
                cnt_cambio = ent.cnt_cambio,
                //
                cntDocContado_anu = ent.cntDocContado_anu,
                cntDocCredito_anu = ent.cntDocCredito_anu,
                cntEfectivo_anu = ent.cntEfectivo_anu,
                cntDivisa_anu = ent.cntDivisa_anu,
                cntElectronico_anu = ent.cntElectronico_anu,
                cntotros_anu = ent.cntotros_anu,
                mContado_anu = ent.mContado_anu,
                mCredito_anu = ent.mCredito_anu,
                mEfectivo_anu = ent.mEfectivo_anu,
                mDivisa_anu = ent.mDivisa_anu,
                mElectronico_anu = ent.mElectronico_anu,
                mOtros_anu = ent.mOtros_anu,
                //
                cntCambio_anu=ent.cnt_cambio_anulado,
                mCambio_anu=ent.mcambio_anulado,
            };
            result.Entidad = nr;

            return result;
        }

        public OOB.Resultado.Ficha Jornada_Cerrar(OOB.Pos.Cerrar.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var fichaDTO = new DtoLibPos.Pos.Cerrar.Ficha()
            {
                idOperador = ficha.idOperador,
                estatus = ficha.estatus,
                arqueoCerrar = new DtoLibPos.Pos.Cerrar.Arqueo()
                {
                    autoArqueo = ficha.arqueo.autoArqueo,
                    cheque = ficha.arqueo.cheque,
                    cierreFtp = ficha.arqueo.cierreFtp,
                    cntDivisaUsuario = ficha.arqueo.cntDivisaUsuario,
                    cntDivisia = ficha.arqueo.cntDivisia,
                    cntDoc = ficha.arqueo.cntDoc,
                    cntDocFac = ficha.arqueo.cntDocFac,
                    cntDocNCr = ficha.arqueo.cntDocNCr,
                    cobranza = ficha.arqueo.cobranza,
                    credito = ficha.arqueo.credito,
                    debito = ficha.arqueo.debito,
                    devolucion = ficha.arqueo.devolucion,
                    diferencia = ficha.arqueo.diferencia,
                    efectivo = ficha.arqueo.efectivo,
                    firma = ficha.arqueo.firma,
                    mbanco1 = ficha.arqueo.mbanco1,
                    mbanco2 = ficha.arqueo.mbanco2,
                    mbanco3 = ficha.arqueo.mbanco3,
                    mbanco4 = ficha.arqueo.mbanco4,
                    mcheque = ficha.arqueo.mcheque,
                    mefectivo = ficha.arqueo.mefectivo,
                    mfirma = ficha.arqueo.mfirma,
                    mgastos = ficha.arqueo.mgastos,
                    montoFac = ficha.arqueo.montoFac,
                    montoNCr = ficha.arqueo.montoNCr,
                    motros = ficha.arqueo.motros,
                    mretenciones = ficha.arqueo.mretenciones,
                    mretiro = ficha.arqueo.mretiro,
                    msubtotal = ficha.arqueo.msubtotal,
                    mtarjeta = ficha.arqueo.mtarjeta,
                    mticket = ficha.arqueo.mticket,
                    mtotal = ficha.arqueo.mtotal,
                    mtrans = ficha.arqueo.mtrans,
                    otros = ficha.arqueo.otros,
                    retiro = ficha.arqueo.retiro,
                    subTotal = ficha.arqueo.subTotal,
                    ticket = ficha.arqueo.ticket,
                    total = ficha.arqueo.total,
                },
            };
            var r01 = MyData.Jornada_Cerrar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Pos.EnUso.Ficha> Jornada_EnUso_GetBy_EquipoSucursal(string idEquipo, string codSucursal)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Pos.EnUso.Ficha>();

            var r01 = MyData.Jornada_EnUso_GetBy_EquipoSucursal(idEquipo, codSucursal);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            var nr = new OOB.Pos.EnUso.Ficha()
            {
                codUsuario = ent.codUsuario,
                fechaApertura = ent.fechaApertura,
                horaApertura = ent.horaApertura,
                id = ent.id,
                idUsuario = ent.idUsuario,
                nomUsuario = ent.nomUsuario,
                idAutoArqueoCierre = ent.idArqueoCierre,
                idResumen = ent.idResumen,
            };
            result.Entidad = nr;

            return result;
        }

    }

}