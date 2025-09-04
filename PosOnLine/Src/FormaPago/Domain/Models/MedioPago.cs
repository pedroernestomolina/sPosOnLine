using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.Domain.Models
{
    public class MedioPago : LibUtilitis.Opcion.IData
    {
        public string idMp { get; set; }
        public string codigoMp { get; set; }
        public string nombreMp { get; set; }
        public int idCurrencies { get; set; }
        public string codigoCurrencies { get; set; }
        public string nombreCurrencies { get; set; }
        public string simboloCurrencies { get; set; }
        public bool aplicaLoteRef { get; set; }
        public bool aplicaBonoPagoDivisa { get; set; }
        public bool aplicaIGTF { get; set; }
        //
        // PARA CONTROL ComboBox
        public string codigo { get { return codigoMp; } set{} }
        public string desc { get { return nombreMp; } set{} }
        public string id { get { return idMp; } set {} }
    }
}