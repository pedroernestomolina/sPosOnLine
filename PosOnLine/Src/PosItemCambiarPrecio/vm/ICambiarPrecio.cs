using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PosItemCambiarPrecio.vm
{
    public interface ICambiarPrecio
    {
        decimal Get_PrecioPagoBs { get; }
        decimal Get_PrecioPagoPrdNoDivisa { get; }
        decimal Get_PrecioPagoDivisa { get; }
        decimal PrecioIngresado { get; }
        bool AbandonarFichaIsOK { get; }
        bool ProcesarCambioIsOK { get; }
        //
        void Invoke(int idItem);
        void AbandonarFicha();
        void ProcesarCambio();
    }
}