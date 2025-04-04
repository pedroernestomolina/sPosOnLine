using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{
    abstract public class baseDocumentoNew : IDocumentoNew
    {
        protected data _ds;
        protected Bitmap _imagenQR;
        protected dataQR _dataQR;
        //
        public baseDocumentoNew()
        {
        }
        public void setData(data ds)
        {
            _ds = ds;
        }
        abstract public void setImprimirQR(dataQR dat);
        public void ImprimirDoc()
        {
            Imprimir();
        }
        public void ImprimirCopiaDoc()
        {
            Imprimir();
        }
        abstract protected void Imprimir();
        //
        protected void generarQR(string dat)
        {
            var _url = dat;
            QrEncoder qrencoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrcode = new QrCode();
            qrencoder.TryEncode(_url, out qrcode);
            GraphicsRenderer render = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();
            render.WriteToStream(qrcode.Matrix, System.Drawing.Imaging.ImageFormat.Png, ms);
            var _imagenTemporal = new Bitmap(ms);
            _imagenQR = new Bitmap(_imagenTemporal, new Size(new Point(100, 100)));
        }
    }
}