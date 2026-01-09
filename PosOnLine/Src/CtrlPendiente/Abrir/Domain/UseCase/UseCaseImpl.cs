using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.CtrlPendiente.Abrir.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public void  AbrirCuentaPendiente(int id)
        {
            try
            {
                var r01 = Sistema.MyData.Pendiente_AbrirCta(id, Sistema.PosEnUso.id);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}