namespace SDVE.Forms
{
    partial class FrmInicio
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
            label1 = new Label();
            label2 = new Label();
            chkSociedadAlumnos = new CheckBox();
            chkConsejoUniversitario = new CheckBox();
            chkConsejoRepresentantes = new CheckBox();
            btnContinuar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(51, 55, 113);
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(-1, 0);
            label1.Name = "label1";
            label1.Size = new Size(983, 73);
            label1.TabIndex = 0;
            label1.Text = "Selección de Elecciones";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(300, 99);
            label2.Name = "label2";
            label2.Size = new Size(363, 20);
            label2.TabIndex = 1;
            label2.Text = "Selecciona las elecciones en las que deseas participar";
            // 
            // chkSociedadAlumnos
            // 
            chkSociedadAlumnos.AutoSize = true;
            chkSociedadAlumnos.Location = new Point(394, 174);
            chkSociedadAlumnos.Name = "chkSociedadAlumnos";
            chkSociedadAlumnos.Size = new Size(176, 24);
            chkSociedadAlumnos.TabIndex = 3;
            chkSociedadAlumnos.Text = "Sociedad de Alumnos";
            chkSociedadAlumnos.UseVisualStyleBackColor = true;
            // 
            // chkConsejoUniversitario
            // 
            chkConsejoUniversitario.AutoSize = true;
            chkConsejoUniversitario.Location = new Point(394, 218);
            chkConsejoUniversitario.Name = "chkConsejoUniversitario";
            chkConsejoUniversitario.Size = new Size(171, 24);
            chkConsejoUniversitario.TabIndex = 4;
            chkConsejoUniversitario.Text = "Consejo Universitario";
            chkConsejoUniversitario.UseVisualStyleBackColor = true;
            // 
            // chkConsejoRepresentantes
            // 
            chkConsejoRepresentantes.AutoSize = true;
            chkConsejoRepresentantes.Location = new Point(394, 260);
            chkConsejoRepresentantes.Name = "chkConsejoRepresentantes";
            chkConsejoRepresentantes.Size = new Size(210, 24);
            chkConsejoRepresentantes.TabIndex = 5;
            chkConsejoRepresentantes.Text = "Consejo de Representantes";
            chkConsejoRepresentantes.UseVisualStyleBackColor = true;
            // 
            // btnContinuar
            // 
            btnContinuar.Location = new Point(429, 318);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(108, 29);
            btnContinuar.TabIndex = 3;
            btnContinuar.Text = "CONTINUAR";
            btnContinuar.UseVisualStyleBackColor = true;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // FrmInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 425);
            Controls.Add(chkSociedadAlumnos);
            Controls.Add(chkConsejoRepresentantes);
            Controls.Add(chkConsejoUniversitario);
            Controls.Add(btnContinuar);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Selcción de elecciones - SDVE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private CheckBox chkConsejoRepresentantes;
        private CheckBox chkSociedadAlumnos;
        private CheckBox chkConsejoUniversitario;
        private Button btnContinuar;
    }
}