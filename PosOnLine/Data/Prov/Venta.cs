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
        public OOB.Resultado.FichaId 
            Venta_Item_Registrar(OOB.Venta.Item.Registrar.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaId();

            var fichaDTO = new DtoLibPos.Venta.Item.Registrar.Ficha()
            {
                validarExistencia = ficha.validarExistencia,
                deposito = new DtoLibPos.Venta.Item.Registrar.FichaDeposito()
                {
                    autoDeposito = ficha.deposito.autoDeposito,
                    autoPrd = ficha.deposito.autoPrd,
                    cantBloq = ficha.deposito.cantBloq,
                },
                item = new DtoLibPos.Venta.Item.Registrar.FichaItem()
                {
                    autoDepartamento = ficha.item.autoDepartamento,
                    autoGrupo = ficha.item.autoGrupo,
                    autoProducto = ficha.item.autoProducto,
                    autoSubGrupo = ficha.item.autoSubGrupo,
                    autoTasa = ficha.item.autoTasa,
                    cantidad = ficha.item.cantidad,
                    categoria = ficha.item.categoria,
                    codigo = ficha.item.codigo,
                    costoCompra = ficha.item.costoCompra,
                    costoPromedio = ficha.item.costoPromedio,
                    costoPromedioUnd = ficha.item.costoPromedioUnd,
                    costoUnd = ficha.item.costoUnd,
                    decimales = ficha.item.decimales,
                    empaqueContenido = ficha.item.empaqueContenido,
                    empaqueDescripcion = ficha.item.empaqueDescripcion,
                    estatusPesado = ficha.item.estatusPesado,
                    idOperador = ficha.item.idOperador,
                    nombre = ficha.item.nombre,
                    pfullDivisa = ficha.item.pfullDivisa,
                    pneto = ficha.item.pneto,
                    tarifaPrecio = ficha.item.tarifaPrecio,
                    tasaIva = ficha.item.tasaIva,
                    tipoIva = ficha.item.tipoIva,
                    autoDeposito=ficha.item.autoDeposito,
                    fPeso=ficha.item.fPeso,
                    fVolumen=ficha.item.fVolumen,
                },
            };
            var r01 = MyData.Venta_Item_Registrar (fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Id = r01.Id;

            return result;
        }
        public OOB.Resultado.FichaEntidad<OOB.Venta.Item.Entidad.Ficha> 
            Venta_Item_GetById(int id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Venta.Item.Entidad.Ficha>();

            var r01 = MyData.Venta_Item_GetById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            var s= r01.Entidad;
            var nr = new OOB.Venta.Item.Entidad.Ficha()
            {
                autoDepartamento = s.autoDepartamento,
                autoGrupo = s.autoGrupo,
                autoProducto = s.autoProducto,
                autoSubGrupo = s.autoSubGrupo,
                autoTasa = s.autoTasa,
                cantidad = s.cantidad,
                categoria = s.categoria,
                codigo = s.codigo,
                costoCompra = s.costoCompra,
                costoPromedio = s.costoPromedio,
                costoPromedioUnd = s.costoPromedioUnd,
                costoUnd = s.costoUnd,
                decimales = s.decimales,
                empaqueContenido = s.empaqueContenido,
                empaqueDescripcion = s.empaqueDescripcion,
                estatusPesado = s.estatusPesado,
                id = s.id,
                idOperador = s.idOperador,
                nombre = s.nombre,
                pfullDivisa = s.pfullDivisa,
                pneto = s.pneto,
                tarifaPrecio = s.tarifaPrecio,
                tasaIva = s.tasaIva,
                tipoIva = s.tipoIva,
                autoDeposito = s.autoDeposito,
                peso=s.fPeso,
                volumen=s.fVolumen,
            };
            result.Entidad=nr;

            return result;
        }
        public OOB.Resultado.Lista<OOB.Venta.Item.Entidad.Ficha> 
            Venta_Item_GetLista(OOB.Venta.Item.Lista.Filtro filtro)
        {
            var result = new OOB.Resultado.Lista<OOB.Venta.Item.Entidad.Ficha>();

            var filtroDTO = new DtoLibPos.Venta.Item.Lista.Filtro()
            {
                idOperador = filtro.idOperador,
            };
            var r01 = MyData.Venta_Item_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst = new List<OOB.Venta.Item.Entidad.Ficha>();
            if (r01.Lista != null) 
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Venta.Item.Entidad.Ficha()
                        {
                            autoDepartamento = s.autoDepartamento,
                            autoGrupo = s.autoGrupo,
                            autoProducto = s.autoProducto,
                            autoSubGrupo = s.autoSubGrupo,
                            autoTasa = s.autoTasa,
                            cantidad = s.cantidad,
                            categoria = s.categoria,
                            codigo = s.codigo,
                            costoCompra = s.costoCompra,
                            costoPromedio = s.costoPromedio,
                            costoPromedioUnd = s.costoPromedioUnd,
                            costoUnd = s.costoUnd,
                            decimales = s.decimales,
                            empaqueContenido = s.empaqueContenido,
                            empaqueDescripcion = s.empaqueDescripcion,
                            estatusPesado = s.estatusPesado,
                            id = s.id,
                            idOperador = s.idOperador,
                            nombre = s.nombre,
                            pfullDivisa = s.pfullDivisa,
                            pneto = s.pneto,
                            tarifaPrecio = s.tarifaPrecio,
                            tasaIva = s.tasaIva,
                            tipoIva = s.tipoIva,
                            autoDeposito = s.autoDeposito,
                            peso = s.fPeso,
                            volumen = s.fVolumen
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }
        public OOB.Resultado.Ficha 
            Venta_Anular(OOB.Venta.Anular.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var fichaDTO = new DtoLibPos.Venta.Anular .Ficha ()
            {
                 items= ficha.items.Select(s=>
                 {
                     var nr = new DtoLibPos.Venta.Anular.FichaItem()
                     {
                         idOperador = s.idOperador,
                         idItem = s.idItem,
                     };
                     return nr;
                 }).ToList(),
                 itemDeposito= ficha.itemDeposito.Select(s=>
                 {
                     var nr = new DtoLibPos.Venta.Anular.FichaDeposito()
                     {
                         autoProducto = s.autoProducto,
                         autoDeposito = s.autoDeposito,
                         cantUndBloq = s.cantUndBloq,
                     };
                     return nr;
                 }).ToList(),
            };
            var r01 = MyData.Venta_Anular(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }
        public OOB.Resultado.Ficha 
            Venta_Item_Eliminar(OOB.Venta.Item.Eliminar.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var fichaDTO = new DtoLibPos.Venta.Item.Eliminar.Ficha()
            {
                idOperador = ficha.idOperador,
                idItem = ficha.idItem,
                autoProducto = ficha.autoProducto,
                autoDeposito = ficha.autoDeposito,
                cantUndBloq = ficha.cantUndBloq,
            };
            var r01 = MyData.Venta_Item_Eliminar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }
        public OOB.Resultado.Ficha 
            Venta_Item_ActualizarCantidad_Disminuir(OOB.Venta.Item.ActualizarCantidad.Disminuir.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var fichaDTO = new DtoLibPos.Venta.Item.ActualizarCantidad.Disminuir.Ficha()
            {
                idOperador = ficha.idOperador,
                idItem = ficha.idItem,
                autoProducto = ficha.autoProducto,
                autoDeposito = ficha.autoDeposito,
                cantUndBloq = ficha.cantUndBloq,
                cantidad=ficha.cantidad,
                precioNeto = ficha.precioNeto,
                tarifaVenta = ficha.tarifaVenta,
                precioDivisa = ficha.precioDivisa,
            };
            var r01 = MyData.Venta_Item_ActualizarCantidad_Disminuir(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }
        public OOB.Resultado.Ficha 
            Venta_Item_ActualizarCantidad_Aumentar(OOB.Venta.Item.ActualizarCantidad.Aumentar.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var fichaDTO = new DtoLibPos.Venta.Item.ActualizarCantidad.Aumentar.Ficha()
            {
                idOperador = ficha.idOperador,
                idItem = ficha.idItem,
                autoProducto = ficha.autoProducto,
                autoDeposito = ficha.autoDeposito,
                cantUndBloq = ficha.cantUndBloq,
                cantidad = ficha.cantidad,
                validarExistencia = ficha.validarExistencia,
                precioNeto = ficha.precioNeto,
                tarifaVenta = ficha.tarifaVenta,
                precioDivisa = ficha.precioDivisa,
            };
            var r01 = MyData.Venta_Item_ActualizarCantidad_Aumentar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }
        public OOB.Resultado.Ficha 
            Venta_Item_ActualizarPrecio(OOB.Venta.Item.ActualizarPrecio.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var fichaDTO = new DtoLibPos.Venta.Item.ActualizarPrecio.Ficha()
            {
                idOperador = ficha.idOperador,
                idItem = ficha.idItem,
                pNeto = ficha.precioNeto,
                pDivisa = ficha.precioDivisa,
                tarifaVenta = ficha.tarifaVenta,
            };
            var r01 = MyData.Venta_Item_ActualizarPrecio(fichaDTO);
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