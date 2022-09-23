using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pago.ValidarCambio
{
    
    public interface IValidarCambio: IGestion, Helpers.IAbandonar, Helpers.IProcesar
    {

        bool ValidarCambioIsOk { get; }
        PagoMovil.data PagoMovilData { get; }
        void setMontoValidar(decimal montoValidar);
        void setTasaCambio(decimal tasaCambio);
        void setPorctBonoPorPagoDivisa(decimal _porctBonoPorPagoDivisa);
        void setDatosCliente(OOB.Cliente.Entidad.Ficha entCliente);
        bool PagoMovilIsOk { get; }
        decimal GetMontoPorEfectivo { get; }
        decimal GetMontoPorDivisa { get; }
        decimal GetMontoPorPagoMovil { get; }
        int GetCantDivisa { get; }

    }

}