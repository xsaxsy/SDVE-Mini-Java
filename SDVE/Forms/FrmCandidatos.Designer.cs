namespace SDVE.Forms
{
    partial class FrmCandidatos
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
            dgvCandidatos = new DataGridView();
            btnAgregar = new Button();
            button1 = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCandidatos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(51, 55, 113);
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(-1, -1);
            label1.Name = "label1";
            label1.Size = new Size(984, 56);
            label1.TabIndex = 0;
            label1.Text = "GESTIÓN DE CANDIDATOS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvCandidatos
            // 
            dgvCandidatos.AllowUserToAddRows = false;
            dgvCandidatos.AllowUserToDeleteRows = false;
            dgvCandidatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCandidatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCandidatos.Location = new Point(35, 83);
            dgvCandidatos.MultiSelect = false;
            dgvCandidatos.Name = "dgvCandidatos";
            dgvCandidatos.ReadOnly = true;
            dgvCandidatos.RowHeadersWidth = 51;
            dgvCandidatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCandidatos.Size = new Size(900, 400);
            dgvCandidatos.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(46, 524);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(162, 29);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar Candidato";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // button1
            // 
            button1.Location = new Point(363, 524);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Regresar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(612, 524);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(841, 524);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FrmCandidatos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 653);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(button1);
            Controls.Add(btnAgregar);
            Controls.Add(dgvCandidatos);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmCandidatos";
            Text = "Gestión de Candidatos - SDVE";
            ((System.ComponentModel.ISupportInitialize)dgvCandidatos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private DataGridView dgvCandidatos;
        private Button btnAgregar;
        private Button button1;
        private Button btnEditar;
        private Button btnEliminar;
    }
}
