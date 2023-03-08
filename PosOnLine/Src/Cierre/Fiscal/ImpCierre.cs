using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Cierre.Fiscal
{
    public class ImpCierre: ICierre
    {
        private NoFiscal.INoFiscal _noFiscal;
        private LibFoxFiscal.LibFoxFiscal.IFiscal _hndFiscal;


        public ImpCierre(NoFiscal.INoFiscal ctrCierrePosNoFiscal, 
                        LibFoxFiscal.LibFoxFiscal.IFiscal ctrFiscal)
        {
            _abandonarIsOk = false;
            _noFiscal = ctrCierrePosNoFiscal;
            _hndFiscal=ctrFiscal;
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
        }
        Frm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new Frm();
                    frm.setControador(this);
                }
                frm.ShowDialog();
            }
        }

        public void ReporteX()
        {
            if (Helpers.Msg.Autorizar("AUTORIZA EL GENERAR REPORTE (X) FISCAL ?")) 
            {
                try
                {
                    var r01 = _hndFiscal.GenerarReporteX();
                    if (r01.Resultado == LibFoxFiscal.Resultado.EnumResultado.ERROR)
                    {
                        throw new Exception(r01.MensajeError);
                    }
                    Helpers.Msg.OK("REPORTE ENVIADO EXITOSAMENTE");
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
        public void ReporteZ()
        {
            if (Helpers.Msg.Autorizar("AUTORIZA EL GENERAR REPORTE (Z) FISCAL ?"))
            {
                try
                {
                    var r01 = _hndFiscal.GenerarReporteZ();
                    if (r01.Resultado == LibFoxFiscal.Resultado.EnumResultado.ERROR)
                    {
                        throw new Exception(r01.MensajeError);
                    }
                    Helpers.Msg.OK("REPORTE ENVIADO EXITOSAMENTE");
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
        public void CierreNoFiscal()
        {
            _noFiscal.Inicializa();
            _noFiscal.Inicia();
            if (_noFiscal.CierreIsOk)
            {
                Helpers.Msg.OK("OPERADOR CERRRADO EXITOSAMENTE !!!!!");
            }
        }

        private bool _abandonarIsOk;
        public bool AbandonarIsOK { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = true;
        }


        private bool CargarData()
        {
            return true;
        }
    }
}