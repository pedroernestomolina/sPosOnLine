using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosOnLine.Helpers.Imprimir.Fiscal
{
    public class DocumentoNC : IDocumento
    {
        private data _ds;
        private LibFoxFiscal.LibFoxFiscal.IFiscal _fiscal;


        public DocumentoNC()
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
                doc.Tipo = LibFoxFiscal.LibFoxFiscal.EnumTipoDocumento.NCredito;
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
            var _ficha = new LibFoxFiscal.LibFoxFiscal.NCredito()
            {
                CargoGlobal = 0m,
                CiRif = _ds.encabezado.CiRifCli,
                Direccion = _ds.encabezado.DireccionCli,
                DsctoGlobal = 0m,
                NombreRazonSocial = _ds.encabezado.NombreCli,
                Telefono = "",
                Monto = _ds.encabezado.Total,
                DocumentoFiscalAfecta = _ds.encabezado.DocumentoAplica,
                FechaDocumentoAfecta = _ds.encabezado.DocumentoFecha.Date.ToShortDateString(),
                SerialFiscalDocumentoAfecta = _ds.encabezado.DocumentoAplica_SerialFiscal,
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
            var _mp = new LibFoxFiscal.LibFoxFiscal.FacturaMedioPago()
            {
                Monto = _ds.metodoPago.Sum(s => s.monto),
                Posicion = 1,
            };
            _lstMP.Add(_mp);
            _ficha.Detalles = _lstDet;
            _ficha.MediosPago = _lstMP;
            try
            {
                var r01 = _fiscal.NCredito(_ficha);
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