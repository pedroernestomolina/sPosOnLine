using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Configuracion.Entidad
{
    
    public class Ficha
    {

        public string idSucursal { get; set; }
        public string idDeposito { get; set; }
        public string idVendedor { get; set; }
        public string idCobrador { get; set; }
        public string idTransporte { get; set; }
        public string idMedioPagoEfectivo { get; set; }
        public string idMedioPagoDivisa { get; set; }
        public string idMedioPagoElectronico { get; set; }
        public string idMedioPagoOtros { get; set; }
        public string idConceptoVenta { get; set; }
        public string idConceptoDevVenta { get; set; }
        public string idConceptoSalida { get; set; }
        public string idTipoDocumentoVenta { get; set; }
        public string idTipoDocumentoDevVenta { get; set; }
        public string idTipoDocumentoNotaEntrega { get; set; }
        public string idSerieFactura { get; set; }
        public string idSerieNotaCredito { get; set; }
        public string idSerieNotaEntrega { get; set; }
        public string idSerieNotaDebito { get; set; }
        public string idClaveUsar { get; set; }
        public string idPrecioManejar { get; set; }
        public string validarExistencia { get; set; }
        public string activarBusquedaPorDescripcion { get; set; }
        public string activarReepsaje { get; set; }
        public decimal limiteInferiorRepesaje { get; set; }
        public decimal limiteSuperiorRepesaje { get; set; }
        public string modoPrecio { get; set; }
        public string estatus { get; set; }


        public bool ValidarExistencia_Activa 
        { 
            get 
            { 
                var rt = validarExistencia.Trim().ToUpper() == "S";
                return rt;
            } 
        }

        public bool BusquedaPorDescripcion_Activa 
        {
            get
            {
                var rt = activarBusquedaPorDescripcion.Trim().ToUpper() == "S";
                return rt;
            }
        }

        public bool Repesaje_Activa
        {
            get
            {
                var rt = activarReepsaje.Trim().ToUpper() == "S";
                return rt;
            }
        }

        public bool Estatus_Activa
        {
            get
            {
                var rt = estatus.Trim().ToUpper() == "1";
                return rt;
            }
        }

        public Enumerados.enumModoPrecio EnumModoPrecio
        {
            get 
            {
                var rt = Enumerados.enumModoPrecio.SinDefinir;
                switch (modoPrecio.Trim().ToUpper()) 
                {
                    case "1":
                        rt = Enumerados.enumModoPrecio.PorTipoNegocio;
                        break;
                    case "2":
                        rt = Enumerados.enumModoPrecio.PorPrecioFijo;
                        break;
                    case "3":
                        rt = Enumerados.enumModoPrecio.Libre;
                        break;
                }
                return rt;
            }
        }


        public Ficha()
        {
            idSucursal = "";
            idDeposito = "";
            idVendedor = "";
            idCobrador = "";
            idTransporte = "";
            idMedioPagoDivisa = "";
            idMedioPagoEfectivo = "";
            idMedioPagoElectronico = "";
            idMedioPagoOtros = "";
            idConceptoDevVenta = "";
            idConceptoSalida = "";
            idConceptoVenta = "";
            idTipoDocumentoVenta = "";
            idTipoDocumentoDevVenta = "";
            idTipoDocumentoNotaEntrega = "";
            idSerieFactura = "";
            idSerieNotaCredito = "";
            idSerieNotaEntrega = "";
            idSerieNotaDebito = "";
            //
            validarExistencia = "";
            idClaveUsar = "";
            idPrecioManejar = "";
            activarBusquedaPorDescripcion = "";
            activarReepsaje = "";
            limiteInferiorRepesaje = 0.0m;
            limiteSuperiorRepesaje = 0.0m;
            //
            estatus = "";
            modoPrecio = "";
        }

        public void setSucursal(string p)
        {
            idSucursal = p;
        }

        public void setDeposito(string p)
        {
            idDeposito = p;
        }

    }

}