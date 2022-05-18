using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PassWord
{
    
    public class Gestion
    {

        private string _clave;


        public string Clave { get { return _clave; } }


        public Gestion()
        {
            _clave = "";
        }


        public void Inicializa() 
        {
            _clave = "";
        }

        PassWordFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new PassWordFrm();
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

        public void setClave(string p)
        {
            _clave = p;
        }

    }

}