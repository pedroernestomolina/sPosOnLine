using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PosItemCambiarPrecio.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public Models.ItemCambio 
            CargarItemCambio(int idItem)
        {
            try
            {
                var rst = Sistema.MyData.Venta_Item_Zufu_ActualizarPrecio_ObetnerData("");
                var rt = new Models.ItemCambio() 
                {
                };
                return rt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}