using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pos.Domain.UseCase
{
    public interface IUseCase
    {
        Models.ResultadoAgregarDoc
            AgregarFactura(OOB.Documento.Agregar.Factura.Ficha doc);
        Helpers.Imprimir.data 
            CargarDataDocumento(Models.ResultadoAgregarDoc result);
    }
}