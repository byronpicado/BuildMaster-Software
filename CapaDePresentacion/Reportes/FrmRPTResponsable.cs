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
    public partial class FrmRPTResponsable : Form
    {
        ResponsableCN responsableCN = new ResponsableCN();
        public FrmRPTResponsable()
        {
            InitializeComponent();
        }

        private void FrmRPTResponsable_Load(object sender, EventArgs e)
        {

            bindingSource1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "CapaDePresentacion.Informes.Informe_Responsable.rdlc";
            bindingSource1.DataSource = responsableCN.ObtenerResponsable();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet9", bindingSource1));

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {

        }
    }
}
