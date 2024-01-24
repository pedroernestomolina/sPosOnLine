using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.AgregarEditar.Vista
{
    public interface IAgregarEditar: IGestion
    {
        __.Ctrl.Boton.Abandonar.IAbandonar Abandonar { get; }
        __.Ctrl.Boton.Procesar.IProcesar Procesar { get; }
        string Get_AccionFicha { get; }
        IDataFicha DataFicha { get; }
        void ProcesarGuardar();
    }
}