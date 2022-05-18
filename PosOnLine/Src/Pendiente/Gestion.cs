using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pendiente
{
    
    public class Gestion
    {

        
        private List<data> _ldata;
        private BindingList<data> _bl;
        private BindingSource _bs;
        private bool _abrirCtaPendienteIsOk;
        private data _ctaPendiente;


        public int CntCtasPendientes { get { return CtasPendientes(); } }
        public BindingSource Source { get { return _bs; } }
        public bool AbrirCtaPendienteIsOk { get { return _abrirCtaPendienteIsOk; } }
        public data CtaPediente { get { return _ctaPendiente; } }


        public Gestion()
        {
            _ldata= new List<data>();
            _bl= new BindingList<data>(_ldata);
            _bs= new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializar() 
        {
            _abrirCtaPendienteIsOk = false;
            _ctaPendiente = null;
        }

        AbrirPendienteFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new AbrirPendienteFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var filtro = new OOB.Pendiente.Lista.Filtro(); 
            if (!Sistema.ModoAbrirDocPendOtrosUsuarios) 
            {
                filtro.idOperador = Sistema.PosEnUso.id; 
            };
            var r01 = Sistema.MyData.Pendiente_Lista(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _bl.Clear();
            foreach (var it in r01.ListaD) 
            {
                _bl.Add(new data(it));
            }

            return rt;
        }


        public bool DejarPendiente()
        {
            var rt = false;

            var msg = MessageBox.Show("Dejar Cuenta En Pendiente ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                return true;
            }

            return rt;
        }

        private int CtasPendientes()
        {
            var rt = 0;
            int idPosUso = -1;

            if (!Sistema.ModoAbrirDocPendOtrosUsuarios)
                idPosUso = Sistema.PosEnUso.id;

            var r01 = Sistema.MyData.Pendiente_CtasPendientes(idPosUso);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
            }
            else
            {
                rt = r01.Entidad;
            }

            return rt;
        }

        public void AbrirCta()
        {
            _abrirCtaPendienteIsOk = false;

            if (_bs.Current != null) 
            {
                var it = (data)_bs.Current;
                var msg = MessageBox.Show("Abrir Cuenta Pendiente ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == System.Windows.Forms.DialogResult.Yes)
                {
                    var r01 = Sistema.MyData.Pendiente_AbrirCta(it.Ficha.id, Sistema.PosEnUso.id);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _abrirCtaPendienteIsOk = true;
                    _ctaPendiente = it;
                }
            }

        }

    }

}