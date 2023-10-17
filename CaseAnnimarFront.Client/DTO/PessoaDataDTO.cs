namespace CaseAnnimarFront.Client.DTO
{
    public class PessoaDataDTO
    {
        public PessoaDataDTO() { }  

        public PessoaDataDTO(int id , string nome , string sobrenome , DateTime dataNascimento , DateTime dataInsercao , string profissao) {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            DataInsercao = dataInsercao;
            Profissao = profissao;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInsercao { get; set; }
        public string Profissao { get; set; }

    }
}
