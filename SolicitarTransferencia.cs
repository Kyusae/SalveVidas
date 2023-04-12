using Salve_Vidas.Db;
using Salve_Vidas.Model;

namespace Salve_Vidas
{
    public partial class SolicitarTransferencia : Form
    {
        public string value { get; set; }
        public string value2 { get; set; }

        public SolicitarTransferencia()
        {
            InitializeComponent();
        }

        public string NotAllowed2 = @"'><{}[]#&()/|*-+$%~\!¨_?:,;ºª°""§¹²³£¢¬=";

        private void SolicitarTransferencia_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Logofull;
            BuscaTipoSanguineo();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtBxQuantidade.Text))
                {
                    MessageBox.Show("Preencha a quantidade de sangue solicitada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string Email = value;
                    string Senha = value2;
                    string TipoSolicitado = CBBxTipoSanguineo.SelectedValue.ToString();
                    string Quantidade = TxtBxQuantidade.Text.Trim();

                    string query = $@"select c.Id as 'IdHospital', c.Cidade from Usuario a 
                              join UsuarioHospital b on b.IdUsuario = a.Id 
                              join Hospital c on c.Id = b.IdHospital 
                              where a.Email = '{Email}' 
                              and a.Senha = '{Senha}'";

                    var retorno = DBase.LoadData<IdCidadeHospital>(query);

                    if (retorno.Count() == 0)
                    {
                        MessageBox.Show("Erro ao criar solicitação, tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string query2 = $@"insert into TransferenciasHospital values (newid(), '{retorno.FirstOrDefault().IdHospital}', '{TipoSolicitado}', '{Quantidade}', '{retorno.FirstOrDefault().Cidade}', getdate(), null)";

                        var retorno2 = DBase.ExecuteWithReturnAffected(query2);

                        if (retorno2 > 0)
                        {
                            MessageBox.Show("Solicitação criada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao criar solicitação, tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CBBxTipoSanguineo_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtBxQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)))
                e.Handled = true;
        }
    }
}
