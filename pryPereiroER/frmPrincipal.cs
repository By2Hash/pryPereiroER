using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace pryPereiroER
{
    public partial class frmPrincipal : Form
    {
        // ─── Listas en memoria ───────────────────────────────────────────────────
        List<CEspecialidades> Listaespecialidades = new List<CEspecialidades>();
        List<CMedico> Listamedicos = new List<CMedico>();

        // ─── Cadena de conexión a Access ─────────────────────────────────────────
        private string cadenaConexion =
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\SP1ER.accdb";

        // ════════════════════════════════════════════════════════════════════════
        //  CONSTRUCTOR
        // ════════════════════════════════════════════════════════════════════════
        public frmPrincipal()
        {
            InitializeComponent();
        }

        // ════════════════════════════════════════════════════════════════════════
        //  CARGA DEL FORMULARIO  –  lee especialidades desde la BD al arrancar
        // ════════════════════════════════════════════════════════════════════════
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CargarEspecialidadesDesdeDB();
        }

        /// <summary>
        /// Lee la tabla Especialidades de Access y llena las listas y combos.
        /// Se llama al iniciar el formulario para que los datos persistan entre sesiones.
        /// </summary>
        private void CargarEspecialidadesDesdeDB()
        {
            try
            {
                string query = "SELECT [Id], [Especialidad] FROM [Especialidades] ORDER BY [Especialidad]";

                using (OleDbConnection conexion = new OleDbConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conexion))
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        // Limpiar antes de cargar para evitar duplicados si se llama más de una vez
                        Listaespecialidades.Clear();
                        cmbConsultarEspecialidad.Items.Clear();
                        cmbEspecialidadMedico.Items.Clear();

                        while (reader.Read())
                        {
                            CEspecialidades esp = new CEspecialidades();
                            esp.Id = Convert.ToInt32(reader["Id"]);
                            esp.Nombre = reader["Especialidad"].ToString();

                            Listaespecialidades.Add(esp);
                            cmbConsultarEspecialidad.Items.Add(esp);
                            cmbEspecialidadMedico.Items.Add(esp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar especialidades desde la base de datos:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════════════════
        //  TAB ESPECIALIDADES  –  Agregar
        // ════════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Solo permite ingresar dígitos en el campo ID (aunque con Autonumeración
        /// el campo queda deshabilitado; se mantiene el evento por si se reutiliza).
        /// </summary>
        private void txtIdEspecialidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            // ── Validación ────────────────────────────────────────────────────
            if (string.IsNullOrWhiteSpace(txtNombreEspecialidad.Text))
            {
                MessageBox.Show("Cargue un nombre de especialidad válido.",
                                "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreEspecialidad = txtNombreEspecialidad.Text.Trim();

            // ── Insertar en Access ────────────────────────────────────────────
            // NOTA: El campo [Id] es Autonumeración → Access lo genera solo.
            //       Solo insertamos [Especialidad].
            try
            {
                string query = "INSERT INTO [Especialidades] ([Especialidad]) VALUES (?)";

                using (OleDbConnection conexion = new OleDbConnection(cadenaConexion))
                {
                    conexion.Open();

                    using (OleDbCommand comando = new OleDbCommand(query, conexion))
                    {
                        comando.Parameters.Add("p1", OleDbType.VarChar, 255).Value = nombreEspecialidad;
                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            // Recuperar el Id autonumérico que Access asignó
                            OleDbCommand cmdIdentity = new OleDbCommand("SELECT @@IDENTITY", conexion);
                            int idGenerado = Convert.ToInt32(cmdIdentity.ExecuteScalar());

                            // Agregar a listas y combos en memoria
                            CEspecialidades nueva = new CEspecialidades();
                            nueva.Id = idGenerado;
                            nueva.Nombre = nombreEspecialidad;

                            Listaespecialidades.Add(nueva);
                            cmbConsultarEspecialidad.Items.Add(nueva);
                            cmbEspecialidadMedico.Items.Add(nueva);

                            // Limpiar campos DESPUÉS de todo
                            txtNombreEspecialidad.Clear();
                            txtIdEspecialidad.Clear();

                            MessageBox.Show(
                                $"Especialidad \"{nombreEspecialidad}\" registrada con éxito.\nID asignado: {idGenerado}",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se insertaron filas. Verificá la estructura de la tabla.",
                                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar especialidad:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════════════════
        //  TAB MÉDICOS  –  Agregar
        // ════════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Solo permite ingresar dígitos en el campo Matrícula.
        /// </summary>
        private void txtMatriculaMedico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnAgregarMedico_Click(object sender, EventArgs e)
        {
            // ── Validaciones ──────────────────────────────────────────────────
            if (string.IsNullOrWhiteSpace(txtMatriculaMedico.Text) ||
                string.IsNullOrWhiteSpace(txtNombreMedico.Text))
            {
                MessageBox.Show("Complete matrícula y nombre del médico.",
                                "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMatriculaMedico.Text, out int matricula))
            {
                MessageBox.Show("La matrícula debe ser un número válido.",
                                "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbEspecialidadMedico.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná una especialidad para el médico.",
                                "Dato incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CEspecialidades especialidadSeleccionada = (CEspecialidades)cmbEspecialidadMedico.SelectedItem;
            string nombreMedico = txtNombreMedico.Text.Trim();

            try
            {
                // Id es Autonumeración → no se inserta
                string query = "INSERT INTO [Medico] ([NombreCompleto], [Matricula], [Id_Especialidad]) " +
                               "VALUES (?, ?, ?)";

                using (OleDbConnection conexion = new OleDbConnection(cadenaConexion))
                {
                    conexion.Open();

                    using (OleDbCommand comando = new OleDbCommand(query, conexion))
                    {
                        comando.Parameters.Add("p1", OleDbType.VarChar, 255).Value = nombreMedico;
                        comando.Parameters.Add("p2", OleDbType.Integer).Value = matricula;
                        comando.Parameters.Add("p3", OleDbType.Integer).Value = especialidadSeleccionada.Id;

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            // Agregar a la lista en memoria
                            CMedico nuevoMedico = new CMedico();
                            nuevoMedico.Matricula = matricula;
                            nuevoMedico.Nombre = nombreMedico;
                            nuevoMedico.Apellido = string.Empty;
                            nuevoMedico.Especialidad = especialidadSeleccionada;
                            Listamedicos.Add(nuevoMedico);

                            // Limpiar campos DESPUÉS del INSERT
                            txtMatriculaMedico.Clear();
                            txtNombreMedico.Clear();
                            cmbEspecialidadMedico.SelectedIndex = -1;

                            MessageBox.Show("Médico registrado con éxito.",
                                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se insertaron filas. Verificá la estructura de la tabla.",
                                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar médico:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





            // ── Agregar a la lista en memoria ─────────────────────────────────
            CMedico nuevoM = new CMedico();
            nuevoM.Matricula = matricula;
            nuevoM.Nombre = txtNombreMedico.Text.Trim();
            nuevoM.Apellido = string.Empty;   // sin campo de apellido en el form
            nuevoM.Especialidad = (CEspecialidades)cmbEspecialidadMedico.SelectedItem;

            Listamedicos.Add(nuevoM);

            // ── Limpiar campos ────────────────────────────────────────────────
            txtMatriculaMedico.Clear();
            txtNombreMedico.Clear();
            cmbEspecialidadMedico.SelectedIndex = -1;

            MessageBox.Show("Médico registrado con éxito.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ════════════════════════════════════════════════════════════════════════
        //  TAB CONSULTA  –  Filtrar médicos por especialidad
        // ════════════════════════════════════════════════════════════════════════

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // ── Validación ────────────────────────────────────────────────────
            if (cmbConsultarEspecialidad.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná una especialidad en el combo.",
                                "Dato incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CEspecialidades seleccionada = (CEspecialidades)cmbConsultarEspecialidad.SelectedItem;

            // ── Filtrar médicos por especialidad ──────────────────────────────
            List<CMedico> listaFiltrada = Listamedicos
                .Where(m => m.Especialidad != null && m.Especialidad.Id == seleccionada.Id)
                .ToList();

            // ── Limpiar grilla ────────────────────────────────────────────────
            dgvMedicos.DataSource = null;
            dgvMedicos.Columns.Clear();

            if (listaFiltrada.Count > 0)
            {
                // Proyección plana para que la grilla muestre el nombre de la especialidad
                var listaParaMostrar = listaFiltrada.Select(m => new
                {
                    Matricula = m.Matricula,
                    Nombre_Completo = m.Nombre,
                    Especialidad = m.Especialidad != null ? m.Especialidad.Nombre : string.Empty
                }).ToList();

                dgvMedicos.AutoGenerateColumns = true;
                dgvMedicos.DataSource = listaParaMostrar;
                dgvMedicos.Refresh();

                MessageBox.Show("Total de médicos encontrados: " + listaFiltrada.Count,
                                "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se encontraron médicos para la especialidad: " + seleccionada.Nombre,
                                "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cmbConsultarEspecialidad.SelectedIndex = -1;
        }

        // ════════════════════════════════════════════════════════════════════════
        //  NUMERACIÓN DE FILAS en el DataGridView
        // ════════════════════════════════════════════════════════════════════════

        private void dgvMedicos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string index = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(
                e.RowBounds.Left,
                e.RowBounds.Top,
                dgvMedicos.RowHeadersWidth,
                e.RowBounds.Height);

            e.Graphics.DrawString(index, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        // ════════════════════════════════════════════════════════════════════════
        //  BOTÓN SALIR
        // ════════════════════════════════════════════════════════════════════════

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ════════════════════════════════════════════════════════════════════════
        //  EVENTOS VACÍOS (requeridos por el diseñador)
        // ════════════════════════════════════════════════════════════════════════

        private void cmbEspecialidadMedico_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}