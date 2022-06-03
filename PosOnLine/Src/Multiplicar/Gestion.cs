using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Multiplicar
{
    
    public class Gestion: Pos.IMultiplicar
    {

        private int _cantidad;
        private bool _procesarOk;
        private bool _abandonarIsOk;


        public bool MultiplicarIsOk { get { return _procesarOk; } }
        public int CantidadIngresar { get { return _cantidad; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarOk; } }
        public int Cantidad { get { return _cantidad; } }


        public Gestion()
        {
            _cantidad = 0;
            _procesarOk = false;
            _abandonarIsOk = false;
        }

        public void Inicializa() 
        {
            _cantidad = 0;
            _procesarOk = false;
            _abandonarIsOk = false;
        }

        MultiplicarFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new MultiplicarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;
            return rt;
        }

        public void setCantidad(int p)
        {
            _cantidad = p;
        }

        public void Procesar()
        {
            _procesarOk = false;
            if (_cantidad > 0) 
            {
                _procesarOk = true;
            }
        }

        public void Abandonar()
        {
            _abandonarIsOk = true;
        }

    }

}