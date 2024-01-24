using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosVerificador.Src.Principal
{

    class Principal: IPrincipal
    {


        private bool _verificacionIsOk;
        private bool _abandonarIsOk;
        private string _codigo;
        private string _msgError;
        private Identificacion.IIdentifica _gLogin;
        private SolicitarPermiso.ISolicitarPermiso _gPermiso;
        private BindingSource _bs;
        private List<dataItem> _lstData;
        private string _documento;
        private string _cliente;


        public bool IsAbandonarOk { get { return _abandonarIsOk; } }
        public bool LeerCodigoIsOk { get { return _verificacionIsOk; } }
        public string MsgError { get { return _msgError; } }
        public string GetUsuario 
        { 
            get 
            {
                var rt = "";
                if (Sistema.Usuario != null) 
                {
                    rt = Sistema.Usuario.codigo + Environment.NewLine + Sistema.Usuario.nombre;
                }
                return rt;
            }
        }
        public BindingSource Data { get { return _bs; } }
        public string GetDocumento { get { return _documento; } }
        public string GetCliente { get { return _cliente; } }


        public Principal() 
        {
            _codigo = "";
            _msgError = "";
            _abandonarIsOk = false;
            _verificacionIsOk = false;
            _lstData = new List<dataItem>();
            _documento = "";
            _cliente = "";
            _bs = new BindingSource();
            _bs.DataSource = _lstData;
            _gLogin = new Identificacion.Identifica();
            _gPermiso = new SolicitarPermiso.SolicitarPerm();
        }


        public void Inicializa()
        {
            _codigo = "";
            _msgError = "";
            _abandonarIsOk = false;
            _verificacionIsOk = false;
        }


        private PrincipalFrm frm;
        public void Inicia()
        {
            _gLogin.Inicializa();
            _gLogin.Inicia();
            if (_gLogin.IsOk) 
            {
                if (CargarData())
                {
                    if (frm == null)
                    {
                        frm = new PrincipalFrm();
                        frm.setControlador(this);
                    }
                    frm.ShowDialog();
                }
            }
        }
        public void LeerCodigo()
        {
            _verificacionIsOk = false;
            _msgError = "";
            _documento = "";
            _cliente = "";
            if (!string.IsNullOrEmpty(_codigo))
            {
                if (_codigo.Trim().Length >= 17)
                {
                    BuscarCodigo(_codigo);
                }
                else
                {
                    _msgError = "CODIGO A BUSCAR INCORRECTO";
                    //Helpers.Msg.Error("CODIGO A BUSCAR INCORRECTO");
                }
            }
            else 
            {
                _msgError = "CODIGO A BUSCAR INCORRECTO";
                //Helpers.Msg.Error("CODIGO A BUSCAR INCORRECTO");
            }
        }
        public void setCodigo(string cod)
        {
            _codigo = cod;
        }
        public void Abandonar()
        {
            _abandonarIsOk = false;
            var xmsg = "Abandonar Ficha ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                _abandonarIsOk = true;
            }
        }


        private bool CargarData()
        {
            return true;
        }
        private void BuscarCodigo(string _codigo)
        {
            var _id = -1;
            var _autoDoc = _codigo.Substring(7, 10);

            if (int.TryParse(_codigo.Substring(0, 6), out _id))
            {
                if (_id == 0)
                {
                    var r00 = Sistema.MyData.Verificador_GetFichaByAutoDoc(_autoDoc);
                    if (r00.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        _msgError = r00.Mensaje;
                        //Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _id = r00.Id;
                }
                var r01 = Sistema.MyData.Verificador_GetFichaById(_id);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    _msgError = r01.Mensaje;
                    //Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                if (r01.Entidad.Isnulado)
                {
                    //SE ANULO LA VERIFICACION PARA ESTE DOCUMENTO 
                    return;
                }
                if (r01.Entidad.autoDoc != _autoDoc)
                {
                    _msgError = "DOCUMENTO NO CORRESPONDE AL VERIFICADOR";
                    //Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var r02 = Sistema.MyData.Documento_GetFichaById(_autoDoc);
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    _msgError = r02.Mensaje;
                    //Helpers.Msg.Error(r02.Mensaje);
                    return;
                }
                var r03 = Sistema.MyData.Documento_GetDocNCR_Relacionados_ByAutoDoc(_autoDoc);
                if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    _msgError = r03.Mensaje;
                    //Helpers.Msg.Error(r02.Mensaje);
                    return;
                }

                var doc = r02.Entidad;
                var cad = doc.AutoDoc + "-" + doc.CodigoDoc + "-" + doc.NroDoc + "-" + doc.MontoDoc.ToString("n2") + "-" + doc.AutoCierreDoc;
                var cod = _codigo.Substring(7).Trim().ToUpper();
                if (cod != cad)
                {
                    _msgError = "CADENA A VERIFICAR NO CORRESPONDE";
                    //Helpers.Msg.Error("CADENA A VERIFICAR NO CORRESPONDE");
                    return;
                }
                if (r01.Entidad.IsVerificado)
                {
                    _msgError = "DOCUMENTO YA VERIFICADO";
                    //Helpers.Msg.Error("DOCUMENTO YA VERIFICADO");
                    return;
                }
                if (r01.Entidad.autoDoc.Trim().ToUpper() != _autoDoc)
                {
                    _msgError = "DOCUMENTO A VERIFICAR DATOS INCORRECTOS";
                    //Helpers.Msg.Error("DOCUMENTO A VERIFICAR DATOS INCORRECTOS");
                    return;
                }
                if (r02.Entidad.Isnulado)
                {
                    _msgError = "DOCUMENTO A VERIFICAR ANULADO";
                    //Helpers.Msg.Error("DOCUMENTO A VERIFICAR ANULADO");
                    return;
                }
                if (r03.Entidad > 0) // HAY DOCUMENTOS NOTAS DE CREDITO RELACIONADOS
                {
                    _gPermiso.Inicializa();
                    _gPermiso.setMotivoSolicitud("HAY DOCUMENTOS NOTAS DE CREDITO RELACIONADOS");
                    _gPermiso.Inicia();
                    if (_gPermiso.IsOk)
                    {
                        var ficha = new OOB.Usuario.Identificar.Ficha()
                        {
                             codigo=_gPermiso.GetUsuario,
                             clave=_gPermiso.GetPassword,
                        };
                        var rp1 = Sistema.MyData.Usuario_Identifica(ficha);
                        if (rp1.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                        {
                            _msgError = rp1.Mensaje;
                            //Helpers.Msg.Error("DOCUMENTO A VERIFICAR ANULADO");
                            return;
                        }
                    }
                    else 
                    {
                        _msgError = "HAY DOCUMENTOS NOTAS DE CREDITO RELACIONADOS";
                        //Helpers.Msg.Error("DOCUMENTO A VERIFICAR ANULADO");
                        return;
                    }
                }

                //PROCESO DE VERIFICACION 
                var fichaOOB = new OOB.Verificador.Verificar.Ficha()
                {
                    id = _id,
                    estatusVer = "1",
                    usuarioCodVer = Sistema.Usuario.codigo,
                    usuarioNombreVer = Sistema.Usuario.nombre,
                };
                var r04 = Sistema.MyData.Verificador_VerificarFicha(fichaOOB);
                if (r04.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    _msgError = r04.Mensaje;
                    //Helpers.Msg.Error(r03.Mensaje);
                    return;
                }
                _verificacionIsOk = true;
                _lstData.Clear();
                foreach (var rg in r02.Entidad.Items) 
                {
                    var it = new dataItem()
                    {
                        cnt = rg.cnt,
                        empaqueCont = rg.empaque.Trim() + "/" + rg.empCont.ToString(),
                        prdCod = rg.prdCod,
                        prdDesc = rg.prdDesc,
                    };
                    _lstData.Add(it);
                }
                _documento = r02.Entidad.FechaDoc.ToShortDateString()+", Hora: "+r02.Entidad.HoraDoc+Environment.NewLine+r02.Entidad.NroDoc+", Por Bs: "+r02.Entidad.MontoDoc.ToString("n2");
                _cliente = r02.Entidad.CiRif+Environment.NewLine+r02.Entidad.RazonSocial;
                _bs.CurrencyManager.Refresh();
            }
        }

        public void ReporteDocumentosVerificados()
        {
            var filtro = new OOB.Reportes.Filtro();
            var r01 = Sistema.MyData.Reportes_DocVerificados(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            if (r01.ListaD != null) 
            {
                if (r01.ListaD.Count > 0) 
                {
                    var _lst = r01.ListaD.Select(s =>
                    {
                        var nr = new Reportes.DocVerificados.data()
                        {
                            docNumero = s.docNro,
                            docFecha= s.docFecha,
                            docMonto= s.docMonto,
                            docMontoDivisa= s.docMontoDivisa,
                            docCliente= s.docCiRif+Environment.NewLine+s.docRazonSocial,
                            docIsAnulado = s.docIsAnulado,
                            isVerificado= s.IsVerificado,
                        };
                        return nr;
                    }).ToList();

                    Reportes.DocVerificados.IDocVerificados rp1 = new Reportes.DocVerificados.Movimiento();
                    rp1.setData(_lst);
                    rp1.Generar();
                }
            }
        }

        public void DarAltaTodosDocumento()
        {
            var xmsg = "Dar de Alta A Todos Los Doucmentos Generados ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                try
                {
                    var r01 = Sistema.MyData.Verificador_DarAltaTodosLosDocumentos();
                    Helpers.Msg.OK("TODOS LOS DOCUMENTOS FUERON DADOS DE ALTA");
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
    }
}