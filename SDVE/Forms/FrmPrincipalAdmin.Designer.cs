namespace SDVE.Forms
{
    partial class FrmPrincipalAdmin
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
            pnlMenu = new Panel();
            pnlContenido = new Panel();
            lblLogo = new Label();
            lblAdmin = new Label();
            btnConvocatorias = new Button();
            btnCandidatos = new Button();
            btnResultados = new Button();
            btnExportacion = new Button();
            btnCerrarSesion = new Button();
            label1 = new Label();
            pnlMenu.SuspendLayout();
            pnlContenido.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(btnCerrarSesion);
            pnlMenu.Controls.Add(btnExportacion);
            pnlMenu.Controls.Add(btnResultados);
            pnlMenu.Controls.Add(btnCandidatos);
            pnlMenu.Controls.Add(btnConvocatorias);
            pnlMenu.Controls.Add(lblAdmin);
            pnlMenu.Controls.Add(lblLogo);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(220, 653);
            pnlMenu.TabIndex = 0;
            // 
            // pnlContenido
            // 
            pnlContenido.Controls.Add(label1);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(220, 0);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(862, 653);
            pnlContenido.TabIndex = 1;
            // 
            // lblLogo
            // 
            lblLogo.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(220, 52);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "SDVE";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAdmin
            // 
            lblAdmin.AutoSize = true;
            lblAdmin.Location = new Point(35, 69);
            lblAdmin.Name = "lblAdmin";
            lblAdmin.Size = new Size(169, 20);
            lblAdmin.TabIndex = 1;
            lblAdmin.Text = "Panel de Administración";
            // 
            // btnConvocatorias
            // 
            btnConvocatorias.FlatStyle = FlatStyle.Flat;
            btnConvocatorias.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConvocatorias.Location = new Point(14, 108);
            btnConvocatorias.Name = "btnConvocatorias";
            btnConvocatorias.Size = new Size(200, 45);
            btnConvocatorias.TabIndex = 2;
            btnConvocatorias.Text = "Convocatorias";
            btnConvocatorias.UseVisualStyleBackColor = true;
            // 
            // btnCandidatos
            // 
            btnCandidatos.FlatStyle = FlatStyle.Flat;
            btnCandidatos.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCandidatos.Location = new Point(14, 169);
            btnCandidatos.Name = "btnCandidatos";
            btnCandidatos.Size = new Size(200, 45);
            btnCandidatos.TabIndex = 3;
            btnCandidatos.Text = "Candidatos";
            btnCandidatos.UseVisualStyleBackColor = true;
            // 
            // btnResultados
            // 
            btnResultados.FlatStyle = FlatStyle.Flat;
            btnResultados.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnResultados.Location = new Point(14, 232);
            btnResultados.Name = "btnResultados";
            btnResultados.Size = new Size(200, 45);
            btnResultados.TabIndex = 4;
            btnResultados.Text = "Resultados";
            btnResultados.UseVisualStyleBackColor = true;
            // 
            // btnExportacion
            // 
            btnExportacion.FlatStyle = FlatStyle.Flat;
            btnExportacion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportacion.Location = new Point(14, 295);
            btnExportacion.Name = "btnExportacion";
            btnExportacion.Size = new Size(200, 45);
            btnExportacion.TabIndex = 5;
            btnExportacion.Text = "Exportación";
            btnExportacion.UseVisualStyleBackColor = true;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrarSesion.Location = new Point(12, 605);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(200, 45);
            btnCerrarSesion.TabIndex = 6;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 47);
            label1.Name = "label1";
            label1.Size = new Size(202, 20);
            label1.TabIndex = 0;
            label1.Text = "PANEL DE ADMINISTRACIÓN";
            // 
            // FrmPrincipalAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 653);
            Controls.Add(pnlContenido);
            Controls.Add(pnlMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmPrincipalAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel de Administración -SDVE";
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            pnlContenido.ResumeLayout(false);
            pnlContenido.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Button btnConvocatorias;
        private Label lblAdmin;
        private Label lblLogo;
        private Panel pnlContenido;
        private Button btnCerrarSesion;
        private Button btnExportacion;
        private Button btnResultados;
        private Button btnCandidatos;
        private Label label1;
    }
}