using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AsignarVededor
{
    public interface IModo: IGestion,  Helpers.IAbandonar , Helpers.IProcesar
    {
        string IdVendedorSeleccionado { get; }
        bool AsignarVendedorIsOk { get; }
    }
}