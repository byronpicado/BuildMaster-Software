using CapaDeDatos;
using CapaDeNegocio.CN_CRUD;
using Entidades;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDePresentacion.Catálogos
{
    public partial class FrmProgreso : Form
    {
        // Variables
        private ProgresoCN progresoCN;
        private Progreso progreso;
        private bool editar = false;
        private int progresoid;
        private ConexionCD conexionCD;
        private SqlDataReader LectorDatos;
        public FrmProgreso()
        {
            InitializeComponent();
            progresoCN = new ProgresoCN();
            conexionCD = new ConexionCD();
        }

        private void FrmProgreso_Load(object sender, EventArgs e)
        {
            MostrarProgreso();
        }

        private void MostrarProgreso()
        {
            try
            {
                progresoCN = new ProgresoCN();
                DGVProgreso.DataSource = progresoCN.ObtenerProgreso();
                DGVProgreso.Columns["id_progreso"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimpiarDatos()
        {
            TxtBuscar.Clear();
            TxtCodigo.Clear();
            TxtDescripcion.Clear();
            DTPFechaRegistro.Value = DateTime.Now; // Resetea al valor actual
            TxtCodigo.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarInputs())
                {
                    progreso = new Progreso(progresoid, TxtCodigo.Text, TxtDescripcion.Text, DTPFechaRegistro.Value);

                    if (!editar)
                    {
                        if (progresoCN.Insertar(progreso))
                        {
                            LimpiarDatos();
                            MostrarProgreso();
                            MessageBox.Show("Progreso agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El registro no se insertó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (progresoCN.Editar(progreso))
                        {
                            LimpiarDatos();
                            MostrarProgreso();
                            MessageBox.Show("Progreso actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVProgreso.SelectedRows.Count > 0)
                {
                    editar = true;
                    progresoid = int.Parse(DGVProgreso.CurrentRow.Cells["id_progreso"].Value.ToString());
                    TxtCodigo.Text = DGVProgreso.CurrentRow.Cells["codigo"].Value.ToString();
                    TxtDescripcion.Text = DGVProgreso.CurrentRow.Cells["descripcion"].Value.ToString();
                    DTPFechaRegistro.Value = Convert.ToDateTime(DGVProgreso.CurrentRow.Cells["fecha_registro"].Value);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVProgreso.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar este progreso?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int progresoid = int.Parse(DGVProgreso.CurrentRow.Cells["id_progreso"].Value.ToString());

                        if (progresoCN.Eliminar(progresoid))
                        {
                            LimpiarDatos();
                            MostrarProgreso();
                            MessageBox.Show("El registro se eliminó correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El registro no se eliminó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarInputs()
        {
            if (string.IsNullOrWhiteSpace(TxtCodigo.Text) ||
                string.IsNullOrWhiteSpace(TxtDescripcion.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
        }

        private void BtnProgreso_Click(object sender, EventArgs e)
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
                string consulta = "SELECT * FROM Progreso WHERE codigo = @codigo";

                // Crear y configurar el comando SQL
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@codigo", TxtBuscar.Text);

                // Crear el adaptador y llenar el DataTable
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                // Asignar el DataTable al DataGridView
                DGVProgreso.DataSource = dt;

                // Cerrar la conexión
                conexionCD.CerrarConexion();
            }
            catch (Exception ex)
            {
      
                MessageBox.Show("Ocurrió un error al buscar los datos del cliente." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string consulta = "SELECT * FROM Progreso";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGVProgreso.DataSource = dt;
        }
    }
}
