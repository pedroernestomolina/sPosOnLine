using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pago.ValidarCambio.SinVuelto
{

    public class ImpSinVuelto : ISinVuelto
    {


        private decimal _montoValidar;
        private decimal _montoCapturado;
        private bool _abandonarIsOk;
        private PagoMovil.IPagoMovil _gPagoMovil;
        private OOB.Cliente.Entidad.Ficha _entCliente;
        private bool ValidarIsOk 
        { 
            get 
            {
                var _monto = _montoValidar - _montoCapturado;
                return (_monto == 0.0m || 
                            (PagoMovilIsOk && (_monto == 0.0m))); 
            } 
        }


        public ImpSinVuelto()
        {
            _abandonarIsOk=false;
            _montoValidar = 0.0m;
            _montoCapturado = 0.0m;
            _gPagoMovil = new PagoMovil.PagoMovil();
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
            _montoValidar = 0.0m;
            _montoCapturado = 0.0m;
            _entCliente = null;
            _gPagoMovil.Inicializa();
        }

        ValidarCambioFrm _frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (_frm == null)
                {
                    _frm = new ValidarCambioFrm();
                    _frm.setControlador(this);
                }
                _frm.ShowDialog();
            }
        }


        public bool ValidarCambioIsOk { get { return ValidarIsOk; } }
        public void setMontoValidar(decimal monto)
        {
            _montoValidar = monto;
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

        public bool PagoMovilIsOk { get { return false; } }
        public Src.PagoMovil.data PagoMovilData { get { return null; } }
        public void PagoMovil()
        {
        }


        public void setDatosCliente(OOB.Cliente.Entidad.Ficha entCliente)
        {
        }


        public bool AbandonarIsOK { get { return _abandonarIsOk; } } 
        public void AbandonarFicha()
        {
            _montoCapturado = 0m;
            _abandonarIsOk = true;
        }

        public bool ProcesarIsOK { get { return ValidarIsOk; } }
        public void Procesar()
        {
        }


        public void setTasaCambio(decimal tasaCambio)
        {
        }
        public void setPorctBonoPorPagoDivisa(decimal _porctBonoPorPagoDivisa)
        {
        }


        private bool CargarData()
        {
            return true;
        }


        public decimal GetMontoPorEfectivo { get { return 0m; } }
        public decimal GetMontoPorDivisa { get { return 0m; } }
        public decimal GetMontoPorPagoMovil { get { return 0m; } }
        public int GetCantDivisa { get { return 0; } }


    }

}