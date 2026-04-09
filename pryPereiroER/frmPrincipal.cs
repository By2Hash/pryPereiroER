using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryPereiroER
{
    public partial class frmPrincipal : Form
    {

        List<CEspecialidades> Listaespecialidades = new List<CEspecialidades>();
        List<CMedico> Listamedicos = new List<CMedico>();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtIdEspecialidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            
         
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
            
                e.Handled = true;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (cmbConsultarEspecialidad.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccioná una especialidad en el combo.");
                return;
            }

            // Obtener la especialidad seleccionada
            CEspecialidades seleccionada = (CEspecialidades)cmbConsultarEspecialidad.SelectedItem;

            // Filtrar médicos por especialidad
            List<CMedico> listaFiltrada = Listamedicos.Where(m => m.Especialidad != null && m.Especialidad.Id == seleccionada.Id).ToList();

            // Limpiar la grilla y columnas para evitar columnas sobrantes
            dgvMedicos.DataSource = null;
            dgvMedicos.Columns.Clear();

            if (listaFiltrada.Count > 0)
            {
                // Crear una lista plana para mostrar el nombre de la especialidad en la grilla
                var listaParaMostrar = listaFiltrada.Select(m => new
                {
                    Matricula = m.Matricula,
                    Nombre = m.Nombre,
                    Apellido = m.Apellido,
                    Especialidad = m.Especialidad != null ? m.Especialidad.Nombre : string.Empty
                }).ToList();

                dgvMedicos.AutoGenerateColumns = true;
                dgvMedicos.DataSource = listaParaMostrar;
                dgvMedicos.Refresh();

                MessageBox.Show("Total de médicos encontrados: " + listaFiltrada.Count.ToString());
            }
            else
            {
                MessageBox.Show("No se encontraron médicos para: " + seleccionada.Nombre);
            }
        }

        private void btnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreEspecialidad.Text))
                {
                    MessageBox.Show("Cargue un nombre válido");
                    return; 
                }

                int idGenerado;
                if (!int.TryParse(txtIdEspecialidad.Text, out idGenerado))
                {
                    MessageBox.Show("El ID debe ser un número válido");
                    return;
                }

                CEspecialidades nuevaEspecialidad = new CEspecialidades();
                nuevaEspecialidad.Id = int.Parse(txtIdEspecialidad.Text);
                nuevaEspecialidad.Nombre = txtNombreEspecialidad.Text;

                Listaespecialidades.Add(nuevaEspecialidad);
                cmbConsultarEspecialidad.Items.Add(nuevaEspecialidad);
                cmbEspecialidadMedico.Items.Add(nuevaEspecialidad);

                txtNombreEspecialidad.Clear();
                txtIdEspecialidad.Clear();

                MessageBox.Show("Especialidad registrada con éxito.");


            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error al agregar especialidad: " + ex.Message);
            }
        }

        private void btnAgregarMedico_Click(object sender, EventArgs e)
        {
           // Validaciones
            if (string.IsNullOrWhiteSpace(txtMatriculaMedico.Text) || string.IsNullOrWhiteSpace(txtNombreMedico.Text))
            {
                MessageBox.Show("Complete matrícula y nombre del médico.");
                return;
            }

            if (!int.TryParse(txtMatriculaMedico.Text, out int matricula))
            {
                MessageBox.Show("La matrícula debe ser un número válido.");
                return;
            }

            if (cmbEspecialidadMedico.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una especialidad para el médico.");
                return;
            }

            CMedico nuevoM = new CMedico();
            nuevoM.Matricula = matricula;
            nuevoM.Nombre = txtNombreMedico.Text;
            // El formulario no tiene campo de apellido, se deja vacío si no existe
            nuevoM.Apellido = string.Empty;
            nuevoM.Especialidad = (CEspecialidades)cmbEspecialidadMedico.SelectedItem;
            Listamedicos.Add(nuevoM);
            txtMatriculaMedico.Clear();
            txtNombreMedico.Clear();
            MessageBox.Show("Médico registrado con éxito.");

        }

        private void txtMatriculaMedico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {

                e.Handled = true;
            }
        }
    }
    
}
