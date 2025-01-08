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
        public OOB.Resultado.Ficha 
            Pedido_TrasladarVenta(OOB.Pedido.TrasladarVenta.Ficha ficha)
        {
            var rt = new OOB.Resultado.Ficha();
            //
            var fichaDTO = new DtoLibPos.Pedido.TrasladarVenta.Ficha()
            {
                idTarjeta= ficha.idTarjeta,
                idOperador = ficha.idOperador,
            };
            var r01 = MyData.Pedido_TrasladarVenta(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                throw new Exception(r01.Mensaje);
            //
            return rt;
        }
    }
}