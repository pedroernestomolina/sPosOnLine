using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers
{
    
    public interface IAbandonar
    {
        
        bool AbandonarIsOK { get; }
        void AbandonarFicha();

    }

}