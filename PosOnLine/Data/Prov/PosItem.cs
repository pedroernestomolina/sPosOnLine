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
            PosItem_ActualizarPrecioPorCambioTasa(OOB.PosItem.ActualizarPrecioPorCambioTasa.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();
            //
            try
            {
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            //
            return result;
        }
    }
}