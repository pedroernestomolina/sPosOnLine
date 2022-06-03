using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Data.Infra
{
    
    public interface IUsuario
    {

        OOB.Resultado.FichaEntidad<OOB.Usuario.Entidad.Ficha> 
            Usuario_Identifica(OOB.Usuario.Identificar.Ficha ficha);

    }

}