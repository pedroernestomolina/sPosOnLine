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
        public OOB.Resultado.FichaEntidad<OOB.Venta.Item.Zufu.ActualizarPrecio.ObtenerData.Ficha> 
            Venta_Item_Zufu_ActualizarPrecio_ObetnerData(string idPrd)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Venta.Item.Zufu.ActualizarPrecio.ObtenerData.Ficha>();
            var r01 = MyData.Venta_Item_Zufu_ActualizarPrecio_ObtenerData(idPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            var _tasaActual = 0m;
            if (r01.Entidad.TasaActual.Trim() != "")
            {
                var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                var culture = CultureInfo.CreateSpecificCulture("es-ES");
                Decimal.TryParse(r01.Entidad.TasaActual, style, culture, out _tasaActual);
            }
            if (_tasaActual <= 0m)
            {
                result.Mensaje = "TASA DIVISA INCORRECTA, NO PUEDE SER CERO (0)";
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            var _prd = r01.Entidad.Producto;
            result.Entidad = new OOB.Venta.Item.Zufu.ActualizarPrecio.ObtenerData.Ficha()
            {
                Producto = new OOB.Venta.Item.Zufu.ActualizarPrecio.ObtenerData.Prd()
                {
                    contEmpCompra = _prd.contEmpCompra,
                    esDivisa = _prd.esDivisa,
                    costoEmpCompraMonAct = _prd.costoMonAct,
                    costoEmpCompraMonDiv = _prd.costoMonDiv,
                },
                TasaActual = _tasaActual,
            };
            return result;
        }
        public OOB.Resultado.Ficha 
            Venta_Item_Zufu_ActualizarPrecio_Actualizar(OOB.Venta.Item.Zufu.ActualizarPrecio.Actualizar.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();
            var fichaDTO = new DtoLibPos.Venta.Item.Zufu.ActualizarPrecio.Actualizar.Ficha()
            {
                data = new DtoLibPos.Venta.Item.Zufu.ActualizarPrecio.Actualizar.Data()
                {
                    idItem = ficha.data.idItem,
                    pFullMonDiv = ficha.data.pFullMonDiv,
                    pNetoMonAct = ficha.data.pNetoMonAct,
                },
                logReg = new DtoLibPos.Venta.Item.Zufu.ActualizarPrecio.Actualizar.LogReg()
                {
                    accion = ficha.logReg.accion,
                    codigoUsuarioAutoriza = ficha.logReg.codigoUsuarioAutoriza,
                    descripcion = ficha.logReg.descripcion,
                    idOperador = ficha.logReg.idOperador,
                    idUsuarioAutoriza = ficha.logReg.idUsuarioAutoriza,
                    nombreUsuarioAutoriza = ficha.logReg.nombreUsuarioAutoriza,
                }
            };
            var r01 = MyData.Venta_Item_Zufu_ActualizarPrecio_Actualizar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            return result;
        }
    }
}