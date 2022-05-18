using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface IDocumento
    {

        OOB.Resultado.FichaAuto Documento_Agregar_Factura(OOB.Documento.Agregar.Factura.Ficha ficha);
        OOB.Resultado.FichaAuto Documento_Agregar_NotaCredito(OOB.Documento.Agregar.NotaCredito.Ficha ficha);
        OOB.Resultado.FichaAuto Documento_Agregar_NotaEntrega(OOB.Documento.Agregar.NotaEntrega.Ficha ficha);
        OOB.Resultado.Lista<OOB.Documento.Lista.Ficha> Documento_Get_Lista(OOB.Documento.Lista.Filtro filtro);
        OOB.Resultado.FichaEntidad<OOB.Documento.Entidad.Ficha> Documento_GetById(string idAuto);
        //
        OOB.Resultado.Ficha Documento_Anular_NotaEntrega(OOB.Documento.Anular.NotaEntrega.Ficha ficha);
        OOB.Resultado.Ficha Documento_Anular_NotaCredito(OOB.Documento.Anular.NotaCredito.Ficha ficha);
        OOB.Resultado.Ficha Documento_Anular_Factura(OOB.Documento.Anular.Factura.Ficha ficha);
        //
        OOB.Resultado.Lista<OOB.Documento.Entidad.FichaMetodoPago> Documento_Get_MetodosPago_ByIdRecibo(string idRecibo);

    }

}