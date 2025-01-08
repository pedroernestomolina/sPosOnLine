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
        public OOB.Resultado.FichaEntidad<OOB.Pedido.ListaResumen.Entidad> 
            Pedido_GetListaResumen(OOB.Pedido.ListaResumen.Filtros filtros)
        {
            var _lst = new List<OOB.Pedido.ListaResumen.Resumen>();
            var rt = new OOB.Resultado.FichaEntidad<OOB.Pedido.ListaResumen.Entidad>();
            rt.Entidad = new OOB.Pedido.ListaResumen.Entidad();
            //
            var filtrosDTO = new DtoLibPos.Pedido.Lista.Filtro()
            {
            };
            var r01 = MyData.Pedido_GetListaResumenBy_Filtro(filtrosDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                throw new Exception(r01.Mensaje);
            if (r01.Entidad != null) 
            {
                if (r01.Entidad.Lista.Count > 0) 
                {
                    _lst = r01.Entidad.Lista.Select(s =>
                    {
                        var nr = new OOB.Pedido.ListaResumen.Resumen()
                        {
                            cntItems = s.cntItems,
                            estatus = s.estatus,
                            factorCambio = s.factorCambio,
                            fechaHora = s.fechaHora,
                            Id = s.Id,
                            montoMonAct = s.montoMonAct,
                            montoMonDiv = s.montoMonDiv,
                            tarjetaNum = s.tarjetaNum,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Entidad.Pedidos = _lst;
            //
            return rt;
        }
    }
}
