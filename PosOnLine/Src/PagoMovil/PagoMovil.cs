using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.PagoMovil
{
    
    public class PagoMovil: IPagoMovil
    {

        private bool _abandonarIsOk;
        private bool _procesarIsOk;
        private string _nombre;
        private string _ciRif;
        private string _telefono;
        private decimal _monto;
        private Helpers.Opcion.IOpcion _gAgencia;
        private Agencia.Agregar.IAgregar _gAgregarAgencia;


        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool IsOk { get { return _procesarIsOk; } }
        public decimal GetMontoPagoMovil { get { return _monto; } }
        public string GetNombrePersona { get { return _nombre.Trim(); } }
        public string GetCiRifPersona { get { return _ciRif.Trim(); } }
        public string GetTelefonoPersona { get { return _telefono.Trim(); } }
        public BindingSource GetAgenciaSource { get { return _gAgencia.Source; } }


        public PagoMovil() 
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _nombre = "";
            _ciRif = "";
            _telefono = "";
            _monto = 0m;
            _gAgencia = new Helpers.Opcion.Gestion();
            _gAgregarAgencia = new Agencia.Agregar.Agregar();
        }

        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _nombre = "";
            _ciRif = "";
            _telefono = "";
            _monto = 0m;
            _gAgencia.Inicializa();
        }

        PagoMovilFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new PagoMovilFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void AbandonarFicha()
        {
            _abandonarIsOk = false;
            var msg = MessageBox.Show("Abandonar Ficha ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                _abandonarIsOk = true;
            }
        }
        public void ProcesarFicha()
        {
            _procesarIsOk = false;
            var msg = MessageBox.Show("Procesar Movimiento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                if (_nombre.Trim() == "") 
                {
                    Helpers.Msg.Alerta("CAMPO NOMBRE NO PUEDE ESTAR VACIO");
                    return ;
                }
                if (_ciRif.Trim() == "")
                {
                    Helpers.Msg.Alerta("CAMPO CIRIF NO PUEDE ESTAR VACIO");
                    return;
                }
                if (_telefono.Trim() == "")
                {
                    Helpers.Msg.Alerta("CAMPO TELEFONO NO PUEDE ESTAR VACIO");
                    return;
                }
                if (_gAgencia.Item  == null)
                {
                    Helpers.Msg.Alerta("CAMPO AGENCIA NO PUEDE ESTAR VACIO");
                    return;
                }
                _procesarIsOk = true;
            }
        }
        public void setDatosPagoMovil(OOB.Cliente.Entidad.Ficha ent, decimal monto)
        {
            if (ent!=null)
            {
                _nombre = ent.Nombre;
                _ciRif = ent.CiRif;
                _telefono = ent.Telefono;
            }
            _monto = monto;
        }
        public void setNombre(string p)
        {
            _nombre = p;
        }
        public void setCiRif(string p)
        {
            _ciRif = p;
        }
        public void setTelefono(string p)
        {
            _telefono = p;
        }
        public void setAgencia(string id)
        {
            _gAgencia.setFicha(id);
        }


        private bool CargarData()
        {
            var rt = true;

            var filtro = new OOB.Agencia.Lista.Filtro();
            var r01 = Sistema.MyData.Agencia_GetLista(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _gAgencia.Limpiar();
            var lst = new List<Helpers.ficha>();
            foreach (var rg in r01.ListaD.OrderBy(o => o.nombre).ToList())
            {
                lst.Add(new Helpers.ficha() { id = rg.auto, codigo = "", desc = rg.nombre });
            }
            _gAgencia.setData(lst);

            return rt;
        }

        public data Data()
        {
            return new data()
            {
                autoAgencia = _gAgencia.GetId,
                ciRif = _ciRif,
                nombre = _nombre,
                telefono = _telefono,
                monto= _monto,
            };
        }


        public void AgregarAgencias()
        {
            _gAgregarAgencia.Inicializa();
            _gAgregarAgencia.Inicia();
            if (_gAgregarAgencia.IsOk) 
            {
                var ficha = new OOB.Agencia.Agregar.Ficha()
                {
                    nombre = _gAgregarAgencia.GetAgencia,
                    codSucursal = Sistema.Sucursal.codigo,
                };
                var r01 = Sistema.MyData.Agencia_Agregar(ficha);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var filtro = new OOB.Agencia.Lista.Filtro();
                var r02 = Sistema.MyData.Agencia_GetLista(filtro);
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                }
                _gAgencia.Limpiar();
                var lst = new List<Helpers.ficha>();
                foreach (var rg in r02.ListaD.OrderBy(o => o.nombre).ToList())
                {
                    lst.Add(new Helpers.ficha() { id = rg.auto, codigo = "", desc = rg.nombre });
                }
                _gAgencia.setData(lst);
            }
        }

    }

}