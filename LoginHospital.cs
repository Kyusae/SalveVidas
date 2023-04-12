using Salve_Vidas.Db;
using Salve_Vidas.Model;

namespace Salve_Vidas
{
    public partial class LoginHospital : Form
    {
        public string value { get; set; }
        public string value2 { get; set; }

        public LoginHospital()
        {
            InitializeComponent();
        }

        private void LoginHospital__Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Logofull;
            BuscaSenha();
            BuscaCampanha();
            BuscaImagem();
            BuscaNomeUsuario();
            BuscaEnderecoRecente();
            BuscaTransferenciasAbertas();
            BuscaQuantidadeSangue();
            BuscaTransferencia();
            BuscaTransferenciasFinalizadasUsuario();
            BuscaHospitais();
            BotTransferencia.Location = new Point(487, 102);
        }

        private void BuscaSenha()
        {
            try
            {
                string Email = value;

                string query = $@"select Senha from Usuario where Email = '{Email}'";

                var retorno = DBase.LoadData<SenhaUsuario>(query);

                if (retorno.Count() == 0)
                {
                    MessageBox.Show("Erro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    value2 = retorno.FirstOrDefault().Senha;
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscaHospitais()
        {
            try
            {
                string Email = value;
                string Senha = value2;

                string query = $@"select distinct c.Nome as 'Hospital', (select c.Endereco + ', ' + c.Numero) as 'Endereço', 
                              c.Bairro, c.Cidade, c.UF, c.Telefone from Hospital c
                              where c.Cidade = (select c.Cidade from Usuario a join UsuarioHospital b on b.IdUsuario = a.Id join Hospital c on c.Id = b.IdHospital where a.Email = '{Email}' and a.Senha = '{Senha}')
                              and c.Id != (select c.Id from Usuario a join UsuarioHospital b on b.IdUsuario = a.Id join Hospital c on c.Id = b.IdHospital where a.Email = '{Email}' and a.Senha = '{Senha}') 
                              and c.DataExclusao is null";

                var retorno = DBase.LoadData<BuscaHospitais>(query);

                if (retorno.Count() == 0)
                {
                    dataGridView2.DataSource = null;
                }
                else
                {
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

        private void BuscaTransferenciasFinalizadasUsuario()
        {
            try
            {
                string Email = value;
                string Senha = value2;
                string query = $@"select e.Descricao, a.Quantidade, a.DataDaSolicitacao, a.DataFinalizacao from TransferenciasHospital a
                                  join TiposSanguineos e on e.Id = a.IdTipoSanguineo
                                  join Hospital b on b.Id = a.IdHospital
                                  join UsuarioHospital c on c.IdHospital = b.Id
                                  join Usuario d on d.Id = c.IdUsuario
                                  where d.Email = '{Email}'
                                  and d.Senha = '{Senha}'
                                  and a.DataFinalizacao is not null
								  order by a.DataFinalizacao desc";

                var retorno = DBase.LoadData<TransferenciaFinalizadas>(query);

                if (retorno.Count() == 0)
                {
                    dataGridView4.DataSource = retorno;
                }
                else
                {
                    dataGridView4.DataSource = retorno;

                    dataGridView4.Refresh();
                    dataGridView4.AutoResizeColumns();
                    dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView4.Columns["Descricao"].HeaderText = "Tipo Sanguineo Solicitado";
                    dataGridView4.Columns["Quantidade"].HeaderText = "Quantidade Solicitada (Em Litros)";
                    dataGridView4.Columns["DataDaSolicitacao"].HeaderText = "Data de Criação";
                    dataGridView4.Columns["DataFinalizacao"].HeaderText = "Data de Finalização";
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscaTransferencia()
        {
            try
            {
                string Email = value;
                string Senha = value2;
                string query = $@"select a.Id, e.Descricao, a.Quantidade, a.Id from TransferenciasHospital a
                                  join TiposSanguineos e on e.Id = a.IdTipoSanguineo
                                  join Hospital b on b.Id = a.IdHospital
                                  join UsuarioHospital c on c.IdHospital = b.Id
                                  join Usuario d on d.Id = c.IdUsuario
                                  where d.Email = '{Email}'
                                  and d.Senha = '{Senha}'
                                  and a.DataFinalizacao is null";

                var retorno = DBase.LoadData<Transferencia>(query);

                if (retorno.Count() == 0)
                {
                    BotTransferencia.Visible = true;
                    BotTransferencia.Location = new Point(487, 102);
                    LblTipo.Visible = false;
                    BotFinalizaTransferencia.Visible = false;
                    PnlTransferencia.Visible = false;
                }
                else
                {
                    LblTipo.Text = retorno.FirstOrDefault().Descricao;
                    LblQuantidade.Text = retorno.FirstOrDefault().Quantidade.ToString();
                    LblId.Text = retorno.FirstOrDefault().Id;

                    BotTransferencia.Visible = false;
                    LblTipo.Visible = true;
                    BotFinalizaTransferencia.Visible = true;
                    PnlTransferencia.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BuscaQuantidadeSangue()
        {
            try
            {
                string Email = value;
                string Senha = value2;

                string queryAPositivo = $@"select a.QuantidadeMinima, a.QuantidadeMaxima, a.QuantidadeAtual from EstoqueDeSangue a
                              join TiposSanguineos e on e.Id = a.IdTipoSanguineo
                              join Hospital b on b.Id = a.IdHospital 
                              join UsuarioHospital c on c.IdHospital = b.Id 
                              join Usuario d on d.Id = c.IdUsuario 
                              where d.Email = '{Email}'
                              and d.Senha = '{Senha}'
                              and e.Id = '955B8DDC-E105-4B31-B2A5-5E822653B224'";

                string queryANegativo = $@"select a.QuantidadeMinima, a.QuantidadeMaxima, a.QuantidadeAtual from EstoqueDeSangue a
                              join TiposSanguineos e on e.Id = a.IdTipoSanguineo
                              join Hospital b on b.Id = a.IdHospital 
                              join UsuarioHospital c on c.IdHospital = b.Id 
                              join Usuario d on d.Id = c.IdUsuario 
                              where d.Email = '{Email}'
                              and d.Senha = '{Senha}'
                              and e.Id = '824447E5-ACF3-4C1F-9DD5-86082973DF9F'";

                string queryABPositivo = $@"select a.QuantidadeMinima, a.QuantidadeMaxima, a.QuantidadeAtual from EstoqueDeSangue a
                              join TiposSanguineos e on e.Id = a.IdTipoSanguineo
                              join Hospital b on b.Id = a.IdHospital 
                              join UsuarioHospital c on c.IdHospital = b.Id 
                              join Usuario d on d.Id = c.IdUsuario 
                              where d.Email = '{Email}'
                              and d.Senha = '{Senha}'
                              and e.Id = 'E2B24E8A-78BB-421C-9751-95864A6AE9C9'";

                string queryABNegativo = $@"select a.QuantidadeMinima, a.QuantidadeMaxima, a.QuantidadeAtual from EstoqueDeSangue a
                              join TiposSanguineos e on e.Id = a.IdTipoSanguineo
                              join Hospital b on b.Id = a.IdHospital 
                              join UsuarioHospital c on c.IdHospital = b.Id 
                              join Usuario d on d.Id = c.IdUsuario 
                              where d.Email = '{Email}'
                              and d.Senha = '{Senha}'
                              and e.Id = '9046BEE6-EC59-4CE2-8C26-EBB37FA46726'";

                string queryBPositivo = $@"select a.QuantidadeMinima, a.QuantidadeMaxima, a.QuantidadeAtual from EstoqueDeSangue a
                              join TiposSanguineos e on e.Id = a.IdTipoSanguineo
                              join Hospital b on b.Id = a.IdHospital 
                              join UsuarioHospital c on c.IdHospital = b.Id 
                              join Usuario d on d.Id = c.IdUsuario 
                              where d.Email = '{Email}'
                              and d.Senha = '{Senha}'
                              and e.Id = '2C2808C7-06B2-42C1-B19A-6564A992CF16'";

                string queryBNegativo = $@"select a.QuantidadeMinima, a.QuantidadeMaxima, a.QuantidadeAtual from EstoqueDeSangue a
                              join TiposSanguineos e on e.Id = a.IdTipoSanguineo
                              join Hospital b on b.Id = a.IdHospital 
                              join UsuarioHospital c on c.IdHospital = b.Id 
                              join Usuario d on d.Id = c.IdUsuario 
                              where d.Email = '{Email}'
                              and d.Senha = '{Senha}'
                              and e.Id = 'D7D10447-26BC-4B73-874E-96F6EFA0B51C'";

                string queryOPositivo = $@"select a.QuantidadeMinima, a.QuantidadeMaxima, a.QuantidadeAtual from EstoqueDeSangue a
                              join TiposSanguineos e on e.Id = a.IdTipoSanguineo
                              join Hospital b on b.Id = a.IdHospital 
                              join UsuarioHospital c on c.IdHospital = b.Id 
                              join Usuario d on d.Id = c.IdUsuario 
                              where d.Email = '{Email}'
                              and d.Senha = '{Senha}'
                              and e.Id = '396E3982-2D97-47E0-8B00-DE5C41F0DD43'";

                string queryONegativo = $@"select a.QuantidadeMinima, a.QuantidadeMaxima, a.QuantidadeAtual from EstoqueDeSangue a
                              join TiposSanguineos e on e.Id = a.IdTipoSanguineo
                              join Hospital b on b.Id = a.IdHospital 
                              join UsuarioHospital c on c.IdHospital = b.Id 
                              join Usuario d on d.Id = c.IdUsuario 
                              where d.Email = '{Email}'
                              and d.Senha = '{Senha}'
                              and e.Id = 'FBB3D017-592A-4B5E-8FF1-2EB5CF1A1461'";

                var retorno = DBase.LoadData<EstoqueSangue>(queryAPositivo);
                var retorno2 = DBase.LoadData<EstoqueSangue>(queryANegativo);
                var retorno3 = DBase.LoadData<EstoqueSangue>(queryABPositivo);
                var retorno4 = DBase.LoadData<EstoqueSangue>(queryABNegativo);
                var retorno5 = DBase.LoadData<EstoqueSangue>(queryBPositivo);
                var retorno6 = DBase.LoadData<EstoqueSangue>(queryBNegativo);
                var retorno7 = DBase.LoadData<EstoqueSangue>(queryOPositivo);
                var retorno8 = DBase.LoadData<EstoqueSangue>(queryONegativo);

                if (retorno.Count() == 0 || retorno2.Count() == 0 || retorno3.Count() == 0 || retorno4.Count() == 0 ||
                    retorno5.Count() == 0 || retorno6.Count() == 0 || retorno7.Count() == 0 || retorno8.Count() == 0)
                {
                    MessageBox.Show("Erro ao buscar quantidade de sangue.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //A+
                    if (retorno.FirstOrDefault().QuantidadeAtual > retorno.FirstOrDefault().QuantidadeMaxima || retorno.FirstOrDefault().QuantidadeAtual < retorno.FirstOrDefault().QuantidadeMinima)
                    {
                        MessageBox.Show("Quantidade de Sangue A+ maior/menor do que o limite.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PgBrAPositivo.Minimum = 0;
                        PgBrAPositivo.Maximum = 100;
                        PgBrAPositivo.Value = 0;
                    }
                    else
                    {
                        PgBrAPositivo.Minimum = retorno.FirstOrDefault().QuantidadeMinima;
                        PgBrAPositivo.Maximum = retorno.FirstOrDefault().QuantidadeMaxima;
                        PgBrAPositivo.Value = retorno.FirstOrDefault().QuantidadeAtual;
                    }

                    //A-
                    if (retorno2.FirstOrDefault().QuantidadeAtual > retorno2.FirstOrDefault().QuantidadeMaxima || retorno2.FirstOrDefault().QuantidadeAtual < retorno2.FirstOrDefault().QuantidadeMinima)
                    {
                        MessageBox.Show("Quantidade de Sangue A- maior/menor do que o limite.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PgBrANegativo.Minimum = 0;
                        PgBrANegativo.Maximum = 100;
                        PgBrANegativo.Value = 0;
                    }
                    else
                    {
                        PgBrANegativo.Minimum = retorno2.FirstOrDefault().QuantidadeMinima;
                        PgBrANegativo.Maximum = retorno2.FirstOrDefault().QuantidadeMaxima;
                        PgBrANegativo.Value = retorno2.FirstOrDefault().QuantidadeAtual;
                    }

                    //AB+
                    if (retorno3.FirstOrDefault().QuantidadeAtual > retorno3.FirstOrDefault().QuantidadeMaxima || retorno3.FirstOrDefault().QuantidadeAtual < retorno3.FirstOrDefault().QuantidadeMinima)
                    {
                        MessageBox.Show("Quantidade de Sangue AB+ maior/menor do que o limite.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PgBrABPositivo.Minimum = 0;
                        PgBrABPositivo.Maximum = 100;
                        PgBrABPositivo.Value = 0;
                    }
                    else
                    {
                        PgBrABPositivo.Minimum = retorno3.FirstOrDefault().QuantidadeMinima;
                        PgBrABPositivo.Maximum = retorno3.FirstOrDefault().QuantidadeMaxima;
                        PgBrABPositivo.Value = retorno3.FirstOrDefault().QuantidadeAtual;
                    }

                    //AB-
                    if (retorno4.FirstOrDefault().QuantidadeAtual > retorno4.FirstOrDefault().QuantidadeMaxima || retorno4.FirstOrDefault().QuantidadeAtual < retorno4.FirstOrDefault().QuantidadeMinima)
                    {
                        MessageBox.Show("Quantidade de Sangue AB- maior/menor do que o limite.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PgBrABNegativo.Minimum = 0;
                        PgBrABNegativo.Maximum = 100;
                        PgBrABNegativo.Value = 0;
                    }
                    else
                    {
                        PgBrABNegativo.Minimum = retorno4.FirstOrDefault().QuantidadeMinima;
                        PgBrABNegativo.Maximum = retorno4.FirstOrDefault().QuantidadeMaxima;
                        PgBrABNegativo.Value = retorno4.FirstOrDefault().QuantidadeAtual;
                    }

                    //B+
                    if (retorno5.FirstOrDefault().QuantidadeAtual > retorno5.FirstOrDefault().QuantidadeMaxima || retorno5.FirstOrDefault().QuantidadeAtual < retorno5.FirstOrDefault().QuantidadeMinima)
                    {
                        MessageBox.Show("Quantidade de Sangue B+ maior/menor do que o limite.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PgBrBPositivo.Minimum = 0;
                        PgBrBPositivo.Maximum = 100;
                        PgBrBPositivo.Value = 0;
                    }
                    else
                    {
                        PgBrBPositivo.Minimum = retorno5.FirstOrDefault().QuantidadeMinima;
                        PgBrBPositivo.Maximum = retorno5.FirstOrDefault().QuantidadeMaxima;
                        PgBrBPositivo.Value = retorno5.FirstOrDefault().QuantidadeAtual;
                    }

                    //B-
                    if (retorno6.FirstOrDefault().QuantidadeAtual > retorno6.FirstOrDefault().QuantidadeMaxima || retorno6.FirstOrDefault().QuantidadeAtual < retorno6.FirstOrDefault().QuantidadeMinima)
                    {
                        MessageBox.Show("Quantidade de Sangue B- maior/menor do que o limite.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PgBrBNegativo.Minimum = 0;
                        PgBrBNegativo.Maximum = 100;
                        PgBrBNegativo.Value = 0;
                    }
                    else
                    {
                        PgBrBNegativo.Minimum = retorno6.FirstOrDefault().QuantidadeMinima;
                        PgBrBNegativo.Maximum = retorno6.FirstOrDefault().QuantidadeMaxima;
                        PgBrBNegativo.Value = retorno6.FirstOrDefault().QuantidadeAtual;
                    }

                    //O+
                    if (retorno7.FirstOrDefault().QuantidadeAtual > retorno7.FirstOrDefault().QuantidadeMaxima || retorno7.FirstOrDefault().QuantidadeAtual < retorno7.FirstOrDefault().QuantidadeMinima)
                    {
                        MessageBox.Show("Quantidade de Sangue O+ maior/menor do que o limite.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PgBrOPositivo.Minimum = 0;
                        PgBrOPositivo.Maximum = 100;
                        PgBrOPositivo.Value = 0;
                    }
                    else
                    {
                        PgBrOPositivo.Minimum = retorno7.FirstOrDefault().QuantidadeMinima;
                        PgBrOPositivo.Maximum = retorno7.FirstOrDefault().QuantidadeMaxima;
                        PgBrOPositivo.Value = retorno7.FirstOrDefault().QuantidadeAtual;
                    }

                    //O-
                    if (retorno8.FirstOrDefault().QuantidadeAtual > retorno8.FirstOrDefault().QuantidadeMaxima || retorno8.FirstOrDefault().QuantidadeAtual < retorno8.FirstOrDefault().QuantidadeMinima)
                    {
                        MessageBox.Show("Quantidade de Sangue O- maior/menor do que o limite.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PgBrONegativo.Minimum = 0;
                        PgBrONegativo.Maximum = 100;
                        PgBrONegativo.Value = 0;
                    }
                    else
                    {
                        PgBrONegativo.Minimum = retorno8.FirstOrDefault().QuantidadeMinima;
                        PgBrONegativo.Maximum = retorno8.FirstOrDefault().QuantidadeMaxima;
                        PgBrONegativo.Value = retorno8.FirstOrDefault().QuantidadeAtual;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscaTransferenciasAbertas()
        {
            try
            {
                string Email = value;
                string Senha = value2;

                string query = $@"select b.Nome as 'Hospital', c.Descricao as 'TipoSolicitado', a.Quantidade, b.Telefone, a.DataDaSolicitacao from TransferenciasHospital a
                                  join Hospital b on b.Id = a.IdHospital
                                  join TiposSanguineos c on c.Id = a.IdTipoSanguineo 
                                  where a.Cidade = (select c.Cidade from Usuario a join UsuarioHospital b on b.IdUsuario = a.Id join Hospital c on c.Id = b.IdHospital where a.Email = '{Email}' and a.Senha = '{Senha}')
                                  and a.DataFinalizacao is null
                                  and a.IdHospital != (select c.Id from Usuario a join UsuarioHospital b on b.IdUsuario = a.Id join Hospital c on c.Id = b.IdHospital where a.Email = '{Email}' and a.Senha = '{Senha}')
                                  order by a.DataDaSolicitacao";

                string query2 = $@"select ('Sem solicitações de transfêrencia no momento') as 'Transferencia'";

                var retorno = DBase.LoadData<Transferencias>(query);

                var retorno2 = DBase.LoadData<SemTransferencias>(query2);

                if (retorno.Count() == 0)
                {
                    dataGridView3.DataSource = retorno2;
                    dataGridView3.Refresh();
                    dataGridView3.AutoResizeColumns();
                    dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    dataGridView3.DataSource = retorno;

                    dataGridView3.Refresh();
                    dataGridView3.AutoResizeColumns();
                    dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView3.Columns["TipoSolicitado"].HeaderText = "Tipo Sanguineo Solicitado";
                    dataGridView3.Columns["DataDaSolicitacao"].HeaderText = "Data Da Solicitacao";
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscaEnderecoRecente()
        {
            try
            {
                string Email = value;
                string Senha = value2;

                string query = $@"select distinct (SELECT c.Endereco + ', ' + c.Numero + ' - ' + c.Bairro + ' - ' + c.Cidade + ' - ' + e.UF) as Endereco, c.Id
                                  from Usuario a
                                  join UsuarioHospital b on b.IdUsuario = a.Id
                                  join Hospital c on b.IdHospital = c.Id
                                  join Estado e on e.Nome = c.Estado
                                  where a.Email = '{Email}' 
                                  and a.Senha = '{Senha}'";

                var retorno = DBase.LoadData<EnderecoUsuario>(query);

                if (retorno.Count() == 0)
                {
                    LblEndereco.Text = "Endereço não cadastrado";
                    BtCriaCampanha.Visible = false;
                    TxtBxEndereco.Visible = false;
                }
                else
                {
                    TxtBxEndereco.Visible = true;
                    TxtBxEndereco.Text = retorno.FirstOrDefault().Endereco;
                }
            }
            catch
            {
                return;
            }
        }

        private void BuscaNomeUsuario()
        {
            try
            {

                string Email = value;
                string Senha = value2;

                string query = $@"select a.Nome, c.Nome as 'NomeHospital' from Usuario a
                                  join UsuarioHospital b on b.IdUsuario = a.Id
                                  join Hospital c on c.Id = b.IdHospital
                                  where a.Email = '{Email}'
                                  and a.Senha = '{Senha}'";

                var retorno = DBase.LoadData<ExisteUsuarioDoador>(query);

                if (retorno.Count() == 0)
                {
                    MessageBox.Show("Erro ao buscar nome do Usuario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    LblNome.Text = retorno.FirstOrDefault().Nome.ToString();
                    LblNomeHospital.Text = retorno.FirstOrDefault().NomeHospital.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscaImagem()
        {
            try
            {
                string Email = value;
                string Senha = value2;

                string query = $@"SELECT b.Imagem as 'Foto' FROM Usuario a 
                                  join UsuarioHospital b on b.IdUsuario = a.Id 
                                  join Hospital c on c.Id = b.IdHospital 
                                  where a.Email = '{Email}'
                                  and a.Senha = '{Senha}'";

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

        private void BuscaCampanha()
        {
            try
            {
                string Email = value;
                string Senha = value2;

                string query = $@"select distinct top 1 d.Id, d.Nome, f.Descricao, e.Nome as 'Hospital', CONVERT(VARCHAR,d.DataCriacao) as 'Data' from Usuario a
                              join UsuarioHospital b on b.IdUsuario = a.Id 
                              join Hospital c on b.IdHospital = c.Id 
                              join CampanhaHospital d on d.IdHospital = c.Id 
                              join Hospital e on d.IdHospital = e.Id
                              join TiposSanguineos f on d.TipoSolicitado = f.Id
                              where a.Email = '{Email}'
                              and a.Senha = '{Senha}'
                              and d.DataFinalizacao is null";

                var retorno = DBase.LoadData<CampanhasDoador>(query);

                if (retorno.Count() == 0)
                {
                    LblNomeCampanha.Text = "Nenhuma campanha ativa no momento";
                    BtFinalizaCampanha.Visible = false;
                    LblTipoCampanha.Visible = false;
                    LblDataCriacao.Visible = false;

                    BtCriaCampanha.Visible = true;
                }
                else
                {
                    LblNomeCampanha.Text = retorno.FirstOrDefault().Nome.ToString();
                    LblTipoCampanha.Text = retorno.FirstOrDefault().Descricao.ToString();
                    LblDataCriacao.Text = retorno.FirstOrDefault().Data.ToString();
                    LblIdCampanha.Text = retorno.FirstOrDefault().Id.ToString();
                    BtFinalizaCampanha.Visible = true;
                    LblTipoCampanha.Visible = true;
                    LblDataCriacao.Visible = true;

                    BtCriaCampanha.Visible = false;
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                criaCampanha.value2 = value2;
                criaCampanha.Atualizacao = "1";
                criaCampanha.ShowDialog();
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
                string Senha = value2;
                string IdCampanha = LblIdCampanha.Text;

                string query = $@"update d set DataFinalizacao = getdate()
                                  from Usuario a
                                  join UsuarioHospital b on b.IdUsuario = a.Id 
                                  join Hospital c on b.IdHospital = c.Id 
                                  join CampanhaHospital d on d.IdHospital = c.Id
                                  where a.Email = '{Email}'
                                  and a.Senha = '{Senha}'
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
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscaCampanhaFinalizadas()
        {
            try
            {
                string Email = value;
                string Senha = value2;

                string query = $@"select distinct d.Nome, f.Descricao, e.Nome as 'Hospital', convert(VARCHAR,d.DataCriacao) as 'DataCriacao', convert(VARCHAR,d.DataFinalizacao) as 'DataFinalizacao', d.DataCriacao
                                  from Usuario a
                                  join UsuarioHospital b on b.IdUsuario = a.Id 
                                  join Hospital c on b.IdHospital = c.Id 
                                  join CampanhaHospital d on d.IdHospital = c.Id 
                                  join Hospital e on d.IdHospital = e.Id
                                  join TiposSanguineos f on d.TipoSolicitado = f.Id
                                  where a.Email = '{Email}'
                                  and a.Senha = '{Senha}'
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void LoginHospital__Activated(object sender, EventArgs e)
        {
            var retorno = DBase.TestaConexao();

            if (retorno == "Erro")
            {

            }
            else
            {
                BuscaSenha();
                BuscaImagem();
                BuscaCampanha();
                BuscaCampanhaFinalizadas();
                BuscaTransferenciasAbertas();
                BuscaEnderecoRecente();
                BuscaTransferencia();
                BuscaTransferenciasFinalizadasUsuario();
                BuscaHospitais();
                BuscaQuantidadeSangue();
            }
        }

        private void LoginHospital__FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void BotTransferencia_Click(object sender, EventArgs e)
        {
            SolicitarTransferencia solicitarTransferencia = new SolicitarTransferencia();
            solicitarTransferencia.value = value;
            solicitarTransferencia.value2 = value2;
            solicitarTransferencia.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Email = value;
            string Senha = value2;
            string Transferencia = LblId.Text;

            string query = $@"update a set DataFinalizacao = getdate()
                              from TransferenciasHospital a
                              join TiposSanguineos e on e.Id = a.IdTipoSanguineo
                              join Hospital b on b.Id = a.IdHospital
                              join UsuarioHospital c on c.IdHospital = b.Id
                              join Usuario d on d.Id = c.IdUsuario
                              where d.Email = '{Email}'
                              and d.Senha = '{Senha}'
                              and a.Id = '{Transferencia}'";

            var retorno = DBase.ExecuteWithReturnAffected(query);

            if (retorno == 0)
            {
                MessageBox.Show("Erro ao finalizar a transferencia", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                BotTransferencia.Visible = true;
                BotTransferencia.Location = new Point(487, 102);
                BotFinalizaTransferencia.Visible = false;
                PnlTransferencia.Visible = false;
                MessageBox.Show("Transferencia finalizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BotAtualizaSangue_Click(object sender, EventArgs e)
        {
            AtualizaEstoqueSangue atualizaEstoqueSangue = new AtualizaEstoqueSangue();
            atualizaEstoqueSangue.value = value;
            atualizaEstoqueSangue.value2 = value2;
            atualizaEstoqueSangue.ShowDialog();
        }

        private void PicBxAtualizarCadastro_Click(object sender, EventArgs e)
        {
            var retorno = DBase.TestaConexao();

            if (retorno == "Erro")
            {

            }
            else
            {
                AtualizaCadastro atualizacadastro = new AtualizaCadastro();
                atualizacadastro.value = value;
                atualizacadastro.value2 = value2;
                atualizacadastro.Atualizacao = "1";
                atualizacadastro.ShowDialog();
            }
        }
    }
}
