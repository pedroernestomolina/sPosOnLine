using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Data.Infra
{
    
    public interface IReportes
    {

        OOB.Resultado.Lista<OOB.Reportes.DocVerificados.Ficha>
            Reportes_DocVerificados(OOB.Reportes.Filtro filtro);

    }

}