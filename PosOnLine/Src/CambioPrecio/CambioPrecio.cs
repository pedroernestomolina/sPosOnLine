using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.CambioPrecio
{
    public class CambioPrecio: IVista
    {
        private Item.data _item;
        private bool _procesarIsOk;
        private bool _abandonarIsOK;
        private decimal _precioNuevo;


        public bool CambioPrecioIsOk { get { return _procesarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOK; } }
        public decimal PrecioNuevo { get { return _precioNuevo; } }


        public CambioPrecio() 
        {
            _procesarIsOk = false;
            _abandonarIsOK = false;
            _precioNuevo = 0m;
        }


        public void Inicializa()
        {
            _procesarIsOk = false;
            _abandonarIsOK = false;
            _precioNuevo = 0m;
        }
        CambioPrecioFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new CambioPrecioFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void setDataItem(Item.data data)
        {
            _item = data;
            //_precioNuevo = data.PrecioItem ;
            _precioNuevo = data.PrecioItem/ data.TasaCambio ;
        }

        private bool CargarData()
        {
            var rt = true;
            return rt;
        }


        public void Abandonar()
        {
            _abandonarIsOK = false;
            var xmsg = "Abandonar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOK = true;
            }
        }

        public void Procesar()
        {
            _procesarIsOk = false;
            var _pn = _precioNuevo * _item.TasaCambio;
            if (_pn <= 0m) 
            {
                Helpers.Msg.Alerta("PRECIO INCORRECTO, VERIFIQUE");
                return;
            }
            if (_pn < _item.CostoItem)
            {
                Helpers.Msg.Alerta("PRECIO POR DEBAJO DEL COSTO, VERIFIQUE");
                return;
            }

            var xmsg = "Guardar Cambios Efectuados?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var fichaOOB = new OOB.Venta.Item.ActualizarPrecio.Ficha()
                {
                    idItem = _item.Id,
                    idOperador = _item.Ficha.idOperador,
                    precioNeto = _pn,
                    tarifaVenta = _item.Ficha.tarifaPrecio,
                    precioDivisa = calculaPrecioDivisaFull(_pn),
                };
                var r01 = Sistema.MyData.Venta_Item_ActualizarPrecio(fichaOOB);
                if (r01.Result ==  OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _precioNuevo = _pn;
                _procesarIsOk = true;
            }
        }

        private decimal calculaPrecioDivisaFull(decimal pn)
        {
            var rt = 0m;
            if (_item.TasaCambio >0)
            {
                rt = pn + (pn * _item.Ficha.tasaIva / 100);
                rt = rt / _item.TasaCambio;
            }
            return rt;
        }


        public string Inf_Producto { get { return _item.NombrePrd; } }
        public decimal GetPrecioNuevo { get { return _precioNuevo; } }
        public decimal Inf_PrecioActual 
        { 
            get 
            {
                var rt = 0m;
                if (_item.TasaCambio > 0) 
                {
                    rt = _item.PrecioItem / _item.TasaCambio;
                }
                return rt;
            } 
        }

        public void setPrecioNuevo(decimal pn)
        {
            _precioNuevo = pn;
        }
        public void setUsuarioAutoriza(object usuario)
        {
        }
    }
}