using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Configuracion
{
    
    public class data
    {

        private OOB.Sucursal.Entidad.Ficha _sucursal;
        private OOB.Deposito.Entidad.Ficha _deposito;
        private OOB.Sistema.Cobrador.Entidad.Ficha _cobrador;
        private OOB.Vendedor.Entidad.Ficha _vendedor;
        private OOB.Sistema.Transporte.Entidad.Ficha _transporte;
        private OOB.Concepto.Entidad.Ficha _conceptoNtEntrega;
        private OOB.Concepto.Entidad.Ficha _conceptoNtCredito;
        private OOB.Concepto.Entidad.Ficha _conceptoVenta;
        private OOB.Sistema.TipoDocumento.Entidad.Ficha _docVenta;
        private OOB.Sistema.TipoDocumento.Entidad.Ficha _docNtCredito;
        private OOB.Sistema.TipoDocumento.Entidad.Ficha _docNtEntrega;
        private OOB.Sistema.MedioPago.Entidad.Ficha _medioPagoEfectivo;
        private OOB.Sistema.MedioPago.Entidad.Ficha _medioPagoDivisa;
        private OOB.Sistema.MedioPago.Entidad.Ficha _medioPagoElectronico;
        private OOB.Sistema.MedioPago.Entidad.Ficha _medioPagoOtro;
        private OOB.Sistema.SerieFiscal.Entidad.Ficha _serieFactura;
        private OOB.Sistema.SerieFiscal.Entidad.Ficha _serieNtCredito;
        private OOB.Sistema.SerieFiscal.Entidad.Ficha _serieNtDebito;
        private OOB.Sistema.SerieFiscal.Entidad.Ficha _serieNtEntrega;
        private OOB.Sistema.Clave.Ficha _clave;
        private OOB.Sistema.ModoPrecio.Ficha _modoPrecio;
        private OOB.Sistema.TarifaPrecio.Ficha _tarifaPrecio;
        private bool _activarRepesaje;
        private bool _activarBusquedaPorDescripcion;
        private bool _validarExistencia;
        private decimal _limiteSupRepesaje;
        private decimal _limiteInfRepesaje;


        public bool ActivarRepesaje { get { return _activarRepesaje; } }
        public bool ActivarBusquedaPorDescripcion { get { return _activarBusquedaPorDescripcion; } }
        public bool ValidarExistencia { get { return _validarExistencia; } }
        public decimal LimiteSupRepesaje { get { return _limiteSupRepesaje; } }
        public decimal LimiteInfRepesaje { get { return _limiteInfRepesaje; } }
        public OOB.Sucursal.Entidad.Ficha Sucursal { get { return _sucursal; } }
        public OOB.Deposito.Entidad.Ficha Deposito { get { return _deposito; } }
        public OOB.Sistema.Cobrador.Entidad.Ficha Cobrador { get { return _cobrador; } }
        public OOB.Vendedor.Entidad.Ficha Vendedor { get { return _vendedor; } }
        public OOB.Sistema.Transporte.Entidad.Ficha Transporte { get { return _transporte; } }
        public OOB.Concepto.Entidad.Ficha ConceptoNtEntrega { get { return _conceptoNtEntrega; } }
        public OOB.Concepto.Entidad.Ficha ConceptoNtCredito { get { return _conceptoNtCredito; } }
        public OOB.Concepto.Entidad.Ficha ConceptoVenta { get { return _conceptoVenta; } }
        public OOB.Sistema.TipoDocumento.Entidad.Ficha DocVenta { get { return _docVenta; } }
        public OOB.Sistema.TipoDocumento.Entidad.Ficha DocNtCredito { get { return _docNtCredito; } }
        public OOB.Sistema.TipoDocumento.Entidad.Ficha DocNtEntrega { get { return _docNtEntrega; } }
        public OOB.Sistema.MedioPago.Entidad.Ficha MedioPagoEfectivo { get { return _medioPagoEfectivo; } }
        public OOB.Sistema.MedioPago.Entidad.Ficha MedioPagoDivisa { get { return _medioPagoDivisa; } }
        public OOB.Sistema.MedioPago.Entidad.Ficha MedioPagoElectronico { get { return _medioPagoElectronico; } }
        public OOB.Sistema.MedioPago.Entidad.Ficha MedioPagoOtro { get { return _medioPagoOtro; } }
        public OOB.Sistema.SerieFiscal.Entidad.Ficha SerieFactura { get { return _serieFactura; } }
        public OOB.Sistema.SerieFiscal.Entidad.Ficha SerieNtCredito { get { return _serieNtCredito; } }
        public OOB.Sistema.SerieFiscal.Entidad.Ficha SerieNtDebito { get { return _serieNtDebito; } }
        public OOB.Sistema.SerieFiscal.Entidad.Ficha SerieNtEntrega { get { return _serieNtEntrega; } }
        public OOB.Sistema.Clave.Ficha Clave { get { return _clave; } }
        public OOB.Sistema.ModoPrecio.Ficha ModoPrecio { get { return _modoPrecio; } }
        public OOB.Sistema.TarifaPrecio.Ficha TarifaPrecio { get { return _tarifaPrecio; } }


        public data()
        {
            Limpiar();
        }

        private void Limpiar()
        {
        }


        public void setSucursal(OOB.Sucursal.Entidad.Ficha ent)
        {
            _sucursal = ent;
        }

        public void setDeposito(OOB.Deposito.Entidad.Ficha ent)
        {
            _deposito = ent;
        }

        public void setCobrador(OOB.Sistema.Cobrador.Entidad.Ficha ent)
        {
            _cobrador = ent;
        }

        public void setVendedor(OOB.Vendedor.Entidad.Ficha ent)
        {
            _vendedor = ent;
        }

        public void setTransporte(OOB.Sistema.Transporte.Entidad.Ficha ent)
        {
            _transporte = ent;
        }

        public void setConceptoNtEntrega(OOB.Concepto.Entidad.Ficha ent)
        {
            _conceptoNtEntrega = ent;
        }

        public void setConceptoNtCredito(OOB.Concepto.Entidad.Ficha ent)
        {
            _conceptoNtCredito= ent;
        }

        public void setConceptoVenta(OOB.Concepto.Entidad.Ficha ent)
        {
            _conceptoVenta= ent;
        }

        public void setDocVenta(OOB.Sistema.TipoDocumento.Entidad.Ficha ent)
        {
            _docVenta = ent;
        }

        public void setDocNtCredito(OOB.Sistema.TipoDocumento.Entidad.Ficha ent)
        {
            _docNtCredito= ent;
        }

        public void setDocNtEntrega(OOB.Sistema.TipoDocumento.Entidad.Ficha ent)
        {
            _docNtEntrega= ent;
        }

        public void setMedioPagoEfectivo(OOB.Sistema.MedioPago.Entidad.Ficha ent)
        {
            _medioPagoEfectivo = ent;
        }

        public void setMedioPagoDivisa(OOB.Sistema.MedioPago.Entidad.Ficha ent)
        {
            _medioPagoDivisa= ent;
        }

        public void setMedioPagoElectronico(OOB.Sistema.MedioPago.Entidad.Ficha ent)
        {
            _medioPagoElectronico= ent;
        }

        public void setMedioPagoOtro(OOB.Sistema.MedioPago.Entidad.Ficha ent)
        {
            _medioPagoOtro= ent;
        }

        public void setSerieFactura(OOB.Sistema.SerieFiscal.Entidad.Ficha ent)
        {
            _serieFactura = ent;
        }

        public void setSerieNtCredito(OOB.Sistema.SerieFiscal.Entidad.Ficha ent)
        {
            _serieNtCredito= ent;
        }

        public void setSerieNtDebito(OOB.Sistema.SerieFiscal.Entidad.Ficha ent)
        {
            _serieNtDebito= ent;
        }

        public void setSerieNtEntrega(OOB.Sistema.SerieFiscal.Entidad.Ficha ent)
        {
            _serieNtEntrega= ent;
        }

        public void setClave(OOB.Sistema.Clave.Ficha ent)
        {
            _clave = ent;
        }

        public void setValidarExistencia(bool p)
        {
            _validarExistencia = p;
        }

        public void setActivarBusquedaPorDescripcion(bool p)
        {
            _activarBusquedaPorDescripcion = p;
        }

        public void setActivarRepesaje(bool p)
        {
            _activarRepesaje = p;
        }

        public bool ValidarIsOk()
        {
            var rt = true;

            if (_medioPagoEfectivo == null) 
            {
                Helpers.Msg.Error("Medio De Pago Efectivo No Puede Estar Vacio");
                return false;
            }
            if (_medioPagoDivisa  == null)
            {
                Helpers.Msg.Error("Medio De Pago Divisa No Puede Estar Vacio");
                return false;
            }
            if (_medioPagoElectronico== null)
            {
                Helpers.Msg.Error("Medio De Pago Electronico No Puede Estar Vacio");
                return false;
            }
            if (_medioPagoOtro == null)
            {
                Helpers.Msg.Error("Medio De Pago Otro No Puede Estar Vacio");
                return false;
            }

            if (_sucursal == null)
            {
                Helpers.Msg.Error("Sucursal No Puede Estar Vacio");
                return false;
            }
            if (_deposito== null)
            {
                Helpers.Msg.Error("Deposito No Puede Estar Vacio");
                return false;
            }
            if (_cobrador == null)
            {
                Helpers.Msg.Error("Cobrador No Puede Estar Vacio");
                return false;
            }
            if (_vendedor== null)
            {
                Helpers.Msg.Error("Vendedor No Puede Estar Vacio");
                return false;
            }
            if (_transporte== null)
            {
                Helpers.Msg.Error("Transporte No Puede Estar Vacio");
                return false;
            }
            if (_conceptoVenta == null)
            {
                Helpers.Msg.Error("Concepto Movimiento Venta No Puede Estar Vacio");
                return false;
            }
            if (_conceptoNtCredito == null)
            {
                Helpers.Msg.Error("Concepto Movimiento Nota de Credito No Puede Estar Vacio");
                return false;
            }
            if (_conceptoNtEntrega== null)
            {
                Helpers.Msg.Error("Concepto Movimiento Nota de Entrega No Puede Estar Vacio");
                return false;
            }
            if (_docVenta == null)
            {
                Helpers.Msg.Error("Tipo Documento De Venta No Puede Estar Vacio");
                return false;
            }
            if (_docNtCredito== null)
            {
                Helpers.Msg.Error("Tipo Documento De Nota de Credito No Puede Estar Vacio");
                return false;
            }
            if (_docNtEntrega== null)
            {
                Helpers.Msg.Error("Tipo Documento De Nota de Entrega No Puede Estar Vacio");
                return false;
            }

            //if (_serieFactura == null)
            //{
            //    Helpers.Msg.Error("Serie Factura No Puede Estar Vacio");
            //    return false;
            //}
            //if (_serieNtCredito == null)
            //{
            //    Helpers.Msg.Error("Serie Nota Credito No Puede Estar Vacio");
            //    return false;
            //}
            //if (_serieNtDebito== null)
            //{
            //    Helpers.Msg.Error("Serie Nota Debito No Puede Estar Vacio");
            //    return false;
            //}
            //if (_serieNtEntrega== null)
            //{
            //    Helpers.Msg.Error("Serie Nota Entrega No Puede Estar Vacio");
            //    return false;
            //}

            if (_modoPrecio == null)
            {
                Helpers.Msg.Error("Modo Precio POS No Puede Estar Vacio");
                return false;
            }

            if (_modoPrecio.id == "2") 
            {
                if (_tarifaPrecio == null) 
                {
                    Helpers.Msg.Error("Tarifa Precio POS No Puede Estar Vacio");
                    return false;
                }
            }

            if (_clave == null)
            {
                Helpers.Msg.Error("Modo Clave POS No Puede Estar Vacio");
                return false;
            }

            if (_activarRepesaje) 
            {
                if (_limiteInfRepesaje > _limiteSupRepesaje) 
                {
                    Helpers.Msg.Error("Limite Repesaje Incorrectos");
                    return false;
                }
            }

            return rt;
        }

        public bool ValidarSucursalDepositoIsOk()
        {
            var rt = true;

            if (_sucursal == null)
            {
                Helpers.Msg.Error("Sucursal No Puede Estar Vacio");
                return false;
            }
            if (_deposito == null)
            {
                Helpers.Msg.Error("Deposito No Puede Estar Vacio");
                return false;
            }

            return rt;
        }

        public void setLimiteSuperior(decimal v)
        {
            _limiteSupRepesaje = v;
        }

        public void setLimiteInferior(decimal v)
        {
            _limiteInfRepesaje = v;
        }

        public void setModoPrecio(OOB.Sistema.ModoPrecio.Ficha v)
        {
            _modoPrecio = v;
        }

        public void setTarifaPrecio(OOB.Sistema.TarifaPrecio.Ficha ent)
        {
            _tarifaPrecio = ent;
        }
    }

}