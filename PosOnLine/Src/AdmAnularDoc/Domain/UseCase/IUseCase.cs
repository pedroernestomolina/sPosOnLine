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
    }
}