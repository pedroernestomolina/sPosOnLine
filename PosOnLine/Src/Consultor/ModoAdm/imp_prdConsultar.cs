using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Consultor.ModoAdm
{
    public class imp_prdConsultar : IPrdConsultar
    {
        private sData _miData;
        private IExistencia _existencia;
        private IVta _vta1;
        private IVta _vta2;
        private IVta _vta3;

        public string GetNombrePrd { get { return _miData.nombrePrd; } }
        public string GetDepartamento { get { return _miData.departamento; } }
        public string GetGrupo { get { return _miData.grupo; } }
        public string GetMarca { get { return _miData.marca; } }
        public string GetModelo { get { return _miData.modelo; } }
        public string GetReferencia { get { return _miData.referencia; } }
        public string GetPasillo { get { return _miData.pasillo; } }
        public string GetCodigoPrd { get { return _miData.codigoPrd; } }
        public string GetCodigoPlu { get { return _miData.codigoPlu; } }
        public string GetCodigoBarra { get { return _miData.codigoBarra; } }
        public string GetTasaIvaDescripcion { get { return _miData.tasaIvaDesplegar; } }
        public IExistencia Existencia { get { return _existencia; } }
        public IVta Vta1 { get { return _vta1; } }
        public IVta Vta2 { get { return _vta2; } }
        public IVta Vta3 { get { return _vta3; } }


        public imp_prdConsultar()
        {
            _existencia = new imp_existencia();
            _vta1 = new imp_vta();
            _vta2 = new imp_vta();
            _vta3 = new imp_vta();
        }


        public void Inicializar()
        {
            _existencia.Inicializar();
            _vta1.Inicializar();
            _vta2.Inicializar();
            _vta3.Inicializar();
        }

        public void setData(sData data)
        {
            _miData = data;
            _existencia.setData(data.existencia);
            _vta1.setData(data.vta1);
            _vta2.setData(data.vta2);
            _vta3.setData(data.vta3);
        }
    }
}