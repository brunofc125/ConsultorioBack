using Consultorio.Domain.Entity;
using Consultorio.Infra.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Infra.Data.Context
{
    public class ConsultorioContext : DbContext
    {
        public ConsultorioContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new PacienteConfiguration());
            modelBuilder.ApplyConfiguration(new AgendamentoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
