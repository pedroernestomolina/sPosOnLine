using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AsignarVededor.ModoAdm
{
    public interface IModoAdm: IModo
    {
        Tools.Vendedor.IVendedor Vendedor { get; }
    }
}