using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PosImprimirTicket.Domain
{
    public class converter
    {
        public static Helpers.Imprimir.data
            fromDataToHelperData(Models.Data data)
        {
            var rt = new Helpers.Imprimir.data();
            //
            if (data != null) 
            {
                var e= data.encabezado;
                rt.encabezado = new Helpers.Imprimir.data.Encabezado()
                {
                    AplicaIGTF = e.AplicaIGTF,
                    BonoPorPagoDivisa = e.BonoPorPagoDivisa,
                    CambioDar = e.CambioDar,
                    Cargo = e.Cargo,
                    CargoPorc = e.CargoPorc,
                    CiRifCli = e.CiRifCli,
                    CntDivisaAplicaBonoPorPagoDivisa = e.CntDivisaAplicaBonoPorPagoDivisa,
                    CntDivisaVueltoDivisa = e.CntDivisaVueltoDivisa,
                    CodigoCli = e.CodigoCli,
                    Descuento = e.Descuento,
                    DescuentoPorc = e.DescuentoPorc,
                    DireccionCli = e.DireccionCli,
                    DocumentoAplica = e.DocumentoAplica,
                    DocumentoAplica_Fecha = e.DocumentoAplica_Fecha,
                    DocumentoAplica_SerialFiscal = e.DocumentoAplica_SerialFiscal,
                    DocumentoCondicionPago = e.DocumentoCondicionPago,
                    DocumentoControl = e.DocumentoControl,
                    DocumentoDiasCredito = e.DocumentoDiasCredito,
                    DocumentoFecha = e.DocumentoFecha,
                    DocumentoFechaVencimiento = e.DocumentoFechaVencimiento,
                    DocumentoHora = e.DocumentoHora,
                    DocumentoNombre = e.DocumentoNombre,
                    DocumentoNro = e.DocumentoNro,
                    DocumentoSerie = e.DocumentoSerie,
                    EstacionEquipo = e.EstacionEquipo,
                    FactorCambio = e.FactorCambio,
                    MontoBonoPorPagoDivisa = e.MontoBonoPorPagoDivisa,
                    MontoIGTF = e.MontoIGTF,
                    NombreCli = e.NombreCli,
                    SaldoPendientDiv = e.SaldoPendientDiv,
                    SubTotal = e.SubTotal,
                    TasaIGTF = e.TasaIGTF,
                    TelefonoCli = e.TelefonoCli,
                    Total = e.Total,
                    TotalDivisa = e.TotalDivisa,
                    Usuario = e.Usuario,
                    VueltoDivisa = e.VueltoDivisa,
                    VueltoEfectivo = e.VueltoEfectivo,
                    VueltoPagoMovil = e.VueltoPagoMovil,
                };
                rt.isAnulado = data.isAnulado;
                rt.item = data.item.Select(s =>
                {
                    return new Helpers.Imprimir.data.Item()
                    {
                        Cantidad = s.Cantidad,
                        CodigoPrd = s.CodigoPrd,
                        Contenido = s.Contenido,
                        DepositoCodigo = s.DepositoCodigo,
                        DepositoDesc = s.DepositoDesc,
                        Empaque = s.Empaque,
                        Importe = s.Importe,
                        ImporteDivisa = s.ImporteDivisa,
                        ImporteFull = s.ImporteFull,
                        NombrePrd = s.NombrePrd,
                        Precio = s.Precio,
                        PrecioDivisa = s.PrecioDivisa,
                        TasaIva = s.TasaIva,
                        TotalUnd = s.TotalUnd,
                    };
                }).ToList();
                rt.medidaEmp = data.medidaEmp.Select(s =>
                {
                    return new Helpers.Imprimir.data.MedidaEmp()
                    {
                        cant = s.cant,
                        desc = s.desc,
                        peso = s.peso,
                        volumen = s.volumen,
                    };
                }).ToList();
                rt.metodoPago = data.metodoPago.Select(s =>
                {
                    return new Helpers.Imprimir.data.MetodoPago()
                    {
                        descripcion = s.descripcion,
                        esDivisa = s.esDivisa,
                        monto = s.monto,
                    };
                }).ToList();
                var n = data.negocio;
                rt.negocio = new Helpers.Imprimir.data.Negocio()
                {
                    CiRif = n.CiRif,
                    Direccion = n.Direccion,
                    Nombre = n.Nombre,
                    Telefonos = n.Telefonos,
                };
                rt.precios = data.precios;
           }
            //
            return rt;
        }
        public static Helpers.Imprimir.dataQR
            fromDataToHelperDataQR(Models.Data.qr qr)
        {
            var rt = new Helpers.Imprimir.dataQR();
            //
            if (qr != null)
            {
                rt.autoCierre = qr.idCierre;
                rt.autoDoc = qr.idDoc;
                rt.codDoc = qr.codigoDoc;
                rt.montoDoc = qr.montoDoc;
                rt.numDoc = qr.nroDoc;
            }
            return rt;
        }
    }
}
