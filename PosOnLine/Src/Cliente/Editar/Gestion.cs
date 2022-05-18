using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Cliente.Editar
{
    
    public class Gestion
    {

        private OOB.Cliente.Entidad.Ficha _ficha;
        private data _data;
        private bool _editarIsOk;
        private bool _abandonarCambiosIsOk;


        public string GetCiRif { get { return _data.GetCiRif; } }
        public string GetNombreRazonSocial { get { return _data.GetNombreRazonSocial; } }
        public string GetDireccion { get { return _data.GetDireccion; } }
        public string GetTelefono { get { return _data.GetTelefono; } }
        public bool IsEditarOk { get { return _editarIsOk; } }
        public bool AbandonarCambiosIsOk { get { return _abandonarCambiosIsOk; } }


        public Gestion() 
        {
            _editarIsOk = false;
            _abandonarCambiosIsOk = false;
            _data = new data();
        }


        public void Inicializa() 
        {
            _editarIsOk = false;
            _abandonarCambiosIsOk = false;
        }

        private EditarFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new EditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();

            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void setCliente(OOB.Cliente.Entidad.Ficha cli)
        {
            _data.Limpiar();
            _ficha=cli;
            _data.setCiRif(cli.CiRif);
            _data.setNombreRazonSocial(cli.Nombre);
            _data.setDireccion(cli.DireccionFiscal);
            _data.setTelefono(cli.Telefono);
        }

        public void GuardarCambios()
        {
            if (_ficha == null) 
            {
                return;
            }
            if (_ficha.Id=="")
            {
                return;
            }
            if (_data.GetNombreRazonSocial == "") 
            {
                Helpers.Msg.Error("CAMPO [ NOMBRE / RAZON SOCIAL ] VACIO");
                return;
            }
            if (_data.GetDireccion == "")
            {
                Helpers.Msg.Error("CAMPO [ DIRECCION ] VACIO");
                return;
            }
            if (_data.GetTelefono == "")
            {
                Helpers.Msg.Error("CAMPO [ TELEFONO ] VACIO");
                return;
            }
            var msg = "Guardar Cambios ?";
            var dg = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dg == DialogResult.Yes) 
            {
                _editarIsOk = false;
                var ficha = new OOB.Cliente.Editar.Ficha()
                {
                    auto = _ficha.Id,
                    ciRif = _data.GetCiRif,
                    dirFiscal = _data.GetDireccion,
                    razonSocial = _data.GetNombreRazonSocial,
                    telefono = _data.GetTelefono,
                };
                var r01 = Sistema.MyData.Cliente_EditarFicha(ficha);
                if (r01.Result ==  OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _editarIsOk = true;
            }
        }

        public void setNombre(string p)
        {
            _data.setNombreRazonSocial(p);
        }
        public void setDireccion(string p)
        {
            _data.setDireccion(p);
        }
        public void setTelefono(string p)
        {
            _data.setTelefono(p);
        }

        public void AbandonarCambios()
        {
            _abandonarCambiosIsOk = false;
            var msg = "Abandonar Cambios ?";
            var dg = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dg == DialogResult.Yes)
            {
                _abandonarCambiosIsOk = true;
            }
        }

    }

}