namespace SDVE.Forms
{
    partial class FrmResultados
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
            lblResultados = new Label();
            lblConvocatoria = new Label();
            cmbConvocatoria = new ComboBox();
            dgvResultados = new DataGridView();
            btnRegresar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // lblResultados
            // 
            lblResultados.BackColor = Color.FromArgb(51, 55, 113);
            lblResultados.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResultados.ForeColor = Color.White;
            lblResultados.Location = new Point(1, -1);
            lblResultados.Name = "lblResultados";
            lblResultados.Size = new Size(981, 59);
            lblResultados.TabIndex = 0;
            lblResultados.Text = "RESULTADOS DE VOTACIÓN";
            lblResultados.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConvocatoria
            // 
            lblConvocatoria.AutoSize = true;
            lblConvocatoria.Location = new Point(237, 82);
            lblConvocatoria.Name = "lblConvocatoria";
            lblConvocatoria.Size = new Size(100, 20);
            lblConvocatoria.TabIndex = 1;
            lblConvocatoria.Text = "Convocatoria:";
            // 
            // cmbConvocatoria
            // 
            cmbConvocatoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbConvocatoria.FormattingEnabled = true;
            cmbConvocatoria.Location = new Point(390, 79);
            cmbConvocatoria.Name = "cmbConvocatoria";
            cmbConvocatoria.Size = new Size(400, 28);
            cmbConvocatoria.TabIndex = 2;
            cmbConvocatoria.SelectedIndexChanged += cmbConvocatoria_SelectedIndexChanged;
            // 
            // dgvResultados
            // 
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AllowUserToDeleteRows = false;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(66, 131);
            dgvResultados.MultiSelect = false;
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersWidth = 51;
            dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultados.Size = new Size(850, 350);
            dgvResultados.TabIndex = 3;
            // 
            // btnRegresar
            // 
            btnRegresar.Location = new Point(452, 526);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(94, 29);
            btnRegresar.TabIndex = 4;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // FrmResultados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(btnRegresar);
            Controls.Add(dgvResultados);
            Controls.Add(cmbConvocatoria);
            Controls.Add(lblConvocatoria);
            Controls.Add(lblResultados);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmResultados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resultados -SDVE";
            Load += FrmResultados_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblResultados;
        private Label lblConvocatoria;
        private ComboBox cmbConvocatoria;
        private DataGridView dgvResultados;
        private Button btnRegresar;
    }
}