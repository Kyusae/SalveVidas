using Salve_Vidas.Db;
using Salve_Vidas.Model;

namespace Salve_Vidas
{
    public partial class AtualizaEstoqueSangue : Form
    {
        public string value { get; set; }
        public string value2 { get; set; }

        public AtualizaEstoqueSangue()
        {
            InitializeComponent();
        }

        private void AtualizaEstoqueSangue_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Logofull;
            BuscaTipoSanguineo();
            BuscaQuantidadeDeEstoqueDeSangue();
        }

        private void BuscaQuantidadeDeEstoqueDeSangue()
        {
            try
            {
                string Email = value;
                string Senha = value2;
                string TipoSanguineo = CBBxTipoSanguineo.SelectedValue.ToString();

                string query = $@"select d.QuantidadeMinima, d.QuantidadeMaxima, d.QuantidadeAtual 
                                  from Usuario a 
                                  join UsuarioHospital b on b.IdUsuario = a.Id
                                  join Hospital c on c.Id = b.IdHospital 
                                  join EstoqueDeSangue d on d.IdHospital = c.Id
                                  where a.Email = '{Email}'
                                  and a.Senha = '{Senha}'
                                  and d.IdTipoSanguineo = '{TipoSanguineo}'";

                var retorno = DBase.LoadData<QuantidadeEstoque>(query);

                if (retorno.Count() == 0)
                {
                    MessageBox.Show("Erro ao buscar quantidades de estoque.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TxtBxQuantidadeAtual.Text = retorno.FirstOrDefault().QuantidadeAtual;
                    TxtBxQuantidadeLimite.Text = retorno.FirstOrDefault().QuantidadeMaxima;
                    TxtBxQuantidadeMinima.Text = retorno.FirstOrDefault().QuantidadeMinima;
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtBxQuantidadeNova.Text) || string.IsNullOrEmpty(TxtBxQuantidadeAtual.Text))
                {
                    MessageBox.Show("Preencha a quantidade atual", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (int.Parse(TxtBxQuantidadeNova.Text) > int.Parse(TxtBxQuantidadeLimite.Text) || int.Parse(TxtBxQuantidadeNova.Text) < int.Parse(TxtBxQuantidadeMinima.Text))
                {
                    MessageBox.Show("Valor não pode ser menor ou maior que o limite ou o minimo de estoque", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string Email = value;
                    string Senha = value2;
                    string TipoSanguineo = CBBxTipoSanguineo.SelectedValue.ToString();
                    string Quantidade = TxtBxQuantidadeNova.Text;

                    string query = $@"update d set QuantidadeAtual = '{Quantidade}'
                                      from Usuario a 
                                      join UsuarioHospital b on b.IdUsuario = a.Id
                                      join Hospital c on c.Id = b.IdHospital 
                                      join EstoqueDeSangue d on d.IdHospital = c.Id
                                      where a.Email = '{Email}'
                                      and a.Senha = '{Senha}'
                                      and d.IdTipoSanguineo = '{TipoSanguineo}'";

                    var retorno = DBase.ExecuteWithReturnAffected(query);

                    if (retorno > 0)
                    {
                        MessageBox.Show("Estoque atualizado com sucesso.", "Sucessp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar estoque, tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string NotAllowed3 = @"'><{}[]#&()/|*+$%~\!¨?:,;ºª°""§¹²³£¢¬=´^`";

        private void TxtBxQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NotAllowed3.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CBBxTipoSanguineo_Click(object sender, EventArgs e)
        {
            TxtBxQuantidadeAtual.Text = null;
            TxtBxQuantidadeLimite.Text = null;
            TxtBxQuantidadeMinima.Text = null;
        }

        private void CBBxTipoSanguineo_Leave(object sender, EventArgs e)
        {
            BuscaQuantidadeDeEstoqueDeSangue();
        }

        private void TxtBxQuantidadeNova_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
    }
}
