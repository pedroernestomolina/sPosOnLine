using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src._Domain.UseCase
{
    public interface ICargarMonedaLocal
    {
        Models.Moneda
            Invoke();
    }
}
