using PosOnLine.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Prov
{
    public partial class DataPrv : IData
    {
        public OOB.Resultado.FichaEntidad<OOB.PosCambioPrecio.ObtenerDataItem.Ficha> 
            PosCambioPrecio_ObtenerDataItem(int idItem)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.PosCambioPrecio.ObtenerDataItem.Ficha>();
            //
            try
            {
                var rt = MyData.PosCambioPrecio_ObtenerDataItem(idItem);
                if (rt.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt.Mensaje);
                }
                if (rt.Entidad == null)
                {
                    throw new Exception("DATA [ ITEM ] NO CARAGADA");
                }
                var s= rt.Entidad;
                result.Entidad = new OOB.PosCambioPrecio.ObtenerDataItem.Ficha()
                {
                    codigoPrd = s.codigoPrd,
                    contEmpqVta = s.contEmpqVta,
                    costoEmpqUndMonLocal = s.costoUnd,
                    descPrd = s.descPrd,
                    idItem = s.idItem,
                    idOperador = s.idOperador,
                    isAdmPorDivisa = s.estatusAdmPorDivisa.Trim().ToUpper() == "1",
                    pFullMonReferencia = s.pFullMonReferencia,
                    pNetoMonLocal = s.pNetoMonLocal,
                    tasaIva = s.tasaIva,
                    contEmpqCompra = s.contEmpqCompra,
                    costoEmpqCompraMonReferencia = s.costoDivisaEmpqCompra,
                };
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
    }
}