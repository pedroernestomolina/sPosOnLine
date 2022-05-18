using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{

    public interface IData: IUsuario, IJornada, IConfiguracion, ISucursal, ICliente,
        IProducto, IDeposito, IVenta, IPendiente, IDocumento, IConcepto, ISistema,
        IVendedor, IPermiso, IReportePos
    {

        OOB.Resultado.FichaEntidad<DateTime> FechaServidor();
        OOB.Resultado.Ficha Test();

    }

}