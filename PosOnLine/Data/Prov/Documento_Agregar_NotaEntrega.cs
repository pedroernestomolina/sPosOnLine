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
            Documento_Agregar_NotaEntrega(OOB.Documento.Agregar.NotaEntrega.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaAuto();
            //
            var fichaDTO = new DtoLibPos.Documento.Agregar.NotaEntrega.Ficha()
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
            };
            //
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
            //
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
            //
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
            //
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
            //
            var r01 = MyData.Documento_Agregar_NotaEntrega(fichaDTO);
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
