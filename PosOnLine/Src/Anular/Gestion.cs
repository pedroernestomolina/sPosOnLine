using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Anular
{
    
    public class Gestion
    {


        public string Motivo { get; set; }
        public bool IsAnularOK { get; set; }


        public Gestion()
        {
            Motivo = "";
            IsAnularOK = false;
        }


        AnularFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AnularFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        private void Limpiar()
        {
            Motivo = "";
            IsAnularOK = false;
        }

        public void Procesar()
        {
            if (Motivo.Trim() != "") 
            {
                IsAnularOK = true;
            }
        }

        public void Inicializa()
        {
            Limpiar();
        }

    }

}