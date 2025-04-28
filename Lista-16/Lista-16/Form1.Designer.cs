namespace Lista_16
{
    partial class Form1
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
            lblFunc = new Label();
            txtListarPorNome = new TextBox();
            dataGridView1 = new DataGridView();
            lblID = new Label();
            lblNome = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtID = new TextBox();
            txtNome = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            txtSalario = new TextBox();
            maskedTextBox1 = new MaskedTextBox();
            txtCargo = new TextBox();
            comboSetor = new ComboBox();
            rbFeminino = new RadioButton();
            rbMasculino = new RadioButton();
            groupBox1 = new GroupBox();
            btnGravar = new Button();
            btnEditar = new Button();
            btnExcluir = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblFunc
            // 
            lblFunc.AutoSize = true;
            lblFunc.Location = new Point(26, 22);
            lblFunc.Name = "lblFunc";
            lblFunc.Size = new Size(166, 15);
            lblFunc.TabIndex = 0;
            lblFunc.Text = "Digite o nome do funcionário:";
            // 
            // txtListarPorNome
            // 
            txtListarPorNome.Location = new Point(217, 19);
            txtListarPorNome.Name = "txtListarPorNome";
            txtListarPorNome.Size = new Size(335, 23);
            txtListarPorNome.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(26, 58);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(650, 178);
            dataGridView1.TabIndex = 2;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(26, 257);
            lblID.Name = "lblID";
            lblID.Size = new Size(21, 15);
            lblID.TabIndex = 3;
            lblID.Text = "ID:";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(26, 291);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 15);
            lblNome.TabIndex = 4;
            lblNome.Text = "Nome:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 331);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 5;
            label1.Text = "Nascimento:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 365);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 6;
            label2.Text = "Salário:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(469, 254);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 7;
            label3.Text = "Cargo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(272, 296);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 8;
            label4.Text = "Setor:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(272, 257);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 9;
            label5.Text = "CPF:";
            // 
            // txtID
            // 
            txtID.Location = new Point(75, 254);
            txtID.Name = "txtID";
            txtID.Size = new Size(64, 23);
            txtID.TabIndex = 10;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(75, 288);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(140, 23);
            txtNome.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(106, 325);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(109, 23);
            dateTimePicker1.TabIndex = 12;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // txtSalario
            // 
            txtSalario.Location = new Point(75, 362);
            txtSalario.Name = "txtSalario";
            txtSalario.Size = new Size(140, 23);
            txtSalario.TabIndex = 13;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.HidePromptOnLeave = true;
            maskedTextBox1.ImeMode = ImeMode.NoControl;
            maskedTextBox1.InsertKeyMode = InsertKeyMode.Overwrite;
            maskedTextBox1.Location = new Point(326, 254);
            maskedTextBox1.Mask = "000.000.000-00";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(100, 23);
            maskedTextBox1.TabIndex = 14;
            // 
            // txtCargo
            // 
            txtCargo.Location = new Point(523, 250);
            txtCargo.Name = "txtCargo";
            txtCargo.Size = new Size(153, 23);
            txtCargo.TabIndex = 15;
            // 
            // comboSetor
            // 
            comboSetor.FormattingEnabled = true;
            comboSetor.Location = new Point(326, 293);
            comboSetor.Name = "comboSetor";
            comboSetor.Size = new Size(100, 23);
            comboSetor.TabIndex = 16;
            // 
            // rbFeminino
            // 
            rbFeminino.AutoSize = true;
            rbFeminino.Location = new Point(115, 37);
            rbFeminino.Name = "rbFeminino";
            rbFeminino.Size = new Size(75, 19);
            rbFeminino.TabIndex = 17;
            rbFeminino.TabStop = true;
            rbFeminino.Text = "Feminino";
            rbFeminino.UseVisualStyleBackColor = true;
            // 
            // rbMasculino
            // 
            rbMasculino.AutoSize = true;
            rbMasculino.Location = new Point(16, 37);
            rbMasculino.Name = "rbMasculino";
            rbMasculino.Size = new Size(80, 19);
            rbMasculino.TabIndex = 18;
            rbMasculino.TabStop = true;
            rbMasculino.Text = "Masculino";
            rbMasculino.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbMasculino);
            groupBox1.Controls.Add(rbFeminino);
            groupBox1.Location = new Point(469, 296);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(207, 85);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sexo:";
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(160, 441);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 20;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(326, 441);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 21;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(477, 441);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 22;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(691, 476);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(btnGravar);
            Controls.Add(groupBox1);
            Controls.Add(comboSetor);
            Controls.Add(txtCargo);
            Controls.Add(maskedTextBox1);
            Controls.Add(txtSalario);
            Controls.Add(dateTimePicker1);
            Controls.Add(txtNome);
            Controls.Add(txtID);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblNome);
            Controls.Add(lblID);
            Controls.Add(dataGridView1);
            Controls.Add(txtListarPorNome);
            Controls.Add(lblFunc);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFunc;
        private TextBox txtListarPorNome;
        private DataGridView dataGridView1;
        private Label lblID;
        private Label lblNome;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtID;
        private TextBox txtNome;
        private DateTimePicker dateTimePicker1;
        private TextBox txtSalario;
        private MaskedTextBox maskedTextBox1;
        private TextBox txtCargo;
        private ComboBox comboSetor;
        private RadioButton rbFeminino;
        private RadioButton rbMasculino;
        private GroupBox groupBox1;
        private Button btnGravar;
        private Button btnEditar;
        private Button btnExcluir;
    }
}
