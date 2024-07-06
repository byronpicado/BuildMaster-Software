using CapaDeNegocio.CN_CRUD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDePresentacion.Reporte
{
    public partial class FrmRPTRecurso : Form
    {
        RecursoCN recursoCN = new RecursoCN();
        public FrmRPTRecurso()
        {
            InitializeComponent();
        }

        private void FrmRPTRecurso_Load(object sender, EventArgs e)
        {

            bindingSource1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "CapaDePresentacion.Informes.Informe_Recurso.rdlc";
            bindingSource1.DataSource = recursoCN.ObtenerRecurso();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet8", bindingSource1));

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
