namespace Salve_Vidas
{
    partial class RemoveEndereco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveEndereco));
            this.LblRedSenha = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CBBxEndereco = new System.Windows.Forms.ComboBox();
            this.LblNvEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblRedSenha
            // 
            this.LblRedSenha.AutoSize = true;
            this.LblRedSenha.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblRedSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblRedSenha.Location = new System.Drawing.Point(218, 9);
            this.LblRedSenha.Name = "LblRedSenha";
            this.LblRedSenha.Size = new System.Drawing.Size(229, 33);
            this.LblRedSenha.TabIndex = 74;
            this.LblRedSenha.Text = "Remover Endereço";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(211)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(278, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 27);
            this.button1.TabIndex = 76;
            this.button1.Text = "Remover Endereço";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CBBxEndereco
            // 
            this.CBBxEndereco.FormattingEnabled = true;
            this.CBBxEndereco.Location = new System.Drawing.Point(218, 129);
            this.CBBxEndereco.Name = "CBBxEndereco";
            this.CBBxEndereco.Size = new System.Drawing.Size(229, 23);
            this.CBBxEndereco.TabIndex = 77;
            this.CBBxEndereco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CBBxEndereco_KeyPress);
            // 
            // LblNvEmail
            // 
            this.LblNvEmail.AutoSize = true;
            this.LblNvEmail.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblNvEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblNvEmail.Location = new System.Drawing.Point(218, 102);
            this.LblNvEmail.Name = "LblNvEmail";
            this.LblNvEmail.Size = new System.Drawing.Size(142, 15);
            this.LblNvEmail.TabIndex = 78;
            this.LblNvEmail.Text = "Endereço a ser Deletado:";
            // 
            // RemoveEndereco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(459, 247);
            this.Controls.Add(this.LblNvEmail);
            this.Controls.Add(this.CBBxEndereco);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LblRedSenha);
            this.MaximizeBox = false;
            this.Name = "RemoveEndereco";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemoveEndereco";
            this.Load += new System.EventHandler(this.RemoveEndereco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LblRedSenha;
        private PictureBox pictureBox1;
        private Button button1;
        private ComboBox CBBxEndereco;
        private Label LblNvEmail;
    }
}