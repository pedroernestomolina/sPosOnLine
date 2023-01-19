using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    public interface IPermiso
    {
        OOB.Resultado.FichaEntidad<OOB.Permiso.Entidad.Ficha> 
            Permiso_Pos(OOB.Permiso.Buscar.Ficha ficha);
        OOB.Resultado.FichaEntidad<string>
            Permiso_PedirClaveAcceso_NivelMaximo();
        OOB.Resultado.FichaEntidad<string>
            Permiso_PedirClaveAcceso_NivelMedio();
        OOB.Resultado.FichaEntidad<string>
            Permiso_PedirClaveAcceso_NivelMinimo();
    }
}
