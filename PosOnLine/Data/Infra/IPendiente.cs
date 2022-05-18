using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface IPendiente
    {

        OOB.Resultado.Ficha Pendiente_DejarCta(OOB.Pendiente.DejarCta.Ficha ficha);
        OOB.Resultado.FichaEntidad<int> Pendiente_CtasPendientes(int idOperador);
        OOB.Resultado.Lista<OOB.Pendiente.Lista.Ficha> Pendiente_Lista(OOB.Pendiente.Lista.Filtro filtro);
        OOB.Resultado.Ficha Pendiente_AbrirCta(int idCta, int idOperador);

    }

}