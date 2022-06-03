using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.ValidarCambio
{

    public class Gestion
    {


        private decimal _montoValidar;
        private decimal _montoCapturado;
        private bool _abandonarIsOk;
        private PagoMovil.IPagoMovil _gPagoMovil;
        private OOB.Cliente.Entidad.Ficha _entCliente;
        private PagoMovil.data _dataPagoMovil;


        public bool ValidarIsOk { get { return ((_montoValidar - _montoCapturado) == 0.0m || PagoMovilIsOk); } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public bool PagoMovilIsOk { get { return _gPagoMovil.IsOk; } }


        public Gestion() 
        {
            _dataPagoMovil = null;
            _gPagoMovil = new PagoMovil.PagoMovil();
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
            _montoValidar = 0.0m;
            _montoCapturado = 0.0m;
            _entCliente = null;
            _dataPagoMovil = null;
            _gPagoMovil.Inicializa();
        }

        public void setMontoValidar(decimal monto)
        {
            _montoValidar = monto;
        }

        ValidarCambioFrm _frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (_frm==null)
                {
                    _frm=new ValidarCambioFrm();
                    _frm.setControlador(this);
                }
                _frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void setMontoCapturado(decimal monto)
        {
            _montoCapturado = monto;
        }

        public void Salir()
        {
            _montoCapturado = 0.0m;
            _abandonarIsOk = true;
        }

        public void PagoMovil()
        {
            _dataPagoMovil = null;
            _gPagoMovil.Inicializa();
            _gPagoMovil.setDatosPagoMovil(_entCliente, _montoValidar);
            _gPagoMovil.Inicia();
            if (_gPagoMovil.IsOk) 
            {
                _dataPagoMovil = _gPagoMovil.Data();
            }
        }

        public void setDatosPagoMovil(OOB.Cliente.Entidad.Ficha ent)
        {
            _entCliente = ent;
        }
        public Src.PagoMovil.data PagoMovilData { get { return _dataPagoMovil; } }

    }

}