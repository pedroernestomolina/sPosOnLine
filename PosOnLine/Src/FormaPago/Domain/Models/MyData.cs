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
        private ConfiguracionIGTF _configuracionIGTF;
        //
        public List<MedioPago> mediosPago { get { return _mediosPago; } }
        public MedioPago medioPagoSeleccionado { get { return _medioPagoSeleccionado; } }
        public List<FormaPago> formasPago { get {return _formasPago;} }
        public ConfiguracionIGTF ConfgiuracionIGTF { get { return _configuracionIGTF; } }
        //
        public MyData()
        {
            _mediosPago = new List<MedioPago>();
            _medioPagoSeleccionado = null;
            _formasPago = new List<FormaPago>();
            _configuracionIGTF = new ConfiguracionIGTF();
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
        public void setConfgiuracionIGTF(ConfiguracionIGTF conf)
        {
            _configuracionIGTF = conf;
        }
    }
}
