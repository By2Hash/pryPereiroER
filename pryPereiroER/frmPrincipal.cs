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
            // 1. Mensaje de diagnóstico (Para saber si hay algo guardado)
            MessageBox.Show("Total de médicos en memoria: " + Listamedicos.Count.ToString());

            if (cmbConsultarEspecialidad.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccioná una especialidad en el combo.");
                return;
            }

            // 2. Obtener la especialidad seleccionada
            CEspecialidades seleccionada = (CEspecialidades)cmbConsultarEspecialidad.SelectedItem;

            // 3. Filtrar manualmente (más seguro que LINQ para debugear ahora)
            List<CMedico> listaFiltrada = new List<CMedico>();
            foreach (CMedico med in Listamedicos)
            {
                if (med.Especialidad.Id == seleccionada.Id)
                {
                    listaFiltrada.Add(med);
                }
            }

            // 4. Limpiar y refrescar la grilla
            dgvMedicos.DataSource = null;
            if (listaFiltrada.Count > 0)
            {
                dgvMedicos.DataSource = listaFiltrada;
                // Refrescar visualmente la grilla
                dgvMedicos.Refresh();
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
           CMedico nuevoM = new CMedico();
            nuevoM.Matricula = int.Parse(txtMatriculaMedico.Text);
            nuevoM.Nombre = txtNombreMedico.Text;
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
