using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Principal
{
    
    public class Gestion
    {


        private Pos.Gestion _gestionPos;
        private PassWord.Gestion _gestionPassW;
        private AdministradorDoc.Principal.Gestion _gestionDoc;
        private Anular.IAnular _gestionAnular;
        private Cierre.Gestion _gestionCierre;
        private Configuracion.Gestion _gestionCnf;
        private Configuracion.SucursalDeposito.Gestion _gestionCnfSucDeposito;
        private Pos.ICliente _gCliente;
        private Cierre.Historico.IHistoria _gCierreHist;


        public string BD_Ruta { get { return Sistema.Instancia; } }
        public string BD_Nombre { get { return Sistema.BaseDatos; } }
        public string Version { get { return "Ver. " + Application.ProductVersion; } }
        public string JornadaActiva { get { return Sistema.PosEnUso.IsEnUso ? "ACTIVA" + Environment.NewLine + Sistema.PosEnUso.fechaApertura.ToShortDateString() + ", " + Sistema.PosEnUso.horaApertura : ""; } }
        public string OperadorActivo { get { return Sistema.PosEnUso.codUsuario + Environment.NewLine + Sistema.PosEnUso.nomUsuario; } }
        public string UsuarioActual { get { return Sistema.Usuario.codigo + Environment.NewLine + Sistema.Usuario.nombre; } }
        public string EquipoId { get { return Sistema.IdEquipo; } }
        public bool ConfiguracionIsOk { get { return Sistema.ConfiguracionActual.Estatus_Activa; } }
        public string SucursalId 
        { 
            get 
            {
                var rt = "";
                if (Sistema.Sucursal != null) 
                {
                    rt = Sistema.Sucursal.codigo;
                }
                return rt;
            }
        }
        public string Sucursal
        {
            get
            {
                var rt = "";
                if (Sistema.Sucursal != null)
                {
                    rt = Sistema.Sucursal.nombre;
                }
                return rt;
            }
        }
        public string Deposito 
        {
            get
            {
                var rt = "";
                if (Sistema.Deposito != null)
                {
                    rt = Sistema.Deposito.nombre;
                }
                return rt;
            }
        }
        public string DepositoID 
        { 
            get 
            {
                var rt = "";
                if (Sistema.Deposito != null)
                {
                    rt = Sistema.Deposito.codigo;
                }
                return rt;
            } 
        }


        public Gestion()
        {
            _gestionCnf = new Configuracion.Gestion();
            _gestionCnfSucDeposito = new Configuracion.SucursalDeposito.Gestion();
            _gestionCierre = new Cierre.Gestion();
            _gestionAnular = new Anular.ImpAnular();
            _gestionDoc = new AdministradorDoc.Principal.Gestion();
            _gestionDoc.setGestionAnular(_gestionAnular);
            _gestionPassW = new PassWord.Gestion();
            _gestionPos = new Pos.Gestion(_gestionAnular);
            _gestionPos.setGestionPassW(_gestionPassW);
            _gCierreHist = new Cierre.Historico.Historia();
            Helpers.PassWord.setGestion(_gestionPassW);
        }


        public void Inicializa()
        {
        }

        PrincipalFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                frm = new PrincipalFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            try
            {
                Sistema.FechaUltimoBoletinDescargado = new DateTime(2000, 1, 1);
                var xr0 = Sistema.MyData.Servicio_GetFechaUltBoletin();
                if (xr0.Result != OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Sistema.FechaUltimoBoletinDescargado = xr0.Entidad;
                }

                var t00 = Sistema.MyData.Sucursal_GetFicha_ByCodigo(Sistema.CodigoSucursalActivo);
                var t01 = Sistema.MyData.Sucursal_GetFichaById(t00.Entidad);
                if (t01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(t01.Mensaje);
                    return false;
                }
                Sistema.Sucursal = t01.Entidad;
                Sistema.Modo_Vuelto_Gestionar = t01.Entidad.isVueltoDivisaHabilitado;

                var t02 = Sistema.MyData.Deposito_GetFicha_ByCodigo(Sistema.CodigoDepositoActivo);
                Sistema.Deposito = t02.Entidad;

                var r01 = Sistema.MyData.Jornada_EnUso_GetBy_EquipoSucursal(Sistema.IdEquipo, Sistema.CodigoSucursalActivo);
                Sistema.PosEnUso = r01.Entidad;

                var r02 = Sistema.MyData.Configuracion_Pos_GetFicha();
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return false;
                }
                Sistema.ConfiguracionActual = r02.Entidad;
                Sistema.ConfiguracionActual.idDeposito = Sistema.Deposito.id;
                Sistema.ConfiguracionActual.idSucursal = Sistema.Sucursal.id;

                var r04 = Sistema.MyData.Sistema_Empresa_GetFicha();
                Sistema.DatosEmpresa = r04.Entidad;
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }

        public void AbrirPos()
        {
            if (Sistema.PosEnUso.IsEnUso)
            {
                if (!Sistema.Sucursal.isActivo)
                {
                    Helpers.Msg.Error("SUCURSAL EN ESTADO INACTIVO, VERIFIQUE");
                    return;
                }
                if (Sistema.Sucursal.autoDepositoPrincipal.Trim().ToUpper() == "")
                {
                    Helpers.Msg.Error("SUCURSAL NO POSEE UN DEPOSITO PRINCIPAL, VERIFIQUE");
                    return;
                }
                if (Sistema.PosEnUso.idUsuario != Sistema.Usuario.id)
                {
                    Helpers.Msg.Error("USUARIO ACTUAL NO PUEDE ABRIR POS" + Environment.NewLine + "EXISTE UNA JORNADA ABIERTA DE OTRO OPERADOR");
                    return;
                }
            }
            else 
            {
                if (Sistema.Sucursal == null) 
                {
                    Helpers.Msg.Error("CONFIGURACION SISTEMA NO HA SIDO REALIZADA, VERIFIQUE");
                    return;
                }
                if (!Sistema.Sucursal.isActivo)
                {
                    Helpers.Msg.Error("SUCURSAL EN ESTADO INACTIVO, VERIFIQUE");
                    return;
                }
                if (Sistema.Sucursal.autoDepositoPrincipal.Trim().ToUpper()=="")
                {
                    Helpers.Msg.Error("SUCURSAL NO POSEE UN DEPOSITO PRINCIPAL, VERIFIQUE");
                    return;
                }

                AbrirJornada();
            }

            if (Sistema.PosEnUso.IsEnUso) 
            {
                if (Sistema.Activar_VentasAdm)
                {
                    _gCliente = new VentaAdm.Gestion();
                }
                else
                {
                    _gCliente = new Cliente.Gestion();
                }
                frm.setVisibilidad(false);
                _gestionPos.setCtrlCliente(_gCliente);
                _gestionPos.Inicializa();
                _gestionPos.Inicia();
                frm.setVisibilidad(true);
            }
        }

        private void AbrirJornada()
        {
            var ficha = new OOB.Pos.Abrir.Ficha(Sistema.Sucursal, Sistema.IdEquipo, Sistema.Usuario);
            var r01 = Sistema.MyData.Jornada_Abrir(ficha);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var r02 = Sistema.MyData.Jornada_EnUso_GetById(r01.Id);
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }
            Sistema.PosEnUso = r02.Entidad;
        }

        public void AdmDocumentos()
        {
            if (Sistema.PosEnUso.IsEnUso)
            {
                _gestionDoc.Inicializa();
                _gestionDoc.Inicia();
                if (_gestionDoc.NotaCreditoIsOk)
                {
                    _gCliente = new Cliente.Gestion();
                    _gestionPos.setCtrlCliente(_gCliente);

                    _gestionPos.Inicializa();
                    _gestionPos.setNotaCredito(_gestionDoc.DocAplicaNotaCredito);
                    _gestionPos.Inicia();
                }
            }
            else
            {
                Helpers.Msg.Error("NO EXISTE UNA JORNADA ABIERTA");
                return;
            }
        }

        public void CerrarPos()
        {
            if (Sistema.PosEnUso.IsEnUso)
            {
                if (Sistema.PosEnUso.idUsuario != Sistema.Usuario.id)
                {
                    Helpers.Msg.Error("USUARIO ACTUAL NO PUEDE CERRAR POS" + Environment.NewLine + "EXISTE UNA JORNADA ABIERTA DE OTRO OPERADOR");
                    return;
                }

                if (Helpers.PassWord.PassWIsOk(Sistema.FuncionPosCerrarPos))
                {
                    _gestionCierre.Inicializa();
                    _gestionCierre.Inicia();
                    if (_gestionCierre.CierreIsOk)
                    {
                        Helpers.Msg.OK("OPERADOR CERRRADO EXITOSAMENTE !!!!!");
                    }
                }
            }
            else 
            {
                Helpers.Msg.Error("NO EXISTE UNA JORNADA ABIERTA");
                return;
            }
        }

        public void Test_BD()
        {
            var r01 = Sistema.MyData.Test();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Helpers.Msg.Alerta("BASE DE DATOS CONECTADA CON EXITO !!!");
        }

        public void ConfiguracionSistema()
        {
            if (Sistema.Usuario.IsInvitado)
            {
                _gestionCnf.Inicializa();
                _gestionCnf.Inicia();
                if (_gestionCnf.ConfiguracionIsOk)
                {
                    var r01 = Sistema.MyData.Configuracion_Pos_GetFicha();
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    var r02 = Sistema.MyData.Sucursal_GetFichaById(r01.Entidad.idSucursal);
                    if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r02.Mensaje);
                        return;
                    }
                    Sistema.ConfiguracionActual = r01.Entidad;
                    Sistema.Sucursal = r02.Entidad;
                }
            }
        }

        public void ConfigurarSucursalDepositoFrio()
        {
            var msg = MessageBox.Show("Estas Seguro De Cambiar Sucursal/Deposito Frio", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg==  DialogResult.Yes)
            {
                var r01 = Sistema.MyData.Configuracion_Pos_CambioDepositoSucursalFrio();
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                ActualizarDeposito();
                Helpers.Msg.EditarOk();
            }
        }

        public void ConfigurarSucursalDepositoViveres()
        {
            var msg = MessageBox.Show("Estas Seguro De Cambiar Sucursal/Deposito Viveres", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var r01 = Sistema.MyData.Configuracion_Pos_CambioDepositoSucursalViveres();
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                ActualizarDeposito();
                Helpers.Msg.EditarOk();
            }
        }

        private void ActualizarDeposito() 
        {
            var r01 = Sistema.MyData.Configuracion_Pos_GetFicha();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return ;
            }
            Sistema.ConfiguracionActual = r01.Entidad;

            if (r01.Entidad.idDeposito != "")
            {
                var r02 = Sistema.MyData.Deposito_GetFichaById(r01.Entidad.idDeposito);
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return ;
                }
                Sistema.Deposito = r02.Entidad;
            }

            if (r01.Entidad.idSucursal != "")
            {
                var r03 = Sistema.MyData.Sucursal_GetFichaById(r01.Entidad.idSucursal);
                if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r03.Mensaje);
                    return ;
                }
                Sistema.Sucursal = r03.Entidad;
            }
        }

        public void ConfigurarSucursalDeposito()
        {
            if (Helpers.PassWord.PassWIsOk(Sistema.ConfigurarDepositoSucursal))
            {
                if (Sistema.ConfiguracionActual.Estatus_Activa)
                {
                    _gestionCnfSucDeposito.Inicializa();
                    _gestionCnfSucDeposito.Inicia();
                    if (_gestionCnfSucDeposito.ConfiguracionIsOk)
                    {
                        ActualizarDeposito();
                        Helpers.Msg.EditarOk();
                    }
                }
                else
                {
                    Helpers.Msg.Error("CONFIGURACION NO DEFNIDA");
                    return;
                }
            }
        }

        public void CierreHistorico()
        {
            _gCierreHist.Inicializa();
            _gCierreHist.Inicia();
        }


        public System.Drawing.Image LogoImagen 
        { 
            get 
            { 
                if (Sistema.Modo_Despliegue_Logo_Base)
                    return PosOnLine.Properties.Resources.LOGO_BASE; 
                else
                    return PosOnLine.Properties.Resources.ZUFU; 
            } 
        }


        public DateTime Get_FechaUltBoletin { get { return Sistema.FechaUltimoBoletinDescargado; } }

    }

}