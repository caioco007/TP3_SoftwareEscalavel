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
    public class AtividadeAlunosConfigurations : IEntityTypeConfiguration<AtividadeAluno>
    {
        public void Configure(EntityTypeBuilder<AtividadeAluno> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasIndex(k => new { k.IdAtividade, k.IdAluno})
                .IsUnique(true);

            builder
                .Property(c => c.DataEntrega)
                .HasColumnType("Date");

            builder
                .Property(p => p.Nota)
                .HasColumnType("decimal");
        }
    }
}
