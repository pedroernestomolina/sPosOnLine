using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Src.Identificacion
{
    
    public interface IIdentifica: IGestion
    {

        bool IsOk { get; }


        void Aceptar();
        void SetCodigo(string p);
        void SetClave(string p);

    }

}