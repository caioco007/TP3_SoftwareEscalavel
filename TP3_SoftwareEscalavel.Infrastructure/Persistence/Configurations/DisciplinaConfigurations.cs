using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SoftwareEscalavel.Core.Entities;

namespace TP3_SoftwareEscalavel.Infrastructure.Persistence.Configurations
{
    public class DisciplinaConfigurations : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasOne(c => c.Professor)
                .WithMany(p => p.Disciplinas)
                .HasForeignKey(c => c.IdProfessor)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(d => d.Alunos)
                .WithOne()
                .HasForeignKey(c => c.IdAluno)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
