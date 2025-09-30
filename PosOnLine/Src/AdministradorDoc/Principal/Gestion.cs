using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.AdministradorDoc.Principal
{
    public class Gestion
    {
        private bool _isModoFiscal;
        private bool _anularDocumentoIsOk;
        private bool _notaCreditoIsOk;
        private Lista.data _docAplicarNotaCredito;
        private Anular.IAnular _gestionAnular;
        private Visualizar.Gestion _gestionVisualizar;
        private PosImprimirTicket.vm.IPosImprimir _vmImprimirTicket;
        private AdmAnularDoc.vm.IAnularDoc _vmAnularDoc;
        private AdmVisualizarDoc.vm.IVisualizar _vmVisualizarDoc;
        //
        public object ItemActual { get { return _gestionLista.ItemActual; } }
        public int CntItems { get { return _gestionLista.CntItems; } }
        private Lista.Gestion _gestionLista;
        public bool NotaCreditoIsOk { get { return _notaCreditoIsOk; } }
        public Lista.data DocAplicaNotaCredito { get { return _docAplicarNotaCredito; } }
        public BindingSource Source { get { return _gestionLista.Source; } }
        public bool AnularDocumentoIsOk { get { return _anularDocumentoIsOk; } }
        //
        public Gestion()
        {
            _anularDocumentoIsOk = false;
            _isModoFiscal = Sistema.ModoFiscalActivo;
            _notaCreditoIsOk = false;
            _docAplicarNotaCredito = null;
            _gestionVisualizar = new Visualizar.Gestion();
            _gestionLista = new Lista.Gestion();
            _vmImprimirTicket = new PosImprimirTicket.vm.PosImprimirImpl();
            _vmAnularDoc = new AdmAnularDoc.vm.AnularDocImpl();
            _vmVisualizarDoc = new AdmVisualizarDoc.vm.VisualizarImpl();
        }
        public void Inicializa()
        {
            _docAplicarNotaCredito = null;
            _anularDocumentoIsOk = false;
            _isModoFiscal = Sistema.ModoFiscalActivo;
            _anularDocumentoIsOk = false;
            _gestionLista.Inicializa();
            _notaCreditoIsOk = false;
            _vmAnularDoc.Inicializa();
            _vmVisualizarDoc.Inicializa();
        }
        AdmDocFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AdmDocFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void setGestionAnular(Anular.IAnular ctr)
        {
            _gestionAnular = ctr;
        }
        public void SubirItem()
        {
            _gestionLista.SubirItem();
        }
        public void BajarItem()
        {
            _gestionLista.BajarItem();
        }
        public void NotaCredito()
        {
            _notaCreditoIsOk = false;
            _docAplicarNotaCredito = null;
            if (AplicaParaNotaCredito())
            {
                if (Helpers.PassWord.PassWIsOk(Sistema.FuncionAdmNotaCredito))
                {
                    _notaCreditoIsOk = true;
                }
            }
        }
        public void AnularDocumento()
        {
            _anularDocumentoIsOk = false;
            if (ItemActual == null) return;
            var itemAnular = (Lista.data)ItemActual;
            if (_vmAnularDoc.AnularDoc(itemAnular.idDocumento)) 
            {
                _anularDocumentoIsOk = true;
                _gestionLista.setAnularDoc();
            };
        }
        public void ImprimirDocumento()
        {
            if (_gestionLista.ItemActual == null) return;
            if (Helpers.PassWord.PassWIsOk(Sistema.FuncionAdmReimprimirDocumento))
            {
                var item = (Lista.data)_gestionLista.ItemActual;
                Imprimir(item.idDocumento);
            }
        }
        public void ImprimirDocumentoAnulado()
        {
            if (_gestionLista.ItemActual == null) return;
            var item = (Lista.data)_gestionLista.ItemActual;
            Imprimir(item.idDocumento);
        }
        public void VisualizarDocumento()
        {
            visualizarDoc();
        }
        public void ActualizarModoDoc()
        {
            if (Sistema.ModoFiscalActivo)
            {
                _isModoFiscal = !_isModoFiscal;
                CargarDocumentos();
            }
        }
        //
        private bool CargarData()
        {
            try
            {
                var filtro = new OOB.Documento.Lista.Filtro() { idArqueo = Sistema.PosEnUso.idAutoArqueoCierre };
                var r01 = Sistema.MyData.Documento_Get_Lista(filtro);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                var _lst = r01.ListaD;
                if (Sistema.ModoFiscalActivo)
                {
                    _lst = r01.ListaD.Where(d => d.IsFiscal).ToList();
                }
                _gestionLista.setData(_lst);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void visualizarDoc()
        {
            if (ItemActual == null) return;
            var item = (Lista.data)ItemActual;
            _vmVisualizarDoc.setIdDocumentoVisualizar(item.idDocumento);
            _vmVisualizarDoc.Visualizar();
        }
        private void CargarDocumentos()
        {
            try
            {
                var filtro = new OOB.Documento.Lista.Filtro() { idArqueo = Sistema.PosEnUso.idAutoArqueoCierre };
                var r01 = Sistema.MyData.Documento_Get_Lista(filtro);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (_isModoFiscal)
                {
                    _gestionLista.setData(r01.ListaD.Where(d => d.IsFiscal).ToList());
                }
                else
                {
                    _gestionLista.setData(r01.ListaD);
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        private bool AplicaParaNotaCredito()
        {
            if (ItemActual == null) return false;
            var it = (Lista.data)ItemActual;
            if (it.DocTipo == Lista.Enumerados.enumTipoDoc.Factura || it.DocTipo == Lista.Enumerados.enumTipoDoc.NotaEntrega)
            {
                if (it.IsAnulado)
                {
                    Helpers.Msg.Error("A DOCUMENTO ANULADO NO SE PUEDE APLICAR NOTA DE CREDITO");
                    return false;
                }
                _docAplicarNotaCredito = it;
                return true;
            }
            else
            {
                Helpers.Msg.Error("NO SE PUEDE APLICAR NOTA DE CREDITO A ESTE TIPO DE DOCUMENTO");
                return false;
            }
        }
        //
        private void Imprimir(string idDoc)
        {
            try
            {
                _vmImprimirTicket.ImprimirCopiaDocumento(idDoc);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}