using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.Domain.Models
{
    public class MyData
    {
        private List<MedioPago> _mediosPago;
        private List<FormaPago> _formasPago;
        private MedioPago _medioPagoSeleccionado;
        //
        public List<MedioPago> mediosPago { get { return _mediosPago; } }
        public MedioPago medioPagoSeleccionado { get { return _medioPagoSeleccionado; } }
        public List<FormaPago> formasPago { get {return _formasPago;} }
        //
        public MyData()
        {
            _mediosPago = new List<MedioPago>();
            _medioPagoSeleccionado = null;
            _formasPago = new List<FormaPago>();
        }
        //
        public void setMediosPago(List<MedioPago> list)
        {
            _mediosPago = list.OrderBy(o => o.nombreMp).ToList();
        }
        public void setMedioPago(string id)
        {
            _medioPagoSeleccionado = null;
            if (id.Trim() != "")
            {
                _medioPagoSeleccionado = _mediosPago.Find(f => f.id == id);
            }
        }
    }
}
