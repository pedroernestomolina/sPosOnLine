using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Agencia.Agregar
{
    
    public interface IAgregar: IGestion
    {

        bool AbandonarIsOk { get; }
        bool ProcesarIsOk { get; }
        bool IsOk { get; }
        string GetAgencia { get; }


        void AbandonarFicha();
        void ProcesarFicha();


        void setNombre(string p);

    }

}