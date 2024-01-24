using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.AgregarEditar.Handler
{
    public class Agregar: ImpHnd, Vista.IAgregar
    {
        private string _idNewCliente;

        public string IdNewCliente { get { return _idNewCliente; } }

        public Agregar()
            :base()
        {
            _idNewCliente = "";
        }
        public void setCiRif(string cirif)
        {
            DataFicha.setCiRif(cirif);
        }
        public override string Get_AccionFicha { get { return "Agregar Ficha"; } }
        protected override void procesarCambios()
        {
            if (Helpers.Msg.Abandonar("Procesar / Guardar Cambios ?"))
            {
                try
                {
                    var fichaOOb = new OOB.Cliente.Agregar.Ficha()
                    {
                        autoGrupo = "0000000001",
                        autoZona = "0000000001",
                        autoEstado = "0000000001",
                        autoCobrador = "0000000001",
                        autoVendedor = "0000000001",
                        ciRif = DataFicha.Get_CiRif,
                        razonSocial = DataFicha.Get_NombreRazonSocial,
                        dirFiscal = DataFicha.Get_DirFiscal,
                        telefono = DataFicha.Get_Telefono,
                        estatus = "Activo",
                        categoria = "Eventual",
                        estatusCredito = "0",
                        pais = "VZLA",
                        tarifa = "0",
                        denominacionFiscal = "No Contribuyente",
                        codigoSucursal = Sistema.Sucursal.codigo,
                    };
                    var r01 = Sistema.MyData.Cliente_AgregarFicha(fichaOOb);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        throw new Exception(r01.Mensaje);
                    }
                    _idNewCliente = r01.Auto;
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
            return true;
        }
    }
}