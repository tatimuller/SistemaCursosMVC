namespace SistemaCursos.Model.Entities
{
    public class Curso
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Vagas { get; set; }

        public int IdProfessor { get; set; }
        public Professor Professor { get; set; }

        public List<Matricula> Matriculas { get; set; } = new List<Matricula>();

        public Curso() { }
        public Curso(string titulo, string descricao, int vagas, int idProfessor)
        {
            Titulo = titulo;
            Descricao = descricao;
            Vagas = vagas;
            IdProfessor = idProfessor;
        }

        public bool PossuiVagas()
        {
            return Vagas < 30;
        }
    }
}
