using SistemaCursos.Model.Entities;

namespace SistemaCursos.Dados.Repositories
{
    public class ProfessorRepository
    {
        private readonly Contexto _contexto;

        public ProfessorRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public Professor BuscarPorId(int id)
        {
            return _contexto.Professores.Find(id);
        }

        public IEnumerable<Professor> BuscarTodos()
        {
            return _contexto.Professores.ToList();
        }

        public void Adicionar(Professor professor)
        {
            _contexto.Professores.Add(professor);
            _contexto.SaveChanges();
        }

        public void Alterar(Professor professor)
        {
            _contexto.Professores.Update(professor);
            _contexto.SaveChanges();
        }

        public void Remover(int id)
        {
            var professor = BuscarPorId(id);
            _contexto.Professores.Remove(professor);
            _contexto.SaveChanges();
        }
    }
}
