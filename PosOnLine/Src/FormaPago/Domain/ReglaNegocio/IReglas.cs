using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.Domain.ReglaNegocio
{
    public interface IReglas
    {
        bool ParaDarDescuento();
        bool ParaDejarlaACredito(string idCliente);
    }
}
