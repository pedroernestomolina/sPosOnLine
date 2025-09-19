using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.Domain.UseCase
{
    public interface IUseCase
    {
        bool 
            CargarEstatusCreditoCliente(string idCliente);
        Models.ConfiguracionIGTF 
            CargarConfiguracionIGTF();
        List<Models.Moneda>
            CargarMonedas();
        bool
            CargarConfiguracionBonoPorPagoDivisa();
    }
}