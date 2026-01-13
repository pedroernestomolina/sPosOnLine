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
        Models.ResultadoAgregarDoc
            AgregarNotaCredito(OOB.Documento.Agregar.NotaCredito.Ficha doc);
        decimal TasaActualSistema();
    }
}