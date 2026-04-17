using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PedidoWeb.Domain.UseCase
{
    public interface IUseCase
    {
        IEnumerable<Domain.Models.PedidoWeb>
            ObtenerListaDePedidosWebActivosSinProcesar();
    }
}