using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PosItemCambiarPrecio.vm
{
    public class CambiarPrecioImpl: IGestion, ICambiarPrecio
    {
        private int _idItemCambiarPrecio;
        private bool _procesarCambioIsOK;
        private decimal _precioIngresado;
        private __.Ctrl.Boton.Abandonar.IAbandonar _btAbandonar;
        private __.Ctrl.Boton.Procesar.IProcesar _btProcesar;
        private Domain.UseCase.IUseCase _uc;
        private Domain.Models.ItemCambio _itemCambio;
        //
        public decimal Get_PrecioPagoBs { get { return _itemCambio.PrecioPagoBs; } }
        public decimal Get_PrecioPagoPrdNoDivisa { get { return _itemCambio.PrecioPagoPrdNoDivisa; } }
        public decimal Get_PrecioPagoDivisa { get { return _itemCambio.PrecioPagoDivisa; } }
        public string Get_ProductoInfo { get { return _itemCambio.ProductoInfo; } }
        public decimal Get_PorctAumentoProductosNoDivisa { get { return _itemCambio.PorctAumentoPrdNoAdmPorDivisa; } }
        public bool AbandonarFichaIsOK { get { return _btAbandonar.OpcionIsOK; } }
        public bool ProcesarCambioIsOK { get { return _procesarCambioIsOK; } }
        //
        public CambiarPrecioImpl()
        {
            _procesarCambioIsOK = false;
            _btAbandonar = new __.Ctrl.Boton.Abandonar.Imp();
            _btProcesar = new __.Ctrl.Boton.Procesar.Imp();
            _uc = new Domain.UseCase.UseCaseImpl();
        }
        public void Invoke(int idItem)
        {
            setItemCambiarPrecio(idItem);
            Inicializa();
            Inicia();
        }
        private void setItemCambiarPrecio(int idItem)
        {
            _idItemCambiarPrecio = idItem;
        }
        public void Inicializa()
        {
            _procesarCambioIsOK = false;
            _btAbandonar.Inicializa();
            _btProcesar.Inicializa();
        }
        vista.Frm frm;
        public void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null) 
                {
                    frm = new vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void setPagoMontoBs(decimal monto)
        {
            //_pagoMontoBs = monto;
        }
        public void setPagoDivisa(decimal monto)
        {
            //_pagoMontoDivisa= monto;
        }
        public void setPagoProductoNoDivisa(decimal monto)
        {
            //_pagoMontoProductoNoDivisa= monto;
        }
        //
        private bool cargarData()
        {
            try
            {
                _itemCambio = _uc.CargarItem(_idItemCambiarPrecio);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        public void AbandonarFicha()
        {
            _btAbandonar.Opcion();
        }
        public void ProcesarCambio()
        {
            _procesarCambioIsOK = false;
            _btProcesar.Opcion("Cambiar Precio De Item ?");
        }


        public decimal PrecioIngresado
        {
            get { return 0m; }
        }
    }
}
