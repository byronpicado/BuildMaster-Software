using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CapaDeDatos;
using CapaDeNegocio.CN_CRUD;
using Entidades;
using Entidades.Entidades;

namespace CapaDePresentacion.Catálogos
{
    public partial class FrmCliente : Form
    {
        private ClienteCN clienteCN;
        private Cliente cliente;
        private bool editar = false;
        private int clienteid;
        private ConexionCD conexionCD;
        private SqlDataReader LectorDatos;

        public FrmCliente()
        {
            InitializeComponent();
            clienteCN = new ClienteCN();
            conexionCD = new ConexionCD();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        private void MostrarClientes()
        {
            try
            {
                clienteCN = new ClienteCN();
                DGVCliente.DataSource = clienteCN.ObtenerClientes();
                DGVCliente.Columns["id_cliente"].Visible = false;
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
            TxtNombre1.Clear();
            TxtNombre2.Clear();
            TxtApellidoPaterno.Clear();
            TxtApellidoMaterno.Clear();
            TxtTelefono.Clear();
            TxtCorreo.Clear();
            TxtCodigo.Focus();
       
            
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarInputs())
                {
                    cliente = new Cliente(clienteid, TxtCodigo.Text, TxtNombre1.Text, TxtNombre2.Text, TxtApellidoPaterno.Text, TxtApellidoMaterno.Text, TxtTelefono.Text, TxtCorreo.Text);

                    if (!editar)
                    {
                        clienteCN.ValidarAntesDeCrear(cliente);
                        if (clienteCN.Insertar(cliente))
                        {
                            LimpiarDatos();
                            MostrarClientes();
                            MessageBox.Show("Cliente agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El registro no se insertó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        clienteCN.ValidarAntesDeEditar(cliente);
                        if (clienteCN.Editar(cliente))
                        {
                            LimpiarDatos();
                            MostrarClientes();
                            MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Ocurrió un error al guardar los datos del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVCliente.SelectedRows.Count > 0)
                {
                    editar = true;
                    TxtCodigo.Text = DGVCliente.CurrentRow.Cells["codigo"].Value.ToString();
                    TxtNombre1.Text = DGVCliente.CurrentRow.Cells["nombre1"].Value.ToString();
                    TxtNombre2.Text = DGVCliente.CurrentRow.Cells["nombre2"].Value.ToString();
                    TxtApellidoPaterno.Text = DGVCliente.CurrentRow.Cells["apellidoPaterno"].Value.ToString();
                    TxtApellidoMaterno.Text = DGVCliente.CurrentRow.Cells["apellidoMaterno"].Value.ToString();
                    TxtTelefono.Text = DGVCliente.CurrentRow.Cells["telefono"].Value.ToString();
                    TxtCorreo.Text = DGVCliente.CurrentRow.Cells["correo"].Value.ToString();
                    clienteid = int.Parse(DGVCliente.CurrentRow.Cells["id_cliente"].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Ocurrió un error al intentar editar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVCliente.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int clienteid = int.Parse(DGVCliente.CurrentRow.Cells["id_cliente"].Value.ToString());
                        clienteCN.ValidarAntesDeEliminar(clienteid);
                        if (clienteCN.Eliminar(clienteid))
                        {
                            LimpiarDatos();
                            MostrarClientes();
                            MessageBox.Show("el Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El cliente no se eliminó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Ocurrió un error al eliminar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            llenar_grid();
            LimpiarDatos();
        }

        private bool ValidarInputs()
        {
            if (string.IsNullOrWhiteSpace(TxtCodigo.Text) ||
                string.IsNullOrWhiteSpace(TxtNombre1.Text) ||
                string.IsNullOrWhiteSpace(TxtApellidoPaterno.Text) ||
                string.IsNullOrWhiteSpace(TxtTelefono.Text) ||
                string.IsNullOrWhiteSpace(TxtCorreo.Text))
            {
                MessageBox.Show("Todos los campos marcados con * son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!IsValidEmail(TxtCorreo.Text))
            {
                MessageBox.Show("El formato del correo es incorrecto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void LogError(Exception ex)
        {
            // Log the exception (e.g., write to a log file or database)
            Console.WriteLine(ex.ToString());
        }

        private void iconButtonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir la conexión a la base de datos
                SqlConnection conexion = conexionCD.AbrirConexion();

                // Construir la consulta SQL con parámetros
                string consulta = "SELECT * FROM Cliente WHERE codigo = @codigo";

                // Crear y configurar el comando SQL
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@codigo", TxtBuscar.Text);

                // Crear el adaptador y llenar el DataTable
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                // Asignar el DataTable al DataGridView
                DGVCliente.DataSource = dt;

                // Cerrar la conexión
                conexionCD.CerrarConexion();
            }
            catch (Exception ex)
            {
                LogError(ex);
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
            string consulta = "SELECT * FROM Cliente";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGVCliente.DataSource = dt;
        }
    }
}
