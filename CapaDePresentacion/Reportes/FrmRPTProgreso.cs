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
    public partial class FrmRPTProgreso : Form
    {
        ProgresoCN progresoCN=new ProgresoCN();
        public FrmRPTProgreso()
        {
            InitializeComponent();
        }

        private void FrmRPTProgreso_Load(object sender, EventArgs e)
        {
            bindingSource1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "CapaDePresentacion.Informes.Informe_Progreso.rdlc";
            bindingSource1.DataSource = progresoCN.ObtenerProgreso();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet6", bindingSource1));

            this.reportViewer1.RefreshReport();
        }
    }
}
