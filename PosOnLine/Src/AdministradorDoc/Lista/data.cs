using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdministradorDoc.Lista
{
    public class data
    {
        private OOB.Documento.Lista.Ficha it;
        //
        public string idDocumento { get { return it.Id; } }
        public string FechaHora { get { return it.FechaEmision.ToShortDateString()+", "+it.HoraEmision; } }
        public string Serie { get { return it.Serie; } }
        public string Documento { get { return it.DocNumero; } }
        public string DocNombre { get { return it.DocNombre; } }
        public string Renglones { get { return it.Renglones.ToString().Trim(); } }
        public string CiRif { get { return it.CiRif; } }
        public string NombreRazonSocial { get { return it.NombreRazonSocial; } }
        public decimal Monto { get { return it.Monto * it.DocSigno; } }
        public decimal MontoDivisa { get { return it.MontoDivisa * it.DocSigno; } }
        public bool IsAnulado { get { return !it.IsActivo; } }
        public bool IsFiscal { get { return it.IsFiscal; } }
        public string DocCodigo { get { return it.DocCodigo; } }
        public string EstatusDoc { get { return IsAnulado ? "ANULADO" : ""; } }
        public int Signo { get { return it.DocSigno; } }
        public Enumerados.enumTipoDoc DocTipo { get { return tipoDocumento(); } }
        //
        public data(OOB.Documento.Lista.Ficha it)
        {
            this.it = it;
        }
        public void setAnularDoc()
        {
            it.Estatus = "1";
        }
        //
        private Enumerados.enumTipoDoc tipoDocumento()
        {
            var tp = Enumerados.enumTipoDoc.SinDefinir;
            switch (DocCodigo.Trim().ToUpper())
            {
                case "01":
                    tp = Enumerados.enumTipoDoc.Factura;
                    break;
                case "02":
                    tp = Enumerados.enumTipoDoc.NotaDebito;
                    break;
                case "03":
                    tp = Enumerados.enumTipoDoc.NotaCredito;
                    break;
                case "04":
                    tp = Enumerados.enumTipoDoc.NotaEntrega;
                    break;
            }
            return tp;
        }
    }
}