using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdmAnularDoc.Domain.ReglaNegocio
{
    public interface IRule
    {
        bool Permiso();
        void ParaAnularDoc(Models.DataAnular data);
    }
}
