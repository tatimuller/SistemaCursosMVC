using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaCursos.Model.Entities;

namespace SistemaCursos.Model.Maps
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("Cursos");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                .HasColumnType("nvarchar(150)")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.HasOne(x => x.Professor)
           .WithMany(p => p.Cursos)
           .HasForeignKey(c => c.IdProfessor);

            builder.HasMany(x => x.Matriculas)
                .WithOne(m => m.Curso)
                .HasForeignKey(m => m.Id);
        }
    }
}
