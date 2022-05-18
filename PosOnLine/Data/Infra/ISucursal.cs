using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface ISucursal
    {

        OOB.Resultado.FichaEntidad<OOB.Sucursal.Entidad.Ficha> 
            Sucursal_GetFichaById(string id);
        OOB.Resultado.FichaEntidad<string> 
            Sucursal_GetFicha_ByCodigo(string codigo);
        OOB.Resultado.Lista<OOB.Sucursal.Entidad.Ficha> 
            Sucursal_GetLista();

    }

}