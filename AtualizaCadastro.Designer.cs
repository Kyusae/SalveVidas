namespace Salve_Vidas
{
    partial class AtualizaCadastro
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
            this.RadBtAtualizaSenha = new System.Windows.Forms.RadioButton();
            this.RadBtAtualizaFoto = new System.Windows.Forms.RadioButton();
            this.RadBtAtualizaTipoSanguineo = new System.Windows.Forms.RadioButton();
            this.TxtBxNovaSenha = new System.Windows.Forms.TextBox();
            this.LblNvSenha = new System.Windows.Forms.Label();
            this.LblConfirmaSenha = new System.Windows.Forms.Label();
            this.TxtBxConfirmaSenha = new System.Windows.Forms.TextBox();
            this.BtAtualizaCadastro = new System.Windows.Forms.Button();
            this.LblNovoTipoSanguineo = new System.Windows.Forms.Label();
            this.CBBxTipoSanguineo = new System.Windows.Forms.ComboBox();
            this.PicBxAtualizaImagem = new System.Windows.Forms.PictureBox();
            this.BtBuscaImagemNova = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BtDeleteCadastro = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBxAtualizaImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Salve_Vidas.Properties.Resources.Logo_em_360p;
            this.pictureBox1.Location = new System.Drawing.Point(12, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LblRedSenha
            // 
            this.LblRedSenha.AutoSize = true;
            this.LblRedSenha.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblRedSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblRedSenha.Location = new System.Drawing.Point(141, 9);
            this.LblRedSenha.Name = "LblRedSenha";
            this.LblRedSenha.Size = new System.Drawing.Size(264, 33);
            this.LblRedSenha.TabIndex = 4;
            this.LblRedSenha.Text = "ATUALIZAR CADASTRO";
            // 
            // RadBtAtualizaSenha
            // 
            this.RadBtAtualizaSenha.AutoSize = true;
            this.RadBtAtualizaSenha.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RadBtAtualizaSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.RadBtAtualizaSenha.Location = new System.Drawing.Point(276, 103);
            this.RadBtAtualizaSenha.Name = "RadBtAtualizaSenha";
            this.RadBtAtualizaSenha.Size = new System.Drawing.Size(111, 19);
            this.RadBtAtualizaSenha.TabIndex = 5;
            this.RadBtAtualizaSenha.TabStop = true;
            this.RadBtAtualizaSenha.Text = "Atualizar Senha";
            this.RadBtAtualizaSenha.UseVisualStyleBackColor = true;
            this.RadBtAtualizaSenha.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // RadBtAtualizaFoto
            // 
            this.RadBtAtualizaFoto.AutoSize = true;
            this.RadBtAtualizaFoto.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RadBtAtualizaFoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.RadBtAtualizaFoto.Location = new System.Drawing.Point(445, 68);
            this.RadBtAtualizaFoto.Name = "RadBtAtualizaFoto";
            this.RadBtAtualizaFoto.Size = new System.Drawing.Size(102, 19);
            this.RadBtAtualizaFoto.TabIndex = 6;
            this.RadBtAtualizaFoto.TabStop = true;
            this.RadBtAtualizaFoto.Text = "Atualizar Foto";
            this.RadBtAtualizaFoto.UseVisualStyleBackColor = true;
            this.RadBtAtualizaFoto.CheckedChanged += new System.EventHandler(this.RadBtAtualizaFoto_CheckedChanged);
            // 
            // RadBtAtualizaTipoSanguineo
            // 
            this.RadBtAtualizaTipoSanguineo.AutoSize = true;
            this.RadBtAtualizaTipoSanguineo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RadBtAtualizaTipoSanguineo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.RadBtAtualizaTipoSanguineo.Location = new System.Drawing.Point(276, 68);
            this.RadBtAtualizaTipoSanguineo.Name = "RadBtAtualizaTipoSanguineo";
            this.RadBtAtualizaTipoSanguineo.Size = new System.Drawing.Size(162, 19);
            this.RadBtAtualizaTipoSanguineo.TabIndex = 8;
            this.RadBtAtualizaTipoSanguineo.TabStop = true;
            this.RadBtAtualizaTipoSanguineo.Text = "Atualizar Tipo Sanguineo";
            this.RadBtAtualizaTipoSanguineo.UseVisualStyleBackColor = true;
            this.RadBtAtualizaTipoSanguineo.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // TxtBxNovaSenha
            // 
            this.TxtBxNovaSenha.Location = new System.Drawing.Point(304, 156);
            this.TxtBxNovaSenha.Name = "TxtBxNovaSenha";
            this.TxtBxNovaSenha.PlaceholderText = "Nova Senha";
            this.TxtBxNovaSenha.Size = new System.Drawing.Size(202, 23);
            this.TxtBxNovaSenha.TabIndex = 9;
            this.TxtBxNovaSenha.Visible = false;
            // 
            // LblNvSenha
            // 
            this.LblNvSenha.AutoSize = true;
            this.LblNvSenha.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblNvSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblNvSenha.Location = new System.Drawing.Point(304, 138);
            this.LblNvSenha.Name = "LblNvSenha";
            this.LblNvSenha.Size = new System.Drawing.Size(74, 15);
            this.LblNvSenha.TabIndex = 10;
            this.LblNvSenha.Text = "Nova Senha:";
            this.LblNvSenha.Visible = false;
            // 
            // LblConfirmaSenha
            // 
            this.LblConfirmaSenha.AutoSize = true;
            this.LblConfirmaSenha.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblConfirmaSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblConfirmaSenha.Location = new System.Drawing.Point(304, 195);
            this.LblConfirmaSenha.Name = "LblConfirmaSenha";
            this.LblConfirmaSenha.Size = new System.Drawing.Size(101, 15);
            this.LblConfirmaSenha.TabIndex = 11;
            this.LblConfirmaSenha.Text = "Confirmar Senha:";
            this.LblConfirmaSenha.Visible = false;
            // 
            // TxtBxConfirmaSenha
            // 
            this.TxtBxConfirmaSenha.Location = new System.Drawing.Point(304, 213);
            this.TxtBxConfirmaSenha.Name = "TxtBxConfirmaSenha";
            this.TxtBxConfirmaSenha.PlaceholderText = "Confirmar Senha";
            this.TxtBxConfirmaSenha.Size = new System.Drawing.Size(202, 23);
            this.TxtBxConfirmaSenha.TabIndex = 12;
            this.TxtBxConfirmaSenha.Visible = false;
            // 
            // BtAtualizaCadastro
            // 
            this.BtAtualizaCadastro.BackColor = System.Drawing.Color.White;
            this.BtAtualizaCadastro.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtAtualizaCadastro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(211)))), ((int)(((byte)(192)))));
            this.BtAtualizaCadastro.Location = new System.Drawing.Point(212, 262);
            this.BtAtualizaCadastro.Name = "BtAtualizaCadastro";
            this.BtAtualizaCadastro.Size = new System.Drawing.Size(124, 26);
            this.BtAtualizaCadastro.TabIndex = 13;
            this.BtAtualizaCadastro.Text = "Atualizar Cadastro";
            this.BtAtualizaCadastro.UseVisualStyleBackColor = false;
            this.BtAtualizaCadastro.Visible = false;
            this.BtAtualizaCadastro.Click += new System.EventHandler(this.BtRedSenha_Click);
            // 
            // LblNovoTipoSanguineo
            // 
            this.LblNovoTipoSanguineo.AutoSize = true;
            this.LblNovoTipoSanguineo.BackColor = System.Drawing.Color.Transparent;
            this.LblNovoTipoSanguineo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblNovoTipoSanguineo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblNovoTipoSanguineo.Location = new System.Drawing.Point(304, 138);
            this.LblNovoTipoSanguineo.Name = "LblNovoTipoSanguineo";
            this.LblNovoTipoSanguineo.Size = new System.Drawing.Size(94, 15);
            this.LblNovoTipoSanguineo.TabIndex = 14;
            this.LblNovoTipoSanguineo.Text = "Tipo Sanguineo:";
            this.LblNovoTipoSanguineo.Visible = false;
            // 
            // CBBxTipoSanguineo
            // 
            this.CBBxTipoSanguineo.FormattingEnabled = true;
            this.CBBxTipoSanguineo.Location = new System.Drawing.Point(304, 156);
            this.CBBxTipoSanguineo.Name = "CBBxTipoSanguineo";
            this.CBBxTipoSanguineo.Size = new System.Drawing.Size(202, 23);
            this.CBBxTipoSanguineo.TabIndex = 15;
            this.CBBxTipoSanguineo.Visible = false;
            this.CBBxTipoSanguineo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CBBxTipoSanguineo_KeyPress);
            // 
            // PicBxAtualizaImagem
            // 
            this.PicBxAtualizaImagem.Location = new System.Drawing.Point(304, 142);
            this.PicBxAtualizaImagem.Name = "PicBxAtualizaImagem";
            this.PicBxAtualizaImagem.Size = new System.Drawing.Size(134, 94);
            this.PicBxAtualizaImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBxAtualizaImagem.TabIndex = 16;
            this.PicBxAtualizaImagem.TabStop = false;
            // 
            // BtBuscaImagemNova
            // 
            this.BtBuscaImagemNova.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtBuscaImagemNova.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(211)))), ((int)(((byte)(192)))));
            this.BtBuscaImagemNova.Location = new System.Drawing.Point(444, 195);
            this.BtBuscaImagemNova.Name = "BtBuscaImagemNova";
            this.BtBuscaImagemNova.Size = new System.Drawing.Size(71, 41);
            this.BtBuscaImagemNova.TabIndex = 17;
            this.BtBuscaImagemNova.Text = "Buscar Foto";
            this.BtBuscaImagemNova.UseVisualStyleBackColor = true;
            this.BtBuscaImagemNova.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BtDeleteCadastro
            // 
            this.BtDeleteCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtDeleteCadastro.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtDeleteCadastro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.BtDeleteCadastro.Location = new System.Drawing.Point(433, 271);
            this.BtDeleteCadastro.Name = "BtDeleteCadastro";
            this.BtDeleteCadastro.Size = new System.Drawing.Size(102, 23);
            this.BtDeleteCadastro.TabIndex = 18;
            this.BtDeleteCadastro.Text = "Deletar Cadastro";
            this.BtDeleteCadastro.UseVisualStyleBackColor = true;
            this.BtDeleteCadastro.Click += new System.EventHandler(this.BtDeleteCadastro_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(25, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "* Somente um item é atualizado por vez";
            // 
            // AtualizaCadastro
            // 
            this.AcceptButton = this.BtAtualizaCadastro;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(559, 306);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtDeleteCadastro);
            this.Controls.Add(this.BtBuscaImagemNova);
            this.Controls.Add(this.PicBxAtualizaImagem);
            this.Controls.Add(this.CBBxTipoSanguineo);
            this.Controls.Add(this.LblNovoTipoSanguineo);
            this.Controls.Add(this.BtAtualizaCadastro);
            this.Controls.Add(this.TxtBxConfirmaSenha);
            this.Controls.Add(this.LblConfirmaSenha);
            this.Controls.Add(this.LblNvSenha);
            this.Controls.Add(this.TxtBxNovaSenha);
            this.Controls.Add(this.RadBtAtualizaTipoSanguineo);
            this.Controls.Add(this.RadBtAtualizaFoto);
            this.Controls.Add(this.RadBtAtualizaSenha);
            this.Controls.Add(this.LblRedSenha);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "AtualizaCadastro";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualizar Cadastro";
            this.Load += new System.EventHandler(this.AtualizaCadastro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBxAtualizaImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label LblRedSenha;
        private RadioButton RadBtAtualizaSenha;
        private RadioButton RadBtAtualizaFoto;
        private RadioButton RadBtAtualizaTipoSanguineo;
        private TextBox TxtBxNovaSenha;
        private Label LblNvSenha;
        private Label LblConfirmaSenha;
        private TextBox TxtBxConfirmaSenha;
        private Button BtAtualizaCadastro;
        private Label LblNovoTipoSanguineo;
        private ComboBox CBBxTipoSanguineo;
        private PictureBox PicBxAtualizaImagem;
        private Button BtBuscaImagemNova;
        private OpenFileDialog openFileDialog1;
        private Button BtDeleteCadastro;
        private Label label3;
    }
}