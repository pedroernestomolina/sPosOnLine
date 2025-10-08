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
                    descEmpqVta=s.descEmpqVta,
                    aplicaPorcAumento = (s.estatusAplicaPorcAumento == "" && s.estatusAdmPorDivisa.Trim().ToUpper() != "1")
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
        public OOB.Resultado.Ficha 
            PosCambioPrecio_ProcesarCambio(OOB.PosCambioPrecio.ProcesarCambiar.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();
            //
            try
            {
                var fichaDTO = new DtoLibPos.PosCambioPrecio.ProcesarCambio.Ficha()
                {
                    item = new DtoLibPos.PosCambioPrecio.ProcesarCambio.DataItem()
                    {
                        idItem = ficha.item.idItem,
                        idOperador = ficha.item.idOperador,
                        pFullMonDiv = ficha.item.pFullMonDiv,
                        pNetoMonAct = ficha.item.pNetoMonAct,
                        aplicarPorcAumento = ficha.item.AplicarPorcAumentoPrdNoDivisa,
                    },
                    logReg = new DtoLibPos.PosCambioPrecio.ProcesarCambio.LogReg()
                    {
                        accion = ficha.logReg.accion,
                        codigoUsuarioAutoriza = ficha.logReg.codigoUsuarioAutoriza,
                        descripcion = ficha.logReg.descripcion,
                        idOperador = ficha.logReg.idOperador,
                        idUsuarioAutoriza = ficha.logReg.idUsuarioAutoriza,
                        nombreUsuarioAutoriza = ficha.logReg.nombreUsuarioAutoriza,
                    },
                };
                var rt = MyData.PosCambioPrecio_ProcesarCambio(fichaDTO);
                if (rt.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt.Mensaje);
                }
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