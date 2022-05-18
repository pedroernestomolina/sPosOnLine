using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.AdministradorDoc.Lista
{
    
    public class Gestion
    {


        private List<data> _l;
        private BindingList<data> _bl;
        private BindingSource _bs;
        private data _docAplicarNotaCredito;
        private data _docAplicaParaAnulacion;
        private bool _isTickeraOk;
        private Helpers.Imprimir.IDocumento _imprimirDoc;
        private Visualizar.Gestion _gestionVer;


        public string TotItems { get { return _bs.Count.ToString().Trim(); } }
        public data DocAplicarNotaCredito { get { return _docAplicarNotaCredito; } }
        public data DocAplicaParaAulacion { get { return _docAplicaParaAnulacion; } }
        public BindingSource Source { get { return _bs; } }
        public bool IsTickeraOk { get { return _isTickeraOk; } }
        public Helpers.Imprimir.IDocumento ImprimirDoc { get { return _imprimirDoc; } }


        public Gestion()
        {
            _isTickeraOk=false;
            _imprimirDoc = null;
            _docAplicarNotaCredito = null;
            _docAplicaParaAnulacion = null;
            _l= new List<data>();
            _bl = new BindingList<data>(_l);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa() 
        {
            _isTickeraOk = false;
            _imprimirDoc = null;
            _docAplicarNotaCredito = null;
            _docAplicaParaAnulacion = null;
        }

        public void BajarItem()
        {
            _bs.Position += 1;
        }

        public void SubirItem()
        {
            _bs.Position -= 1;
        }

        public void setData(List<OOB.Documento.Lista.Ficha> list)
        {
            _bl.Clear();
            foreach (var it in list.OrderByDescending(o=>o.FechaEmision.Date).ThenByDescending(o=>o.HoraEmision).ThenByDescending(o=>o.DocNumero).ToList()) 
            {
                _bl.Add(new data(it));
            }
        }

        public bool AplicaParaNotaCredito()
        {
            var rt = false;
            if (_bs.Current != null)
            {
                var it = (data)_bs.Current;
                if (it.DocTipo == data.enumTipoDoc.Factura)
                {
                    if (!it.IsAnulado)
                    {
                        _docAplicarNotaCredito = it;
                        return true;
                    }
                    else 
                    {
                        Helpers.Msg.Error("A DOCUMENTO ANULADO NO SE PUEDE APLICAR NOTA DE CREDITO");
                    }
                }
                else 
                {
                    Helpers.Msg.Error("NO SE PUEDE APLICAR NOTA DE CREDITO A ESTE TIPO DE DOCUMENTO");
                }
            }

            return rt;
        }

        public bool AplicaParaAnular()
        {
            var rt = false;
            if (_bs.Current != null)
            {
                var it = (data)_bs.Current;
                if (!it.IsAnulado)
                {
                    _docAplicaParaAnulacion = it;
                    return true;
                }
                else 
                {
                    Helpers.Msg.Error("Documento Se Encuentra Ya Anulado");
                    return false;
                }
            }

            return rt;
        }

        public void setAnularDoc()
        {
            if (_bs.Current != null)
            {
                var it = (data)_bs.Current;
                it.setAnularDoc();
            }
            _bs.CurrencyManager.Refresh();
        }

        public void ImprimirDocumento()
        {
            _isTickeraOk = false;
            if (_bs.Current != null)
            {
                var it = (data)_bs.Current;
                var xr1 = Sistema.MyData.Documento_GetById(it.idDocumento);
                if (xr1.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(xr1.Mensaje);
                    return;
                }

                var xr2 = Sistema.MyData.Documento_Get_MetodosPago_ByIdRecibo(xr1.Entidad.AutoReciboCxC);
                if (xr2.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(xr2.Mensaje);
                    return;
                }

                var _cirif= Sistema.DatosEmpresa.CiRif;
                if (Sistema.DatosNegociTicket_Rif.Trim() != "")
                    _cirif = Sistema.DatosNegociTicket_Rif.Trim();
                var _nombre = Sistema.DatosEmpresa.Nombre;
                if (Sistema.DatosNegociTicket_Nombre.Trim() != "")
                    _nombre= Sistema.DatosNegociTicket_Nombre.Trim();
                var _direccion= Sistema.DatosEmpresa.Direccion;
                if (Sistema.DatosNegociTicket_Direccion.Trim() != "")
                    _direccion = Sistema.DatosNegociTicket_Direccion.Trim();

                var xdata = new Helpers.Imprimir.data();
                xdata.negocio = new Helpers.Imprimir.data.Negocio()
                {
                    CiRif = _cirif,
                    Nombre = _nombre,
                    Direccion = _direccion,
                    Telefonos = Sistema.DatosEmpresa.Telefono,
                };
                var docNombre = "";
                switch (xr1.Entidad.Tipo.Trim().ToUpper())
                {
                    case "01":
                        docNombre = "COPIA FACTURA";
                        break;
                    case "02":
                        docNombre = "COPIA NOTA DE DEBITO";
                        break;
                    case "03":
                        docNombre = "COPIA NOTA DE CREDITO";
                        break;
                    case "04":
                        docNombre = "COPIA NOTA DE ENTREGA";
                        break;
                }
                xdata.encabezado = new Helpers.Imprimir.data.Encabezado()
                {
                    CiRifCli = xr1.Entidad.CiRif,
                    DireccionCli = xr1.Entidad.DirFiscal,
                    DocumentoCondicionPago = xr1.Entidad.CondicionPago,
                    DocumentoControl = xr1.Entidad.Control,
                    DocumentoDiasCredito = xr1.Entidad.Dias,
                    DocumentoFecha = xr1.Entidad.Fecha,
                    DocumentoFechaVencimiento = xr1.Entidad.FechaVencimiento,
                    DocumentoNombre = docNombre,
                    DocumentoNro = xr1.Entidad.DocumentoNro,
                    DocumentoSerie = xr1.Entidad.Serie,
                    DocumentoAplica = xr1.Entidad.Aplica,
                    NombreCli = xr1.Entidad.RazonSocial,
                    FactorCambio=xr1.Entidad.FactorCambio,
                    SubTotal=xr1.Entidad.SubTotal,
                    Descuento=xr1.Entidad.Descuento,
                    Total=xr1.Entidad.Total,
                    TotalDivisa=xr1.Entidad.MontoDivisa,
                    EstacionEquipo = xr1.Entidad.Estacion,
                    Usuario = xr1.Entidad.Usuario,
                    CambioDar = xr1.Entidad.Cambio,
                    DocumentoHora = xr1.Entidad.Hora,
                    TelefonoCli = xr1.Entidad.Telefono,
                    CodigoCli = xr1.Entidad.CodigoCliente,
                    DescuentoPorc = xr1.Entidad.Descuento1p,
                    Cargo = xr1.Entidad.Cargos,
                    CargoPorc = xr1.Entidad.Cargosp,
                };
                xdata.item = new List<Helpers.Imprimir.data.Item>();
                foreach (var rg in xr1.Entidad.items)
                {
                    var nr = new Helpers.Imprimir.data.Item()
                    {
                        NombrePrd = rg.Nombre,
                        CodigoPrd = rg.Codigo,
                        Cantidad = rg.Cantidad,
                        Contenido = rg.ContenidoEmpaque,
                        DepositoCodigo = rg.CodigoDeposito,
                        DepositoDesc = rg.Deposito,
                        Empaque = rg.Empaque,
                        Importe = rg.TotalNeto,
                        ImporteFull= rg.Total,
                        ImporteDivisa = rg.Total,
                        Precio = rg.PrecioItem,
                        PrecioDivisa = rg.PrecioItem,
                        TotalUnd=rg.CantidadUnd,
                        TasaIva=rg.Tasa,
                    };
                    xdata.item.Add(nr);
                }
                xdata.metodoPago = new List<Helpers.Imprimir.data.MetodoPago>();
                foreach (var mp in xr2.ListaD)
                {
                    if (mp.cntDivisa > 1)
                    {
                        var pag = new Helpers.Imprimir.data.MetodoPago() { descripcion = "Efectivo($"+mp.cntDivisa.ToString()+")", monto = mp.montoRecibido };
                        xdata.metodoPago.Add(pag);
                    }
                    else
                    {
                        var pag = new Helpers.Imprimir.data.MetodoPago() { descripcion = mp.descMedioPago, monto = mp.montoRecibido };
                        xdata.metodoPago.Add(pag);
                    }
                }

                switch (it.DocTipo)
                { 
                    case data.enumTipoDoc.Factura:
                        Sistema.ImprimirFactura.setData(xdata);
                        if (Sistema.ImprimirFactura.GetType() == typeof(Helpers.Imprimir.Tickera58.Documento))
                        {
                            _isTickeraOk = true;
                            _imprimirDoc = Sistema.ImprimirFactura;
                        }
                        else if (Sistema.ImprimirFactura.GetType() == typeof(Helpers.Imprimir.Tickera80.Documento))
                        {
                            _isTickeraOk = true;
                            _imprimirDoc = Sistema.ImprimirFactura;
                        }
                        else
                        {
                            Sistema.ImprimirFactura.ImprimirCopiaDoc();
                        }
                        break;
                    case data.enumTipoDoc.NotaCredito:
                        Sistema.ImprimirNotaCredito.setData(xdata);
                        if (Sistema.ImprimirNotaCredito.GetType() == typeof(Helpers.Imprimir.Tickera58.Documento))
                        {
                            _isTickeraOk = true;
                            _imprimirDoc = Sistema.ImprimirNotaCredito;
                        }
                        else if (Sistema.ImprimirNotaCredito.GetType() == typeof(Helpers.Imprimir.Tickera80.Documento))
                        {
                            _isTickeraOk = true;
                            _imprimirDoc = Sistema.ImprimirNotaCredito;
                        }
                        else
                        {
                            Sistema.ImprimirNotaCredito.ImprimirCopiaDoc();
                        }
                        break;
                    case data.enumTipoDoc.NotaEntrega:
                        Sistema.ImprimirNotaEntrega.setData(xdata);
                        if (Sistema.ImprimirNotaEntrega.GetType() == typeof(Helpers.Imprimir.Tickera58.Documento))
                        {
                            _isTickeraOk = true;
                            _imprimirDoc = Sistema.ImprimirNotaEntrega;
                        }
                        else if (Sistema.ImprimirNotaEntrega.GetType() == typeof(Helpers.Imprimir.Tickera80.Documento))
                        {
                            _isTickeraOk = true;
                            _imprimirDoc = Sistema.ImprimirNotaEntrega;
                        }
                        else
                        {
                            Sistema.ImprimirNotaEntrega.ImprimirCopiaDoc();
                        }
                        break;
                }
            }
        }

        public void VisualizarDocumento()
        {
            if (_bs != null)
            {
                if (_bs.Current != null)
                {
                    var item = (data)_bs.Current;
                    _gestionVer.Inicializa();
                    _gestionVer.setDocumento(item);
                    _gestionVer.Inicia();
                }
            }
        }

        public void setVisualizar(Visualizar.Gestion _gestionVisualizar)
        {
            _gestionVer = _gestionVisualizar;
        }

    }

}