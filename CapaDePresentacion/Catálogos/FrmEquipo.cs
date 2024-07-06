using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CapaDeDatos;
using CapaDeNegocio.CN_CRUD;
using Entidades.Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaDePresentacion.Catálogos
{
    public partial class FrmEquipo : Form
    {
        private EquipoCN equipoCN;
        private Equipo equipo;
        private bool editar = false;
        private int equipoid;
        private ConexionCD conexionCD;
        private SqlDataReader LectorDatos;

        public FrmEquipo()
        {
            InitializeComponent();
            equipoCN = new EquipoCN();
            conexionCD = new ConexionCD();
        }

        private void FrmEquipo_Load(object sender, EventArgs e)
        {
            MostrarEquipos();
        }

        private void llenar_grid() 
        {
            // Abrir la conexión a la base de datos
            SqlConnection conexion = conexionCD.AbrirConexion();
            string consulta = "SELECT * FROM Equipo";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGVEquipo.DataSource = dt;
        }
        private void MostrarEquipos()
        {
            try
            {
                equipoCN = new EquipoCN();
                DGVEquipo.DataSource = equipoCN.ObtenerEquipos();
                DGVEquipo.Columns["id_equipo"].Visible = false;
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Ocurrió un error al cargar los datos de equipos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarDatos()
        {
            TxtCodigo.Clear();
            TxtTipo.Clear();
            TxtMarca.Clear();
            TxtBuscar.Clear();
            DTPFecha_Adquisicion.Value = DateTime.Now; // Reset date picker to current date
            TxtCodigo.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarInputs())
                {
                    equipo = new Equipo(equipoid, TxtCodigo.Text, TxtTipo.Text, TxtMarca.Text, DTPFecha_Adquisicion.Value);

                    if (!editar)
                    {
                        equipoCN.ValidarAntesDeCrear(equipo);
                        if (equipoCN.Insertar(equipo))
                        {
                            LimpiarDatos();
                            MostrarEquipos();
                            MessageBox.Show("Equipo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El registro no se insertó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        equipoCN.ValidarAntesDeEditar(equipo);
                        if (equipoCN.Editar(equipo))
                        {
                            LimpiarDatos();
                            MostrarEquipos();
                            MessageBox.Show("Equipo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El registro no se editó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Ocurrió un error al guardar los datos del equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVEquipo.SelectedRows.Count > 0)
                {
                    editar = true;
                    TxtCodigo.Text = DGVEquipo.CurrentRow.Cells["codigo"].Value.ToString();
                    TxtTipo.Text = DGVEquipo.CurrentRow.Cells["tipo"].Value.ToString();
                    TxtMarca.Text = DGVEquipo.CurrentRow.Cells["marca"].Value.ToString();
                    DTPFecha_Adquisicion.Text = DGVEquipo.CurrentRow.Cells["fecha_adquisicion"].Value.ToString();
                    equipoid = int.Parse(DGVEquipo.CurrentRow.Cells["id_equipo"].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Ocurrió un error al intentar editar el equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVEquipo.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar este equipo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int equipoid = int.Parse(DGVEquipo.CurrentRow.Cells["id_equipo"].Value.ToString());
                        equipoCN.ValidarAntesDeEliminar(equipoid);
                        if (equipoCN.Eliminar(equipoid))
                        {
                            LimpiarDatos();
                            MostrarEquipos();
                            MessageBox.Show("Equipo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El registro no se eliminó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Ocurrió un error al eliminar el equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarInputs()
        {
            if (string.IsNullOrWhiteSpace(TxtCodigo.Text) ||
                string.IsNullOrWhiteSpace(TxtTipo.Text) ||
                string.IsNullOrWhiteSpace(TxtMarca.Text))
            {
                MessageBox.Show("Todos los campos marcados con * son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LogError(Exception ex)
        {
            // Log the exception (e.g., write to a log file or database)
            Console.WriteLine(ex.ToString());
        }

        private void BtnLimpiar_Click_1(object sender, EventArgs e)
        {
            llenar_grid();
            LimpiarDatos();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void DGVEquipo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            llenar_grid();
            LimpiarDatos();
        }

        private void iconButtonBuscar_Click(object sender, EventArgs e)
        {

        }

        private void iconButtonBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Abrir la conexión a la base de datos
                SqlConnection conexion = conexionCD.AbrirConexion();

                // Construir la consulta SQL con parámetros
                string consulta = "SELECT * FROM Equipo WHERE codigo = @codigo";

                // Crear y configurar el comando SQL
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@codigo", TxtBuscar.Text);

                // Crear el adaptador y llenar el DataTable
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                // Asignar el DataTable al DataGridView
                DGVEquipo.DataSource = dt;

                // Cerrar la conexión
                conexionCD.CerrarConexion();
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Ocurrió un error al buscar los datos del equipo.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
