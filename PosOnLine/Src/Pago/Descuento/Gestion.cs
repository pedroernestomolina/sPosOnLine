using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pago.Descuento
{
    
    public class Gestion
    {

        private decimal _descuento;
        private bool _isOk;


        public decimal Descuento { get { return _descuento; } }
        public bool IsOk { get { return _isOk; } }


        public Gestion()
        {
            _descuento = 0.0m;
        }


        public void Inicializa()
        {
            _isOk = false;
            _descuento = 0.0m;
        }

        DescuentoFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new DescuentoFrm();
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


        public void setPorcentaje(decimal p)
        {
            _descuento = p;
        }

        public void Aceptar()
        {
            _isOk = (_descuento >= 0.0m && _descuento <= 99.99m);
        }

        public void setDescuento(decimal p)
        {
            _descuento = p;
        }

    }

}