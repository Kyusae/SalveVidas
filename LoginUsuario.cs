using Salve_Vidas.Db;
using Salve_Vidas.Model;

namespace Salve_Vidas
{
    public partial class LoginUsuario : Form
    {
        public string value { get; set; }
        public string value2 { get; set; }

        public LoginUsuario()
        {
            InitializeComponent();
        }

        private void LoginUsuario_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Logofull;
            toolTip1.SetToolTip(PicBxVoltar, "Voltar");
            toolTip1.SetToolTip(PicBxAtualizarCadastro, "Configurações");
            toolTip1.SetToolTip(BtAdicionaEndereco, "Adicionar Endereço");
            toolTip1.SetToolTip(BtRemoveEndereco, "Remover Endereço");
            BuscaImagem();
            BuscaNomeUsuario();
            BuscaTipoSanguineo();
            BuscaEnderecoRecente();
            BuscaCampanha();
            BuscaCampanhaFinalizadas();
            BuscaHospital();
            BuscaCampanhasAtivasUsuarios();
            BuscaCampanhasAtivasHospitais();
        }

        private void BuscaImagem()
        {
            try
            {
                string Email = value;

                string query = $@"select Imagem as 'Foto' from Usuario a
                                  join Doador b on b.IdUsuario = a.Id
                                  where a.Email = '{Email}'";

                var retorno = DBase.LoadData<Imagem>(query);

                if (retorno.Count() == 0 || retorno.FirstOrDefault().Foto == "")
                {
                    PicBxLogin.Image = Properties.Resources.k;
                }
                else
                {
                    var teste = Base64ToImage(retorno.FirstOrDefault().Foto);
                    PicBxLogin.Image = teste;
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

        private void BuscaNomeUsuario()
        {
            try
            {

                string Email = value;
                string Senha = value2;

                string query = $@"select a.Nome from Usuario a
                              left join Doador b on b.IdUsuario = a.Id
                              where a.Email = '{Email}'";

                var retorno = DBase.LoadData<ExisteUsuarioDoador>(query);

                if (retorno.Count() == 0)
                {
                    MessageBox.Show("Erro ao buscar nome do Usuario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    LblNome.Text = retorno.FirstOrDefault().Nome.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private void LoginUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void PicBxAtualizarCadastro_Click(object sender, EventArgs e)
        {
            var retorno = DBase.TestaConexao();

            if (retorno == "Erro")
            {

            }
            else
            {
                if (LblTipoSanguineo.Text == "Tipo Sanguineo não cadastrado")
                {
                    Cadastro cadastraUsu = new Cadastro();
                    cadastraUsu.Atualizacao = "1";
                    cadastraUsu.email = value;
                    cadastraUsu.ShowDialog();
                }
                else
                {
                    AtualizaCadastro atualizacadastro = new AtualizaCadastro();
                    atualizacadastro.value = value;
                    atualizacadastro.value2 = value2;
                    atualizacadastro.ShowDialog();
                }
            }
        }

        private void BuscaTipoSanguineo()
        {
            try
            {
                string Email = value;
                string Senha = value2;

                string query = $@"select d.Descricao, d.DoaPara, d.RecebeDe, d.PessoasAjudadas from Usuario a
                              join UsuarioDoador b on b.IdUsuario = a.Id
                              join Doador c on b.IdDoador = c.Id 
                              join TiposSanguineos d on c.IdTipoSanguineo = d.Id 
                              where c.Email = '{Email}'
                              and a.Senha = '{Senha}'";

                var retorno = DBase.LoadData<UsuarioTipoSanguineo>(query);

                if (retorno.Count() == 0)
                {
                    LblTipoSanguineo.Text = "Tipo Sanguineo não cadastrado";
                    LblDoaPara.Text = "Tipo Sanguineo não cadastrado";
                    LblRecebeDe.Text = "Tipo Sanguineo não cadastrado";
                    LblPessoasAjudadas.Text = "Tipo Sanguineo não cadastrado";
                    label6.Visible = false;
                    BtCriaCampanha.Visible = false;
                    BtFinalizaCampanha.Visible = false;
                    BtAdicionaEndereco.Visible = false;
                    BtRemoveEndereco.Visible = false;
                }
                else
                {
                    LblTipoSanguineo.Text = retorno.FirstOrDefault().Descricao.ToString();
                    LblDoaPara.Text = retorno.FirstOrDefault().DoaPara.ToString();
                    LblRecebeDe.Text = retorno.FirstOrDefault().RecebeDe.ToString();
                    LblPessoasAjudadas.Text = retorno.FirstOrDefault().PessoasAjudadas.ToString();

                    LblTipoSanguineo.Font = new Font("Calibri", 12);
                    LblDoaPara.Font = new Font("Calibri", 12);
                    LblRecebeDe.Font = new Font("Calibri", 12);
                    LblPessoasAjudadas.Font = new Font("Calibri", 12);
                    label6.Font = new Font("Calibri", 12);
                    this.LblTipoSanguineo.Location = new Point(82, 3);
                    this.LblDoaPara.Location = new Point(46, 3);
                    this.LblRecebeDe.Location = new Point(30, 3);
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private void BuscaEnderecoRecente()
        {
            try
            {
                string Email = value;
                string Senha = value2;

                string query = $@"select distinct (SELECT d.Endereco + ', ' + d.Numero + ' - ' + d.Bairro + ' - ' + d.Cidade + ' - ' + e.UF) as Endereco, d.Id, d.DataCriacao
                              from Usuario a
                              join UsuarioDoador b on b.IdUsuario = a.Id
                              join Doador c on b.IdDoador = c.Id 
                              join EnderecoDoador d on d.IdDoador = c.Id 
                              join Estado e on e.Nome = d.Estado
                              where c.Email = '{Email}' 
                              and a.Senha = '{Senha}'
                              order by d.DataCriacao desc";

                var retorno = DBase.LoadData<EnderecoUsuario>(query);

                if (retorno.Count() == 0)
                {
                    LblEndereco.Text = "Endereço não cadastrado";
                    BtCriaCampanha.Visible = false;
                    CBBxEndereco.Visible = false;
                }
                else
                {
                    CBBxEndereco.Visible = true;

                    CBBxEndereco.DataSource = retorno;
                    CBBxEndereco.DisplayMember = "Endereco";
                    CBBxEndereco.ValueMember = "Id";
                }
            }
            catch
            {
                return;
            }
        }

        private void LoginUsuario_Activated(object sender, EventArgs e)
        {
            var retorno = DBase.TestaConexao();

            if (retorno == "Erro")
            {

            }
            else
            {
                BuscaImagem();
                BuscaTipoSanguineo();
                BuscaCampanha();
                BuscaCampanhaFinalizadas();
                BuscaHospital();
                BuscaCampanhasAtivasUsuarios();
                BuscaCampanhasAtivasHospitais();

                if (LblPessoasAjudadas.Text != "Tipo Sanguineo não cadastrado")
                    label6.Visible = true;

                if (LblPessoasAjudadas.Text == "Tipo Sanguineo não cadastrado")
                    BtCriaCampanha.Visible = false;
            }
        }

        private void BuscaCampanha()
        {
            try
            {
                string Email = value;

                string query = $@"select distinct top 1 d.Id, d.Nome, f.Descricao, e.Nome as 'Hospital', CONVERT(VARCHAR,d.DataCriacao) as 'Data' from Usuario a
                              join UsuarioDoador b on b.IdUsuario = a.Id 
                              join Doador c on b.IdDoador = c.Id 
                              join CampanhaUsuario d on d.IdDoador = c.Id 
                              join Hospital e on d.IdHospital = e.Id
                              join TiposSanguineos f on d.TipoSolicitado = f.Id
                              where a.Email = '{Email}'
                              and c.Email = '{Email}'
                              and d.DataFinalizacao is null";

                var retorno = DBase.LoadData<CampanhasDoador>(query);

                if (retorno.Count() == 0)
                {
                    LblNomeCampanha.Text = "Nenhuma campanha ativa no momento";
                    BtFinalizaCampanha.Visible = false;
                    LblTipoCampanha.Visible = false;
                    LblHospital.Visible = false;
                    LblDataCriacao.Visible = false;

                    BtCriaCampanha.Visible = true;
                }
                else
                {
                    LblNomeCampanha.Text = retorno.FirstOrDefault().Nome.ToString();
                    LblTipoCampanha.Text = retorno.FirstOrDefault().Descricao.ToString();
                    LblHospital.Text = retorno.FirstOrDefault().Hospital.ToString();
                    LblDataCriacao.Text = retorno.FirstOrDefault().Data.ToString();
                    LblIdCampanha.Text = retorno.FirstOrDefault().Id.ToString();
                    BtFinalizaCampanha.Visible = true;
                    LblTipoCampanha.Visible = true;
                    LblHospital.Visible = true;
                    LblDataCriacao.Visible = true;

                    BtCriaCampanha.Visible = false;
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private void BtFinalizaCampanha_Click(object sender, EventArgs e)
        {
            FinalizaCampanha();
        }

        private void FinalizaCampanha()
        {
            try
            {
                string Email = value;
                string IdCampanha = LblIdCampanha.Text;

                string query = $@"update d set DataFinalizacao = getdate()
                              from Usuario a
                              join UsuarioDoador b on b.IdUsuario = a.Id 
                              join Doador c on b.IdDoador = c.Id 
                              join CampanhaUsuario d on d.IdDoador = c.Id 
                              join Hospital e on d.IdHospital = e.Id
                              where a.Email = '{Email}'
                              and c.Email = '{Email}'
                              and d.Id = '{IdCampanha}'
                              and d.DataFinalizacao is null";

                var retorno = DBase.ExecuteWithReturnAffected(query);

                if (retorno == 0)
                {
                    MessageBox.Show("Erro ao finalizar a campanha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    BuscaCampanha();
                    BuscaCampanhaFinalizadas();
                    MessageBox.Show("Campanha finalizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private void BtCriaCampanha_Click(object sender, EventArgs e)
        {
            var retorno = DBase.TestaConexao();

            if (retorno == "Erro")
            {

            }
            else
            {
                CriaCampanha criaCampanha = new CriaCampanha();
                criaCampanha.value = value;
                criaCampanha.ShowDialog();
            }
        }

        private void BuscaCampanhaFinalizadas()
        {
            try
            {
                string Email = value;

                string query = $@"select distinct d.Nome, f.Descricao, e.Nome as 'Hospital', convert(VARCHAR,d.DataCriacao) as 'DataCriacao', convert(VARCHAR,d.DataFinalizacao) as 'DataFinalizacao', d.DataCriacao
                              from Usuario a
                              join UsuarioDoador b on b.IdUsuario = a.Id 
                              join Doador c on b.IdDoador = c.Id 
                              join CampanhaUsuario d on d.IdDoador = c.Id 
                              join Hospital e on d.IdHospital = e.Id
                              join TiposSanguineos f on d.TipoSolicitado = f.Id
                              where a.Email = '{Email}'
                              and c.Email = '{Email}'
                              and d.DataFinalizacao is not null
                              order by d.DataCriacao desc";

                var retorno = DBase.LoadData<BuscaCampanhas>(query);

                dataGridView1.DataSource = retorno;

                dataGridView1.Refresh();
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns["Descricao"].HeaderText = "Tipo Sanguineo Solicitado";
                dataGridView1.Columns["DataCriacao"].HeaderText = "Data de Criação";
                dataGridView1.Columns["DataFinalizacao"].HeaderText = "Data de Finalização";
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
                if (LblDoaPara.Text == "Tipo Sanguineo não cadastrado" || LblRecebeDe.Text == "Tipo Sanguineo não cadastrado")
                {
                    string query = $@"select ('Realize o Cadastro Completo para Visualizar os Hospitais proximos') as 'Texto'";

                    var retorno = DBase.LoadData<Descricao>(query);

                    dataGridView2.DataSource = retorno;

                    dataGridView2.Refresh();
                    dataGridView2.AutoResizeColumns();
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    string Email = value;
                    string Endereco = CBBxEndereco.SelectedValue.ToString();

                    string query = $@"select distinct e.Nome as 'Hospital', (select e.Endereco + ', ' + e.Numero) as 'Endereço', 
                              e.Bairro, e.Cidade, e.UF, e.Telefone from Usuario a 
                              join UsuarioDoador b on b.IdUsuario = a.Id 
                              join Doador c on b.IdDoador = c.Id
                              join EnderecoDoador d on d.IdDoador = c.Id 
                              join Hospital e on e.Cidade = d.Cidade 
                              where a.Email = '{Email}'
                              and d.Id = '{Endereco}'
                              and e.Cidade = d.Cidade
                              and d.DataExclusao is null";

                    var retorno = DBase.LoadData<BuscaHospitais>(query);

                    dataGridView2.DataSource = retorno;

                    dataGridView2.Refresh();
                    dataGridView2.AutoResizeColumns();
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscaCampanhasAtivasUsuarios()
        {
            try
            {
                if (LblDoaPara.Text == "Tipo Sanguineo não cadastrado" || LblRecebeDe.Text == "Tipo Sanguineo não cadastrado")
                {
                    string query = $@"select ('Realize o Cadastro Completo para Visualizar as Campanhas Ativas no Momento') as 'Endereco'";

                    var retorno = DBase.LoadData<BuscaCampanhasUsuarios>(query);

                    dataGridView2.DataSource = retorno;

                    dataGridView2.Refresh();
                    dataGridView2.AutoResizeColumns();
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    string Email = value;
                    string Endereco = CBBxEndereco.SelectedValue.ToString();

                    string query = $@"select distinct f.Nome as 'Campanha', e.Nome as 'Hospital', g.Descricao, (select e.Endereco + ', ' + e.Numero) as 'Endereço', e.Cidade, e.UF as 'Estado', e.Telefone as 'Contato', f.DataCriacao from Usuario a
                              join UsuarioDoador b on b.IdUsuario = a.Id 
                              join Doador c on b.IdDoador = c.Id 
                              join EnderecoDoador d on d.IdDoador = c.Id 
                              join Hospital e on e.Cidade = d.Cidade
                              join CampanhaUsuario f on f.IdHospital = e.Id
                              join TiposSanguineos g on f.TipoSolicitado = g.Id
                              where a.Email = '{Email}' 
                              and d.Id = '{Endereco}'
                              and e.Cidade = d.Cidade
                              and f.DataFinalizacao is null
							  and f.TipoSolicitado = c.IdTipoSanguineo
                              order by f.DataCriacao";

                    var retorno = DBase.LoadData<BuscaCampanhasUsuarios>(query);

                    dataGridView3.DataSource = retorno;

                    dataGridView3.Refresh();
                    dataGridView3.AutoResizeColumns();
                    dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView3.Columns["Descricao"].HeaderText = "Tipo Sanguineo Solicitado";
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscaCampanhasAtivasHospitais()
        {
            try
            {
                if (LblDoaPara.Text == "Tipo Sanguineo não cadastrado" || LblRecebeDe.Text == "Tipo Sanguineo não cadastrado")
                {
                    string query = $@"select ('Realize o Cadastro Completo para Visualizar as Campanhas Ativas no Momento') as 'Endereco'";

                    var retorno = DBase.LoadData<BuscaCampanhasHospitais>(query);

                    dataGridView2.DataSource = retorno;

                    dataGridView2.Refresh();
                    dataGridView2.AutoResizeColumns();
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    string Email = value;
                    string Endereco = CBBxEndereco.SelectedValue.ToString();

                    string query = $@"select distinct f.Nome as 'Campanha', e.Nome as 'Hospital', g.Descricao, (select e.Endereco + ', ' + e.Numero) as 'Endereço', e.Cidade, e.UF as 'Estado', e.Telefone as 'Contato', f.DataCriacao from Usuario a
                              join UsuarioDoador b on b.IdUsuario = a.Id 
                              join Doador c on b.IdDoador = c.Id 
                              join EnderecoDoador d on d.IdDoador = c.Id 
                              join Hospital e on e.Cidade = d.Cidade
                              join CampanhaHospital f on f.IdHospital = e.Id 
                              join TiposSanguineos g on f.TipoSolicitado = g.Id
                              where a.Email = '{Email}' 
                              and d.Id = '{Endereco}'
                              and e.Cidade = d.Cidade
                              and f.DataFinalizacao is null
							  and (f.TipoSolicitado = c.IdTipoSanguineo or f.TipoSolicitado = '1FBFE62B-6E0D-472F-8AB2-3DFB636108A7')
                              order by f.DataCriacao";

                    var retorno = DBase.LoadData<BuscaCampanhasHospitais>(query);

                    dataGridView4.DataSource = retorno;

                    dataGridView4.Refresh();
                    dataGridView4.AutoResizeColumns();
                    dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView4.Columns["Descricao"].HeaderText = "Tipo Sanguineo Solicitado";
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void CBBxEndereco_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BtAdicionaEndereco_Click(object sender, EventArgs e)
        {
            var retorno = DBase.TestaConexao();

            if (retorno == "Erro")
            {

            }
            else
            {
                AdicionaEndereco adicionaEndereco = new AdicionaEndereco();
                adicionaEndereco.value = value;
                adicionaEndereco.ShowDialog();
            }
        }

        private void CBBxEndereco_Click(object sender, EventArgs e)
        {
            BuscaEnderecoRecente();
        }

        private void CBBxEndereco_SelectedIndexChanged(object sender, EventArgs e)
        {
            var retorno = DBase.TestaConexao();

            if (retorno == "Erro")
            {

            }
            else
            {
                BuscaHospital();
                BuscaCampanhasAtivasHospitais();
                BuscaCampanhasAtivasUsuarios();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var retorno = DBase.TestaConexao();

            if (retorno == "Erro")
            {

            }
            else
            {
                RemoveEndereco removeEndereco = new RemoveEndereco();
                removeEndereco.value = value;
                removeEndereco.ShowDialog();
            }
        }
    }
}
