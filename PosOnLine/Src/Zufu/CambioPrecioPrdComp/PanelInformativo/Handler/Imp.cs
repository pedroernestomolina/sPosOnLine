using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.CambioPrecioPrdComp.PanelInformativo.Handler
{
    public class Imp: Vista.IVista
    {
        private __.Ctrl.Boton.Salir.ISalir _btSalir;
        private CambioPrecio.Vista.IdataPanel  _dataInf;
        //
        public CambioPrecio.Vista.IdataPanel DataInf { get { return _dataInf; } }
        public __.Ctrl.Boton.Salir.ISalir BtSalir { get { return _btSalir; } }
        //
        public Imp()
        {
            _btSalir = new __.Ctrl.Boton.Salir.Imp();
        }
        public void Inicializa()
        {
            _btSalir.Inicializa();
        }
        Vista.Frm frm;
        public void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null) 
                {
                    frm = new Vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void setDataInf(object data)
        {
            _dataInf = (CambioPrecio.Vista.IdataPanel)data;
        }
        //
        private bool cargarData()
        {
            return true;
        }
    }
}