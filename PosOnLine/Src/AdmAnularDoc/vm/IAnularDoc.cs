using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdmAnularDoc.vm
{
    public interface IAnularDoc
    {
        bool 
            AnularDoc(string idDoc);
        void 
            Inicializa();
    }
}