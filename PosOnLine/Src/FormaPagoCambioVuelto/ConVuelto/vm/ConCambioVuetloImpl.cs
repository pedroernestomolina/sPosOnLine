using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPagoCambioVuelto.ConVuelto.vm
{
    public class ConCambioVuetloImpl: IConCambioVuelto
    {
        private decimal _montoValidar;
        private decimal _factorCambio;
        private decimal _montoPorPagoMovilIngresado;
        private int _cntPorDivisaIngresada;
        private decimal _montoPorEfectivoIngresado;
        private decimal _montoPorDivisa;
        private __.Ctrl.Boton.Salir.ISalir _abandonar;
        private decimal _saldo;
        private string _faltaSobraOk;
        private bool _validacionIsOk;
        //
        public decimal Get_MontoValidar { get { return _montoValidar; } }
        public decimal Get_MontoPorEfectivo { get { return _montoPorEfectivoIngresado; } }
        public int Get_CntPorDivisa { get { return _cntPorDivisaIngresada; } }
        public decimal Get_MontoPorDivisa { get { return _montoPorDivisa; } }
        public decimal Get_MontoPorPagoMovil { get { return _montoPorPagoMovilIngresado; } }
        public decimal Get_SaldoTotal { get { return _saldo; } }
        public string Get_EstadoFaltaSobraOk { get { return _faltaSobraOk; } }
        public Domain.Models.DataRetornar Get_DataRetornar { get { return dataRetornar(); } }
        public bool abandonarIsOK { get { return _abandonar.OpcionIsOK; } }
        public bool validacionIsOk { get { return _validacionIsOk; } }
        //
        public ConCambioVuetloImpl()
        {
            _validacionIsOk = false;
            _abandonar = new __.Ctrl.Boton.Salir.Imp();
            _montoPorEfectivoIngresado = 0m;
            _montoPorPagoMovilIngresado = 0m;
            _montoPorDivisa = 0m;
            _cntPorDivisaIngresada = 0;
            _faltaSobraOk="";
        }
        //
        public void Inicializa()
        {
            _validacionIsOk = false;
            setMontoPorEfectivo(0m);
            setCntPorDivisa(0);
            setMontoPorPagoMovil(0m);
            _abandonar.Inicializa();
        }
        vista.Frm frm;
        public void Inicia()
        {
            if (cargarData()) 
            {
                recalcular();
                if (frm == null)
                {
                    frm = new vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        //
        public void setMontoValidar(decimal monto)
        {
            _montoValidar = monto;
        }
        public void setTasaCambio(decimal factor)
        {
            _factorCambio = factor;
        }
        public void setMontoPorEfectivo(decimal monto)
        {
            _montoPorEfectivoIngresado = monto;
            recalcular();
        }
        public void setCntPorDivisa(int cnt)
        {
            _cntPorDivisaIngresada = cnt;
            recalcular();
        }
        public void setMontoPorPagoMovil(decimal monto)
        {
            _montoPorPagoMovilIngresado = monto;
            recalcular();
        }
        public void abandonarFicha()
        {
            _abandonar.Opcion();
        }
        public void procesarFicha()
        {
            if (_saldo != 0m) return;
            _validacionIsOk = true;
        }
        //
        private void recalcular()
        {
            _faltaSobraOk = "";
            _montoPorDivisa = _cntPorDivisaIngresada * _factorCambio;
            _montoPorDivisa = Math.Round(_montoPorDivisa, 2, MidpointRounding.AwayFromZero);
            var _montoIngresos = (_montoPorEfectivoIngresado + _montoPorDivisa + _montoPorPagoMovilIngresado);
            _montoIngresos = Math.Round(_montoIngresos, 2, MidpointRounding.AwayFromZero);
            //
            _saldo = _montoIngresos - _montoValidar;
            _saldo = Math.Round(_saldo, 2, MidpointRounding.AwayFromZero);
            //
            if (_saldo>0m) 
            {
                _faltaSobraOk = "Sobra";
            }
            else if (_saldo < 0m)
            {
                _faltaSobraOk = "Falta";
            }
            else 
            {
                _faltaSobraOk = "";
            }
        }
        private bool cargarData() 
        {
            return true;
        }
        private Domain.Models.DataRetornar dataRetornar()
        {
            var rt = new Domain.Models.DataRetornar()
            {
                MontoPorPagoMovil = _montoPorPagoMovilIngresado,
                CantDivisaPorVueltoEnDivisa = _cntPorDivisaIngresada,
                MontoPorVueltoEnDivisa = _montoPorDivisa,
                MontoPorVueltoEnEfectivo = _montoPorEfectivoIngresado,
            };
            return rt;
        }
    }
}