namespace Salve_Vidas
{
    partial class SalveVidas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalveVidas));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtBxEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LblRedSenha = new System.Windows.Forms.Label();
            this.PcBxInvisivel = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PcBxVisivel = new System.Windows.Forms.PictureBox();
            this.TxtBxSenha = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBxInvisivel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBxVisivel)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(496, 285);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BtLogin
            // 
            this.BtLogin.BackColor = System.Drawing.Color.White;
            this.BtLogin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(211)))), ((int)(((byte)(192)))));
            this.BtLogin.Location = new System.Drawing.Point(636, 313);
            this.BtLogin.Name = "BtLogin";
            this.BtLogin.Size = new System.Drawing.Size(140, 28);
            this.BtLogin.TabIndex = 1;
            this.BtLogin.Text = "LOGIN";
            this.BtLogin.UseVisualStyleBackColor = false;
            this.BtLogin.Click += new System.EventHandler(this.BtLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.label1.Location = new System.Drawing.Point(583, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "LOGIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.label2.Location = new System.Drawing.Point(594, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email";
            // 
            // TxtBxEmail
            // 
            this.TxtBxEmail.Location = new System.Drawing.Point(594, 208);
            this.TxtBxEmail.Name = "TxtBxEmail";
            this.TxtBxEmail.PlaceholderText = "Email";
            this.TxtBxEmail.Size = new System.Drawing.Size(219, 23);
            this.TxtBxEmail.TabIndex = 4;
            this.TxtBxEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBxEmail_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.label3.Location = new System.Drawing.Point(594, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Senha";
            // 
            // LblRedSenha
            // 
            this.LblRedSenha.AutoSize = true;
            this.LblRedSenha.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblRedSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblRedSenha.Location = new System.Drawing.Point(559, 376);
            this.LblRedSenha.Name = "LblRedSenha";
            this.LblRedSenha.Size = new System.Drawing.Size(133, 19);
            this.LblRedSenha.TabIndex = 7;
            this.LblRedSenha.Text = "Esqueceu a senha?";
            this.LblRedSenha.Click += new System.EventHandler(this.label4_Click);
            // 
            // PcBxInvisivel
            // 
            this.PcBxInvisivel.Image = global::Salve_Vidas.Properties.Resources.Mostrar_Senha;
            this.PcBxInvisivel.Location = new System.Drawing.Point(819, 265);
            this.PcBxInvisivel.Name = "PcBxInvisivel";
            this.PcBxInvisivel.Size = new System.Drawing.Size(26, 22);
            this.PcBxInvisivel.TabIndex = 8;
            this.PcBxInvisivel.TabStop = false;
            this.PcBxInvisivel.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.label4.Location = new System.Drawing.Point(709, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Não possui uma conta?";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // PcBxVisivel
            // 
            this.PcBxVisivel.Image = global::Salve_Vidas.Properties.Resources.Mostrar_Senha2;
            this.PcBxVisivel.Location = new System.Drawing.Point(819, 264);
            this.PcBxVisivel.Name = "PcBxVisivel";
            this.PcBxVisivel.Size = new System.Drawing.Size(26, 23);
            this.PcBxVisivel.TabIndex = 10;
            this.PcBxVisivel.TabStop = false;
            this.PcBxVisivel.Click += new System.EventHandler(this.PcBxVisivel_Click);
            // 
            // TxtBxSenha
            // 
            this.TxtBxSenha.Location = new System.Drawing.Point(594, 263);
            this.TxtBxSenha.Name = "TxtBxSenha";
            this.TxtBxSenha.PlaceholderText = "Senha";
            this.TxtBxSenha.Size = new System.Drawing.Size(219, 23);
            this.TxtBxSenha.TabIndex = 6;
            this.TxtBxSenha.UseSystemPasswordChar = true;
            // 
            // SalveVidas
            // 
            this.AcceptButton = this.BtLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(897, 518);
            this.Controls.Add(this.PcBxInvisivel);
            this.Controls.Add(this.PcBxVisivel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LblRedSenha);
            this.Controls.Add(this.TxtBxSenha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtBxEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtLogin);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "SalveVidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salve+Vidas";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBxInvisivel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBxVisivel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button BtLogin;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label LblRedSenha;
        private PictureBox PcBxInvisivel;
        private Label label4;
        private PictureBox PcBxVisivel;
        public TextBox TxtBxEmail;
        public TextBox TxtBxSenha;
        private ToolTip toolTip1;
    }
}