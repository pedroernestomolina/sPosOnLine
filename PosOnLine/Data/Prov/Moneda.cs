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
        public OOB.Resultado.Lista<OOB.Moneda.Entidad.Ficha>
            Moneda_GetLista()
        {
            var result = new OOB.Resultado.Lista<OOB.Moneda.Entidad.Ficha>();
            //
            try
            {
                var filtroDTO = new DtoLibPos.Moneda.Filtro();
                var rt = MyData.Moneda_GetLista(filtroDTO);
                if (rt.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt.Mensaje);
                }
                if (rt.Lista == null) 
                {
                    throw new Exception("DATA [ MONEDA ] NO CARAGADA");
                }
                if (rt.Lista.Count == 0) 
                {
                    throw new Exception("LISTA [ MONEDA ] VACIA");
                }
                var lst = new List<OOB.Moneda.Entidad.Ficha>();
                lst = rt.Lista.Select(s =>
                {
                    var nr = new OOB.Moneda.Entidad.Ficha()
                    {
                        codigo = s.codigo,
                        id = s.id,
                        nombre = s.nombre,
                        simbolo = s.simbolo,
                        tasaRespectoMonReferencia = s.tasaRespectoMonReferencia,
                    };
                    return nr;
                }).ToList();
                result.ListaD = lst;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
        public OOB.Resultado.FichaEntidad<OOB.Moneda.Entidad.Ficha>
            Moneda_GetFichaById(int id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Moneda.Entidad.Ficha>();
            //
            try
            {
                var rt = MyData.Moneda_GetFichaById(id);
                if (rt.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt.Mensaje);
                }
                if (rt.Entidad == null)
                {
                    throw new Exception("DATA [ MONEDA ] NO CARAGADA");
                }
                var s = rt.Entidad;
                var ent = new OOB.Moneda.Entidad.Ficha()
                {
                    codigo = s.codigo,
                    id = s.id,
                    nombre = s.nombre,
                    simbolo = s.simbolo,
                    tasaRespectoMonReferencia = s.tasaRespectoMonReferencia,
                };
                result.Entidad = ent;
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
