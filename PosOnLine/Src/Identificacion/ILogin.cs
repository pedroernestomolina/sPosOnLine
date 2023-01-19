using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Identificacion
{
    public interface ILogin: IGestion, Helpers.IAbandonar
    {
        bool LoginIsOk { get; }

        string GetCodigo { get; }
        string GetClave { get; }
        void setCodigo(string desc);
        void setClave(string psw);

        void Aceptar();
    }
}