using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface IAgencia
    {

        OOB.Resultado.Lista<OOB.Agencia.Entidad.Ficha>
            Agencia_GetLista(OOB.Agencia.Lista.Filtro filtro);


        OOB.Resultado.FichaAuto
            Agencia_Agregar(OOB.Agencia.Agregar.Ficha ficha);

    }

}