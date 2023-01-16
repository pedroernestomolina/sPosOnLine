using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.MovCaja.Adm
{
    public interface IAdmLista: ILista
    {
        void Subir();
        void Bajar();
        void setAnularMov(int id);
        void Agregar(data ficha);
    }
}