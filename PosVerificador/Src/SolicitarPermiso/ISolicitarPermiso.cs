using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Src.SolicitarPermiso
{
    
    public interface ISolicitarPermiso: IGestion
    {

        bool IsOk { get; }
        string GetUsuario { get; }
        string GetPassword { get; }
        bool AceptarIsOk { get; }
        bool AbandonarIsOk { get; }
        string GetSolicitudMotivo { get; }


        void Aceptar();
        void Abandonar();
        void setUsuario(string p);
        void setClave(string p);
        void setMotivoSolicitud(string mot);

    }

}