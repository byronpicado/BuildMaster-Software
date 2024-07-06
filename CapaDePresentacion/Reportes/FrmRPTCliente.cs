using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocio.CN_CRUD;



namespace CapaDePresentacion.Reporte
{
    
    public partial class FrmRPTCliente : Form
    {
        ClienteCN clienteCN = new ClienteCN();
        public FrmRPTCliente()
        {
            InitializeComponent();
        }

        private void FrmRPTCliente_Load(object sender, EventArgs e)
        {
            bindingSource1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "CapaDePresentacion.Informes.Informe_Cliente.rdlc";
            bindingSource1.DataSource = clienteCN.ObtenerClientes();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", bindingSource1));
      
            this.reportViewer1.RefreshReport();
        }
    }
}
