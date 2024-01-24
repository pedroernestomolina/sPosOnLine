using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.Cliente.Vista
{
    public interface IVista: IPosZufuCliente
    {
        __.Ctrl.Boton.Salir.ISalir BtAceptar { get; }
        __.Ctrl.Boton.Salir.ISalir BtSalir { get; }
        __.Ctrl.Boton.Abandonar.IAbandonar BtAbandonar { get; }
        string ClienteCiRif { get; }
        string ClienteNombreRazonSocial { get; }
        string ClienteDirFiscal { get; }
        string ClienteTelefono { get; }
        IBusqueda Busqueda { get; }
        void Buscar();
        void AceptarCliente();
        void EditarCliente();
        void AbandonarFicha();
        void CerrarSinSeleccionarFicha();
    }
}