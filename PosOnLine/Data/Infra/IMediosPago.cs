using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    public interface IMediosPago
    {
        OOB.Resultado.Lista<OOB.MediosPago.Entidad.Ficha>
            MedioPago_GetLista();
        OOB.Resultado.FichaEntidad<OOB.MediosPago.Entidad.Ficha>
            MedioPago_GetFichaById(string id);
    }
}