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
        public OOB.Resultado.Lista<OOB.Producto_ModoAdm.Lista.Ficha> 
            Producto_ModoAdm_GetLista(OOB.Producto.Lista.Filtro filtro)
        {
            var result = new OOB.Resultado.Lista<OOB.Producto_ModoAdm.Lista.Ficha>();
            var filtroDTO = new DtoLibPos.Producto.Lista.Filtro()
            {
                AutoDeposito = filtro.autoDeposito,
                IdPrecioManejar = filtro.idPrecioManejar,
                Cadena = filtro.cadena,
                IsPorPlu = filtro.isPorPlu,
            };
            var r01 = MyData.Producto_ModoAdm_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var _lst = new List<OOB.Producto_ModoAdm.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    _lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Producto_ModoAdm.Lista.Ficha()
                        {
                            auto = s.auto,
                            codigo = s.codigo,
                            contEmpCompra = s.contEmpCompra,
                            contEmpInv = s.contEmpInv,
                            contEmpVta = s.contEmpVta,
                            descEmpCompra = s.descEmpCompra,
                            descEmpInv = s.descEmpInv,
                            descEmpVta = s.descEmpVta,
                            desdeOferta = s.desdeOferta,
                            estatus = s.estatus,
                            estatusDivisa = s.estatusDivisa,
                            estatusOferta = s.estatusOferta,
                            estatusPesado = s.estatusPesado,
                            exDisponible = s.exDisponible,
                            exFisica = s.exFisica,
                            hastaOferta = s.hastaOferta,
                            nombre = s.nombre,
                            pFullDivisa = s.pFullDivisa,
                            plu = s.plu,
                            pNeto = s.pNeto,
                            porctOferta = s.porctOferta,
                            tasaIva = s.tasaIva,
                            tipoEmpVta = s.tipoEmpVta,
                            utilidadVta = s.utilidadVta,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = _lst;
            return result;
        }
        public OOB.Resultado.FichaEntidad<bool> 
            Producto_ModoAdm_VerificaPrecioVtaProducto(string autoPrd, string tipoPrecio, string tipoEmpaque)
        {
            var result = new OOB.Resultado.FichaEntidad<bool>();
            var r01 = MyData.Producto_ModoAdm_VerificaPrecioVtaProducto(autoPrd, tipoPrecio, tipoEmpaque);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            result.Entidad = r01.Entidad;
            return result;
        }
        public OOB.Resultado.FichaEntidad<OOB.Producto_ModoAdm.Precio.Ficha> 
            Producto_ModoAdm_GetPrecio_By(OOB.Producto_ModoAdm.Precio.Filtro filtro)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Producto_ModoAdm.Precio.Ficha>();
            var filtroDTO = new DtoLibPos.Producto_ModoAdm.Precio.Filtro()
            {
                autoPrd = filtro.autoPrd,
                tipoPrecioHnd = filtro.tipoPrecioHnd,
            };
            var r01 = MyData.Producto_ModoAdm_GetPrecio_By(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var _lst = new List<OOB.Producto_ModoAdm.Precio.Precio>();
            if (r01.Entidad.precios != null) 
            {
                if (r01.Entidad.precios.Count > 0) 
                {
                    _lst = r01.Entidad.precios.Select(s =>
                    {
                        var nr = new OOB.Producto_ModoAdm.Precio.Precio()
                        {
                            autoEmp = s.autoEmp,
                            contEmp = s.contEmp,
                            descEmp = s.descEmp,
                            idPrecioVenta = s.idPrecioVenta,
                            idTipoEmpVenta = s.idTipoEmpVenta,
                            idTipoPrecio = s.idTipoPrecio,
                            ofertaDesde = s.ofertaDesde,
                            ofertaEstatus = s.ofertaEstatus,
                            ofertaHasta = s.ofertaHasta,
                            ofertaPorct = s.ofertaPorct,
                            pfdEmp = s.pfdEmp,
                            pnEmp = s.pnEmp,
                            tipoEmp = s.tipoEmp,
                            utEmp = s.utEmp,
                            decimales= s.decimales,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Entidad = new OOB.Producto_ModoAdm.Precio.Ficha()
            {
                precios = _lst,
            };
            return result;
        }
        public OOB.Resultado.FichaEntidad<OOB.Producto_ModoAdm.Entidad.Ficha> 
            Producto_ModoAdm_GetFicha_By(string autoPrd)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Producto_ModoAdm.Entidad.Ficha>();
            var r01 = MyData.Producto_ModoAdm_GetFicha_By(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var p = r01.Entidad;
            result.Entidad = new OOB.Producto_ModoAdm.Entidad.Ficha()
            {
                categoria = p.categoria,
                codDepart = p.codDepart,
                codGrupo = p.codGrupo,
                codigoPLU = p.codigoPLU,
                codigoPrd = p.codigoPrd,
                contEmpCompra = p.contEmpCompra,
                costo = p.costo,
                costoDivisa = p.costoDivisa,
                descDepart = p.descDepart,
                descEmpCompra = p.descEmpCompra,
                decimalesEmpCompra = p.decimalesEmpCompra,
                descGrupo = p.descGrupo,
                descPrd = p.descPrd,
                descTasaIva = p.descTasaIva,
                estatus = p.estatus,
                estatusDivisa = p.estatusDivisa,
                estatusOferta = p.estatusOferta,
                estatusPesado = p.estatusPesado,
                fAlto = p.fAlto,
                fAncho = p.fAncho,
                fLargo = p.fLargo,
                fPeso = p.fPeso,
                fVolumen = p.fVolumen,
                idDepart = p.idDepart,
                idEmpCompra = p.idEmpCompra,
                idGrupo = p.idGrupo,
                idMarca = p.idMarca,
                idPrd = p.idPrd,
                idSubGrupo = p.idSubGrupo,
                idTasaIva = p.idTasaIva,
                descMarca = p.descMarca,
                modelo = p.modelo,
                pasillo = p.pasillo,
                referencia = p.referencia,
                tasaIva = p.tasaIva,
                CostoPromedio = p.CostoPromedio,
                CostoPromUnd = p.CostoPromUnd,
                CostoUnd = p.CostoUnd,
            };
            return result;
        }
    }
}