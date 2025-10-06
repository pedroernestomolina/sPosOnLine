using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PosItemCambiarPrecio.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public Models.ItemCambio 
            CargarItem(int idItem)
        {
            try
            {
                var rstItem = Sistema.MyData.PosCambioPrecio_ObtenerDataItem(idItem);
                if (rstItem.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(rstItem.Mensaje);
                }
                var rstPorctAumento = Sistema.MyData.Configuracion_PorcentajeAumentarEnPreciosDeProductosNoAdministradoPorDivisa();
                if (rstPorctAumento.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rstPorctAumento.Mensaje);
                }
                var rstFactorDivisa = Sistema.MyData.Configuracion_FactorDivisa();
                if (rstFactorDivisa.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rstFactorDivisa.Mensaje);
                }
                var rstTasaDivisaSistema = Sistema.MyData.Configuracion_TasaCambioSistema();
                if (rstTasaDivisaSistema.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rstTasaDivisaSistema.Mensaje);
                }
                var it = rstItem.Entidad;
                return new Models.ItemCambio()
                {
                    TasaDivisaPos = rstFactorDivisa.Entidad,
                    TasaDivisaSistema = rstTasaDivisaSistema.Entidad,
                    PorctAumentoPrdNoAdmPorDivisa = rstPorctAumento.Entidad,
                    Item = new Models.Item()
                    {
                        codigoPrd = it.codigoPrd,
                        contEmpqVta = it.contEmpqVta,
                        costoEmpqUndMonLocal = it.costoEmpqUndMonLocal,
                        descPrd = it.descPrd,
                        idItem = it.idItem,
                        idOperador = it.idOperador,
                        isAdmPorDivisa = it.isAdmPorDivisa,
                        pFullMonReferencia = it.pFullMonReferencia,
                        pNetoMonLocal = it.pNetoMonLocal,
                        tasaIva = it.tasaIva,
                        costoEmpqCompraMonReferencia = it.costoEmpqCompraMonReferencia,
                        contEmpqCompra = it.contEmpqCompra,
                    }
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}