namespace pryPereiroER
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabEspecialidades = new System.Windows.Forms.TabPage();
            this.txtIdEspecialidad = new System.Windows.Forms.TextBox();
            this.txtNombreEspecialidad = new System.Windows.Forms.TextBox();
            this.lblIdEspecialidad = new System.Windows.Forms.Label();
            this.lblNombreEspecialidad = new System.Windows.Forms.Label();
            this.btnAgregarEspecialidad = new System.Windows.Forms.Button();
            this.tabMedicos = new System.Windows.Forms.TabPage();
            this.txtMatriculaMedico = new System.Windows.Forms.TextBox();
            this.txtNombreMedico = new System.Windows.Forms.TextBox();
            this.cmbEspecialidadMedico = new System.Windows.Forms.ComboBox();
            this.lblMatriculaMedico = new System.Windows.Forms.Label();
            this.lblNombreMedico = new System.Windows.Forms.Label();
            this.lblEspecialidadMedico = new System.Windows.Forms.Label();
            this.btnAgregarMedico = new System.Windows.Forms.Button();
            this.tabConsulta = new System.Windows.Forms.TabPage();
            this.dgvMedicos = new System.Windows.Forms.DataGridView();
            this.cmbEspecialidades = new System.Windows.Forms.ComboBox();
            this.lblEspecialidadConsulta = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.clmMatricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.tabEspecialidades.SuspendLayout();
            this.tabMedicos.SuspendLayout();
            this.tabConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabEspecialidades);
            this.tabControl.Controls.Add(this.tabMedicos);
            this.tabControl.Controls.Add(this.tabConsulta);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(686, 390);
            this.tabControl.TabIndex = 0;
            // 
            // tabEspecialidades
            // 
            this.tabEspecialidades.Controls.Add(this.txtIdEspecialidad);
            this.tabEspecialidades.Controls.Add(this.txtNombreEspecialidad);
            this.tabEspecialidades.Controls.Add(this.lblIdEspecialidad);
            this.tabEspecialidades.Controls.Add(this.lblNombreEspecialidad);
            this.tabEspecialidades.Controls.Add(this.btnAgregarEspecialidad);
            this.tabEspecialidades.Location = new System.Drawing.Point(4, 22);
            this.tabEspecialidades.Name = "tabEspecialidades";
            this.tabEspecialidades.Padding = new System.Windows.Forms.Padding(3);
            this.tabEspecialidades.Size = new System.Drawing.Size(678, 364);
            this.tabEspecialidades.TabIndex = 0;
            this.tabEspecialidades.Text = "Especialidades";
            this.tabEspecialidades.UseVisualStyleBackColor = true;
            // 
            // txtIdEspecialidad
            // 
            this.txtIdEspecialidad.Location = new System.Drawing.Point(7, 25);
            this.txtIdEspecialidad.Name = "txtIdEspecialidad";
            this.txtIdEspecialidad.Size = new System.Drawing.Size(86, 20);
            this.txtIdEspecialidad.TabIndex = 0;
            this.txtIdEspecialidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdEspecialidad_KeyPress);
            // 
            // txtNombreEspecialidad
            // 
            this.txtNombreEspecialidad.Location = new System.Drawing.Point(98, 25);
            this.txtNombreEspecialidad.Name = "txtNombreEspecialidad";
            this.txtNombreEspecialidad.Size = new System.Drawing.Size(172, 20);
            this.txtNombreEspecialidad.TabIndex = 1;
            // 
            // lblIdEspecialidad
            // 
            this.lblIdEspecialidad.AutoSize = true;
            this.lblIdEspecialidad.Location = new System.Drawing.Point(7, 10);
            this.lblIdEspecialidad.Name = "lblIdEspecialidad";
            this.lblIdEspecialidad.Size = new System.Drawing.Size(21, 13);
            this.lblIdEspecialidad.TabIndex = 2;
            this.lblIdEspecialidad.Text = "ID:";
            // 
            // lblNombreEspecialidad
            // 
            this.lblNombreEspecialidad.AutoSize = true;
            this.lblNombreEspecialidad.Location = new System.Drawing.Point(98, 10);
            this.lblNombreEspecialidad.Name = "lblNombreEspecialidad";
            this.lblNombreEspecialidad.Size = new System.Drawing.Size(47, 13);
            this.lblNombreEspecialidad.TabIndex = 3;
            this.lblNombreEspecialidad.Text = "Nombre:";
            // 
            // btnAgregarEspecialidad
            // 
            this.btnAgregarEspecialidad.Location = new System.Drawing.Point(274, 25);
            this.btnAgregarEspecialidad.Name = "btnAgregarEspecialidad";
            this.btnAgregarEspecialidad.Size = new System.Drawing.Size(64, 20);
            this.btnAgregarEspecialidad.TabIndex = 4;
            this.btnAgregarEspecialidad.Text = "Agregar";
            this.btnAgregarEspecialidad.UseVisualStyleBackColor = true;
            // 
            // tabMedicos
            // 
            this.tabMedicos.Controls.Add(this.txtMatriculaMedico);
            this.tabMedicos.Controls.Add(this.txtNombreMedico);
            this.tabMedicos.Controls.Add(this.cmbEspecialidadMedico);
            this.tabMedicos.Controls.Add(this.lblMatriculaMedico);
            this.tabMedicos.Controls.Add(this.lblNombreMedico);
            this.tabMedicos.Controls.Add(this.lblEspecialidadMedico);
            this.tabMedicos.Controls.Add(this.btnAgregarMedico);
            this.tabMedicos.Location = new System.Drawing.Point(4, 22);
            this.tabMedicos.Name = "tabMedicos";
            this.tabMedicos.Padding = new System.Windows.Forms.Padding(3);
            this.tabMedicos.Size = new System.Drawing.Size(678, 364);
            this.tabMedicos.TabIndex = 1;
            this.tabMedicos.Text = "Médicos";
            this.tabMedicos.UseVisualStyleBackColor = true;
            // 
            // txtMatriculaMedico
            // 
            this.txtMatriculaMedico.Location = new System.Drawing.Point(7, 25);
            this.txtMatriculaMedico.Name = "txtMatriculaMedico";
            this.txtMatriculaMedico.Size = new System.Drawing.Size(86, 20);
            this.txtMatriculaMedico.TabIndex = 0;
            // 
            // txtNombreMedico
            // 
            this.txtNombreMedico.Location = new System.Drawing.Point(98, 25);
            this.txtNombreMedico.Name = "txtNombreMedico";
            this.txtNombreMedico.Size = new System.Drawing.Size(172, 20);
            this.txtNombreMedico.TabIndex = 1;
            // 
            // cmbEspecialidadMedico
            // 
            this.cmbEspecialidadMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidadMedico.FormattingEnabled = true;
            this.cmbEspecialidadMedico.Location = new System.Drawing.Point(274, 25);
            this.cmbEspecialidadMedico.Name = "cmbEspecialidadMedico";
            this.cmbEspecialidadMedico.Size = new System.Drawing.Size(172, 21);
            this.cmbEspecialidadMedico.TabIndex = 2;
            // 
            // lblMatriculaMedico
            // 
            this.lblMatriculaMedico.AutoSize = true;
            this.lblMatriculaMedico.Location = new System.Drawing.Point(7, 10);
            this.lblMatriculaMedico.Name = "lblMatriculaMedico";
            this.lblMatriculaMedico.Size = new System.Drawing.Size(55, 13);
            this.lblMatriculaMedico.TabIndex = 3;
            this.lblMatriculaMedico.Text = "Matrícula:";
            // 
            // lblNombreMedico
            // 
            this.lblNombreMedico.AutoSize = true;
            this.lblNombreMedico.Location = new System.Drawing.Point(98, 10);
            this.lblNombreMedico.Name = "lblNombreMedico";
            this.lblNombreMedico.Size = new System.Drawing.Size(47, 13);
            this.lblNombreMedico.TabIndex = 4;
            this.lblNombreMedico.Text = "Nombre:";
            // 
            // lblEspecialidadMedico
            // 
            this.lblEspecialidadMedico.AutoSize = true;
            this.lblEspecialidadMedico.Location = new System.Drawing.Point(274, 10);
            this.lblEspecialidadMedico.Name = "lblEspecialidadMedico";
            this.lblEspecialidadMedico.Size = new System.Drawing.Size(70, 13);
            this.lblEspecialidadMedico.TabIndex = 5;
            this.lblEspecialidadMedico.Text = "Especialidad:";
            // 
            // btnAgregarMedico
            // 
            this.btnAgregarMedico.Location = new System.Drawing.Point(451, 25);
            this.btnAgregarMedico.Name = "btnAgregarMedico";
            this.btnAgregarMedico.Size = new System.Drawing.Size(64, 20);
            this.btnAgregarMedico.TabIndex = 6;
            this.btnAgregarMedico.Text = "Agregar";
            this.btnAgregarMedico.UseVisualStyleBackColor = true;
            // 
            // tabConsulta
            // 
            this.tabConsulta.Controls.Add(this.dgvMedicos);
            this.tabConsulta.Controls.Add(this.cmbEspecialidades);
            this.tabConsulta.Controls.Add(this.lblEspecialidadConsulta);
            this.tabConsulta.Controls.Add(this.btnConsultar);
            this.tabConsulta.Location = new System.Drawing.Point(4, 22);
            this.tabConsulta.Name = "tabConsulta";
            this.tabConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsulta.Size = new System.Drawing.Size(678, 364);
            this.tabConsulta.TabIndex = 2;
            this.tabConsulta.Text = "Consulta";
            this.tabConsulta.UseVisualStyleBackColor = true;
            // 
            // dgvMedicos
            // 
            this.dgvMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMatricula,
            this.clmNombre,
            this.clmApellido,
            this.clmEspecialidad});
            this.dgvMedicos.Location = new System.Drawing.Point(7, 50);
            this.dgvMedicos.Name = "dgvMedicos";
            this.dgvMedicos.RowTemplate.Height = 25;
            this.dgvMedicos.Size = new System.Drawing.Size(665, 309);
            this.dgvMedicos.TabIndex = 3;
            // 
            // cmbEspecialidades
            // 
            this.cmbEspecialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidades.FormattingEnabled = true;
            this.cmbEspecialidades.Location = new System.Drawing.Point(7, 25);
            this.cmbEspecialidades.Name = "cmbEspecialidades";
            this.cmbEspecialidades.Size = new System.Drawing.Size(172, 21);
            this.cmbEspecialidades.TabIndex = 2;
            // 
            // lblEspecialidadConsulta
            // 
            this.lblEspecialidadConsulta.AutoSize = true;
            this.lblEspecialidadConsulta.Location = new System.Drawing.Point(7, 10);
            this.lblEspecialidadConsulta.Name = "lblEspecialidadConsulta";
            this.lblEspecialidadConsulta.Size = new System.Drawing.Size(70, 13);
            this.lblEspecialidadConsulta.TabIndex = 1;
            this.lblEspecialidadConsulta.Text = "Especialidad:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(183, 25);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(64, 20);
            this.btnConsultar.TabIndex = 0;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // clmMatricula
            // 
            this.clmMatricula.HeaderText = "Matricula";
            this.clmMatricula.Name = "clmMatricula";
            // 
            // clmNombre
            // 
            this.clmNombre.HeaderText = "Nombre";
            this.clmNombre.Name = "clmNombre";
            // 
            // clmApellido
            // 
            this.clmApellido.HeaderText = "Apellido";
            this.clmApellido.Name = "clmApellido";
            // 
            // clmEspecialidad
            // 
            this.clmEspecialidad.HeaderText = "Especialidad";
            this.clmEspecialidad.Name = "clmEspecialidad";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administracion - Clìnica ";
            this.tabControl.ResumeLayout(false);
            this.tabEspecialidades.ResumeLayout(false);
            this.tabEspecialidades.PerformLayout();
            this.tabMedicos.ResumeLayout(false);
            this.tabMedicos.PerformLayout();
            this.tabConsulta.ResumeLayout(false);
            this.tabConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabEspecialidades;
        private System.Windows.Forms.TabPage tabMedicos;
        private System.Windows.Forms.TabPage tabConsulta;
        private System.Windows.Forms.DataGridView dgvMedicos;
        private System.Windows.Forms.ComboBox cmbEspecialidades;
        private System.Windows.Forms.Label lblEspecialidadConsulta;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txtIdEspecialidad;
        private System.Windows.Forms.TextBox txtNombreEspecialidad;
        private System.Windows.Forms.Label lblIdEspecialidad;
        private System.Windows.Forms.Label lblNombreEspecialidad;
        private System.Windows.Forms.Button btnAgregarEspecialidad;
        private System.Windows.Forms.TextBox txtMatriculaMedico;
        private System.Windows.Forms.TextBox txtNombreMedico;
        private System.Windows.Forms.ComboBox cmbEspecialidadMedico;
        private System.Windows.Forms.Label lblMatriculaMedico;
        private System.Windows.Forms.Label lblNombreMedico;
        private System.Windows.Forms.Label lblEspecialidadMedico;
        private System.Windows.Forms.Button btnAgregarMedico;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMatricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEspecialidad;
    }
}

