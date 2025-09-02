using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public List<Models.MedioPago>
            CargarMediosPagoUseCase()
        {
            var rt = new List<Models.MedioPago>();
            //
            var result = Sistema.MyData.MedioPago_GetLista();
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                throw new Exception(result.Mensaje);
            }
            rt = result.ListaD.
                Where(w=> w.aplicaParaPOS && w.aplicaParaCobro).
                Select(s =>
            {
                var nr = new Models.MedioPago()
                {
                    codigoCurrencies = s.codigoCurrencies,
                    codigoMp = s.codigoMp,
                    idCurrencies = s.idCurrencies,
                    idMp = s.idMp,
                    nombreCurrencies = s.nombreCurrencies,
                    nombreMp = s.nombreMp,
                    simboloCurrencies = s.simboloCurrencies,
                    aplicaLoteRef = s.aplicaLoteRef,
                    aplicaBonoPagoDivisa= s.aplicaBonoPagoDivisa,
                };
                return nr;
            }).ToList();
            //
            return rt;
        }
        public Models.Moneda 
            CargarMonedaLocal()
        {
            var rt = new Models.Moneda();
            //
            var result = Sistema.MyData.Configuracion_MonedaLocal ();
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(result.Mensaje);
            }
            if (result.Entidad == null) 
            {
                throw new Exception("PROBLEMA AL CARGAR DATA");
            }
            var s = result.Entidad;
            rt = new Models.Moneda()
            {
                id = s.id,
                codigo = s.codigo,
                nombre = s.nombre,
                simbolo = s.simbolo,
            };
            //
            return rt;
        }
        public Models.Moneda 
            CargarMonedaReferencia()
        {
            var rt = new Models.Moneda();
            //
            var result = Sistema.MyData.Configuracion_MonedaReferencia();
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(result.Mensaje);
            }
            if (result.Entidad == null)
            {
                throw new Exception("PROBLEMA AL CARGAR DATA");
            }
            var s = result.Entidad;
            rt = new Models.Moneda()
            {
                id = s.id,
                codigo = s.codigo,
                nombre = s.nombre,
                simbolo = s.simbolo,
            };
            //
            return rt;
        }
        public Models.MedioPago 
            CargarMedioPagoPorBonoDivisa()
        {
            var rt = new Models.MedioPago();
            //
            var result = Sistema.MyData.Configuracion_MedioPagoPorPagoBonoDivisa();
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(result.Mensaje);
            }
            if (result.Entidad == null)
            {
                throw new Exception("PROBLEMA AL CARGAR DATA");
            }
            var s = result.Entidad;
            rt = new Models.MedioPago()
            {
                codigoCurrencies = s.codigoCurrencies,
                codigoMp = s.codigoMp,
                idCurrencies = s.idCurrencies,
                idMp = s.idMp,
                nombreCurrencies = s.nombreCurrencies,
                nombreMp = s.nombreMp,
                simboloCurrencies = s.simboloCurrencies,
                aplicaLoteRef = s.aplicaLoteRef,
                aplicaBonoPagoDivisa = s.aplicaBonoPagoDivisa,
            };
            //
            return rt;
        }
        public bool 
            CargarEstatusCreditoCliente(string idCliente)
        {
            var rt = false;
            //
            var result = Sistema.MyData.Cliente_GetEstatusCredito(idCliente);
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(result.Mensaje);
            }
            if (result.Entidad == null)
            {
                throw new Exception("PROBLEMA AL CARGAR DATA");
            }
            rt = result.Entidad;
            //
            return rt;
        }
    }
}
