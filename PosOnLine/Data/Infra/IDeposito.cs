using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface IDeposito
    {

        OOB.Resultado.Lista<OOB.Deposito.Entidad.Ficha> Deposito_GetLista(OOB.Deposito.Lista.Filtro filtro);
        OOB.Resultado.FichaEntidad <OOB.Deposito.Entidad.Ficha> Deposito_GetFichaById(string id);
        OOB.Resultado.FichaEntidad<OOB.Deposito.Entidad.Ficha> Deposito_GetFicha_ByCodigo(string codigo);

    }

}