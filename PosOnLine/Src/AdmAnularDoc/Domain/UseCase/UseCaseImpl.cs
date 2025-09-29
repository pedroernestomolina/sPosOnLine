using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdmAnularDoc.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public Models.DataAnular 
            RecopilarDataDocumentoAnular(string idDoc)
        {
            var rt = new Models.DataAnular();
            //
            try
            {
                var rst = Sistema.MyData.Documento_RecopilarData_Anular(idDoc);
                if (rst.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(rst.Mensaje);
                }
                var s= rst.Entidad.doc;
                rt.doc = new Models.Documento()
                {
                    codigoDoc = s.codigoDoc,
                    estatusAnulado = s.estatusAnulado.Trim().ToUpper() == "1",
                    estatusCredito = s.estatusCredito.Trim().ToUpper() == "1",
                    estatusDocFiscal = s.estatusDocFiscal.Trim().ToUpper() == "1",
                    idCliente = s.idCliente,
                    idDoc = s.idDoc,
                    idDocCxc = s.idDocCxc,
                    idReciboCxc = s.idReciboCxc,
                    montoPendCxc = s.montoPendCxc,

                };
                rt.kardex = rst.Entidad.kardex.Select(k =>
                {
                    var xr = new Models.Kardex()
                    {
                        cntUndMov = k.cntUndMov,
                        idDeposito = k.idDeposito,
                        idProducto = k.idProducto,
                        signoMov = k.signoMov,
                    };
                    return xr;
                }).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rt;
        }
    }
}