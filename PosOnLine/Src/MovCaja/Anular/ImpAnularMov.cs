using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.MovCaja.Anular
{
    public class ImpAnularMov: IAnularMov
    {
        private Src.Anular.IAnular _gAnular;
        private int _idMovAnular;
        private int _idOperador;
        private bool _anularMovIsOk;

        public bool AnularMovCajaIsOk { get { return _anularMovIsOk; } }

        public ImpAnularMov(Src.Anular.IAnular ctr)
        {
            _idMovAnular = -1;
            _idOperador = -1;
            _anularMovIsOk = false;
            _gAnular = ctr;
        }
        public void Inicializa()
        {
            _idMovAnular = -1;
            _idOperador = -1;
            _anularMovIsOk = false;
            _gAnular.Inicializa();
        }
        public void Inicia()
        {
            _gAnular.Inicia();
            if (_gAnular.ProcesarIsOK) 
            {
                AnularMovimiento(_gAnular.GetMotivo);
            }
        }
        public void setMovAnular(int id)
        {
            _idMovAnular = id;
        }
        public void setIdOperadorActual(int id)
        {
            _idOperador = id;
        }

        private void AnularMovimiento(string desc)
        {
            _anularMovIsOk = false;
            var msg = MessageBox.Show("Estas Seguro De Anular Este Movimiento ?", "** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.No)
            {
                return;
            }
            var fichaOOB = new OOB.MovCaja.Anular.Ficha()
            {
                AutoUsuAut = Sistema.Usuario.id,
                CodigoUsuAut = Sistema.Usuario.codigo,
                IdMovimiento = _idMovAnular,
                IdOperador = _idOperador,
                Motivo = desc,
                NombreUsuAut = Sistema.Usuario.nombre,
            };
            try
            {
                var r = Sistema.MyData.MovCaja_Anular(fichaOOB);
                _anularMovIsOk = true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}