namespace SistemaCursos.Model.Entities
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string EMail { get; set; }

        public Pessoa() { }

        public Pessoa(string nome, string eMail)
        {
            Nome = nome;
            EMail = eMail;
        }

    }
}
