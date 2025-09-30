using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdmAnularDoc.Domain.UseCase
{
    public interface IUseCase
    {
        Domain.Models.DataAnular
            RecopilarDataDocumentoAnular(string idDoc);
        void 
            AnularFactura(Models.DataAnular dataAnular, string motivo);
        void 
            AnularNotaCredito(Models.DataAnular dataAnular, string motivo);
        void 
            AnularNotaEntrega(Models.DataAnular dataAnular, string motivo);
    }
}