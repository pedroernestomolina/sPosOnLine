using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPagoSolicitudPagoMovil.Domain.UseCase
{
    public interface IUseCase
    {
        List<Models.Agencia>
            CargarAgenciasUseCase();
    }
}