using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.__.Ctrl.Boton.Salir
{
    public class Imp: baseImp, ISalir
    {
        public Imp()
            :base()
        {
        }
        public override void Opcion()
        {
            _opcion = true;
        }
    }
}
