using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{
    abstract public class baseImprimirReporteCuadreCajaTicket: baseImprimirReporteCuadreCaja, IReporteCuadreCajaTicket
    {
        protected ITicket _ticket;
        //
        public baseImprimirReporteCuadreCajaTicket()
            :base()
        {
        }
        public void setControladorTickera(object ctr)
        {
            _ticket.setControlador(ctr);
        }
        public void setTicket(ITicket ticket)
        {
            _ticket = ticket;
        }
    }
}