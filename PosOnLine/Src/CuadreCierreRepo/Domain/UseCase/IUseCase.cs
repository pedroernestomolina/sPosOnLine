using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreRepo.Domain.UseCase
{
    public interface IUseCase
    {
        Domain.Models.RepoPagoResumen
            ReportePagoResumen(int id);
        List<Domain.Models.RepoVentaCredito>
            ReporteVentaCredito(int id);
        List<Domain.Models.RepoCambiosVuelto>
            ReporteCambiosVueltoEntregado(int id);
        List<Domain.Models.RepoPagoMovil>
            ReportePagoMovilPorRealizar(int id);
        List<Models.RepoPagoDetalleEnc> 
            ReportePagoDetalle(int id);
    }
}