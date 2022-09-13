using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pago.LoteReferencia
{
    
    public interface ILoteRef: IGestion, Helpers.IAbandonar, Helpers.IProcesar
    {

        void setNroLote(string nro);
        void setNroReferencia(string nro);


        string GetNroLote { get; }
        string GetNroReferencia { get; }

    }

}