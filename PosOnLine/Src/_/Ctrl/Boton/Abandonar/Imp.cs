using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.__.Ctrl.Boton.Abandonar
{
    public class Imp: baseImp, IAbandonar
    {
        public Imp()
            :base()
        {
        }
        public override void Opcion(string msg = "")
        {
            _opcion = Helpers.Msg.Abandonar();
        }
    }
}
