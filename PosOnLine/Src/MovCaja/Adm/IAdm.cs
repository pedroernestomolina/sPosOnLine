using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.MovCaja.Adm
{
    public interface IAdm: IGestion, Helpers.IAbandonar
    {
        int GetData_CantItem { get; }
        BindingSource GetData_Source { get; }
        void setIdOperadorActual(int id);
        void Subir();
        void Bajar();
        void AnularMov();
        void AgregarMov();
        void ViewMov();
    }
}