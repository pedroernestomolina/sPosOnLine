using PosOnLine.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Prov
{
    public partial class DataPrv : IData
    {
        public OOB.Resultado.FichaAuto
                    Documento_Agregar_NotaCredito(OOB.Documento.Agregar.NotaCredito.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaAuto();
            //
            var fichaDTO = new DtoLibPos.Documento.Agregar.NotaCredito.Ficha()
            {
                idOperador = ficha.idOperador,
                DocumentoNro = ficha.DocumentoNro,
                RazonSocial = ficha.RazonSocial,
                DirFiscal = ficha.DirFiscal,
                CiRif = ficha.CiRif,
                Tipo = ficha.Tipo,
                Exento = ficha.Exento,
                Base1 = ficha.Base1,
                Base2 = ficha.Base2,
                Base3 = ficha.Base3,
                Impuesto1 = ficha.Impuesto1,
                Impuesto2 = ficha.Impuesto2,
                Impuesto3 = ficha.Impuesto3,
                MBase = ficha.MBase,
                Impuesto = ficha.Impuesto,
                Total = ficha.Total,
                Tasa1 = ficha.Tasa1,
                Tasa2 = ficha.Tasa2,
                Tasa3 = ficha.Tasa3,
                Nota = ficha.Nota,
                TasaRetencionIva = ficha.TasaRetencionIva,
                TasaRetencionIslr = ficha.TasaRetencionIslr,
                RetencionIva = ficha.TasaRetencionIva,
                RetencionIslr = ficha.RetencionIslr,
                AutoCliente = ficha.AutoCliente,
                CodigoCliente = ficha.CodigoCliente,
                Control = ficha.Control,
                OrdenCompra = ficha.OrdenCompra,
                Dias = ficha.Dias,
                Descuento1 = ficha.Descuento1,
                Descuento2 = ficha.Descuento2,
                Cargos = ficha.Cargos,
                Descuento1p = ficha.Descuento1p,
                Descuento2p = ficha.Descuento2p,
                Cargosp = ficha.Cargosp,
                Columna = ficha.Columna,
                EstatusAnulado = ficha.EstatusAnulado,
                Aplica = ficha.Aplica,
                ComprobanteRetencion = ficha.ComprobanteRetencion,
                SubTotalNeto = ficha.SubTotalNeto,
                Telefono = ficha.Telefono,
                FactorCambio = ficha.FactorCambio,
                CodigoVendedor = ficha.CodigoVendedor,
                Vendedor = ficha.Vendedor,
                AutoVendedor = ficha.AutoVendedor,
                Pedido = ficha.Pedido,
                CondicionPago = ficha.CondicionPago,
                Usuario = ficha.Usuario,
                CodigoUsuario = ficha.CodigoUsuario,
                CodigoSucursal = ficha.CodigoSucursal,
                Transporte = ficha.Transporte,
                CodigoTransporte = ficha.CodigoTransporte,
                MontoDivisa = ficha.MontoDivisa,
                Despachado = ficha.Despachado,
                DirDespacho = ficha.DirDespacho,
                Estacion = ficha.Estacion,
                Renglones = ficha.Renglones,
                SaldoPendiente = ficha.SaldoPendiente,
                ComprobanteRetencionIslr = ficha.ComprobanteRetencionIslr,
                DiasValidez = ficha.DiasValidez,
                AutoUsuario = ficha.AutoUsuario,
                AutoTransporte = ficha.AutoTransporte,
                Situacion = ficha.Situacion,
                Signo = ficha.Signo,
                Serie = ficha.Serie,
                Tarifa = ficha.Tarifa,
                TipoRemision = ficha.TipoRemision,
                DocumentoRemision = ficha.DocumentoRemision,
                AutoRemision = ficha.AutoRemision,
                DocumentoNombre = ficha.DocumentoNombre,
                SubTotalImpuesto = ficha.SubTotalImpuesto,
                SubTotal = ficha.SubTotal,
                TipoCliente = ficha.TipoCliente,
                Planilla = ficha.Planilla,
                Expendiente = ficha.Expendiente,
                AnticipoIva = ficha.AnticipoIva,
                TercerosIva = ficha.TercerosIva,
                Neto = ficha.Neto,
                Costo = ficha.Costo,
                Utilidad = ficha.Utilidad,
                Utilidadp = ficha.Utilidadp,
                DocumentoTipo = ficha.DocumentoTipo,
                CiTitular = ficha.CiTitular,
                NombreTitular = ficha.NombreTitular,
                CiBeneficiario = ficha.CiBeneficiario,
                NombreBeneficiario = ficha.NombreBeneficiario,
                Clave = ficha.Clave,
                DenominacionFiscal = ficha.DenominacionFiscal,
                Cambio = ficha.Cambio,
                Cierre = ficha.Cierre,
                CierreFtp = ficha.CierreFtp,
                EstatusCierreContable = ficha.EstatusCierreContable,
                EstatusValidado = ficha.EstatusValidado,
                FechaPedido = ficha.FechaPedido,
                Prefijo = ficha.Prefijo,
                //
                PorctBonoPorPagoDivisa = ficha.PorctBonoPorPagoDivisa,
                CantDivisaAplicaBonoPorPagoDivisa = ficha.CantDivisaAplicaBonoPorPagoDivisa,
                MontoBonoPorPagoDivisa = ficha.MontoBonoPorPagoDivisa,
                MontoBonoEnDivisaPorPagoDivisa = ficha.MontoBonoEnDivisaPorPagoDivisa,
                MontoPorVueltoEnEfectivo = ficha.MontoPorVueltoEnEfectivo,
                MontoPorVueltoEnDivisa = ficha.MontoPorVueltoEnDivisa,
                MontoPorVueltoEnPagoMovil = ficha.MontoPorVueltoEnPagoMovil,
                CantDivisaPorVueltoEnDivisa = ficha.CantDivisaPorVueltoEnDivisa,
                estatusPorBonoPorPagoDivisa = ficha.estatusPorBonoPorPagoDivisa,
                estatusPorVueltoEnPagoMovil = ficha.estatusPorVueltoEnPagoMovil,
                //
                estatusFiscal = ficha.estatusFiscal,
                zFiscal = ficha.zFiscal,
                //
                estatusMostrarLibroVenta = ficha.AplicarLibroVenta ? "1" : "",
            };
            //
            if (ficha.ClienteSaldo == null)
            {
                fichaDTO.ClienteSaldo = null;
            }
            else
            {
                fichaDTO.ClienteSaldo = new DtoLibPos.Documento.Agregar.NotaCredito.FichaClienteSaldo()
                {
                    autoCliente = ficha.ClienteSaldo.AutoCliente,
                    montoActualizar = Math.Round(ficha.ClienteSaldo.MontoActualizar, 2, MidpointRounding.AwayFromZero),
                };
            }
            //
            var detalles = ficha.Detalles.Select(s =>
            {
                var nr = new DtoLibPos.Documento.Agregar.NotaCredito.FichaDetalle()
                {
                    AutoProducto = s.AutoProducto,
                    Codigo = s.Codigo,
                    Nombre = s.Nombre,
                    AutoDepartamento = s.AutoDepartamento,
                    AutoGrupo = s.AutoGrupo,
                    AutoSubGrupo = s.AutoSubGrupo,
                    AutoDeposito = s.AutoDeposito,
                    Cantidad = s.Cantidad,
                    Empaque = s.Empaque,
                    PrecioNeto = s.PrecioNeto,
                    Descuento1p = s.Descuento1p,
                    Descuento2p = s.Descuento2p,
                    Descuento3p = s.Descuento3p,
                    Descuento1 = s.Descuento1,
                    Descuento2 = s.Descuento2,
                    Descuento3 = s.Descuento3,
                    CostoVenta = s.CostoVenta,
                    TotalNeto = s.TotalNeto,
                    Tasa = s.Tasa,
                    Impuesto = s.Impuesto,
                    Total = s.Total,
                    EstatusAnulado = s.EstatusAnulado,
                    Tipo = s.Tipo,
                    Deposito = s.Deposito,
                    Signo = s.Signo,
                    PrecioFinal = s.PrecioFinal,
                    AutoCliente = s.AutoCliente,
                    Decimales = s.Decimales,
                    ContenidoEmpaque = s.ContenidoEmpaque,
                    CantidadUnd = s.CantidadUnd,
                    PrecioUnd = s.PrecioUnd,
                    CostoUnd = s.CostoUnd,
                    Utilidad = s.Utilidad,
                    Utilidadp = s.Utilidadp,
                    PrecioItem = s.PrecioItem,
                    EstatusGarantia = s.EstatusGarantia,
                    EstatusSerial = s.EstatusSerial,
                    CodigoDeposito = s.CodigoDeposito,
                    DiasGarantia = s.DiasGarantia,
                    Detalle = s.Detalle,
                    PrecioSugerido = s.PrecioSugerido,
                    AutoTasa = s.AutoTasa,
                    EstatusCorte = s.EstatusCorte,
                    X = s.X,
                    Y = s.Y,
                    Z = s.Z,
                    Corte = s.Corte,
                    Categoria = s.Categoria,
                    Cobranzap = s.Cobranzap,
                    Ventasp = s.Ventasp,
                    CobranzapVendedor = s.CobranzapVendedor,
                    VentaspVendedor = s.VentaspVendedor,
                    Cobranza = s.Cobranza,
                    Ventas = s.Ventas,
                    CobranzaVendedor = s.CobranzaVendedor,
                    VentasVendedor = s.VentasVendedor,
                    CostoPromedioUnd = s.CostoPromedioUnd,
                    CostoCompra = s.CostoCompra,
                    EstatusChecked = s.EstatusChecked,
                    Tarifa = s.Tarifa,
                    TotalDescuento = s.TotalDescuento,
                    CodigoVendedor = s.CodigoVendedor,
                    AutoVendedor = s.AutoVendedor,
                };
                return nr;
            }).ToList();
            fichaDTO.Detalles = detalles;
            //
            var kardex = ficha.MovKardex.Select(s =>
            {
                var nr = new DtoLibPos.Documento.Agregar.NotaCredito.FichaKardex()
                {
                    AutoProducto = s.AutoProducto,
                    Total = s.Total,
                    AutoDeposito = s.AutoDeposito,
                    AutoConcepto = s.AutoConcepto,
                    Modulo = s.Modulo,
                    Entidad = s.Entidad,
                    Signo = s.Signo,
                    Cantidad = s.Cantidad,
                    CantidadBono = s.CantidadBono,
                    CantidadUnd = s.CantidadUnd,
                    CostoUnd = s.CostoUnd,
                    EstatusAnulado = s.EstatusAnulado,
                    Nota = s.Nota,
                    PrecioUnd = s.PrecioUnd,
                    Codigo = s.Codigo,
                    Siglas = s.Siglas,
                    CierreFtp = s.CierreFtp,
                    CodigoConcepto = s.CodigoConcepto,
                    CodigoDeposito = s.CodigoDeposito,
                    CodigoSucursal = s.CodigoSucursal,
                    NombreConcepto = s.NombreConcepto,
                    NombreDeposito = s.NombreDeposito,
                    FactorCambio = s.FactorCambio,
                };
                return nr;
            }).ToList();
            fichaDTO.MovKardex = kardex;
            //
            var actDeposito = ficha.ActDeposito.Select(s =>
            {
                var nr = new DtoLibPos.Documento.Agregar.NotaCredito.FichaDeposito()
                {
                    AutoDeposito = s.AutoDeposito,
                    AutoProducto = s.AutoProducto,
                    CantUnd = s.CantUnd,
                };
                return nr;
            }).ToList();
            fichaDTO.ActDeposito = actDeposito;
            //
            var dc = ficha.DocCxC;
            var docCxC = new DtoLibPos.Documento.Agregar.NotaCredito.FichaCxC()
            {
                CCobranza = dc.CCobranza,
                CCobranzap = dc.CCobranzap,
                TipoDocumento = dc.TipoDocumento,
                Nota = dc.Nota,
                Importe = dc.Importe,
                Acumulado = dc.Acumulado,
                AutoCliente = dc.AutoCliente,
                Cliente = dc.Cliente,
                CiRif = dc.CiRif,
                CodigoCliente = dc.CodigoCliente,
                EstatusCancelado = dc.EstatusCancelado,
                Resta = dc.Resta,
                EstatusAnulado = dc.EstatusAnulado,
                Numero = dc.Numero,
                AutoAgencia = dc.AutoAgencia,
                Agencia = dc.Agencia,
                Signo = dc.Signo,
                AutoVendedor = dc.AutoVendedor,
                CDepartamento = dc.CDepartamento,
                CVentas = dc.CVentas,
                CVentasp = dc.CVentasp,
                Serie = dc.Serie,
                ImporteNeto = dc.ImporteNeto,
                Dias = dc.Dias,
                MontoDivisa = dc.MontoDivisa,
                TasaDivisa = dc.TasaDivisa,
                //
                AcumuladoDivisa = dc.AcumuladoDivisa,
                CodigoSucursal = dc.CodigoSucursal,
                RestaDivisa = dc.RestaDivisa,
                ImporteNetoDivisa = dc.ImporteNetoDivisa,
            };
            fichaDTO.DocCxC = docCxC;
            //
            if (ficha.DocCxCPago == null)
            {
                fichaDTO.DocCxCPago = null;
            }
            else
            {
                var xp = ficha.DocCxCPago.Pago;
                var p = new DtoLibPos.Documento.Agregar.NotaCredito.FichaCxC()
                {
                    CCobranza = xp.CCobranza,
                    CCobranzap = xp.CCobranzap,
                    TipoDocumento = xp.TipoDocumento,
                    Nota = xp.Nota,
                    Importe = xp.Importe,
                    Acumulado = xp.Acumulado,
                    AutoCliente = xp.AutoCliente,
                    Cliente = xp.Cliente,
                    CiRif = xp.CiRif,
                    CodigoCliente = xp.CodigoCliente,
                    EstatusCancelado = xp.EstatusCancelado,
                    Resta = xp.Resta,
                    EstatusAnulado = xp.EstatusAnulado,
                    Numero = xp.Numero,
                    AutoAgencia = xp.AutoAgencia,
                    Agencia = xp.Agencia,
                    Signo = xp.Signo,
                    AutoVendedor = xp.AutoVendedor,
                    CDepartamento = xp.CDepartamento,
                    CVentas = xp.CVentas,
                    CVentasp = xp.CVentasp,
                    Serie = xp.Serie,
                    ImporteNeto = xp.ImporteNeto,
                    Dias = xp.Dias,
                    CastigoP = xp.CastigoP,
                    CierreFtp = xp.CierreFtp,
                    MontoDivisa = dc.MontoDivisa,
                    TasaDivisa = dc.TasaDivisa,
                    //
                    AcumuladoDivisa = xp.AcumuladoDivisa,
                    CodigoSucursal = xp.CodigoSucursal,
                    RestaDivisa = xp.RestaDivisa,
                    ImporteNetoDivisa = xp.ImporteNetoDivisa,
                };
                //
                var xpR = ficha.DocCxCPago.Recibo;
                var pR = new DtoLibPos.Documento.Agregar.NotaCredito.FichaCxCRecibo()
                {
                    AutoUsuario = xpR.AutoUsuario,
                    Importe = xpR.Importe,
                    Usuario = xpR.Usuario,
                    MontoRecibido = xpR.MontoRecibido,
                    Cobrador = xpR.Cobrador,
                    AutoCliente = xpR.AutoCliente,
                    Cliente = xpR.Cliente,
                    CiRif = xpR.CiRif,
                    Codigo = xpR.Codigo,
                    EstatusAnulado = xpR.EstatusAnulado,
                    Direccion = xpR.Direccion,
                    Telefono = xpR.Telefono,
                    AutoCobrador = xpR.AutoCobrador,
                    Anticipos = xpR.Anticipos,
                    Cambio = xpR.Cambio,
                    Nota = xpR.Nota,
                    CodigoCobrador = xpR.CodigoCobrador,
                    Retenciones = xpR.Retenciones,
                    Descuentos = xpR.Descuentos,
                    Cierre = xpR.Cierre,
                    CierreFtp = xpR.CierreFtp,
                    //
                    ImporteDivisa = xpR.ImporteDivisa,
                    MontoRecibidoDivisa = xpR.MontoRecibidoDivisa,
                    CambioDivisa = xpR.CambioDivisa,
                    CodigoSucursal = xpR.CodigoSucursal,
                };
                //
                var xpD = ficha.DocCxCPago.Documento;
                var pD = new DtoLibPos.Documento.Agregar.NotaCredito.FichaCxCDocumento()
                {
                    Id = xpD.Id,
                    TipoDocumento = xpD.TipoDocumento,
                    Importe = xpD.Importe,
                    Operacion = xpD.Operacion,
                    CastigoP = xpD.CastigoP,
                    CierreFtp = xpD.CierreFtp,
                    ComisionP = xpD.ComisionP,
                    Dias = xpD.Dias,
                    //
                    ImporteDivisa = xpD.ImporteDivisa,
                    CodigoSucursal = xpD.CodigoSucursal,
                    Notas = xpD.Notas,
                };
                //
                var pM = ficha.DocCxCPago.MetodoPago.Select(s =>
                {
                    var nr = new DtoLibPos.Documento.Agregar.NotaCredito.FichaCxCMetodoPago()
                    {
                        AutoMedioPago = s.AutoMedioPago,
                        AutoAgencia = s.AutoAgencia,
                        Medio = s.Medio,
                        Codigo = s.Codigo,
                        MontoRecibido = s.MontoRecibido,
                        EstatusAnulado = s.EstatusAnulado,
                        Numero = s.Numero,
                        Agencia = s.Agencia,
                        AutoUsuario = s.AutoUsuario,
                        AutoCobrador = s.AutoCobrador,
                        Cierre = s.Cierre,
                        CierreFtp = s.CierreFtp,
                        Lote = s.Lote,
                        Referencia = s.Referencia,
                        //
                        OpBanco = s.OpBanco,
                        OpNroCta = s.OpNroCta,
                        OpNroRef = s.OpNroRef,
                        OpFecha = s.OpFecha,
                        OpDetalle = s.OpDetalle,
                        OpMonto = s.OpMonto,
                        OpTasa = s.OpTasa,
                        OpAplicaConversion = s.OpAplicaConversion,
                        CodigoSucursal = s.CodigoSucursal,
                    };
                    return nr;
                }).ToList();
                //
                var dp = new DtoLibPos.Documento.Agregar.NotaCredito.FichaCxCPago()
                {
                    Pago = p,
                    Recibo = pR,
                    Documento = pD,
                    MetodoPago = pM,
                };
                fichaDTO.DocCxCPago = dp;
            }
            //
            fichaDTO.Resumen = new DtoLibPos.Documento.Agregar.NotaCredito.FichaPosResumen()
            {
                cntDevolucion = ficha.Resumen.cntDevolucion,
                cntDivisa = ficha.Resumen.cntDivisa,
                cntDoc = ficha.Resumen.cntDoc,
                cntDocContado = ficha.Resumen.cntDocContado,
                cntDocCredito = ficha.Resumen.cntDocCredito,
                cntEfectivo = ficha.Resumen.cntEfectivo,
                cntElectronico = ficha.Resumen.cntElectronico,
                cntFac = ficha.Resumen.cntFac,
                cntNCr = ficha.Resumen.cntNCr,
                cntotros = ficha.Resumen.cntotros,
                idResumen = ficha.Resumen.idResumen,
                mContado = ficha.Resumen.mContado,
                mCredito = ficha.Resumen.mCredito,
                mDevolucion = ficha.Resumen.mDevolucion,
                mDivisa = ficha.Resumen.mDivisa,
                mEfectivo = ficha.Resumen.mEfectivo,
                mElectronico = ficha.Resumen.mElectronico,
                mFac = ficha.Resumen.mFac,
                mNCr = ficha.Resumen.mNCr,
                mOtros = ficha.Resumen.mOtros,
                cntAnu = ficha.Resumen.cntAnu,
                cntNte = ficha.Resumen.cntNte,
                mAnu = ficha.Resumen.mAnu,
                mNte = ficha.Resumen.mNte,
            };


            //
            var resumenGeneral = new DtoLibPos.Documento.Agregar.NotaCredito.FichaPosResumenGeneral();
            if (ficha.ResumenGeneral != null)
            {
                var rg = ficha.ResumenGeneral;
                resumenGeneral = new DtoLibPos.Documento.Agregar.NotaCredito.FichaPosResumenGeneral()
                {
                    cambioVueltoMonLocal = rg.cambioVuelto,
                    cntDivisaEntregada = rg.cntDivisaEntregada,
                    codigoDocumento = rg.codigoDocumento,
                    estatusAnulado = rg.estatusAnulado,
                    estatusCredito = rg.estatusCredito,
                    idResumen = rg.idResumen,
                    montoMonLocal = rg.montoMonLocal,
                    montoMonReferencia = rg.montoMonReferencia,
                    montoPendMonLocal = rg.montoPendMonLocal,
                    montoPendMonReferencia = rg.montoPendMonReferencia,
                    montoRecibidoMonLocal = rg.montoRecibidoMonLocal,
                    montoRecibidoMonReferencia = rg.montoRecibidoMonReferencia,
                    nombreDocumento = rg.nombreDocumento,
                    signoDocumento = rg.signoDocumento,
                    varianteDocumento = rg.varianteDocumento,
                    vueltoDadoPagoDivisa = rg.vueltoDadoPagoDivisa,
                    vueltoDadoPagoEfectivo = rg.vueltoDadoPagoEfectivo,
                    vueltoDadoPagoMovil = rg.vueltoDadoPagoMovil,
                    factorCambio = rg.factorCambio,
                    bonoPagoDivisaMonLocal = rg.bonoPagoDivisaMonLocal,
                    bonoPagoDivisaMonReferencia = rg.bonoPagoDivisaMonReferencia,
                    cambioVueltoMonReferencia = rg.cambioVueltoMonReferencia,
                    igtfMonLocal = rg.igtfMonLocal,
                };
            }
            fichaDTO.resumenGeneral = resumenGeneral;
            //
            var lst_DetalleFormaPago = new List<DtoLibPos.Documento.Agregar.NotaCredito.FichaPosResumenDetalleFormaPago>();
            if (ficha.DetalleFormaPago != null)
            {
                foreach (var it in ficha.DetalleFormaPago)
                {
                    var detalleFormaPago = new DtoLibPos.Documento.Agregar.NotaCredito.FichaPosResumenDetalleFormaPago()
                    {
                        codigoCurrencies = it.codigoCurrencies,
                        codigoMedioPago = it.codigoMedioPago,
                        descripcionCurrencies = it.descripcionCurrencies,
                        descripcionMedioPago = it.descripcionMedioPago,
                        estatusAnulado = it.estatusAnulado,
                        estatusAplicaBonoPorPagoDivisa = it.estatusAplicaBonoPorPagoDivisa ? "1" : "0",
                        estatusAplicaIGTF = it.estatusAplicaIGTF ? "1" : "0",
                        idCurrencies = it.idCurrencies,
                        idMedioPago = it.idMedioPago,
                        idResumen = it.idResumen,
                        loteNro = it.loteNro,
                        montoIngresao = it.montoIngresao,
                        montoIngresoMonedaLocal = it.montoIngresoMonedaLocal,
                        montoIngresoMonedaReferencia = it.montoIngresoMonedaReferencia,
                        referenciaNro = it.referenciaNro,
                        signo = it.signo,
                        simboloCurrencies = it.simboloCurrencies,
                        tasaCurrencies = it.tasaCurrencies,
                        factorCambio = it.factorCambio,
                    };
                    lst_DetalleFormaPago.Add(detalleFormaPago);
                }
            }
            fichaDTO.detalleFormaPago = lst_DetalleFormaPago;
            //



            if (ficha.SerieFiscal != null)
            {
                fichaDTO.SerieFiscal = new DtoLibPos.Documento.Agregar.NotaCredito.FichaSerie() { auto = ficha.SerieFiscal.auto };
            }
            //
            var r01 = MyData.Documento_Agregar_NotaCredito(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Auto = r01.Auto;
            //
            return result;
        }
    }
}