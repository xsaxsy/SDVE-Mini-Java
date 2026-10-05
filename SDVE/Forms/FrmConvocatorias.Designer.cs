namespace SDVE.Forms
{
    partial class FrmConvocatorias
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
            dgvConvocatorias = new DataGridView();
            label1 = new Label();
            btnCambiarEstado = new Button();
            btnRegresar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvConvocatorias).BeginInit();
            SuspendLayout();
            // 
            // dgvConvocatorias
            // 
            dgvConvocatorias.AllowUserToAddRows = false;
            dgvConvocatorias.AllowUserToDeleteRows = false;
            dgvConvocatorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvConvocatorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConvocatorias.Location = new Point(23, 95);
            dgvConvocatorias.MultiSelect = false;
            dgvConvocatorias.Name = "dgvConvocatorias";
            dgvConvocatorias.ReadOnly = true;
            dgvConvocatorias.RowHeadersWidth = 51;
            dgvConvocatorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConvocatorias.Size = new Size(820, 350);
            dgvConvocatorias.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(51, 55, 113);
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(-1, 0);
            label1.Name = "label1";
            label1.Size = new Size(887, 53);
            label1.TabIndex = 1;
            label1.Text = "Gestión de Convocatorias";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCambiarEstado
            // 
            btnCambiarEstado.Location = new Point(205, 469);
            btnCambiarEstado.Name = "btnCambiarEstado";
            btnCambiarEstado.Size = new Size(172, 29);
            btnCambiarEstado.TabIndex = 2;
            btnCambiarEstado.Text = "Activar / Desactivar";
            btnCambiarEstado.UseVisualStyleBackColor = true;
            btnCambiarEstado.Click += btnCambiarEstado_Click;
            // 
            // btnRegresar
            // 
            btnRegresar.Location = new Point(585, 469);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(94, 29);
            btnRegresar.TabIndex = 3;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // FrmConvocatorias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 553);
            Controls.Add(btnRegresar);
            Controls.Add(btnCambiarEstado);
            Controls.Add(label1);
            Controls.Add(dgvConvocatorias);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmConvocatorias";
            Text = "Gestión de Convocatorias - SDVE";
            ((System.ComponentModel.ISupportInitialize)dgvConvocatorias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvConvocatorias;
        private Label label1;
        private Button btnCambiarEstado;
        private Button btnRegresar;
    }
}