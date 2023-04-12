namespace Salve_Vidas.Model
{
    internal class ExisteUsuario
    {
        public string Nome { get; set; }
    }
    internal class SenhaUsuario
    {
        public string Senha { get; set; }
    }

    internal class Transferencias
    {
        public string Hospital { get; set; }
        public string TipoSolicitado { get; set; }
        public string Quantidade { get; set; }
        public string Telefone { get; set; }
        public string DataDaSolicitacao { get; set; }
    }
    internal class SemTransferencias
    {
        public string Transferencia { get; set; }
    }

    internal class QuantidadeEstoque
    {
        public string QuantidadeMinima { get; set; }
        public string QuantidadeMaxima { get; set; }
        public string QuantidadeAtual { get; set; }
    }

    internal class ExisteUsuarioDoador
    {
        public string Nome { get; set; }
        public string NomeHospital { get; set; }
    }

    internal class AtualizarCadastro
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }

    internal class ExisteUsuarioHospital
    {
        public string Nome { get; set; }
    }
    internal class IdDoador
    {
        public string Id { get; set; }
    }
    internal class IdUsuario
    {
        public string Id { get; set; }
    }

    internal class TiposSanguineos
    {
        public string Descricao { get; set; }
        public string Id { get; set; }
    }

    internal class EstadosNome
    {
        public string Nome { get; set; }
    }

    internal class EstadosId
    {
        public string Nome { get; set; }
        public string Id { get; set; }
    }

    internal class Hospitais
    {
        public string Nome { get; set; }
        public string Id { get; set; }
    }

    internal class IdHospitais
    {
        public string IdHospital { get; set; }
    }

    internal class EstoqueSangue
    {
        public int QuantidadeMinima { get; set; }
        public int QuantidadeMaxima { get; set; }
        public int QuantidadeAtual { get; set; }
    }

    internal class Transferencia
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
    }

    internal class TransferenciaFinalizadas
    {
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string DataDaSolicitacao { get; set; }
        public string DataFinalizacao { get; set; }
    }

    internal class IdCidadeHospital
    {
        public string IdHospital { get; set; }
        public string Cidade { get; set; }
    }

    internal class Cidade
    {
        public string Nome { get; set; }
        public string Id { get; set; }
    }

    internal class EstadosUF
    {
        public string UF { get; set; }
    }

    internal class Cidades
    {
        public string Nome { get; set; }
    }

    internal class EnderecoUsuario
    {
        public string Endereco { get; set; }
        public string Id { get; set; }
    }

    internal class CampanhasDoador
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Hospital { get; set; }
        public string Data { get; set; }
    }

    internal class UsuarioTipoSanguineo
    {
        public string Descricao { get; set; }
        public string DoaPara { get; set; }
        public string RecebeDe { get; set; }
        public string PessoasAjudadas { get; set; }
    }

    internal class Imagem
    {
        public string Foto { get; set; }
    }

    internal class Enderecos
    {
        public int NumeroDeEnderecos { get; set; }
    }

    internal class EnderecoDoador
    {
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string CodigoPostal { get; set; }
    }
    internal class Descricao
    {
        public string Texto { get; set; }
    }
}
