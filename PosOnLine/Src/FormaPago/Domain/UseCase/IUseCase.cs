using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.Domain.UseCase
{
    public interface IUseCase
    {
        List<Models.MedioPago> CargarMediosPagoUseCase();
        Models.Moneda CargarMonedaLocal();
        Models.Moneda CargarMonedaReferencia();
        Models.MedioPago CargarMedioPagoPorBonoDivisa();
        bool CargarEstatusCreditoCliente(string idCliente);
    }
}