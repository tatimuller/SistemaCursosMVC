using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaCursos.Model.Entities;

namespace SistemaCursos.Model.Maps
{
    public class MatriculaMap : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.ToTable("Matriculas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataMatricula)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.HasOne(m => m.Aluno)
            .WithMany(a => a.Matriculas)
            .HasForeignKey(m => m.IdAluno);

            builder.HasOne(m => m.Curso)
                .WithMany(c => c.Matriculas)
                .HasForeignKey(m => m.IdCurso);
        }
    }
}
