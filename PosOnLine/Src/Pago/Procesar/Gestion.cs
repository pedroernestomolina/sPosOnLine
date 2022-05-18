using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pago.Procesar
{
    
    public class Gestion
    {


        private string _cliente;
        private bool _limpiarPagosIsOk;
        private bool _pagoIsOk;
        private Pago _pago;
        private LoteReferencia.Gestion _gestionLoteReferencia;
        private Descuento.Gestion _gestionDescuento;


        public string ClienteData { get { return _cliente; } }
        public decimal SubTotalMontoPagar { get { return _pago.SubTotalMontoPagar; } }
        public decimal TasaCambio { get { return _pago.TasaCambio; } }
        public decimal MontoPagar { get { return _pago.MontoPagar; } }
        public decimal MontoPagarDivisa { get { return _pago.MontoPagarDivisa; } }
        public decimal MontoResta_MonedaNacional { get { return _pago.MontoResta_MonedaNacional; } }
        public decimal MontoResta_Divisa { get { return _pago.MontoResta_Divisa; } }
        public decimal MontoDivisa { get { return _pago.MontoDivisa; } }
        public decimal MontoRecibido { get { return _pago.MontoRecibido; } }
        public decimal MontoCambioDar_MonedaNacional { get { return _pago.MontoCambioDar_MonedaNacional; } }
        public decimal MontoCambioDar_Divisa { get { return _pago.MontoCambioDar_Divisa; } }
        public decimal DescuentoPorct { get { return _pago.DescuentoPorct; } }
        public bool LimpiarPagosIsOk { get { return _limpiarPagosIsOk; } }
        public string PagoElectronico_LOTE_1 { get { return _pago.PagoElectronico_LOTE(1); } }
        public string PagoElectronico_REF_1 { get { return _pago.PagoElectronico_REF(1); } }
        public string PagoElectronico_LOTE_2 { get { return _pago.PagoElectronico_LOTE(2); } }
        public string PagoElectronico_REF_2 { get { return _pago.PagoElectronico_REF(2); } }
        public string PagoElectronico_LOTE_3 { get { return _pago.PagoElectronico_LOTE(3); } }
        public string PagoElectronico_REF_3 { get { return _pago.PagoElectronico_REF(3); } }
        public string PagoElectronico_LOTE_4 { get { return _pago.PagoElectronico_LOTE(4); } }
        public string PagoElectronico_REF_4 { get { return _pago.PagoElectronico_REF(4); } }
        public bool PagoIsOk { get { return _pagoIsOk; } }
        public List<PagoDetalle> PagoDetalles { get { return _pago.Detalle; } }
        public bool IsCreditoOk { get { return _pago.IsCredito; } }
        

        public Gestion()
        {
            _gestionLoteReferencia = new LoteReferencia.Gestion();
            _gestionDescuento = new Descuento.Gestion();
            _pago = new Pago();
            _pago.setGestionLoteRef(_gestionLoteReferencia);
            _pago.setGestionDescuento(_gestionDescuento);
        }


        public void Inicializar()
        {
            _cliente = "";
            _pagoIsOk = false;
            _limpiarPagosIsOk = false;
            _pago.Limpiar();
        }

        ProcesarFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new ProcesarFrm();
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

        public void setCliente(string data)
        {
            _cliente = data;
        }

        public void setImporte(decimal monto)
        {
            _pago.setMontoPagar(monto);
        }

        public void setTasaCambio(decimal tasa)
        {
            _pago.setTasaCambio(tasa);
        }

        public void Calculadora()
        {
            Helpers.Utilitis.Calculadora();
        }


        public void AddEfectivo(decimal monto)
        {
            _pago.AddEfectivo(monto);
        }

        public void AddDivisa(decimal monto)
        {
            _pago.AddDivisa(monto);
        }

        public void AddElectronico(decimal monto, int p)
        {
            _pago.AddElectronico(monto, p);
        }

        public void LimpiarPagos()
        {
            _limpiarPagosIsOk = false;
            var mes = MessageBox.Show("Limpiar Metodos De Pagos?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (mes == DialogResult.Yes) 
            {
                _pago.Limpiar();
                _limpiarPagosIsOk = true;
            }
        }

        public void Procesar()
        {
            _pagoIsOk = _pago.Procesar();
        }

        public void DarDescuento()
        {
            if (Helpers.PassWord.PassWIsOk(Sistema.FuncionPosTeclaDescuento))
            {
                _pago.DarDescuento();
            }
        }

        public void DarCredito()
        {
            if (Helpers.PassWord.PassWIsOk(Sistema.FuncionPosTeclaCredito))
            {
                _pago.DarCredito();
                _pagoIsOk = _pago.IsCredito;
            }
        }

        public void setDescuento(decimal dsctoFinal)
        {
            _pago.setDescuento(dsctoFinal);
        }

    }

}