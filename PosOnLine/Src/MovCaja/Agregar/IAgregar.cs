using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.MovCaja.Agregar
{
    public interface IAgregar: IGestion, Helpers.IAbandonar, Helpers.IProcesar 
    {
        BindingSource GetTipoMov_Source { get; }
        decimal GetMontoMov { get; }
        decimal GetFactorCambio { get; }
        string GetConcepto { get; }
        string GetDetalles { get; }
        DateTime GetFechaEmision { get;  }
        decimal GetTotalMov { get;  }
        string GetTipoMov_Id { get; }

        void setFechaMov(DateTime fecha);
        void SetMontoMov(decimal monto);
        void setEsDivisa(bool p);
        void setFactorCambio(decimal monto);
        void setConcepto(string desc);
        void setDetalles(string desc);
        void setTipoMov(string id);
        bool GetEsDivisa { get; }

        BindingSource GetMedio_Source { get; }
        string GetMedio_Id { get; }
        void setMedio(string id);
        void setMedioEsDivisa(bool p);
        bool GetMedioEsDivisa { get; }
        void setMontoMedio(decimal monto);
        void setCantMedio(int cnt);
        int GetCantMedio { get;  }
        decimal GetMontoMedio { get; }
        void AceptarMedio();
        BindingSource GetListaMedios_Source { get; }
        void EliminarMedio();
        decimal GetImporteMedio { get;  }
        bool AceptarMedioIsok { get; }
        decimal GetResta { get; }
        void setIdOperadorActual(int id);

        bool AgregarIsOk { get; }
        int IdMovAgregado { get;  }
    }
}