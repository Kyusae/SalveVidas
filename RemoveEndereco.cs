using Salve_Vidas.Db;
using Salve_Vidas.Model;

namespace Salve_Vidas
{
    public partial class RemoveEndereco : Form
    {
        public string value { get; set; }

        public RemoveEndereco()
        {
            InitializeComponent();
        }

        private void RemoveEndereco_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Logofull;
            BuscaEndereco();
        }

        private void BuscaEndereco()
        {
            try
            {
                string Email = value;

                string query = $@"select distinct (SELECT d.Endereco + ', ' + d.Numero + ' - ' + d.Cidade + ' - ' + e.UF) as Endereco, d.Id, d.DataCriacao
                              from Usuario a
                              join UsuarioDoador b on b.IdUsuario = a.Id
                              join Doador c on b.IdDoador = c.Id 
                              join EnderecoDoador d on d.IdDoador = c.Id 
                              join Estado e on e.Nome = d.Estado
                              where c.Email = '{Email}'
                              order by d.DataCriacao desc";

                var retorno = DBase.LoadData<EnderecoUsuario>(query);

                if (retorno.Count() == 0)
                {
                    MessageBox.Show("Erro ao buscar endereços cadastrados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CBBxEndereco.DataSource = retorno;
                    CBBxEndereco.DisplayMember = "Endereco";
                    CBBxEndereco.ValueMember = "Id";
                }
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
                string Email = value;
                string Endereco = CBBxEndereco.SelectedValue.ToString();

                string query1 = $@"select distinct d.Id from Usuario a
                               join UsuarioDoador b on b.IdUsuario = a.Id 
                               join Doador c on b.IdDoador = c.Id
                               join EnderecoDoador d on d.IdDoador = c.Id 
                               where a.Email = '{Email}' 
                               and c .Email = '{Email}'";

                var retorno1 = DBase.LoadData<EnderecoUsuario>(query1);

                if (retorno1.Count() == 0)
                {
                    MessageBox.Show("Erro ao remover endereço cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (retorno1.Count() == 1)
                    {
                        MessageBox.Show("Você não pode excluir o único endereço cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string query2 = $@"delete d
                              from Usuario a
                              join UsuarioDoador b on b.IdUsuario = a.Id 
                              join Doador c on b.IdDoador = c.Id
                              join EnderecoDoador d on d.IdDoador = c.Id 
                              where a.Email = '{Email}' 
                              and c .Email = '{Email}' 
                              and d.Id = '{Endereco}'";

                        var retorno2 = DBase.ExecuteWithReturnAffected(query2);

                        if (retorno2 == 0)
                        {
                            MessageBox.Show("Erro ao remover endereço cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Endereço excluido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CBBxEndereco_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
