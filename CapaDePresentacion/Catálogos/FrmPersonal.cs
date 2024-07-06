using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Entidades; // Ensure you include the Entidades namespace
using CapaDeNegocio.CN_CRUD;
using CapaDeDatos;
using System.Diagnostics.Eventing.Reader; // Ensure you include the business layer namespace

namespace CapaDePresentacion.Catálogos
{
    public partial class FrmPersonal : Form
    {
        // Variables
        private PersonalCN personalCN;
        private Personal personal;
        private bool editar = false;
        private int personalid;
        private ConexionCD conexionCD;
        private SqlDataReader LectorDatos;

        public FrmPersonal()
        {
            InitializeComponent();
            personalCN = new PersonalCN();
            conexionCD = new ConexionCD();
        }

        private void FrmPersonal_Load(object sender, EventArgs e)
        {
             MostrarPersonal();
        }

        // Obtener el personal desde la Capa de Negocio y la vamos a enviar al DGV
        private void MostrarPersonal()
        {
            try
            {
                personalCN=new PersonalCN();
                DGVPersonal.DataSource = personalCN.ObtenerPersonal();
                DGVPersonal.Columns["id_personal"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Limpiar los controles de texto
        private void LimpiarDatos()
        {
            TxtCodigo.Clear();
            TxtNombre1.Clear();
            TxtNombre2.Clear();
            TxtApellidoPaterno.Clear();
            TxtApellidoMaterno.Clear();
            TxtCargo.Clear();
            DTPFechaContratacion.Value = DateTime.Now; // Resetea al valor actual
            TxtCodigo.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarInputs())
                {
                    personal = new Personal(personalid, TxtCodigo.Text, TxtNombre1.Text, TxtNombre2.Text, TxtApellidoPaterno.Text, TxtApellidoMaterno.Text, TxtCargo.Text, DTPFechaContratacion.Value);

                    if (!editar)
                    {
                        if (personalCN.Insertar(personal))
                        {
                            LimpiarDatos();
                            MostrarPersonal();
                            MessageBox.Show("Personal agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El registro no se insertó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (personalCN.Editar(personal))
                        {
                            LimpiarDatos();
                            MostrarPersonal();
                            MessageBox.Show("Personal actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (DGVPersonal.SelectedRows.Count > 0)
                {
                    editar = true;
                    personalid = int.Parse(DGVPersonal.CurrentRow.Cells["id_personal"].Value.ToString());
                    TxtCodigo.Text = DGVPersonal.CurrentRow.Cells["codigo"].Value.ToString();
                    TxtNombre1.Text = DGVPersonal.CurrentRow.Cells["nombre1"].Value.ToString();
                    TxtNombre2.Text = DGVPersonal.CurrentRow.Cells["nombre2"].Value.ToString();
                    TxtApellidoPaterno.Text = DGVPersonal.CurrentRow.Cells["apellidoPaterno"].Value.ToString();
                    TxtApellidoMaterno.Text = DGVPersonal.CurrentRow.Cells["apellidoMaterno"].Value.ToString();
                    TxtCargo.Text = DGVPersonal.CurrentRow.Cells["cargo"].Value.ToString();
                    DTPFechaContratacion.Value = Convert.ToDateTime(DGVPersonal.CurrentRow.Cells["fecha_contratacion"].Value);
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
                if (DGVPersonal.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar este personal?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int personalid = int.Parse(DGVPersonal.CurrentRow.Cells["id_personal"].Value.ToString());
                        personalCN.ValidarAntesDeEliminar(personalid);
                        if (personalCN.Eliminar(personalid))
                        {
                            LimpiarDatos();
                            MostrarPersonal();
                            MessageBox.Show("El registro se eliminó correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El registro no se eliminó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una fila de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Additional validation logic if necessary
        private bool ValidarInputs()
        {
            if (string.IsNullOrWhiteSpace(TxtCodigo.Text) ||
               string.IsNullOrWhiteSpace(TxtNombre1.Text) ||
               string.IsNullOrWhiteSpace(TxtNombre2.Text) ||
               string.IsNullOrWhiteSpace(TxtApellidoPaterno.Text) ||
               string.IsNullOrWhiteSpace(TxtApellidoMaterno.Text)||
               string.IsNullOrWhiteSpace(TxtCargo.Text))
           
            {
                
                MessageBox.Show("Todos los campos marcados con * son obligatorios","Adevertencia",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

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
                string consulta = "SELECT * FROM Personal WHERE codigo = @codigo";

                // Crear y configurar el comando SQL
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@codigo", TxtBuscar.Text);

                // Crear el adaptador y llenar el DataTable
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                // Asignar el DataTable al DataGridView
                DGVPersonal.DataSource = dt;

                // Cerrar la conexión
                conexionCD.CerrarConexion();
            }
            catch (Exception ex)
            {
              
                MessageBox.Show("Ocurrió un error al buscar los datos del personal." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            llenar_grid();
            LimpiarDatos();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
        private void llenar_grid()
        {
            // Abrir la conexión a la base de datos
            SqlConnection conexion = conexionCD.AbrirConexion();
            string consulta = "SELECT * FROM Personal";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGVPersonal.DataSource = dt;
        }
    }
}
