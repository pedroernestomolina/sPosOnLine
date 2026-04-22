using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src
{
    public interface IListaDe
    {
        object Get_SourceData { get; }
        int Get_ItemsEncontrados { get; }
    }
}