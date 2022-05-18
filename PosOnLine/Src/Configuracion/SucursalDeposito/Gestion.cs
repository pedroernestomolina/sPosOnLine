using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Configuracion.SucursalDeposito
{
    
    public class Gestion
    {

        private data _cnf;
        private bool _configuracionIsOk;
        private OOB.Configuracion.Entidad.Ficha _cnfActual;
        private List<OOB.Deposito.Entidad.Ficha> LDeposito;
        private List<OOB.Sucursal.Entidad.Ficha> LSucursal;
        private BindingSource bs_Sucursal;
        private BindingSource bs_Deposito;


        public BindingSource _bs_Sucursal { get { return bs_Sucursal; } }
        public BindingSource _bs_Deposito { get { return bs_Deposito; } }
        public string AutoSucursal { get { return _cnfActual.idSucursal; } }
        public string AutoDeposito { get { return _cnfActual.idDeposito; } }
        public bool ConfiguracionIsOk { get { return _configuracionIsOk; } }


        public Gestion()
        {
            _cnf = new data();
            _configuracionIsOk = false;
            LSucursal = new List<OOB.Sucursal.Entidad.Ficha>();
            LDeposito = new List<OOB.Deposito.Entidad.Ficha>();
            bs_Sucursal = new BindingSource();
            bs_Deposito = new BindingSource();
            bs_Sucursal.DataSource = LSucursal;
            bs_Deposito.DataSource = LDeposito;
        }


        public void Inicializa()
        {
            _configuracionIsOk = false;
        }

        SucursalDeposito.CnfSucDepFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new CnfSucDepFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = false;

            var r01 = Sistema.MyData.Configuracion_Pos_GetFicha();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return rt;
            }
            _cnfActual = r01.Entidad;

            var r09 = Sistema.MyData.Sucursal_GetLista();
            if (r09.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r09.Mensaje);
                return rt;
            }
            LSucursal.Clear();
            LSucursal.AddRange(r09.ListaD.OrderBy(o => o.nombre).ToList());
            
            return true;
        }

        public void setSucursal(string v)
        {
            LDeposito.Clear();
            var ent = LSucursal.FirstOrDefault(f => f.id == v);
            _cnf.setSucursal(ent);
            if (ent != null)
            {
                var filtro = new OOB.Deposito.Lista.Filtro() { PorCodigoSuc = ent.codigo, };
                var r01 = Sistema.MyData.Deposito_GetLista(filtro); ;
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                LDeposito.AddRange(r01.ListaD);
            }
            _bs_Deposito.CurrencyManager.Refresh();
        }

        public void setDeposito(string v)
        {
            var ent = LDeposito.FirstOrDefault(f => f.id == v);
            _cnf.setDeposito(ent);
        }

        public void Procesar()
        {
            if (!Helpers.PassWord.PassWIsOk(""))
            {
                return;
            }

            _configuracionIsOk = false;
            if (_cnf.ValidarSucursalDepositoIsOk())
            {
                var msg = MessageBox.Show("Guardar Configuración ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var ficha = new OOB.Configuracion.CambioSucursalDeposito.Ficha()
                    {
                        idDeposito = _cnf.Deposito.id,
                        idSucursal = _cnf.Sucursal.id,
                    };
                    var r01 = Sistema.MyData.Configuracion_Pos_CambioSucursalDeposito(ficha);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _configuracionIsOk = true;
                }
            }
        }

    }

}