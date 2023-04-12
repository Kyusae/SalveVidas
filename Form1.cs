using Salve_Vidas.Db;
using Salve_Vidas.Model;

namespace Salve_Vidas
{
    public partial class SalveVidas : Form
    {
        public SalveVidas()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Logofull;
            toolTip1.SetToolTip(PcBxInvisivel, "Mostrar Senha");
            toolTip1.SetToolTip(PcBxVisivel, "Esconder Senha");
            PcBxVisivel.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            var retorno = DBase.TestaConexao();

            if (retorno == "Erro")
            {

            }
            else
            {
                RedSenha redSenha = new RedSenha();
                redSenha.ShowDialog();
            }
        }

        private void BtLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var retornoConexao = DBase.TestaConexao();

                if (retornoConexao == "Erro")
                {

                }
                else
                {
                    if (string.IsNullOrEmpty(TxtBxEmail.Text) || string.IsNullOrEmpty(TxtBxSenha.Text))
                    {
                        MessageBox.Show("Preencha Os Campos Para Realizar Login", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string Email = TxtBxEmail.Text.Trim();

                        string senha = TxtBxSenha.Text.Trim();
                        string senhaHash = "";
                        senhaHash = Hash.criptografarSenha(senha);

                        string query = $@"select Nome from Usuario a
                                      where Email = '{Email}' and DataExclusao is null";

                        var retorno = DBase.LoadData<ExisteUsuario>(query);

                        if (retorno.Count() == 0)
                        {
                            MessageBox.Show("Email não cadastrado/Usuario Deletado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string query1 = $@"select Nome from Usuario a
                                           where Email = '{Email}'
                                           and Senha = '{senhaHash}'
                                           and DataExclusao is null";

                            var retorno1 = DBase.LoadData<ExisteUsuario>(query1);

                            if (retorno1.Count() == 0)
                            {
                                MessageBox.Show("Senha Incorreta", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string query3 = $@"select distinct c.Nome from Usuario a
                                               join UsuarioDoador b on b.IdUsuario = a.Id 
                                               join Doador c on b.IdDoador = c.Id 
                                               where a.Email = '{Email}' 
                                               and a.Senha = '{senhaHash}' 
                                               and a.DataExclusao is null";

                                var retorno3 = DBase.LoadData<ExisteUsuarioDoador>(query3);

                                if (retorno3.Count() == 0)
                                {
                                    string query4 = $@"select c.Nome from Usuario a 
                                               join UsuarioHospital b on b.IdUsuario = a.Id 
                                               join Hospital c on b.IdHospital = c.Id
                                               where a.Email = '{Email}'
                                               and a.Senha = '{senhaHash}'
                                               and a.DataExclusao is null";

                                    var retorno4 = DBase.LoadData<ExisteUsuarioHospital>(query4);

                                    if (retorno4.Count() == 0)
                                    {
                                        LoginUsuario loginUsuario = new LoginUsuario();
                                        loginUsuario.value = TxtBxEmail.Text;
                                        loginUsuario.value2 = senhaHash;
                                        this.Visible = false;
                                        loginUsuario.Show();
                                    }
                                    else
                                    {
                                        LoginHospital loginHospital = new LoginHospital();
                                        loginHospital.value = TxtBxEmail.Text;
                                        loginHospital.value2 = senhaHash;
                                        this.Visible = false;
                                        loginHospital.Show();
                                    }
                                }
                                else
                                {
                                    LoginUsuario loginUsuario = new LoginUsuario();
                                    loginUsuario.value = TxtBxEmail.Text;
                                    loginUsuario.value2 = senhaHash;
                                    this.Visible = false;
                                    loginUsuario.Show();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            var retorno = DBase.TestaConexao();

            if (retorno == "Erro")
            {

            }
            else
            {
                Cadastro cadastraUsu = new Cadastro();
                cadastraUsu.ShowDialog();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TxtBxSenha.UseSystemPasswordChar = false;
            PcBxInvisivel.Visible = false;
            PcBxVisivel.Visible = true;
        }

        private void PcBxVisivel_Click(object sender, EventArgs e)
        {
            TxtBxSenha.UseSystemPasswordChar = true;
            PcBxVisivel.Visible = false;
            PcBxInvisivel.Visible = true;
        }

        public const string NotAllowed2 = @"'";

        private void TxtBxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NotAllowed2.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}