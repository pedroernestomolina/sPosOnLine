using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Lib.Controles.BalanzaSoloPeso.BalanzaManual
{
    
    public class Balanza: IBalanza
    {

        public Resultado LeerPeso()
        {
            var rt = new Resultado();

            var frm = new BalanzaFrm();
            frm.ShowDialog();
            rt.Peso=frm.Peso;

            return rt;
        }

    }

}
