using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
namespace PosOnLine.Helpers.Imprimir.Fiscal
{
    public class Documento: IDocumento
    {
        private data _ds;
        private LibFoxFiscal.LibFoxFiscal.IFiscal _fiscal;


        public Documento()
        {
        }


        public void ImprimirDoc()
        {
            Imprimir();
        }
        public void ImprimirCopiaDoc()
        {
            try
            {
                var doc = new LibFoxFiscal.LibFoxFiscal.ReImprimir();
                doc.Documento = _ds.encabezado.DocumentoNro;
                doc.Tipo = LibFoxFiscal.LibFoxFiscal.EnumTipoDocumento.Factura;
                var f01 = _fiscal.ReImprimirDocumento(doc);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }  
        }


        public void setData(data ds)
        {
            _ds = ds;
        }
        public void setImprimirQR(dataQR dat)
        {
        }


        //
        public bool IsModoTicket { get { return false; } }
        public bool IsModoFiscal { get { return true; } }
        public void setControlador(System.Drawing.Printing.PrintPageEventArgs e)
        {
        }
        public void setEmpresa(OOB.Sistema.Empresa.Ficha ficha)
        {
        }


        private void Imprimir()
        {
            var _ficha = new LibFoxFiscal.LibFoxFiscal.Factura()
            {
                CargoGlobal = 0m,
                CiRif = _ds.encabezado.CiRifCli,
                CondicionPago = _ds.encabezado.DocumentoCondicionPago,
                Direccion = _ds.encabezado.DireccionCli,
                DsctoGlobal = 0m,
                Estacion = _ds.encabezado.EstacionEquipo,
                NombreRazonSocial = _ds.encabezado.NombreCli,
                Telefono = "",
                Total = _ds.encabezado.Total,
                Usuario = _ds.encabezado.Usuario,
            };
            var _lstDet = new List<LibFoxFiscal.LibFoxFiscal.IFacturaDetalles>();
            foreach (var rg in _ds.item)
            {
                var _det = new LibFoxFiscal.LibFoxFiscal.FacturaDetalles()
                {
                    Cantidad = rg.Cantidad,
                    Cargo = 0m,
                    Codigo = "",
                    Descripcion = rg.NombrePrd,
                    Dscto = 0m,
                    Precio = rg.Precio,
                    Tasa = rg.TasaIva == 0m ? (int?)null : 1,
                };
                _lstDet.Add(_det);
            }
            var _lstMP = new List<LibFoxFiscal.LibFoxFiscal.IFacturaMedioPago>();
            if (_ds.encabezado.AplicaIGTF)
            {
                //
                //APLICA IGTF SE ACUMULA TODO LO QUE NO ES DIVISA EN UN SOLO MEDIO DE PAGO Y SE RESTA EL MONTO DEL IGTF
                var _mp1 = new LibFoxFiscal.LibFoxFiscal.FacturaMedioPago()
                {
                    Monto = _ds.metodoPago.Where(w=>w.esDivisa==false).Sum(s => s.monto),
                    Posicion = 1,
                };
                _mp1.Monto -= _ds.encabezado.MontoIGTF;
                _lstMP.Add(_mp1);

                //
                //APLICA IGTF SE ACUMULA TODO LO QUE ES DIVISA EN UN SOLO MEDIO DE PAGO Y SE SUMA EL MONTO DEL IGTF
                var _mp2 = new LibFoxFiscal.LibFoxFiscal.FacturaMedioPago()
                {
                    Monto = _ds.metodoPago.Where(w => w.esDivisa).Sum(s => s.monto),
                    Posicion = 21,
                };
                _mp2.Monto += _ds.encabezado.MontoIGTF;
                if (_mp2.Monto > 0) 
                {
                    _lstMP.Add(_mp2);
                }
            }
            else 
            {
                //SI NO APLICA IGTF SE ACUMULA TODO EN UN SOLO MEDIO DE PAGO
                var _mp = new LibFoxFiscal.LibFoxFiscal.FacturaMedioPago()
                {
                    Monto = _ds.metodoPago.Sum(s => s.monto),
                    Posicion = 1,
                };
                _lstMP.Add(_mp);
            }
            _ficha.Detalles = _lstDet;
            _ficha.MediosPago = _lstMP;
            try
            {
                var r01 = _fiscal.Factura(_ficha);
                if (r01.Resultado == LibFoxFiscal.Resultado.EnumResultado.ERROR)
                {
                    throw new Exception(r01.MensajeError);
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        public void setHndFiscal(LibFoxFiscal.LibFoxFiscal.IFiscal hndFiscal)
        {
            _fiscal = hndFiscal;
        }
    }
}
*/