using CapaDeNegocio.CN_CRUD;
using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaDePresentacion.Operaciones
{
    public partial class Equipo : Form
    {
        // Variables
        private EquipoCN equipoCN;
        private MantenimientoEquipoCN mantenimientoEquipoCN;
        private MantenimientoCN mantenimientoCN = new MantenimientoCN();
        private int equipoId;

        public Equipo()
        {
            InitializeComponent();
        }

        private void Equipo_Load(object sender, EventArgs e)
        {
            Mostrar();
            CargarDatos();
        }

        // Mostrar los equipos en el DataGridView
        private void Mostrar()
        {
            try
            {
                equipoCN = new EquipoCN();
                mantenimientoEquipoCN = new MantenimientoEquipoCN();

                // Cargar los datos del mantenimiento en el DataGridView
                DgvEquipo.DataSource = mantenimientoCN.ObtenerMantenimiento();
                DgvEquipo.Columns["id_mantenimiento"].Visible = false;
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Cargar datos en el ComboBox
        private void CargarDatos()
        {
            try
            {
                equipoCN = new EquipoCN();
                CmbEquipo.DataSource = equipoCN.ObtenerEquipos();
                CmbEquipo.DisplayMember = "codigo"; // Ajusta esto al campo correcto en tu entidad
                CmbEquipo.ValueMember = "id_equipo";
                CmbEquipo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Filtrar los equipos según los criterios de búsqueda
        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = string.IsNullOrEmpty(TxtCodigo.Text) ? null : TxtCodigo.Text;
                int? equipoId = CmbEquipo.SelectedValue != null ? (int?)CmbEquipo.SelectedValue : null;

                equipoCN = new EquipoCN();
                DgvEquipo.DataSource =(codigo, equipoId); // Suponiendo que tienes este método implementado
                DgvEquipo.Columns["id_equipo"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Limpiar los campos de filtro y recargar los datos
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            CmbEquipo.SelectedIndex = -1;
            TxtCodigo.Text = string.Empty;
            Mostrar();
        }

        // Agregar un nuevo registro de equipo
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            var frm = new Operaciones.FrmMaestroDetalleEquipo(); // Cambia al formulario correcto para agregar
            frm.FormClosed += Frm_FormClosed;
            frm.ShowDialog();
        }

        // Manejar la recarga de datos al cerrar el formulario de detalle
        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Mostrar();
        }

        // Editar el registro seleccionado de equipo
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvEquipo.SelectedRows.Count > 0)
                {
                    equipoId = int.Parse(DgvEquipo.CurrentRow.Cells["id_equipo"].Value.ToString());

                    var frm = new Operaciones.FrmMaestroDetalleEquipo(); // Cambia al formulario correcto para edición
                  
                    frm.FormClosed += Frm_FormClosed;
                    frm.ShowDialog();
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

        // Eliminar el registro seleccionado de equipo
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvEquipo.SelectedRows.Count > 0)
                {
                    equipoId = int.Parse(DgvEquipo.CurrentRow.Cells["id_equipo"].Value.ToString());

               

                    if (mantenimientoEquipoCN.Eliminar(equipoId))
                    {
                        // Eliminar el equipo
                        if (equipoCN.Eliminar(equipoId))
                        {
                            Mostrar();
                            CargarDatos();
                            BtnLimpiar_Click(null, null);
                        }
                        else
                        {
                            MessageBox.Show("El registro de equipo no se eliminó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El registro de mantenimiento de equipo no se eliminó correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
    }
}
