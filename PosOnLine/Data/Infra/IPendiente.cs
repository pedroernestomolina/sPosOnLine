using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    public interface IPendiente
    {
        OOB.Resultado.Ficha 
            Pendiente_DejarCta(OOB.Pendiente.DejarCta.Ficha ficha);
        OOB.Resultado.FichaEntidad<int> 
            Pendiente_CtasPendientes(int idOperador);
        OOB.Resultado.Lista<OOB.Pendiente.Lista.Ficha> 
            Pendiente_Lista(OOB.Pendiente.Lista.Filtro filtro);
        OOB.Resultado.Ficha 
            Pendiente_AbrirCta(int idCta, int idOperador);
        OOB.Resultado.FichaEntidad<bool>
            Pendiente_VerificarEstatusCtaProtegida(int idCta);
        OOB.Resultado.Ficha
            Pendiente_AsignarEstatusCtaProtegida(int idCta);
        OOB.Resultado.Ficha
            Pendiente_QuitarEstatusCtaProtegida(int idCta);
        //
        OOB.Resultado.FichaEntidad<int> 
            Pendiente_CtasPendientesSinProteger(int idPosUso);
    }
}