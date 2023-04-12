using Salve_Vidas.Db;
using Salve_Vidas.Model;

namespace Salve_Vidas
{
    public partial class Cadastro : Form
    {
        string image = "";
        public string email = "";
        public string Atualizacao = null;

        public Cadastro()
        {
            InitializeComponent();
        }

        private void CadastraUsu_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Logofull;
            toolTip1.SetToolTip(PcBxInvisivel, "Mostrar Senha");
            toolTip1.SetToolTip(PcBxVisivel, "Esconder Senha");
            PcBxVisivel.Visible = false;
            BuscaTipoSanguineo();

            if (Atualizacao == "1")
            {
                BtCadastrar.Visible = false;
                TxtBxSenha.Visible = false;
                label9.Visible = false;
                label8.Visible = false;
                PcBxInvisivel.Visible = false;
                PcBxVisivel.Visible = false;
                BtAtualizar.Visible = true;
                BuscaInformaçõesUsuario();
                BtDeleteCadastro.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int Tipo = 0;

                string Nome = TxtBxNome.Text.Trim();
                string Sobrenome = TxtBxSobrenome.Text.Trim();
                string Email = TxtBxEmail.Text.Trim();
                string Telefone = TxtBxTelefone.Text.Trim();
                string Senha = TxtBxSenha.Text.Trim();
                string SenhaHashNova = "";
                SenhaHashNova = Hash.criptografarSenha(Senha);

                string CPF = TxtBxCPF.Text.Trim();
                string TipoSanguineo = CBBxTipoSanguineo.SelectedValue.ToString();
                string Imagem = image;

                string Endereco = TxtBxEndereco.Text.Trim();
                string Numero = TxtBxNumero.Text.Trim();
                string Complemento = TxtBxComplemento.Text.Trim();
                string Bairro = TxtBxBairro.Text.Trim();
                string Cidade = TxtBxCidade.Text.Trim();
                string UF = TxtBxUF.Text.Trim();
                string CEP = TxtBxCEP.Text.Trim();
                string Estado = TxtBxEstado.Text.Trim();

                if (string.IsNullOrEmpty(TxtBxNome.Text) || string.IsNullOrEmpty(TxtBxSobrenome.Text) || string.IsNullOrEmpty(TxtBxEmail.Text) || string.IsNullOrEmpty(TxtBxTelefone.Text) || string.IsNullOrEmpty(TxtBxSenha.Text))
                {
                    MessageBox.Show("Insira todas as informações para continuar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string query = $@"select Nome from Usuario where Email = '{Email}' and Senha = '{SenhaHashNova}'";
                    var retorno = DBase.LoadData<ExisteUsuario>(query);

                    if (retorno.Count() > 0)
                    {
                        MessageBox.Show("Email já cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (RadBtNao.Checked)
                        {
                            Tipo = 0;

                            ExecutaInsereUsuario(Tipo, Nome, Sobrenome, Email, Telefone, SenhaHashNova);
                        }

                        if (RadBtSim.Checked)
                        {
                            if (TxtBxCPF.Text == "   .   .   -" || string.IsNullOrEmpty(CBBxTipoSanguineo.Text) || string.IsNullOrEmpty(Imagem)
                                    || string.IsNullOrEmpty(TxtBxEndereco.Text) || string.IsNullOrEmpty(TxtBxNumero.Text) || string.IsNullOrEmpty(TxtBxBairro.Text)
                                    || string.IsNullOrEmpty(TxtBxCidade.Text) || string.IsNullOrEmpty(TxtBxUF.Text) || string.IsNullOrEmpty(TxtBxCEP.Text)
                                    || string.IsNullOrEmpty(TxtBxEstado.Text)
                                    || string.IsNullOrEmpty(TxtBxCPF.Text))
                            {
                                MessageBox.Show("Insira todas as informações para continuar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string query2 = $@"select Nome from Doador where CPF = '{CPF}' and Email = '{Email}'";
                                var retorno2 = DBase.LoadData<ExisteUsuarioDoador>(query2);

                                if (retorno2.Count() > 0)
                                {
                                    MessageBox.Show("CPF já cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    Tipo = 1;

                                    ExecutaInsereUsuario(Tipo, Nome, Sobrenome, Email, Telefone, SenhaHashNova, CPF, TipoSanguineo, Imagem, Endereco, Numero, Complemento, Bairro, Cidade, UF, CEP, Estado);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro, tente novamente", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExecutaInsereUsuario(int Tipo, string Nome, string Sobrenome, string Email, string Telefone, string Senha, // Para criar o usuario padrão
            string CPF = null, string TipoSanguineo = null, string Imagem = null, // Para criar o Doador
            string Endereco = null, string Numero = null, string Complemento = null, string Bairro = null, string Cidade = null, string UF = null, string CEP = null, string Estado = null) // Para criar o Endereço
        {
            try
            {
                string ExecutaProc = null;

                if (Tipo == 0)
                {
                    ExecutaProc = @"" + Tipo + ", '" + Nome + "', '" + Sobrenome + "', '" + Email + "', '" + Telefone + "', '" + Senha + "'";
                }
                if (Tipo == 1)
                {
                    ExecutaProc = @"" + Tipo + ", '" + Nome + "', '" + Sobrenome + "', '" + Email + "', '" + Telefone + "', '" + Senha + "', '" + CPF + "', '" + TipoSanguineo + "', '" + Imagem + "', '" + Endereco + "', '" + Numero + "', '" + Complemento + "', '" + Bairro + "', '" + Cidade + "', '" + UF + "', '" + CEP + "', '" + Estado + "'";
                }

                var retorno = DBase.RunProcedure("CriaUsuario", new
                {
                    Tipo = Tipo,
                    Nome = Nome,
                    Sobrenome = Sobrenome,
                    Email = Email,
                    Telefone = Telefone,
                    Senha = Senha,
                    CPF = CPF,
                    TipoSanguineo = TipoSanguineo,
                    Imagem = Imagem,
                    Endereco = Endereco,
                    Numero = Numero,
                    Complemento = Complemento,
                    Bairro = Bairro,
                    Cidade = Cidade,
                    UF = UF,
                    CEP = CEP,
                    Estado = Estado
                });

                if (retorno > 0)
                {
                    MessageBox.Show("Sucesso ao criar o usuario", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Erro, tente novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RadBtSim_CheckedChanged(object sender, EventArgs e)
        {
            CBBxTipoSanguineo.Visible = true;
            TxtBxCidade.Visible = true;
            TxtBxEstado.Visible = true;

            PicBxFoto.Visible = true;
            BtImagem.Visible = true;

            LblCPF.Visible = true;
            LblTipoSanguineo.Visible = true;
            LblBairro.Visible = true;
            LblCEP.Visible = true;
            LblCidade.Visible = true;
            LblComplemento.Visible = true;
            LblEndereco.Visible = true;
            LblEstado.Visible = true;
            LblNumero.Visible = true;
            LblUF.Visible = true;

            TxtBxCPF.Visible = true;
            TxtBxBairro.Visible = true;
            TxtBxCEP.Visible = true;
            TxtBxComplemento.Visible = true;
            TxtBxEndereco.Visible = true;
            TxtBxNumero.Visible = true;
            TxtBxUF.Visible = true;
        }

        private void RadBtNao_CheckedChanged(object sender, EventArgs e)
        {
            CBBxTipoSanguineo.Visible = false;
            TxtBxCidade.Visible = false;
            TxtBxEstado.Visible = false;

            PicBxFoto.Visible = false;
            BtImagem.Visible = false;

            LblBairro.Visible = false;
            LblCEP.Visible = false;
            LblCidade.Visible = false;
            LblComplemento.Visible = false;
            LblEndereco.Visible = false;
            LblEstado.Visible = false;
            LblNumero.Visible = false;
            LblUF.Visible = false;
            LblTipoSanguineo.Visible = false;
            LblCPF.Visible = false;

            TxtBxBairro.Visible = false;
            TxtBxCEP.Visible = false;
            TxtBxComplemento.Visible = false;
            TxtBxEndereco.Visible = false;
            TxtBxNumero.Visible = false;
            TxtBxUF.Visible = false;
            TxtBxCPF.Visible = false;
        }

        private void BtImagem_Click(object sender, EventArgs e)
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
                if (strFn.Contains(".mp4") || strFn.Contains(".MKV") || strFn.Contains(".AVI") || strFn.Contains(".WMV")
                    || strFn.Contains(".MOV") || strFn.Contains(".QT") || strFn.Contains(".AVCHD") || strFn.Contains(".FLV") || strFn.Contains(".SWF"))
                {
                    MessageBox.Show("Formato de foto invalido. Utilize imagens em formato JPG, PNG.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return vetorImagens;
                }
                else
                {
                    if (string.IsNullOrEmpty(strFn))
                        return vetorImagens;

                    this.PicBxFoto.Image = Image.FromFile(strFn);
                    FileInfo arqImagem = new FileInfo(strFn);

                    vetorImagens = ImageToBase64(this.PicBxFoto.Image, this.PicBxFoto.Image.RawFormat);

                    image = vetorImagens;
                    return vetorImagens;
                }
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

        private void PcBxVisivel_Click(object sender, EventArgs e)
        {
            TxtBxSenha.UseSystemPasswordChar = true;
            PcBxVisivel.Visible = false;
            PcBxInvisivel.Visible = true;
        }

        private void PcBxInvisivel_Click(object sender, EventArgs e)
        {
            TxtBxSenha.UseSystemPasswordChar = false;
            PcBxInvisivel.Visible = false;
            PcBxVisivel.Visible = true;
        }

        private void BuscaEstado(string UF)
        {
            try
            {
                string query = $@"select Nome from Estado where UF = '{UF}' order by Nome desc";

                var retorno = DBase.LoadData<EstadosNome>(query);

                TxtBxEstado.Text = retorno.FirstOrDefault().Nome.ToString();
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscaInformaçõesUsuario()
        {
            try
            {
                string Email = email;

                string query = $@"select a.Nome, a.Sobrenome, a.Email, a.Telefone from Usuario a
                              left join Doador b on b.IdUsuario = a.Id
                              where a.Email = '{Email}'";

                var retorno = DBase.LoadData<AtualizarCadastro>(query);

                if (retorno.Count() == 0)
                {
                    MessageBox.Show("Erro ao buscar informações do Usuario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TxtBxNome.Text = retorno.FirstOrDefault().Nome.ToString();
                    TxtBxNome.Enabled = false;
                    TxtBxSobrenome.Text = retorno.FirstOrDefault().Sobrenome.ToString();
                    TxtBxSobrenome.Enabled = false;
                    TxtBxEmail.Text = retorno.FirstOrDefault().Email.ToString();
                    TxtBxEmail.Enabled = false;
                    TxtBxTelefone.Text = retorno.FirstOrDefault().Telefone.ToString();
                    TxtBxTelefone.Enabled = false;

                    RadBtSim.Checked = true;
                    RadBtNao.Visible = false;
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtBxCPF.Text) || string.IsNullOrEmpty(TxtBxEndereco.Text) || string.IsNullOrEmpty(TxtBxNumero.Text)
                    || string.IsNullOrEmpty(TxtBxBairro.Text) || string.IsNullOrEmpty(TxtBxCEP.Text))
                {
                    if (TxtBxCPF.Text.Length < 14 || TxtBxCEP.Text.Length < 9)
                        MessageBox.Show("Preencha os dados corretamente: CPF e/ou CEP", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    MessageBox.Show("Preencha os dados corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string Nome = TxtBxNome.Text.Trim();
                    string Sobrenome = TxtBxSobrenome.Text.Trim();
                    string CPF = TxtBxCPF.Text.Trim();
                    string Email = TxtBxEmail.Text.Trim();
                    string Telefone = TxtBxTelefone.Text.Trim();
                    string? TipoSanguineo = CBBxTipoSanguineo.SelectedValue.ToString();
                    string Imagem = image;

                    string Endereco = TxtBxEndereco.Text.Trim();
                    string Numero = TxtBxNumero.Text.Trim();
                    string Bairro = TxtBxBairro.Text.Trim();
                    string CEP = TxtBxCEP.Text.Trim();
                    string Complemento = TxtBxComplemento.Text.Trim();
                    string UF = TxtBxUF.Text.Trim();
                    string Estado = TxtBxEstado.Text.Trim();
                    string Cidade = TxtBxCidade.Text.Trim();

                    string query = $@"select Id from Usuario where Email = '{Email}'";

                    var retorno = DBase.LoadData<IdUsuario>(query);

                    string query1 = $@"Insert into Doador values (newid(), '{retorno.FirstOrDefault().Id}', '{Nome}', '{Sobrenome}', '{CPF}', '{Email}', '{Telefone}', '{TipoSanguineo}','{Imagem}')";

                    var retorno1 = DBase.ExecuteWithReturnAffected(query1);

                    if (retorno1 == 0)
                    {
                        MessageBox.Show("Erro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string query2 = $@"select Id from Doador where Email = '{Email}'";

                        var retorno2 = DBase.LoadData<IdDoador>(query2);

                        if (retorno2.Count() == 0)
                        {
                            MessageBox.Show("Erro ao buscar IdUsuario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string query3 = $@"Insert into UsuarioDoador values (newid(), '{retorno.FirstOrDefault().Id}', '{retorno2.FirstOrDefault().Id}')";

                            var retorno3 = DBase.ExecuteWithReturnAffected(query3);

                            if (retorno3 == 0)
                            {
                                MessageBox.Show("Erro ao inserir vinculo de Doador", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string query5 = $@"insert into EnderecoDoador values (newid(), '{retorno2.FirstOrDefault().Id}', '{Endereco}', '{Numero}', '{Complemento}', '{Bairro}', '{Cidade}', '{UF}', '{CEP}',  '{Estado}', getdate(), null)";

                                var retorno5 = DBase.ExecuteWithReturnAffected(query5);

                                if (retorno5 == 0)
                                {
                                    MessageBox.Show("Erro ao inserir endereço", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Usuario Cadastrado com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public string NotAllowed = @"'><@{}[]#&()/|*-+$%~\!¨_?:,.;ºª°""§¹²³£¢¬1234567890=";
        public string NotAllowed2 = @"'><{}[]#&()/|*-+$%~\!¨_?:,;ºª°""§¹²³£¢¬=";
        public string NotAllowed3 = @"'><{}[]#&()/|*+$%~\!¨?:,;ºª°""§¹²³£¢¬=´^`";

        private void TxtBxNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NotAllowed.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtBxSobrenome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NotAllowed.Contains(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtBxCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NotAllowed3.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtBxCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)))
                e.Handled = true;
        }

        private void TxtBxTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)))
                e.Handled = true;
        }

        private void BtDeleteCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                var resposta = MessageBox.Show("Deseja excluir seu cadastro?", "Confirme a Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resposta == DialogResult.Yes)
                {
                    string Email = TxtBxEmail.Text.Trim();

                    DeletaUsuario(Email);
                }
                else
                {
                    MessageBox.Show("Operação cancelada", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void TxtBxNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NotAllowed2.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtBxComplemento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NotAllowed2.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtBxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NotAllowed3.Contains(e.KeyChar))
            {
                e.Handled = true;
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
            catch (Exception Erro)
            {
                MessageBox.Show("Erro ao deletar usuario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBxEmail_Leave(object sender, EventArgs e)
        {
            try
            {
                ValidaEmail validaEmail = new ValidaEmail();

                validaEmail.IsValidEmail(TxtBxEmail.Text.Trim());

                if (!validaEmail.IsValidEmail(TxtBxEmail.Text.Trim()))
                {
                    MessageBox.Show("Email Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (TxtBxNome.Enabled == true)
                        BtCadastrar.Enabled = false;
                    if (TxtBxNome.Enabled == false)
                        BtAtualizar.Enabled = false;
                }
                else
                {
                    if (TxtBxNome.Enabled == true)
                        BtCadastrar.Enabled = true;
                    if (TxtBxNome.Enabled == false)
                        BtAtualizar.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBxCEP_Leave(object sender, EventArgs e)
        {
            try
            {
                ViaCep viaCep = new ViaCep();

                var resposta = viaCep.consultaCEP(TxtBxCEP.Text.Trim());

                if (resposta != null)
                {
                    TxtBxEndereco.Text = resposta.Logradouro;
                    TxtBxBairro.Text = resposta.Bairro;
                    TxtBxUF.Text = resposta.UF;
                    TxtBxCidade.Text = resposta.localidade;

                    BuscaEstado(resposta.UF);

                    if (TxtBxEndereco.Text == "" || TxtBxBairro.Text == "")
                    {
                        BtCadastrar.Enabled = false;
                        RdBtEndereco.Visible = true;
                        RdBtEndereco.Checked = true;

                        if (RdBtEndereco.Checked)
                        {
                            TxtBxEndereco.Enabled = true;
                            TxtBxBairro.Enabled = true;

                            TxtBxEndereco.ReadOnly = false;
                            TxtBxBairro.ReadOnly = false;
                        }
                    }
                    else
                    {
                        RadBtSim.Checked = true;
                        BtCadastrar.Enabled = true;
                        RdBtEndereco.Visible = false;
                        RdBtEndereco.Checked = false;
                        TxtBxEndereco.Enabled = false;
                        TxtBxBairro.Enabled = false;
                        TxtBxEstado.Enabled = false;
                        TxtBxCidade.Enabled = false;
                        TxtBxEndereco.ReadOnly = true;
                        TxtBxBairro.ReadOnly = true;
                    }
                }
                else
                {
                    TxtBxEndereco.Text = null;
                    TxtBxBairro.Text = null;
                    TxtBxUF.Text = null;
                    TxtBxCidade.Text = null;
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBxCPF_Leave(object sender, EventArgs e)
        {
            if (ValidaCPF(TxtBxCPF.Text))
            {

            }
            else
            {
                MessageBox.Show("CPF Inválido !", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtBxCPF.Clear();
            }
        }

        public static bool ValidaCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");


            if (valor.Length != 11)
            {
                return false;
            }

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                {
                    igual = false;
                }

            if (igual || valor == "12345678909")
            {
                return false;
            }

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                  valor[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
            {
                return false;
            }

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
            {
                if (numeros[10] != 11 - resultado)
                {
                    return false;
                }
            }
            return true;
        }

        private void TxtBxCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("Insira apenas números no campo CPF", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TxtBxCEP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("Insira apenas números no campo CEP", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TxtBxTelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("Insira apenas números no campo Telefone", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Cadastro_Activated(object sender, EventArgs e)
        {
            if (RadBtSim.Checked || RdBtEndereco.Checked)
            {
                if (TxtBxEndereco.Text == "" || TxtBxBairro.Text == "" || TxtBxNumero.Text == "")
                    BtCadastrar.Enabled = false;
                else
                    BtCadastrar.Enabled = true;
            }
        }
    }
}
