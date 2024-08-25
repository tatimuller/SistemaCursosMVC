namespace SistemaCursos.Model.Entities
{
    public class Professor : Pessoa
    {
        public List<Curso> Cursos { get; set; } = new List<Curso>();

        public Professor() { }

        public Professor(string nome, string eMail) : base(nome, eMail)
        {

        }
    }
}
