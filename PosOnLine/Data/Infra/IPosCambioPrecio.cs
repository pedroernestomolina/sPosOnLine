using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    public interface IPosCambioPrecio
    {
        OOB.Resultado.FichaEntidad<OOB.PosCambioPrecio.ObtenerDataItem.Ficha>
            PosCambioPrecio_ObtenerDataItem(int idItem);
    }
}