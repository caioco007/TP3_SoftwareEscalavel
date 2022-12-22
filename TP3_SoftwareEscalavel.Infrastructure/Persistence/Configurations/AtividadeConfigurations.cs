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
    internal class AtividadeConfigurations : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.DataInicioEntrega)
                .HasColumnType("Date");

            builder
                .Property(c => c.DataFinalEntrega)
                .HasColumnType("Date");
        }
    }
}
