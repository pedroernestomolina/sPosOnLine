using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    public interface IVentaZufu
    {
        OOB.Resultado.FichaEntidad<OOB.Venta.Item.Zufu.ActualizarPrecio.ObtenerData.Ficha>
            Venta_Item_Zufu_ActualizarPrecio_ObetnerData(string idPrd);
        OOB.Resultado.Ficha 
            Venta_Item_Zufu_ActualizarPrecio_Actualizar(OOB.Venta.Item.Zufu.ActualizarPrecio.Actualizar.Ficha ficha);
    }
}