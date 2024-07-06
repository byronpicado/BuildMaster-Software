using CapaDeDatos;
using CapaDeNegocio.CN_CRUD;
using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaDePresentacion
{
    public partial class FrmPrincipal : Form
    {
        // Variables
        private ProyectoCN proyectoCN;
        private ClienteCN clienteCN = new ClienteCN();
        private ResponsableCN responsableCN = new ResponsableCN();
        private ProgresoCN progresoCN = new ProgresoCN();
        private Proyecto proyecto;
        private bool editar = false;
        private int proyectoid;
        private ConexionCD conexionCD;
        private SqlDataReader LectorDatos;
        private Timer actualizarTimer; // Declarar el Timer

        public FrmPrincipal()
        {
            InitializeComponent();
            proyectoCN = new ProyectoCN();
            MostrarProyectosDetalle();

            // Inicializar y configurar el Timer
            actualizarTimer = new Timer();
            actualizarTimer.Interval = 3000; // 3000 milisegundos = 3 segundos
            actualizarTimer.Tick += new EventHandler(ActualizarTimer_Tick); // Suscribirse al evento Tick
            actualizarTimer.Start(); // Iniciar el Timer
        }

        // Nuevo método para mostrar los detalles de los proyectos
        private void MostrarProyectosDetalle()
        {
            try
            {
                proyectoCN = new ProyectoCN();
                DGVProyectoDetalle.DataSource = proyectoCN.ObtenerProyecto();
                DGVProyectoDetalle.Columns["id_proyecto"].Visible = false;
                DGVProyectoDetalle.Columns["id_cliente"].Visible = false;
                DGVProyectoDetalle.Columns["id_responsable"].Visible = false;
                DGVProyectoDetalle.Columns["id_progreso"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al mostrar los proyectos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para manejar el evento Tick del Timer
        private void ActualizarTimer_Tick(object sender, EventArgs e)
        {
            MostrarProyectosDetalle();  // Refrescar el DataGridView con los nuevos datos
        }

        // Eventos del formulario y lógica existente
        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmCliente();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void equipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmEquipo();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void habilidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmHabilidad();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmMantenimiento();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmPersonal();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void proyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmProyecto();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void progresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmProgreso();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void proyectoDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarProyectosDetalle();
        }

        private void recursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmRecurso();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void responsableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmResponsable();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void tareaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmTarea();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 80;
            }
            else
                MenuVertical.Width = 250;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmPersonal();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmCliente();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss ");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void BtnEquipo_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmEquipo();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void BtnHabilidad_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmHabilidad();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmMantenimiento();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void BtnProgreso_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmProgreso();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmResponsable();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void iconButtonCliente_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmCliente();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void iconButtonEquipo_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmEquipo();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void iconButtonHabilidad_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmHabilidad();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void iconButtonMantenimiento_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmMantenimiento();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void iconButtonPersonal_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmPersonal();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void iconButtonProgreso_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmProgreso();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void iconButtonResponsable_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmResponsable();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void iconButtonProyecto_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmProyecto();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void iconButtonTarea_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmTarea();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void iconButtonRecurso_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmRecurso();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void iconButtonReportProyecto_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTCliente();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmProyecto();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.FrmProyecto();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void iconButtonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = conexionCD.AbrirConexion();
                string consulta = "SELECT * FROM Proyecto WHERE codigo = @codigo";
                SqlCommand comando = new SqlCommand(consulta, conexion);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                DGVProyectoDetalle.DataSource = dt;
                conexionCD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar los datos del equipo." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void holaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTCliente();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void reporteDeResponsableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTResponsable();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void reporteDePersonalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTPersonal();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void reporteDeHabilidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTHabilidad();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void reporteDeTareaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTTarea();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void reporteDeRecursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTRecurso();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void reporteDeEquipoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTEquipo();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void reporteDeMantenimientoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTMatenimiento();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void reporteDeProgresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTProgreso();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void reporteDeProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTProyecto();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void menuacercade_Click(object sender, EventArgs e)
        {
            var Frm = new Catálogos.AcercaDelSistemaBuildMaster();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTCliente();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTResponsable();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTPersonal();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTHabilidad();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTTarea();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTRecurso();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTEquipo();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTMatenimiento();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTProgreso();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            var Frm = new Reporte.FrmRPTProyecto();
            Frm.ShowDialog();
            Frm.Dispose();
        }

        private void submenureportecompras_Click(object sender, EventArgs e)
        {
            var Frm = new Operaciones.Equipo();
            Frm.ShowDialog();
            Frm.Dispose();
        }
    }
}
