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

        public OOB.Resultado.Lista<OOB.Reportes.DocVerificados.Ficha> 
            Reportes_DocVerificados(OOB.Reportes.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Reportes.DocVerificados.Ficha>();

            var filtroDTO = new DtoLibPos.Reportes.PosVerificador.Filtro()
            {
                desde = filtro.desde,
                hasta = filtro.hasta,
            };
            var r01 = MyData.ReportePosVerificados_DocVerificados(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.Reportes.DocVerificados.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list= r01.Lista.Select(s=>
                    {
                        var nr = new OOB.Reportes.DocVerificados.Ficha()
                        {
                            autoDocumento = s.autoDocumento,
                            codUsuVer = s.codUsuVer,
                            docCiRif = s.docCiRif,
                            docEstatusAnu = s.docEstatusAnu,
                            docFecha = s.docFecha,
                            docMonto = s.docMonto,
                            docMontoDivisa = s.docMontoDivisa,
                            docNro = s.docNro,
                            docRazonSocial = s.docRazonSocial,
                            docTipo = s.docTipo,
                            estatusVer = s.estatusVer,
                            fechaVer = s.fechaVer,
                            nombUsuVer = s.nombUsuVer,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.ListaD = list;

            return rt;
        }

    }

}