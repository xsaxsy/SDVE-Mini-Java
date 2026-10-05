namespace SDVE.Forms
{
    partial class FrmExportacion
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
            lblConvocatoria = new Label();
            cmbConvocatoria = new ComboBox();
            label1 = new Label();
            cmbFormato = new ComboBox();
            cmbNivel = new ComboBox();
            label2 = new Label();
            cmbFiltro = new ComboBox();
            lblFiltro = new Label();
            btnExportar = new Button();
            btnRegrear = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(51, 55, 113);
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.ImageAlign = ContentAlignment.TopLeft;
            lblTitulo.Location = new Point(-1, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(887, 61);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "EXPORTACIÓN DE RESULTADOS\r\n";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConvocatoria
            // 
            lblConvocatoria.AutoSize = true;
            lblConvocatoria.Font = new Font("Segoe UI", 12F);
            lblConvocatoria.Location = new Point(176, 101);
            lblConvocatoria.Name = "lblConvocatoria";
            lblConvocatoria.Size = new Size(138, 28);
            lblConvocatoria.TabIndex = 1;
            lblConvocatoria.Text = "Convocatoria: ";
            // 
            // cmbConvocatoria
            // 
            cmbConvocatoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbConvocatoria.Font = new Font("Segoe UI", 12F);
            cmbConvocatoria.FormattingEnabled = true;
            cmbConvocatoria.Location = new Point(332, 101);
            cmbConvocatoria.Name = "cmbConvocatoria";
            cmbConvocatoria.Size = new Size(400, 36);
            cmbConvocatoria.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(223, 179);
            label1.Name = "label1";
            label1.Size = new Size(91, 28);
            label1.TabIndex = 3;
            label1.Text = "Formato:";
            // 
            // cmbFormato
            // 
            cmbFormato.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormato.Font = new Font("Segoe UI", 12F);
            cmbFormato.FormattingEnabled = true;
            cmbFormato.Location = new Point(332, 179);
            cmbFormato.Name = "cmbFormato";
            cmbFormato.Size = new Size(400, 36);
            cmbFormato.TabIndex = 4;
            // 
            // cmbNivel
            // 
            cmbNivel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNivel.Font = new Font("Segoe UI", 12F);
            cmbNivel.FormattingEnabled = true;
            cmbNivel.Location = new Point(332, 261);
            cmbNivel.Name = "cmbNivel";
            cmbNivel.Size = new Size(400, 36);
            cmbNivel.TabIndex = 6;
            cmbNivel.SelectedIndexChanged += cmbNivel_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(145, 261);
            label2.Name = "label2";
            label2.Size = new Size(169, 28);
            label2.TabIndex = 5;
            label2.Text = "Nivel de Consulta:";
            // 
            // cmbFiltro
            // 
            cmbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltro.Font = new Font("Segoe UI", 12F);
            cmbFiltro.FormattingEnabled = true;
            cmbFiltro.Location = new Point(332, 348);
            cmbFiltro.Name = "cmbFiltro";
            cmbFiltro.Size = new Size(400, 36);
            cmbFiltro.TabIndex = 8;
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Font = new Font("Segoe UI", 12F);
            lblFiltro.Location = new Point(252, 348);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(62, 28);
            lblFiltro.TabIndex = 7;
            lblFiltro.Text = "Filtro:";
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(265, 444);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(94, 29);
            btnExportar.TabIndex = 9;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnRegrear
            // 
            btnRegrear.Location = new Point(461, 444);
            btnRegrear.Name = "btnRegrear";
            btnRegrear.Size = new Size(94, 29);
            btnRegrear.TabIndex = 10;
            btnRegrear.Text = "Regresar";
            btnRegrear.UseVisualStyleBackColor = true;
            // 
            // FrmExportacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 525);
            Controls.Add(btnRegrear);
            Controls.Add(btnExportar);
            Controls.Add(cmbFiltro);
            Controls.Add(lblFiltro);
            Controls.Add(cmbNivel);
            Controls.Add(label2);
            Controls.Add(cmbFormato);
            Controls.Add(label1);
            Controls.Add(cmbConvocatoria);
            Controls.Add(lblConvocatoria);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmExportacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Exportación de resultados - SDVE";
            Load += FrmExportacion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblConvocatoria;
        private ComboBox cmbConvocatoria;
        private Label label1;
        private ComboBox cmbFormato;
        private ComboBox cmbNivel;
        private Label label2;
        private ComboBox cmbFiltro;
        private Label lblFiltro;
        private Button btnExportar;
        private Button btnRegrear;
    }
}