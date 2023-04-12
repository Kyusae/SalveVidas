using Salve_Vidas.Db;
using Salve_Vidas.Model;

namespace Salve_Vidas
{
    public partial class AtualizaCadastro : Form
    {
        public string value { get; set; }
        public string value2 { get; set; }

        public string Atualizacao = null;

        string image = "";

        public AtualizaCadastro()
        {
            InitializeComponent();
        }

        private void AtualizaCadastro_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Logofull;

            if (Atualizacao == "1")
            {
                BtAtualizaCadastro.Visible = false;
                RadBtAtualizaTipoSanguineo.Visible = false;
                BtDeleteCadastro.Visible = false;

                RadBtAtualizaSenha.Location = new Point(264, 68);
                BuscaImagemHospital();
            }
            else
            {
                BtAtualizaCadastro.Visible = true;
                BuscaTipoSanguineo();
                BuscaImagem();
            }
        }

        private void BtRedSenha_Click(object sender, EventArgs e)
        {
            if (Atualizacao == "1")
            {
                if (RadBtAtualizaSenha.Checked)
                {
                    AtualizaSenha();
                }

                if (RadBtAtualizaFoto.Checked)
                {
                    AtualizaFotoHospital();
                }
            }
            else
            {
                if (RadBtAtualizaSenha.Checked)
                {
                    AtualizaSenha();
                }

                if (RadBtAtualizaTipoSanguineo.Checked)
                {
                    AtualizaTipoSanguineo();
                }

                if (RadBtAtualizaFoto.Checked)
                {
                    AtualizaFoto();
                }
            }
        }

        private void BuscaImagemHospital()
        {
            try
            {
                string Email = value;
                string Senha = value2;

                string query = $@"select b.Imagem as 'Foto'
                                  from Usuario a
                                  join UsuarioHospital b on b.IdUsuario = a.Id
                                  where a.Email = '{Email}'
                                  and a.Senha = '{Senha}'";

                var retorno = DBase.LoadData<Imagem>(query);

                if (retorno.FirstOrDefault().Foto == "")
                {
                    PicBxAtualizaImagem.Image = Properties.Resources.k;
                }
                else
                {
                    var teste = Base64ToImage(retorno.FirstOrDefault().Foto);
                    PicBxAtualizaImagem.Image = teste;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AtualizaFotoHospital()
        {
            try
            {
                string Email = value;
                string Senha = value2;

                string query = $@"update b set Imagem = '{image}'
                                  from Usuario a
                                  join UsuarioHospital b on b.IdUsuario = a.Id
                                  where a.Email = '{Email}'
                                  and a.Senha = '{Senha}'";

                var retorno = DBase.ExecuteWithReturnAffected(query);

                if (retorno == 0)
                {
                    MessageBox.Show("Erro ao atualizar imagem", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Imagem Atualizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            LblNovoTipoSanguineo.Visible = false;
            CBBxTipoSanguineo.Visible = false;
            PicBxAtualizaImagem.Visible = false;
            BtBuscaImagemNova.Visible = false;

            LblConfirmaSenha.Visible = true;
            LblNvSenha.Visible = true;
            TxtBxConfirmaSenha.Visible = true;
            TxtBxNovaSenha.Visible = true;

            BtAtualizaCadastro.Visible = true;
        }

        private void AtualizaSenha()
        {
            try
            {
                if (string.IsNullOrEmpty(TxtBxNovaSenha.Text) || string.IsNullOrEmpty(TxtBxConfirmaSenha.Text))
                {
                    MessageBox.Show("Informe a nova senha para atualizar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (TxtBxNovaSenha.Text != TxtBxConfirmaSenha.Text)
                    {
                        MessageBox.Show("As senhas devem ser iguais", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string Email = value;

                        string senhaantiga = value2;

                        string senhanova = TxtBxConfirmaSenha.Text.Trim();
                        string senhaHashnova = "";
                        senhaHashnova = Hash.criptografarSenha(senhanova);

                        if (senhaHashnova == value2)
                        {
                            MessageBox.Show("A senha nova não pode ser a mesma que a antiga", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string query = $@"select 1 from Usuario where Email = '{Email}' and Senha = '{senhaantiga}'";

                            var retorno = DBase.LoadData<ExisteUsuarioDoador>(query);

                            if (retorno.Count() == 0)
                            {
                                MessageBox.Show("Usuario não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string query2 = $@"update a set Senha = '{senhaHashnova}'
                                              from Usuario a 
                                              where Email = '{value}'
                                              and Senha = '{value2}'";

                                var retorno2 = DBase.ExecuteWithReturnAffected(query2);

                                if (retorno2 == 0)
                                {
                                    MessageBox.Show("Erro ao atualizar a senha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Sucesso ao atualizar a senha", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            LblConfirmaSenha.Visible = false;
            LblNvSenha.Visible = false;
            TxtBxConfirmaSenha.Visible = false;
            TxtBxNovaSenha.Visible = false;
            PicBxAtualizaImagem.Visible = false;
            BtBuscaImagemNova.Visible = false;

            LblNovoTipoSanguineo.Visible = true;
            CBBxTipoSanguineo.Visible = true;

            BtAtualizaCadastro.Visible = true;
        }

        private void BuscaTipoSanguineo()
        {
            try
            {
                string query = $@"select Descricao, Id from TiposSanguineos where Id not in ('1FBFE62B-6E0D-472F-8AB2-3DFB636108A7') order by Descricao";

                var retorno = DBase.LoadData<TiposSanguineos>(query);

                CBBxTipoSanguineo.DataSource = retorno;
                CBBxTipoSanguineo.DisplayMember = "Descricao";
                CBBxTipoSanguineo.ValueMember = "Id";
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizaTipoSanguineo()
        {
            try
            {
                string Email = value;
                string Senha = value2;

                string query = $@"update c set IdTipoSanguineo = '{CBBxTipoSanguineo.SelectedValue.ToString()}'
                              from Usuario a
                              join UsuarioDoador b on b.IdUsuario = a.Id 
                              join Doador c on b.IdDoador = c.Id 
                              where c.Email = '{value}' and a.Senha = '{value2}'";

                var retorno = DBase.ExecuteWithReturnAffected(query);

                if (retorno == 0)
                {
                    MessageBox.Show("Erro ao atualizar Tipo Sanguineo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Tipo Sanguineo atualizado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CBBxTipoSanguineo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BuscaImagem()
        {
            try
            {
                string Email = value;
                string Senha = value2;

                string query = $@"select Imagem as 'Foto' from Usuario a
                                  join Doador b on b.IdUsuario = a.Id
                                  where a.Email = '{Email}'";

                var retorno = DBase.LoadData<Imagem>(query);

                if (retorno.FirstOrDefault().Foto == "")
                {
                    PicBxAtualizaImagem.Image = Properties.Resources.k;
                }
                else
                {
                    var teste = Base64ToImage(retorno.FirstOrDefault().Foto);
                    PicBxAtualizaImagem.Image = teste;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Image Base64ToImage(string base64String)
        {
            try
            {
                // Convert Base64 String to byte[]
                byte[] imageBytes = Convert.FromBase64String(base64String);
                MemoryStream ms = new MemoryStream(imageBytes, 0,
                  imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);
                return image;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog(this);
            string strFn = this.openFileDialog1.FileName;
            var teste = CarregaImagem(strFn);
        }

        protected string CarregaImagem(string strFn)
        {
            string vetorImagens = "";

            try
            {
                if (string.IsNullOrEmpty(strFn))
                    return vetorImagens;

                this.PicBxAtualizaImagem.Image = Image.FromFile(strFn);
                FileInfo arqImagem = new FileInfo(strFn);

                vetorImagens = ImageToBase64(this.PicBxAtualizaImagem.Image, this.PicBxAtualizaImagem.Image.RawFormat);

                image = vetorImagens;
                return vetorImagens;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return vetorImagens;
            }
        }

        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        private void AtualizaFoto()
        {
            try
            {
                string Email = value;
                string Senha = value2;

                string query = $@"update c set Imagem = '{image}'
                              from Usuario a
                              join UsuarioDoador b on b.IdUsuario = a.Id 
                              join Doador c on b.IdDoador = c.Id 
                              where c.Email = '{value}' and a.Senha = '{value2}'";

                var retorno = DBase.ExecuteWithReturnAffected(query);

                if (retorno == 0)
                {
                    MessageBox.Show("Erro ao atualizar imagem", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Imagem Atualizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RadBtAtualizaFoto_CheckedChanged(object sender, EventArgs e)
        {
            LblConfirmaSenha.Visible = false;
            LblNvSenha.Visible = false;
            TxtBxConfirmaSenha.Visible = false;
            TxtBxNovaSenha.Visible = false;
            LblNovoTipoSanguineo.Visible = false;
            CBBxTipoSanguineo.Visible = false;

            PicBxAtualizaImagem.Visible = true;
            BtBuscaImagemNova.Visible = true;

            BtAtualizaCadastro.Visible = true;
        }

        private void BtDeleteCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                var resposta = MessageBox.Show("Deseja excluir seu cadastro?", "Confirme a Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resposta == DialogResult.Yes)
                {
                    string Email = value;

                    DeletaUsuario(Email);
                }
                else
                {
                    MessageBox.Show("Operação cancelada", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Erro ao deletar usuario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeletaUsuario(string Email)
        {
            try
            {
                string ExecutaProc = null;

                ExecutaProc = $@"'{Email}'";

                var retorno = DBase.RunProcedure("DeletaUsuario", new
                {
                    Email = Email
                });

                if (retorno > 0)
                    MessageBox.Show("Usuario Deletado com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Application.Restart();
            }
            catch
            {
                MessageBox.Show("Erro ao deletar usuario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
