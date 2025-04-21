using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Cierre.Historico
{
    public interface IHistoria: IGestion
    {
        object GetDataSource { get; }
        object ItemActual { get; }
        //
        void ImprimirCierre();
        void VentCredito();
        void PagoDetalles();
        void PagoResumen();
    }
}