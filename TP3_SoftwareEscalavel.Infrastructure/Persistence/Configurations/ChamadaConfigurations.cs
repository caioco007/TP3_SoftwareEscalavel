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
    public class ChamadaConfigurations : IEntityTypeConfiguration<Chamada>
    {
        public void Configure(EntityTypeBuilder<Chamada> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasIndex(k => new { k.DataCriacao, k.IdDisciplina, k.IdAluno })
                .IsUnique(true);

            builder
                .Property(c => c.DataCriacao)
                .HasColumnType("Date");

        }
    }
}
