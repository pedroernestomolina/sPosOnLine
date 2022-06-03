using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Src.Principal
{

    public interface IPrincipal: IGestion
    {

        bool IsAbandonarOk { get; }
        bool LeerCodigoIsOk { get; }
        string MsgError { get; }
        string GetUsuario { get; }


        void LeerCodigo();
        void setCodigo(string cod);
        void Abandonar();
        void ReporteDocumentosVerificados();

    }

}