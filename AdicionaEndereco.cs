using Salve_Vidas.Db;
using Salve_Vidas.Model;

namespace Salve_Vidas
{
    public partial class AdicionaEndereco : Form
    {
        public string value { get; set; }

        public AdicionaEndereco()
        {
            InitializeComponent();
        }

        private void AdicionaEndereco_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Logofull;
        }

        private void TxtBxCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)))
                e.Handled = true;
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

        public const string NotAllowed2 = @"'@><{}[]#&()/|*-+$%~\!¨_?:,;ºª°""§¹²³£¢¬=";

        private void BtCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                string Email = value;
                string Endereco = TxtBxEndereco.Text.Trim();
                string Numero = TxtBxNumero.Text.Trim();
                string Complemento = TxtBxComplemento.Text.Trim();
                string Bairro = TxtBxBairro.Text.Trim();
                string Cidade = TxtBxCidade.Text.Trim();
                string UF = TxtBxUF.Text.Trim();
                string CEP = TxtBxCEP.Text.Trim();
                string Estado = TxtBxEstado.Text.Trim();

                if (string.IsNullOrEmpty(Numero) || string.IsNullOrEmpty(CEP))
                {
                    MessageBox.Show("Preencha os dados corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string query = $@"select a.Id from Doador a
                                  join UsuarioDoador b on b.IdDoador = a.Id
                                  join Usuario c on b.IdUsuario = c.Id
                                  where a.Email = '{Email}'
                                  and c.Email = '{Email}'";

                    var retorno = DBase.LoadData<IdDoador>(query);

                    if (retorno.Count() == 0)
                    {
                        MessageBox.Show("Erro ao buscar dados do usuario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string query4 = $@"select count (Id) as 'NumeroDeEnderecos' from EnderecoDoador where IdDoador = '{retorno.FirstOrDefault().Id}'";

                        var retorno4 = DBase.LoadData<Enderecos>(query4);

                        if (retorno4.FirstOrDefault().NumeroDeEnderecos >= 5)
                        {
                            MessageBox.Show("Número maximo de endereços cadastrados, exclua um para seguir", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string query2 = $@"select top 1 Endereco, Numero, CodigoPostal from EnderecoDoador
                                               where IdDoador = '{retorno.FirstOrDefault().Id}'
                                               and Endereco = '{TxtBxEndereco.Text}'
                                               and Numero = '{TxtBxNumero.Text}'
                                               and CodigoPostal = '{TxtBxCEP.Text}'";

                            var retorno2 = DBase.LoadData<EnderecoDoador>(query2);

                            if (retorno2.Count() == 0)
                            {
                                string query3 = $@"insert into EnderecoDoador values (newid(), '{retorno.FirstOrDefault().Id}', '{Endereco}', '{Numero}', '{Complemento}', '{Bairro}', '{Cidade}', '{UF}', '{CEP}', '{Estado}', getdate(), null)";

                                var retorno3 = DBase.ExecuteWithReturnAffected(query3);

                                if (retorno3 == 0)
                                {
                                    MessageBox.Show("Erro ao inserir endereço do usuario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Endereço Cadastrado com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                            else if (retorno2.FirstOrDefault().Endereco == TxtBxEndereco.Text || retorno2.FirstOrDefault().Numero == TxtBxNumero.Text || retorno2.FirstOrDefault().CodigoPostal == TxtBxCEP.Text)
                            {
                                MessageBox.Show("Endereço já cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Erro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void TxtBxNumero_Leave(object sender, EventArgs e)
        {
            BtCadastrar.Enabled = true;
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

        private void TxtBxCEP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("Insira apenas números no campo CEP", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AdicionaEndereco_Activated(object sender, EventArgs e)
        {
            if (RdBtEndereco.Checked)
            {
                if (TxtBxEndereco.Text == "" || TxtBxBairro.Text == "" || TxtBxNumero.Text == "")
                    BtCadastrar.Enabled = false;
                else
                    BtCadastrar.Enabled = true;
            }
            else
            {
                if (string.IsNullOrEmpty(TxtBxNumero.Text))
                    BtCadastrar.Enabled = false;
                else
                    BtCadastrar.Enabled = true;
            }
        }
    }
}
