namespace Salve_Vidas
{
    partial class CriaCampanha
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblRedSenha = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtBxNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CBBxTipoSanguineo = new System.Windows.Forms.ComboBox();
            this.CBBxHospital = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CBBxEstado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CBBxCidade = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Salve_Vidas.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(414, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(276, 213);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LblRedSenha
            // 
            this.LblRedSenha.AutoSize = true;
            this.LblRedSenha.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblRedSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblRedSenha.Location = new System.Drawing.Point(33, 36);
            this.LblRedSenha.Name = "LblRedSenha";
            this.LblRedSenha.Size = new System.Drawing.Size(362, 33);
            this.LblRedSenha.TabIndex = 5;
            this.LblRedSenha.Text = "CRIAR CAMPANHA DE DOAÇÃO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(54)))), ((int)(((byte)(108)))));
            this.label7.Location = new System.Drawing.Point(13, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 19);
            this.label7.TabIndex = 23;
            this.label7.Text = "Nome da Campanha:";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(206)))), ((int)(((byte)(193)))));
            this.button1.Location = new System.Drawing.Point(307, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 53);
            this.button1.TabIndex = 5;
            this.button1.Text = "Criar Campanha";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtBxNome
            // 
            this.TxtBxNome.Location = new System.Drawing.Point(171, 84);
            this.TxtBxNome.MaxLength = 50;
            this.TxtBxNome.Name = "TxtBxNome";
            this.TxtBxNome.PlaceholderText = "Campanha para o Daniel";
            this.TxtBxNome.Size = new System.Drawing.Size(224, 23);
            this.TxtBxNome.TabIndex = 1;
            this.TxtBxNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBxNome_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(54)))), ((int)(((byte)(108)))));
            this.label1.Location = new System.Drawing.Point(13, 124);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 19);
            this.label1.TabIndex = 26;
            this.label1.Text = "Tipo Sanguineo Solicitado:";
            // 
            // CBBxTipoSanguineo
            // 
            this.CBBxTipoSanguineo.FormattingEnabled = true;
            this.CBBxTipoSanguineo.Location = new System.Drawing.Point(211, 124);
            this.CBBxTipoSanguineo.Name = "CBBxTipoSanguineo";
            this.CBBxTipoSanguineo.Size = new System.Drawing.Size(184, 23);
            this.CBBxTipoSanguineo.TabIndex = 2;
            this.CBBxTipoSanguineo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CBBxTipoSanguineo_KeyPress);
            // 
            // CBBxHospital
            // 
            this.CBBxHospital.DropDownHeight = 100;
            this.CBBxHospital.FormattingEnabled = true;
            this.CBBxHospital.IntegralHeight = false;
            this.CBBxHospital.Location = new System.Drawing.Point(211, 246);
            this.CBBxHospital.Name = "CBBxHospital";
            this.CBBxHospital.Size = new System.Drawing.Size(184, 23);
            this.CBBxHospital.TabIndex = 4;
            this.CBBxHospital.Click += new System.EventHandler(this.CBBxHospital_Click);
            this.CBBxHospital.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CBBxHospital_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(54)))), ((int)(((byte)(108)))));
            this.label2.Location = new System.Drawing.Point(135, 246);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 29;
            this.label2.Text = "Hospital:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(54)))), ((int)(((byte)(108)))));
            this.label4.Location = new System.Drawing.Point(63, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 19);
            this.label4.TabIndex = 32;
            this.label4.Text = "Estado do Hospital:";
            // 
            // CBBxEstado
            // 
            this.CBBxEstado.DropDownHeight = 100;
            this.CBBxEstado.FormattingEnabled = true;
            this.CBBxEstado.IntegralHeight = false;
            this.CBBxEstado.Location = new System.Drawing.Point(211, 162);
            this.CBBxEstado.Name = "CBBxEstado";
            this.CBBxEstado.Size = new System.Drawing.Size(184, 23);
            this.CBBxEstado.TabIndex = 3;
            this.CBBxEstado.Click += new System.EventHandler(this.CBBxEstado_Click);
            this.CBBxEstado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CBBxEstado_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label5.Location = new System.Drawing.Point(510, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 15);
            this.label5.TabIndex = 34;
            this.label5.Text = "* Todos os itens são obrigatorios";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(54)))), ((int)(((byte)(108)))));
            this.label3.Location = new System.Drawing.Point(145, 207);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 19);
            this.label3.TabIndex = 36;
            this.label3.Text = "Cidade:";
            // 
            // CBBxCidade
            // 
            this.CBBxCidade.DropDownHeight = 100;
            this.CBBxCidade.FormattingEnabled = true;
            this.CBBxCidade.IntegralHeight = false;
            this.CBBxCidade.Location = new System.Drawing.Point(211, 207);
            this.CBBxCidade.Name = "CBBxCidade";
            this.CBBxCidade.Size = new System.Drawing.Size(184, 23);
            this.CBBxCidade.TabIndex = 35;
            this.CBBxCidade.Click += new System.EventHandler(this.comboBox1_Click);
            this.CBBxCidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // CriaCampanha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(702, 353);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CBBxCidade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CBBxEstado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CBBxHospital);
            this.Controls.Add(this.CBBxTipoSanguineo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtBxNome);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LblRedSenha);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "CriaCampanha";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criar Campanha";
            this.Load += new System.EventHandler(this.CriaCampanha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label LblRedSenha;
        private Label label7;
        private Button button1;
        private TextBox TxtBxNome;
        private Label label1;
        private ComboBox CBBxTipoSanguineo;
        private ComboBox CBBxHospital;
        private Label label2;
        private Label label4;
        private ComboBox CBBxEstado;
        private Label label5;
        private Label label3;
        private ComboBox CBBxCidade;
    }
}