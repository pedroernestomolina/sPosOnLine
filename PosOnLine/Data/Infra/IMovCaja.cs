using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    public interface IMovCaja
    {
        OOB.Resultado.FichaId
            MovCaja_Registrar(OOB.MovCaja.Registrar.Ficha ficha);
        OOB.Resultado.Ficha
            MovCaja_Anular(OOB.MovCaja.Anular.Ficha ficha);
        OOB.Resultado.FichaEntidad<OOB.MovCaja.Entidad.Ficha>
            MovCaja_GetById(int id);
        OOB.Resultado.Lista<OOB.MovCaja.Entidad.Ficha>
            MovCaja_GetLista(OOB.MovCaja.Lista.Filtro filtro);
    }
}