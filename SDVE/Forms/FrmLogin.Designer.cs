namespace SDVE
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblMatricula = new Label();
            txtMatricula = new TextBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            btnIniciarSesion = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Location = new Point(140, 10);
            lblTitulo.Margin = new Padding(8, 0, 8, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(600, 51);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "SISTEMA DIGITAL DE VOTACIÓN";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitulo.Location = new Point(140, 59);
            lblSubtitulo.Margin = new Padding(4, 0, 4, 0);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(600, 33);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "ESTUDIANTIL";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMatricula.Location = new Point(396, 162);
            lblMatricula.Margin = new Padding(4, 0, 4, 0);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(85, 23);
            lblMatricula.TabIndex = 2;
            lblMatricula.Text = "Matricula:";
            // 
            // txtMatricula
            // 
            txtMatricula.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatricula.Location = new Point(260, 190);
            txtMatricula.Margin = new Padding(4);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(350, 30);
            txtMatricula.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(266, 276);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(350, 30);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(388, 247);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(101, 23);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Contraseña:";
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciarSesion.Location = new Point(285, 370);
            btnIniciarSesion.Margin = new Padding(4);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(305, 45);
            btnIniciarSesion.TabIndex = 6;
            btnIniciarSesion.Text = "Iniciar";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(20F, 45F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 554);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtMatricula);
            Controls.Add(lblMatricula);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(8);
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema digital de Votación Estudiantil -SDVE";
            FormClosed += this.FrmLogin_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblMatricula;
        private TextBox txtMatricula;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnIniciarSesion;
    }
}
