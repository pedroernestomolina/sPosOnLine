using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.Domain.ReglaNegocio
{
    public class ReglasImpl: IReglas
    {
        private UseCase.IUseCase _uc;
        //
        public ReglasImpl(UseCase.IUseCase uc)
        {
            _uc = uc;
        }
        public bool
            ParaDarDescuento()
        {
            return Helpers.PassWord.PassWIsOk(Sistema.FuncionPosTeclaDescuento);
        }
        public bool 
            ParaDejarlaACredito(string idCliente)
        {
            var rt = false;
            //
            try
            {
                if (Sistema.Sucursal.HabilitarVentaCredito)
                {
                    var estatusIsOk = _uc.CargarEstatusCreditoCliente(idCliente);
                    if (estatusIsOk)
                    {
                        if (Helpers.PassWord.PassWIsOk(Sistema.FuncionPosTeclaCredito))
                        {
                            rt = true;
                        }
                    }
                    else
                    {
                        Helpers.Msg.Error("Cliente no habilitado para CREDITO !!");
                    }
                }
                else
                {
                    Helpers.Msg.Error("Sucursal no habilitada para generar documentos a CREDITO !!");
                }
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