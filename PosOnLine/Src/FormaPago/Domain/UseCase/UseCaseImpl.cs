using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
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
        public Models.ConfiguracionIGTF 
            CargarConfiguracionIGTF()
        {
            var rt = new Models.ConfiguracionIGTF();
            //
            var result= Sistema.MyData.Configuracion_IGTF();
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(result.Mensaje);
            }
            if (result.Entidad == null)
            {
                throw new Exception("PROBLEMA AL CARGAR DATA");
            }
            rt = new Models.ConfiguracionIGTF()
            {
                aplica = result.Entidad.ActivarIGTF,
                tasa = result.Entidad.TasaIGTF,
            };
            //
            return rt;
        }
        public List<Models.Moneda> 
            CargarMonedas()
        {
            var rt = new List<Models.Moneda>();
            //
            var result = Sistema.MyData.Moneda_GetLista();
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(result.Mensaje);
            }
            rt = result.ListaD.Select(s =>
                {
                    var nr = new Models.Moneda()
                    {
                        codigo = s.codigo,
                        id = s.id,
                        nombre = s.nombre,
                        simbolo = s.simbolo,
                        tasaRespectoMonReferencia = s.tasaRespectoMonReferencia,
                    };
                    return nr;
                }).ToList();
            //
            return rt;
        }
        public bool
            CargarConfiguracionBonoPorPagoDivisa()
        {
            var r01 = Sistema.MyData.Configuracion_HabilitarDescuentoUnicamenteConPagoEnDivsa();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            //
            return r01.Entidad;
        }
    }
}