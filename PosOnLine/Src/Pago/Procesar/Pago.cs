﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pago.Procesar
{

    public class Pago
    {

        private List<PagoDetalle> _detalle { get; set; }
        private decimal _subtotalMonto;
        private decimal _tasaCambio;
        private decimal _dsctoPorct;
        private bool _isCredito;
        private LoteReferencia.Gestion _gestionLoteRef;
        private Descuento.Gestion _gestionDescuento;
        private ValidarCambio.Gestion _gestionValidarCambio;
        private OOB.Cliente.Entidad.Ficha _entCliente;


        public List<PagoDetalle> Detalle 
        { 
            get 
            { 
                return _detalle; 
            }
        }

        public decimal MontoRecibido
        {
            get
            {
                var x = 0.0m;
                x = _detalle.Sum(s => s.Monto);
                x = Math.Round(x, 2, MidpointRounding.AwayFromZero);
                return x;
            }
        }

        public decimal MontoCambioDar_MonedaNacional
        {
            get
            {
                var x = 0.0m;
                if (!_isCredito) 
                {
                    x = MontoRecibido - MontoPagar;
                }
                return x;
            }
        }

        public decimal MontoCambioDar_Divisa
        {
            get
            {
                var x = 0.0m;
                if (!_isCredito)
                {
                    if (_tasaCambio > 0)
                    {
                        var _factor = 1 + (_porctBonoPorPagoDivisa / 100);
                        x = (MontoCambioDar_MonedaNacional / _factor) / _tasaCambio;
                    }
                }
                return x;
            }
        }

        public decimal MontoResta_MonedaNacional
        {
            get
            {
                var x = 0.0m;
                x = MontoPagar - MontoRecibido;
                x = Math.Round(x, 2, MidpointRounding.AwayFromZero);
                return x;
            }
        }

        public decimal MontoResta_Divisa
        {
            get
            {
                var x = 0.0m;
                if (_tasaCambio > 0)
                {
                    x = MontoResta_MonedaNacional / _tasaCambio;
                }
                return x;
            }
        }

        public decimal MontoDivisa
        {
            get
            {
                var x = 0.0m;
                x = _detalle.Where(w => w.Modo == Enumerados.ModoPago.Divisa).Sum(s => s.Monto);
                return x;
            }
        }

        public decimal SubTotalMontoPagar
        {
            get
            {
                return decimal.Round(_subtotalMonto,2, MidpointRounding.AwayFromZero) ;
            }
        }

        public decimal MontoPagar
        {
            get
            {
                var x = 0.0m;
                x = _subtotalMonto-Descuento;
                return x;
            }
        }

        public decimal MontoPagarDivisa
        {
            get
            {
                var x = 0.0m;
                if (_tasaCambio > 0)
                {
                    x =MontoPagar / _tasaCambio;
                }
                return x;
            }
        }

        public decimal TasaCambio
        {
            get
            {
                var x = 0.0m;
                x = _tasaCambio;
                return x;
            }
        }

        public decimal Descuento
        {
            get
            {
                var x = 0.0m;
                x = _subtotalMonto * _dsctoPorct/100;
                return decimal.Round(x,2,MidpointRounding.AwayFromZero);
            }
        }

        public decimal DescuentoPorct
        {
            get
            {
                return _dsctoPorct;
            }
        }

        public bool IsCredito
        {
            get
            {
                return _isCredito;
            }
        }

        public string PagoElectronico_LOTE(int id)
        {
            var rt = "";
            var det = _detalle.FirstOrDefault(f => f.Modo == Enumerados.ModoPago.Electronico && f.Id == id);
            if (det != null) 
            {
                rt = det.Lote;
            }
            return rt;
        }
        public string PagoElectronico_REF(int id)
        {
            var rt = "";
            var det = _detalle.FirstOrDefault(f => f.Modo == Enumerados.ModoPago.Electronico && f.Id == id);
            if (det != null)
            {
                rt = det.Referencia;
            }
            return rt;
        }


        public Pago()
        {
            _isCredito = false;
            _subtotalMonto = 0.0m;
            _tasaCambio = 0.0m;
            _dsctoPorct = 0.0m;
            _detalle = new List<PagoDetalle>();
            _gestionValidarCambio = new ValidarCambio.Gestion();
            _entCliente = null;
        }


        public void setMontoPagar(decimal monto)
        {
            _subtotalMonto = monto;
        }

        public void setTasaCambio(decimal tasa)
        {
            _tasaCambio = tasa;
        }

        public void AddEfectivo(decimal monto)
        {
            var it = _detalle.FirstOrDefault(f => f.Modo == Enumerados.ModoPago.Efectivo);
            if (it == null)
            {
                if (monto > 0m)
                {
                    it = new PagoDetalle()
                    {
                        Modo = Enumerados.ModoPago.Efectivo,
                        Tasa = 1,
                        Cantidad = 1,
                        Monto = monto,
                        Lote = "",
                        Referencia = "",
                        TarjetaNro = "",
                        Importe = MontoResta_MonedaNacional,
                        MontoRecibido = monto,
                    };
                    _detalle.Add(it);
                }
            }
            else
            {
                it.Monto = 0;
                it.Importe = MontoResta_MonedaNacional;
                it.Monto = monto;
                it.MontoRecibido = monto;
            }
        }


        private bool _activarBonoPorPagoDivisa;
        private decimal _porctBonoPorPagoDivisa;
        private int _cntDivisaRecomendada;
        public void setActivarBonoPorPagoDivisa(bool activar)
        {
            _activarBonoPorPagoDivisa = activar;
        }
        public void setPorctBonoPorPagoDivisa(decimal porct)
        {
            _porctBonoPorPagoDivisa = porct;
        }
        public int GetCntDivisaRecomendar { get { return _cntDivisaRecomendada; } }
        public void AddDivisa(decimal monto)
        {
            _cntDivisaRecomendada = 0;
            var it = _detalle.FirstOrDefault(f => f.Modo == Enumerados.ModoPago.Divisa);
            var it2 = _detalle.FirstOrDefault(f => f.Modo == Enumerados.ModoPago.Electronico && f.Id==4);
            if (it != null)
            {
                _detalle.Remove(it);
            }
            if (it2 != null)
            {
                _detalle.Remove(it2);
            }
            if (monto > 0m)
            {
                PgDivisa pg = new PgDivisa();
                pg.setHabilitarBono(_activarBonoPorPagoDivisa);
                pg.setTasaBono(_porctBonoPorPagoDivisa);
                pg.setTasaDivisa(_tasaCambio);
                pg.AgregarPago(monto, MontoPagar);
                it = new PagoDetalle()
                {
                    Modo = Enumerados.ModoPago.Divisa,
                    Tasa = _tasaCambio,
                    Cantidad = monto,
                    Monto = pg.GetMontoRecibeBs,
                    Lote = "",
                    Referencia = "",
                    TarjetaNro = "",
                    Importe = MontoResta_MonedaNacional,
                    MontoRecibido = monto,
                };
                _cntDivisaRecomendada = pg.GetCntDivisaRecomendar;
                _detalle.Add(it);
                var msg1 = "BONO";
                var msg2 = Math.Round(pg.GetMontoBonoDivisa, 2, MidpointRounding.AwayFromZero).ToString()+"$";
                AddElectronico(pg.GetMontoBonoBs, 4, msg1, msg2, false);
            }
        }

        public void AddElectronico(decimal monto, int id, string nroLote="", string nroReferencia="", bool activar=true)
        {
            var _nroLote = nroLote;
            var _nroReferencia = nroReferencia;
            var it = _detalle.FirstOrDefault(f => f.Modo == Enumerados.ModoPago.Electronico && f.Id == id);
            if (it != null)
            {
                _nroLote = it.Lote;
                _nroReferencia = it.Referencia;
                _detalle.Remove(it);
            }
            if (monto > 0m)
            {
                if (activar)
                {
                    PgPunto pg = new PgPunto();
                    pg.setNroLote(_nroLote);
                    pg.setNroReferencia(_nroReferencia);
                    pg.AgregarPago();
                    nroLote = pg.GetNroLote;
                    nroReferencia = pg.GetNroReferencia;
                }
                it = new PagoDetalle()
                {
                    Id = id,
                    Modo = Enumerados.ModoPago.Electronico,
                    Tasa = 1,
                    Cantidad = 1,
                    Monto = monto,
                    Lote = nroLote,
                    Referencia = nroReferencia,
                    TarjetaNro = "",
                    Importe = MontoResta_MonedaNacional,
                    MontoRecibido = monto,
                };
                _detalle.Add(it);
            }
        }

        public void Limpiar()
        {
            _isCredito = false;
            _dsctoPorct = 0.0m;
            _detalle.Clear();
            _cntDivisaRecomendada = 0;
            _gestionValidarCambio.Inicializa();
        }

        public void setDescuento(decimal porct)
        {
            _dsctoPorct= porct;
        }

        private decimal _montoValidar;
        public decimal MontoCambioDar { get { return _montoValidar; } }
        public bool Procesar() 
        {
            var rt = false;

            if (_isNotaCredito)
            {
                if (MontoRecibido > MontoPagar) 
                {
                    Helpers.Msg.Alerta("MONTO RECIBIDO DEBE SER IGUAL AL MONTO DE LA NOTA DE CREDITO");
                    return false;
                }
            }

            if (MontoRecibido >= MontoPagar) 
            {
                var msg = MessageBox.Show("Procesar Pago ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    _montoValidar = MontoCambioDar_MonedaNacional;
                    if (_montoValidar >0m)
                    {
                        _gestionValidarCambio.Inicializa();
                        _gestionValidarCambio.setMontoValidar(_montoValidar);
                        _gestionValidarCambio.setDatosPagoMovil(_entCliente);
                        _gestionValidarCambio.Inicia();
                        return _gestionValidarCambio.ValidarIsOk;
                    }
                    return true;
                }
            }

            return rt;
        }

        public bool  setDocumentoCredito() 
        {
            var msg = MessageBox.Show("Dejar Factura A Crédito ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.No)
            {
                return false;
            }
            _detalle.Clear();
            _isCredito = true;

            return true;
        }

        public void DarDescuento() 
        {
            _gestionDescuento.Inicializa();
            _gestionDescuento.setDescuento(_dsctoPorct);
            _gestionDescuento.Inicia();
            if (_gestionDescuento.IsOk) 
            {
                _dsctoPorct = _gestionDescuento.Descuento;
            }
        }

        public void setGestionLoteRef(LoteReferencia.Gestion gestion)
        {
            _gestionLoteRef = gestion;
        }

        public void setGestionDescuento(Src.Pago.Descuento.Gestion gestion)
        {
            _gestionDescuento = gestion;
        }

        public void DarCredito()
        {
            _isCredito = false;
            var msg = MessageBox.Show("Procesar Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _isCredito = true;
            }
        }

        private bool _isNotaCredito;
        public void setNotaCredito(bool estatus)
        {
            _isNotaCredito = estatus;
        }
        public void setDataCliente(OOB.Cliente.Entidad.Ficha ent)
        {
            _entCliente = ent;
        }

        public bool PagoMovilIsOk { get { return _gestionValidarCambio.PagoMovilIsOk; } }
        public PagoMovil.data PagoMovilData { get { return _gestionValidarCambio.PagoMovilData; } }
        public decimal GetPagoOtro 
        { 
            get 
            { 
                var _monto=0m;
                var _ent = _detalle.FirstOrDefault(f => f.Modo == Enumerados.ModoPago.Electronico && f.Id == 4);
                if (_ent != null) { _monto = _ent.MontoRecibido; }
                return _monto;
            } 
        }

    }

}