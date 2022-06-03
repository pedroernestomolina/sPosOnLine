using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Documento.Agregar.NotaCredito
{
    
    public class FichaCxCDocumento: BaseCxCDocumento
    {

        public FichaCxCDocumento()
        {
            Id = 1;
            TipoDocumento = "";
            Documento = "";
            Importe = 0.0m;
            Operacion = "";
            Dias = 0;
            CastigoP = 0.0m;
            ComisionP = 0.0m;
            CierreFtp = "";
        }

    }

}