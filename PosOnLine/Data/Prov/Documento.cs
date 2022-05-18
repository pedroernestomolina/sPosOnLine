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

        public OOB.Resultado.FichaAuto Documento_Agregar_Factura(OOB.Documento.Agregar.Factura.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaAuto();

            var fichaDTO = new DtoLibPos.Documento.Agregar.Factura.Ficha()
            {
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
            };

            var detalles = ficha.Detalles.Select(s =>
            {
                var nr = new DtoLibPos.Documento.Agregar.Factura.FichaDetalle()
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

            var kardex = ficha.MovKardex.Select(s =>
            {
                var nr = new DtoLibPos.Documento.Agregar.Factura.FichaKardex()
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
                };
                return nr;
            }).ToList();
            fichaDTO.MovKardex = kardex;

            var actDeposito = ficha.ActDeposito.Select(s =>
            {
                var nr = new DtoLibPos.Documento.Agregar.Factura.FichaDeposito()
                {
                    AutoDeposito = s.AutoDeposito,
                    AutoProducto = s.AutoProducto,
                    CantUnd = s.CantUnd,
                };
                return nr;
            }).ToList();
            fichaDTO.ActDeposito = actDeposito;

            var dc = ficha.DocCxC;
            var docCxC = new DtoLibPos.Documento.Agregar.Factura.FichaCxC()
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
            };
            fichaDTO.DocCxC = docCxC;

            if (ficha.DocCxCPago == null)
            {
                fichaDTO.DocCxCPago = null;
            }
            else
            {
                var xp = ficha.DocCxCPago.Pago;
                var p = new DtoLibPos.Documento.Agregar.Factura.FichaCxC()
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
                };

                var xpR = ficha.DocCxCPago.Recibo;
                var pR = new DtoLibPos.Documento.Agregar.Factura.FichaCxCRecibo()
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
                };

                var xpD = ficha.DocCxCPago.Documento;
                var pD = new DtoLibPos.Documento.Agregar.Factura.FichaCxCDocumento()
                {
                    Id = xpD.Id,
                    TipoDocumento = xpD.TipoDocumento,
                    Importe = xpD.Importe,
                    Operacion = xpD.Operacion,
                    CastigoP = xpD.CastigoP,
                    CierreFtp = xpD.CierreFtp,
                    ComisionP = xpD.ComisionP,
                    Dias = xpD.Dias,
                };

                var pM = ficha.DocCxCPago.MetodoPago.Select(s =>
                {
                    var nr = new DtoLibPos.Documento.Agregar.Factura.FichaCxCMetodoPago()
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
                    };
                    return nr;
                }).ToList();

                var dp = new DtoLibPos.Documento.Agregar.Factura.FichaCxCPago()
                {
                    Pago = p,
                    Recibo = pR,
                    Documento = pD,
                    MetodoPago = pM,
                };
                fichaDTO.DocCxCPago = dp;
            }
            fichaDTO.PosVenta = ficha.PosVenta.Select(s =>
            {
                var nr = new DtoLibPos.Documento.Agregar.Factura.FichaPosVenta()
                {
                    id = s.id,
                    idOperador = s.idOperador,
                };
                return nr;
            }).ToList();
            fichaDTO.Resumen = new DtoLibPos.Documento.Agregar.Factura.FichaPosResumen()
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
                //
                cntAnu = ficha.Resumen.cntAnu,
                cntNte = ficha.Resumen.cntNte,
                mAnu = ficha.Resumen.mAnu,
                mNte = ficha.Resumen.mNte,
                //
                cntCambio = ficha.Resumen.cntCambio,
                mCambio = ficha.Resumen.mCambio,
            };
            if (ficha.SerieFiscal != null) 
            {
                fichaDTO.SerieFiscal = new DtoLibPos.Documento.Agregar.Factura.FichaSerie() { auto = ficha.SerieFiscal.auto };
            }

            var r01 = MyData.Documento_Agregar_Factura(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Auto = r01.Auto;

            return result;
        }

        public OOB.Resultado.Lista<OOB.Documento.Lista.Ficha> Documento_Get_Lista(OOB.Documento.Lista.Filtro filtro)
        {
            var result = new OOB.Resultado.Lista<OOB.Documento.Lista.Ficha>();

            var filtroDTO = new DtoLibPos.Documento.Lista.Filtro()
            {
                idArqueo = filtro.idArqueo,
            };
            var r01 = MyData.Documento_Get_Lista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst = new List<OOB.Documento.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Documento.Lista.Ficha()
                        {
                            CiRif = s.CiRif,
                            Control = s.Control,
                            DocCodigo = s.DocCodigo,
                            DocNombre = s.DocNombre,
                            DocNumero = s.DocNumero,
                            DocSigno = s.DocSigno,
                            Estatus = s.Estatus,
                            FechaEmision = s.FechaEmision,
                            HoraEmision = s.HoraEmision,
                            Id = s.Id,
                            Monto = s.Monto,
                            NombreRazonSocial = s.NombreRazonSocial,
                            Renglones = s.Renglones,
                            Serie = s.Serie,
                            MontoDivisa=s.MontoDivisa,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Documento.Entidad.Ficha> Documento_GetById(string idAuto)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Documento.Entidad.Ficha>();

            var r01 = MyData.Documento_GetById (idAuto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            var s= r01.Entidad;
            var nr = new OOB.Documento.Entidad.Ficha()
            {
                AnoRelacion = s.AnoRelacion,
                AnticipoIva = s.AnticipoIva,
                Aplica = s.Aplica,
                Auto = s.Auto,
                AutoCliente = s.AutoCliente,
                AutoRemision = s.AutoRemision,
                AutoTransporte = s.AutoTransporte,
                AutoUsuario = s.AutoUsuario,
                AutoVendedor = s.AutoVendedor,
                Base1 = s.Base1,
                Base2 = s.Base2,
                Base3 = s.Base3,
                Cambio = s.Cambio,
                Cargos = s.Cargos,
                Cargosp = s.Cargosp,
                CiBeneficiario = s.CiBeneficiario,
                Cierre = s.Cierre,
                CierreFtp = s.CierreFtp,
                CiRif = s.CiRif,
                CiTitular = s.CiTitular,
                Clave = s.Clave,
                CodigoCliente = s.CodigoCliente,
                CodigoSucursal = s.CodigoSucursal,
                CodigoTransporte = s.CodigoTransporte,
                CodigoUsuario = s.CodigoUsuario,
                CodigoVendedor = s.CodigoVendedor,
                Columna = s.Columna,
                ComprobanteRetencion = s.ComprobanteRetencion,
                ComprobanteRetencionIslr = s.ComprobanteRetencionIslr,
                CondicionPago = s.CondicionPago,
                Control = s.Control,
                Costo = s.Costo,
                DenominacionFiscal = s.DenominacionFiscal,
                Descuento1 = s.Descuento1,
                Descuento1p = s.Descuento1p,
                Descuento2 = s.Descuento2,
                Descuento2p = s.Descuento2p,
                Despachado = s.Despachado,
                Dias = s.Dias,
                DiasValidez = s.DiasValidez,
                DirDespacho = s.DirDespacho,
                DirFiscal = s.DirFiscal,
                DocumentoNombre = s.DocumentoNombre,
                DocumentoNro = s.DocumentoNro,
                DocumentoRemision = s.DocumentoRemision,
                DocumentoTipo = s.DocumentoTipo,
                Estacion = s.Estacion,
                EstatusAnulado = s.EstatusAnulado,
                EstatusCierreContable = s.EstatusCierreContable,
                EstatusValidado = s.EstatusValidado,
                Exento = s.Exento,
                Expendiente = s.Expendiente,
                FactorCambio = s.FactorCambio,
                Fecha = s.Fecha,
                FechaPedido = s.FechaPedido,
                FechaVencimiento = s.FechaVencimiento,
                Hora = s.Hora,
                Impuesto = s.Impuesto,
                Impuesto1 = s.Impuesto1,
                Impuesto2 = s.Impuesto2,
                Impuesto3 = s.Impuesto3,
                MBase = s.MBase,
                MesRelacion = s.MesRelacion,
                MontoDivisa = s.MontoDivisa,
                Neto = s.Neto,
                NombreBeneficiario = s.NombreBeneficiario,
                NombreTitular = s.NombreTitular,
                Nota = s.Nota,
                OrdenCompra = s.OrdenCompra,
                Pedido = s.Pedido,
                Planilla = s.Planilla,
                Prefijo = s.Prefijo,
                RazonSocial = s.RazonSocial,
                Renglones = s.Renglones,
                RetencionIslr = s.RetencionIslr,
                RetencionIva = s.RetencionIva,
                SaldoPendiente = s.SaldoPendiente,
                Serie = s.Serie,
                Signo = s.Signo,
                Situacion = s.Situacion,
                SubTotal = s.SubTotal,
                SubTotalImpuesto = s.SubTotalImpuesto,
                SubTotalNeto = s.SubTotalNeto,
                Tarifa = s.Tarifa,
                Tasa1 = s.Tasa1,
                Tasa2 = s.Tasa2,
                Tasa3 = s.Tasa3,
                TasaRetencionIslr = s.TasaRetencionIslr,
                TasaRetencionIva = s.TasaRetencionIva,
                Telefono = s.Telefono,
                TercerosIva = s.TercerosIva,
                Tipo = s.Tipo,
                TipoCliente = s.TipoCliente,
                TipoRemision = s.TipoRemision,
                Total = s.Total,
                Transporte = s.Transporte,
                Usuario = s.Usuario,
                Utilidad = s.Utilidad,
                Utilidadp = s.Utilidadp,
                Vendedor = s.Vendedor,
                AutoDocCxC=s.AutoDocCxC,
                AutoReciboCxC=s.AutoReciboCxC,
                items = s.items.Select(ss =>
                {
                    var xr = new OOB.Documento.Entidad.FichaItem()
                    {
                        EstatusPesado=ss.EstatusPesado,
                        AutoCliente = ss.AutoCliente,
                        AutoDepartamento = ss.AutoDepartamento,
                        AutoDeposito = ss.AutoDeposito,
                        AutoGrupo = ss.AutoGrupo,
                        AutoProducto = ss.AutoProducto,
                        AutoSubGrupo = ss.AutoSubGrupo,
                        AutoTasa = ss.AutoTasa,
                        AutoVendedor = ss.AutoVendedor,
                        Cantidad = ss.Cantidad,
                        CantidadUnd = ss.CantidadUnd,
                        Categoria = ss.Categoria,
                        CierreFtp = ss.CierreFtp,
                        Cobranza = ss.Cobranza,
                        Cobranzap = ss.Cobranzap,
                        CobranzapVendedor = ss.CobranzapVendedor,
                        CobranzaVendedor = ss.CobranzaVendedor,
                        Codigo = ss.Codigo,
                        CodigoDeposito = ss.CodigoDeposito,
                        CodigoVendedor = ss.CodigoVendedor,
                        ContenidoEmpaque = ss.ContenidoEmpaque,
                        Corte = ss.Corte,
                        CostoCompra = ss.CostoCompra,
                        CostoPromedioUnd = ss.CostoPromedioUnd,
                        CostoUnd = ss.CostoUnd,
                        CostoVenta = ss.CostoVenta,
                        Decimales = ss.Decimales,
                        Deposito = ss.Deposito,
                        Descuento1 = ss.Descuento1,
                        Descuento1p = ss.Descuento1p,
                        Descuento2 = ss.Descuento2,
                        Descuento2p = ss.Descuento2p,
                        Descuento3 = ss.Descuento3,
                        Descuento3p = ss.Descuento3p,
                        Detalle = ss.Detalle,
                        DiasGarantia = ss.DiasGarantia,
                        Empaque = ss.Empaque,
                        EstatusAnulado = ss.EstatusAnulado,
                        EstatusChecked = ss.EstatusChecked,
                        EstatusCorte = ss.EstatusCorte,
                        EstatusGarantia = ss.EstatusGarantia,
                        EstatusSerial = ss.EstatusSerial,
                        Impuesto = ss.Impuesto,
                        Nombre = ss.Nombre,
                        PrecioFinal = ss.PrecioFinal,
                        PrecioItem = ss.PrecioItem,
                        PrecioNeto = ss.PrecioNeto,
                        PrecioSugerido = ss.PrecioSugerido,
                        PrecioUnd = ss.PrecioUnd,
                        Signo = ss.Signo,
                        Tarifa = ss.Tarifa,
                        Tasa = ss.Tasa,
                        Tipo = ss.Tipo,
                        Total = ss.Total,
                        TotalDescuento = ss.TotalDescuento,
                        TotalNeto = ss.TotalNeto,
                        Utilidad = ss.Utilidad,
                        Utilidadp = ss.Utilidadp,
                        Ventas = ss.Ventas,
                        Ventasp = ss.Ventasp,
                        VentaspVendedor = ss.VentaspVendedor,
                        VentasVendedor = ss.VentasVendedor,
                        X = ss.X,
                        Y = ss.Y,
                        Z = ss.Z,
                    };
                    return xr;
                }).ToList(),
            };
            result.Entidad = nr;

            return result;
        }

        public OOB.Resultado.FichaAuto Documento_Agregar_NotaCredito(OOB.Documento.Agregar.NotaCredito.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaAuto();

            var fichaDTO = new DtoLibPos.Documento.Agregar.NotaCredito.Ficha()
            {
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
            };

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
                };
                return nr;
            }).ToList();
            fichaDTO.MovKardex = kardex;

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
            };
            fichaDTO.DocCxC = docCxC;

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
            if (ficha.SerieFiscal != null)
            {
                fichaDTO.SerieFiscal = new DtoLibPos.Documento.Agregar.NotaCredito.FichaSerie() { auto = ficha.SerieFiscal.auto };
            }

            var r01 = MyData.Documento_Agregar_NotaCredito(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Auto = r01.Auto;

            return result;
        }

        public OOB.Resultado.FichaAuto Documento_Agregar_NotaEntrega(OOB.Documento.Agregar.NotaEntrega.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaAuto();

            var fichaDTO = new DtoLibPos.Documento.Agregar.NotaEntrega.Ficha()
            {
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
            };

            var detalles = ficha.Detalles.Select(s =>
            {
                var nr = new DtoLibPos.Documento.Agregar.NotaEntrega.FichaDetalle()
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

            var kardex = ficha.MovKardex.Select(s =>
            {
                var nr = new DtoLibPos.Documento.Agregar.NotaEntrega.FichaKardex()
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
                };
                return nr;
            }).ToList();
            fichaDTO.MovKardex = kardex;

            var actDeposito = ficha.ActDeposito.Select(s =>
            {
                var nr = new DtoLibPos.Documento.Agregar.NotaEntrega.FichaDeposito()
                {
                    AutoDeposito = s.AutoDeposito,
                    AutoProducto = s.AutoProducto,
                    CantUnd = s.CantUnd,
                };
                return nr;
            }).ToList();
            fichaDTO.ActDeposito = actDeposito;

            fichaDTO.PosVenta = ficha.PosVenta.Select(s =>
            {
                var nr = new DtoLibPos.Documento.Agregar.NotaEntrega.FichaPosVenta()
                {
                    id = s.id,
                    idOperador = s.idOperador,
                };
                return nr;
            }).ToList();
            fichaDTO.Resumen = new DtoLibPos.Documento.Agregar.NotaEntrega.FichaPosResumen()
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
            if (ficha.SerieFiscal != null)
            {
                fichaDTO.SerieFiscal = new DtoLibPos.Documento.Agregar.NotaEntrega.FichaSerie() { auto = ficha.SerieFiscal.auto };
            }

            var r01 = MyData.Documento_Agregar_NotaEntrega(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Auto = r01.Auto;

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ficha"></param>
        /// <returns></returns>
        /// 
        public OOB.Resultado.Ficha Documento_Anular_NotaEntrega(OOB.Documento.Anular.NotaEntrega.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var fichaDTO = new DtoLibPos.Documento.Anular.NotaEntrega.Ficha()
            {
                autoDocumento = ficha.autoDocumento,
                CodigoDocumento = ficha.CodigoDocumento,
                auditoria = new DtoLibPos.Documento.Anular.NotaEntrega.FichaAuditoria()
                {
                    autoSistemaDocumento = ficha.auditoria.autoSistemaDocumento,
                    autoUsuario = ficha.auditoria.autoUsuario,
                    codigo = ficha.auditoria.codigo,
                    estacion = ficha.auditoria.estacion,
                    motivo = ficha.auditoria.motivo,
                    usuario = ficha.auditoria.usuario,
                },
                deposito = ficha.deposito.Select(s =>
                {
                    var nr = new DtoLibPos.Documento.Anular.NotaEntrega.FichaDeposito()
                    {
                        AutoDeposito = s.AutoDeposito,
                        AutoProducto = s.AutoProducto,
                        CantUnd = s.CantUnd,
                        nombrePrd = s.nombrePrd,
                    };
                    return nr;
                }).ToList(),
                resumen = new DtoLibPos.Documento.Anular.NotaEntrega.FichaResumen()
                {
                    idResumen = ficha.resumen.idResumen,
                    monto = ficha.resumen.monto,
                },
            };

            var r01 = MyData.Documento_Anular_NotaEntrega (fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }
        public OOB.Resultado.Ficha Documento_Anular_NotaCredito(OOB.Documento.Anular.NotaCredito.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var fichaDTO = new DtoLibPos.Documento.Anular.NotaCredito.Ficha()
            {
                autoDocumento = ficha.autoDocumento,
                autoDocCxC=ficha.autoDocCxC,
                CodigoDocumento = ficha.CodigoDocumento,
                auditoria = new DtoLibPos.Documento.Anular.NotaCredito.FichaAuditoria()
                {
                    autoSistemaDocumento = ficha.auditoria.autoSistemaDocumento,
                    autoUsuario = ficha.auditoria.autoUsuario,
                    codigo = ficha.auditoria.codigo,
                    estacion = ficha.auditoria.estacion,
                    motivo = ficha.auditoria.motivo,
                    usuario = ficha.auditoria.usuario,
                },
                deposito = ficha.deposito.Select(s =>
                {
                    var nr = new DtoLibPos.Documento.Anular.NotaCredito.FichaDeposito()
                    {
                        AutoDeposito = s.AutoDeposito,
                        AutoProducto = s.AutoProducto,
                        CantUnd = s.CantUnd,
                        nombrePrd = s.nombrePrd,
                    };
                    return nr;
                }).ToList(),
                resumen = new DtoLibPos.Documento.Anular.NotaCredito.FichaResumen()
                {
                    idResumen = ficha.resumen.idResumen,
                    monto = ficha.resumen.monto,
                },
            };

            var r01 = MyData.Documento_Anular_NotaCredito(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }
        public OOB.Resultado.Ficha Documento_Anular_Factura(OOB.Documento.Anular.Factura.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var fichaDTO = new DtoLibPos.Documento.Anular.Factura.Ficha()
            {
                autoDocumento = ficha.autoDocumento,
                autoDocCxC = ficha.autoDocCxC,
                autoReciboCxC = ficha.autoReciboCxC,
                CodigoDocumento = ficha.CodigoDocumento,
                auditoria = new DtoLibPos.Documento.Anular.Factura.FichaAuditoria()
                {
                    autoSistemaDocumento = ficha.auditoria.autoSistemaDocumento,
                    autoUsuario = ficha.auditoria.autoUsuario,
                    codigo = ficha.auditoria.codigo,
                    estacion = ficha.auditoria.estacion,
                    motivo = ficha.auditoria.motivo,
                    usuario = ficha.auditoria.usuario,
                },
                deposito = ficha.deposito.Select(s =>
                {
                    var nr = new DtoLibPos.Documento.Anular.Factura.FichaDeposito()
                    {
                        AutoDeposito = s.AutoDeposito,
                        AutoProducto = s.AutoProducto,
                        CantUnd = s.CantUnd,
                        nombrePrd = s.nombrePrd,
                    };
                    return nr;
                }).ToList(),
                resumen = new DtoLibPos.Documento.Anular.Factura.FichaResumen()
                {
                    idResumen = ficha.resumen.idResumen,
                    monto = ficha.resumen.monto,
                    cntContado = ficha.resumen.cntContado,
                    cntCredito = ficha.resumen.cntCredito,
                    cntDivisa = ficha.resumen.cntDivisa,
                    cntEfectivo = ficha.resumen.cntEfectivo,
                    cntElectronico = ficha.resumen.cntElectronico,
                    cntOtros = ficha.resumen.cntOtros,
                    mContado = ficha.resumen.mContado,
                    mCredito = ficha.resumen.mCredito,
                    mDivisa = ficha.resumen.mDivisa,
                    mEfectivo = ficha.resumen.mEfectivo,
                    mElectronico = ficha.resumen.mElectronico,
                    mOtros = ficha.resumen.mOtros,
                    cntCambio=ficha.resumen.cntCambio,
                    mCambio=ficha.resumen.mCambio,
                },
            };

            var r01 = MyData.Documento_Anular_Factura(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idRecibo"></param>
        /// <returns></returns>

        public OOB.Resultado.Lista<OOB.Documento.Entidad.FichaMetodoPago> Documento_Get_MetodosPago_ByIdRecibo(string idRecibo)
        {
            var result = new OOB.Resultado.Lista<OOB.Documento.Entidad.FichaMetodoPago>();

            var r01 = MyData.Documento_Get_MetodosPago_ByIdRecibo(idRecibo);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst = new List<OOB.Documento.Entidad.FichaMetodoPago>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Documento.Entidad.FichaMetodoPago()
                        {
                            autoMedioPago = s.autoMedioPago,
                            codigoMedioPago = s.codigoMedioPago,
                            descMedioPago = s.descMedioPago,
                            lote = s.lote,
                            montoRecibido = s.montoRecibido,
                            referencia = s.referencia,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }

    }

}