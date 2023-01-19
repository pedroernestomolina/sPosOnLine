using PosOnLine.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine
{
    
    public class Sistema
    {

        static public IData MyData;
        static public Lib.Controles.BalanzaSoloPeso.IBalanza MyBalanza;

        static public string Instancia;
        static public string BaseDatos;
        public static OOB.Usuario.Entidad.Ficha Usuario;
        public static OOB.Pos.EnUso.Ficha PosEnUso;
        public static OOB.Configuracion.Entidad.Ficha ConfiguracionActual;
        public static OOB.Sucursal.Entidad.Ficha Sucursal;
        public static OOB.Deposito.Entidad.Ficha Deposito;
        public static OOB.Sistema.Empresa.Ficha DatosEmpresa;
        public static string IdEquipo;
        public static string EquipoEstacion;

        //FUNCIONES DEL POS
        public static string FuncionPosDevolucion           = "0816010000";
        public static string FuncionPosAnularVenta          = "0816020000";
        public static string FuncionPosTeclaSumar           = "0816030000";
        public static string FuncionPosTeclaMultiplicar     = "0816040000";
        public static string FuncionPosTeclaRestar          = "0816050000";
        public static string FuncionPosTeclaPendiente       = "0816060000";
        public static string FuncionPosTeclaPendienteAnular = "0816070000";
        public static string FuncionPosTeclaDescuento       = "0816080000";
        public static string FuncionPosTeclaCredito         = "0816090000";
        public static string FuncionPosElaborarNotaEntrega  = "0816130000";
        public static string FuncionAdmAnularDocumento      = "0816100000";
        public static string FuncionAdmNotaCredito          = "0816110000";
        public static string FuncionAdmReimprimirDocumento  = "0816120000";
        public static string ConfigurarDepositoSucursal     = "0816140000";
        public static string FuncionPosElaborarFacturaVenta = "0816150000";
        public static string FuncionPosCambiarPrecioVenta   = "0816160000";
        public static string FuncionPosCerrarPos            = "0816170000";

        //METODOS DE IMPRESION DOCUMENTO
        public static Helpers.Imprimir.IDocumento ImprimirFactura;
        public static Helpers.Imprimir.IDocumento ImprimirNotaCredito;
        public static Helpers.Imprimir.IDocumento ImprimirNotaEntrega;
        public static Helpers.Imprimir.ICuadreCaja ImprimirCuadreCaja;

        //
        public static string SerieFactura;
        public static string SerieNCredito;
        public static string SerieNEntrega;

        //
        public static string CLAVE_ADMINISTRADOR = "71277128";
        public static string USUARIO_ADMINISTRATIVO = "ADMINISTRADOR";
        public static string USUARIO_ADMINISTRATIVO_CLAVE = "ADMIN";

        //
        public static string CodigoSucursalActivo;
        public static string CodigoDepositoActivo;

        //
        //ESTA OPCION PERMITE AL FACTURADOR DEJAR UNICAMENTE EL DOCUMENTO EN PENDIENTE, PARA SER FACTURADO POR OTRO EQUIPO
        public static bool ModoSoloDocPendiente;

        //
        //ESTA OPCION PERMITE ABRIR DOCUMENTOS PENDIENTES DE OTROS USUARIOS, PARA PODER SER FACTURADOS
        public static bool ModoAbrirDocPendOtrosUsuarios;

        //
        public static bool HabilitarTiposEmpaqueAlBuscarPorCodigoDeBarra;

        //DATOS PARA EL TICKET
        public static string DatosNegociTicket_Rif;
        public static string DatosNegociTicket_Nombre;
        public static string DatosNegociTicket_Direccion;

        //PARA OPCION VENTAS ADMINITRATIVA
        public static bool Activar_VentasAdm;

        // CONFIGURACION POS
        public static bool Modo_Vuelto_Gestionar;
        public static bool Modo_Despliegue_Logo_Base;
        public static bool Modo_Despliegue_Solo_Divisa;
        public static DateTime FechaUltimoBoletinDescargado;
    }

}