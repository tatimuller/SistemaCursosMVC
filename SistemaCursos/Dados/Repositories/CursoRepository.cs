using SistemaCursos.Model.Entities;

namespace SistemaCursos.Dados.Repositories
{
    public class CursoRepository
    {
        private readonly Contexto _contexto;

        public CursoRepository(Contexto context)
        {
            _contexto = context;
        }

        public Curso BuscarPeloId(int id)
        {
            return _contexto.Cursos.Find(id);
        }

        public void Adicionar(Curso curso)
        {
            _contexto.Cursos.Add(curso);
            _contexto.SaveChanges();
        }

        public void Alterar(Curso curso)
        {
            _contexto.Cursos.Update(curso);
            _contexto.SaveChanges();
        }

        public void Remover(int id)
        {
            var curso = BuscarPeloId(id);
            _contexto.Cursos.Remove(curso);
            _contexto.SaveChanges();
        }

        public IEnumerable<Curso> BuscarTodos()
        {
            return _contexto.Cursos.ToList();
        }
    }

}
