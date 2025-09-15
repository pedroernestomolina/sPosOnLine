using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src._Domain.UseCase
{
    public class CargarMedioPagoPorBonoDivisaImpl: ICargarMedioPagoPorBonoDivisa
    {
        public Models.MedioPago 
            Invoke()
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
    }
}