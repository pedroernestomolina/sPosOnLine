using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.TasaCambioPos.Vm
{
    public interface ITasaCambioPos
    {
        decimal GetTasaPosInput { get; }
        bool AbandonarFichaIsOK { get; }
        bool CambioIsOK { get; }
        decimal GetTasaSistemaActualizada { get; }
        decimal GetDsctoBonoPagoDivisaActualizado { get; }
        List<OOB.Venta.Item.Entidad.Ficha> GetListaItemsActualizados { get; }
        //
        void Invoke();    
        void setTasaPos(decimal tasa);
        void AbandonarFicha();
        void ProcesarFicha();
    }
}