namespace SDVE.Forms
{
    partial class FrmConfirmacion
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
            pnlResumen = new FlowLayoutPanel();
            btnConfirmar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(51, 55, 113);
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.ControlLightLight;
            lblTitulo.Location = new Point(2, -2);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(880, 57);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "CONFIRMACIÓN DE VOTACIÓN";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblInstruccion
            // 
            lblInstruccion.AutoSize = true;
            lblInstruccion.Location = new Point(241, 91);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Size = new Size(398, 20);
            lblInstruccion.TabIndex = 1;
            lblInstruccion.Text = "Revisa cuidadosamente tus selecciones antes de confirmar.";
            // 
            // pnlResumen
            // 
            pnlResumen.AutoScroll = true;
            pnlResumen.Location = new Point(92, 130);
            pnlResumen.Name = "pnlResumen";
            pnlResumen.Size = new Size(700, 400);
            pnlResumen.TabIndex = 2;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(360, 547);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(167, 29);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "CONFIRMAR VOTO";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // FrmConfirmacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 603);
            Controls.Add(btnConfirmar);
            Controls.Add(pnlResumen);
            Controls.Add(lblInstruccion);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmConfirmacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Confirmación de voto - SDVE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblInstruccion;
        private FlowLayoutPanel pnlResumen;
        private Button btnConfirmar;
    }
}