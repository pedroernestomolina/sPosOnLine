using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Data.Infra
{

    public interface IVerificador
    {


        OOB.Resultado.FichaEntidad<OOB.Verificador.Entidad.Ficha>
            Verificador_GetFichaById(int id);
        OOB.Resultado.FichaId
            Verificador_GetFichaByAutoDoc(string audtoDoc);
        OOB.Resultado.Ficha
            Verificador_VerificarFicha(OOB.Verificador.Verificar.Ficha ficha);

    }

}