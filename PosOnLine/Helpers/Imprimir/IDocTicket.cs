using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{
    public interface IDocumentoTicket: IDocumentoNew
    {
        void setControladorTickera(object ctr);
        void setTicket(ITicket ticket);
    }
}
