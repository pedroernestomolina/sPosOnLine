using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdmVisualizarDoc.Domain.UseCase
{
    public interface IUseCase
    {
        Models.DocVisualizar
            DocumentoVisualizar(string idDoc);
    }
}
