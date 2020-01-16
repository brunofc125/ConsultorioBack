using Consultorio.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Infra.Data.Configuration
{
    class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired(true);
            builder.Property(x => x.DataNasc).IsRequired(true);
            builder.Property(x => x.Crm).IsRequired(true);
            builder.HasMany(x => x.Agendamentos).WithOne(x => x.Medico).HasForeignKey(x => x.IdMedico).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
