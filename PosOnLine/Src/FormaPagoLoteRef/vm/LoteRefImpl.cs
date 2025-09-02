using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPagoLoteRef.vm
{
    public class LoteRefImpl: ILoteRef
    {
        private string _lote;
        private string _referencia;
        private __.Ctrl.Boton.Salir.ISalir _salir;
        private bool _datosValidosIsOk;
        //
        public string getLote { get { return _lote; } }
        public string getReferencia { get { return _referencia; } }
        public bool DatosValidosIsOk { get { return _datosValidosIsOk; } }
        public bool salidaIsOk { get { return _salir.OpcionIsOK; } }
        //
        public LoteRefImpl()
        {
            _lote = "";
            _referencia = "";
            _datosValidosIsOk = false;
            _salir = new __.Ctrl.Boton.Salir.Imp();
        }
        public void Inicializa()
        {
            _lote = "";
            _referencia = "";
            _datosValidosIsOk = false;
            _salir.Inicializa();
        }
        private vista.Frm frm;
        public void Inicia()
        {
            if (frm == null) 
            {
                frm = new vista.Frm();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }
        public void setLote(string p)
        {
            _lote = p;
        }
        public void setReferencia(string p)
        {
            _referencia = p;
        }
        public void salir()
        {
            _datosValidosIsOk = false;
            if (_referencia.Trim() != "")
            {
                _datosValidosIsOk = true;
            }
            _salir.Opcion();
        }
    }
}