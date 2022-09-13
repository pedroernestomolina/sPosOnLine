using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pago.LoteReferencia
{

    public class Gestion: ILoteRef
    {
        
        
        private string _lote;
        private string _referencia;
        private bool _abandonarIsOk;
        private bool _procesarIsOk;


        public Gestion()
        {
            _lote = "";
            _referencia = "";
            _abandonarIsOk = false;
            _procesarIsOk = false;
        }


        public void Inicializa() 
        {
            _lote = "";
            _referencia = "";
            _abandonarIsOk = false;
            _procesarIsOk = false;
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


        public void setNroLote(string nro)
        {
            _lote = nro;
        }
        public void setNroReferencia(string nro)
        {
            _referencia = nro;
        }
        public string GetNroLote { get { return _lote; } }
        public string GetNroReferencia { get { return _referencia; } }


        public bool AbandonarIsOK { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = true;
        }

        public bool LoteRefIsOk { get { return _procesarIsOk; } }
        public bool ProcesarIsOK { get { return _procesarIsOk; } }
        public void Procesar()
        {
            _procesarIsOk = false;
            if (_lote.Trim() != "" && _referencia.Trim() != "")
            {
                _procesarIsOk = true;
            }
        }


        private bool CargarData()
        {
            return true;
        }

    }

}