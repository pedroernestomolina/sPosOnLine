using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pos.Domain.UseCase
{
    public class UseCaseImpl : IUseCase
    {
        public Models.ResultadoAgregarDoc
            AgregarFactura(OOB.Documento.Agregar.Factura.Ficha doc)
        {
            var result = Sistema.MyData.Documento_Agregar_Factura(doc);
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(result.Mensaje);
            }
            if (result.Entidad == null)
            {
                throw new Exception("DATA NO CARGADA");
            }
            var s = result.Entidad;
            var rt = new Models.ResultadoAgregarDoc()
            {
                autoCierre = s.autoCierre,
                autoDoc = s.autoDoc,
                codDoc = s.codDoc,
                idVerificador = s.idVerificador,
                montoDoc = s.montoDoc,
                numDoc = s.numDoc,
            };
            return rt;
        }
        public Models.ResultadoAgregarDoc
            AgregarNotaCredito(OOB.Documento.Agregar.NotaCredito.Ficha doc)
        {
            var result = Sistema.MyData.Documento_Agregar_NotaCredito(doc);
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(result.Mensaje);
            }
            if (result.Auto == "")
            {
                throw new Exception("DATA NO CARGADA");
            }
            var rt = new Models.ResultadoAgregarDoc()
            {
                autoCierre = "",
                autoDoc = result.Auto,
                codDoc = "",
                idVerificador = -1,
                montoDoc = 0m,
                numDoc = "",
            };
            return rt;
        }
        public decimal 
            TasaActualSistema()
        {
            var result = Sistema.MyData.Configuracion_TasaCambioSistema();
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(result.Mensaje);
            }
            return result.Entidad;
        }
        public Models.CuentaControl 
            ObtenerMiCuentaControl(int idOperador)
        {
            try
            {
                var result = Sistema.MyData.PosCtaControl_ObtenerDatosCtaControl(idOperador);
                if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(result.Mensaje);
                }
                var f = result.Entidad;
                return new Models.CuentaControl()
                {
                    idCliente = f.IdCliente,
                    idCtaControl = f.IdCtaControl,
                    isProtegida = f.IsProtegida,
                    TasaPos = f.TasaPos,
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool 
            VerificaSiExisteCuentaControlParaEsteOperador(int idOperador)
        {
            try
            {
                var result = Sistema.MyData.PosCtaControl_VerificaSiExisteParaEsteOperador(idOperador);
                if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(result.Mensaje);
                }
                return result.Entidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public decimal 
            ObtenerTasaPosActual()
        {
            try
            {
                var result = Sistema.MyData.Configuracion_FactorDivisa();
                if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(result.Mensaje);
                }
                return result.Entidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool
            LimpiarOperadorControl(int idOperador)
        {
            try
            {
                var rt = Sistema.MyData.PosCtaControl_LimpiarDadoOperador(idOperador);
                if (rt.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(rt.Mensaje);
                }
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}