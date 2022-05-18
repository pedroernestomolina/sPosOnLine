using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface IReportePos
    {

        OOB.Resultado.Lista<OOB.Reportes.Pos.PagoDetalle.Ficha> ReportePos_PagoDetalle(OOB.Reportes.Pos.Filtro filtro);
        OOB.Resultado.Lista<OOB.Reportes.Pos.PagoResumen.Ficha> ReportePos_PagoResumen(OOB.Reportes.Pos.Filtro filtro);

    }

}