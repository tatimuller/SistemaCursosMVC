namespace SistemaCursos.Model.Entities
{
    public class Aluno : Pessoa
    {
        public string Endereco { get; set; }
        public bool Ativo { get; set; }

        public List<Matricula> Matriculas { get; set; } = new List<Matricula>();
        

        public Aluno(string nome, string eMail, string endereco) : base(nome, eMail)
        {
            Endereco = endereco;
            Ativo = true;

        }
        public Aluno AlterarNome(string nome)
        {           
            this.Nome = nome;
            return this;
        }
      

        public void AtualizarInformacoes(string nome, string endereco, string email)
        {
            Nome = nome;
            Endereco = endereco;
            EMail = email;

        }
    }
}
