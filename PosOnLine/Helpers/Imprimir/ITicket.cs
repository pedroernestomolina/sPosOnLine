using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{
    public interface ITicket
    {
        DatosNegocio Negocio { get; set; }
        DatosCliente Cliente { get; set; }
        DatosDocumento Documento { get; set; }
        //
        void Imprimir();
        void Reporte(IEnumerable<string> lineas);
        void setControlador(object ctr);
    }
}
