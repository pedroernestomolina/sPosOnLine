using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.PagoMovil
{
    
    public interface IPagoMovil: IGestion, Helpers.IAbandonar, Helpers.IProcesar
    {

        bool IsOk { get; }


        decimal GetMontoPagoMovil { get; }
        string GetNombrePersona { get; }
        string GetCiRifPersona { get; }
        string GetTelefonoPersona { get; }
        BindingSource GetAgenciaSource { get; }


        void setMontoPagoMovil(decimal monto);
        void setNombre(string p);
        void setCiRif(string p);
        void setTelefono(string p);
        void setAgencia(string id);
        data DataRetornar();


        void AgregarAgencias();

    }

}