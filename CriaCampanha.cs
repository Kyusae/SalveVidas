using Salve_Vidas.Db;
using Salve_Vidas.Model;

namespace Salve_Vidas
{
    public partial class CriaCampanha : Form
    {
        public string value { get; set; }
        public string value2 { get; set; }

        public string Atualizacao = null;
        public string Tipo = null;

        public CriaCampanha()
        {
            InitializeComponent();
        }

        private void CriaCampanha_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Logofull;
            BuscaTipoSanguineo();
            BuscaEstado();
            BuscaCidade();

            if (Atualizacao == "1")
            {
                label4.Visible = false;
                label3.Visible = false;
                label2.Visible = false;
                CBBxEstado.Visible = false;
                CBBxCidade.Visible = false;
                CBBxHospital.Visible = false;

                Tipo = "1";
            }
        }

        private void BuscaTipoSanguineo()
        {
            try
            {
                string query = $@"select Descricao, Id from TiposSanguineos order by Descricao";

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

        private void BuscaEstado()
        {
            try
            {
                string query = $@"select Nome, Id from Estado order by Nome";

                var retorno = DBase.LoadData<EstadosId>(query);

                CBBxEstado.DataSource = retorno;
                CBBxEstado.DisplayMember = "Nome";
                CBBxEstado.ValueMember = "Id";
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscaHospital()
        {
            try
            {

                string Cidade = CBBxCidade.SelectedValue.ToString();
                string Estado = CBBxEstado.SelectedValue.ToString();

                string query = $@"select distinct a.Nome, a.Id from Hospital a 
                              join Estado b on b.Nome = a.Estado
                              join Cidades c on c.Nome = a.Cidade
                              where b.Id = '{Estado}'
                              and c.Id = '{Cidade}'
                              order by a.Nome";

                var retorno = DBase.LoadData<Hospitais>(query);

                CBBxHospital.DataSource = retorno;
                CBBxHospital.DisplayMember = "Nome";
                CBBxHospital.ValueMember = "Id";
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CBBxHospital_Click(object sender, EventArgs e)
        {
            BuscaHospital();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtBxNome.Text) || TxtBxNome.Text.Contains("'"))
                {
                    MessageBox.Show("Preencha os campos corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string Email = value;
                    string Senha = value2;
                    string Nome = TxtBxNome.Text.Trim();
                    string TipoSolicitado = CBBxTipoSanguineo.SelectedValue.ToString();

                    if (Tipo == "1")
                    {
                        string query = $@"select b.IdHospital from Usuario a
                                          join UsuarioHospital b on b.IdUsuario = a.Id 
                                          where a.Email = '{Email}'
                                          and a.Senha = '{Senha}'";

                        var retorno = DBase.LoadData<IdHospitais>(query);

                        if (retorno.Count() == 0)
                        {
                            MessageBox.Show("Erro, tente novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string query2 = $@"insert into CampanhaHospital values (newid(), '{retorno.FirstOrDefault().IdHospital.ToString()}', '{Nome}', '{TipoSolicitado}', getdate(), null)";

                            var retorno2 = DBase.ExecuteWithReturnAffected(query2);

                            if (retorno2 == 0)
                            {
                                MessageBox.Show("Erro ao criar Campanha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Campanha criada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(CBBxHospital.Text))
                        {
                            MessageBox.Show("Preencha os campos corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string Hospital = CBBxHospital.SelectedValue.ToString();

                            string query = $@"select Id from Doador where Email = '{Email}'";

                            var retorno = DBase.LoadData<IdDoador>(query);

                            if (retorno.Count() == 0)
                            {
                                MessageBox.Show("Usuario não possui cadastro completo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string query2 = $@"insert into CampanhaUsuario values (newid(), '{retorno.FirstOrDefault().Id}', '{Nome}', '{TipoSolicitado}', '{Hospital}', getdate(), null)";

                                var retorno2 = DBase.ExecuteWithReturnAffected(query2);

                                if (retorno2 == 0)
                                {
                                    MessageBox.Show("Erro ao criar Campanha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Campanha criada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CBBxEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CBBxHospital_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CBBxCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CBBxTipoSanguineo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtBxNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cadastro cadastro = new Cadastro();

            if (cadastro.NotAllowed.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            CBBxHospital.DataSource = null;
            BuscaCidade();
        }

        private void BuscaCidade()
        {
            try
            {
                string Estado = CBBxEstado.SelectedValue.ToString();

                string query = $@"select distinct Nome, Id from Cidades
                              where IdEstado = '{Estado}'
                              order by Nome";

                var retorno = DBase.LoadData<Cidade>(query);

                CBBxCidade.DataSource = retorno;
                CBBxCidade.DisplayMember = "Nome";
                CBBxCidade.ValueMember = "Id";
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CBBxEstado_Click(object sender, EventArgs e)
        {
            CBBxCidade.DataSource = null;
            CBBxHospital.DataSource = null;
        }
    }
}
