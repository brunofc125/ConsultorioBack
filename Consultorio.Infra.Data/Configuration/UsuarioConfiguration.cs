using Consultorio.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Infra.Data.Configuration
{
    class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Login).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Senha).HasMaxLength(100).IsRequired(true);
            builder.HasMany(x => x.Agendamentos).WithOne(x => x.Usuario).HasForeignKey(x => x.IdUsuario).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
