using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosVerificador.Src.Reportes
{

    public partial class ReporteFrm : Form
    {

        public string Path { get; set; }
        public IEnumerable<ReportDataSource> rds { get; set; }
        public IEnumerable<ReportParameter> prmts { get; set; }


        public ReporteFrm()
        {
            InitializeComponent();
        }

        private void ReporteFrm_Load(object sender, EventArgs e)
        {
            this.reportViewer2.ProcessingMode = ProcessingMode.Local;
            this.reportViewer2.Visible = true;
            this.reportViewer2.SetDisplayMode(DisplayMode.Normal);
            this.reportViewer2.LocalReport.ReportPath = Path;
            this.reportViewer2.LocalReport.DataSources.Clear();
            foreach (var it in rds)
            {
                this.reportViewer2.LocalReport.DataSources.Add(it);
            }
            this.reportViewer2.ShowParameterPrompts = true;

            if (prmts != null)
            {
                foreach (var p in prmts)
                {
                    this.reportViewer2.LocalReport.SetParameters(p);
                }
            }
            this.reportViewer2.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer2.RefreshReport();
        }

    }

}