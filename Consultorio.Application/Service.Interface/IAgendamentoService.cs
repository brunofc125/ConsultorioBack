using Consultorio.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Application.Service.Interface
{
    public interface IAgendamentoService
    {
        public bool CadastrarAgendamento(AgendamentoViewModel agendamento);
        public AgendamentoViewModel GetAgendamento(string id);
        public AgendamentoViewModelPaciente GetAgendamentoPaciente(string id);
        public bool DeletarAgendamento(string id);
        public bool AtualizarAgendamento(AgendamentoViewModel agendamento);
        public IEnumerable<AgendamentoViewModel> ObterAgendamentos(DateTime horario, bool todos);
        public IEnumerable<AgendamentoViewModelPaciente> ObterAgendamentosPaciente(DateTime horario, bool todos);
        public IEnumerable<AgendamentoViewModelPaciente> ObterAgendamentosPaciente(string nome);

    }
}
