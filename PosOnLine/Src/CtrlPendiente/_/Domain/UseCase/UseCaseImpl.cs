using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.CtrlPendiente.__.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public bool VerificaSiCuentaAbrirEstaProtegida(int idCta)
        {
            try
            {
                var r01 = Sistema.MyData.Pendiente_VerificarEstatusCtaProtegida(idCta);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                return r01.Entidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
