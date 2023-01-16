using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosOnLine.Src.MovCaja.View
{
    public interface IViewMov: IGestion, Helpers.IAbandonar
    {
        List<detalle> GetListaMedios_Source { get; }
        DateTime GetFechaEmision { get; }
        string GetConcepto { get; }
        string GetDetalles { get; }
        decimal GetFactorCambio { get; }
        decimal GetMontoMov { get; }
        decimal GetMontoDivisaMov { get; }
        string GetTipoMovDesc { get; }
        string GetTipoMov { get; }
        void setMovView(int id);
    }
}