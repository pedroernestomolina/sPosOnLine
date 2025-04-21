using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Cierre
{
    public class Utils
    {
        static public void VentCredito(string idCierre)
        {
            try
            {
                var filtro = new OOB.Reportes.Pos.VentCredito.Filtro()
                {
                    IdCierre = idCierre,
                };
                var r01 = Sistema.MyData.ReportePos_VentCredito(filtro);
                var rp1 = new Reportes.Cierre.VentCredito.Movimiento(r01.ListaD);
                rp1.Generar();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return;
            }
        }
        static public void ReporteDetalle(string idCierre)
        {
            try
            {
                var filtro = new OOB.Reportes.Pos.Filtro()
                {
                    idCierre = idCierre,
                };
                var r01 = Sistema.MyData.ReportePos_PagoDetalle(filtro);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                var rp1 = new Reportes.Cierre.Detalle.Movimiento(r01.ListaD);
                rp1.setMontoNtCredito(0m);
                rp1.Generar();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        static public void ReporteResumen(string idCierre)
        {
            try
            {
                var filtro = new OOB.Reportes.Pos.Filtro()
                {
                    idCierre = idCierre,
                };
                var r01 = Sistema.MyData.ReportePos_PagoResumen(filtro);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                var rp1 = new Reportes.Cierre.Resumen.Movimiento(r01.ListaD);
                rp1.setMontoNtCredito(0m);
                rp1.setMontoCambioDar(0m);
                rp1.Generar();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}