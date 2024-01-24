using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.__.Ctrl.Boton
{
    public abstract class baseImp: IBoton
    {
        protected bool _opcion;

        public bool OpcionIsOK { get { return _opcion; } }
        public baseImp()
        {
            _opcion = false;
        }
        public void Inicializa()
        {
            _opcion = false;
        }
        public abstract void Opcion();
    }
}
