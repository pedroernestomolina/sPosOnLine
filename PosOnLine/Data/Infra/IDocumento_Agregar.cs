using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    public interface IDocumento_Agregar
    {
        OOB.Resultado.FichaEntidad<OOB.Documento.Agregar.Factura.Result>
            Documento_Agregar_Factura(OOB.Documento.Agregar.Factura.Ficha ficha);
        OOB.Resultado.FichaAuto
            Documento_Agregar_NotaCredito(OOB.Documento.Agregar.NotaCredito.Ficha ficha);
        OOB.Resultado.FichaAuto
            Documento_Agregar_NotaEntrega(OOB.Documento.Agregar.NotaEntrega.Ficha ficha);
    }
}
