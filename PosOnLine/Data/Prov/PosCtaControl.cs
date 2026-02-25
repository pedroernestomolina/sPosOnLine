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
        public OOB.Resultado.FichaEntidad<OOB.PosCtaControl.Obtener.Ficha> 
            PosCtaControl_ObtenerDatosCtaControl(int idOperador)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.PosCtaControl.Obtener.Ficha>();
            //
            try
            {
                var rt = MyData.PosCtaControl_ObtenerDatosCtaControl(idOperador);
                if (rt.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt.Mensaje);
                }
                if (rt.Entidad == null)
                {
                    throw new Exception("DATA [ ITEM ] NO CARAGADA");
                }
                var f = rt.Entidad;
                result.Entidad = new OOB.PosCtaControl.Obtener.Ficha()
                {
                    IdCliente = f.idCliente,
                    IdCtaControl = f.idControl,
                    IsProtegida = f.estatusProtegida.Trim().ToUpper() == "1",
                    TasaPos = f.tasapos,
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
        public OOB.Resultado.FichaEntidad<bool> 
            PosCtaControl_VerificaSiExisteParaEsteOperador(int idOperador)
        {
            var result = new OOB.Resultado.FichaEntidad<bool>();
            //
           try
            {
               var rt = MyData.PosCtaControl_VerificaSiExisteParaEsteOperador(idOperador);
               if (rt.Result== DtoLib.Enumerados.EnumResult.isError)
               {
                   throw new Exception(rt.Mensaje);
               }
               result.Entidad = rt.Entidad;
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
            PosCtaControl_LimpiarDadoOperador(int idOperador)
        {
            var result = new OOB.Resultado.Ficha();
            //
            try
            {
                var rt = MyData.PosCtaControl_LimpiarDadoOperador(idOperador);
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