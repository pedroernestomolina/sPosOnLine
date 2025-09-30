using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdmAnularDoc.vm
{
    public class AnularDocImpl: IAnularDoc
    {
        private Domain.ReglaNegocio.IRule _rule;
        private Domain.UseCase.IUseCase _uc;
        private Anular.IAnular _vmAnular;
        //
        public void Inicializa()
        {
        }
        public AnularDocImpl()
        {
            _rule = new Domain.ReglaNegocio.RuleImpl();
            _uc = new Domain.UseCase.UseCaseImpl();
            _vmAnular = new Anular.ImpAnular();
        }
        public bool 
            AnularDoc(string idDoc)
        {
            var rt = false;
            //
            try
            {
                if (_rule.Permiso()) 
                {
                    var _dataAnular= _uc.RecopilarDataDocumentoAnular(idDoc);
                    _rule.ParaAnularDoc(_dataAnular);
                    _vmAnular.Inicializa();
                    _vmAnular.Inicia();
                    if (_vmAnular.ProcesarIsOK) 
                    {
                        if (Helpers.Msg.Procesar("Estas Seguro De Anular Este Documento ?"))
                        {
                            var motivo = _vmAnular.GetMotivo;
                            switch (_dataAnular.doc.tipoDoc)
                            {
                                case _Domain.Models.Enumerados.enumTipoDoc.NotaEntrega:
                                    rt = AnularNotaEntrega(_dataAnular, motivo);
                                    break;
                                case _Domain.Models.Enumerados.enumTipoDoc.NotaCredito:
                                    rt = AnularNotaCredito(_dataAnular, motivo);
                                    break;
                                case _Domain.Models.Enumerados.enumTipoDoc.Factura:
                                    rt = AnularFactura(_dataAnular, motivo);
                                    break;
                                default:
                                    Helpers.Msg.Alerta("DOCUMENTO SELECCIONADO NO DEFINIDO");
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
            //
            return rt;
        }
        //
        private bool AnularFactura(Domain.Models.DataAnular dataAnular, string motivo)
        {
            try
            {
                _uc.AnularFactura(dataAnular, motivo);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private bool AnularNotaCredito(Domain.Models.DataAnular dataAnular, string motivo)
        {
            try
            {
                _uc.AnularNotaCredito(dataAnular, motivo);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private bool AnularNotaEntrega(Domain.Models.DataAnular dataAnular, string motivo)
        {
            try
            {
                _uc.AnularNotaEntrega(dataAnular, motivo);
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
