using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.Domain.Models
{
    public class DataResumenRecolectada
    {
        private List<MetodoPagoUso> _lstMP;
        private List<TipoDocUso> _lstDoc;
        private TotalesRecogido _totales;
        //
        public List<MetodoPagoUso> MetodosPagoUsados { get { return _lstMP; } }
        public List<TipoDocUso> TiposDocumentoEmitidos { get { return _lstDoc; } }
        public TotalesRecogido Totales { get { return _totales; } }
        //
        public DataResumenRecolectada()
        {
            _lstMP = new List<MetodoPagoUso>();
            _lstDoc = new List<TipoDocUso>();
            _totales = new TotalesRecogido();
        }
        public void setMetodosPagoUsados(List<MetodoPagoUso> lst)
        {
            _lstMP.Clear();
            _lstMP.AddRange(lst);
        }
        public void setDocumentosEmitidos(List<TipoDocUso> lst)
        {
            _lstDoc.Clear();
            _lstDoc.AddRange(lst);
        }
        public void setTotalRecogido(TotalesRecogido ficha)
        {
            _totales = ficha;
        }
    }
}