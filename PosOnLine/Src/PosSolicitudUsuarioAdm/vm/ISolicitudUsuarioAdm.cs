using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PosSolicitudUsuarioAdm.vm
{
    public interface ISolicitudUsuarioAdm
    {
        bool Get_AutorizaPermisoIsOk { get; }
        Domain.Models.UsuarioAutoriza Get_UsuarioAutorizoPermiso { get; }
        //
        void Invoke();
    }
}