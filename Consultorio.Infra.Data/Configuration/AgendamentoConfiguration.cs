using Consultorio.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Infra.Data.Configuration
{
    class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.HorarioInicial).IsRequired(true);
            builder.Property(x => x.HorarioFinal).IsRequired(true);
            builder.Property(x => x.Observacao).HasMaxLength(200).IsRequired(true);
        }
    }
}
