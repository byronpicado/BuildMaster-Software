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
    public partial class FrmRPTHabilidad : Form
    {
        HabilidadCN habilidadCN = new HabilidadCN();
        public FrmRPTHabilidad()
        {
            InitializeComponent();
        }

        private void FrmRPTHabilidad_Load(object sender, EventArgs e)
        {
            bindingSource1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "CapaDePresentacion.Informes.Informe_Habilidad.rdlc";
            bindingSource1.DataSource = habilidadCN.ObtenerHabilidad();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet3", bindingSource1));

            this.reportViewer1.RefreshReport();
        }
    }
}
