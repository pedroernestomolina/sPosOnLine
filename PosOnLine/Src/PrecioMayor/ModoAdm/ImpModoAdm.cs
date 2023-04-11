using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PrecioMayor.ModoAdm
{
    public class ImpModoAdm: IModoAdm
    {
        private string _autoPrd;
        private string _tipoPrecioTrabajarar;
        private bool _precioSeleccionadoIsOk;
        private string _tarifaSeleccionada;


        public bool PrecioSeleccionadoIsOk { get { return _precioSeleccionadoIsOk; } }
        public string TarifaSeleccionada { get { return _tarifaSeleccionada; } }
        public string AutoProducto { get { return _autoPrd; } }


        public ImpModoAdm()
        {
            _autoPrd = "";
            _tipoPrecioTrabajarar= "";
            _tarifaSeleccionada = "";
            _precioSeleccionadoIsOk = false;
        }


        public void Inicializa()
        {
            _tarifaSeleccionada = "1"; // TIPO DE EMPAQUE A SELECCIONAR 
            _precioSeleccionadoIsOk = false;
        }
        public void Inicia()
        {
            if (CargarData())
            {
                _precioSeleccionadoIsOk = true;
            }
            else 
            {
                _tarifaSeleccionada = "";
                _precioSeleccionadoIsOk = false;
            }
        }

        private bool CargarData()
        {
            try
            {
                var r01 = Sistema.MyData.Producto_ModoAdm_VerificaPrecioVtaProducto(_autoPrd, _tipoPrecioTrabajarar, _tarifaSeleccionada);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        public void setAutoProducto(string autoPrd)
        {
            _autoPrd = autoPrd;
        }
        public void setTarifaPrecio(string tarifa)
        {
            _tipoPrecioTrabajarar= tarifa;
        }
    }
}