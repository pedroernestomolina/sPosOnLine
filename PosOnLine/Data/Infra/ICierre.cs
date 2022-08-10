using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface ICierre
    {

        OOB.Resultado.Lista<OOB.Cierre.Lista.Ficha>
           Cierre_Lista_GetByFiltro(OOB.Cierre.Lista.Filtro filtro);
        OOB.Resultado.FichaEntidad<OOB.Cierre.Entidad.Ficha>
            Cierre_GetById(int idCierre);

    }

}