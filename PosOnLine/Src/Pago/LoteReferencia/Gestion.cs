using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pago.LoteReferencia
{

    public class Gestion
    {
        
        
        private bool _isOk;
        private string _lote;
        private string _referencia;


        public string Lote { get { return _lote; } }
        public string Referencia { get { return _referencia; } }
        public bool IsOk { get { return _isOk; } }


        public Gestion ()
        {
            Limpiar();
        }


        private void Limpiar()
        {
            _isOk = false;
            _lote = "";
            _referencia = "";
        }

        public void Inicializa() 
        {
            Limpiar();
        }

        LoteReferenciaFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm==null)
                {
                    frm = new LoteReferenciaFrm();
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

        public void Aceptar()
        {
            if (_lote.Trim() != "" && _referencia.Trim() != "") 
            {
                _isOk = true;
            }
        }

        public void setLote(string p)
        {
            _lote = p;
        }

        public void setReferencia(string p)
        {
            _referencia = p;
        }

    }

}