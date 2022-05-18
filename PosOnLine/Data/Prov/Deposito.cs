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

        public OOB.Resultado.Lista<OOB.Deposito.Entidad.Ficha> Deposito_GetLista(OOB.Deposito.Lista.Filtro filtro)
        {
            var result = new OOB.Resultado.Lista<OOB.Deposito.Entidad.Ficha>();

            var filtroDTO = new DtoLibPos.Deposito.Lista.Filtro() { PorCodigoSuc = filtro.PorCodigoSuc };
            var r01 = MyData.Deposito_GetLista (filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst = new List<OOB.Deposito.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Deposito.Entidad.Ficha()
                        {
                            id = s.id,
                            codigo = s.codigo,
                            nombre = s.nombre,
                            codSuc = s.codigoSuc,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Deposito.Entidad.Ficha> Deposito_GetFichaById(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Deposito.Entidad.Ficha>();

            var r01 = MyData.Deposito_GetFichaById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            var nr = new OOB.Deposito.Entidad.Ficha()
            {
                id = ent.id,
                codigo = ent.codigo,
                nombre = ent.nombre,
                codSuc = ent.codSuc,
            };
            result.Entidad = nr;

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Deposito.Entidad.Ficha> Deposito_GetFicha_ByCodigo(string codigo)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Deposito.Entidad.Ficha>();

            var r01 = MyData.Deposito_GetFicha_ByCodigo(codigo);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            var nr = new OOB.Deposito.Entidad.Ficha()
            {
                id = ent.id,
                codigo = ent.codigo,
                nombre = ent.nombre,
                codSuc = ent.codSuc,
            };
            result.Entidad = nr;

            return result;
        }

    }

}