using PosOnLine.Data.Infra;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Prov
{
    
    public partial class DataPrv: IData
    {

        public OOB.Resultado.FichaEntidad<OOB.Configuracion.Entidad.Ficha> Configuracion_Pos_GetFicha()
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Configuracion.Entidad.Ficha>();

            var r01 = MyData.Configuracion_Pos_GetFicha();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            var nr = new OOB.Configuracion.Entidad.Ficha()
            {
                idCobrador = ent.idCobrador,
                idConceptoDevVenta = ent.idConceptoDevVenta,
                idConceptoSalida = ent.idConceptoSalida,
                idConceptoVenta = ent.idConceptoVenta,
                idDeposito = ent.idDeposito,
                idMedioPagoDivisa = ent.idMedioPagoDivisa,
                idMedioPagoEfectivo = ent.idMedioPagoEfectivo,
                idMedioPagoElectronico = ent.idMedioPagoElectronico,
                idMedioPagoOtros = ent.idMedioPagoOtros,
                idSucursal = ent.idSucursal,
                idTransporte = ent.idTransporte,
                idVendedor = ent.idVendedor,
                idTipoDocumentoVenta = ent.idTipoDocVenta,
                idTipoDocumentoDevVenta = ent.idTipoDocDevVenta,
                idTipoDocumentoNotaEntrega = ent.idTipoDocNotaEntrega,
                idSerieFactura = ent.idFacturaSerie,
                idSerieNotaCredito = ent.idNotaCreditoSerie,
                idSerieNotaEntrega = ent.idNotaEntregaSerie,
                idSerieNotaDebito = ent.idNotaDebitoSerie,
                //
                idClaveUsar = ent.idClaveUsar,
                idPrecioManejar = ent.idPrecioManejar,
                validarExistencia = ent.validarExistencia,
                activarBusquedaPorDescripcion = ent.activarBusquedaPorDescripcion,
                activarReepsaje = ent.activarRepesaje,
                limiteInferiorRepesaje = ent.limiteInferiorRepesaje,
                limiteSuperiorRepesaje = ent.limiteSuperiorRepesaje,
                //
                estatus = ent.estatus,
                modoPrecio = ent.modoPrecio,
            };
            result.Entidad = nr;

            return result;
        }

        public OOB.Resultado.FichaEntidad<decimal> Configuracion_FactorDivisa()
        {
            var result = new OOB.Resultado.FichaEntidad<decimal>();

            var r01 = MyData.Configuracion_FactorDivisa();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var m1 = 0.0m;
            var cnf = r01.Entidad;
            if (cnf.Trim() != "")
            {
                var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                var culture = CultureInfo.CreateSpecificCulture("es-ES");
                //var culture = CultureInfo.CreateSpecificCulture("en-EN");
                Decimal.TryParse(cnf, style, culture, out m1);
            }
            result.Entidad = m1;

            return result;
        }
        
        public OOB.Resultado.Ficha Configuracion_Pos_Actualizar(OOB.Configuracion.Actualizar.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var fichaDTO = new DtoLibPos.Configuracion.Actualizar.Ficha()
            {
                activarBusquedaPorDescripcion = ficha.activarBusquedaPorDescripcion,
                activarRepesaje = ficha.activarBusquedaPorDescripcion,
                idClaveUsar = ficha.idClaveUsar,
                idCobrador = ficha.idCobrador,
                idConceptoDevVenta = ficha.idConceptoDevVenta,
                idConceptoSalida = ficha.idConceptoSalida,
                idConceptoVenta = ficha.idConceptoVenta,
                idDeposito = ficha.idDeposito,
                idFacturaSerie = ficha.idFacturaSerie,
                idMedioPagoDivisa = ficha.idMedioPagoDivisa,
                idMedioPagoEfectivo = ficha.idMedioPagoEfectivo,
                idMedioPagoElectronico = ficha.idMedioPagoElectronico,
                idMedioPagoOtros = ficha.idMedioPagoOtros,
                idNotaCreditoSerie = ficha.idNotaCreditoSerie,
                idNotaDebitoSerie = ficha.idNotaDebitoSerie,
                idNotaEntregaSerie = ficha.idNotaEntregaSerie,
                idPrecioManejar = ficha.idPrecioManejar,
                idSucursal = ficha.idSucursal,
                idTipoDocDevVenta = ficha.idTipoDocDevVenta,
                idTipoDocNotaEntrega = ficha.idTipoDocNotaEntrega,
                idTipoDocVenta = ficha.idTipoDocVenta,
                idTransporte = ficha.idTransporte,
                idVendedor = ficha.idVendedor,
                limiteInferiorRepesaje = ficha.limiteInferiorRepesaje,
                limiteSuperiorRepesaje = ficha.limiteSuperiorRepesaje,
                modoPrecio = ficha.modoPrecio,
                validarExistencia = ficha.validarExistencia,
            };
            var r01 = MyData.Configuracion_Pos_Actualizar (fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

        public OOB.Resultado.Ficha Configuracion_Pos_CambioDepositoSucursalFrio()
        {
            var result = new OOB.Resultado.Ficha();

            var r01 = MyData.Configuracion_Pos_CambioDepositoSucursalFrio();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

        public OOB.Resultado.Ficha Configuracion_Pos_CambioDepositoSucursalViveres()
        {
            var result = new OOB.Resultado.Ficha();

            var r01 = MyData.Configuracion_Pos_CambioDepositoSucursalViveres();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

        public OOB.Resultado.Ficha Configuracion_Pos_CambioSucursalDeposito(OOB.Configuracion.CambioSucursalDeposito.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var fichaDTO = new DtoLibPos.Configuracion.CambioDepositoSucursal.Ficha()
            {
                idSucursal = ficha.idSucursal,
                idDeposito = ficha.idDeposito,
            };
            var r01 = MyData.Configuracion_Pos_CambioDepositoSucursal (fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

        public OOB.Resultado.FichaEntidad<bool> Configuracion_Habilitar_Precio5_VentaMayor()
        {
            var result = new OOB.Resultado.FichaEntidad<bool>();

            var r01 = MyData.Configuracion_Habilitar_Precio5_VentaMayor();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            var rt = false;
            if (r01.Entidad != null) 
            {
                rt=  r01.Entidad.Trim().ToUpper() == "SI" ? true : false;
            }
            result.Entidad = rt;

            return result;
        }

    }

}