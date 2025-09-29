using PosOnLine.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Prov
{
    public partial class DataPrv : IData
    {
        public OOB.Resultado.FichaEntidad<OOB.Documento.RecopilarData.Anular.Ficha> 
            Documento_RecopilarData_Anular(string idDoc)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Documento.RecopilarData.Anular.Ficha>();
            //
            try
            {
                var r01 = MyData.Documento_RecopilarData_Anular(idDoc);
                if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (r01.Entidad == null)
                {
                    throw new Exception("DATA NO CARGADA");
                }
                if (r01.Entidad.doc == null)
                {
                    throw new Exception("CUERPO DOCUMENTO NO CARGADO");
                }
                if (r01.Entidad.kardex == null)
                {
                    throw new Exception("ITEMS NO CARGADO");
                }
                var s = r01.Entidad.doc;
                result.Entidad = new OOB.Documento.RecopilarData.Anular.Ficha();
                result.Entidad.doc = new OOB.Documento.RecopilarData.Anular.Documento()
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
                //
                result.Entidad.kardex = r01.Entidad.kardex.Select(k =>
                {
                    var xr = new OOB.Documento.RecopilarData.Anular.Kardex()
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
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
    }
}
