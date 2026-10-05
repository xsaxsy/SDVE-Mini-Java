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
            lblParticipacion = new Label();
            lblAbstencionismo = new Label();
            lblNivel = new Label();
            cmbNivel = new ComboBox();
            lblFiltro = new Label();
            cmbFiltro = new ComboBox();
            pnlGrafica = new Panel();
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
            dgvResultados.Location = new Point(61, 216);
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
            btnRegresar.Location = new Point(468, 874);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(94, 29);
            btnRegresar.TabIndex = 4;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // lblParticipacion
            // 
            lblParticipacion.AutoSize = true;
            lblParticipacion.Location = new Point(278, 602);
            lblParticipacion.Name = "lblParticipacion";
            lblParticipacion.Size = new Size(140, 20);
            lblParticipacion.TabIndex = 5;
            lblParticipacion.Text = "Participación: 0.00%";
            // 
            // lblAbstencionismo
            // 
            lblAbstencionismo.AutoSize = true;
            lblAbstencionismo.Location = new Point(564, 602);
            lblAbstencionismo.Name = "lblAbstencionismo";
            lblAbstencionismo.Size = new Size(161, 20);
            lblAbstencionismo.TabIndex = 6;
            lblAbstencionismo.Text = "Abstencionismo: 0.00%";
            // 
            // lblNivel
            // 
            lblNivel.AutoSize = true;
            lblNivel.Location = new Point(209, 125);
            lblNivel.Name = "lblNivel";
            lblNivel.Size = new Size(128, 20);
            lblNivel.TabIndex = 7;
            lblNivel.Text = "Nivel de Consulta:";
            // 
            // cmbNivel
            // 
            cmbNivel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNivel.FormattingEnabled = true;
            cmbNivel.Location = new Point(390, 117);
            cmbNivel.Name = "cmbNivel";
            cmbNivel.Size = new Size(400, 28);
            cmbNivel.TabIndex = 8;
            cmbNivel.SelectedIndexChanged += cmbNivel_SelectedIndexChanged;
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Location = new Point(291, 167);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(46, 20);
            lblFiltro.TabIndex = 9;
            lblFiltro.Text = "Filtro:";
            // 
            // cmbFiltro
            // 
            cmbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltro.FormattingEnabled = true;
            cmbFiltro.Location = new Point(389, 159);
            cmbFiltro.Name = "cmbFiltro";
            cmbFiltro.Size = new Size(151, 28);
            cmbFiltro.TabIndex = 10;
            // 
            // pnlGrafica
            // 
            pnlGrafica.AutoScroll = true;
            pnlGrafica.BorderStyle = BorderStyle.FixedSingle;
            pnlGrafica.Location = new Point(61, 648);
            pnlGrafica.Name = "pnlGrafica";
            pnlGrafica.Size = new Size(850, 220);
            pnlGrafica.TabIndex = 11;
            // 
            // FrmResultados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(981, 949);
            Controls.Add(pnlGrafica);
            Controls.Add(cmbFiltro);
            Controls.Add(lblFiltro);
            Controls.Add(cmbNivel);
            Controls.Add(lblNivel);
            Controls.Add(lblAbstencionismo);
            Controls.Add(lblParticipacion);
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
        private Label lblParticipacion;
        private Label lblAbstencionismo;
        private Label lblNivel;
        private ComboBox cmbNivel;
        private Label lblFiltro;
        private ComboBox cmbFiltro;
        private Panel pnlGrafica;
    }
}