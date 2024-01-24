using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.AgregarEditar.Handler
{
    public class Editar : ImpHnd, Vista.IEditar
    {
        private string _idEditar;

        public Editar()
            : base()
        {
            _idEditar = "";
        }
        public override string Get_AccionFicha { get { return "Editar Ficha"; } }
        public void setIdEditar(string id)
        {
            _idEditar = id;
        }
        protected override void procesarCambios()
        {
            if (Helpers.Msg.Abandonar("Procesar / Guardar Cambios ?"))
            {
                try
                {
                    var ficha = new OOB.Cliente.Editar.Ficha()
                    {
                        auto = DataFicha.Get_Id,
                        ciRif = DataFicha.Get_CiRif,
                        dirFiscal = DataFicha.Get_DirFiscal,
                        razonSocial = DataFicha.Get_NombreRazonSocial,
                        telefono = DataFicha.Get_Telefono,
                    };
                    var r01 = Sistema.MyData.Cliente_EditarFicha(ficha);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        throw new Exception(r01.Mensaje);
                    }
                    Procesar.setOpcion(true);
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
        protected override bool cargarData()
        {
            var r01 = Sistema.MyData.Cliente_GetFicha(_idEditar);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            DataFicha.setCliente(r01.Entidad);
            return true;
        }
    }
}