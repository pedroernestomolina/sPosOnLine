using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    public interface IMoneda
    {
        OOB.Resultado.Lista<OOB.Moneda.Entidad.Ficha>
            Moneda_GetLista();
        OOB.Resultado.FichaEntidad<OOB.Moneda.Entidad.Ficha>
            Moneda_GetFichaById(int id);
    }
}
