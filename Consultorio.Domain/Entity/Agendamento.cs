using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Domain.Entity
{
    public class Agendamento
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdPaciente { get; set; }
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }
        public string Observacao { get; set; }
        public Paciente Paciente { get; set; }
        public Usuario Usuario { get; set; }
        public Agendamento(Guid id, Guid idUsuario, Guid idPaciente, DateTime horarioInicial, DateTime horarioFinal, string observacao)
        {
            this.Id = id;
            this.IdUsuario = idUsuario;
            this.IdPaciente = idPaciente;
            this.HorarioInicial = horarioInicial;
            this.HorarioFinal = horarioFinal;
            this.Observacao = observacao;
        }
        public Agendamento(Guid idUsuario, Guid idPaciente, DateTime horarioInicial, DateTime horarioFinal, string observacao)
        {
            this.IdUsuario = idUsuario;
            this.IdPaciente = idPaciente;
            this.HorarioInicial = horarioInicial;
            this.HorarioFinal = horarioFinal;
            this.Observacao = observacao;
        }
    }
}
