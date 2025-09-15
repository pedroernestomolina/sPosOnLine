using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.Domain.Models
{
    public class MedioPago: _Domain.Models.MedioPago, LibUtilitis.Opcion.IData
    {
        // PARA CONTROL ComboBox
        public string codigo { get { return codigoMp; } set{} }
        public string desc { get { return nombreMp; } set{} }
        public string id { get { return idMp; } set {} }
    }
}