using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pos.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public Models.ResultadoAgregarDoc
            AgregarFactura(OOB.Documento.Agregar.Factura.Ficha doc)
        {
            var result = Sistema.MyData.Documento_Agregar_Factura(doc);
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(result.Mensaje);
            }
            if (result.Entidad == null) 
            {
                throw new Exception("DATA NO CARGADA");
            }
            var s=result.Entidad;
            var rt = new Models.ResultadoAgregarDoc()
            {
                autoCierre = s.autoCierre,
                autoDoc = s.autoDoc,
                codDoc = s.codDoc,
                idVerificador = s.idVerificador,
                montoDoc = s.montoDoc,
                numDoc = s.numDoc,
            };
            return rt;
       }
        public Helpers.Imprimir.data 
            CargarDataDocumento(Models.ResultadoAgregarDoc result)
        {
            try
            {
                var xr1 = Sistema.MyData.Documento_GetById(result.autoDoc);
                if (xr1.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(xr1.Mensaje);
                }
                var xr2 = Sistema.MyData.Documento_Get_MetodosPago_ByIdRecibo(xr1.Entidad.AutoReciboCxC);
                if (xr2.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(xr2.Mensaje);
                }
                //
                var _lprecio = new List<String>();
                var it = 1;
                foreach (var rg in xr1.Entidad.precios)
                {
                    var rt = rg.descPrd.Trim() + " #" + rg.precio.ToString("n2").Trim() + "- ";
                    it += 1;
                    _lprecio.Add(rt);
                }
                //

                var xdata = new Helpers.Imprimir.data();
                xdata.isAnulado = xr1.Entidad.EstatusAnulado == "1";
                xdata.negocio = new Helpers.Imprimir.data.Negocio()
                {
                    Nombre = Sistema.DatosEmpresa.Nombre,
                    CiRif = Sistema.DatosEmpresa.CiRif,
                    Direccion = Sistema.DatosEmpresa.Direccion,
                    Telefonos = Sistema.DatosEmpresa.Telefono,
                };
                var docNombre = "";
                switch (xr1.Entidad.Tipo.Trim().ToUpper())
                {
                    case "01":
                        docNombre = "FACTURA";
                        break;
                    case "02":
                        docNombre = "NOTA DE DEBITO";
                        break;
                    case "03":
                        docNombre = "NOTA DE CREDITO";
                        break;
                    case "04":
                        docNombre = "NOTA DE ENTREGA";
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
                    FactorCambio = xr1.Entidad.FactorCambio,
                    SubTotal = xr1.Entidad.SubTotal,
                    Descuento = xr1.Entidad.Descuento,
                    Total = xr1.Entidad.Total,
                    TotalDivisa = xr1.Entidad.MontoDivisa,
                    EstacionEquipo = xr1.Entidad.Estacion,
                    Usuario = xr1.Entidad.Usuario,
                    CambioDar = xr1.Entidad.Cambio,
                    DocumentoHora = xr1.Entidad.Hora,
                    TelefonoCli = xr1.Entidad.Telefono,
                    CodigoCli = xr1.Entidad.CodigoCliente,
                    DescuentoPorc = xr1.Entidad.Descuento1p,
                    Cargo = xr1.Entidad.Cargos,
                    CargoPorc = xr1.Entidad.Cargosp,
                    VueltoEfectivo = xr1.Entidad.MontoPorVueltoEnEfectivo,
                    VueltoDivisa = xr1.Entidad.MontoPorVueltoEnDivisa,
                    VueltoPagoMovil = xr1.Entidad.MontoPorVueltoEnPagoMovil,
                    CntDivisaVueltoDivisa = xr1.Entidad.CantDivisaPorVueltoEnDivisa,
                    //
                    BonoPorPagoDivisa = xr1.Entidad.BonoPorPagoDivisa,
                    MontoBonoPorPagoDivisa = xr1.Entidad.MontoBonoPorPagoDivisa,
                    CntDivisaAplicaBonoPorPagoDivisa = xr1.Entidad.CntDivisaAplicaBonoPorPagoDivisa,
                    //
                    DocumentoAplica_Fecha = xr1.Entidad.Fecha,
                    DocumentoAplica_SerialFiscal = xr1.Entidad.Control,
                    //
                    AplicaIGTF = xr1.Entidad.aplicaIGTF,
                    MontoIGTF = xr1.Entidad.montoIGTF,
                    TasaIGTF = xr1.Entidad.tasaIGTF,
                    //
                    SaldoPendientDiv = xr1.Entidad.SaldoPendiente,
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
                        ImporteDivisa = rg.TotalNeto,
                        Precio = rg.PrecioItem,
                        PrecioDivisa = rg.PrecioItem,
                        TotalUnd = rg.CantidadUnd,
                        TasaIva = rg.Tasa,
                        ImporteFull = rg.Total,
                    };
                    xdata.item.Add(nr);
                }
                xdata.metodoPago = new List<Helpers.Imprimir.data.MetodoPago>();
                foreach (var mp in xr2.ListaD)
                {
                    if (Math.Abs(mp.cntDivisa) >= 1)
                    {
                        var pag = new Helpers.Imprimir.data.MetodoPago() { descripcion = "Efectivo(" + Sistema.SimboloDivisa_AlImprimirTicket + mp.cntDivisa.ToString() + ")", monto = mp.montoRecibido, esDivisa = true };
                        xdata.metodoPago.Add(pag);
                    }
                    else
                    {
                        var pag = new Helpers.Imprimir.data.MetodoPago() { descripcion = mp.descMedioPago, monto = mp.montoRecibido };
                        xdata.metodoPago.Add(pag);
                    }
                }
                xdata.medidaEmp = xr1.Entidad.medidas.Select(s =>
                {
                    var med = new Helpers.Imprimir.data.MedidaEmp()
                    {
                        cant = s.cant,
                        desc = s.desc,
                        peso = s.peso,
                        volumen = s.volumen,
                    };
                    return med;
                }).ToList();
                //
                xdata.precios = _lprecio;
                //
                return xdata;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return null;
            }
        }
        public Models.ResultadoAgregarDoc 
            AgregarNotaCredito(OOB.Documento.Agregar.NotaCredito.Ficha doc)
        {
            var result = Sistema.MyData.Documento_Agregar_NotaCredito(doc);
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(result.Mensaje);
            }
            if (result.Auto == "")
            {
                throw new Exception("DATA NO CARGADA");
            }
            var rt = new Models.ResultadoAgregarDoc()
            {
                autoCierre = "",
                autoDoc = result.Auto,
                codDoc = "",
                idVerificador = -1,
                montoDoc = 0m,
                numDoc = "",
            };
            return rt;
        }
    }
}