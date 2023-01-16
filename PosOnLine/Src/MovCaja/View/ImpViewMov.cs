using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.MovCaja.View
{
    public class ImpViewMov : IViewMov
    {
        private int _idMov;
        private dataView _data;

        public List<detalle> GetListaMedios_Source { get { return _data.ListaDet; } }
        public DateTime GetFechaEmision { get { return _data.FechaEmisionMov; } }
        public string GetConcepto { get { return _data.ConceptoMov; } }
        public string GetDetalles { get { return _data.DetallesMov; } }
        public decimal GetFactorCambio { get { return _data.FactorCambio; } }
        public decimal GetMontoMov { get {return _data.MontoMov; } }
        public string GetTipoMovDesc { get { return _data.TipoMovDesc; } }
        public decimal GetMontoDivisaMov { get { return _data.MontoDivisaMov; } }
        public string GetTipoMov { get { return _data.TipoMov; } }

        public ImpViewMov()
        {
            _idMov = -1;
            _data = new dataView();
        }
        public void Inicializa()
        {
            _idMov = -1;
            _data.Inicializa();
        }
        ViewFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new ViewFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void setMovView(int id)
        {
            _idMov = id;
        }

        public bool AbandonarIsOK { get { return true; } }
        public void AbandonarFicha()
        {
        }

        private bool CargarData()
        {
            try
            {
                var r01 = Sistema.MyData.MovCaja_GetById(_idMov);
                _data.Load(r01.Entidad);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
    }
}