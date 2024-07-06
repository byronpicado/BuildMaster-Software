using System;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using CapaDeDatos;
using CapaDeNegocio.CN_CRUD;
using Entidades;

namespace CapaDePresentacion.Catálogos
{
    public partial class FrmResponsable : Form
    {
        // Variables
        private ResponsableCN responsableCN;
        private Responsable responsable;
        private bool editar = false;
        private int responsableId;
        private ConexionCD conexionCD;
        private SqlDataReader LectorDatos;

        public FrmResponsable()
        {
            InitializeComponent();
            responsableCN = new ResponsableCN();
            conexionCD = new ConexionCD();
        }

        private void FrmResponsable_Load(object sender, EventArgs e)
        {
            MostrarResponsables();
        }

        // Obtener los responsables desde la Capa de Negocio y enviar al DataGridView
        private void MostrarResponsables()
        {
            try
            {
                responsableCN = new ResponsableCN();
                DGVResponsable.DataSource = responsableCN.ObtenerResponsable();
                DGVResponsable.Columns["id_responsable"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Limpiar los controles de texto
        private void LimpiarDatos()
        {
            TxtBuscar.Clear();
            TxtCodigo.Clear();
            TxtNombre1.Clear();
            TxtNombre2.Clear();
            TxtApellidoPaterno.Clear();
            TxtApellidoMaterno.Clear();
            TxtCargo.Clear();
            TxtCodigo.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarInputs())
                {
                    responsable = new Responsable(responsableId, TxtCodigo.Text, TxtNombre1.Text, TxtNombre2.Text, TxtApellidoPaterno.Text, TxtApellidoMaterno.Text, TxtCargo.Text);

                    if (!editar)
                    {
                        InsertarResponsable();
                    }
                    else
                    {
                        EditarResponsable();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarResponsable()
        {
            try
            {
                if (responsableCN.Insertar(responsable))
                {
                    LimpiarDatos();
                    MostrarResponsables();
                    MessageBox.Show("Responsable agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El registro no se insertó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarResponsable()
        {
            try
            {
                editar = false;
                if (responsableCN.Editar(responsable))
                {
                    LimpiarDatos();
                    MostrarResponsables();
                    MessageBox.Show("Responsable actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El registro no se editó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVResponsable.SelectedRows.Count > 0)
                {
                    editar = true;
                    responsableId = int.Parse(DGVResponsable.CurrentRow.Cells["id_responsable"].Value.ToString());
                    TxtCodigo.Text = DGVResponsable.CurrentRow.Cells["codigo"].Value.ToString();
                    TxtNombre1.Text = DGVResponsable.CurrentRow.Cells["Nombre1"].Value.ToString();
                    TxtNombre2.Text = DGVResponsable.CurrentRow.Cells["Nombre2"].Value.ToString();
                    TxtApellidoPaterno.Text = DGVResponsable.CurrentRow.Cells["apellidoPaterno"].Value.ToString();
                    TxtApellidoMaterno.Text = DGVResponsable.CurrentRow.Cells["apellidoMaterno"].Value.ToString();
                    TxtCargo.Text = DGVResponsable.CurrentRow.Cells["cargo"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVResponsable.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar este responsable?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        EliminarResponsable();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarResponsable()
        {
            try
            {
                int responsableId = int.Parse(DGVResponsable.CurrentRow.Cells["id_responsable"].Value.ToString());
                if (responsableCN.Eliminar(responsableId))
                {
                    LimpiarDatos();
                    MostrarResponsables();
                    MessageBox.Show("El registro se eliminó correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El registro no se eliminó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarInputs()
        {
            if (string.IsNullOrWhiteSpace(TxtCodigo.Text) ||
                string.IsNullOrWhiteSpace(TxtNombre1.Text) ||
                string.IsNullOrWhiteSpace(TxtApellidoPaterno.Text) ||
                string.IsNullOrWhiteSpace(TxtApellidoMaterno.Text) ||
                string.IsNullOrWhiteSpace(TxtCargo.Text))
            {
                MessageBox.Show("Todos los campos marcados con * son obligatorios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            return true;
        }

        

        private void BtnLimpiar_Click_1(object sender, EventArgs e)
        {
            llenar_grid();
            LimpiarDatos();
        }

        private void iconButtonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir la conexión a la base de datos
                SqlConnection conexion = conexionCD.AbrirConexion();

                // Construir la consulta SQL con parámetros
                string consulta = "SELECT * FROM Responsable WHERE codigo = @codigo";

                // Crear y configurar el comando SQL
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@codigo", TxtBuscar.Text);

                // Crear el adaptador y llenar el DataTable
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                // Asignar el DataTable al DataGridView
                DGVResponsable.DataSource = dt;

                // Cerrar la conexión
                conexionCD.CerrarConexion();
            }
            catch (Exception ex)
            {
     
                MessageBox.Show("Ocurrió un error al buscar los dato del Responsable." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            llenar_grid();
            LimpiarDatos();
        }
        private void llenar_grid()
        {
            // Abrir la conexión a la base de datos
            SqlConnection conexion = conexionCD.AbrirConexion();
            string consulta = "SELECT * FROM Responsable";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGVResponsable.DataSource = dt;
        }
    }
}
