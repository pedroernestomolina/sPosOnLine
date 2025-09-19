using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    public interface ICuadreCierre
    {
        OOB.Resultado.Lista<OOB.CuadreCierre.CuadreResumen.MetodoPago>
           CuadreCierre_Get_CuadreResumenMetodoPago_byId(int idResumen);
        OOB.Resultado.Lista<OOB.CuadreCierre.CuadreResumen.Documento>
           CuadreCierre_Get_CuadreResumenDocumento_byId(int idResumen);
        OOB.Resultado.FichaEntidad<OOB.CuadreCierre.CuadreResumen.Totales>
           CuadreCierre_Get_CuadreResumenTotalesd_byId(int idResumen);
        //
        OOB.Resultado.Lista<OOB.CuadreCierre.Reportes.PagoDetalle.Ficha>
            CuadreCierre_Reporte_PagoDetalle(int idResumen);
        OOB.Resultado.FichaEntidad<OOB.CuadreCierre.Reportes.PagoResumen.Ficha>
            CuadreCierre_Reporte_PagoResumen(int idResumen);
        OOB.Resultado.Lista<OOB.CuadreCierre.Reportes.VentaCredito.Ficha>
            CuadreCierre_Reporte_VentaCredito(int idResumen);
        OOB.Resultado.Lista<OOB.CuadreCierre.Reportes.CambiosVuelto.Ficha>
            CuadreCierre_Reporte_CambiosVueltoEntregado(int idResumen);
        OOB.Resultado.Lista<OOB.CuadreCierre.Reportes.PagoMovil.Ficha>
            CuadreCierre_Reporte_PagoMovilPorRealizar(int idResumen);
    }
}