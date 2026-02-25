using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PosBuscarProducto.vm
{
    public interface IBuscarPrd
    {
        void setIdDepositoManejar(string p);
        void setTarifaPrecio(string _precioManejar);

        Domain.Models.BusquedaResult
            Execute(string cadena);
    }
}
