using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PosImprimirTicket.Domain.UseCase
{
    public interface IUseCase
    {
        Models.Data
            CargarDataDocumento(string idDoc, string estatus="");
    }
}