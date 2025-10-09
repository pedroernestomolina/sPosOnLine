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
                var fichaDTO = new DtoLibPos.PosItem.ActualizarPrecioPorCambioTasa.Ficha()
                {
                    items = ficha.items.Select(s =>
                    {
                        return new DtoLibPos.PosItem.ActualizarPrecioPorCambioTasa.Item()
                        {
                            idItem = s.idItem,
                            precioNeto = s.precioNeto,
                        };
                    }).ToList(),
                };
                var rst = MyData.PosItem_ActualizarPrecioPorCambioTasa(fichaDTO);
                if (rst.Result ==  DtoLib.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(rst.Mensaje);
                }
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