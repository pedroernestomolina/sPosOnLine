using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AsignarVededor.ModoAdm
{
    public class ImpModoAdm: IModoAdm
    {
        private string _idVendedorAsignado;
        private bool _abandonarIsOk;
        private bool _procesarIsOk;
        private Tools.Vendedor.IVendedor _vendedor;


        public Tools.Vendedor.IVendedor Vendedor { get { return _vendedor; } }
        public string IdVendedorSeleccionado { get { return _idVendedorAsignado; } }
        public bool AsignarVendedorIsOk { get { return _procesarIsOk; } }


        public ImpModoAdm()
        {
            _idVendedorAsignado = "";
            _vendedor = new Tools.Vendedor.ImpVendedor();
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _idVendedorAsignado = "";
            _vendedor.Inicializa();
        }
        Frm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public bool AbandonarIsOK { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = Helpers.Msg.Abandonar();
        }

        public bool ProcesarIsOK { get { return _procesarIsOk; } }
        public void Procesar()
        {
            _procesarIsOk = false;
            _idVendedorAsignado = "";
            if (_vendedor.GetItem == null)
            {
                Helpers.Msg.Alerta("DEBES INDICAR UN VENDEDOR");
                return;
            }
            if (Helpers.Msg.Procesar()) 
            {
                _procesarIsOk = true;
                _idVendedorAsignado = _vendedor.GetId;
            }
        }


        private bool CargarData()
        {
            try
            {
                _vendedor.CargarData();
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
    }
}