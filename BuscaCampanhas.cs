namespace Salve_Vidas
{
    public class BuscaCampanhas
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Hospital { get; set; }

        public string DataCriacao { get; set; }

        public string DataFinalizacao { get; set; }
    }

    public class BuscaHospitais
    {
        public string Hospital { get; set; }

        public string Endereço { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string Telefone { get; set; }
    }

    public class BuscaCampanhasUsuarios
    {
        public string Campanha { get; set; }

        public string Hospital { get; set; }

        public string Descricao { get; set; }

        public string Endereço { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Contato { get; set; }
    }
    public class BuscaCampanhasHospitais
    {
        public string Campanha { get; set; }

        public string Hospital { get; set; }

        public string Descricao { get; set; }

        public string Endereço { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Contato { get; set; }
    }
}
