using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPagoDscto.vm
{
    public class DsctoImpl : IDscto
    {
        private decimal _dsctoDar;
        private __.Ctrl.Boton.Salir.ISalir _abandonarFicha;
        private __.Ctrl.Boton.Salir.ISalir _procesarFicha;
        //
        public decimal Get_DsctoDado { get { return _dsctoDar; } }
        public bool procesarFichaIsOK { get { return _procesarFicha.OpcionIsOK; } }
        public bool abandonarFichaIsOk { get { return _abandonarFicha.OpcionIsOK; } }
        //
        public DsctoImpl()
        {
            _dsctoDar = 0m;
            _procesarFicha = new __.Ctrl.Boton.Salir.Imp();
            _abandonarFicha = new __.Ctrl.Boton.Salir.Imp();
        }
        public void Inicializa()
        {
            _dsctoDar = 0m;
            _procesarFicha.Inicializa();
            _abandonarFicha.Inicializa();
        }
        //
        public void setDsctoDar(decimal porct)
        {
            _dsctoDar = porct;
        }
        //
        FormaPagoDscto.vista.Frm frm;
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
        //
        public void procesarFicha()
        {
            if (_dsctoDar >= 0m && _dsctoDar <= 99.99m)
            {
                _procesarFicha.Opcion();
            }
            else 
            {
                Helpers.Msg.Alerta("Monto Descuento a Dar Incorrecto");
            }
        }
        public void abandonarFicha()
        {
            _abandonarFicha.Opcion();
        }
        //
        private bool cargarData()
        {
            var rt = true;
            //
            return rt;
        }
    }
}