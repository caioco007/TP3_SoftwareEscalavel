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
    public class DisciplinaAlunoConfigurations : IEntityTypeConfiguration<DisciplinaAluno>
    {
        public void Configure(EntityTypeBuilder<DisciplinaAluno> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasIndex(k => new { k.IdDisciplina, k.IdAluno})
                .IsUnique(true);
        }
    }
}
