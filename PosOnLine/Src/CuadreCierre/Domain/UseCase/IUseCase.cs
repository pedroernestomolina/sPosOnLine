using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.Domain.UseCase
{
    public interface IUseCase
    {
        Domain.Models.DataResumenRecolectada
            CuadreResumen(int id);
        List<Domain.Models.RepoPagoDetalleEnc>
            ReportePagoDetalle(int id);
        Domain.Models.RepoPagoResumen
            ReportePagoResumen(int id);
        List<Domain.Models.RepoVentaCredito>
            ReporteVentaCredito(int id);
        List<Domain.Models.RepoCambiosVuelto>
            ReporteCambiosVueltoEntregado(int id);
        List<Domain.Models.RepoPagoMovil>
            ReportePagoMovilPorRealizar(int id);
    }
}