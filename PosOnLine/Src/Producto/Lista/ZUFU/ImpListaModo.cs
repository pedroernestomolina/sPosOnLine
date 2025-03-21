using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Producto.Lista.ZUFU
{
    public class ImpListaModo : PosOnLine.Src.Producto.Lista.IListaModo
    {
        private List<OOB.Producto.Lista.Ficha> _lst;
        private decimal _tasaCambio;
        private decimal _porctBonoDivisa;
        private bool _habilitarBonoDivisa; 
        private IListaProducto _listaPrd;
        //
        private bool _isCantidadVisible;
        private bool _isPrecioVisible;
        //
        public bool ItemSeleccionIsOk { get { return _listaPrd.ItemSeleccionadoIsOk; } }
        public string IdItemSeleccionado { get { return ItemSeleccionado.Auto; } }
        public bool GetSalirMismaLista { get { return _listaPrd.SalirListaIsOk; } }
        public OOB.Producto.Lista.Ficha ItemSeleccionado { get { return (OOB.Producto.Lista.Ficha)_listaPrd.ItemSeleccionado; } }
        //
        public bool IsCantidadVisible { get { return _isCantidadVisible; } }
        public bool IsPrecioVisible { get { return _isPrecioVisible; } }
        //
        public ImpListaModo()
        {
            _lst = null;
            _tasaCambio = 0m;
            _listaPrd = new ImpListaProducto();
            //
            _isCantidadVisible = true;
            _isPrecioVisible = true;
        }
        public void Inicializa()
        {
            _listaPrd.Inicializa();
        }
        public void setData(List<OOB.Producto.Lista.Ficha> lst, decimal tasaCambio)
        {
            _lst = lst;
            _tasaCambio = tasaCambio;
        }
        public void Inicia()
        {
            try
            {
                cargarData();
                _listaPrd.setData(_lst, _tasaCambio, _porctBonoDivisa, _habilitarBonoDivisa);
                _listaPrd.Inicia();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return ;
            }
        }
        public void setCantidadVisible(bool valor) 
        {
            _isCantidadVisible = valor;
        }
        public void setPrecioVisible(bool valor)
        {
            _isPrecioVisible = valor;
        }
        //03/04
        public void setFiltroPrdListar(OOB.Producto.Lista.Filtro filtro)
        {
        }
        //
        public bool ProductoSeleccionadoIsPesado 
        { 
            get 
            {
                if (ItemSeleccionado != null)
                {
                    return ItemSeleccionado.IsPesado;
                }
                else 
                {
                    return false;
                }
            } 
        }
        //
        private void cargarData()
        {
            _porctBonoDivisa = 0m;
            var r01 = Sistema.MyData.Configuracion_HabilitarDescuentoUnicamenteConPagoEnDivsa();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            _habilitarBonoDivisa = r01.Entidad;
            var r02 = Sistema.MyData.Configuracion_ValorMaximoPorcentajeDescuento();
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(r02.Mensaje);
            }
            _porctBonoDivisa = r02.Entidad;
        }
    }
}