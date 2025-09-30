using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.AdmVisualizarDoc.vm
{
    public class VisualizarImpl: IVisualizar
    {
        private string _idDoc;
        private Domain.UseCase.IUseCase _uc;
        private Domain.Models.DocVisualizar _docVisualizar;
        private BindingSource _bs;
        //
        public object Get_ItemSource { get { return _bs; } }
        public string Get_Doc_Tipo { get { return _docVisualizar.encabezado.documentoNombre; } }
        public string Get_Doc_Numero { get { return _docVisualizar.encabezado.documentoNro; } }
        public string Get_Doc_FechaEmision { get { return _docVisualizar.encabezado.documentoFechaEmision.ToShortDateString(); } }
        public string Get_Doc_ClienteInfo { get { return _docVisualizar.encabezado.clienteInfo; } }
        public bool Get_doc_IsCredito { get { return _docVisualizar.encabezado.documentoIsCredito; } }
        public bool Get_doc_IsAnulado { get { return _docVisualizar.encabezado.documentoIsAnulado; } }
        public string Get_Doc_Importe 
        { 
            get 
            { 
                return _docVisualizar.encabezado.documentoImporteMonLocal.ToString("n2")+Environment.NewLine+ _docVisualizar.encabezado.documentoImporteMonReferencia.ToString("n2")+"$"; 
            } 
        }

        //
        public VisualizarImpl()
        {
            _idDoc = "";
            _docVisualizar = null;
            _bs = new BindingSource();
            _uc = new Domain.UseCase.UseCaseImpl();
        }
        public void setIdDocumentoVisualizar(string id)
        {
            _idDoc = id;
        }
        public void Inicializa()
        {
            _idDoc = "";
            _docVisualizar = null;
        }
        public void Inicia()
        {
        }
        vista.Frm frm;
        public void Visualizar()
        {
            if (_idDoc == "") return;
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
        private bool cargarData()
        {
            var rt = false;
            //
            try
            {
                _docVisualizar = _uc.DocumentoVisualizar(_idDoc);
                _bs.DataSource = _docVisualizar.cuerpo;
                rt = true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
            //
            return rt;
        }
    }
}