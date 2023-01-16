using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.MovCaja.Agregar
{
    public class ImpAgregar: IAgregar
    {
        private int _idNuevoMov;
        private dataAgregar _data;
        private dataMedios _dataMedios;
        private medio _medio;
        private Helpers.Opcion.IOpcion _gTipoMov;
        private Helpers.Opcion.IOpcion _gMedio;

        public DateTime GetFechaEmision { get { return _data.FechaEmision; } }
        public BindingSource GetTipoMov_Source { get { return _gTipoMov.Source; } }
        public decimal GetMontoMov { get { return _data.Monto; } }
        public decimal GetFactorCambio { get { return _data.FactorCambio; } }
        public string GetConcepto { get { return _data.Concepto; } }
        public string GetDetalles { get { return _data.Detalles; } }
        public decimal GetTotalMov { get { return _data.TotalMov; } }
        public string GetTipoMov_Id { get { return _gTipoMov.GetId; } }
        public bool GetEsDivisa { get { return _data.EsDivisa; } }

        public ImpAgregar()
        {
            _idNuevoMov = -1;
            _data= new dataAgregar();
            _dataMedios = new dataMedios();
            _medio = new medio();
            _gTipoMov = new Helpers.Opcion.Gestion();
            _gMedio = new Helpers.Opcion.Gestion();
        }

        public void Inicializa()
        {
            _idNuevoMov = -1;
            _data.Inicializa();
            _dataMedios.Inicializa();
            _medio.Inicializa();
            _gTipoMov.Inicializa();
            _gMedio.Inicializa();
            _aceptarMedioIsOk = false;
        }
        AgregarFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AgregarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool _procesarIsOk;
        public bool ProcesarIsOK { get { return _procesarIsOk; } }
        public void Procesar()
        {
            _idNuevoMov = -1;
            _procesarIsOk = false;
            try
            {
                _data.IsOk();
                _dataMedios.IsOk();
                if (Math.Abs(GetResta) > 0m)
                {
                    throw new Exception("TOTAL DE MEDIOS NO PUEDE SER SUPERIOR AL MONTO DEL MOVIMIENTO");
                }
                var r = MessageBox.Show("Agregar Movimiento de Caja ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (r == DialogResult.Yes)
                {
                    _procesarIsOk = Registrar();
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        private bool _abandonarIsOk;
        public bool AbandonarIsOK { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk= Helpers.Msg.Abandonar();
        }

        private bool CargarData()
        {
            var r01 = Sistema.MyData.Configuracion_FactorDivisa();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _data.FactorCambio = r01.Entidad;
            _dataMedios.setFactorCambio(r01.Entidad);
            _medio.setFactorCambio(r01.Entidad);

            var _lst = new List<Helpers.ficha>();
            _lst.Add(new Helpers.ficha() { id = "01", codigo = "", desc = "ENTRADA" });
            _lst.Add(new Helpers.ficha() { id = "02", codigo = "", desc = "SALIDA" });
            _gTipoMov.setData(_lst);
            setTipoMov("01");

            var filtroOOB = new OOB.Sistema.MedioPago.Lista.Filtro();
            var r02 = Sistema.MyData.Sistema_MedioPago_GetLista(filtroOOB);
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            var _lst2= new List<Helpers.ficha>();
            foreach (var rg in r02.ListaD) 
            {
                _lst2.Add(new Helpers.ficha() { id = rg.id, codigo = rg.codigo, desc = rg.nombre });
            }
            _gMedio.setData(_lst2);

            return true;
        }

        public void setFechaMov(DateTime fecha)
        {
            _data.FechaEmision = fecha;
        }
        public void SetMontoMov(decimal monto)
        {
            _data.Monto = monto;
        }
        public void setEsDivisa(bool p)
        {
            _data.EsDivisa = p;
        }
        public void setFactorCambio(decimal monto)
        {
            _data.FactorCambio = monto;
            _dataMedios.setFactorCambio(monto);
            _medio.setFactorCambio(monto);
        }
        public void setConcepto(string desc)
        {
            _data.Concepto = desc;
        }
        public void setDetalles(string desc)
        {
            _data.Detalles = desc;
        }
        public void setTipoMov(string id)
        {
            _gTipoMov.setFicha(id);
            _data.TipoMov = _gTipoMov.Item;
        }

        private bool _aceptarMedioIsOk;
        public bool AceptarMedioIsok { get { return _aceptarMedioIsOk; } }
        public BindingSource GetListaMedios_Source { get { return _dataMedios.Source; } }
        public bool GetMedioEsDivisa { get { return _medio.EsDivisa; } }
        public int GetCantMedio { get { return _medio.Cant; } }
        public decimal GetMontoMedio { get { return _medio.Monto; } }
        public BindingSource GetMedio_Source { get { return _gMedio.Source; } }
        public string GetMedio_Id { get { return _gMedio.GetId; } }
        public decimal GetImporteMedio { get { return _medio.Importe; } }
        public decimal GetResta { get { return GetTotalMov-_dataMedios.Monto; } }

        public void setMedio(string id)
        {
            _gMedio.setFicha(id);
            _medio.Ficha = _gMedio.Item;
        }
        public void setMedioEsDivisa(bool p)
        {
            _medio.EsDivisa = p;
        }
        public void setMontoMedio(decimal monto)
        {
            _medio.Monto = monto;
        }
        public void setCantMedio(int cnt)
        {
            _medio.Cant = cnt;
        }
        public void AceptarMedio()
        {
            _aceptarMedioIsOk = false;
            if (_medio.Ficha == null) 
            {
                return;
            }
            if (_medio.Importe <= 0m) 
            {
                return;
            }
            _dataMedios.Agregar(_medio);
            _medio = new medio();
            _gMedio.setFicha("");
            _aceptarMedioIsOk = true;
            _medio.setFactorCambio(_data.FactorCambio);
        }
        public void EliminarMedio()
        {
            _dataMedios.EliminarMedio();
        }

        private bool  Registrar()
        {
            var _tipoMov="S";
            var _signoMov=-1;
            if (_data.TipoMov.id=="01")
            {
                _tipoMov="E";
                _signoMov=1;
            }
            var fichaOOB = new OOB.MovCaja.Registrar.Ficha()
            {
                ConceptoMov = _data.Concepto,
                DetalleMov = _data.Detalles,
                FactorCambio = _data.FactorCambio,
                FechaMov = _data.FechaEmision,
                IdOperador = _data.IdOperador,
                MontoDivisaMov = _data.MontoDivisa,
                MontoMov = _data.TotalMov,
                SignoMov = _signoMov,
                TipoMov = _tipoMov,
            };
            var lstDet = new List<OOB.MovCaja.Registrar.Detalle>();
            foreach (var rg in _dataMedios.Medios) 
            {
                var nr = new OOB.MovCaja.Registrar.Detalle()
                {
                    autoMedio = rg.Ficha.id,
                    cntDivisa = rg.Cant,
                    codigoMedio = rg.Ficha.codigo,
                    descMedio = rg.Ficha.desc,
                    monto = rg.Importe,
                };
                lstDet.Add(nr);
            }
            fichaOOB.Detalles = lstDet;
            try
            {
                var r01 = Sistema.MyData.MovCaja_Registrar(fichaOOB);
                _idNuevoMov = r01.Id;
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        public void setIdOperadorActual(int id)
        {
            _data.IdOperador = id;
        }

        public bool AgregarIsOk { get { return _procesarIsOk; } }
        public int IdMovAgregado { get { return _idNuevoMov; } }
    }
}