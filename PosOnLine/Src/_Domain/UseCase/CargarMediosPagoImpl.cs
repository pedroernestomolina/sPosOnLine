using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src._Domain.UseCase
{
    public class CargarMediosPagoImpl: ICargarMediosPago
    {
        public List<Models.MedioPago> 
            Invoke()
        {
            var rt = new List<Models.MedioPago>();
            //
            var result = Sistema.MyData.MedioPago_GetLista();
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(result.Mensaje);
            }
            rt = result.ListaD.
                Where(w => w.aplicaParaPOS && w.aplicaParaCobro).
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
                        aplicaBonoPagoDivisa = s.aplicaBonoPagoDivisa,
                        aplicaIGTF = s.aplicaIGTF,
                    };
                    return nr;
                }).ToList();
            //
            return rt;
        }
    }
}