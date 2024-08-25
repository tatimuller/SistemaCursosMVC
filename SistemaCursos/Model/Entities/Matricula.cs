using SistemaCursos.Model.Enums;

namespace SistemaCursos.Model.Entities
{
    public class Matricula
    {
        public int Id { get; private set; }
        public DateTime DataMatricula { get; set; }
        public EnumStatusMatricula Status { get; set; }

        public int IdAluno { get; set; }
        public Aluno Aluno { get; set; }

        public int IdCurso { get; set; }
        public Curso Curso { get; set; }

        public Matricula() { }

        public Matricula(DateTime dataMatricula, EnumStatusMatricula status, int idAluno, int cursoId)
        {
            DataMatricula = dataMatricula;
            Status = status;
            IdAluno = idAluno;
            IdCurso = cursoId;
        }

        public void ConcluirMatricula()
        {

            if (Curso.PossuiVagas() && DataMatricula > DateTime.Now && Status == EnumStatusMatricula.Ativa)
            {
                Status = EnumStatusMatricula.Concluida;
            }
        }

        public void CancelarMatricula()
        {
            Status = EnumStatusMatricula.Cancelada;
        }
    }
}
}
