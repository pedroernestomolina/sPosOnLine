using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.CambioPrecioPrdComp.CambioPrecio.Vista
{
    public interface IPrecio
    {
        __.Precio.IPrecio Get_PrecioVta { get; }
        void Inicializa();
        void setPosTipoMoneda(__.Precio.Moneda.TipoMoneda tipoMoneda);
        void setPosPrecioNeto(decimal precio);
        void setPosCostoActual(decimal costo);
        void setPosTasaCambio(decimal tasa);
        void setPosTasaIva(decimal tasa);
        void setPosBonoPorPagoEnDivisa(decimal tasaBono);
        void setModoBonoIncluido(bool modo);
        decimal PrecioSinBono(decimal precio);
        void Refresh();
    }
}