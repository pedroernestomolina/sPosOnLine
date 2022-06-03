using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Data.Infra
{
    
    public interface IDocumento
    {

        OOB.Resultado.FichaEntidad<OOB.Documento.Entidad.Ficha>
            Documento_GetFichaById(string id);
        OOB.Resultado.FichaEntidad<int>
            Documento_GetDocNCR_Relacionados_ByAutoDoc(string autoDoc);

    }

}