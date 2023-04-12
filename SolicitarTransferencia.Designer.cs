namespace Salve_Vidas
{
    partial class SolicitarTransferencia
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
            this.CBBxTipoSanguineo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBxQuantidade = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Salve_Vidas.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(414, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(276, 213);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // LblRedSenha
            // 
            this.LblRedSenha.AutoSize = true;
            this.LblRedSenha.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblRedSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblRedSenha.Location = new System.Drawing.Point(33, 36);
            this.LblRedSenha.Name = "LblRedSenha";
            this.LblRedSenha.Size = new System.Drawing.Size(316, 33);
            this.LblRedSenha.TabIndex = 6;
            this.LblRedSenha.Text = "SOLICITAR TRANSFERENCIA";
            // 
            // CBBxTipoSanguineo
            // 
            this.CBBxTipoSanguineo.FormattingEnabled = true;
            this.CBBxTipoSanguineo.Location = new System.Drawing.Point(211, 86);
            this.CBBxTipoSanguineo.Name = "CBBxTipoSanguineo";
            this.CBBxTipoSanguineo.Size = new System.Drawing.Size(184, 23);
            this.CBBxTipoSanguineo.TabIndex = 27;
            this.CBBxTipoSanguineo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CBBxTipoSanguineo_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(54)))), ((int)(((byte)(108)))));
            this.label1.Location = new System.Drawing.Point(13, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 19);
            this.label1.TabIndex = 28;
            this.label1.Text = "Tipo Sanguineo Solicitado:";
            // 
            // TxtBxQuantidade
            // 
            this.TxtBxQuantidade.Location = new System.Drawing.Point(211, 135);
            this.TxtBxQuantidade.MaxLength = 50;
            this.TxtBxQuantidade.Name = "TxtBxQuantidade";
            this.TxtBxQuantidade.PlaceholderText = "Quantidade em Litros (20)";
            this.TxtBxQuantidade.Size = new System.Drawing.Size(184, 23);
            this.TxtBxQuantidade.TabIndex = 29;
            this.TxtBxQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBxQuantidade_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(54)))), ((int)(((byte)(108)))));
            this.label7.Location = new System.Drawing.Point(40, 135);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 19);
            this.label7.TabIndex = 30;
            this.label7.Text = "Quantidade Solicitada:";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(206)))), ((int)(((byte)(193)))));
            this.button1.Location = new System.Drawing.Point(182, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 53);
            this.button1.TabIndex = 31;
            this.button1.Text = "Solicitar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SolicitarTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(702, 254);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtBxQuantidade);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CBBxTipoSanguineo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblRedSenha);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "SolicitarTransferencia";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SolicitarTransferencia";
            this.Load += new System.EventHandler(this.SolicitarTransferencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label LblRedSenha;
        private ComboBox CBBxTipoSanguineo;
        private Label label1;
        private TextBox TxtBxQuantidade;
        private Label label7;
        private Button button1;
    }
}