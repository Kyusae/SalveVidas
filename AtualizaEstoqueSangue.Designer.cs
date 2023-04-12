namespace Salve_Vidas
{
    partial class AtualizaEstoqueSangue
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
            this.button1 = new System.Windows.Forms.Button();
            this.TxtBxQuantidadeAtual = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CBBxTipoSanguineo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblRedSenha = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TxtBxQuantidadeNova = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtBxQuantidadeLimite = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtBxQuantidadeMinima = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(206)))), ((int)(((byte)(193)))));
            this.button1.Location = new System.Drawing.Point(275, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 53);
            this.button1.TabIndex = 38;
            this.button1.Text = "Atualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtBxQuantidadeAtual
            // 
            this.TxtBxQuantidadeAtual.Location = new System.Drawing.Point(236, 211);
            this.TxtBxQuantidadeAtual.MaxLength = 50;
            this.TxtBxQuantidadeAtual.Name = "TxtBxQuantidadeAtual";
            this.TxtBxQuantidadeAtual.PlaceholderText = "Quantidade em Litros (20L)";
            this.TxtBxQuantidadeAtual.ReadOnly = true;
            this.TxtBxQuantidadeAtual.Size = new System.Drawing.Size(184, 23);
            this.TxtBxQuantidadeAtual.TabIndex = 36;
            this.TxtBxQuantidadeAtual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBxQuantidade_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(54)))), ((int)(((byte)(108)))));
            this.label7.Location = new System.Drawing.Point(21, 211);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(211, 19);
            this.label7.TabIndex = 37;
            this.label7.Text = "Quantidade Atual (Em Litros):";
            // 
            // CBBxTipoSanguineo
            // 
            this.CBBxTipoSanguineo.FormattingEnabled = true;
            this.CBBxTipoSanguineo.Location = new System.Drawing.Point(236, 74);
            this.CBBxTipoSanguineo.Name = "CBBxTipoSanguineo";
            this.CBBxTipoSanguineo.Size = new System.Drawing.Size(184, 23);
            this.CBBxTipoSanguineo.TabIndex = 34;
            this.CBBxTipoSanguineo.Click += new System.EventHandler(this.CBBxTipoSanguineo_Click);
            this.CBBxTipoSanguineo.Leave += new System.EventHandler(this.CBBxTipoSanguineo_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(54)))), ((int)(((byte)(108)))));
            this.label1.Location = new System.Drawing.Point(110, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 19);
            this.label1.TabIndex = 35;
            this.label1.Text = "Tipo Sanguineo:";
            // 
            // LblRedSenha
            // 
            this.LblRedSenha.AutoSize = true;
            this.LblRedSenha.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblRedSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblRedSenha.Location = new System.Drawing.Point(45, 22);
            this.LblRedSenha.Name = "LblRedSenha";
            this.LblRedSenha.Size = new System.Drawing.Size(361, 33);
            this.LblRedSenha.TabIndex = 33;
            this.LblRedSenha.Text = "ATUALIZAR BANCO DE SANGUE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Salve_Vidas.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(441, 84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(276, 213);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // TxtBxQuantidadeNova
            // 
            this.TxtBxQuantidadeNova.Location = new System.Drawing.Point(236, 262);
            this.TxtBxQuantidadeNova.MaxLength = 50;
            this.TxtBxQuantidadeNova.Name = "TxtBxQuantidadeNova";
            this.TxtBxQuantidadeNova.PlaceholderText = "Quantidade em Litros (20L)";
            this.TxtBxQuantidadeNova.Size = new System.Drawing.Size(184, 23);
            this.TxtBxQuantidadeNova.TabIndex = 39;
            this.TxtBxQuantidadeNova.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBxQuantidadeNova_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(54)))), ((int)(((byte)(108)))));
            this.label2.Location = new System.Drawing.Point(19, 262);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 19);
            this.label2.TabIndex = 40;
            this.label2.Text = "Quantidade Nova (Em Litros):";
            // 
            // TxtBxQuantidadeLimite
            // 
            this.TxtBxQuantidadeLimite.Location = new System.Drawing.Point(236, 120);
            this.TxtBxQuantidadeLimite.MaxLength = 50;
            this.TxtBxQuantidadeLimite.Name = "TxtBxQuantidadeLimite";
            this.TxtBxQuantidadeLimite.PlaceholderText = "Quantidade em Litros (20L)";
            this.TxtBxQuantidadeLimite.ReadOnly = true;
            this.TxtBxQuantidadeLimite.Size = new System.Drawing.Size(184, 23);
            this.TxtBxQuantidadeLimite.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(54)))), ((int)(((byte)(108)))));
            this.label3.Location = new System.Drawing.Point(4, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 19);
            this.label3.TabIndex = 42;
            this.label3.Text = "Quantidade Maxima (Em Litros):";
            // 
            // TxtBxQuantidadeMinima
            // 
            this.TxtBxQuantidadeMinima.Location = new System.Drawing.Point(237, 166);
            this.TxtBxQuantidadeMinima.MaxLength = 50;
            this.TxtBxQuantidadeMinima.Name = "TxtBxQuantidadeMinima";
            this.TxtBxQuantidadeMinima.PlaceholderText = "Quantidade em Litros (20L)";
            this.TxtBxQuantidadeMinima.ReadOnly = true;
            this.TxtBxQuantidadeMinima.Size = new System.Drawing.Size(184, 23);
            this.TxtBxQuantidadeMinima.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(54)))), ((int)(((byte)(108)))));
            this.label4.Location = new System.Drawing.Point(6, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 19);
            this.label4.TabIndex = 44;
            this.label4.Text = "Quantidade Minima (Em Litros):";
            // 
            // AtualizaEstoqueSangue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(729, 371);
            this.Controls.Add(this.TxtBxQuantidadeMinima);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtBxQuantidadeLimite);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtBxQuantidadeNova);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtBxQuantidadeAtual);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CBBxTipoSanguineo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblRedSenha);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "AtualizaEstoqueSangue";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AtualizaEstoqueSangue";
            this.Load += new System.EventHandler(this.AtualizaEstoqueSangue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox TxtBxQuantidadeAtual;
        private Label label7;
        private ComboBox CBBxTipoSanguineo;
        private Label label1;
        private Label LblRedSenha;
        private PictureBox pictureBox1;
        private TextBox TxtBxQuantidadeNova;
        private Label label2;
        private TextBox TxtBxQuantidadeLimite;
        private Label label3;
        private TextBox TxtBxQuantidadeMinima;
        private Label label4;
    }
}