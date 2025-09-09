using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.FormaPagoSolicitudPagoMovil.vm
{
    public interface IPagoMovil: IGestion 
    {
        decimal Get_MontoPagoMovil { get; }
        string Get_EntidadNombre { get; }
        string Get_EntidadCiRif { get; }
        string Get_EntidadTelefono { get; }
        object Get_AgenciasSource { get; }
        string Get_AgenciaID { get; }
        bool abandonarFichaIsOK { get; }
        bool solicitudIsOk { get; }
        Domain.Models.DataRetornar Get_DataRetornar { get; }
        //
        void setMontoPagoMovil(decimal monto);
        void setEntidadCliente(FormaPago.Domain.Models.Cliente entidadCliente);
        void setEntidadNombre(string data);
        void setEntidadCiRif(string data);
        void setEntidadTelefono(string data);
        void setAgencia(string id);
        //
        void procesarFicha();
        void abandonarFicha();
    }
}