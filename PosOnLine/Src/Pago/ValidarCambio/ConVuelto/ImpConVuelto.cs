using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pago.ValidarCambio.ConVuelto
{

    public class ImpConVuelto : IConVuelto
    {


        private PagoMovil.IPagoMovil _gPagoMovil;
        private OOB.Cliente.Entidad.Ficha _entCliente;


        public ImpConVuelto()
        {
            _abandonarIsOk=false;
            _montoValidar = 0.0m;
            _cntDivisaEnt = 0;
            _montoEfectivoEnt = 0m;
            _montoPagoMovilEnt = 0m;
            _entCliente = null;
            _gPagoMovil = new PagoMovil.PagoMovil();
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _montoValidar = 0.0m;
            _cntDivisaEnt = 0;
            _montoEfectivoEnt = 0m;
            _montoPagoMovilEnt = 0m;
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


        private bool _validarIsOk { get { return (GetTotal == 0m); } }
        public bool ValidarCambioIsOk { get { return _validarIsOk; } }


        private decimal _montoValidar;
        public decimal GetMontoValidar { get { return _montoValidar; } }
        public void setMontoValidar(decimal monto)
        {
            _montoValidar = monto;
        }

        public void Salir()
        {
            _abandonarIsOk = true;
        }


        public void setDatosCliente(OOB.Cliente.Entidad.Ficha ficha)
        {
            _entCliente = ficha;
        }


        private bool _abandonarIsOk;
        public bool AbandonarIsOK { get { return _abandonarIsOk; } } 
        public void AbandonarFicha()
        {
            _procesarIsOk = false;
            _abandonarIsOk = true;
            _cntDivisaEnt = 0;
            _montoEfectivoEnt = 0m;
            _montoPagoMovilEnt = 0m;
        }


        private bool _procesarIsOk;
        public bool ProcesarIsOK { get { return _procesarIsOk; } }
        public void Procesar()
        {
            _procesarIsOk = false;
            if (_validarIsOk)
            {
                _procesarIsOk = Helpers.Msg.Procesar();
            }
        }


        private bool CargarData()
        {
            recalcular();
            return true;
        }


        private decimal _montoEfectivoEnt;
        public decimal GetMontoEfectivoEnt { get { return _montoEfectivoEnt; } }
        public void setMontoEfectivo(decimal monto)
        {
            _montoEfectivoEnt = monto;
        }
        public void PagoPorEfectivo(decimal monto)
        {
            setMontoEfectivo(monto);
            recalcular();
        }


        private int _cntDivisaEnt;
        public decimal GetMontoDivisa
        {
            get
            {
                var rt = (_cntDivisaEnt * _tasaCambio);
                rt += (rt * (_porctBonoPorPagoDivisa / 100));
                return rt;
            }
        }
        public int GetCntDivisaEnt { get { return _cntDivisaEnt; } }
        public void PagoPorDivisa(int cnt)
        {
            setCntDivisa(cnt);
            recalcular();
        }
        public void setCntDivisa(int cnt)
        {
            _cntDivisaEnt = cnt;
        }


        public bool PagoMovilIsOk { get { return _gPagoMovil.IsOk; } }
        public Src.PagoMovil.data PagoMovilData { get { return _gPagoMovil.DataRetornar(); } }
        public void PagoPorPagoMovil(decimal monto)
        {
            _gPagoMovil.Inicializa();
            setMontoPagoMovil(0m);
            recalcular();

            if (monto > 0m)
            {
                _gPagoMovil.Inicializa();
                _gPagoMovil.setNombre(_entCliente.Nombre);
                _gPagoMovil.setCiRif(_entCliente.CiRif);
                _gPagoMovil.setTelefono(_entCliente.Telefono);
                _gPagoMovil.setMontoPagoMovil(monto);
                _gPagoMovil.Inicia();
                if (_gPagoMovil.IsOk)
                {
                    setMontoPagoMovil(monto);
                    recalcular();
                }
            }
        }


        private decimal _montoPagoMovilEnt;
        public decimal GetMontoPagoMovilEnt { get { return _montoPagoMovilEnt; } }
        public void setMontoPagoMovil(decimal monto)
        {
            _montoPagoMovilEnt = monto;
        }

        private decimal _tasaCambio;
        public void setTasaCambio(decimal tasaCambio)
        {
            _tasaCambio = tasaCambio;
        }

        private decimal _porctBonoPorPagoDivisa;
        public void setPorctBonoPorPagoDivisa(decimal porctBonoPorPagoDivisa)
        {
            _porctBonoPorPagoDivisa = porctBonoPorPagoDivisa; 
        }


        public decimal GetTotal { get { return recalcular(); } }
        private decimal recalcular()
        {
            return Math.Round(_montoValidar - (GetMontoEfectivoEnt + GetMontoDivisa + GetMontoPagoMovilEnt), 2, MidpointRounding.AwayFromZero);
        }


        public string GetVueltoDesc { get { return GetTotal > 0m ? "FALTA" : GetTotal == 0m ? "" : "SOBRA"; } }
        public decimal GetVueltoMonto { get { return Math.Abs(GetTotal); } }


        public decimal GetMontoPorEfectivo { get { return GetMontoEfectivoEnt; } }
        public decimal GetMontoPorDivisa { get { return GetMontoDivisa; } }
        public decimal GetMontoPorPagoMovil { get { return GetMontoPagoMovilEnt; } }
        public int GetCantDivisa { get { return GetCntDivisaEnt; } }

    }

}