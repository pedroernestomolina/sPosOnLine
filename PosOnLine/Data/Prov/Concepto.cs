using PosOnLine.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Prov
{
    
    public partial class DataPrv: IData
    {

        public OOB.Resultado.FichaEntidad<OOB.Concepto.Entidad.Ficha> Concepto_GetFichaById(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Concepto.Entidad.Ficha>();

            var r01 = MyData.Concepto_GetFichaById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            var nr = new OOB.Concepto.Entidad.Ficha()
            {
                id = ent.id,
                codigo = ent.codigo,
                nombre = ent.nombre,
            };
            result.Entidad = nr;

            return result;
        }

        public OOB.Resultado.Lista<OOB.Concepto.Entidad.Ficha> Concepto_GetLista()
        {
            var result = new OOB.Resultado.Lista <OOB.Concepto.Entidad.Ficha>();

            var filtroDTO = new DtoLibPos.Concepto.Lista.Filtro();
            var r01 = MyData.Concepto_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst = new List<OOB.Concepto.Entidad.Ficha>();
            if (r01.Lista != null) 
            {
                if (r01.Lista.Count > 0) 
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Concepto.Entidad.Ficha()
                        {
                            id = s.id,
                            codigo = s.codigo,
                            nombre = s.nombre,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }

    }

}