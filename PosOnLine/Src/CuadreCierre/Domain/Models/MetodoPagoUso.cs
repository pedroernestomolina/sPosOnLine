using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.Domain.Models
{
    public class MetodoPagoUso
    {
        private decimal _montoPorVuelto;
        private int _cantDivisaDevuelta;
        private decimal _montoDivisaDevuelta;
        private decimal _tasaPonderada;
        private decimal _importe;
        private decimal _segunSistema; 
        //
        public string idMP { get; set; }
        public string codigoMP { get; set; }
        public string descripcionMP { get; set; }
        public string simboloMon { get; set; }
        public string codigoMon { get; set; }
        public decimal totalMontoRecibido { get; set; }
        public decimal totalMontoRecibidoMonLocal { get; set; }
        public decimal tasaFactorPonderado { get; set; }
        public decimal importe { get { return _importe; } }
        public decimal MontoSegunSistema { get { return _segunSistema; } }
        //
        public string CabDescripcion { get { return descripcionMP.Trim() + " " + simboloMon.Trim(); } }
        public string CabMontoSist { get { return (totalMontoRecibido - _montoPorVuelto- _cantDivisaDevuelta).ToString("n2"); } }
        public string CabFactor
        {
            get
            {
                actualizarTasaPonderadaImporte();
                return _tasaPonderada.ToString("n4");
            }
        }
        public string CabImporte 
        { 
            get 
            {
                actualizarTasaPonderadaImporte();
                return _importe.ToString("n2"); 
            } 
        }
        public decimal MontoSegunUsu { get; set; }
        //
        public void setVueltoPorMontoDado(decimal monto)
        {
            _montoPorVuelto = monto;
            _segunSistema = totalMontoRecibido-monto;
            actualizarTasaPonderadaImporte();
        }
        public  void setCantDivisaDevuelta(int cntDivisa)
        {
            _cantDivisaDevuelta = cntDivisa;
            _segunSistema = totalMontoRecibido - cntDivisa;
            actualizarTasaPonderadaImporte();
        }
        public void setMontoDivisaDevuelta(decimal monto)
        {
            _montoDivisaDevuelta = monto;
            actualizarTasaPonderadaImporte();
        }
        public void setActivarMontoPorBonoPagoDivisa()
        {
            _segunSistema=totalMontoRecibido;
            MontoSegunUsu = totalMontoRecibido;
            _importe = totalMontoRecibidoMonLocal;
        }
        private void actualizarTasaPonderadaImporte() 
        {
            decimal _cnt = (totalMontoRecibido -_cantDivisaDevuelta );
            decimal _monto = (totalMontoRecibidoMonLocal - _montoDivisaDevuelta);
            _tasaPonderada = 0m;
            if (_cnt>0m)
            {
                _tasaPonderada = _monto / _cnt;
                _tasaPonderada = Math.Round(_tasaPonderada, 4, MidpointRounding.AwayFromZero);
            }
            _importe = MontoSegunUsu * _tasaPonderada;
            _importe = Math.Round(_importe, 2, MidpointRounding.AwayFromZero);
        }
        public void Recalcular()
        {
            _importe = MontoSegunUsu * _tasaPonderada;
            _importe = Math.Round(_importe, 2, MidpointRounding.AwayFromZero);
        }
    }
}