using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface IVendedor
    {

        OOB.Resultado.FichaEntidad<OOB.Vendedor.Entidad.Ficha> Vendedor_GetFichaById(string id);
        OOB.Resultado.Lista<OOB.Vendedor.Entidad.Ficha> Vendedor_GetLista();

    }

}