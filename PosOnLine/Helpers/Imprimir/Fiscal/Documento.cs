using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Helpers.Imprimir.Fiscal
{
    
    public class Documento: IDocumento
    {

        public void ImprimirDoc()
        {
            MessageBox.Show("EN FISCAL ORIGINA");
        }


        public void ImprimirCopiaDoc()
        {
            MessageBox.Show("EN FISCAL COPIA");
        }

        public void setData(data ds)
        {
        }

    }

}
