using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreProceso.Domain.ReglaNegocio
{
    public class RuleImpl: IRule
    {
        public void CuentasPendientes()
        {
            try
            {
                int idPosUso = -1;
                if (!Sistema.ModoAbrirDocPendOtrosUsuarios)
                    idPosUso = Sistema.PosEnUso.id;
                var r01 = Sistema.MyData.Pendiente_CtasPendientes(idPosUso);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (r01.Entidad > 0)
                {
                    throw new Exception("HAY CUENTAS PENDIENTES EN PROCESO !!");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}