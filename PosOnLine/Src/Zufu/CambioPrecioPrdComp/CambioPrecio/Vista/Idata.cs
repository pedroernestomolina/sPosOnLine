using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.CambioPrecioPrdComp.CambioPrecio.Vista
{
    public interface Idata
    {
        object Item_GetIdPrd { get; }
        decimal Item_GetPrecioActual { get; }
        decimal Item_GetCostoActualEmpVta { get; }
        bool Get_AplicaBono { get; }
        decimal PrecioNuevoNetoMonAct { get; }
        decimal PrecioNuevoFullMonDiv { get; }
        decimal Utilidad_Precio_Actual { get; }
        decimal UtilidadNueva { get; }
        Vista.IPrecio PrecioNuevo { get; }
        //
        void setItem(Object item);
        void setPrd(object prd);
        void setPrecioCambiar(decimal precio);
        void setAplicandoBono(bool modo);
        void setTasaPos(decimal tasa);
        void setTasaBonoAplicar(decimal tasa);
        bool VerificarData();
        void Inicializa();
        void Refresh();
    }
}