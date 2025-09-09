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
        private bool _procesarFichaIsOK;
        //
        public decimal Get_DsctoDado { get { return _dsctoDar; } }
        public bool procesarFichaIsOK { get { return _procesarFichaIsOK; } }
        public bool abandonarFichaIsOk { get { return _abandonarFicha.OpcionIsOK; } }
        //
        public DsctoImpl()
        {
            _procesarFichaIsOK=false;
            _dsctoDar = 0m;
            _abandonarFicha = new __.Ctrl.Boton.Salir.Imp();
        }
        public void Inicializa()
        {
            _procesarFichaIsOK=false;
            _dsctoDar = 0m;
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
            _procesarFichaIsOK = false;
            if (_dsctoDar >= 0m && _dsctoDar <= 99.99m)
            {
                _procesarFichaIsOK = true;
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