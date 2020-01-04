using Consultorio.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Infra.Data.Configuration
{
    class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired(true);
            builder.Property(x => x.DataNasc).IsRequired(true);
            builder.HasMany(x => x.Agendamentos).WithOne(x => x.Paciente).HasForeignKey(x => x.IdPaciente).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
