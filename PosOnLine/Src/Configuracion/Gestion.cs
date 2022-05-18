using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Configuracion
{
    
    public class Gestion
    {

        private data _cnf;
        private bool _configuracionIsOk;
        private OOB.Configuracion.Entidad.Ficha _cnfActual;
        private List<OOB.Sistema.MedioPago.Entidad.Ficha> LMedioEfectivo;
        private List<OOB.Sistema.MedioPago.Entidad.Ficha> LMedioDivisa;
        private List<OOB.Sistema.MedioPago.Entidad.Ficha> LMedioElectronico;
        private List<OOB.Sistema.MedioPago.Entidad.Ficha> LMedioOtro;
        private List<OOB.Sistema.SerieFiscal.Entidad.Ficha> LSerieFactura;
        private List<OOB.Sistema.SerieFiscal.Entidad.Ficha> LSerieNotaCredito;
        private List<OOB.Sistema.SerieFiscal.Entidad.Ficha> LSerieNotaDebito;
        private List<OOB.Sistema.SerieFiscal.Entidad.Ficha> LSerieNotaEntrega;
        private List<OOB.Sistema.Transporte.Entidad.Ficha> LTransporte;
        private List<OOB.Concepto.Entidad.Ficha> LMovVenta;
        private List<OOB.Concepto.Entidad.Ficha> LMovDevVenta;
        private List<OOB.Concepto.Entidad.Ficha> LMovSalida;
        private List<OOB.Sistema.Cobrador.Entidad.Ficha> LCobrador;
        private List<OOB.Vendedor.Entidad.Ficha> LVendedor;
        private List<OOB.Sistema.TipoDocumento.Entidad.Ficha> LDocVenta;
        private List<OOB.Sistema.TipoDocumento.Entidad.Ficha> LDocNtCredito;
        private List<OOB.Sistema.TipoDocumento.Entidad.Ficha> LDocNtEntrega;
        private List<OOB.Deposito.Entidad.Ficha> LDeposito;
        private List<OOB.Sucursal.Entidad.Ficha> LSucursal;
        private List<OOB.Sistema.Clave.Ficha> LClave;
        private List<OOB.Sistema.ModoPrecio.Ficha> LModoPrecio;
        private List<OOB.Sistema.TarifaPrecio.Ficha> LTarifaPrecio;

        private BindingSource bs_MedioEfectivo;
        private BindingSource bs_MedioDivisa;
        private BindingSource bs_MedioElectronico;
        private BindingSource bs_MedioOtro;
        private BindingSource bs_SerieFactura;
        private BindingSource bs_SerieNotaCredito;
        private BindingSource bs_SerieNotaDebito;
        private BindingSource bs_SerieNotaEntrega;
        private BindingSource bs_MovVenta;
        private BindingSource bs_MovDevVenta;
        private BindingSource bs_MovSalida;
        private BindingSource bs_Sucursal;
        private BindingSource bs_Deposito;
        private BindingSource bs_Cobrador;
        private BindingSource bs_Vendedor;
        private BindingSource bs_Transporte;
        private BindingSource bs_DocVenta;
        private BindingSource bs_DocNtCredito;
        private BindingSource bs_DocNtEntrega;
        private BindingSource bs_Clave;
        private BindingSource bs_ModoPrecio;
        private BindingSource bs_TariaPrecio;


        public BindingSource _bs_MedioEfectivo { get { return bs_MedioEfectivo; } }
        public BindingSource _bs_MedioDivisa { get { return bs_MedioDivisa; } }
        public BindingSource _bs_MedioElectronico { get { return bs_MedioElectronico; } }
        public BindingSource _bs_MedioOtro { get { return bs_MedioOtro; } }
        public BindingSource _bs_Sucursal { get { return bs_Sucursal; } }
        public BindingSource _bs_Deposito { get { return bs_Deposito; } }
        public BindingSource _bs_Cobrador { get {return bs_Cobrador;} }
        public BindingSource _bs_Vendedor { get {return bs_Vendedor;} }
        public BindingSource _bs_Transporte { get {return bs_Transporte;} }
        public BindingSource _bs_SerieFactura { get {return bs_SerieFactura;} }
        public BindingSource _bs_SerieNotaCredito { get {return bs_SerieNotaCredito;} }
        public BindingSource _bs_SerieNotaDebito { get {return bs_SerieNotaDebito;} }
        public BindingSource _bs_SerieNotaEntrega { get {return bs_SerieNotaEntrega;} }
        public BindingSource _bs_MovVenta  { get {return bs_MovVenta ;} }
        public BindingSource _bs_MovDevVenta  { get {return bs_MovDevVenta ;} }
        public BindingSource _bs_MovSalida  { get {return bs_MovSalida ;} }
        public BindingSource _bs_DocVenta { get { return bs_DocVenta; } }
        public BindingSource _bs_DocNtCredito { get { return bs_DocNtCredito; } }
        public BindingSource _bs_DocNtEntrega { get { return bs_DocNtEntrega; } }
        public BindingSource _bs_Clave{ get { return bs_Clave; } }
        public BindingSource _bs_ModoPrecio { get { return bs_ModoPrecio; } }
        public BindingSource _bs_TarifaPrecio { get { return bs_TariaPrecio; } }


        public string AutoMedioEfectivo { get { return _cnfActual.idMedioPagoEfectivo; } }
        public string AutoMedioDivisa { get { return _cnfActual.idMedioPagoDivisa; } }
        public string AutoMedioElectronico { get { return _cnfActual.idMedioPagoElectronico; } }
        public string AutoMedioOtro { get { return _cnfActual.idMedioPagoOtros; } }
        public string AutoSerieFactura { get { return _cnfActual.idSerieFactura; } }
        public string AutoSerieNotaCredito { get { return _cnfActual.idSerieNotaCredito; } }
        public string AutoSerieNotaDebito { get { return _cnfActual.idSerieNotaDebito; } }
        public string AutoSerieNotaEntrega { get { return _cnfActual.idSerieNotaEntrega; } }
        public string AutoSucursal { get { return _cnfActual.idSucursal; } }
        public string AutoDeposito { get { return _cnfActual.idDeposito; } }
        public string AutoCobrador { get { return _cnfActual.idCobrador; } }
        public string AutoVendedor { get { return _cnfActual.idVendedor; } }
        public string AutoTransporte { get { return _cnfActual.idTransporte; } }
        public string AutoConceptoVenta { get { return _cnfActual.idConceptoVenta; } }
        public string AutoConceptoNtCredito { get { return _cnfActual.idConceptoDevVenta; } }
        public string AutoConceptoNtEntrega { get { return _cnfActual.idConceptoSalida; } }
        public string AutoDocVenta { get { return _cnfActual.idTipoDocumentoVenta ; } }
        public string AutoDocNtCredito { get { return _cnfActual.idTipoDocumentoDevVenta; } }
        public string AutoDocNtEntrega { get { return _cnfActual.idTipoDocumentoNotaEntrega; } }
        public string CodigoSucursal { get { return _cnf.Sucursal != null ? _cnf.Sucursal.codigo : ""; } }
        public string IdEquipo { get { return Sistema.IdEquipo; } }
        public bool ActivarBusquedaPorDescripcion { get { return _cnfActual.BusquedaPorDescripcion_Activa; } }
        public bool ValidarExistencia { get { return _cnfActual.ValidarExistencia_Activa; } }
        public string AutoModoPrecio { get { return _cnfActual.modoPrecio; } }
        public object AutoTarifaPrecio { get { return _cnfActual.idPrecioManejar; } }
        public string AutoClavePos { get { return _cnfActual.idClaveUsar; } }
        public bool ActivarRepesaje { get { return _cnfActual.Repesaje_Activa; } }
        public decimal LimiteInferiorRepesaje { get { return _cnfActual.limiteInferiorRepesaje ; } } 
        public decimal LimiteSuperiorRepesaje { get { return _cnfActual.limiteSuperiorRepesaje; } }
        public bool ConfiguracionIsOk { get { return _configuracionIsOk; } }
        public bool Habilitar_Tarifa_Precio 
        { 
            get 
            {
                if (_cnf.ModoPrecio != null)
                {
                    return _cnf.ModoPrecio.id == "2" ? true : false;
                }
                else
                    return false;
            } 
        }


        public Gestion()
        {
            _cnf = new data();
            _configuracionIsOk = false;
            LMedioEfectivo = new List<OOB.Sistema.MedioPago.Entidad.Ficha>();
            LMedioDivisa = new List<OOB.Sistema.MedioPago.Entidad.Ficha>();
            LMedioElectronico = new List<OOB.Sistema.MedioPago.Entidad.Ficha>();
            LMedioOtro = new List<OOB.Sistema.MedioPago.Entidad.Ficha>();
            LSerieFactura = new List<OOB.Sistema.SerieFiscal.Entidad.Ficha>();
            LSerieNotaCredito = new List<OOB.Sistema.SerieFiscal.Entidad.Ficha>();
            LSerieNotaDebito = new List<OOB.Sistema.SerieFiscal.Entidad.Ficha>();
            LSerieNotaEntrega = new List<OOB.Sistema.SerieFiscal.Entidad.Ficha>();
            LTransporte = new List<OOB.Sistema.Transporte.Entidad.Ficha>();
            LMovVenta = new List<OOB.Concepto.Entidad.Ficha>();
            LMovDevVenta = new List<OOB.Concepto.Entidad.Ficha>();
            LMovSalida = new List<OOB.Concepto.Entidad.Ficha>();
            LVendedor = new List<OOB.Vendedor.Entidad.Ficha>();
            LCobrador = new List<OOB.Sistema.Cobrador.Entidad.Ficha>();
            LDocVenta = new List<OOB.Sistema.TipoDocumento.Entidad.Ficha>();
            LDocNtCredito = new List<OOB.Sistema.TipoDocumento.Entidad.Ficha>();
            LDocNtEntrega = new List<OOB.Sistema.TipoDocumento.Entidad.Ficha>();
            LSucursal = new List<OOB.Sucursal.Entidad.Ficha>();
            LDeposito = new List<OOB.Deposito.Entidad.Ficha>();
            LClave = new List<OOB.Sistema.Clave.Ficha>();
            LModoPrecio = new List<OOB.Sistema.ModoPrecio.Ficha>();
            LTarifaPrecio = new List<OOB.Sistema.TarifaPrecio.Ficha>();

            bs_MedioEfectivo = new BindingSource();
            bs_MedioDivisa = new BindingSource();
            bs_MedioElectronico = new BindingSource();
            bs_MedioOtro = new BindingSource();
            bs_SerieFactura = new BindingSource();
            bs_SerieNotaCredito = new BindingSource();
            bs_SerieNotaDebito = new BindingSource();
            bs_SerieNotaEntrega = new BindingSource();
            bs_Transporte = new BindingSource();
            bs_MovVenta = new BindingSource();
            bs_MovDevVenta = new BindingSource();
            bs_MovSalida = new BindingSource();
            bs_Cobrador = new BindingSource();
            bs_Vendedor = new BindingSource();
            bs_Sucursal= new BindingSource();
            bs_Deposito = new BindingSource();
            bs_DocVenta = new BindingSource();
            bs_DocNtCredito = new BindingSource();
            bs_DocNtEntrega = new BindingSource();
            bs_Clave = new BindingSource();
            bs_ModoPrecio = new BindingSource();
            bs_TariaPrecio = new BindingSource();
            
            bs_MedioEfectivo.DataSource = LMedioEfectivo;
            bs_MedioDivisa.DataSource = LMedioDivisa;
            bs_MedioElectronico.DataSource = LMedioElectronico;
            bs_MedioOtro.DataSource = LMedioOtro;
            bs_SerieFactura.DataSource = LSerieFactura;
            bs_SerieNotaCredito.DataSource = LSerieNotaCredito;
            bs_SerieNotaDebito.DataSource = LSerieNotaDebito;
            bs_SerieNotaEntrega.DataSource = LSerieNotaEntrega;
            bs_Transporte.DataSource = LTransporte;
            bs_MovVenta.DataSource = LMovVenta;
            bs_MovDevVenta.DataSource = LMovDevVenta;
            bs_MovSalida.DataSource = LMovSalida;
            bs_Cobrador.DataSource = LCobrador;
            bs_Vendedor.DataSource = LVendedor;
            bs_DocVenta.DataSource = LDocVenta;
            bs_DocNtCredito.DataSource = LDocNtCredito;
            bs_DocNtEntrega.DataSource = LDocNtEntrega;
            bs_Sucursal.DataSource = LSucursal;
            bs_Deposito.DataSource = LDeposito;
            bs_Clave.DataSource = LClave;
            bs_ModoPrecio.DataSource = LModoPrecio;
            bs_TariaPrecio.DataSource = LTarifaPrecio;
        }


        public bool CargarData()
        {
            var rt = false;

            var r01 = Sistema.MyData.Configuracion_Pos_GetFicha();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError )
            {
                Helpers.Msg.Error(r01.Mensaje);
                return rt;
            }
            _cnfActual = r01.Entidad;
            _cnfActual.setSucursal(Sistema.Sucursal.id);
            _cnfActual.setDeposito(Sistema.Deposito.id);

            var filtro = new OOB.Sistema.MedioPago.Lista.Filtro();
            var r02 = Sistema.MyData.Sistema_MedioPago_GetLista(filtro);
            if (r02.Result ==  OOB.Resultado.Enumerados.EnumResult.isError )
            {
                Helpers.Msg.Error(r02.Mensaje);
                return rt;
            }
            LMedioEfectivo.Clear();
            LMedioEfectivo.AddRange(r02.ListaD);
            LMedioEfectivo.FirstOrDefault(f => f.id == r01.Entidad.idMedioPagoEfectivo);

            LMedioDivisa.Clear();
            LMedioDivisa.AddRange(r02.ListaD);
            LMedioElectronico.Clear();
            LMedioElectronico.AddRange(r02.ListaD);
            LMedioOtro.Clear();
            LMedioOtro.AddRange(r02.ListaD);

            var r03 = Sistema.MyData.Sistema_Serie_GetLista();
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError )
            {
                Helpers.Msg.Error(r03.Mensaje);
                return rt;
            }
            LSerieFactura.Clear();
            LSerieFactura.AddRange(r03.ListaD);
            LSerieNotaDebito.Clear();
            LSerieNotaDebito.AddRange(r03.ListaD);
            LSerieNotaCredito.Clear();
            LSerieNotaCredito.AddRange(r03.ListaD);
            LSerieNotaEntrega.Clear();
            LSerieNotaEntrega.AddRange(r03.ListaD);

            var r04 = Sistema.MyData.Concepto_GetLista();
            if (r04.Result ==  OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return rt;
            }
            LMovVenta.Clear();
            LMovVenta.AddRange(r04.ListaD);
            LMovDevVenta.Clear();
            LMovDevVenta.AddRange(r04.ListaD);
            LMovSalida.Clear();
            LMovSalida.AddRange(r04.ListaD);

            var r05 = Sistema.MyData.Sistema_Transporte_GetLista();
            if (r05.Result ==  OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return rt;
            }
            LTransporte.Clear();
            LTransporte.AddRange(r05.ListaD);

            var r06 = Sistema.MyData.Sistema_Cobrador_GetLista();
            if (r06.Result ==  OOB.Resultado.Enumerados.EnumResult.isError )
            {
                Helpers.Msg.Error(r06.Mensaje);
                return rt;
            }
            LCobrador.Clear();
            LCobrador.AddRange(r06.ListaD);

            var r07 = Sistema.MyData.Vendedor_GetLista();
            if (r07.Result ==  OOB.Resultado.Enumerados.EnumResult.isError )
            {
                Helpers.Msg.Error(r07.Mensaje);
                return rt;
            }
            LVendedor.Clear();
            LVendedor.AddRange(r07.ListaD);

            var r08 = Sistema.MyData.Sistema_TipoDocumento_GetLista();
            if (r08.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r08.Mensaje);
                return rt;
            }
            LDocVenta.Clear();
            LDocVenta.AddRange(r08.ListaD);
            LDocNtCredito.Clear();
            LDocNtCredito.AddRange(r08.ListaD);
            LDocNtEntrega.Clear();
            LDocNtEntrega.AddRange(r08.ListaD);

            var r09 = Sistema.MyData.Sucursal_GetLista();
            if (r09.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r09.Mensaje);
                return rt;
            }
            LSucursal.Clear();
            LSucursal.AddRange(r09.ListaD.OrderBy(o=>o.nombre).ToList());

            LClave.Clear();
            LClave.Add(new OOB.Sistema.Clave.Ficha() { id = "1", nombre = "Máxima" });
            LClave.Add(new OOB.Sistema.Clave.Ficha() { id = "2", nombre = "Media" });
            LClave.Add(new OOB.Sistema.Clave.Ficha() { id = "3", nombre = "Minima" });

            LModoPrecio.Clear();
            LModoPrecio.Add(new OOB.Sistema.ModoPrecio.Ficha() { id = "1", nombre = "Por Tipo Negocio/Sucursal" });
            LModoPrecio.Add(new OOB.Sistema.ModoPrecio.Ficha() { id = "2", nombre = "Por Precio Fijo" });
            LModoPrecio.Add(new OOB.Sistema.ModoPrecio.Ficha() { id = "3", nombre = "Libre" });

            LTarifaPrecio.Clear();
            LTarifaPrecio.Add(new OOB.Sistema.TarifaPrecio.Ficha() { id = "1", nombre = "Precio 1" });
            LTarifaPrecio.Add(new OOB.Sistema.TarifaPrecio.Ficha() { id = "2", nombre = "Precio 2" });
            LTarifaPrecio.Add(new OOB.Sistema.TarifaPrecio.Ficha() { id = "3", nombre = "Precio 3" });
            LTarifaPrecio.Add(new OOB.Sistema.TarifaPrecio.Ficha() { id = "4", nombre = "Precio 4" });
            LTarifaPrecio.Add(new OOB.Sistema.TarifaPrecio.Ficha() { id = "5", nombre = "Precio 5" });

            //
            setSucursal(Sistema.Sucursal.id);
            setDeposito(Sistema.Deposito.id);
            
            return true;
        }

        public void Inicializa() 
        {
            _configuracionIsOk = false;
        }

        ConfigurarFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                frm = new Configuracion.ConfigurarFrm();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }

        public void setSucursal(string v)
        {
            LDeposito.Clear();
            var ent= LSucursal.FirstOrDefault(f=>f.id==v);
            _cnf.setSucursal(ent);
            if (ent!=null) 
            {
                var filtro = new OOB.Deposito.Lista.Filtro() { PorCodigoSuc = ent.codigo, };
                var r01 = Sistema.MyData.Deposito_GetLista(filtro);;
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                LDeposito.AddRange(r01.ListaD);
            }
            _bs_Deposito.CurrencyManager.Refresh();
        }

        public void setDeposito(string v)
        {
            var ent = LDeposito.FirstOrDefault(f => f.id == v);
            _cnf.setDeposito(ent);
        }

        public void setCobrador(string v)
        {
            var ent = LCobrador.FirstOrDefault(f => f.id == v);
            _cnf.setCobrador(ent);
        }

        public void setVendedor(string v)
        {
            var ent = LVendedor.FirstOrDefault(f => f.id == v);
            _cnf.setVendedor(ent);
        }

        public void setTransporte(string v)
        {
            var ent = LTransporte.FirstOrDefault(f => f.id == v);
            _cnf.setTransporte(ent);
        }

        public void setConceptoVenta(string v)
        {
            var ent = LMovVenta.FirstOrDefault(f => f.id == v);
            _cnf.setConceptoVenta(ent);
        }

        public void setConceptoNtCredito(string v)
        {
            var ent = LMovDevVenta.FirstOrDefault(f => f.id == v);
            _cnf.setConceptoNtCredito(ent);
        }

        public void setConceptoNtEntrega(string v)
        {
            var ent = LMovSalida.FirstOrDefault(f => f.id == v);
            _cnf.setConceptoNtEntrega(ent);
        }

        public void setDocVenta(string v)
        {
            var ent = LDocVenta.FirstOrDefault(f => f.autoId == v);
            _cnf.setDocVenta(ent);
        }

        public void setDocNtCredito(string v)
        {
            var ent = LDocNtCredito.FirstOrDefault(f => f.autoId == v);
            _cnf.setDocNtCredito(ent);
        }

        public void setDocNtEntrega(string v)
        {
            var ent = LDocNtEntrega.FirstOrDefault(f => f.autoId == v);
            _cnf.setDocNtEntrega(ent);
        }

        public void setMedioPagoEfectivo(string v)
        {
            var ent = LMedioEfectivo.FirstOrDefault(f => f.id == v);
            _cnf.setMedioPagoEfectivo(ent);
        }

        public void setMedioPagoDivisa(string v)
        {
            var ent = LMedioDivisa.FirstOrDefault(f => f.id == v);
            _cnf.setMedioPagoDivisa(ent);
        }

        public void setMedioPagoElectronico(string v)
        {
            var ent = LMedioElectronico.FirstOrDefault(f => f.id == v);
            _cnf.setMedioPagoElectronico(ent);
        }

        public void setMedioPagoOtro(string v)
        {
            var ent = LMedioOtro.FirstOrDefault(f => f.id == v);
            _cnf.setMedioPagoOtro(ent);
        }

        public void setSerieFactura(string v)
        {
            var ent = LSerieFactura .FirstOrDefault(f => f.Auto == v);
            _cnf.setSerieFactura(ent);
        }

        public void setSerieNtCredito(string v)
        {
            var ent = LSerieNotaCredito.FirstOrDefault(f => f.Auto == v);
            _cnf.setSerieNtCredito(ent);
        }

        public void setSerieNtDebito(string v)
        {
            var ent = LSerieNotaDebito.FirstOrDefault(f => f.Auto == v);
            _cnf.setSerieNtDebito(ent);
        }

        public void setSerieNtEntrega(string v)
        {
            var ent = LSerieNotaEntrega.FirstOrDefault(f => f.Auto == v);
            _cnf.setSerieNtEntrega(ent);
        }

        public void setClave(string v)
        {
            var ent = LClave.FirstOrDefault(f => f.id == v);
            _cnf.setClave(ent);
        }

        public void setValidarExistencia(bool p)
        {
            _cnf.setValidarExistencia(p);
        }

        public void setActivarBusquedaPorDescripcion(bool p)
        {
            _cnf.setActivarBusquedaPorDescripcion(p);
        }

        public void setActivarRepesaje(bool p)
        {
            _cnf.setActivarRepesaje(p);
        }
             
        public void setLimiteSuperior(decimal v)
        {
            _cnf.setLimiteSuperior(v);
        }

        public void setLimiteInferior(decimal v)
        {
            _cnf.setLimiteInferior(v);
        }

        public void setModoPrecio(string v)
        {
            var ent = LModoPrecio.FirstOrDefault(f => f.id == v);
            _cnf.setModoPrecio(ent);
        }

        public void setTarifaPrecio(string v)
        {
            var ent = LTarifaPrecio.FirstOrDefault(f => f.id == v);
            _cnf.setTarifaPrecio(ent);
        }

        public void Procesar()
        {
            if (!Helpers.PassWord.PassWIsOk(""))
            {
                return;
            }

            _configuracionIsOk = false;
            if (_cnf.ValidarIsOk())
            {
                var msg = MessageBox.Show("Guardar Configuración ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes) 
                {
                    var ficha = new OOB.Configuracion.Actualizar.Ficha()
                    {
                        activarBusquedaPorDescripcion = _cnf.ActivarBusquedaPorDescripcion ? "S" : "N",
                        activarRepesaje = _cnf.ActivarRepesaje ? "S" : "N",
                        idClaveUsar = _cnf.Clave.id,
                        idCobrador = _cnf.Cobrador.id,
                        idConceptoDevVenta = _cnf.ConceptoNtCredito.id,
                        idConceptoSalida = _cnf.ConceptoNtEntrega.id,
                        idConceptoVenta = _cnf.ConceptoVenta.id,
                        idDeposito = _cnf.Deposito.id,
                        idFacturaSerie = "",
                        idMedioPagoDivisa = _cnf.MedioPagoDivisa.id,
                        idMedioPagoEfectivo = _cnf.MedioPagoEfectivo.id,
                        idMedioPagoElectronico = _cnf.MedioPagoElectronico.id,
                        idMedioPagoOtros = _cnf.MedioPagoOtro.id,
                        idNotaCreditoSerie = "",
                        idNotaDebitoSerie = "",
                        idNotaEntregaSerie = "",
                        idSucursal = _cnf.Sucursal.id,
                        idTipoDocDevVenta = _cnf.DocNtCredito.autoId,
                        idTipoDocNotaEntrega = _cnf.DocNtEntrega.autoId,
                        idTipoDocVenta = _cnf.DocVenta.autoId,
                        idTransporte = _cnf.Transporte.id,
                        idVendedor = _cnf.Vendedor.id,
                        limiteInferiorRepesaje = _cnf.LimiteInfRepesaje,
                        limiteSuperiorRepesaje = _cnf.LimiteSupRepesaje,
                        modoPrecio = _cnf.ModoPrecio.id,
                        idPrecioManejar = _cnf.TarifaPrecio!=null?_cnf.TarifaPrecio.id:"",
                        validarExistencia = _cnf.ValidarExistencia ? "S" : "N",
                    };
                    var r01 = Sistema.MyData.Configuracion_Pos_Actualizar(ficha);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _configuracionIsOk = true;
                }
            }
        }

    }

}