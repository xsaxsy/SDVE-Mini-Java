namespace SDVE.Forms
{
    partial class FrmVotacion
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
            lblInstruccion = new Label();
            pnlPapeleta = new Panel();
            btnContinuar = new Button();
            btnRegresar = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.BackColor = Color.FromArgb(51, 55, 113);
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.Window;
            lblTitulo.Location = new Point(-1, -1);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(985, 59);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "PAPELETA DE VOTACIÓN";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblInstruccion
            //
            lblInstruccion.AutoSize = true;
            lblInstruccion.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInstruccion.Location = new Point(327, 87);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Size = new Size(339, 23);
            lblInstruccion.TabIndex = 1;
            lblInstruccion.Text = "Seleccione un candidato por cada elección:";
            //
            // pnlPapeleta
            //
            pnlPapeleta.AutoScroll = true;
            pnlPapeleta.BorderStyle = BorderStyle.FixedSingle;
            pnlPapeleta.Location = new Point(23, 131);
            pnlPapeleta.Name = "pnlPapeleta";
            pnlPapeleta.Size = new Size(930, 444);
            pnlPapeleta.TabIndex = 2;
            //
            // btnContinuar
            //
            btnContinuar.Location = new Point(550, 602);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(125, 29);
            btnContinuar.TabIndex = 4;
            btnContinuar.Text = "CONTINUAR";
            btnContinuar.UseVisualStyleBackColor = true;
            btnContinuar.Click += this.btnContinuar_Click;
            //
            // btnRegresar
            //
            btnRegresar.Location = new Point(320, 602);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(125, 29);
            btnRegresar.TabIndex = 3;
            btnRegresar.Text = "REGRESAR";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            //
            // FrmVotacion
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 653);
            Controls.Add(btnRegresar);
            Controls.Add(btnContinuar);
            Controls.Add(pnlPapeleta);
            Controls.Add(lblInstruccion);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmVotacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Votación - SDVE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblInstruccion;
        private Panel pnlPapeleta;
        private Button btnContinuar;
        private Button btnRegresar;
    }
}
