using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Lista.ModoAdm
{
    public interface IDataPrd
    {
        IEmpVta EmpVta1 { get; }
        IEmpVta EmpVta2 { get; }
        IEmpVta EmpVta3 { get; }
        IInv Inv { get; }
        string GetAutoPrd { get; }
        string GetDesc { get; }
        string Codigo { get; }
        string Nombre { get; }
        decimal CantidadEx { get; }
        string PLU { get; }
    }
}