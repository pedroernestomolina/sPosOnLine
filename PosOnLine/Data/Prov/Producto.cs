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
        public OOB.Resultado.FichaAuto 
            Producto_BusquedaByCodigo(string buscar)
        {
            var result = new OOB.Resultado.FichaAuto();

            var r01 = MyData.Producto_BusquedaByCodigo(buscar);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Auto = r01.Auto;

            return result;
        }
        public OOB.Resultado.FichaAuto 
            Producto_BusquedaByPlu(string buscar)
        {
            var result = new OOB.Resultado.FichaAuto();

            var r01 = MyData.Producto_BusquedaByPlu(buscar);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Auto = r01.Auto;

            return result;
        }
        public OOB.Resultado.FichaAuto 
            Producto_BusquedaByCodigoBarra(string buscar)
        {
            var result = new OOB.Resultado.FichaAuto();

            var r01 = MyData.Producto_BusquedaByCodigoBarra(buscar);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Auto = r01.Auto;

            return result;
        }
        public OOB.Resultado.FichaEntidad<OOB.Producto.Entidad.Ficha> 
            Producto_GetFichaById(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Producto.Entidad.Ficha>();

            var r01 = MyData.Producto_GetFichaById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent= r01.Entidad;
            var nr = new OOB.Producto.Entidad.Ficha()
            {
                Auto = ent.Auto,
                AutoDepartamento = ent.AutoDepartamento,
                AutoGrupo = ent.AutoGrupo,
                AutoMarca = ent.AutoMarca,
                AutoSubGrupo = ent.AutoSubGrupo,
                AutoTasaIva = ent.AutoTasaIva,
                AutoMedidaEmpaque_1 = ent.AutoMedidaEmpaque_1,
                AutoMedidaEmpaque_2 = ent.AutoMedidaEmpaque_2,
                AutoMedidaEmpaque_3 = ent.AutoMedidaEmpaque_3,
                AutoMedidaEmpaque_4 = ent.AutoMedidaEmpaque_4,
                AutoMedidaEmpaque_5 = ent.AutoMedidaEmpaque_5,
                Categoria = ent.Categoria,
                CodDepartamento = ent.CodDepartamento,
                CodGrupo = ent.CodGrupo,
                CodigoPLU = ent.CodigoPLU,
                CodigoPrd = ent.CodigoPrd,
                Estatus = ent.Estatus,
                EstatusDivisa = ent.EstatusDivisa,
                EstatusOferta = ent.EstatusOferta,
                EstatusPesado = ent.EstatusPesado,
                Marca = ent.Marca,
                Modelo = ent.Modelo,
                NombreDepartamento = ent.NombreDepartamento,
                NombreGrupo = ent.NombreGrupo,
                NombrePrd = ent.NombrePrd,
                NombreTasa = ent.NombreTasa,
                Pasillo = ent.Pasillo,
                Referencia = ent.Referencia,
                TasaImpuesto = ent.TasaImpuesto,
                //pneto_1 = ent.pneto_1,
                //pneto_2 = ent.pneto_2,
                //pneto_3 = ent.pneto_3,
                //pneto_4 = ent.pneto_4,
                //pneto_5 = ent.pneto_5,
                pdf_1 = ent.pdf_1,
                pdf_2 = ent.pdf_2,
                pdf_3 = ent.pdf_3,
                pdf_4 = ent.pdf_4,
                pdf_5 = ent.pdf_5,
                contenido_1 = ent.contenido_1,
                contenido_2 = ent.contenido_2,
                contenido_3 = ent.contenido_3,
                contenido_4 = ent.contenido_4,
                contenido_5 = ent.contenido_5,
                empaque_1 = ent.empaque_1,
                empaque_2 = ent.empaque_2,
                empaque_3 = ent.empaque_3,
                empaque_4 = ent.empaque_4,
                empaque_5 = ent.empaque_5,
                decimales_1 = ent.decimales_1,
                decimales_2 = ent.decimales_2,
                decimales_3 = ent.decimales_3,
                decimales_4 = ent.decimales_4,
                decimales_5 = ent.decimales_5,
                //
                CostoDivisa = ent.CostoDivisa,
                ContenidoEmpaqueCompra = ent.ContenidoEmpaqueCompra,
                Costo = ent.Costo,
                CostoPromedio = ent.CostoPromedio,
                //
                AutoMedidaEmpaqueMay_1 = ent.AutoMedidaEmpaqueMay_1,
                AutoMedidaEmpaqueMay_2 = ent.AutoMedidaEmpaqueMay_2,
                AutoMedidaEmpaqueMay_3 = ent.AutoMedidaEmpaqueMay_3,
                AutoMedidaEmpaqueMay_4 = ent.AutoMedidaEmpaqueMay_4,
                contenidoMay_1 = ent.contenidoMay_1,
                contenidoMay_2 = ent.contenidoMay_2,
                contenidoMay_3 = ent.contenidoMay_3,
                contenidoMay_4 = ent.contenidoMay_4,
                decimalesMay_1 = ent.decimalesMay_1,
                decimalesMay_2 = ent.decimalesMay_2,
                decimalesMay_3 = ent.decimalesMay_3,
                decimalesMay_4 = ent.decimalesMay_4,
                empaqueMay_1 = ent.empaqueMay_1,
                empaqueMay_2 = ent.empaqueMay_2,
                empaqueMay_3 = ent.empaqueMay_3,
                empaqueMay_4 = ent.empaqueMay_4,
                pdfMay_1 = ent.pdfMay_1,
                pdfMay_2 = ent.pdfMay_2,
                pdfMay_3 = ent.pdfMay_3,
                pdfMay_4 = ent.pdfMay_4,
                //pnetoMay_1 = ent.pnetoMay_1,
                //pnetoMay_2 = ent.pnetoMay_2,
                //pnetoMay_3 = ent.pnetoMay_3,
                //pnetoMay_4 = ent.pnetoMay_4,
                //
                AutoMedidaEmpaqueDsp_1 = ent.AutoMedidaEmpaqueDsp_1,
                AutoMedidaEmpaqueDsp_2 = ent.AutoMedidaEmpaqueDsp_2,
                AutoMedidaEmpaqueDsp_3 = ent.AutoMedidaEmpaqueDsp_3,
                AutoMedidaEmpaqueDsp_4 = ent.AutoMedidaEmpaqueDsp_4,
                contenidoDsp_1 = ent.contenidoDsp_1,
                contenidoDsp_2 = ent.contenidoDsp_2,
                contenidoDsp_3 = ent.contenidoDsp_3,
                contenidoDsp_4 = ent.contenidoDsp_4,
                decimalesDsp_1 = ent.decimalesDsp_1,
                decimalesDsp_2 = ent.decimalesDsp_2,
                decimalesDsp_3 = ent.decimalesDsp_3,
                decimalesDsp_4 = ent.decimalesDsp_4,
                empaqueDsp_1 = ent.empaqueDsp_1,
                empaqueDsp_2 = ent.empaqueDsp_2,
                empaqueDsp_3 = ent.empaqueDsp_3,
                empaqueDsp_4 = ent.empaqueDsp_4,
                pdfDsp_1 = ent.pdfDsp_1,
                pdfDsp_2 = ent.pdfDsp_2,
                pdfDsp_3 = ent.pdfDsp_3,
                pdfDsp_4 = ent.pdfDsp_4,
                //pnetoDsp_1 = ent.pnetoDsp_1,
                //pnetoDsp_2 = ent.pnetoDsp_2,
                //pnetoDsp_3 = ent.pnetoDsp_3,
                //pnetoDsp_4 = ent.pnetoDsp_4,
                //
                FPeso = ent.FPeso,
                FAlto = ent.FAlto,
                FLargo = ent.FLargo,
                FAncho = ent.FAncho,
                FVolumen = ent.FVolumen,
            };
            nr.setPneto_1(ent.pneto_1);
            nr.setPneto_2(ent.pneto_2);
            nr.setPneto_3(ent.pneto_3);
            nr.setPneto_4(ent.pneto_4);
            nr.setPneto_5(ent.pneto_5);
            nr.setPnetoMay_1(ent.pnetoMay_1);
            nr.setPnetoMay_2(ent.pnetoMay_2);
            nr.setPnetoMay_3(ent.pnetoMay_3);
            nr.setPnetoMay_4(ent.pnetoMay_4);
            nr.setPnetoDsp_1(ent.pnetoDsp_1);
            nr.setPnetoDsp_2(ent.pnetoDsp_2);
            nr.setPnetoDsp_3(ent.pnetoDsp_3);
            nr.setPnetoDsp_4(ent.pnetoDsp_4);
            result.Entidad = nr;

            return result;
        }
        public OOB.Resultado.Lista<OOB.Producto.Lista.Ficha> 
            Producto_GetLista(OOB.Producto.Lista.Filtro filtro)
        {
            var result = new OOB.Resultado.Lista<OOB.Producto.Lista.Ficha>();

            var filtroDTO = new DtoLibPos.Producto.Lista.Filtro()
            {
                AutoDeposito = filtro.autoDeposito,
                IdPrecioManejar = filtro.idPrecioManejar,
                Cadena = filtro.cadena,
                IsPorPlu=filtro.isPorPlu,
            };
            var r01 = MyData.Producto_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst = new List<OOB.Producto.Lista.Ficha>();
            if (r01.Lista != null) 
            {
                if (r01.Lista.Count > 0) 
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Producto.Lista.Ficha()
                        {
                            Auto = s.Auto,
                            Codigo = s.Codigo,
                            Contenido = s.Contenido,
                            Decimales = s.Decimales,
                            Empaque = s.Empaque,
                            Estatus = s.Estatus,
                            EstatusDivisa = s.EstatusDivisa,
                            EstatusPesado = s.EstatusPesado,
                            ExDisponible = s.ExDisponible,
                            ExFisica = s.ExFisica,
                            Nombre = s.Nombre,
                            PrecioFullDivisa = s.PrecioFullDivisa,
                            PrecioNeto = s.PrecioNeto,
                            TasaIva = s.TasaIva,
                            PLU = s.PLU,
                            ContenidoMay = s.contenidoMay,
                            DecimalesMay = s.decimalesMay,
                            EmpaqueMay = s.empaqueMay,
                            PrecioFullDivisaMay = s.precioFullDivisaMay,
                            //
                            contEmp_1 = s.contEmp_1,
                            contEmp_2 = s.contEmp_2,
                            contEmp_3 = s.contEmp_3,
                            descEmp_1 = s.descEmp_1,
                            descEmp_2 = s.descEmp_2,
                            descEmp_3 = s.descEmp_3,
                            pnetoEmp_1 = s.pnetoEmp_1,
                            pnetoEmp_2 = s.pnetoEmp_2,
                            pnetoEmp_3 = s.pnetoEmp_3,
                            pfullDivEmp_1 = s.pfullDivEmp_1,
                            pfullDivEmp_2 = s.pfullDivEmp_2,
                            pfullDivEmp_3 = s.pfullDivEmp_3,
                            //
                            contEmpCompra = s.contEmpCompra,
                            contEmpInv = s.contEmpInv,
                            descEmpCompra = s.descEmpCompra,
                            descEmpInv = s.descEmpInv,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }
        public OOB.Resultado.FichaEntidad<OOB.Producto.Existencia.Entidad.Ficha> 
            Producto_Existencia_GetByPrdDeposito(OOB.Producto.Existencia.Buscar.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Producto.Existencia.Entidad.Ficha>();

            var fichaDTO = new DtoLibPos.Producto.Existencia.Buscar.Ficha()
            {
                autoDeposito = ficha.autoDeposito,
                autoPrd = ficha.autoPrd,
            };
            var r01 = MyData.Producto_Existencia_GetByPrdDeposito(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent= r01.Entidad;
            var nr = new OOB.Producto.Existencia.Entidad.Ficha()
            {
                autoDeposito = ent.autoDeposito,
                autoPrd = ent.autoPrd,
                codigoDeposito = ent.codigoDeposito,
                codigoPrd = ent.codigoPrd,
                exDisponible = ent.exDisponible,
                exFisica = ent.exFisica,
                nombreDeposito = ent.nombreDeposito,
                nombrePrd = ent.nombrePrd,
            };
            result.Entidad=nr;

            return result;
        }
        public OOB.Resultado.FichaEntidad<OOB.Producto.Costo.Ficha> 
            Producto_GetCosto_By(string idPrd)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Producto.Costo.Ficha>();
            var r01 = MyData.Producto_GetCosto_By(idPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var r = r01.Entidad;
            result.Entidad = new OOB.Producto.Costo.Ficha()
            {
                contEmpCompra = r.contEmpCompra,
                costoEmpCompraDivisa = r.costoEmpCompraDivisa,
                costoEmpCompraMonLocal = r.costoEmpCompraMonLocal,
                costoUndCompraMonLocal = r.costoUndCompraMonLocal,
                descPrd = r.descPrd,
                idPrd = r.idPrd,
            };
            return result;
        }
    }
}