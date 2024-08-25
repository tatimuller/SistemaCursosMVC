using Microsoft.EntityFrameworkCore;
using SistemaCursos.Model.Entities;
using SistemaCursos.Model.Maps;

namespace SistemaCursos.Dados
{
    public class Contexto : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1; Database = sistemacursos; User Id = sa; Password = Docker@#; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new MatriculaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
 }
