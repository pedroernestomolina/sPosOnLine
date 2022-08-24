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
        private decimal _valorMaximoDescuentoPermitido;


        public decimal Descuento { get { return _descuento; } }
        public bool IsOk { get { return _isOk; } }


        public Gestion()
        {
            _valorMaximoDescuentoPermitido = 0m;
            _descuento = 0.0m;
        }


        public void Inicializa()
        {
            _isOk = false;
            _descuento = 0.0m;
            _valorMaximoDescuentoPermitido = 0m;
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

            var r01 = Sistema.MyData.Configuracion_ValorMaximoPorcentajeDescuento();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _valorMaximoDescuentoPermitido = r01.Entidad;
            return rt;
        }


        public void setPorcentaje(decimal p)
        {
            _descuento = p;
        }

        public void Aceptar()
        {
            _isOk = false;
            if (_descuento >= 0m)
            {
                if (_valorMaximoDescuentoPermitido > 0m)
                {
                    _isOk = _descuento <= _valorMaximoDescuentoPermitido;
                    if (!_isOk) 
                    {
                        Helpers.Msg.Alerta("VALOR MAXIMO PERMITIDO PARA EL DESCUENTO SUPERADO");
                    }
                }
                else 
                {
                    _isOk = _descuento <= 99.99m;
                }
            }
        }

        public void setDescuento(decimal p)
        {
            _descuento = p;
        }

    }

}