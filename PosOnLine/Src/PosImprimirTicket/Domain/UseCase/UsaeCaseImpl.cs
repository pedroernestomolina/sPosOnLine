using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PosImprimirTicket.Domain.UseCase
{
    public class UsaeCaseImpl: IUseCase
    {
        public Models.Data 
            CargarDataDocumento(string idDoc, string estatus="")
        {
            try
            {
                var xr0 = Sistema.MyData.Configuracion_MonedaLocal();
                //
                var xr1 = Sistema.MyData.Documento_GetById(idDoc);
                if (xr1.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(xr1.Mensaje);
                }
                //
                var xdata = new Models.Data();
                xdata.codigoDoc = xr1.Entidad.cuerpo.Tipo;
                xdata.isAnulado = xr1.Entidad.cuerpo.EstatusAnulado.Trim().ToUpper() == "1";
                xdata.negocio = new Models.Data.Negocio()
                {
                    Nombre = Sistema.DatosEmpresa.Nombre,
                    CiRif = Sistema.DatosEmpresa.CiRif,
                    Direccion = Sistema.DatosEmpresa.Direccion,
                    Telefonos = Sistema.DatosEmpresa.Telefono,
                };
                var docNombre = "";
                var _cuerpo = xr1.Entidad.cuerpo;
                switch (_cuerpo.Tipo.Trim().ToUpper())
                {
                    case "01":
                        docNombre = estatus+"FACTURA";
                        break;
                    case "02":
                        docNombre = estatus+"NOTA DE DEBITO";
                        break;
                    case "03":
                        docNombre = estatus+"NOTA DE CREDITO";
                        break;
                    case "04":
                        docNombre = estatus+"NOTA DE ENTREGA";
                        break;
                }
                xdata.encabezado = new Models.Data.Encabezado()
                {
                    CiRifCli = _cuerpo.CiRif,
                    DireccionCli = _cuerpo.DirFiscal,
                    DocumentoCondicionPago = _cuerpo.CondicionPago,
                    DocumentoControl = _cuerpo.Control,
                    DocumentoDiasCredito = _cuerpo.Dias,
                    DocumentoFecha = _cuerpo.Fecha,
                    DocumentoFechaVencimiento = _cuerpo.FechaVencimiento,
                    DocumentoNombre = docNombre,
                    DocumentoNro = _cuerpo.DocumentoNro,
                    DocumentoSerie = _cuerpo.Serie,
                    DocumentoAplica = _cuerpo.Aplica,
                    NombreCli = _cuerpo.RazonSocial,
                    FactorCambio = _cuerpo.FactorCambio,
                    SubTotal = _cuerpo.SubTotal,
                    Descuento = _cuerpo.Descuento,
                    Total = _cuerpo.Total,
                    TotalDivisa = _cuerpo.MontoDivisa,
                    EstacionEquipo = _cuerpo.Estacion,
                    Usuario = _cuerpo.Usuario,
                    CambioDar = _cuerpo.Cambio,
                    DocumentoHora = _cuerpo.Hora,
                    TelefonoCli = _cuerpo.Telefono,
                    CodigoCli = _cuerpo.CodigoCliente,
                    DescuentoPorc = _cuerpo.Descuento1p,
                    Cargo = _cuerpo.Cargos,
                    CargoPorc = _cuerpo.Cargosp,
                    VueltoEfectivo = _cuerpo.MontoPorVueltoEnEfectivo,
                    VueltoDivisa = _cuerpo.MontoPorVueltoEnDivisa,
                    VueltoPagoMovil = _cuerpo.MontoPorVueltoEnPagoMovil,
                    CntDivisaVueltoDivisa = _cuerpo.CantDivisaPorVueltoEnDivisa,
                    //
                    BonoPorPagoDivisa = _cuerpo.BonoPorPagoDivisa,
                    MontoBonoPorPagoDivisa = _cuerpo.MontoBonoPorPagoDivisa,
                    CntDivisaAplicaBonoPorPagoDivisa = _cuerpo.CntDivisaAplicaBonoPorPagoDivisa,
                    //
                    DocumentoAplica_Fecha = _cuerpo.Fecha,
                    DocumentoAplica_SerialFiscal = _cuerpo.Control,
                    //
                    AplicaIGTF = _cuerpo.aplicaIGTF,
                    MontoIGTF = _cuerpo.montoIGTF,
                    TasaIGTF = _cuerpo.tasaIGTF,
                    //
                    SaldoPendientDiv = _cuerpo.SaldoPendiente,
                    //
                };
                xdata.item = new List<Models.Data.Item>();
                foreach (var rg in xr1.Entidad.items.OrderBy(o=>o.Empaque).ToList())
                {
                    var nr = new Models.Data.Item()
                    {
                        NombrePrd = rg.Nombre,
                        CodigoPrd = rg.Codigo,
                        Cantidad = rg.Cantidad,
                        Contenido = rg.ContenidoEmpaque,
                        DepositoCodigo = rg.CodigoDeposito,
                        DepositoDesc = rg.Deposito,
                        Empaque = rg.Empaque,
                        Importe = rg.TotalNeto,
                        ImporteDivisa = rg.TotalNeto,
                        Precio = rg.PrecioItem,
                        PrecioDivisa = rg.PrecioItem,
                        TotalUnd = rg.CantidadUnd,
                        TasaIva = rg.Tasa,
                        ImporteFull = rg.Total,
                    };
                    xdata.item.Add(nr);
                }
                xdata.metodoPago = new List<Models.Data.MetodoPago>();
                foreach (var mp in xr1.Entidad.metPago.Where(w=>w.montoIngresado>0m).ToList())
                {
                    var pag = new Models.Data.MetodoPago()
                    {
                        descripcion = mp.descMP + mp.simboloMon,
                        monto = mp.montoMonLocal
                    };
                    if (xr0.Entidad.codigo.Trim().ToUpper() != mp.codigoMon) 
                    {
                        pag.descripcion = mp.descMP + "(" + mp.montoIngresado.ToString("n2") + mp.simboloMon + ")";
                    }
                    xdata.metodoPago.Add(pag);
                }
                xdata.medidaEmp = xr1.Entidad.medidas.Select(s =>
                {
                    var med = new Models.Data.MedidaEmp()
                    {
                        cant = s.cant,
                        desc = s.desc,
                        peso = s.peso,
                        volumen = s.volumen,
                    };
                    return med;
                }).ToList();
                //
                var _lprecio = new List<String>();
                var it = 1;
                var _xrt = (xr1.Entidad.cuerpo.MontoDivisa - xr1.Entidad.cuerpo.MontoBonoEnDivisaPorPagoDivisa);
                foreach (var rg in xr1.Entidad.precios)
                {
                    var precio = rg.precio;
                    var rt = rg.descPrd.Trim() + " #" + precio.ToString("n2").Trim() + "- ";
                    it += 1;
                    _lprecio.Add(rt);
                }
                xdata.precios = _lprecio;
                //
                xdata.infoQR = new Models.Data.qr()
                {
                    codigoDoc = _cuerpo.Tipo,
                    idCierre = _cuerpo.Cierre,
                    idDoc = _cuerpo.Auto,
                    montoDoc = _cuerpo.Total,
                    nroDoc = _cuerpo.DocumentoNro,
                };
                return xdata;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}