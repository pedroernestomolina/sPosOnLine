using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.MovCaja.View
{
    public class dataView
    {
        private List<detalle> _lista;

        public List<detalle> ListaDet { get { return _lista; } }
        public DateTime FechaEmisionMov { get; set; }
        public string ConceptoMov { get; set; }
        public string DetallesMov { get; set; }
        public decimal FactorCambio { get; set; }
        public decimal MontoMov { get; set; }
        public decimal MontoDivisaMov { get; set; }
        public string TipoMovDesc { get; set; }
        public string TipoMov { get; set; }

        public dataView()
        {
            _lista = new List<detalle>();
            Inicializa();
        }
        public void Inicializa()
        {
            FechaEmisionMov = DateTime.Now.Date;
            ConceptoMov = "";
            DetallesMov = "";
            FactorCambio = 0m;
            MontoMov = 0m;
            TipoMovDesc = "";
            TipoMov = "";
            _lista.Clear();
        }
        public void Load(OOB.MovCaja.Entidad.Ficha ficha)
        {
            var _tipo="SALIDA";
            if (ficha.TipoMov == "E") 
            {
                _tipo = "ENTRADA";
            }
            FechaEmisionMov = ficha.FechaMov;
            ConceptoMov = ficha.ConceptoMov;
            DetallesMov = ficha.DetalleMov;
            MontoMov = ficha.MontoMov;
            TipoMovDesc = _tipo;
            FactorCambio=ficha.FactorCambio;
            MontoDivisaMov = ficha.MontoDivisaMov;
            TipoMov = ficha.TipoMov;
            foreach (var r in ficha.Detalles) 
            {
                var nr = new detalle()
                {
                    Cant = r.cntDivisa,
                    Importe = r.monto,
                    Medio = r.descMedio,
                    Monto = r.monto,
                };
                if (r.cntDivisa > 0)
                {
                    nr.Monto = 0m;
                }
                _lista.Add(nr);
            }
        }
    }
}