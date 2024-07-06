
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
    public partial class FrmHabilidad : Form
    {
        // Variables
        private HabilidadCN habilidadCN;
        private Habilidad habilidad;
        private bool editar = false;
        private int habilidadid;
        private ConexionCD conexionCD;
        private SqlDataReader LectorDatos;
        public FrmHabilidad()
        {
            InitializeComponent();
            habilidadCN = new HabilidadCN();
            conexionCD = new ConexionCD();
        }



        private void FrmHabilidad_Load(object sender, EventArgs e)
        {
            MostrarHabilidad();
        }
        // Obtener las clientes desde la Capa de Negocio y la vamos a enviar al DGV
        private void MostrarHabilidad()
        {
            try
            { 
            habilidadCN = new HabilidadCN();
            DGVHabilidad.DataSource = habilidadCN.ObtenerHabilidad();
            DGVHabilidad.Columns["id_habilidad"].Visible = false;
        }
        catch(Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Ocurrió un error al cargar los datos de las habilidades.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Limpiar los controles de texto
        private void LimpiarDatos()
        {
            TxtBuscar.Clear();
            TxtCodigo.Clear();
            TxtDescripcion.Clear();
            TxtCodigo.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarInputs())
                {
                    //mandar a llamar habilidadId para el codigo generado en la BD
                    habilidad = new Habilidad(TxtCodigo.Text, habilidadid, TxtDescripcion.Text);

                    if (!editar)
                    {
                        habilidadCN.ValidarAntesDeCrear(habilidad);
                        if (habilidadCN.Insertar(habilidad))
                        {
                            LimpiarDatos();
                            MostrarHabilidad();
                            MessageBox.Show("Habilidad agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("El registro no se inserto correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else //Es uno existente
                    {
                        habilidadCN.ValidarAntesDeEditar(habilidad);
                        if (habilidadCN.Editar(habilidad))
                        {
                            LimpiarDatos();
                            MostrarHabilidad();
                            MessageBox.Show("Habilidad actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        }
                        else
                        {
                            MessageBox.Show("El registro no se edito correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Ocurrió un error al guardar los datos de la habilidad", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVHabilidad.SelectedRows.Count > 0)
                {
                    editar = true;
                    TxtCodigo.Text = DGVHabilidad.CurrentRow.Cells["codigo"].Value.ToString();
                    TxtDescripcion.Text = DGVHabilidad.CurrentRow.Cells["descripcion"].Value.ToString();
                    habilidadid = int.Parse(DGVHabilidad.CurrentRow.Cells["id_habilidad"].Value.ToString());

                }
                else
                    MessageBox.Show("Debe seleccionar una fila de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Ocurrió un error al intentar editar la habilidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        
            {
            try
            {
                if (DGVHabilidad.SelectedRows.Count > 0)
                {

                    if (MessageBox.Show("¿Está seguro que desea eliminar esta habilidad?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int habilidadid = int.Parse(DGVHabilidad.CurrentRow.Cells["id_habilidad"].Value.ToString());

                        habilidadCN.ValidarAntesDeEliminar(habilidadid);

                        if (habilidadCN.Eliminar(habilidadid))
                        {
                            LimpiarDatos();
                            MostrarHabilidad();
                            MessageBox.Show("El registro se eliminó correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El registro no se elimino correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LogError(ex);
                MessageBox.Show("Ocurrió un error al eliminar la habilidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string.IsNullOrWhiteSpace(TxtDescripcion.Text))
               

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

        private void iconButtonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir la conexión a la base de datos
                SqlConnection conexion = conexionCD.AbrirConexion();

                // Construir la consulta SQL con parámetros
                string consulta = "SELECT * FROM Habilidad WHERE codigo = @codigo";

                // Crear y configurar el comando SQL
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@codigo", TxtBuscar.Text);

                // Crear el adaptador y llenar el DataTable
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                // Asignar el DataTable al DataGridView
                DGVHabilidad.DataSource = dt;

                // Cerrar la conexión
                conexionCD.CerrarConexion();
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Ocurrió un error al buscar los datos de la habilidad." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string consulta = "SELECT * FROM Habilidad";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DGVHabilidad.DataSource = dt;
        }
    }
}