using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.CtrlPendiente.Proteger.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public void ProtegerCuenta(int idCta)
        {
            try
            {
                var rst = Sistema.MyData.Pendiente_AsignarEstatusCtaProtegida(idCta);
                if (rst.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(rst.Mensaje);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
