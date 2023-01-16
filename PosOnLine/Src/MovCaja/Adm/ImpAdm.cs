using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.MovCaja.Adm
{
    public class ImpAdm: IAdm
    {
        private int _idOperador;
        private IAdmLista _gLista;
        private Src.MovCaja.Anular.IAnularMov _gAnularMovCaja;
        private Src.MovCaja.Agregar.IAgregar _gAgregarMovCaja;
        private Src.MovCaja.View.IViewMov _gViewMovCaja;

        public int GetData_CantItem { get { return _gLista.GetCantItem; } }
        public BindingSource GetData_Source { get { return _gLista.GetSource; } }
        public object ItemActual { get { return _gLista.GetItemActual; } }

        public ImpAdm(Src.MovCaja.Anular.IAnularMov ctrAnular,
                        Src.MovCaja.Agregar.IAgregar ctrAgregar,
                        Src.MovCaja.View.IViewMov  ctrView)
        {
            _idOperador = -1;
            _gLista = new ImpAdmLista();
            _gAnularMovCaja = ctrAnular;
            _gAgregarMovCaja=ctrAgregar;
            _gViewMovCaja = ctrView;
        }

        public void Inicializa()
        {
            _idOperador = -1;
            _gLista.Inicializa();
        }
        AdmFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new AdmFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void setIdOperadorActual(int id)
        {
            _idOperador = id;
        }

        public void Subir()
        {
            _gLista.Subir();
        }
        public void Bajar()
        {
            _gLista.Bajar();
        }
        public void AnularMov()
        {
            if (ItemActual != null) 
            {
                var _item = (data)ItemActual;
                if (_item.IsAnulado) 
                {
                    Helpers.Msg.Error("MOVIMIENTO YA SE ENCUENTRA ANULADO");
                    return;
                }
                _gAnularMovCaja.Inicializa();
                _gAnularMovCaja.setIdOperadorActual(Sistema.PosEnUso.id);
                _gAnularMovCaja.setMovAnular(_item.IdMov);
                _gAnularMovCaja.Inicia();
                if (_gAnularMovCaja.AnularMovCajaIsOk)
                {
                    _gLista.setAnularMov(_item.IdMov);
                    Helpers.Msg.EliminarOk();
                }
            }
        }
        public void AgregarMov()
        {
            _gAgregarMovCaja.Inicializa();
            _gAgregarMovCaja.setIdOperadorActual(Sistema.PosEnUso.id);
            _gAgregarMovCaja.Inicia();
            if (_gAgregarMovCaja.AgregarIsOk) 
            {
                var idNuevo = _gAgregarMovCaja.IdMovAgregado;
                try
                {
                    var r01 = Sistema.MyData.MovCaja_GetById(idNuevo);
                    var rg = new data()
                    {
                        EstatusAnulado = r01.Entidad.EstatusAnulado,
                        IdMov = r01.Entidad.IdMov,
                        NroMov = r01.Entidad.NumeroMov,
                        TipoMov = r01.Entidad.TipoMov,
                    };
                    _gLista.Agregar(rg);
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
        public void ViewMov()
        {
            if (ItemActual != null)
            {
                var _item = (data)ItemActual;
                _gViewMovCaja.Inicializa();
                _gViewMovCaja.setMovView(_item.IdMov);
                _gViewMovCaja.Inicia();
            }
        }

        public bool AbandonarIsOK { get { return true; } }
        public void AbandonarFicha()
        {
        }

        private bool CargarData()
        {
            try
            {
                var filtroOOB = new OOB.MovCaja.Lista.Filtro()
                {
                    IdOperador = _idOperador,
                };
                var r01 = Sistema.MyData.MovCaja_GetLista(filtroOOB);
                var _lst = new List<object>();
                foreach (var rg in r01.ListaD.OrderByDescending(o=>o.IdMov).ToList()) 
                {
                    var nr = new data()
                    {
                        IdMov = rg.IdMov,
                        NroMov = rg.NumeroMov,
                        TipoMov = rg.TipoMov,
                        EstatusAnulado= rg.EstatusAnulado,
                    };
                    _lst.Add(nr);
                }
                _gLista.setLista(_lst);
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