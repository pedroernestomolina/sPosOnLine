using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface IConcepto
    {

        OOB.Resultado.FichaEntidad<OOB.Concepto.Entidad.Ficha> Concepto_GetFichaById(string id);
        OOB.Resultado.Lista<OOB.Concepto.Entidad.Ficha> Concepto_GetLista();

    }

}