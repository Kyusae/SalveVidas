using Salve_Vidas.Db;
using Salve_Vidas.Model;

namespace Salve_Vidas
{
    public partial class RedSenha : Form
    {
        public RedSenha()
        {
            InitializeComponent();
        }

        private void RedSenha_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Logofull;
            PcBxVisivel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtBxEmailRedSenha.Text) || string.IsNullOrEmpty(TxtBxSenhaRedSenha.Text))
                {
                    MessageBox.Show("Preencha Os Campos Para Atualizar A Senha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string parametro = TxtBxEmailRedSenha.Text.Trim();
                    string senha = TxtBxSenhaRedSenha.Text.Trim();
                    string senhaHash = "";
                    senhaHash = Hash.criptografarSenha(senha);

                    string query2 = $@"select 1 from Usuario where Email = '{parametro}'";

                    var retorno2 = DBase.LoadData<ExisteUsuarioDoador>(query2);

                    if (retorno2.Count() == 0)
                    {
                        MessageBox.Show("Email não cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string query1 = $@"select 1 from Usuario 
                                           where Email = '{parametro}'
                                           and Senha = '{senhaHash}'";

                        var retorno1 = DBase.LoadData<ExisteUsuarioDoador>(query1);

                        if (retorno1.Count() == 0)
                        {
                            string query = $@"update a set Senha = '{senhaHash}'
                                              from Usuario a 
                                              where Email = '{parametro}'
                                              and Senha <> '{senhaHash}'";

                            var retorno = DBase.ExecuteWithReturnAffected(query);

                            if (retorno == 0)
                            {
                                MessageBox.Show("Erro ao atualizar a senha, valide o e-mail", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Sucesso ao atualizar a senha", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("A senha nova não pode ser a mesma que a antiga", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TxtBxSenhaRedSenha.UseSystemPasswordChar = false;
            PcBxInvisivel.Visible = false;
            PcBxVisivel.Visible = true;
        }

        private void PcBxVisivel_Click(object sender, EventArgs e)
        {
            TxtBxSenhaRedSenha.UseSystemPasswordChar = true;
            PcBxVisivel.Visible = false;
            PcBxInvisivel.Visible = true;
        }
    }
}
