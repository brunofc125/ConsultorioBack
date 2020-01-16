using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Application.ViewModel
{
    public class AgendamentoViewModel
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdPaciente { get; set; }
        public Guid IdMedico { get; set; }
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }
        public string Observacao { get; set; }
        public AgendamentoViewModel()
        {

        }

        public AgendamentoViewModel(Guid id, Guid idUsuario, Guid idPaciente, Guid idMedico, DateTime horarioInicial, DateTime horarioFinal, string observacao)
        {
            this.Id = id;
            this.IdUsuario = idUsuario;
            this.IdPaciente = idPaciente;
            this.IdMedico = idMedico;
            this.HorarioInicial = horarioInicial;
            this.HorarioFinal = horarioFinal;
            this.Observacao = observacao;
        }
        public AgendamentoViewModel(Guid idUsuario, Guid idPaciente, Guid idMedico, DateTime horarioInicial, DateTime horarioFinal, string observacao)
        {
            this.IdUsuario = idUsuario;
            this.IdPaciente = idPaciente;
            this.IdMedico = idMedico;
            this.HorarioInicial = horarioInicial;
            this.HorarioFinal = horarioFinal;
            this.Observacao = observacao;
        }
    }
}
