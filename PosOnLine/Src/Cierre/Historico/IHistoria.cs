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

        BindingSource  GetDataSource { get; }


        void ImprimirCierre();


        bool ImprimirIsOk { get; }
        void Imprimir(System.Drawing.Printing.PrintPageEventArgs e);

    }

}