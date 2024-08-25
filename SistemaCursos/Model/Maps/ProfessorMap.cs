using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaCursos.Model.Entities;

namespace SistemaCursos.Model.Maps
{
    internal class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professores");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("nvarchar(150)")
                .IsRequired();

            builder.Property(x => x.EMail)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.HasMany(x => x.Cursos)
           .WithOne(c => c.Professor)
           .HasForeignKey(c => c.IdProfessor);
        }
    }
}
