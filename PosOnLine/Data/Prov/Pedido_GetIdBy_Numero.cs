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
        public OOB.Resultado.FichaEntidad<int> 
            Pedido_GetIdBy_Numero(int numero)
        {
            var rt = new OOB.Resultado.FichaEntidad<int>();
            //
            var r01 = MyData.Pedido_GetIdBy_Numero(numero);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                throw new Exception(r01.Mensaje);
            rt.Entidad=r01.Entidad;
            //
            return rt;
        }
    }
}