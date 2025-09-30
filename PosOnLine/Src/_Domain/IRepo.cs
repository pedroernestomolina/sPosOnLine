using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src._Domain
{
    public interface IRepo
    {
        void setIdResumen(int id);
        void Generar();
    }
}
