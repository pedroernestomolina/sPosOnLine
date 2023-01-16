using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Anular
{
    public interface IAnular: IGestion, Helpers.IAbandonar, Helpers.IProcesar
    {
        string GetMotivo { get; }
        void setMotivo(string desc);
    }
}