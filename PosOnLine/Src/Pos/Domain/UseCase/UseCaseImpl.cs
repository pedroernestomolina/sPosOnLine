using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pos.Domain.UseCase
{
    public class UseCaseImpl : IUseCase
    {
        public Models.ResultadoAgregarDoc
            AgregarFactura(OOB.Documento.Agregar.Factura.Ficha doc)
        {
            var result = Sistema.MyData.Documento_Agregar_Factura(doc);
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(result.Mensaje);
            }
            if (result.Entidad == null)
            {
                throw new Exception("DATA NO CARGADA");
            }
            var s = result.Entidad;
            var rt = new Models.ResultadoAgregarDoc()
            {
                autoCierre = s.autoCierre,
                autoDoc = s.autoDoc,
                codDoc = s.codDoc,
                idVerificador = s.idVerificador,
                montoDoc = s.montoDoc,
                numDoc = s.numDoc,
            };
            return rt;
        }
        public Models.ResultadoAgregarDoc
            AgregarNotaCredito(OOB.Documento.Agregar.NotaCredito.Ficha doc)
        {
            var result = Sistema.MyData.Documento_Agregar_NotaCredito(doc);
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(result.Mensaje);
            }
            if (result.Auto == "")
            {
                throw new Exception("DATA NO CARGADA");
            }
            var rt = new Models.ResultadoAgregarDoc()
            {
                autoCierre = "",
                autoDoc = result.Auto,
                codDoc = "",
                idVerificador = -1,
                montoDoc = 0m,
                numDoc = "",
            };
            return rt;
        }
    }
}