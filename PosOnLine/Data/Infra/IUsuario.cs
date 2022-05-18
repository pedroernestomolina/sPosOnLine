using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface IUsuario
    {

        OOB.Resultado.FichaEntidad<OOB.Usuario.Entidad.Ficha> Usuario_Identificar(OOB.Usuario.Identificar.Ficha ficha);

    }

}