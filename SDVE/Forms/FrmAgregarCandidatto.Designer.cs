namespace SDVE.Forms
{
    partial class FrmAgregarCandidatto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblNombreCandidato = new Label();
            lblConvocatoria = new Label();
            txtNombre = new TextBox();
            cmbConvocatoria = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(51, 55, 113);
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(-1, -1);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(586, 58);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "AGREGAR CANDIDATO";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNombreCandidato
            // 
            lblNombreCandidato.AutoSize = true;
            lblNombreCandidato.Location = new Point(98, 114);
            lblNombreCandidato.Name = "lblNombreCandidato";
            lblNombreCandidato.Size = new Size(163, 20);
            lblNombreCandidato.TabIndex = 1;
            lblNombreCandidato.Text = "Nombre del candidato:";
            // 
            // lblConvocatoria
            // 
            lblConvocatoria.AutoSize = true;
            lblConvocatoria.Location = new Point(161, 176);
            lblConvocatoria.Name = "lblConvocatoria";
            lblConvocatoria.Size = new Size(100, 20);
            lblConvocatoria.TabIndex = 2;
            lblConvocatoria.Text = "Convocatoria:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(277, 111);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(185, 27);
            txtNombre.TabIndex = 3;
            // 
            // cmbConvocatoria
            // 
            cmbConvocatoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbConvocatoria.FormattingEnabled = true;
            cmbConvocatoria.Location = new Point(277, 173);
            cmbConvocatoria.Name = "cmbConvocatoria";
            cmbConvocatoria.Size = new Size(185, 28);
            cmbConvocatoria.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(146, 237);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(312, 237);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmAgregarCandidatto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 403);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(cmbConvocatoria);
            Controls.Add(txtNombre);
            Controls.Add(lblConvocatoria);
            Controls.Add(lblNombreCandidato);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmAgregarCandidatto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Candidato - SDVE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNombreCandidato;
        private Label lblConvocatoria;
        private TextBox txtNombre;
        private ComboBox cmbConvocatoria;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}