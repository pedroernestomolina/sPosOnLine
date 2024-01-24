using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.AgregarEditar.Handler
{
    public abstract class ImpHnd: Vista.IAgregarEditar
    {
        private __.Ctrl.Boton.Abandonar.IAbandonar _abandonar;
        private __.Ctrl.Boton.Procesar.IProcesar _procesar;
        private Vista.IDataFicha _dataFicha;

        public __.Ctrl.Boton.Abandonar.IAbandonar Abandonar { get { return _abandonar; ;} }
        public __.Ctrl.Boton.Procesar.IProcesar Procesar { get { return _procesar; } }
        public Vista.IDataFicha DataFicha { get { return _dataFicha; } }
        public abstract string Get_AccionFicha { get; }
       
        public ImpHnd()
        {
            _abandonar = new __.Ctrl.Boton.Abandonar.Imp();
            _procesar = new __.Ctrl.Boton.Procesar.Imp();
            _dataFicha = new dataFicha();
        }
        public void Inicializa()
        {
            _abandonar.Inicializa();
            _procesar.Inicializa();
            _dataFicha.Inicializa();
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
        public void ProcesarGuardar()
        {
            _procesar.setOpcion(false);
            if (_dataFicha.VerificarDataIsOk())
            {
                procesarCambios();
            }
        }

        protected abstract void procesarCambios();
        protected abstract bool cargarData();
    }
}