using System;
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
                        x = MontoCambioDar_MonedaNacional / _tasaCambio;
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
                    MontoRecibido=monto,
                };
                _detalle.Add(it);
            }
            else
            {
                it.Monto = 0;
                it.Importe = MontoResta_MonedaNacional;
                it.Monto = monto;
                it.MontoRecibido = monto;
            }
        }

        public void AddDivisa(decimal monto)
        {
            var it = _detalle.FirstOrDefault(f => f.Modo == Enumerados.ModoPago.Divisa);
            if (it == null)
            {
                it = new PagoDetalle()
                {
                    Modo = Enumerados.ModoPago.Divisa,
                    Tasa = _tasaCambio,
                    Cantidad = monto,
                    Monto = monto * _tasaCambio,
                    Lote = "",
                    Referencia = "",
                    TarjetaNro = "",
                    Importe = MontoResta_MonedaNacional,
                    MontoRecibido=monto,
                };
                _detalle.Add(it);
            }
            else
            {
                it.Monto = 0;
                it.Importe = MontoResta_MonedaNacional;
                it.Monto = monto;
                it.Monto = monto * _tasaCambio;
                it.MontoRecibido = monto;
            }
        }

        public void AddElectronico(decimal monto, int id)
        {
            var _lote = "";
            var _ref = "";

            if (monto > 0)
            {
                var xit = _detalle.FirstOrDefault(f => f.Modo == Enumerados.ModoPago.Electronico && f.Id == id);
                if (xit == null)
                {
                    _gestionLoteRef.Inicializa();
                    _gestionLoteRef.Inicia();
                }
                else
                {
                    _gestionLoteRef.Inicializa();
                    _gestionLoteRef.setLote(xit.Lote);
                    _gestionLoteRef.setReferencia(xit.Referencia);
                    _gestionLoteRef.Inicia();
                }
                if (_gestionLoteRef.IsOk)
                {
                    _lote = _gestionLoteRef.Lote;
                    _ref = _gestionLoteRef.Referencia;
                }
            }

            var it = _detalle.FirstOrDefault(f => f.Modo == Enumerados.ModoPago.Electronico && f.Id == id);
            if (it == null)
            {
                it = new PagoDetalle()
                {
                    Id = id,
                    Modo = Enumerados.ModoPago.Electronico,
                    Tasa = 1,
                    Cantidad = 1,
                    Monto = monto,
                    Lote = _lote,
                    Referencia = _ref,
                    TarjetaNro = "",
                    Importe = MontoResta_MonedaNacional,
                    MontoRecibido=monto,
                };
                _detalle.Add(it);
            }
            else
            {
                it.Monto = 0;
                it.Importe = MontoResta_MonedaNacional;
                it.Monto = monto;
                it.Lote = _lote;
                it.Referencia = _ref;
                it.TarjetaNro = "";
                it.MontoRecibido = monto;
            }
        }

        public void Limpiar()
        {
            _isCredito = false;
            _dsctoPorct = 0.0m;
            _detalle.Clear();
        }

        public void setDescuento(decimal porct)
        {
            _dsctoPorct= porct;
        }

        public bool Procesar() 
        {
            var rt = false;

            if (MontoRecibido >= MontoPagar) 
            {
                var msg = MessageBox.Show("Procesar Pago ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {

                    if (MontoRecibido > MontoPagar)
                    {
                        _gestionValidarCambio.Inicializa();
                        _gestionValidarCambio.setMontoValidar(MontoCambioDar_MonedaNacional);
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


    }

}