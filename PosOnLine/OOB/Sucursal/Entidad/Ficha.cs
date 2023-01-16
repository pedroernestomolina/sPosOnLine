using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Sucursal.Entidad
{
    public class Ficha
    {
        public enum enumModoVenta { sinDefinir = -1, Detal = 1, Mayor };
        public string id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string nombreGrupo { get; set; }
        public int idPrecioManejar { get; set; }
        public string estatusVentaMayor { get; set; }
        public string estatusVentaCredito { get; set; }
        public string estatus { get; set; }
        public string autoDepositoPrincipal { get; set; }
        public string habilitaVentaSurtidoPos { get; set; }
        public string habilitaVueltoDivisaPos { get; set; }
        public string habilitaModGastoPos { get; set; }
        public string modoVentaPos { get; set; }
        public bool HabilitarVentaCredito { get { return estatusVentaCredito.Trim() == "1"; } }
        public bool HabilitarVentaMayor { get { return estatusVentaMayor.Trim() == "1"; } }
        public bool isActivo { get { return estatus.Trim().ToUpper() == "1"; } }
        public bool isVentaSurtidoHabilitado { get { return habilitaVentaSurtidoPos.Trim().ToUpper() == "1"; } }
        public bool isVueltoDivisaHabilitado { get { return habilitaVueltoDivisaPos.Trim().ToUpper() == "1"; } }
        public bool isModGastoHabilitado { get { return habilitaModGastoPos.Trim().ToUpper() == "1"; } }
        public enumModoVenta TipoVentaPos 
        { 
            get 
            { 
                switch (modoVentaPos.Trim().ToUpper())
                {
                    case "D":
                        return enumModoVenta.Detal;
                    case "M":
                        return enumModoVenta.Mayor;
                    default:
                        return enumModoVenta.Detal;
                }
            } 
        }


        public Ficha()
        {
            id = "";
            idPrecioManejar = -1;
            codigo = "";
            nombre = "";
            nombreGrupo = "";
            estatusVentaMayor = "";
            estatusVentaCredito = "";
            estatus = "";
            autoDepositoPrincipal = "";
            habilitaVentaSurtidoPos = "";
            habilitaVueltoDivisaPos = "";
            habilitaModGastoPos = "";
            modoVentaPos = "";
        }
    }
}