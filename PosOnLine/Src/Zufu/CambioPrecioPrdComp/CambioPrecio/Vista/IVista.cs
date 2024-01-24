using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.CambioPrecioPrdComp.CambioPrecio.Vista
{
    public interface IVista: IPosZufuCambioPrecioPrd 
    {
        Idata DataFicha { get; }
        IdataPanel DataPanel { get; }
        __.Ctrl.Boton.Abandonar.IAbandonar BtAbandonar { get; }
        __.Ctrl.Boton.Procesar.IProcesar BtProcesar { get; }
        //
        void PanelInformativo();
        void Procesar();
        void AplicarBono(bool modo);
        void setPrecioNuevo(decimal precio);
    }
}