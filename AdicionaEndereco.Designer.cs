namespace Salve_Vidas
{
    partial class AdicionaEndereco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionaEndereco));
            this.TxtBxCidade = new System.Windows.Forms.TextBox();
            this.TxtBxEstado = new System.Windows.Forms.TextBox();
            this.TxtBxUF = new System.Windows.Forms.TextBox();
            this.LblUF = new System.Windows.Forms.Label();
            this.LblEstado = new System.Windows.Forms.Label();
            this.TxtBxCEP = new System.Windows.Forms.MaskedTextBox();
            this.LblCEP = new System.Windows.Forms.Label();
            this.LblCidade = new System.Windows.Forms.Label();
            this.TxtBxBairro = new System.Windows.Forms.TextBox();
            this.LblBairro = new System.Windows.Forms.Label();
            this.TxtBxComplemento = new System.Windows.Forms.TextBox();
            this.LblComplemento = new System.Windows.Forms.Label();
            this.TxtBxNumero = new System.Windows.Forms.TextBox();
            this.LblNumero = new System.Windows.Forms.Label();
            this.TxtBxEndereco = new System.Windows.Forms.TextBox();
            this.LblEndereco = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtCadastrar = new System.Windows.Forms.Button();
            this.LblRedSenha = new System.Windows.Forms.Label();
            this.RdBtEndereco = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtBxCidade
            // 
            this.TxtBxCidade.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TxtBxCidade.Location = new System.Drawing.Point(473, 184);
            this.TxtBxCidade.Name = "TxtBxCidade";
            this.TxtBxCidade.ReadOnly = true;
            this.TxtBxCidade.Size = new System.Drawing.Size(176, 23);
            this.TxtBxCidade.TabIndex = 70;
            // 
            // TxtBxEstado
            // 
            this.TxtBxEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TxtBxEstado.Location = new System.Drawing.Point(255, 184);
            this.TxtBxEstado.Name = "TxtBxEstado";
            this.TxtBxEstado.ReadOnly = true;
            this.TxtBxEstado.Size = new System.Drawing.Size(114, 23);
            this.TxtBxEstado.TabIndex = 69;
            // 
            // TxtBxUF
            // 
            this.TxtBxUF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TxtBxUF.Location = new System.Drawing.Point(473, 228);
            this.TxtBxUF.Name = "TxtBxUF";
            this.TxtBxUF.PlaceholderText = "UF";
            this.TxtBxUF.ReadOnly = true;
            this.TxtBxUF.Size = new System.Drawing.Size(100, 23);
            this.TxtBxUF.TabIndex = 68;
            // 
            // LblUF
            // 
            this.LblUF.AutoSize = true;
            this.LblUF.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblUF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblUF.Location = new System.Drawing.Point(443, 231);
            this.LblUF.Name = "LblUF";
            this.LblUF.Size = new System.Drawing.Size(24, 15);
            this.LblUF.TabIndex = 67;
            this.LblUF.Text = "UF:";
            // 
            // LblEstado
            // 
            this.LblEstado.AutoSize = true;
            this.LblEstado.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblEstado.Location = new System.Drawing.Point(202, 187);
            this.LblEstado.Name = "LblEstado";
            this.LblEstado.Size = new System.Drawing.Size(47, 15);
            this.LblEstado.TabIndex = 66;
            this.LblEstado.Text = "Estado:";
            // 
            // TxtBxCEP
            // 
            this.TxtBxCEP.Location = new System.Drawing.Point(255, 93);
            this.TxtBxCEP.Mask = "00000-000";
            this.TxtBxCEP.Name = "TxtBxCEP";
            this.TxtBxCEP.Size = new System.Drawing.Size(114, 23);
            this.TxtBxCEP.TabIndex = 1;
            this.TxtBxCEP.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.TxtBxCEP_MaskInputRejected);
            this.TxtBxCEP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBxCEP_KeyPress);
            this.TxtBxCEP.Leave += new System.EventHandler(this.TxtBxCEP_Leave);
            // 
            // LblCEP
            // 
            this.LblCEP.AutoSize = true;
            this.LblCEP.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCEP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblCEP.Location = new System.Drawing.Point(219, 96);
            this.LblCEP.Name = "LblCEP";
            this.LblCEP.Size = new System.Drawing.Size(30, 15);
            this.LblCEP.TabIndex = 65;
            this.LblCEP.Text = "CEP:";
            // 
            // LblCidade
            // 
            this.LblCidade.AutoSize = true;
            this.LblCidade.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblCidade.Location = new System.Drawing.Point(419, 187);
            this.LblCidade.Name = "LblCidade";
            this.LblCidade.Size = new System.Drawing.Size(48, 15);
            this.LblCidade.TabIndex = 64;
            this.LblCidade.Text = "Cidade:";
            // 
            // TxtBxBairro
            // 
            this.TxtBxBairro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TxtBxBairro.Location = new System.Drawing.Point(255, 228);
            this.TxtBxBairro.MaxLength = 20;
            this.TxtBxBairro.Name = "TxtBxBairro";
            this.TxtBxBairro.PlaceholderText = "Bairro";
            this.TxtBxBairro.ReadOnly = true;
            this.TxtBxBairro.Size = new System.Drawing.Size(114, 23);
            this.TxtBxBairro.TabIndex = 58;
            // 
            // LblBairro
            // 
            this.LblBairro.AutoSize = true;
            this.LblBairro.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblBairro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblBairro.Location = new System.Drawing.Point(204, 231);
            this.LblBairro.Name = "LblBairro";
            this.LblBairro.Size = new System.Drawing.Size(45, 15);
            this.LblBairro.TabIndex = 63;
            this.LblBairro.Text = "Bairro:";
            // 
            // TxtBxComplemento
            // 
            this.TxtBxComplemento.Location = new System.Drawing.Point(473, 138);
            this.TxtBxComplemento.MaxLength = 10;
            this.TxtBxComplemento.Name = "TxtBxComplemento";
            this.TxtBxComplemento.PlaceholderText = "Complemento";
            this.TxtBxComplemento.Size = new System.Drawing.Size(176, 23);
            this.TxtBxComplemento.TabIndex = 3;
            this.TxtBxComplemento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBxComplemento_KeyPress);
            // 
            // LblComplemento
            // 
            this.LblComplemento.AutoSize = true;
            this.LblComplemento.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblComplemento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblComplemento.Location = new System.Drawing.Point(382, 141);
            this.LblComplemento.Name = "LblComplemento";
            this.LblComplemento.Size = new System.Drawing.Size(85, 15);
            this.LblComplemento.TabIndex = 62;
            this.LblComplemento.Text = "Complemento:";
            // 
            // TxtBxNumero
            // 
            this.TxtBxNumero.Location = new System.Drawing.Point(255, 138);
            this.TxtBxNumero.MaxLength = 5;
            this.TxtBxNumero.Name = "TxtBxNumero";
            this.TxtBxNumero.PlaceholderText = "Numero da Casa/Ap.";
            this.TxtBxNumero.Size = new System.Drawing.Size(114, 23);
            this.TxtBxNumero.TabIndex = 2;
            this.TxtBxNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBxNumero_KeyPress);
            this.TxtBxNumero.Leave += new System.EventHandler(this.TxtBxNumero_Leave);
            // 
            // LblNumero
            // 
            this.LblNumero.AutoSize = true;
            this.LblNumero.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblNumero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblNumero.Location = new System.Drawing.Point(196, 141);
            this.LblNumero.Name = "LblNumero";
            this.LblNumero.Size = new System.Drawing.Size(53, 15);
            this.LblNumero.TabIndex = 61;
            this.LblNumero.Text = "Numero:";
            // 
            // TxtBxEndereco
            // 
            this.TxtBxEndereco.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TxtBxEndereco.Location = new System.Drawing.Point(473, 93);
            this.TxtBxEndereco.MaxLength = 20;
            this.TxtBxEndereco.Name = "TxtBxEndereco";
            this.TxtBxEndereco.PlaceholderText = "Nome da Rua";
            this.TxtBxEndereco.ReadOnly = true;
            this.TxtBxEndereco.Size = new System.Drawing.Size(176, 23);
            this.TxtBxEndereco.TabIndex = 55;
            // 
            // LblEndereco
            // 
            this.LblEndereco.AutoSize = true;
            this.LblEndereco.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblEndereco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblEndereco.Location = new System.Drawing.Point(407, 96);
            this.LblEndereco.Name = "LblEndereco";
            this.LblEndereco.Size = new System.Drawing.Size(60, 15);
            this.LblEndereco.TabIndex = 60;
            this.LblEndereco.Text = "Endereço:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 71;
            this.pictureBox1.TabStop = false;
            // 
            // BtCadastrar
            // 
            this.BtCadastrar.Enabled = false;
            this.BtCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtCadastrar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtCadastrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(211)))), ((int)(((byte)(192)))));
            this.BtCadastrar.Location = new System.Drawing.Point(294, 274);
            this.BtCadastrar.Name = "BtCadastrar";
            this.BtCadastrar.Size = new System.Drawing.Size(82, 34);
            this.BtCadastrar.TabIndex = 4;
            this.BtCadastrar.Text = "Cadastrar";
            this.BtCadastrar.UseVisualStyleBackColor = true;
            this.BtCadastrar.Click += new System.EventHandler(this.BtCadastrar_Click);
            // 
            // LblRedSenha
            // 
            this.LblRedSenha.AutoSize = true;
            this.LblRedSenha.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblRedSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblRedSenha.Location = new System.Drawing.Point(223, 9);
            this.LblRedSenha.Name = "LblRedSenha";
            this.LblRedSenha.Size = new System.Drawing.Size(233, 33);
            this.LblRedSenha.TabIndex = 73;
            this.LblRedSenha.Text = "Adicionar Endereço";
            // 
            // RdBtEndereco
            // 
            this.RdBtEndereco.AutoSize = true;
            this.RdBtEndereco.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RdBtEndereco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.RdBtEndereco.Location = new System.Drawing.Point(204, 55);
            this.RdBtEndereco.Name = "RdBtEndereco";
            this.RdBtEndereco.Size = new System.Drawing.Size(181, 18);
            this.RdBtEndereco.TabIndex = 74;
            this.RdBtEndereco.TabStop = true;
            this.RdBtEndereco.Text = "Meu Endereço está incorreto";
            this.RdBtEndereco.UseVisualStyleBackColor = true;
            this.RdBtEndereco.Visible = false;
            // 
            // AdicionaEndereco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(672, 320);
            this.Controls.Add(this.RdBtEndereco);
            this.Controls.Add(this.LblRedSenha);
            this.Controls.Add(this.BtCadastrar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TxtBxCidade);
            this.Controls.Add(this.TxtBxEstado);
            this.Controls.Add(this.TxtBxUF);
            this.Controls.Add(this.LblUF);
            this.Controls.Add(this.LblEstado);
            this.Controls.Add(this.TxtBxCEP);
            this.Controls.Add(this.LblCEP);
            this.Controls.Add(this.LblCidade);
            this.Controls.Add(this.TxtBxBairro);
            this.Controls.Add(this.LblBairro);
            this.Controls.Add(this.TxtBxComplemento);
            this.Controls.Add(this.LblComplemento);
            this.Controls.Add(this.TxtBxNumero);
            this.Controls.Add(this.LblNumero);
            this.Controls.Add(this.TxtBxEndereco);
            this.Controls.Add(this.LblEndereco);
            this.MaximizeBox = false;
            this.Name = "AdicionaEndereco";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Endereco";
            this.Activated += new System.EventHandler(this.AdicionaEndereco_Activated);
            this.Load += new System.EventHandler(this.AdicionaEndereco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox TxtBxCidade;
        private TextBox TxtBxEstado;
        private TextBox TxtBxUF;
        private Label LblUF;
        private Label LblEstado;
        private MaskedTextBox TxtBxCEP;
        private Label LblCEP;
        private Label LblCidade;
        private TextBox TxtBxBairro;
        private Label LblBairro;
        private TextBox TxtBxComplemento;
        private Label LblComplemento;
        private TextBox TxtBxNumero;
        private Label LblNumero;
        private TextBox TxtBxEndereco;
        private Label LblEndereco;
        private PictureBox pictureBox1;
        private Button BtCadastrar;
        private Label LblRedSenha;
        private RadioButton RdBtEndereco;
    }
}