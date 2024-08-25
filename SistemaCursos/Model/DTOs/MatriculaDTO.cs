using SistemaCursos.Model.Enums;

namespace SistemaCursos.Model.DTOs
{
    public class MatriculaDTO
    {
        public int Id { get; set; }
        public DateTime DataMatricula { get; set; }
        public EnumStatusMatricula Status { get; set; }
        public AlunoDTO Aluno { get; set; }
        public CursoDTO Curso { get; set; }
    }
}
