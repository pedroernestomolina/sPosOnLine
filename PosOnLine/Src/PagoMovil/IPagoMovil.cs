using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.PagoMovil
{
    
    public interface IPagoMovil: IGestion
    {

        bool AbandonarIsOk { get; }
        bool ProcesarIsOk { get; }
        bool IsOk { get; }


        void AbandonarFicha();
        void ProcesarFicha();
        void setDatosPagoMovil(OOB.Cliente.Entidad.Ficha _entCliente, decimal monto);


        decimal GetMontoPagoMovil { get; }
        string GetNombrePersona { get; }
        string GetCiRifPersona { get; }
        string GetTelefonoPersona { get; }
        BindingSource GetAgenciaSource { get; }


        void setNombre(string p);
        void setCiRif(string p);
        void setTelefono(string p);
        void setAgencia(string id);
        data Data();

    }

}