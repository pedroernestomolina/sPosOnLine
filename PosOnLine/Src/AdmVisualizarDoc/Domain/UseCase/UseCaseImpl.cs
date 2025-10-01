using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdmVisualizarDoc.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public Models.DocVisualizar 
            DocumentoVisualizar(string idDoc)
        {
            try
            {
                var rst = Sistema.MyData.Documento_GetById(idDoc);
                if (rst.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst.Mensaje);
                }
                var doc = new Models.DocVisualizar()
                {
                    encabezado = new Models.Encabezado()
                    {
                        clienteCiRif = rst.Entidad.cuerpo.CiRif,
                        clienteNombre = rst.Entidad.cuerpo.RazonSocial,
                        clienteCodigo = rst.Entidad.cuerpo.CodigoCliente,
                        clienteDirFiscal = rst.Entidad.cuerpo.DirFiscal,
                        documentoFechaEmision = rst.Entidad.cuerpo.Fecha,
                        documentoImporteMonReferencia = rst.Entidad.cuerpo.MontoDivisa,
                        documentoImporteMonLocal = rst.Entidad.cuerpo.Total,
                        documentoNro = rst.Entidad.cuerpo.DocumentoNro,
                        documentoNombre = rst.Entidad.cuerpo.DocumentoNombre,
                        documentoIsAnulado = rst.Entidad.cuerpo.EstatusAnulado.Trim().ToUpper() == "1",
                        documentoIsCredito = rst.Entidad.cuerpo.IsDocumentoCredito,
                    },
                    cuerpo = rst.Entidad.items.Select(s =>
                    {
                        return new Models.Cuerpo()
                        {
                            codigoPrd = s.Codigo,
                            importeMonLocal= s.Total,
                            nombrePrd = s.Nombre,
                            precioMonLocal= s.PrecioItem,
                            cant = s.Cantidad,
                            empqCont = s.ContenidoEmpaque,
                            empqNombre = s.Empaque,
                            isPesado = s.EstatusPesado.Trim().ToUpper() == "1",
                        };
                    }).ToList(),
                };
                return doc;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}