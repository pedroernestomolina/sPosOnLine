using PosVerificador.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Data.Prov
{
    
    public partial class DataPrv : IData
    {

        public OOB.Resultado.FichaEntidad<OOB.Documento.Entidad.Ficha> 
            Documento_GetFichaById(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Documento.Entidad.Ficha>();
            try
            {
                var r01 = MyData.Documento_GetById(id);
                if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (r01.Entidad == null) 
                {
                    throw new Exception("DATA NO CARGADA");
                }
                if (r01.Entidad.cuerpo == null) 
                {
                    throw new Exception("CUERPO DOCUMENTO NO CARGADO");
                }
                var s = r01.Entidad.cuerpo;
                var nr = new OOB.Documento.Entidad.Ficha()
                {
                    AutoCierreDoc = s.Cierre,
                    AutoDoc = s.Auto,
                    CodigoDoc = s.Tipo,
                    EstatusAnuladoDoc = s.EstatusAnulado,
                    FechaDoc = s.Fecha,
                    HoraDoc = s.Hora,
                    MontoDoc = s.Total,
                    NroDoc = s.DocumentoNro,
                    CiRif = s.CiRif,
                    DirFiscal = s.DirFiscal,
                    RazonSocial = s.RazonSocial,
                    estacionEquipo = s.Estacion,
                    Items = r01.Entidad.items.Select(ss =>
                    {
                        var it = new OOB.Documento.Entidad.FichaItem()
                        {
                            cnt = ss.Cantidad,
                            empaque = ss.Empaque,
                            empCont = ss.ContenidoEmpaque,
                            prdCod = ss.Codigo,
                            prdDesc = ss.Nombre,
                        };
                        return it;
                    }).ToList(),
                };
                result.Entidad = nr;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message ;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
        public OOB.Resultado.FichaEntidad<int> 
            Documento_GetDocNCR_Relacionados_ByAutoDoc(string autoDoc)
        {
            var result = new OOB.Resultado.FichaEntidad<int>();

            var r01 = MyData.Documento_GetDocNCR_Relacionados_ByAutoDoc (autoDoc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Entidad =  r01.Entidad;

            return result;
        }
    }
}