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
            Pedido_Guardar(OOB.Pedido.Guardar.Ficha ficha)
        {
            var rt = new OOB.Resultado.Ficha();
            //
            var fichaDTO = new DtoLibPos.Pedido.Guardar.Ficha()
            {
                idOperador = ficha.idOperador,
                numeroTarj = ficha.numeroTarj,
                montoMonAct = ficha.montoMonAct,
                montoMonDiv = ficha.montoMonDiv,
                factorCambio = ficha.factorCambio,
                cntItems = ficha.cntItems,
            };
            var r01 = MyData.Pedido_Guardar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                throw new Exception(r01.Mensaje);
            //
            return rt;
        }
    }
}