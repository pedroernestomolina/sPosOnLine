using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.__.Ctrl.Boton.Procesar
{
    public class Imp: baseImp, IProcesar
    {
        public Imp()
            :base()
        {
        }
        public void setOpcion(bool p)
        {
            _opcion = p;
        }
        public override void Opcion(string msg = "Procesar / Guardar Cambios ?:")
        {
            _opcion = Helpers.Msg.Procesar(msg);
        }
    }
}