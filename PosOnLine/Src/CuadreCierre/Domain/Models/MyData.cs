using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.Domain.Models
{
    public class MyData
    {
        private DataResumenRecolectada _dataResumenRecolectada;
        private List<Domain.Models.MedioPago> _mediosPago;
        private _Domain.Models.Moneda _monedaLocal;
        private _Domain.Models.Moneda _monedaReferencia;
        private List<string> _dataResumen;
        //
        public DataResumenRecolectada DataResumenRecolectada { get { return _dataResumenRecolectada; } }
        public List<MetodoPagoUso> MetodosPagoUsado { get { return _dataResumenRecolectada.MetodosPagoUsados; } }
        public decimal MontoCuadrar { get { return _dataResumenRecolectada != null ? _dataResumenRecolectada.MontoCuadrar : 0m; } }
        public List<Models.MedioPago> MediosPago { get { return _mediosPago; } }
        public decimal VueltoMontoPorEfectivo { get { return _dataResumenRecolectada.VueltoMontoPorEfectivo; } }
        public int VueltoCntPorDivisa { get { return _dataResumenRecolectada.VueltoCntPorDivisa; } }
        public decimal VueltoMontoPorDivisa { get { return _dataResumenRecolectada.VueltoMontoPorDivisa; } }
        public decimal VueltoMontoPorPagoMovil { get { return _dataResumenRecolectada.VueltoMontoPorPagoMovil; } }
        public _Domain.Models.Moneda MonedaLocal { get { return _monedaLocal; } }
        public _Domain.Models.Moneda MonedaReferencia { get { return _monedaReferencia; } }
        public List<string> DataResumen { get { return _dataResumen; } }
        //
        public MyData()
        {
            _dataResumen = new List<string>();
            _dataResumenRecolectada = new DataResumenRecolectada();
            _mediosPago = new List<Models.MedioPago>();
        }
        //
        public void setDataResumenRecolectada(DataResumenRecolectada data)
        {
            _dataResumenRecolectada = data;
            //
            var ls = data.TiposDocumentoEmitidos.GroupBy(g => g.codigoDoc).Select(s => new { codigoDoc = s.Key, lista = s.ToList() }).ToList();
            var _ct = 20;
            var _cl = _ct+5;
            var _st = "";
            _st = "Cnt/Doc Emitidos: ".Trim().PadLeft(_ct, ' ');
            _dataResumen.Add(_st);
            _st = ls.Sum(s=> s.lista.Sum(ss=>ss.cntDoc)).ToString().Trim().PadLeft(_cl, ' ');
            _dataResumen.Add(_st);
            foreach (var it in ls) 
            {
                if (it.codigoDoc.Trim().ToUpper() == "01")
                {
                    _st = "Por Factura: ".Trim().PadLeft(_ct, ' ');
                }
                else if (it.codigoDoc.Trim().ToUpper() == "03")
                {
                    _st = "Por Nota/Credito: ".Trim().PadLeft(_ct, ' ');
                }
                else 
                {
                    _st = "NO IDENTIFICADO: ".Trim().PadLeft(_ct, ' ');
                }
                _dataResumen.Add(_st);
                _st = it.lista.Sum(s => s.cntDoc).ToString().Trim().PadLeft(_cl, ' ');
                _dataResumen.Add(_st);
                //
                _st = "Activas: ".Trim().PadLeft(_ct, ' ');
                _dataResumen.Add(_st);
                _st = it.lista.Where(w=>w.esAnulado==false).Sum(s=>s.cntDoc).ToString().Trim().PadLeft(_cl, ' ');
                _dataResumen.Add(_st);
                //
                _st = "Importe: ".Trim().PadLeft(_ct, ' ');
                _dataResumen.Add(_st);
                _st = it.lista.Where(w=>w.esAnulado==false).Sum(r => r.montoMonLocal).ToString("n2").Trim().PadLeft(_cl, ' ');
                _dataResumen.Add(_st);
                //
                _st = "Importe $: ".Trim().PadLeft(_ct, ' ');
                _dataResumen.Add(_st);
                _st = it.lista.Where(w => w.esAnulado == false).Sum(r => r.montoMonReferencia).ToString("n2").Trim().PadLeft(_cl, ' ');
                _dataResumen.Add(_st);
                //
                _st = "Anuladas: ".Trim().PadLeft(_ct, ' ');
                _dataResumen.Add(_st);
                _st = it.lista.Where(w=>w.esAnulado).Sum(s => s.cntDoc).ToString().Trim().PadLeft(_cl, ' ');
                _dataResumen.Add(_st);
                //
                _st = "Importe: ".Trim().PadLeft(_ct, ' ');
                _dataResumen.Add(_st);
                _st = it.lista.Where(w => w.esAnulado ).Sum(r => r.montoMonLocal).ToString("n2").Trim().PadLeft(_cl, ' ');
                _dataResumen.Add(_st);
                //
                _st = "Importe $: ".Trim().PadLeft(_ct, ' ');
                _dataResumen.Add(_st);
                _st = it.lista.Where(w => w.esAnulado ).Sum(r => r.montoMonReferencia).ToString("n2").Trim().PadLeft(_cl, ' ');
                _dataResumen.Add(_st);
                //
                _st = "".Trim().PadLeft(_ct, ' ');
                _dataResumen.Add(_st);
            }
        }
        public void setMediosPago(List<Models.MedioPago> lst)
        {
            _mediosPago = lst;
        }
        public void setMonedaReferencia(_Domain.Models.Moneda moneda)
        {
            _monedaReferencia = moneda;
        }
        public void setMonedaLocal(_Domain.Models.Moneda moneda)
        {
            _monedaLocal = moneda;
        }
    }
}