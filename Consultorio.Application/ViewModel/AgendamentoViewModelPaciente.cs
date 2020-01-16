using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Application.ViewModel
{
    public class AgendamentoViewModelPaciente
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdPaciente { get; set; }
        public Guid IdMedico { get; set; }
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }
        public string Observacao { get; set; }
        public PacienteViewModel Paciente { get; set; }
        public AgendamentoViewModelPaciente()
        {

        }
        public AgendamentoViewModelPaciente(Guid id, Guid idUsuario, Guid idPaciente, Guid idMedico, DateTime horarioInicial, DateTime horarioFinal, string observacao, PacienteViewModel paciente)
        {
            this.Id = id;
            this.IdUsuario = idUsuario;
            this.IdPaciente = idPaciente;
            this.IdMedico = idMedico;
            this.HorarioInicial = horarioInicial;
            this.HorarioFinal = horarioFinal;
            this.Observacao = observacao;
            this.Paciente = paciente;
        }
        public AgendamentoViewModelPaciente(Guid idUsuario, Guid idPaciente, Guid idMedico, DateTime horarioInicial, DateTime horarioFinal, string observacao, PacienteViewModel paciente)
        {
            this.IdUsuario = idUsuario;
            this.IdPaciente = idPaciente;
            this.IdMedico = idMedico;
            this.HorarioInicial = horarioInicial;
            this.HorarioFinal = horarioFinal;
            this.Observacao = observacao;
            this.Paciente = paciente;
        }
    }
}
