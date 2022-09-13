using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pago.Procesar
{
    
    public class PgPunto
    {

        private string _nroLote;
        private string _nroReferencia;
        private LoteReferencia.ILoteRef _gLoteRef;


        public PgPunto()
        {
            _nroLote = "";
            _nroReferencia = "";
            _gLoteRef = new LoteReferencia.Gestion();
        }


        public void setNroLote(string nroLote)
        {
            _nroLote = nroLote;
        }
        public void setNroReferencia(string nroReferencia)
        {
            _nroReferencia = nroReferencia;
        }
        public void AgregarPago()
        {
            _gLoteRef.Inicializa();
            _gLoteRef.setNroLote(_nroLote);
            _gLoteRef.setNroReferencia(_nroReferencia);
            _gLoteRef.Inicia();
        }

        public string GetNroLote { get { return _gLoteRef.GetNroLote; } }
        public string GetNroReferencia { get { return _gLoteRef.GetNroReferencia; } }

    }

}