using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPagoLoteRef.vm
{
    public interface ILoteRef: IVista
    {
        string getLote { get; }
        string getReferencia { get; }
        bool DatosValidosIsOk { get; }
        bool salidaIsOk { get; }
        void setLote(string p);
        void setReferencia(string p);
        void salir();
    }
}