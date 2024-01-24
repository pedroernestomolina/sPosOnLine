using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.CambioPrecioPrdComp.PanelInformativo.Vista
{
    public interface IVista: IGestion
    {
        __.Ctrl.Boton.Salir.ISalir BtSalir { get; }
        CambioPrecio.Vista.IdataPanel DataInf { get; }
        void setDataInf(object data);
    }
}