using CapaDeDatos;
using CapaDeNegocio.CN_CRUD;
using Entidades;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CapaDePresentacion.Catálogos
{
    public partial class FrmRecurso : Form
    {
        // Variables
        private RecursoCN recursoCN;
        private Recurso recurso;
        private bool editar = false;
        private int recursoid;
        private ConexionCD conexionCD;
        private SqlDataReader LectorDatos;


        public FrmRecurso()
        {
            InitializeComponent();
        }

        private void FrmRecurso_Load(object sender, EventArgs e)
        {
            MostrarRecurso();
        }

        // Obtener los recursos desde la Capa de Negocio y mostrar en el DataGridView
        private void MostrarRecurso()
        {
            recursoCN = new RecursoCN();
            DGVRecurso.DataSource = recursoCN.ObtenerRecurso();
            // Ocultar la columna de ID si no se desea mostrar
            DGVRecurso.Columns["id_recurso"].Visible = false;
            conexionCD = new ConexionCD();
        }

        // Limpiar los controles de texto del formulario
        private void LimpiarDatos()
        {
            TxtBuscar.Clear();  
            TxtCodigo.Text = "";
            TxtTipo.Text = "";
            TxtDescripcion.Text = "";
            TxtCosto.Text = "";
            editar = false;
            recursoid = 0;
        }

        // Validar que todos los campos estén llenos
        private bool ValidarInputs()
        {
            if (string.IsNullOrWhiteSpace(TxtCodigo.Text) ||
                string.IsNullOrWhiteSpace(TxtTipo.Text) ||
                string.IsNullOrWhiteSpace(TxtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(TxtCosto.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(TxtCosto.Text, out _))
            {
                MessageBox.Show("El campo Costo debe ser numérico.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Evento del botón Guardar
        private void BtnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (ValidarInputs())
                {
                    recurso = new Recurso
                    {
                        codigo = TxtCodigo.Text,
                        tipo = TxtTipo.Text,
                        descripcion = TxtDescripcion.Text,
                        costo = decimal.Parse(TxtCosto.Text)
                    };

                    if (editar)
                    {
                        recurso.id_recurso = recursoid;
                        if (recursoCN.Editar(recurso))
                        {
                            MessageBox.Show("El recurso se actualizó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarDatos();
                            MostrarRecurso();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el recurso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (recursoCN.Insertar(recurso))
                        {
                            MessageBox.Show("El recurso se registró correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarDatos();
                            MostrarRecurso();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar el recurso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón Editar
        private void BtnEditar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (DGVRecurso.SelectedRows.Count > 0)
                {
                    editar = true;
                    TxtCodigo.Text = DGVRecurso.CurrentRow.Cells["codigo"].Value.ToString();
                    TxtTipo.Text = DGVRecurso.CurrentRow.Cells["tipo"].Value.ToString();
                    TxtDescripcion.Text = DGVRecurso.CurrentRow.Cells["descripcion"].Value.ToString();
                    TxtCosto.Text = DGVRecurso.CurrentRow.Cells["costo"].Value.ToString();

                    recursoid = int.Parse(DGVRecurso.CurrentRow.Cells["id_recurso"].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón Eliminar
        private void BtnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (DGVRecurso.SelectedRows.Count > 0)
                {
                    int recursoid = int.Parse(DGVRecurso.CurrentRow.Cells["id_recurso"].Value.ToString());

                    if (MessageBox.Show("¿Está seguro que desea eliminar este recurso?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (recursoCN.Eliminar(recursoid))
                        {
                            MessageBox.Show("El recurso se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarDatos();
                            MostrarRecurso();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el recurso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón Limpiar
        private void BtnLimpiar_Click(object sender, EventArgs e)
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
                string consulta = "SELECT * FROM Recurso WHERE codigo = @codigo";

                // Crear y configurar el comando SQL
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@codigo", TxtBuscar.Text);

                // Crear el adaptador y llenar el DataTable
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                // Asignar el DataTable al DataGridView
                DGVRecurso.DataSource = dt;

                // Cerrar la conexión
                conexionCD.CerrarConexion();
            }
            catch (Exception ex)
            {
          
                MessageBox.Show("Ocurrió un error al buscar los datos del recurso." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string consulta = "SELECT * FROM Recurso";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGVRecurso.DataSource = dt;
        }
    }
}
